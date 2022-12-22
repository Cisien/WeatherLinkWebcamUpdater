using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace WeatherLinkWebcamUpdater
{
    class Program
    {
        private static readonly CancellationTokenSource _cts = new ();
        private static readonly Timer _updateTimer = new (async o => await UpdateCamera(), null, Timeout.Infinite, Timeout.Infinite);
        private static readonly HttpClientHandler _httpClientHandler = new ();

        private static string _weatherLinkLocalIp = "127.0.0.1";
        private static string _weatherCamIp = "127.0.0.1";
        private static string _weatherCamUsername = string.Empty;
        private static string _weatherCamPassword = string.Empty;

        private static readonly XmlSerializer _xmlSerializer = new(typeof(VideoOverlay));
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            AllowTrailingCommas = true
        };

        static async Task Main()
        {
            Console.WriteLine("Starting...");
            Console.CancelKeyPress += Console_CancelKeyPress;
            _updateTimer.Change(TimeSpan.Zero, TimeSpan.FromMinutes(1));
            _weatherLinkLocalIp = Environment.GetEnvironmentVariable("WEATHER_LINK_IP");
            _weatherCamIp = Environment.GetEnvironmentVariable("WEATHER_CAM_IP");
            _weatherCamUsername = Environment.GetEnvironmentVariable("WEATHER_CAM_USERNAME");
            _weatherCamPassword = Environment.GetEnvironmentVariable("WEATHER_CAM_PASSWORD");

            try
            {
                await Task.Delay(-1, _cts.Token);
            }
            catch (TaskCanceledException) { }

            _cts.Dispose();
            _updateTimer.Change(Timeout.Infinite, Timeout.Infinite);
            _updateTimer.Dispose();
        }

        private static async Task UpdateCamera()
        {
            var currentConditions = await GetCurrentConditions();

            await UpdateWeatherCamOverlay(currentConditions);

        }

        private static async Task UpdateWeatherCamOverlay(WeatherLinkCurrentConditions currentConditions)
        {
            using var httpClient = new HttpClient(_httpClientHandler, false);
            var credsBytes = Encoding.ASCII.GetBytes($"{_weatherCamUsername}:{_weatherCamPassword}");
            var credsEncoded = Convert.ToBase64String(credsBytes);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credsEncoded);

            var overlayString = "Unavailable";
            if ((currentConditions?.Data?.Conditions?.Count ?? 0) == 0)
            {
                return;
            }

            var cc = currentConditions.Data.Conditions[0];
            var bar = currentConditions.Data.Conditions[2];
            var trend = "=";

            if (bar.BarTrend > 0)
            {
                trend = "+";
            }
            else if (bar.BarTrend < 0)
            {
                trend = "-";
            }

            overlayString = $"{cc.Temp:00.0}f {33.8638815 * bar.BarSeaLevel:000.0}mb{trend} {DegreesToCardinalDetailed(cc.WindDirScalarAvgLast1_Min ?? 0)} {cc.WindSpeedAvgLast1_Min ?? 0.0d:0.0}mph {cc.RainfallLast24_Hr * 0.01:0.00}in {cc.RainRateLast * 0.01:0.00}in/hr";

            var overlay = new VideoOverlay
            {
                attribute = new VideoOverlayAttribute { flashing = false, transparent = false },
                fontSize = "64*64",
                frontColorMode = "auto",
                channelNameOverlay = new VideoOverlayChannelNameOverlay { enabled = false, positionX = 0, positionY = 0 },
                DateTimeOverlay = new VideoOverlayDateTimeOverlay { enabled = true, dateStyle = "DD-MM-YYYY", displayWeek = true, timeStyle = "24hour", positionX = 0, positionY = 0 },
                TextOverlayList = new[]{
                    new VideoOverlayTextOverlay { displayText = overlayString, enabled = true, id = 1, positionX = 16, positionY = 480 },
                    new VideoOverlayTextOverlay { displayText = string.Empty, enabled = false, id = 2, positionX = 0, positionY = 0 },
                    new VideoOverlayTextOverlay { displayText = string.Empty, enabled = false, id = 3, positionX = 0, positionY = 0 },
                    new VideoOverlayTextOverlay { displayText = string.Empty, enabled = false, id = 4, positionX = 0, positionY = 0 }
                }
            };

            var sw = new StringBuilder();
            using var writer = XmlWriter.Create(sw, new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                NewLineChars = "\n",
                ConformanceLevel = ConformanceLevel.Auto,
                OmitXmlDeclaration = true,
                WriteEndDocumentOnClose = true,
                Indent = true
            });
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            _xmlSerializer.Serialize(new FullTagXmlWriter(writer), overlay, namespaces);
            var xml = sw.ToString();
            using var content = new StringContent(xml, Encoding.UTF8, "application/xml");
            using var response = await httpClient.PutAsync($"http://{_weatherCamIp}/ISAPI/System/Video/inputs/channels/1/overlays", content);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Overlay update failed: {response.StatusCode}");
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Request: {xml}\nResponse: {responseContent}");

            }
            else
            {
                Console.WriteLine($"Overlay updated to {overlayString}");
            }
        }

        public static string DegreesToCardinalDetailed(double degrees)
        {
            string[] caridnals = { "  N", "NNE", " NE", "ENE", "  E", "ESE", " SE", "SSE", "  S", "SSW", " SW", "WSW", "  W", "WNW", " NW", "NNW", "  N" };
            return caridnals[(int)Math.Round(degrees * 10 % 3600 / 225)];
        }

        private static async Task<WeatherLinkCurrentConditions> GetCurrentConditions()
        {

            using var httpClient = new HttpClient(_httpClientHandler, false);
            string currentConditionsJson;
            try
            {

                currentConditionsJson = await httpClient.GetStringAsync($"http://{_weatherLinkLocalIp}/v1/current_conditions");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

            try
            {
                return JsonSerializer.Deserialize<WeatherLinkCurrentConditions>(currentConditionsJson, _jsonOptions);
            }
            catch (JsonException ex)
            {
                var badJsonIndex = Math.Min(0, ((int)ex.BytePositionInLine.Value) - 20);
                Console.WriteLine($"{ex.Message}: \n{currentConditionsJson[badJsonIndex..^0]}");
                return null;
            }
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
            _cts.Cancel();
        }
    }
}

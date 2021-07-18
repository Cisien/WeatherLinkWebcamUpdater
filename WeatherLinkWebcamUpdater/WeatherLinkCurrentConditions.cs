
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WeatherLinkWebcamUpdater
{
    public class WeatherLinkCurrentConditions
    {
        [JsonPropertyName("data")]
        public Data Data { get; set; }

        [JsonPropertyName("error")]
        public object Error { get; set; }
    }


    public partial class Data
    {
        [JsonPropertyName("did")]
        public string Did { get; set; }

        [JsonPropertyName("ts")]
        public long Ts { get; set; }

        [JsonPropertyName("conditions")]
        public List<Condition> Conditions { get; set; }
    }

    public partial class Condition
    {
        [JsonPropertyName("lsid")]
        public long Lsid { get; set; }

        [JsonPropertyName("data_structure_type")]
        public long DataStructureType { get; set; }

        [JsonPropertyName("txid")]
        public long? Txid { get; set; }

        [JsonPropertyName("temp")]
        public double? Temp { get; set; }

        [JsonPropertyName("hum")]
        public double? Hum { get; set; }

        [JsonPropertyName("dew_point")]
        public double? DewPoint { get; set; }

        [JsonPropertyName("wet_bulb")]
        public double? WetBulb { get; set; }

        [JsonPropertyName("heat_index")]
        public double? HeatIndex { get; set; }

        [JsonPropertyName("wind_chill")]
        public double? WindChill { get; set; }

        [JsonPropertyName("thw_index")]
        public double? ThwIndex { get; set; }

        [JsonPropertyName("thsw_index")]
        public double? ThswIndex { get; set; }

        [JsonPropertyName("wind_speed_last")]
        public double? WindSpeedLast { get; set; }

        [JsonPropertyName("wind_dir_last")]
        public int? WindDirLast { get; set; }

        [JsonPropertyName("wind_speed_avg_last_1_min")]
        public double? WindSpeedAvgLast1_Min { get; set; }

        [JsonPropertyName("wind_dir_scalar_avg_last_1_min")]
        public long? WindDirScalarAvgLast1_Min { get; set; }

        [JsonPropertyName("wind_speed_avg_last_2_min")]
        public double? WindSpeedAvgLast2_Min { get; set; }

        [JsonPropertyName("wind_dir_scalar_avg_last_2_min")]
        public long? WindDirScalarAvgLast2_Min { get; set; }

        [JsonPropertyName("wind_speed_hi_last_2_min")]
        public double? WindSpeedHiLast2_Min { get; set; }

        [JsonPropertyName("wind_dir_at_hi_speed_last_2_min")]
        public long? WindDirAtHiSpeedLast2_Min { get; set; }

        [JsonPropertyName("wind_speed_avg_last_10_min")]
        public double? WindSpeedAvgLast10_Min { get; set; }

        [JsonPropertyName("wind_dir_scalar_avg_last_10_min")]
        public long? WindDirScalarAvgLast10_Min { get; set; }

        [JsonPropertyName("wind_speed_hi_last_10_min")]
        public double? WindSpeedHiLast10_Min { get; set; }

        [JsonPropertyName("wind_dir_at_hi_speed_last_10_min")]
        public long? WindDirAtHiSpeedLast10_Min { get; set; }

        [JsonPropertyName("rain_size")]
        public long? RainSize { get; set; }

        [JsonPropertyName("rain_rate_last")]
        public long? RainRateLast { get; set; }

        [JsonPropertyName("rain_rate_hi")]
        public long? RainRateHi { get; set; }

        [JsonPropertyName("rainfall_last_15_min")]
        public long? RainfallLast15_Min { get; set; }

        [JsonPropertyName("rain_rate_hi_last_15_min")]
        public long? RainRateHiLast15_Min { get; set; }

        [JsonPropertyName("rainfall_last_60_min")]
        public long? RainfallLast60_Min { get; set; }

        [JsonPropertyName("rainfall_last_24_hr")]
        public long? RainfallLast24_Hr { get; set; }
        
        [JsonPropertyName("rain_storm")]
        public long? RainStorm { get; set; }

        [JsonPropertyName("rain_storm_start_at")]
        public long? RainStormStartAt { get; set; }

        [JsonPropertyName("solar_rad")]
        public long? SolarRad { get; set; }

        [JsonPropertyName("uv_index")]
        public double? UvIndex { get; set; }

        [JsonPropertyName("rx_state")]
        public long? RxState { get; set; }

        [JsonPropertyName("trans_battery_flag")]
        public long? TransBatteryFlag { get; set; }

        [JsonPropertyName("rainfall_daily")]
        public long? RainfallDaily { get; set; }

        [JsonPropertyName("rainfall_monthly")]
        public long? RainfallMonthly { get; set; }

        [JsonPropertyName("rainfall_year")]
        public long? RainfallYear { get; set; }

        [JsonPropertyName("rain_storm_last")]
        public object RainStormLast { get; set; }

        [JsonPropertyName("rain_storm_last_start_at")]
        public object RainStormLastStartAt { get; set; }

        [JsonPropertyName("rain_storm_last_end_at")]
        public object RainStormLastEndAt { get; set; }

        [JsonPropertyName("temp_in")]
        public double? TempIn { get; set; }

        [JsonPropertyName("hum_in")]
        public double? HumIn { get; set; }

        [JsonPropertyName("dew_point_in")]
        public double? DewPointIn { get; set; }

        [JsonPropertyName("heat_index_in")]
        public double? HeatIndexIn { get; set; }

        [JsonPropertyName("bar_sea_level")]
        public double? BarSeaLevel { get; set; }

        [JsonPropertyName("bar_trend")]
        public double? BarTrend { get; set; }

        [JsonPropertyName("bar_absolute")]
        public double? BarAbsolute { get; set; }
    }
}

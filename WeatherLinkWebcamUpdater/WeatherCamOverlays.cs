using System;
using System.Collections.Generic;
using System.Text;

#pragma warning disable IDE1006 // Naming Styles
namespace WeatherLinkWebcamUpdater
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class VideoOverlay
    {

        private VideoOverlayAttribute attributeField;

        private string fontSizeField;

        private string frontColorModeField;

        private VideoOverlayTextOverlay[] textOverlayListField;

        private VideoOverlayDateTimeOverlay dateTimeOverlayField;

        private VideoOverlayChannelNameOverlay channelNameOverlayField;

        /// <remarks/>
        public VideoOverlayAttribute attribute
        {
            get
            {
                return this.attributeField;
            }
            set
            {
                this.attributeField = value;
            }
        }

        /// <remarks/>
        public string fontSize
        {
            get
            {
                return this.fontSizeField;
            }
            set
            {
                this.fontSizeField = value;
            }
        }

        /// <remarks/>
        public string frontColorMode
        {
            get
            {
                return this.frontColorModeField;
            }
            set
            {
                this.frontColorModeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("TextOverlay", IsNullable = false)]
        public VideoOverlayTextOverlay[] TextOverlayList
        {
            get
            {
                return this.textOverlayListField;
            }
            set
            {
                this.textOverlayListField = value;
            }
        }

        /// <remarks/>
        public VideoOverlayDateTimeOverlay DateTimeOverlay
        {
            get
            {
                return this.dateTimeOverlayField;
            }
            set
            {
                this.dateTimeOverlayField = value;
            }
        }

        /// <remarks/>
        public VideoOverlayChannelNameOverlay channelNameOverlay
        {
            get
            {
                return this.channelNameOverlayField;
            }
            set
            {
                this.channelNameOverlayField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class VideoOverlayAttribute
    {

        private bool transparentField;

        private bool flashingField;

        /// <remarks/>
        public bool transparent
        {
            get
            {
                return this.transparentField;
            }
            set
            {
                this.transparentField = value;
            }
        }

        /// <remarks/>
        public bool flashing
        {
            get
            {
                return this.flashingField;
            }
            set
            {
                this.flashingField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class VideoOverlayTextOverlay
    {

        private byte idField;

        private bool enabledField;

        private string displayTextField;

        private byte positionXField;

        private ushort positionYField;

        /// <remarks/>
        public byte id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public bool enabled
        {
            get
            {
                return this.enabledField;
            }
            set
            {
                this.enabledField = value;
            }
        }

        /// <remarks/>
        public string displayText
        {
            get
            {
                return this.displayTextField;
            }
            set
            {
                this.displayTextField = value;
            }
        }

        /// <remarks/>
        public byte positionX
        {
            get
            {
                return this.positionXField;
            }
            set
            {
                this.positionXField = value;
            }
        }

        /// <remarks/>
        public ushort positionY
        {
            get
            {
                return this.positionYField;
            }
            set
            {
                this.positionYField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class VideoOverlayDateTimeOverlay
    {

        private bool enabledField;

        private byte positionYField;

        private byte positionXField;

        private string dateStyleField;

        private string timeStyleField;

        private bool displayWeekField;

        /// <remarks/>
        public bool enabled
        {
            get
            {
                return this.enabledField;
            }
            set
            {
                this.enabledField = value;
            }
        }

        /// <remarks/>
        public byte positionY
        {
            get
            {
                return this.positionYField;
            }
            set
            {
                this.positionYField = value;
            }
        }

        /// <remarks/>
        public byte positionX
        {
            get
            {
                return this.positionXField;
            }
            set
            {
                this.positionXField = value;
            }
        }

        /// <remarks/>
        public string dateStyle
        {
            get
            {
                return this.dateStyleField;
            }
            set
            {
                this.dateStyleField = value;
            }
        }

        /// <remarks/>
        public string timeStyle
        {
            get
            {
                return this.timeStyleField;
            }
            set
            {
                this.timeStyleField = value;
            }
        }

        /// <remarks/>
        public bool displayWeek
        {
            get
            {
                return this.displayWeekField;
            }
            set
            {
                this.displayWeekField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class VideoOverlayChannelNameOverlay
    {

        private bool enabledField;

        private byte positionYField;

        private byte positionXField;

        /// <remarks/>
        public bool enabled
        {
            get
            {
                return this.enabledField;
            }
            set
            {
                this.enabledField = value;
            }
        }

        /// <remarks/>
        public byte positionY
        {
            get
            {
                return this.positionYField;
            }
            set
            {
                this.positionYField = value;
            }
        }

                               /// <remarks/>
        public byte positionX
        {
            get
            {
                return this.positionXField;
            }
            set
            {
                this.positionXField = value;
            }
        }
    }
#pragma warning restore IDE1006 // Naming Styles
}

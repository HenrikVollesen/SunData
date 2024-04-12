using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace SunData
{
    internal class AnalemmaData
    {
        public string theDay { get; set; }
        public DateTime HourOfCalc { get; set; }
        public float Azimuth { get; set; }
        public float Altitude { get; set; }

    }
    internal class SunData
    {
        public string theDay { get; set; }
        public DateTime sunrise { get; set; }
        public DateTime sunset { get; set; }
        public DateTime solar_noon { get; set; }
        public int day_length { get; set; }
        public DateTime civil_twilight_begin { get; set; }
        public DateTime civil_twilight_end { get; set; }
        public DateTime nautical_twilight_begin { get; set; }
        public DateTime nautical_twilight_end { get; set; }
        public DateTime astronomical_twilight_begin { get; set; }
        public DateTime astronomical_twilight_end { get; set; }

    }
    internal class SunDataSettings
    {
        public SunDataSettings() 
        {
            Latitude = 57.01375;
            Longitude = 9.97723;

            CustomFormat = "yyyy-MM-dd";
            LogHourPart = 11;
            LogMinutePart = 20;

        }

        public SunDataSettings(string a_Settings_Path, string customFormat) : this() 
        {
            DataFolder = Path.GetDirectoryName(a_Settings_Path);
            DataFileName = Path.GetFileName(a_Settings_Path);
            StartDate = Util.wholeDay(DateTime.Now.ToUniversalTime());
            EndDate = StartDate + TimeSpan.FromDays(365);

            CustomFormat = customFormat;
        }

        public string DataFolder { get; set; }
        public string DataFileName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime dateTime { get; set; }
        public string theStartDay { get; set; }
        public string theEndDay { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string CustomFormat { get; private set; }
        public float Azimuth { get; set; }
        public float Altitude { get; set; }
        public int DaysBetweenLog { get; set; }
        public int LogHourPart { get; set; }
        public int LogMinutePart { get; set; }
        public bool AlignToLongitude { get; set; }
        public List<AnalemmaData> theAnalemmaData { get; set; }
        public List<SunData> theSunData { get; set; }
    }
}

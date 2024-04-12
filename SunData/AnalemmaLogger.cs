using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunData
{
    internal class AnalemmaLogger
    {
        public string dataContents { get; set; }
        public string csvPath { get; set; }
        public TimeSpan ts { get; set; }

        public async Task LogAnalemmaData(SunDataSettings loggerSettings)
        {
            csvPath = loggerSettings.DataFolder + @"\" + loggerSettings.DataFileName;
            WriteHeaderline();

            ts = loggerSettings.EndDate - loggerSettings.StartDate;
            DateTime dateLoop = loggerSettings.StartDate;
            DateTime dateLoopTime = dateLoop.AddHours(loggerSettings.LogHourPart);
            dateLoopTime = dateLoopTime.AddMinutes(loggerSettings.LogMinutePart);
            dateLoopTime = DateTime.SpecifyKind(dateLoopTime, DateTimeKind.Utc);

            loggerSettings.theAnalemmaData = new List<AnalemmaData>();
            loggerSettings.theAnalemmaData.Capacity = ts.Days + 1;

            int n = (ts.Days + 1) / loggerSettings.DaysBetweenLog;

            for (int i = 0; i <= n; i++)
            {
                loggerSettings.dateTime = dateLoopTime;
                string date_string = dateLoop.ToString(loggerSettings.CustomFormat);

                SunPosition.CalculateSunPosition(loggerSettings);

                AnalemmaData data = new AnalemmaData();
                data.theDay = date_string;
                data.HourOfCalc = dateLoopTime;
                data.Azimuth = loggerSettings.Azimuth;
                data.Altitude = loggerSettings.Altitude;
                loggerSettings.theAnalemmaData.Add(data);  
                //dataContents += "\n"; // End of Line
                dateLoop = dateLoop.AddDays((double)loggerSettings.DaysBetweenLog);
                if (dateLoop > loggerSettings.EndDate)
                    break;
                dateLoopTime = dateLoop.AddHours(loggerSettings.LogHourPart);
                dateLoopTime = dateLoopTime.AddMinutes(loggerSettings.LogMinutePart);
            }

            WriteData(loggerSettings);
        }

        private void WriteHeaderline()
        {
            dataContents = ""; // Start with empty string
            dataContents += "Day" + ";";
            dataContents += "HourOfCalc" + ";";
            dataContents += "Azimuth" + ";";
            dataContents += "Altitude" + ";";
            dataContents += "\n";
        }

        private void WriteData(SunDataSettings loggerSettings)
        {
            CultureInfo cultureDK = CultureInfo.GetCultureInfo("da-DK");
            List<AnalemmaData> theData = loggerSettings.theAnalemmaData;
            for (int i = 0; i < theData.Count; i++)
            {
                
                dataContents += theData[i].theDay + ";";
                dataContents += theData[i].HourOfCalc.ToString("T", cultureDK) + ";";
                dataContents += theData[i].Azimuth + ";";
                dataContents += theData[i].Altitude + ";";
                dataContents += "\n";
            }
            try
            {
                File.WriteAllText(csvPath, dataContents);
            }
            catch (System.IO.IOException)
            {
                throw new System.IO.IOException();
            }


        }
    }
}

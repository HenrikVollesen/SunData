using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Nodes;

namespace SunData
{
    internal class SunDataLogger
    {
        public string dataContents { get; set; }
        public string csvPath { get; set; }
        public TimeSpan ts { get; set; }

        public async Task LogSunData(SunDataSettings loggerSettings)
        {
            string theURI = @"https://api.sunrise-sunset.org/json";

            csvPath = loggerSettings.DataFolder + @"\" + loggerSettings.DataFileName;
            WriteHeaderline();

            HttpClient httpClient = new HttpClient();
            string latit = loggerSettings.Latitude.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            string longit = loggerSettings.Longitude.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            string pos = "?lat=" + latit + "&lng=" + longit;
            string date = "&date=";
            string formatted = "&formatted=0";
            string tzid = "&tzid=Europe/Copenhagen";

            ts = loggerSettings.EndDate - loggerSettings.StartDate;

            DateTime dateLoop = loggerSettings.StartDate;

            string jsonContents;
            JsonNode root;
            JsonNode status;
            JsonNode results;

            loggerSettings.theSunData = new List<SunData>();
            loggerSettings.theSunData.Capacity = ts.Days+1;

            int n = (ts.Days + 1) / loggerSettings.DaysBetweenLog;
            Util.SetProgressBar(1, 0, n);

            for (int i = 0; i <= n; i++)
            {
                string date_string = dateLoop.ToString(loggerSettings.CustomFormat);
                string api_request = theURI + pos + date + date_string + formatted + tzid;
                Util.SetProgressBar(1, i);

                try
                {
                    jsonContents = await httpClient.GetStringAsync(api_request);
                    root = JsonNode.Parse(jsonContents);
                    status = root["status"];
                    if (status.ToString() == "OK")
                    {
                        results = root["results"];
                        SunData thesunData = new();

                        thesunData.theDay = date_string;
                        thesunData.sunrise = DateTime.Parse(results["sunrise"].ToString());
                        thesunData.sunset = DateTime.Parse(results["sunset"].ToString());
                        thesunData.solar_noon = DateTime.Parse(results["solar_noon"].ToString());
                        thesunData.day_length = Int32.Parse(results["day_length"].ToString());
                        thesunData.civil_twilight_begin = DateTime.Parse(results["civil_twilight_begin"].ToString());
                        thesunData.civil_twilight_end = DateTime.Parse(results["civil_twilight_end"].ToString());
                        thesunData.nautical_twilight_begin = DateTime.Parse(results["nautical_twilight_begin"].ToString());
                        thesunData.nautical_twilight_end = DateTime.Parse(results["nautical_twilight_end"].ToString());
                        thesunData.astronomical_twilight_begin = DateTime.Parse(results["astronomical_twilight_begin"].ToString());
                        thesunData.astronomical_twilight_end = DateTime.Parse(results["astronomical_twilight_end"].ToString());
                        loggerSettings.theSunData.Add(thesunData);

                    }

                }
                catch (Exception ex)
                {
                    jsonContents = ex.Message;
                    continue;
                }

                dateLoop = dateLoop.AddDays((double)loggerSettings.DaysBetweenLog);
                if (dateLoop > loggerSettings.EndDate)
                    break;
            }

            WriteData(loggerSettings);
            //File.WriteAllText(csvPath, dataContents);

        }
        private void WriteHeaderline()
        {
            dataContents = ""; // Start with empty string
            dataContents += "Date" + ";";
            dataContents += "sunrise" + ";";
            dataContents += "sunset" + ";";
            dataContents += "solar_noon" + ";";
            dataContents += "day_length" + ";";
            dataContents += "civil_twilight_begin" + ";";
            dataContents += "civil_twilight_end" + ";";
            dataContents += "nautical_twilight_begin" + ";";
            dataContents += "nautical_twilight_end" + ";";
            dataContents += "astronomical_twilight_begin" + ";";
            dataContents += "astronomical_twilight_end";
            dataContents += "\n";
        }

        private void WriteData(SunDataSettings loggerSettings)
        {
            CultureInfo cultureDK = CultureInfo.GetCultureInfo("da-DK");
            List<SunData> theData = loggerSettings.theSunData;
            for (int i = 0; i < theData.Count; i++)
            {
                dataContents += theData[i].theDay + ";";
                dataContents += theData[i].sunrise.ToString("T",cultureDK) + ";";
                dataContents += theData[i].sunset.ToString("T",cultureDK) + ";";
                dataContents += theData[i].solar_noon.ToString("T",cultureDK) + ";";
                dataContents += theData[i].day_length.ToString() + ";";
                dataContents += theData[i].civil_twilight_begin.ToString("T",cultureDK) + ";";
                dataContents += theData[i].civil_twilight_end.ToString("T",cultureDK) + ";";
                dataContents += theData[i].nautical_twilight_begin.ToString("T",cultureDK) + ";";
                dataContents += theData[i].nautical_twilight_end.ToString("T",cultureDK) + ";";
                dataContents += theData[i].astronomical_twilight_begin.ToString("T",cultureDK) + ";";
                dataContents += theData[i].astronomical_twilight_end.ToString("T",cultureDK) + ";";
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

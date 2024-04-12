
using System.Globalization;
using System.Linq;
using System.Runtime;
using System.Windows.Forms;

namespace SunData
{
    enum ProcessState { ready, processing, finished, failed };

    public partial class Form1 : Form
    {
        private const string AnalemmaDataTarget = @"D:\Data\Sundata\AnalemmaData.csv";
        private const string SunDataTarget = @"D:\Data\Sundata\SunData.csv";

        private const string CustomFormat = "yyyy-MM-dd";

        private int SettingsIndex = 0;
        private AnalemmaSettings a_Settings = new(AnalemmaDataTarget, CustomFormat);
        private AnalemmaSettings d_Settings = new(SunDataTarget, CustomFormat);
        private AnalemmaSettings theSettings = new();

        private ProcessState _processState;

        private string LatitudeFormat;
        private string LongitudeFormat;

        private bool FromLatitude;
        private bool FromLongitude;

        private bool DirectoryExists;

        private CultureInfo cultureUK;
        private NumberFormatInfo numberUK;

        /*********************************************************************
        * Form1 Ctor
        * */

        public Form1()
        {
            InitializeComponent();
            _processState = ProcessState.ready;

            LatitudeFormat = "{0,9:+00.0000;-00.0000;00.0}";
            LongitudeFormat = "{0,10:+000.0000;-000.0000;000.0}";

            cultureUK = new CultureInfo("en-UK");
            numberUK = cultureUK.NumberFormat;

            // Settings for Analemma Data
            a_Settings.DaysBetweenLog = 28;

            // Settings for Day Data
            d_Settings.DaysBetweenLog = 1;

            dateTimePickerStart.CustomFormat = "yyyy-MM-dd";
            dateTimePickerEnd.CustomFormat = "yyyy-MM-dd";
            dateTimePickerStart.Value = Util.wholeDay(DateTime.Now.ToUniversalTime());
            dateTimePickerEnd.Value = dateTimePickerStart.Value + TimeSpan.FromDays(365);

            textBoxLatitude.Text = string.Format(numberUK, LatitudeFormat, a_Settings.Latitude);
            textBoxLongitude.Text = string.Format(numberUK, LongitudeFormat, a_Settings.Longitude);

            dateTimePickerLogTime.Value = new DateTime(1900, 1, 1, a_Settings.LogHourPart, a_Settings.LogMinutePart, 0);

            textBoxFilename_A.Text = AnalemmaDataTarget;
            textBoxFilename_D.Text = SunDataTarget;

            SetControlValues();

            Info.SetLabel(labelProcessing);

            timerLongitude.Interval = 10000;

            SetInfoText();
        }

        /*********************************************************************
         * Common controls for all tabs
         * */
        private void textBoxLatitude_TextChanged(object sender, EventArgs e)
        {
            bool FormatOk = false;
            bool DataFromGoogle = false;
            double testLatitude = double.NaN;
            double testLongitude = double.NaN;

            timerLatitude.Stop();

            if (FromLongitude)
            {
                FromLongitude = false;
                return;
            }
            try
            {
                bool test = textBoxLatitude.Text.Contains(',');
                if (test)
                {
                    string[] ss = textBoxLatitude.Text.Split(',');
                    if (ss.Length == 2) // Might there be a string like "57.01380172922418, 9.97732743975114" from Google Maps?
                    {
                        testLatitude = double.Parse(ss[0], numberUK);
                        testLongitude = double.Parse(ss[1], numberUK);
                        FormatOk = true;
                        DataFromGoogle = true;
                    }
                    else // else, probably comma rather than point, which will not trigger the exception
                    {
                        FormatOk = false;
                    }
                }
                else
                {
                    testLatitude = double.Parse(textBoxLatitude.Text, numberUK);
                    FormatOk = true;
                }
                //
            }
            catch (FormatException ex)
            {
                textBoxLatitude.ForeColor = Color.Red;
            }

            if (FormatOk)
            {
                a_Settings.Latitude = testLatitude;
                if (!testLongitude.Equals(double.NaN))
                    a_Settings.Longitude = testLongitude;

                textBoxLatitude.ForeColor = Color.Black;
            }
            else
            {
                textBoxLatitude.ForeColor = Color.Red;
            }

            if (DataFromGoogle)
            {
                FromLatitude = true;
                textBoxLatitude.Text = string.Format(numberUK, LatitudeFormat, a_Settings.Latitude);
                textBoxLongitude.Text = string.Format(numberUK, LongitudeFormat, a_Settings.Longitude);
            }
            else
                timerLatitude.Start();

            CalcLogTime();
        }
        private void timerLatitude_Tick(object sender, EventArgs e)
        {
            textBoxLatitude.Text = string.Format(numberUK, LatitudeFormat, a_Settings.Latitude);
            textBoxLongitude.Text = string.Format(numberUK, LongitudeFormat, a_Settings.Longitude);
            timerLatitude.Stop();
        }
        private void textBoxLongitude_TextChanged(object sender, EventArgs e)
        {
            bool FormatOk = false;
            bool DataFromGoogle = false;
            double testLatitude = double.NaN;
            double testLongitude = double.NaN;

            timerLongitude.Stop();

            if (FromLatitude)
            {
                FromLatitude = false;
                return;
            }
            try
            {
                bool test = textBoxLongitude.Text.Contains(',');
                if (test)
                {
                    string[] ss = textBoxLongitude.Text.Split(',');
                    if (ss.Length == 2) // Might there be a string like "57.01380172922418, 9.97732743975114" from Google Maps?
                    {
                        testLatitude = double.Parse(ss[0], numberUK);
                        testLongitude = double.Parse(ss[1], numberUK);
                        FormatOk = true;
                        DataFromGoogle = true;
                    }
                    else // else, probably comma rather than point, which will not trigger the exception
                    {
                        FormatOk = false;
                    }
                }
                else
                {
                    testLongitude = double.Parse(textBoxLongitude.Text, numberUK);
                    FormatOk = true;
                }
                //
            }
            catch (FormatException ex)
            {
                textBoxLongitude.ForeColor = Color.Red;
            }

            if (FormatOk)
            {
                a_Settings.Longitude = testLongitude;
                if (!testLatitude.Equals(double.NaN))
                    a_Settings.Latitude = testLatitude;

                textBoxLongitude.ForeColor = Color.Black;
            }
            else
            {
                textBoxLongitude.ForeColor = Color.Red;
            }

            if (DataFromGoogle)
            {
                FromLongitude = true;
                textBoxLongitude.Text = string.Format(numberUK, LongitudeFormat, a_Settings.Longitude);
                textBoxLatitude.Text = string.Format(numberUK, LatitudeFormat, a_Settings.Latitude);
            }
            else
                timerLongitude.Start();

            CalcLogTime();
        }
        private void timerLongitude_Tick(object sender, EventArgs e)
        {
            textBoxLongitude.Text = string.Format(numberUK, LongitudeFormat, a_Settings.Longitude);
            textBoxLatitude.Text = string.Format(numberUK, LatitudeFormat, a_Settings.Latitude);
            timerLongitude.Stop();
        }
        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            ResetProcessingState();
            DateTime _wholeDay = Util.wholeDay(dateTimePickerStart.Value);
            theSettings.StartDate = _wholeDay;
            theSettings.theStartDay = theSettings.StartDate.ToString(CustomFormat);
            if (dateTimePickerStart.Value > dateTimePickerEnd.Value)
            {
                dateTimePickerEnd.Value = theSettings.EndDate = theSettings.StartDate;
                theSettings.theEndDay = theSettings.EndDate.ToString(CustomFormat);
            }

            //UpdateDates();
            SetInfoText();
        }
        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            ResetProcessingState();
            DateTime _wholeDay = Util.wholeDay(dateTimePickerEnd.Value);
            theSettings.EndDate = _wholeDay;
            theSettings.theEndDay = theSettings.EndDate.ToString(CustomFormat);
            if (dateTimePickerStart.Value > dateTimePickerEnd.Value)
            {
                dateTimePickerStart.Value = theSettings.StartDate = theSettings.EndDate;
                theSettings.theStartDay = theSettings.StartDate.ToString(CustomFormat);
            }
            //UpdateDates();

            SetInfoText();
        }
        private void numericUpDownDaysBetween_ValueChanged(object sender, EventArgs e)
        {
            theSettings.DaysBetweenLog = (int)numericUpDownDaysBetween.Value;

            SetInfoText();
        }
        private void numericUpDownDaysBetween_KeyUp(object sender, KeyEventArgs e)
        {
            theSettings.DaysBetweenLog = (int)numericUpDownDaysBetween.Value;

            SetInfoText();
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetProcessingState();
            SetControlValues();
        }

        /*********************************************************************
         * Tab Page 1: Analemma controls
         * */

        private void buttonBrowse_A_Click(object sender, EventArgs e)
        {
            ResetProcessingState();

            saveFileDialog1.InitialDirectory = Path.GetDirectoryName(textBoxFilename_A.Text);
            saveFileDialog1.FileName = Path.GetFileName(textBoxFilename_A.Text);
            //saveFileDialog1.FileName = "SunDataTarget.csv";
            saveFileDialog1.ShowDialog();
            string result = saveFileDialog1.FileName;
            textBoxFilename_A.Text = Path.GetFullPath(result);

            SetInfoText();
        }
        private void textBoxFilename_A_TextChanged(object sender, EventArgs e)
        {
            ResetProcessingState();
            buttonSave_A.Enabled = false;
            if (!a_Settings.DataFolder.Equals(""))
            {
                a_Settings.DataFolder = Path.GetDirectoryName(textBoxFilename_A.Text);
                a_Settings.DataFileName = Path.GetFileName(textBoxFilename_A.Text);
                DirectoryInfo theRootDir = new DirectoryInfo(a_Settings.DataFolder);
                DirectoryExists = theRootDir.Exists;
                buttonSave_A.Enabled = DirectoryExists;
            }
            SetInfoText();

        }
        private async void buttonSave_A_Click(object sender, EventArgs e)
        {
            _processState = ProcessState.processing;
            SetInfoText();

            AnalemmaLogger analemmaLogger = new AnalemmaLogger();
            try
            {
                await analemmaLogger.LogAnalemmaData(a_Settings);
                _processState = ProcessState.finished;
            }
            catch (System.IO.IOException)
            {
                _processState = ProcessState.failed;
            }

            SetInfoText();
            ResetProcessingState();
        }
        private void dateTimePickerLogTime_ValueChanged(object sender, EventArgs e)
        {
            a_Settings.LogHourPart = dateTimePickerLogTime.Value.Hour;
            a_Settings.LogMinutePart = dateTimePickerLogTime.Value.Minute;
        }
        private void checkBoxAlign_CheckedChanged(object sender, EventArgs e)
        {
            a_Settings.AlignToLongitude = checkBoxAlign.Checked;
            CalcLogTime();
        }

        /*********************************************************************
         * Tab Page 2: Day Data controls
         * */
        private void buttonBrowse_D_Click(object sender, EventArgs e)
        {
            ResetProcessingState();

            saveFileDialog1.InitialDirectory = Path.GetDirectoryName(textBoxFilename_D.Text);
            saveFileDialog1.FileName = Path.GetFileName(textBoxFilename_D.Text);
            //saveFileDialog1.FileName = "SunDataTarget.csv";
            saveFileDialog1.ShowDialog();
            string result = saveFileDialog1.FileName;
            textBoxFilename_D.Text = Path.GetFullPath(result);

            SetInfoText();
        }
        private void textBoxFilename_D_TextChanged(object sender, EventArgs e)
        {
            ResetProcessingState();
            buttonSave_D.Enabled = false;
            if (!d_Settings.DataFolder.Equals(""))
            {
                d_Settings.DataFolder = Path.GetDirectoryName(textBoxFilename_D.Text);
                d_Settings.DataFileName = Path.GetFileName(textBoxFilename_D.Text);
                DirectoryInfo theRootDir = new DirectoryInfo(d_Settings.DataFolder);
                DirectoryExists = theRootDir.Exists;
                buttonSave_D.Enabled = DirectoryExists;
            }
            SetInfoText();

        }
        private async void buttonSave_D_Click(object sender, EventArgs e)
        {
            _processState = ProcessState.processing;
            SetInfoText();
            buttonSave_D.Enabled = false;

            labelProgress1.Visible = true;
            Util.InitProgressBar(1, progressBarSunData);
            Refresh();
            SunDataLogger sundataLogger = new SunDataLogger();
            await sundataLogger.LogSunData(d_Settings);
            //Thread.Sleep(5000);
            Util.InitProgressBar(1, progressBarSunData, false);
            labelProgress1.Visible = false;

            _processState = ProcessState.finished;
            buttonSave_D.Enabled = true;
            SetInfoText();
        }

        /*********************************************************************
         * Common helper methods
         * */
        private void SetInfoText()
        {
            string infoText;

            if (_processState == ProcessState.ready)
            {
                infoText = "Date interval: ";

                if (theSettings.StartDate <= theSettings.EndDate)
                {
                    infoText += FormatDays();
                }
                else
                {
                    infoText += "Invalid";
                }

                infoText += "\n";

                if (DirectoryExists)
                {
                    infoText += "Folder exists! Ready to process...";
                }
                else
                {
                    infoText += "Folder does not exist!";
                }

            }
            else if (_processState == ProcessState.processing)
            {
                infoText = FormatDays();
                infoText += "\nProcessing... ";
            }
            else if (_processState == ProcessState.failed)
            {
                infoText = "Processing failed! There was a problem writing the file!";
            }
            else
            {
                infoText = "Finished processing.";
            }

            Info.SetInfo(infoText);
        }
        private string FormatDays()
        {
            string result = "";

            if (theSettings.DaysBetweenLog > 0)
            {
                TimeSpan ts = theSettings.EndDate - theSettings.StartDate;
                int n = (ts.Days + 1) / theSettings.DaysBetweenLog + 1;
                string _day = (n == 1) ? " day" : " days";
                result = n.ToString() + _day + " from " + theSettings.theStartDay + " to " + theSettings.theEndDay;
            }
            return result;
        }
        private void ResetProcessingState()
        {
            if ((_processState == ProcessState.finished) || (_processState == ProcessState.failed))
            {
                _processState = ProcessState.ready;
            }
        }
        private void CalcLogTime()
        {
            if (a_Settings.AlignToLongitude)
            {
                double NoonTime = 24 * (180.0 - a_Settings.Longitude) / 360;
                a_Settings.LogHourPart = (int)NoonTime;
                a_Settings.LogMinutePart = (int)(60.0 * (NoonTime - a_Settings.LogHourPart));
                dateTimePickerLogTime.Value = new DateTime(1900, 1, 1, a_Settings.LogHourPart, a_Settings.LogMinutePart, 0);
            }
        }
        private void SetControlValues()
        {
            SettingsIndex = tabControl1.SelectedIndex;

            theSettings = (SettingsIndex == 0) ? a_Settings : d_Settings;

            UpdateDates();

        }
        private void UpdateDates()
        {
            DateTime _wholeDay = Util.wholeDay(dateTimePickerStart.Value);
            theSettings.StartDate = _wholeDay;
            theSettings.theStartDay = theSettings.StartDate.ToString(CustomFormat);
            if (theSettings.StartDate > theSettings.EndDate)
            {
                dateTimePickerEnd.Value = theSettings.EndDate = theSettings.StartDate;
                theSettings.theEndDay = theSettings.EndDate.ToString(CustomFormat);
            }

            _wholeDay = Util.wholeDay(dateTimePickerEnd.Value);
            theSettings.EndDate = _wholeDay;
            theSettings.theEndDay = theSettings.EndDate.ToString(CustomFormat);
            if (theSettings.StartDate > theSettings.EndDate)
            {
                dateTimePickerStart.Value = theSettings.StartDate = theSettings.EndDate;
                theSettings.theStartDay = theSettings.StartDate.ToString(CustomFormat);
            }

            numericUpDownDaysBetween.Value = theSettings.DaysBetweenLog;
        }
    }

    static class Info
    {
        public static Label theInfoLabel = new();

        public static void SetLabel(Label source)
        {
            theInfoLabel = source;
        }
        public static void SetInfo(string info)
        {
            theInfoLabel.Text = info;
            theInfoLabel.Refresh();
        }
    }

}
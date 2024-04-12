namespace SunData
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            buttonBrowse_A = new Button();
            textBoxFilename_A = new TextBox();
            buttonSave_A = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            labelProcessing = new Label();
            dateTimePickerStart = new DateTimePicker();
            labelStartDate = new Label();
            dateTimePickerEnd = new DateTimePicker();
            labelEndDate = new Label();
            groupBox1 = new GroupBox();
            label1 = new Label();
            numericUpDownDaysBetween = new NumericUpDown();
            dateTimePickerLogTime = new DateTimePicker();
            label2 = new Label();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            progressBarSunData = new ProgressBar();
            saveFileDialog1 = new SaveFileDialog();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            checkBoxAlign = new CheckBox();
            tabPage2 = new TabPage();
            groupBox4 = new GroupBox();
            labelProgress1 = new Label();
            textBoxFilename_D = new TextBox();
            buttonBrowse_D = new Button();
            buttonSave_D = new Button();
            tabPage3 = new TabPage();
            textBox1 = new TextBox();
            groupBox5 = new GroupBox();
            label5 = new Label();
            textBoxLongitude = new TextBox();
            textBoxLatitude = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            timerLongitude = new System.Windows.Forms.Timer(components);
            timerLatitude = new System.Windows.Forms.Timer(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDaysBetween).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // buttonBrowse_A
            // 
            buttonBrowse_A.Location = new Point(7, 20);
            buttonBrowse_A.Name = "buttonBrowse_A";
            buttonBrowse_A.Size = new Size(71, 23);
            buttonBrowse_A.TabIndex = 7;
            buttonBrowse_A.Text = "Browse...";
            buttonBrowse_A.TextAlign = ContentAlignment.MiddleLeft;
            buttonBrowse_A.UseVisualStyleBackColor = true;
            buttonBrowse_A.Click += buttonBrowse_A_Click;
            // 
            // textBoxFilename_A
            // 
            textBoxFilename_A.BorderStyle = BorderStyle.FixedSingle;
            textBoxFilename_A.Location = new Point(84, 20);
            textBoxFilename_A.Name = "textBoxFilename_A";
            textBoxFilename_A.Size = new Size(403, 23);
            textBoxFilename_A.TabIndex = 8;
            textBoxFilename_A.Text = "D:\\Data\\Sundata\\AnalemmaDataTarget.csv";
            textBoxFilename_A.TextChanged += textBoxFilename_A_TextChanged;
            // 
            // buttonSave_A
            // 
            buttonSave_A.Location = new Point(6, 50);
            buttonSave_A.Name = "buttonSave_A";
            buttonSave_A.Size = new Size(138, 31);
            buttonSave_A.TabIndex = 9;
            buttonSave_A.Text = "Save Analemma Data!";
            buttonSave_A.TextAlign = ContentAlignment.MiddleLeft;
            buttonSave_A.UseVisualStyleBackColor = true;
            buttonSave_A.Click += buttonSave_A_Click;
            // 
            // labelProcessing
            // 
            labelProcessing.FlatStyle = FlatStyle.Flat;
            labelProcessing.Location = new Point(15, 17);
            labelProcessing.Name = "labelProcessing";
            labelProcessing.Size = new Size(481, 47);
            labelProcessing.TabIndex = 13;
            labelProcessing.Text = "Status";
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.CalendarMonthBackground = Color.Silver;
            dateTimePickerStart.CustomFormat = "yyyy-MM-dd";
            dateTimePickerStart.Format = DateTimePickerFormat.Custom;
            dateTimePickerStart.Location = new Point(13, 41);
            dateTimePickerStart.MaxDate = new DateTime(2050, 12, 31, 0, 0, 0, 0);
            dateTimePickerStart.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(100, 23);
            dateTimePickerStart.TabIndex = 3;
            dateTimePickerStart.ValueChanged += dateTimePickerStart_ValueChanged;
            // 
            // labelStartDate
            // 
            labelStartDate.AutoSize = true;
            labelStartDate.Location = new Point(13, 21);
            labelStartDate.Name = "labelStartDate";
            labelStartDate.Size = new Size(61, 15);
            labelStartDate.TabIndex = 6;
            labelStartDate.Text = "Start Date:";
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.CustomFormat = "yyyy.MM.dd";
            dateTimePickerEnd.Format = DateTimePickerFormat.Custom;
            dateTimePickerEnd.Location = new Point(135, 41);
            dateTimePickerEnd.MaxDate = new DateTime(2050, 12, 31, 0, 0, 0, 0);
            dateTimePickerEnd.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(100, 23);
            dateTimePickerEnd.TabIndex = 4;
            dateTimePickerEnd.ValueChanged += dateTimePickerEnd_ValueChanged;
            // 
            // labelEndDate
            // 
            labelEndDate.AutoSize = true;
            labelEndDate.Location = new Point(135, 21);
            labelEndDate.Name = "labelEndDate";
            labelEndDate.Size = new Size(57, 15);
            labelEndDate.TabIndex = 8;
            labelEndDate.Text = "End Date:";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.GhostWhite;
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(numericUpDownDaysBetween);
            groupBox1.Controls.Add(labelEndDate);
            groupBox1.Controls.Add(dateTimePickerEnd);
            groupBox1.Controls.Add(labelStartDate);
            groupBox1.Controls.Add(dateTimePickerStart);
            groupBox1.FlatStyle = FlatStyle.Popup;
            groupBox1.Location = new Point(17, 79);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(509, 74);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Select date interval";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(267, 21);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 10;
            label1.Text = "Days between log:";
            // 
            // numericUpDownDaysBetween
            // 
            numericUpDownDaysBetween.Location = new Point(267, 41);
            numericUpDownDaysBetween.Maximum = new decimal(new int[] { 28, 0, 0, 0 });
            numericUpDownDaysBetween.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownDaysBetween.Name = "numericUpDownDaysBetween";
            numericUpDownDaysBetween.Size = new Size(60, 23);
            numericUpDownDaysBetween.TabIndex = 5;
            numericUpDownDaysBetween.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownDaysBetween.ValueChanged += numericUpDownDaysBetween_ValueChanged;
            numericUpDownDaysBetween.KeyUp += numericUpDownDaysBetween_KeyUp;
            // 
            // dateTimePickerLogTime
            // 
            dateTimePickerLogTime.CustomFormat = "HH:mm";
            dateTimePickerLogTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerLogTime.Location = new Point(5, 33);
            dateTimePickerLogTime.Name = "dateTimePickerLogTime";
            dateTimePickerLogTime.ShowUpDown = true;
            dateTimePickerLogTime.Size = new Size(58, 23);
            dateTimePickerLogTime.TabIndex = 6;
            dateTimePickerLogTime.Value = new DateTime(2024, 2, 10, 22, 54, 11, 0);
            dateTimePickerLogTime.ValueChanged += dateTimePickerLogTime_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 9);
            label2.Name = "label2";
            label2.Size = new Size(217, 15);
            label2.TabIndex = 11;
            label2.Text = "Select log time of the day (00:00 - 23:59)";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBoxFilename_A);
            groupBox2.Controls.Add(buttonBrowse_A);
            groupBox2.Controls.Add(buttonSave_A);
            groupBox2.Location = new Point(5, 65);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(493, 90);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Select file to save data in:";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.GhostWhite;
            groupBox3.Controls.Add(labelProcessing);
            groupBox3.Location = new Point(17, 396);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(511, 79);
            groupBox3.TabIndex = 11;
            groupBox3.TabStop = false;
            groupBox3.Text = "Status";
            // 
            // progressBarSunData
            // 
            progressBarSunData.Location = new Point(255, 62);
            progressBarSunData.Name = "progressBarSunData";
            progressBarSunData.Size = new Size(214, 31);
            progressBarSunData.Step = 1;
            progressBarSunData.TabIndex = 12;
            progressBarSunData.Visible = false;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(17, 182);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(510, 188);
            tabControl1.TabIndex = 15;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.GhostWhite;
            tabPage1.Controls.Add(checkBoxAlign);
            tabPage1.Controls.Add(dateTimePickerLogTime);
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Controls.Add(label2);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(502, 160);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Analemma";
            // 
            // checkBoxAlign
            // 
            checkBoxAlign.AutoSize = true;
            checkBoxAlign.Location = new Point(78, 36);
            checkBoxAlign.Name = "checkBoxAlign";
            checkBoxAlign.Size = new Size(232, 19);
            checkBoxAlign.TabIndex = 12;
            checkBoxAlign.Text = "Align log time to Longitude of location";
            checkBoxAlign.UseVisualStyleBackColor = true;
            checkBoxAlign.CheckedChanged += checkBoxAlign_CheckedChanged;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.GhostWhite;
            tabPage2.Controls.Add(groupBox4);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(502, 160);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Day Data";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(labelProgress1);
            groupBox4.Controls.Add(progressBarSunData);
            groupBox4.Controls.Add(textBoxFilename_D);
            groupBox4.Controls.Add(buttonBrowse_D);
            groupBox4.Controls.Add(buttonSave_D);
            groupBox4.Location = new Point(8, 7);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(491, 104);
            groupBox4.TabIndex = 11;
            groupBox4.TabStop = false;
            groupBox4.Text = "Select file to save data in:";
            // 
            // labelProgress1
            // 
            labelProgress1.AutoSize = true;
            labelProgress1.Location = new Point(185, 70);
            labelProgress1.Name = "labelProgress1";
            labelProgress1.Size = new Size(55, 15);
            labelProgress1.TabIndex = 13;
            labelProgress1.Text = "Progress:";
            labelProgress1.Visible = false;
            // 
            // textBoxFilename_D
            // 
            textBoxFilename_D.BorderStyle = BorderStyle.FixedSingle;
            textBoxFilename_D.Location = new Point(84, 26);
            textBoxFilename_D.Name = "textBoxFilename_D";
            textBoxFilename_D.Size = new Size(404, 23);
            textBoxFilename_D.TabIndex = 11;
            textBoxFilename_D.TextChanged += textBoxFilename_D_TextChanged;
            // 
            // buttonBrowse_D
            // 
            buttonBrowse_D.Location = new Point(7, 21);
            buttonBrowse_D.Name = "buttonBrowse_D";
            buttonBrowse_D.Size = new Size(71, 31);
            buttonBrowse_D.TabIndex = 10;
            buttonBrowse_D.Text = "Browse...";
            buttonBrowse_D.TextAlign = ContentAlignment.MiddleLeft;
            buttonBrowse_D.UseVisualStyleBackColor = true;
            buttonBrowse_D.Click += buttonBrowse_D_Click;
            // 
            // buttonSave_D
            // 
            buttonSave_D.Location = new Point(8, 62);
            buttonSave_D.Name = "buttonSave_D";
            buttonSave_D.Size = new Size(138, 31);
            buttonSave_D.TabIndex = 12;
            buttonSave_D.Text = "Save Day Data!";
            buttonSave_D.TextAlign = ContentAlignment.MiddleLeft;
            buttonSave_D.UseVisualStyleBackColor = true;
            buttonSave_D.Click += buttonSave_D_Click;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.LightGray;
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(502, 160);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Sun Motion";
            // 
            // textBox1
            // 
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.BackColor = Color.GhostWhite;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Enabled = false;
            textBox1.Location = new Point(8, 8);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(529, 153);
            textBox1.TabIndex = 16;
            // 
            // groupBox5
            // 
            groupBox5.BackColor = Color.GhostWhite;
            groupBox5.Controls.Add(label5);
            groupBox5.Controls.Add(textBoxLongitude);
            groupBox5.Controls.Add(textBoxLatitude);
            groupBox5.Controls.Add(label4);
            groupBox5.Location = new Point(17, 18);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(511, 53);
            groupBox5.TabIndex = 17;
            groupBox5.TabStop = false;
            groupBox5.Text = "Select your location:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(252, 23);
            label5.Name = "label5";
            label5.Size = new Size(148, 15);
            label5.TabIndex = 13;
            label5.Text = "Longitude [-180,0 ; +180.0]";
            // 
            // textBoxLongitude
            // 
            textBoxLongitude.BorderStyle = BorderStyle.FixedSingle;
            textBoxLongitude.Font = new Font("Consolas", 10F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxLongitude.Location = new Point(406, 18);
            textBoxLongitude.Name = "textBoxLongitude";
            textBoxLongitude.Size = new Size(90, 23);
            textBoxLongitude.TabIndex = 1;
            textBoxLongitude.TextChanged += textBoxLongitude_TextChanged;
            // 
            // textBoxLatitude
            // 
            textBoxLatitude.BorderStyle = BorderStyle.FixedSingle;
            textBoxLatitude.Font = new Font("Consolas", 10F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxLatitude.Location = new Point(143, 18);
            textBoxLatitude.Name = "textBoxLatitude";
            textBoxLatitude.Size = new Size(90, 23);
            textBoxLatitude.TabIndex = 2;
            textBoxLatitude.TextChanged += textBoxLatitude_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 23);
            label4.Name = "label4";
            label4.Size = new Size(125, 15);
            label4.TabIndex = 12;
            label4.Text = "Latitude [-90,0 ; +90.0]";
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.GhostWhite;
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Enabled = false;
            textBox4.Location = new Point(8, 169);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(529, 209);
            textBox4.TabIndex = 18;
            // 
            // textBox5
            // 
            textBox5.BackColor = Color.GhostWhite;
            textBox5.BorderStyle = BorderStyle.FixedSingle;
            textBox5.Enabled = false;
            textBox5.Location = new Point(8, 386);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(529, 97);
            textBox5.TabIndex = 19;
            // 
            // timerLongitude
            // 
            timerLongitude.Interval = 10000;
            timerLongitude.Tick += timerLongitude_Tick;
            // 
            // timerLatitude
            // 
            timerLatitude.Interval = 10000;
            timerLatitude.Tick += timerLatitude_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(545, 491);
            Controls.Add(groupBox5);
            Controls.Add(groupBox1);
            Controls.Add(textBox1);
            Controls.Add(groupBox3);
            Controls.Add(tabControl1);
            Controls.Add(textBox4);
            Controls.Add(textBox5);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Form1";
            Text = "SunDataTarget";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDaysBetween).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonBrowse_A;
        private TextBox textBoxFilename_A;
        private Button buttonSave_A;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label labelProcessing;
        private DateTimePicker dateTimePickerStart;
        private Label labelStartDate;
        private DateTimePicker dateTimePickerEnd;
        private Label labelEndDate;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label1;
        private NumericUpDown numericUpDownDaysBetween;
        private NumericUpDown numericUpDownMinute;
        private Label label2;
        private SaveFileDialog saveFileDialog1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private GroupBox groupBox4;
        private TextBox textBoxFilename_D;
        private Button buttonBrowse_D;
        private Button buttonSave_D;
        private DateTimePicker dateTimePickerLogTime;
        private TextBox textBox1;
        private GroupBox groupBox5;
        private TextBox textBoxLatitude;
        private Label label4;
        private TextBox textBoxLongitude;
        private Label label5;
        private TextBox textBox4;
        private TextBox textBox5;
        private CheckBox checkBoxAlign;
        private System.Windows.Forms.Timer timerLongitude;
        private System.Windows.Forms.Timer timerLatitude;
        private ProgressBar progressBarSunData;
        private Label labelProgress1;
    }
}
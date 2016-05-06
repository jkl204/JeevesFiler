namespace JeevesFiler
{
    partial class JeevesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.browseFolder = new System.Windows.Forms.Button();
            this.pathLabel = new System.Windows.Forms.Label();
            this.UnsortedBox = new System.Windows.Forms.ListBox();
            this.commitSort = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.PrefixTextB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CoreTextB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuffixTextB = new System.Windows.Forms.TextBox();
            this.PrefixCounterChk = new System.Windows.Forms.CheckBox();
            this.SuffixCounterChk = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LexFilterSelectStartTextB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.LexFilterSelectEndTextB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.LexFilterExcludeStartTextB = new System.Windows.Forms.TextBox();
            this.LexFilterExcludeEndTextB = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PrefixDateCmbo = new System.Windows.Forms.ComboBox();
            this.SuffixDateCmbo = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuffixDateChk = new System.Windows.Forms.CheckBox();
            this.PrefixDateChk = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.SuffixDigitTextB = new System.Windows.Forms.TextBox();
            this.PrefixDigitTextB = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.IgnorePrefixTextB = new System.Windows.Forms.TextBox();
            this.IgnorePrefixChk = new System.Windows.Forms.CheckBox();
            this.sortByGroupBox = new System.Windows.Forms.GroupBox();
            this.SizeRadio = new System.Windows.Forms.RadioButton();
            this.TimeRadio = new System.Windows.Forms.RadioButton();
            this.LexRadio = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DscOrderRadio = new System.Windows.Forms.RadioButton();
            this.AscOrderRadio = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.browseFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.GroupByYrRadio = new System.Windows.Forms.RadioButton();
            this.GroupByExtRadio = new System.Windows.Forms.RadioButton();
            this.GroupByNoneRadio = new System.Windows.Forms.RadioButton();
            this.previewFilters = new System.Windows.Forms.Button();
            this.SortedBox = new System.Windows.Forms.CheckedListBox();
            this.ExitOut = new System.Windows.Forms.Button();
            this.RenameProgress = new System.Windows.Forms.ProgressBar();
            this.label16 = new System.Windows.Forms.Label();
            this.CurrentCoreChk = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.sortByGroupBox.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // browseFolder
            // 
            this.browseFolder.Location = new System.Drawing.Point(21, 19);
            this.browseFolder.Name = "browseFolder";
            this.browseFolder.Size = new System.Drawing.Size(75, 23);
            this.browseFolder.TabIndex = 0;
            this.browseFolder.Text = "folder";
            this.browseFolder.UseVisualStyleBackColor = true;
            this.browseFolder.Click += new System.EventHandler(this.browseFolder_Click);
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.pathLabel.Location = new System.Drawing.Point(102, 22);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(126, 16);
            this.pathLabel.TabIndex = 1;
            this.pathLabel.Text = "selected folder path";
            // 
            // UnsortedBox
            // 
            this.UnsortedBox.FormattingEnabled = true;
            this.UnsortedBox.HorizontalScrollbar = true;
            this.UnsortedBox.Location = new System.Drawing.Point(21, 98);
            this.UnsortedBox.Name = "UnsortedBox";
            this.UnsortedBox.Size = new System.Drawing.Size(180, 407);
            this.UnsortedBox.TabIndex = 2;
            // 
            // commitSort
            // 
            this.commitSort.Location = new System.Drawing.Point(433, 215);
            this.commitSort.Name = "commitSort";
            this.commitSort.Size = new System.Drawing.Size(75, 23);
            this.commitSort.TabIndex = 4;
            this.commitSort.Text = "rename";
            this.commitSort.UseVisualStyleBackColor = true;
            this.commitSort.Click += new System.EventHandler(this.commitSort_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Prefix";
            // 
            // PrefixTextB
            // 
            this.PrefixTextB.Location = new System.Drawing.Point(66, 35);
            this.PrefixTextB.Name = "PrefixTextB";
            this.PrefixTextB.Size = new System.Drawing.Size(111, 20);
            this.PrefixTextB.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Core";
            // 
            // CoreTextB
            // 
            this.CoreTextB.Location = new System.Drawing.Point(66, 71);
            this.CoreTextB.Name = "CoreTextB";
            this.CoreTextB.Size = new System.Drawing.Size(111, 20);
            this.CoreTextB.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Suffix";
            // 
            // SuffixTextB
            // 
            this.SuffixTextB.Location = new System.Drawing.Point(66, 106);
            this.SuffixTextB.Name = "SuffixTextB";
            this.SuffixTextB.Size = new System.Drawing.Size(111, 20);
            this.SuffixTextB.TabIndex = 10;
            // 
            // PrefixCounterChk
            // 
            this.PrefixCounterChk.AutoSize = true;
            this.PrefixCounterChk.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.PrefixCounterChk.Location = new System.Drawing.Point(200, 47);
            this.PrefixCounterChk.Name = "PrefixCounterChk";
            this.PrefixCounterChk.Size = new System.Drawing.Size(88, 17);
            this.PrefixCounterChk.TabIndex = 11;
            this.PrefixCounterChk.Text = "use counter -";
            this.PrefixCounterChk.UseVisualStyleBackColor = true;
            this.PrefixCounterChk.CheckedChanged += new System.EventHandler(this.PrefixCounterChk_CheckedChanged);
            // 
            // SuffixCounterChk
            // 
            this.SuffixCounterChk.AutoSize = true;
            this.SuffixCounterChk.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.SuffixCounterChk.Location = new System.Drawing.Point(199, 120);
            this.SuffixCounterChk.Name = "SuffixCounterChk";
            this.SuffixCounterChk.Size = new System.Drawing.Size(88, 17);
            this.SuffixCounterChk.TabIndex = 12;
            this.SuffixCounterChk.Text = "use counter -";
            this.SuffixCounterChk.UseVisualStyleBackColor = true;
            this.SuffixCounterChk.CheckedChanged += new System.EventHandler(this.SuffixCounterChk_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(348, 278);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Filter / Resort Selection";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "only rename";
            // 
            // LexFilterSelectStartTextB
            // 
            this.LexFilterSelectStartTextB.Location = new System.Drawing.Point(87, 20);
            this.LexFilterSelectStartTextB.Name = "LexFilterSelectStartTextB";
            this.LexFilterSelectStartTextB.Size = new System.Drawing.Size(100, 20);
            this.LexFilterSelectStartTextB.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(193, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "to";
            // 
            // LexFilterSelectEndTextB
            // 
            this.LexFilterSelectEndTextB.Location = new System.Drawing.Point(215, 20);
            this.LexFilterSelectEndTextB.Name = "LexFilterSelectEndTextB";
            this.LexFilterSelectEndTextB.Size = new System.Drawing.Size(100, 20);
            this.LexFilterSelectEndTextB.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "exclude";
            // 
            // LexFilterExcludeStartTextB
            // 
            this.LexFilterExcludeStartTextB.Location = new System.Drawing.Point(87, 55);
            this.LexFilterExcludeStartTextB.Name = "LexFilterExcludeStartTextB";
            this.LexFilterExcludeStartTextB.Size = new System.Drawing.Size(100, 20);
            this.LexFilterExcludeStartTextB.TabIndex = 20;
            // 
            // LexFilterExcludeEndTextB
            // 
            this.LexFilterExcludeEndTextB.Location = new System.Drawing.Point(215, 55);
            this.LexFilterExcludeEndTextB.Name = "LexFilterExcludeEndTextB";
            this.LexFilterExcludeEndTextB.Size = new System.Drawing.Size(100, 20);
            this.LexFilterExcludeEndTextB.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(193, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "to";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CurrentCoreChk);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.PrefixDateCmbo);
            this.groupBox1.Controls.Add(this.SuffixDateCmbo);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.SuffixDateChk);
            this.groupBox1.Controls.Add(this.PrefixDateChk);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.SuffixDigitTextB);
            this.groupBox1.Controls.Add(this.PrefixDigitTextB);
            this.groupBox1.Controls.Add(this.CoreTextB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.PrefixTextB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.SuffixTextB);
            this.groupBox1.Controls.Add(this.PrefixCounterChk);
            this.groupBox1.Controls.Add(this.SuffixCounterChk);
            this.groupBox1.Location = new System.Drawing.Point(233, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 153);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Renaming Convo";
            // 
            // PrefixDateCmbo
            // 
            this.PrefixDateCmbo.BackColor = System.Drawing.SystemColors.Window;
            this.PrefixDateCmbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PrefixDateCmbo.Enabled = false;
            this.PrefixDateCmbo.FormattingEnabled = true;
            this.PrefixDateCmbo.Items.AddRange(new object[] {
            "MMddyyyy",
            "ddMMyyyy",
            "yyyyMMdd",
            "MM.dd.yyyy",
            "dd.MM.yyyy",
            "yyyy.MM.dd",
            "MM_dd_yyyy",
            "dd_MM_yyyy",
            "yyyy_MM_dd"});
            this.PrefixDateCmbo.Location = new System.Drawing.Point(66, 35);
            this.PrefixDateCmbo.Name = "PrefixDateCmbo";
            this.PrefixDateCmbo.Size = new System.Drawing.Size(111, 21);
            this.PrefixDateCmbo.TabIndex = 32;
            this.PrefixDateCmbo.Visible = false;
            this.PrefixDateCmbo.SelectedIndexChanged += new System.EventHandler(this.PrefixDateCmbo_SelectedIndexChanged);
            // 
            // SuffixDateCmbo
            // 
            this.SuffixDateCmbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SuffixDateCmbo.Enabled = false;
            this.SuffixDateCmbo.FormattingEnabled = true;
            this.SuffixDateCmbo.Items.AddRange(new object[] {
            "MMddyyyy",
            "ddMMyyyy",
            "yyyyMMdd",
            "MM.dd.yyyy",
            "dd.MM.yyyy",
            "yyyy.MM.dd",
            "MM_dd_yyyy",
            "dd_MM_yyyy",
            "yyyy_MM_dd"});
            this.SuffixDateCmbo.Location = new System.Drawing.Point(66, 105);
            this.SuffixDateCmbo.Name = "SuffixDateCmbo";
            this.SuffixDateCmbo.Size = new System.Drawing.Size(111, 21);
            this.SuffixDateCmbo.TabIndex = 33;
            this.SuffixDateCmbo.Visible = false;
            this.SuffixDateCmbo.SelectedIndexChanged += new System.EventHandler(this.SuffixDateCmbo_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(230, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "OPTIONS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(181, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "********************************";
            // 
            // SuffixDateChk
            // 
            this.SuffixDateChk.AutoSize = true;
            this.SuffixDateChk.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.SuffixDateChk.Location = new System.Drawing.Point(187, 103);
            this.SuffixDateChk.Name = "SuffixDateChk";
            this.SuffixDateChk.Size = new System.Drawing.Size(63, 17);
            this.SuffixDateChk.TabIndex = 18;
            this.SuffixDateChk.Text = "file date";
            this.SuffixDateChk.UseVisualStyleBackColor = true;
            this.SuffixDateChk.CheckedChanged += new System.EventHandler(this.SuffixDateChk_CheckedChanged);
            // 
            // PrefixDateChk
            // 
            this.PrefixDateChk.AutoSize = true;
            this.PrefixDateChk.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.PrefixDateChk.Location = new System.Drawing.Point(187, 31);
            this.PrefixDateChk.Name = "PrefixDateChk";
            this.PrefixDateChk.Size = new System.Drawing.Size(63, 17);
            this.PrefixDateChk.TabIndex = 17;
            this.PrefixDateChk.Text = "file date";
            this.PrefixDateChk.UseVisualStyleBackColor = true;
            this.PrefixDateChk.CheckedChanged += new System.EventHandler(this.PrefixDateChk_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label13.Location = new System.Drawing.Point(281, 102);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "digits";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label12.Location = new System.Drawing.Point(281, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "digits";
            // 
            // SuffixDigitTextB
            // 
            this.SuffixDigitTextB.Enabled = false;
            this.SuffixDigitTextB.Location = new System.Drawing.Point(284, 117);
            this.SuffixDigitTextB.Name = "SuffixDigitTextB";
            this.SuffixDigitTextB.Size = new System.Drawing.Size(39, 20);
            this.SuffixDigitTextB.TabIndex = 14;
            // 
            // PrefixDigitTextB
            // 
            this.PrefixDigitTextB.Enabled = false;
            this.PrefixDigitTextB.Location = new System.Drawing.Point(284, 44);
            this.PrefixDigitTextB.Name = "PrefixDigitTextB";
            this.PrefixDigitTextB.Size = new System.Drawing.Size(39, 20);
            this.PrefixDigitTextB.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.IgnorePrefixTextB);
            this.groupBox2.Controls.Add(this.IgnorePrefixChk);
            this.groupBox2.Controls.Add(this.LexFilterSelectStartTextB);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.LexFilterExcludeEndTextB);
            this.groupBox2.Controls.Add(this.LexFilterSelectEndTextB);
            this.groupBox2.Controls.Add(this.LexFilterExcludeStartTextB);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(230, 297);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(337, 114);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lex Filter";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label15.Location = new System.Drawing.Point(211, 85);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(113, 13);
            this.label15.TabIndex = 25;
            this.label15.Text = "- no. of chars to ignore";
            // 
            // IgnorePrefixTextB
            // 
            this.IgnorePrefixTextB.Enabled = false;
            this.IgnorePrefixTextB.Location = new System.Drawing.Point(182, 82);
            this.IgnorePrefixTextB.Name = "IgnorePrefixTextB";
            this.IgnorePrefixTextB.Size = new System.Drawing.Size(27, 20);
            this.IgnorePrefixTextB.TabIndex = 24;
            // 
            // IgnorePrefixChk
            // 
            this.IgnorePrefixChk.AutoSize = true;
            this.IgnorePrefixChk.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.IgnorePrefixChk.Location = new System.Drawing.Point(23, 84);
            this.IgnorePrefixChk.Name = "IgnorePrefixChk";
            this.IgnorePrefixChk.Size = new System.Drawing.Size(162, 17);
            this.IgnorePrefixChk.TabIndex = 23;
            this.IgnorePrefixChk.Text = "Ignore Prefix When Filtering -";
            this.IgnorePrefixChk.UseVisualStyleBackColor = true;
            this.IgnorePrefixChk.CheckedChanged += new System.EventHandler(this.IgnorePrefixChk_CheckedChanged);
            // 
            // sortByGroupBox
            // 
            this.sortByGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.sortByGroupBox.Controls.Add(this.SizeRadio);
            this.sortByGroupBox.Controls.Add(this.TimeRadio);
            this.sortByGroupBox.Controls.Add(this.LexRadio);
            this.sortByGroupBox.Location = new System.Drawing.Point(230, 422);
            this.sortByGroupBox.Name = "sortByGroupBox";
            this.sortByGroupBox.Size = new System.Drawing.Size(101, 103);
            this.sortByGroupBox.TabIndex = 25;
            this.sortByGroupBox.TabStop = false;
            this.sortByGroupBox.Text = "Sort by";
            // 
            // SizeRadio
            // 
            this.SizeRadio.AutoSize = true;
            this.SizeRadio.Location = new System.Drawing.Point(17, 65);
            this.SizeRadio.Name = "SizeRadio";
            this.SizeRadio.Size = new System.Drawing.Size(45, 17);
            this.SizeRadio.TabIndex = 2;
            this.SizeRadio.Text = "Size";
            this.SizeRadio.UseVisualStyleBackColor = true;
            // 
            // TimeRadio
            // 
            this.TimeRadio.AutoSize = true;
            this.TimeRadio.Location = new System.Drawing.Point(17, 42);
            this.TimeRadio.Name = "TimeRadio";
            this.TimeRadio.Size = new System.Drawing.Size(76, 17);
            this.TimeRadio.TabIndex = 1;
            this.TimeRadio.Text = "Timestamp";
            this.TimeRadio.UseVisualStyleBackColor = true;
            // 
            // LexRadio
            // 
            this.LexRadio.AutoSize = true;
            this.LexRadio.Checked = true;
            this.LexRadio.Location = new System.Drawing.Point(17, 19);
            this.LexRadio.Name = "LexRadio";
            this.LexRadio.Size = new System.Drawing.Size(69, 17);
            this.LexRadio.TabIndex = 0;
            this.LexRadio.TabStop = true;
            this.LexRadio.Text = "Lex (abc)";
            this.LexRadio.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DscOrderRadio);
            this.groupBox4.Controls.Add(this.AscOrderRadio);
            this.groupBox4.Location = new System.Drawing.Point(457, 425);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(110, 100);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "In Order of";
            // 
            // DscOrderRadio
            // 
            this.DscOrderRadio.AutoSize = true;
            this.DscOrderRadio.Location = new System.Drawing.Point(16, 49);
            this.DscOrderRadio.Name = "DscOrderRadio";
            this.DscOrderRadio.Size = new System.Drawing.Size(82, 17);
            this.DscOrderRadio.TabIndex = 1;
            this.DscOrderRadio.Text = "Descending";
            this.DscOrderRadio.UseVisualStyleBackColor = true;
            // 
            // AscOrderRadio
            // 
            this.AscOrderRadio.AutoSize = true;
            this.AscOrderRadio.Checked = true;
            this.AscOrderRadio.Location = new System.Drawing.Point(16, 26);
            this.AscOrderRadio.Name = "AscOrderRadio";
            this.AscOrderRadio.Size = new System.Drawing.Size(75, 17);
            this.AscOrderRadio.TabIndex = 0;
            this.AscOrderRadio.TabStop = true;
            this.AscOrderRadio.Text = "Ascending";
            this.AscOrderRadio.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label6.Location = new System.Drawing.Point(18, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Files to Label";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label11.Location = new System.Drawing.Point(587, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(191, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Order to Relabel in  =>  New File Name";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.GroupByYrRadio);
            this.groupBox5.Controls.Add(this.GroupByExtRadio);
            this.groupBox5.Controls.Add(this.GroupByNoneRadio);
            this.groupBox5.Location = new System.Drawing.Point(352, 425);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(88, 100);
            this.groupBox5.TabIndex = 29;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Group by";
            // 
            // GroupByYrRadio
            // 
            this.GroupByYrRadio.AutoSize = true;
            this.GroupByYrRadio.Location = new System.Drawing.Point(12, 62);
            this.GroupByYrRadio.Name = "GroupByYrRadio";
            this.GroupByYrRadio.Size = new System.Drawing.Size(47, 17);
            this.GroupByYrRadio.TabIndex = 2;
            this.GroupByYrRadio.Text = "Year";
            this.GroupByYrRadio.UseVisualStyleBackColor = true;
            // 
            // GroupByExtRadio
            // 
            this.GroupByExtRadio.AutoSize = true;
            this.GroupByExtRadio.Location = new System.Drawing.Point(12, 39);
            this.GroupByExtRadio.Name = "GroupByExtRadio";
            this.GroupByExtRadio.Size = new System.Drawing.Size(68, 17);
            this.GroupByExtRadio.TabIndex = 1;
            this.GroupByExtRadio.Text = "File Type";
            this.GroupByExtRadio.UseVisualStyleBackColor = true;
            // 
            // GroupByNoneRadio
            // 
            this.GroupByNoneRadio.AutoSize = true;
            this.GroupByNoneRadio.Checked = true;
            this.GroupByNoneRadio.Location = new System.Drawing.Point(12, 16);
            this.GroupByNoneRadio.Name = "GroupByNoneRadio";
            this.GroupByNoneRadio.Size = new System.Drawing.Size(51, 17);
            this.GroupByNoneRadio.TabIndex = 0;
            this.GroupByNoneRadio.TabStop = true;
            this.GroupByNoneRadio.Text = "None";
            this.GroupByNoneRadio.UseVisualStyleBackColor = true;
            // 
            // previewFilters
            // 
            this.previewFilters.Location = new System.Drawing.Point(306, 215);
            this.previewFilters.Name = "previewFilters";
            this.previewFilters.Size = new System.Drawing.Size(75, 23);
            this.previewFilters.TabIndex = 30;
            this.previewFilters.Text = "preview";
            this.previewFilters.UseVisualStyleBackColor = true;
            this.previewFilters.Click += new System.EventHandler(this.previewFilters_Click);
            // 
            // SortedBox
            // 
            this.SortedBox.CheckOnClick = true;
            this.SortedBox.FormattingEnabled = true;
            this.SortedBox.Location = new System.Drawing.Point(590, 98);
            this.SortedBox.Name = "SortedBox";
            this.SortedBox.Size = new System.Drawing.Size(317, 409);
            this.SortedBox.TabIndex = 31;
            this.SortedBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.SortedBox_ItemCheck);
            this.SortedBox.DoubleClick += new System.EventHandler(this.SortedBox_DoubleClick);
            // 
            // ExitOut
            // 
            this.ExitOut.Location = new System.Drawing.Point(832, 19);
            this.ExitOut.Name = "ExitOut";
            this.ExitOut.Size = new System.Drawing.Size(75, 23);
            this.ExitOut.TabIndex = 32;
            this.ExitOut.Text = "Exit";
            this.ExitOut.UseVisualStyleBackColor = true;
            this.ExitOut.Click += new System.EventHandler(this.ExitOut_Click);
            // 
            // RenameProgress
            // 
            this.RenameProgress.Location = new System.Drawing.Point(233, 246);
            this.RenameProgress.Name = "RenameProgress";
            this.RenameProgress.Size = new System.Drawing.Size(337, 23);
            this.RenameProgress.TabIndex = 33;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(181, 89);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(135, 13);
            this.label16.TabIndex = 34;
            this.label16.Text = "********************************";
            // 
            // CurrentCoreChk
            // 
            this.CurrentCoreChk.AutoSize = true;
            this.CurrentCoreChk.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.CurrentCoreChk.Location = new System.Drawing.Point(187, 73);
            this.CurrentCoreChk.Name = "CurrentCoreChk";
            this.CurrentCoreChk.Size = new System.Drawing.Size(108, 17);
            this.CurrentCoreChk.TabIndex = 35;
            this.CurrentCoreChk.Text = "use current name";
            this.CurrentCoreChk.UseVisualStyleBackColor = true;
            this.CurrentCoreChk.CheckedChanged += new System.EventHandler(this.currentCoreChk_CheckedChanged);
            // 
            // JeevesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 544);
            this.Controls.Add(this.RenameProgress);
            this.Controls.Add(this.ExitOut);
            this.Controls.Add(this.SortedBox);
            this.Controls.Add(this.previewFilters);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.sortByGroupBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.commitSort);
            this.Controls.Add(this.UnsortedBox);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.browseFolder);
            this.Name = "JeevesForm";
            this.Text = "Jeeves, Rename those Files";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.sortByGroupBox.ResumeLayout(false);
            this.sortByGroupBox.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button browseFolder;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.ListBox UnsortedBox;
        private System.Windows.Forms.Button commitSort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PrefixTextB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CoreTextB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SuffixTextB;
        private System.Windows.Forms.CheckBox PrefixCounterChk;
        private System.Windows.Forms.CheckBox SuffixCounterChk;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox LexFilterSelectStartTextB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox LexFilterSelectEndTextB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox LexFilterExcludeStartTextB;
        private System.Windows.Forms.TextBox LexFilterExcludeEndTextB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox sortByGroupBox;
        private System.Windows.Forms.RadioButton SizeRadio;
        private System.Windows.Forms.RadioButton TimeRadio;
        private System.Windows.Forms.RadioButton LexRadio;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton DscOrderRadio;
        private System.Windows.Forms.RadioButton AscOrderRadio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox SuffixDigitTextB;
        private System.Windows.Forms.TextBox PrefixDigitTextB;
        private System.Windows.Forms.FolderBrowserDialog browseFolderDialog;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton GroupByYrRadio;
        private System.Windows.Forms.RadioButton GroupByExtRadio;
        private System.Windows.Forms.RadioButton GroupByNoneRadio;
        private System.Windows.Forms.Button previewFilters;
        private System.Windows.Forms.CheckBox IgnorePrefixChk;
        private System.Windows.Forms.CheckedListBox SortedBox;
        private System.Windows.Forms.CheckBox SuffixDateChk;
        private System.Windows.Forms.CheckBox PrefixDateChk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox SuffixDateCmbo;
        private System.Windows.Forms.ComboBox PrefixDateCmbo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox IgnorePrefixTextB;
        private System.Windows.Forms.Button ExitOut;
        private System.Windows.Forms.ProgressBar RenameProgress;
        private System.Windows.Forms.CheckBox CurrentCoreChk;
        private System.Windows.Forms.Label label16;
    }
}


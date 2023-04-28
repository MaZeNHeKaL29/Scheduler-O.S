namespace WindowsFormsApp1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ArrivalTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BurstTime = new System.Windows.Forms.TextBox();
            this.prioity_label = new System.Windows.Forms.Label();
            this.Priority = new System.Windows.Forms.TextBox();
            this.FCFS = new System.Windows.Forms.Button();
            this.SJFP = new System.Windows.Forms.Button();
            this.PP = new System.Windows.Forms.Button();
            this.RR = new System.Windows.Forms.Button();
            this.PNP = new System.Windows.Forms.Button();
            this.SJFNP = new System.Windows.Forms.Button();
            this.timeQuantum_label = new System.Windows.Forms.Label();
            this.TimeQuantum = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView2 = new System.Windows.Forms.ListView();
            this.listView3 = new System.Windows.Forms.ListView();
            this.AvgTurnaround = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AvgWaiting = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.liveScheduler = new System.Windows.Forms.RadioButton();
            this.runCurrentProcesses = new System.Windows.Forms.RadioButton();
            this.reset = new System.Windows.Forms.Button();
            this.maxNoOfProcesses = new System.Windows.Forms.TextBox();
            this.noProcesses_label = new System.Windows.Forms.Label();
            this.chooseScheduler = new System.Windows.Forms.ComboBox();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Location = new System.Drawing.Point(7, 630);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 55);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add Process";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.AddProcess_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 482);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Arrival Time";
            // 
            // ArrivalTime
            // 
            this.ArrivalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArrivalTime.Location = new System.Drawing.Point(10, 517);
            this.ArrivalTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ArrivalTime.Name = "ArrivalTime";
            this.ArrivalTime.Size = new System.Drawing.Size(137, 30);
            this.ArrivalTime.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 561);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Burst Time";
            // 
            // BurstTime
            // 
            this.BurstTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BurstTime.Location = new System.Drawing.Point(9, 594);
            this.BurstTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BurstTime.Name = "BurstTime";
            this.BurstTime.Size = new System.Drawing.Size(137, 30);
            this.BurstTime.TabIndex = 6;
            // 
            // prioity_label
            // 
            this.prioity_label.AutoSize = true;
            this.prioity_label.BackColor = System.Drawing.Color.Transparent;
            this.prioity_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prioity_label.Location = new System.Drawing.Point(5, 394);
            this.prioity_label.Name = "prioity_label";
            this.prioity_label.Size = new System.Drawing.Size(71, 25);
            this.prioity_label.TabIndex = 9;
            this.prioity_label.Text = "Priority";
            // 
            // Priority
            // 
            this.Priority.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Priority.Location = new System.Drawing.Point(11, 428);
            this.Priority.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Priority.Name = "Priority";
            this.Priority.Size = new System.Drawing.Size(139, 30);
            this.Priority.TabIndex = 8;
            // 
            // FCFS
            // 
            this.FCFS.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.FCFS.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FCFS.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.FCFS.Location = new System.Drawing.Point(784, 657);
            this.FCFS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FCFS.Name = "FCFS";
            this.FCFS.Size = new System.Drawing.Size(125, 34);
            this.FCFS.TabIndex = 10;
            this.FCFS.Text = "FCFS";
            this.FCFS.UseVisualStyleBackColor = false;
            this.FCFS.Click += new System.EventHandler(this.FCFS_Click);
            // 
            // SJFP
            // 
            this.SJFP.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.SJFP.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SJFP.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.SJFP.Location = new System.Drawing.Point(915, 657);
            this.SJFP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SJFP.Name = "SJFP";
            this.SJFP.Size = new System.Drawing.Size(189, 34);
            this.SJFP.TabIndex = 11;
            this.SJFP.Text = "SJF Preemptive";
            this.SJFP.UseVisualStyleBackColor = false;
            this.SJFP.Click += new System.EventHandler(this.SJFPreemptive_Click);
            // 
            // PP
            // 
            this.PP.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.PP.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PP.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.PP.Location = new System.Drawing.Point(1109, 657);
            this.PP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PP.Name = "PP";
            this.PP.Size = new System.Drawing.Size(211, 34);
            this.PP.TabIndex = 12;
            this.PP.Text = "Priority Preemptive";
            this.PP.UseVisualStyleBackColor = false;
            this.PP.Click += new System.EventHandler(this.PriorityPreemptive_Click);
            // 
            // RR
            // 
            this.RR.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.RR.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RR.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RR.Location = new System.Drawing.Point(1325, 657);
            this.RR.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RR.Name = "RR";
            this.RR.Size = new System.Drawing.Size(125, 34);
            this.RR.TabIndex = 13;
            this.RR.Text = "Round Robin";
            this.RR.UseVisualStyleBackColor = false;
            this.RR.Click += new System.EventHandler(this.RoundRobin_Click);
            // 
            // PNP
            // 
            this.PNP.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.PNP.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PNP.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.PNP.Location = new System.Drawing.Point(1109, 602);
            this.PNP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PNP.Name = "PNP";
            this.PNP.Size = new System.Drawing.Size(211, 34);
            this.PNP.TabIndex = 14;
            this.PNP.Text = "Priority Non-Preemptive";
            this.PNP.UseVisualStyleBackColor = false;
            this.PNP.Click += new System.EventHandler(this.PriorityNonPreemptive_Click);
            // 
            // SJFNP
            // 
            this.SJFNP.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.SJFNP.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SJFNP.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.SJFNP.Location = new System.Drawing.Point(915, 602);
            this.SJFNP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SJFNP.Name = "SJFNP";
            this.SJFNP.Size = new System.Drawing.Size(189, 34);
            this.SJFNP.TabIndex = 15;
            this.SJFNP.Text = "SJF Non-Preemptive";
            this.SJFNP.UseVisualStyleBackColor = false;
            this.SJFNP.Click += new System.EventHandler(this.SJFNonPreemptive_Click);
            // 
            // timeQuantum_label
            // 
            this.timeQuantum_label.AutoSize = true;
            this.timeQuantum_label.BackColor = System.Drawing.Color.Transparent;
            this.timeQuantum_label.Location = new System.Drawing.Point(1323, 610);
            this.timeQuantum_label.Name = "timeQuantum_label";
            this.timeQuantum_label.Size = new System.Drawing.Size(94, 16);
            this.timeQuantum_label.TabIndex = 17;
            this.timeQuantum_label.Text = "Time Quantum";
            // 
            // TimeQuantum
            // 
            this.TimeQuantum.Location = new System.Drawing.Point(1325, 630);
            this.TimeQuantum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TimeQuantum.Name = "TimeQuantum";
            this.TimeQuantum.Size = new System.Drawing.Size(125, 22);
            this.TimeQuantum.TabIndex = 16;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(749, 335);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(691, 261);
            this.listView1.TabIndex = 18;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "PID";
            this.columnHeader1.Width = 82;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Burst Time";
            this.columnHeader2.Width = 95;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Arrival Time";
            this.columnHeader3.Width = 93;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Priority";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Turnaround Time";
            this.columnHeader5.Width = 103;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Waiting Time";
            this.columnHeader6.Width = 82;
            // 
            // listView2
            // 
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(7, 12);
            this.listView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(1445, 52);
            this.listView2.TabIndex = 19;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // listView3
            // 
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(7, 66);
            this.listView3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(1445, 52);
            this.listView3.TabIndex = 20;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            // 
            // AvgTurnaround
            // 
            this.AvgTurnaround.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvgTurnaround.Location = new System.Drawing.Point(449, 363);
            this.AvgTurnaround.Margin = new System.Windows.Forms.Padding(4);
            this.AvgTurnaround.Name = "AvgTurnaround";
            this.AvgTurnaround.ReadOnly = true;
            this.AvgTurnaround.Size = new System.Drawing.Size(229, 56);
            this.AvgTurnaround.TabIndex = 21;
            this.AvgTurnaround.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(444, 335);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(204, 22);
            this.label5.TabIndex = 22;
            this.label5.Text = "Average Turnaround Time";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(444, 444);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 22);
            this.label6.TabIndex = 24;
            this.label6.Text = "Average Waiting Time";
            // 
            // AvgWaiting
            // 
            this.AvgWaiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvgWaiting.Location = new System.Drawing.Point(449, 473);
            this.AvgWaiting.Margin = new System.Windows.Forms.Padding(4);
            this.AvgWaiting.Name = "AvgWaiting";
            this.AvgWaiting.ReadOnly = true;
            this.AvgWaiting.Size = new System.Drawing.Size(229, 56);
            this.AvgWaiting.TabIndex = 23;
            this.AvgWaiting.Text = "";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 148);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1445, 88);
            this.flowLayoutPanel1.TabIndex = 25;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel2.Location = new System.Drawing.Point(8, 215);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1445, 50);
            this.flowLayoutPanel2.TabIndex = 26;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // liveScheduler
            // 
            this.liveScheduler.AutoSize = true;
            this.liveScheduler.BackColor = System.Drawing.Color.Transparent;
            this.liveScheduler.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.liveScheduler.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.liveScheduler.Location = new System.Drawing.Point(444, 602);
            this.liveScheduler.Margin = new System.Windows.Forms.Padding(4);
            this.liveScheduler.Name = "liveScheduler";
            this.liveScheduler.Size = new System.Drawing.Size(164, 26);
            this.liveScheduler.TabIndex = 27;
            this.liveScheduler.TabStop = true;
            this.liveScheduler.Text = "Live Scheduler";
            this.liveScheduler.UseVisualStyleBackColor = false;
            this.liveScheduler.CheckedChanged += new System.EventHandler(this.liveScheduler_CheckedChanged);
            // 
            // runCurrentProcesses
            // 
            this.runCurrentProcesses.AutoSize = true;
            this.runCurrentProcesses.BackColor = System.Drawing.Color.Transparent;
            this.runCurrentProcesses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runCurrentProcesses.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.runCurrentProcesses.Location = new System.Drawing.Point(444, 657);
            this.runCurrentProcesses.Margin = new System.Windows.Forms.Padding(4);
            this.runCurrentProcesses.Name = "runCurrentProcesses";
            this.runCurrentProcesses.Size = new System.Drawing.Size(239, 26);
            this.runCurrentProcesses.TabIndex = 28;
            this.runCurrentProcesses.TabStop = true;
            this.runCurrentProcesses.Text = "Run Current Processes";
            this.runCurrentProcesses.UseVisualStyleBackColor = false;
            this.runCurrentProcesses.CheckedChanged += new System.EventHandler(this.runCurrentProcesses_CheckedChanged);
            // 
            // reset
            // 
            this.reset.BackColor = System.Drawing.Color.Firebrick;
            this.reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset.ForeColor = System.Drawing.Color.White;
            this.reset.Location = new System.Drawing.Point(220, 630);
            this.reset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(184, 55);
            this.reset.TabIndex = 29;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = false;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // maxNoOfProcesses
            // 
            this.maxNoOfProcesses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxNoOfProcesses.Location = new System.Drawing.Point(193, 588);
            this.maxNoOfProcesses.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maxNoOfProcesses.Name = "maxNoOfProcesses";
            this.maxNoOfProcesses.Size = new System.Drawing.Size(211, 30);
            this.maxNoOfProcesses.TabIndex = 30;
            // 
            // noProcesses_label
            // 
            this.noProcesses_label.AutoSize = true;
            this.noProcesses_label.BackColor = System.Drawing.Color.Transparent;
            this.noProcesses_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noProcesses_label.Location = new System.Drawing.Point(186, 556);
            this.noProcesses_label.Name = "noProcesses_label";
            this.noProcesses_label.Size = new System.Drawing.Size(203, 25);
            this.noProcesses_label.TabIndex = 31;
            this.noProcesses_label.Text = "Max No. of Processes";
            // 
            // chooseScheduler
            // 
            this.chooseScheduler.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseScheduler.FormattingEnabled = true;
            this.chooseScheduler.Items.AddRange(new object[] {
            "Scheduler",
            "FCFS",
            "SJF",
            "Priority",
            "Round Robin"});
            this.chooseScheduler.Location = new System.Drawing.Point(193, 335);
            this.chooseScheduler.Name = "chooseScheduler";
            this.chooseScheduler.Size = new System.Drawing.Size(213, 37);
            this.chooseScheduler.TabIndex = 32;
            this.chooseScheduler.SelectedIndexChanged += new System.EventHandler(this.chooseScheduler_SelectedIndexChanged);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(8, 245);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(1445, 21);
            this.hScrollBar1.TabIndex = 33;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.back;
            this.ClientSize = new System.Drawing.Size(1469, 699);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.chooseScheduler);
            this.Controls.Add(this.noProcesses_label);
            this.Controls.Add(this.maxNoOfProcesses);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.runCurrentProcesses);
            this.Controls.Add(this.liveScheduler);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AvgWaiting);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AvgTurnaround);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.timeQuantum_label);
            this.Controls.Add(this.TimeQuantum);
            this.Controls.Add(this.SJFNP);
            this.Controls.Add(this.PNP);
            this.Controls.Add(this.RR);
            this.Controls.Add(this.PP);
            this.Controls.Add(this.SJFP);
            this.Controls.Add(this.FCFS);
            this.Controls.Add(this.prioity_label);
            this.Controls.Add(this.Priority);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BurstTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ArrivalTime);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = " OS Scheduler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ArrivalTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BurstTime;
        private System.Windows.Forms.Label prioity_label;
        private System.Windows.Forms.TextBox Priority;
        private System.Windows.Forms.Button FCFS;
        private System.Windows.Forms.Button SJFP;
        private System.Windows.Forms.Button PP;
        private System.Windows.Forms.Button RR;
        private System.Windows.Forms.Button PNP;
        private System.Windows.Forms.Button SJFNP;
        private System.Windows.Forms.Label timeQuantum_label;
        private System.Windows.Forms.TextBox TimeQuantum;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.RichTextBox AvgTurnaround;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox AvgWaiting;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton liveScheduler;
        private System.Windows.Forms.RadioButton runCurrentProcesses;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.TextBox maxNoOfProcesses;
        private System.Windows.Forms.Label noProcesses_label;
        private System.Windows.Forms.ComboBox chooseScheduler;
        private System.Windows.Forms.HScrollBar hScrollBar1;
    }
}


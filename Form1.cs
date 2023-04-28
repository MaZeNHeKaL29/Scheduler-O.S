using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int maxNoProcesses = 0;
        int pidCounter = 1;
        int counter = 0;
        bool timer = false;
        List<Process> processList = new List<Process>();
        int totalTime = 0;
        int currentTime = 0;
        List<ListViewItem> listViewItems = new List<ListViewItem>();
        int processIndex = -1;
        public static System.Timers.Timer aTimer;
        int timeQuantum = 1; //Default Time Quantum
        int timeQuantumCount = 1;
        Label l1 = new Label();
        Label l2 = new Label();
        static Func<List<Process>, int,int, Tuple<List<Process>, int>> FuncPtr = null;
        public Form1()
        {
            InitializeComponent();
            // Create a timer and set a two second interval.
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 1000;

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            aTimer.AutoReset = true;
            liveScheduler.Checked = true;
            chooseScheduler.SelectedIndex = 0;
            flowLayoutPanel1.HorizontalScroll.Visible = false;
            flowLayoutPanel1.VerticalScroll.Visible = false;
            flowLayoutPanel1.HorizontalScroll.Maximum = 0;
            flowLayoutPanel1.AutoScrollMinSize = new Size(0, 0);
            flowLayoutPanel2.HorizontalScroll.Visible = false;
            flowLayoutPanel2.VerticalScroll.Visible = false;
            hScrollBar1.Visible = false;
        }

        public void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (FuncPtr != null)
            {
                var tuple = FuncPtr(processList, timeQuantum,counter);
                processList = tuple.Item1;
                processIndex = tuple.Item2;
            }
            if (counter % 18 == 0)
            {
                // Use Invoke method to update the listView2 control from the UI thread
                listView2.Invoke((MethodInvoker)delegate {
                    listView2.Columns.Clear();
                });
                listView3.Invoke((MethodInvoker)delegate {
                    listView3.Columns.Clear();
                });
            }
            listView2.Invoke((MethodInvoker)delegate {
                listView2.Columns.Add(counter.ToString());
            });
            try
            {
                if (processList != null && processList.Count > 0 && processIndex < processList.Count && processIndex != -1 )
                {
                    listView3.Invoke((MethodInvoker)delegate {
                        listView3.Columns.Add("P" + processList.ElementAt(processIndex).pid.ToString());
                    });
                }
                else
                {
                    listView3.Invoke((MethodInvoker)delegate {
                        listView3.Columns.Add("IDLE");
                    });
                }
            }
            catch(Exception ex)
            {
                listView3.Invoke((MethodInvoker)delegate {
                    listView3.Columns.Add("IDLE");
                });
            }
            counter++;
            listViewItems.Clear();
            for (int i = 0; i < processList.Count; i++)
            {
                Process p = processList[i];

                ListViewItem list_item = new ListViewItem(p.pid.ToString());
                list_item.SubItems.Add(p.burst_time.ToString());
                list_item.SubItems.Add(p.arrival_time.ToString());
                list_item.SubItems.Add(p.priority.ToString());
                list_item.SubItems.Add(p.turnaround_time.ToString());
                list_item.SubItems.Add(p.waiting_time.ToString());
                listViewItems.Add(list_item);
            }
            totalTime = 0;
            currentTime = 0;
            for (int i = 0; i < processList.Count; i++)
            {
                Process p = processList[i];
                if (p.arrival_time > currentTime)
                {
                    totalTime += p.arrival_time - currentTime;
                    currentTime = p.arrival_time;
                }
                totalTime += p.burst_time;
                currentTime += p.burst_time;
            }
            listView1.Invoke((MethodInvoker)delegate {
                listView1.Items.Clear();
            });
            foreach (ListViewItem item in listViewItems)
            {
                listView1.Invoke((MethodInvoker)delegate {
                    listView1.Items.Add(item);
                });
            }
            if(pidCounter > 1)
            {
                AvgTurnaround.Invoke((MethodInvoker)delegate {
                    AvgTurnaround.Text = ((float)Process.total_turnaround_time / (pidCounter - 1)).ToString();
                });
                AvgWaiting.Invoke((MethodInvoker)delegate {
                    AvgWaiting.Text = ((float)Process.total_waiting_time / (pidCounter - 1)).ToString();
                });
            }
            else
            {
                AvgTurnaround.Invoke((MethodInvoker)delegate {
                    AvgTurnaround.Text = ((float)Process.total_turnaround_time).ToString();
                });
                AvgWaiting.Invoke((MethodInvoker)delegate {
                    AvgWaiting.Text = ((float)Process.total_waiting_time).ToString();
                });
            }
        }

        public void runCurrentProcess()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();
            float fsize;
            int size;
            if(totalTime > 30)
            {
                fsize = (float)(25 + 1) / 51 / 21;
                hScrollBar1.Visible= true;
            }
            else
            {
                fsize = (float)(totalTime + 1) / 51 / 21;
                hScrollBar1.Visible= false;
            }
            fsize = 1 / fsize;
            size = (int)fsize;
            List<Tuple<int,string, int, int>> processes = new List<Tuple<int,string, int, int>>();
            List<Process> processList1 = new List<Process>();
            foreach(Process p in processList)
            {
                Process process = new Process(p.pid, p.arrival_time, p.burst_time, p.priority);
                processList1.Add(process);
            }
            for (int i = 0; i < totalTime + 1; i++)
            {
                if (FuncPtr != null)
                {
                    var tuple = FuncPtr(processList1, timeQuantum, i);
                    processList1 = tuple.Item1;
                    processIndex = tuple.Item2;
                }
                if (processList1 != null && processList1.Count > 0 && processIndex < processList1.Count && processIndex != -1)
                {
                    Process p = processList1.ElementAt(processIndex);
                    if(p.burst_time == 0)
                    {
                        foreach(Process process in processList)
                        {
                            if(process.pid == p.pid)
                            {
                                process.turnaround_time = p.turnaround_time;
                                process.waiting_time = p.waiting_time;
                            }
                        }
                    }
                    if (processes.Count > 0)
                    {
                        if (processes.ElementAt(processes.Count - 1).Item1 == p.pid)
                        {
                            int width = processes.ElementAt(processes.Count - 1).Item3 + 1;
                            processes[processes.Count - 1] = new Tuple<int, string, int, int>(p.pid, "P" + p.pid.ToString(), width, i);
                        }
                        else
                        {
                            processes.Add((new Tuple<int, string, int, int>(p.pid, "P" + p.pid.ToString(), 1, i)));
                        }
                    }
                    else
                    {
                        processes.Add((new Tuple<int, string, int, int>(p.pid, "P" + p.pid.ToString(), 1, i)));
                    }
                }
                else
                {
                    processes.Add((new Tuple<int, string, int, int>(-1, "IDLE" , 1, i)));
                }
            }
            processIndex = -1;
            processList1.Clear();
            Scheduler.timeQuantum = 1;
            Scheduler.timeQuantumCount = 0;
            Scheduler.locked = false;
            Scheduler.processIndex = -1;
            foreach (Tuple<int,string, int, int> process in processes)
            {
                Label label = new Label();
                label.Text = process.Item2;
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.BorderStyle = BorderStyle.FixedSingle;
                label.Size = new Size(process.Item3 * size, 50);
                label.Location = new Point(process.Item4 * size, 0);
                label.Margin = new Padding(0);
                flowLayoutPanel1.Controls.Add(label);
            }
            flowLayoutPanel2.FlowDirection = FlowDirection.LeftToRight;
            for (int i = 0; i < totalTime + 1; i++)
            {
                Label label = new Label();
                label.Text = i.ToString();
                label.TextAlign = ContentAlignment.TopLeft;
                label.BorderStyle = BorderStyle.FixedSingle;
                label.Size = new Size(size, 20);
                label.Location = new Point(i * size, 50);
                label.Margin = new Padding(0);
                flowLayoutPanel2.Controls.Add(label);
            }
            /* update table with turnaround time and waiting time */
            listViewItems.Clear();
            for (int i = 0; i < processList.Count; i++)
            {
                Process p = processList[i];

                ListViewItem list_item = new ListViewItem(p.pid.ToString());
                list_item.SubItems.Add(p.burst_time.ToString());
                list_item.SubItems.Add(p.arrival_time.ToString());
                list_item.SubItems.Add(p.priority.ToString());
                list_item.SubItems.Add(p.turnaround_time.ToString());
                list_item.SubItems.Add(p.waiting_time.ToString());
                listViewItems.Add(list_item);
            }
            listView1.Items.Clear();
            foreach (ListViewItem item in listViewItems)
            {
                listView1.Items.Add(item);
            }
            foreach(Process p in processList)
            {
                p.turnaround_time = 0;
                p.waiting_time = 0;
            }
            if (pidCounter > 1)
            {
                AvgTurnaround.Text = ((float)Process.total_turnaround_time / (pidCounter - 1)).ToString();
                AvgWaiting.Text = ((float)Process.total_waiting_time / (pidCounter - 1)).ToString();
            }
            else
            {
                AvgTurnaround.Text = ((float)Process.total_turnaround_time).ToString();
                AvgWaiting.Text = ((float)Process.total_waiting_time).ToString();
            }
            Process.total_turnaround_time= 0;
            Process.total_waiting_time= 0;
            // Recalculate the total width of the panel's contents
            int totalWidth = flowLayoutPanel1.Controls.Cast<Control>().Sum(control => control.Width + control.Margin.Horizontal);

            // Set the maximum value of the external scrollbar to the total width
            hScrollBar1.Maximum = totalWidth;

            // Set the small change and large change values of the scrollbar
            hScrollBar1.SmallChange = 10;
            hScrollBar1.LargeChange = flowLayoutPanel1.ClientSize.Width;
        }

        private void AddProcess_Click(object sender, EventArgs e)
        {
            int.TryParse(maxNoOfProcesses.Text.ToString(), out maxNoProcesses);
            if (processList.Count < maxNoProcesses || maxNoProcesses == 0 || liveScheduler.Checked == true)
            {
                Process p;
                int pid = pidCounter;
                pidCounter++;
                int burst_time = 0;
                int priority = 0;
                int arrival_time = 0;
                int.TryParse(ArrivalTime.Text.ToString(), out arrival_time);
                if (arrival_time <= counter)
                {
                    arrival_time = counter;
                }
                int.TryParse(BurstTime.Text.ToString(), out burst_time);
                int.TryParse(Priority.Text.ToString(), out priority);
                if (burst_time != 0)
                {
                    p = new Process(pid, arrival_time, burst_time, priority);
                    processList.Add(p);
                    if (!timer)
                    {
                        ListViewItem list_item = new ListViewItem(p.pid.ToString());
                        list_item.SubItems.Add(p.burst_time.ToString());
                        list_item.SubItems.Add(p.arrival_time.ToString());
                        list_item.SubItems.Add(p.priority.ToString());
                        list_item.SubItems.Add(p.turnaround_time.ToString());
                        list_item.SubItems.Add(p.waiting_time.ToString());
                        listViewItems.Add(list_item);
                        listView1.Items.Clear();
                        foreach (ListViewItem item in listViewItems)
                        {
                            listView1.Items.Add(item);
                        }
                    }
                    if (p.arrival_time > currentTime)
                    {
                        totalTime += p.arrival_time - currentTime;
                        currentTime = p.arrival_time;
                    }
                    totalTime += p.burst_time;
                    currentTime += p.burst_time;
                }
            }
            
        }

        private void FCFS_Click(object sender, EventArgs e)
        {
            Scheduler.timeQuantum = 1;
            Scheduler.timeQuantumCount = 0;
            Scheduler.locked = false;
            Scheduler.processIndex = -1;
            Process.total_turnaround_time = 0;
            Process.total_waiting_time = 0;
            listView2.Clear();
            listView3.Clear();
            counter = 0;
            FuncPtr = Scheduler.FCFS;
            if(runCurrentProcesses.Checked)
            {
                runCurrentProcess();
            }
            else if(liveScheduler.Checked)
            {
                aTimer.Close();
                // Start the timer
                aTimer.Enabled = true;
                timer = true;
            }
            Scheduler.timeQuantum = 1;
            Scheduler.timeQuantumCount = 0;
            Scheduler.locked = false;
            Scheduler.processIndex = -1;
        }

        private void SJFNonPreemptive_Click(object sender, EventArgs e)
        {
            Scheduler.timeQuantum = 1;
            Scheduler.timeQuantumCount = 0;
            Scheduler.locked = false;
            Scheduler.processIndex = -1;
            Process.total_turnaround_time = 0;
            Process.total_waiting_time = 0;
            listView2.Clear();
            listView3.Clear();
            counter = 0;
            FuncPtr = Scheduler.SJFNonPreemptive;
            if (runCurrentProcesses.Checked)
            {
                runCurrentProcess();
            }
            else if (liveScheduler.Checked)
            {
                aTimer.Close();
                // Start the timer
                aTimer.Enabled = true;
                timer = true;
            }
            Scheduler.timeQuantum = 1;
            Scheduler.timeQuantumCount = 0;
            Scheduler.locked = false;
            Scheduler.processIndex = -1;
        }

        private void SJFPreemptive_Click(object sender, EventArgs e)
        {
            Scheduler.timeQuantum = 1;
            Scheduler.timeQuantumCount = 0;
            Scheduler.locked = false;
            Scheduler.processIndex = -1;
            Process.total_turnaround_time = 0;
            Process.total_waiting_time = 0;
            listView2.Clear();
            listView3.Clear();
            counter = 0;
            FuncPtr = Scheduler.SJFPreemptive;
            if (runCurrentProcesses.Checked)
            {
                runCurrentProcess();
            }
            else if (liveScheduler.Checked)
            {
                aTimer.Close();
                // Start the timer
                aTimer.Enabled = true;
                timer = true;
            }
            Scheduler.timeQuantum = 1;
            Scheduler.timeQuantumCount = 0;
            Scheduler.locked = false;
            Scheduler.processIndex = -1;
        }


        private void PriorityNonPreemptive_Click(object sender, EventArgs e)
        {
            Scheduler.timeQuantum = 1;
            Scheduler.timeQuantumCount = 0;
            Scheduler.locked = false;
            Scheduler.processIndex = -1;
            Process.total_turnaround_time = 0;
            Process.total_waiting_time = 0;
            listView2.Clear();
            listView3.Clear();
            counter = 0;
            FuncPtr = Scheduler.PriorityNonPreemptive;
            if (runCurrentProcesses.Checked)
            {
                runCurrentProcess();
            }
            else if (liveScheduler.Checked)
            {
                aTimer.Close();
                // Start the timer
                aTimer.Enabled = true;
                timer = true;
            }
            Scheduler.timeQuantum = 1;
            Scheduler.timeQuantumCount = 0;
            Scheduler.locked = false;
            Scheduler.processIndex = -1;
        }

        private void PriorityPreemptive_Click(object sender, EventArgs e)
        {
            Scheduler.timeQuantum = 1;
            Scheduler.timeQuantumCount = 0;
            Scheduler.locked = false;
            Scheduler.processIndex = -1;
            Process.total_turnaround_time = 0;
            Process.total_waiting_time = 0;
            listView2.Clear();
            listView3.Clear();
            counter = 0;
            FuncPtr = Scheduler.PriorityPreemptive;
            if (runCurrentProcesses.Checked)
            {
                runCurrentProcess();
            }
            else if (liveScheduler.Checked)
            {
                aTimer.Close();
                // Start the timer
                aTimer.Enabled = true;
                timer = true;
            }
            Scheduler.timeQuantum = 1;
            Scheduler.timeQuantumCount = 0;
            Scheduler.locked = false;
            Scheduler.processIndex = -1;
        }

        private void RoundRobin_Click(object sender, EventArgs e)
        {
            Scheduler.timeQuantum = 1;
            Scheduler.timeQuantumCount = 0;
            Scheduler.locked = false;
            Scheduler.processIndex = -1;
            Process.total_turnaround_time = 0;
            Process.total_waiting_time = 0;
            listView2.Clear();
            listView3.Clear();
            counter = 0;
            int.TryParse(TimeQuantum.Text.ToString(), out timeQuantum);
            int.TryParse(TimeQuantum.Text.ToString(), out timeQuantumCount);
            if(timeQuantum == 0)
            {
                timeQuantum = 1; //Default Time Quantum
                timeQuantumCount = 1;
                TimeQuantum.Text = "1";
            }
            FuncPtr = Scheduler.RoundRobin;
            processList.Sort((x,y) => x.arrival_time.CompareTo(y.arrival_time));
            if (runCurrentProcesses.Checked)
            {
                runCurrentProcess();
            }
            else if (liveScheduler.Checked)
            {
                aTimer.Close();
                // Start the timer
                aTimer.Enabled = true;
                timer = true;
            }
            Scheduler.timeQuantum = 1;
            Scheduler.timeQuantumCount = 0;
            Scheduler.locked = false;
            Scheduler.processIndex = -1;
        }

        private void liveScheduler_CheckedChanged(object sender, EventArgs e)
        {
            if(liveScheduler.Checked)
            {
                runCurrentProcesses.Checked = false;
                liveScheduler.Checked = true;
                maxNoOfProcesses.Visible = false;
                noProcesses_label.Visible = false;
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel2.Controls.Clear();
                listViewItems.Clear();
                for (int i = 0; i < processList.Count; i++)
                {
                    Process p = processList[i];

                    ListViewItem list_item = new ListViewItem(p.pid.ToString());
                    list_item.SubItems.Add(p.burst_time.ToString());
                    list_item.SubItems.Add(p.arrival_time.ToString());
                    list_item.SubItems.Add(p.priority.ToString());
                    list_item.SubItems.Add(p.turnaround_time.ToString());
                    list_item.SubItems.Add(p.waiting_time.ToString());
                    listViewItems.Add(list_item);
                }
                listView1.Items.Clear();
                foreach (ListViewItem item in listViewItems)
                {
                    listView1.Items.Add(item);
                }
            }
        }

        private void runCurrentProcesses_CheckedChanged(object sender, EventArgs e)
        {
            if(runCurrentProcesses.Checked)
            {
                liveScheduler.Checked = false;
                runCurrentProcesses.Checked = true;
                aTimer.Close();
                aTimer.Enabled = false;
                timer = false;
                counter = 0;
                listView2.Clear();
                listView3.Clear();
                maxNoOfProcesses.Visible = true;
                noProcesses_label.Visible = true;
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            aTimer.Close();
            aTimer.Enabled = false;
            timer = false;
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();
            counter = 0;
            pidCounter = 1;
            listView1.Items.Clear();
            listView2.Clear();
            listView3.Clear();
            processList.Clear();
            listViewItems.Clear();
            totalTime = 0;
            currentTime = 0;
            processIndex = -1;
            timeQuantum = 1;
            timeQuantumCount = 1;
            Scheduler.timeQuantum = 1;
            Scheduler.timeQuantumCount = 0;
            Scheduler.locked = false;
            Scheduler.processIndex = -1;
            Process.total_turnaround_time = 0;
            Process.total_waiting_time = 0;
            chooseScheduler.SelectedIndex = 0;
            AvgTurnaround.Text = "";
            AvgWaiting.Text = "";
            Priority.Text = "";
            ArrivalTime.Text = "";
            BurstTime.Text = "";
            TimeQuantum.Text = "";
            maxNoOfProcesses.Text = "";
            hScrollBar1.Visible = false;
        }

        private void chooseScheduler_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = chooseScheduler.SelectedIndex;
            switch(index)
            {
                default:
                case -1:
                case 0:
                    FCFS.Visible = true;
                    SJFP.Visible = true;
                    SJFNP.Visible = true;
                    PP.Visible= true;
                    PNP.Visible = true;
                    RR.Visible = true;
                    TimeQuantum.Visible = true;
                    timeQuantum_label.Visible = true;
                    prioity_label.Visible = true;
                    Priority.Visible = true;
                    break;
                case 1:
                    FCFS.Visible = true;
                    SJFP.Visible = false;
                    SJFNP.Visible = false;
                    PP.Visible = false;
                    PNP.Visible = false;
                    RR.Visible = false;
                    TimeQuantum.Visible = false;
                    timeQuantum_label.Visible = false;
                    prioity_label.Visible = false;
                    Priority.Visible = false;
                    Priority.Text = "";
                    break;
                case 2:
                    FCFS.Visible = false;
                    SJFP.Visible = true;
                    SJFNP.Visible = true;
                    PP.Visible = false;
                    PNP.Visible = false;
                    RR.Visible = false;
                    TimeQuantum.Visible = false;
                    timeQuantum_label.Visible = false;
                    prioity_label.Visible = false;
                    Priority.Visible = false;
                    Priority.Text = "";
                    break;
                case 3:
                    FCFS.Visible = false;
                    SJFP.Visible = false;
                    SJFNP.Visible = false;
                    PP.Visible = true;
                    PNP.Visible = true;
                    RR.Visible = false;
                    TimeQuantum.Visible = false;
                    timeQuantum_label.Visible = false;
                    prioity_label.Visible = true;
                    Priority.Visible = true;
                    break;
                case 4:
                    FCFS.Visible = false;
                    SJFP.Visible = false;
                    SJFNP.Visible = false;
                    PP.Visible = false;
                    PNP.Visible = false;
                    RR.Visible = true;
                    TimeQuantum.Visible = true;
                    timeQuantum_label.Visible = true;
                    prioity_label.Visible = false;
                    Priority.Visible = false;
                    Priority.Text = "";
                    break;
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            flowLayoutPanel1.HorizontalScroll.Value = hScrollBar1.Value;
            flowLayoutPanel2.HorizontalScroll.Value = hScrollBar1.Value;
            // Recalculate the total width of the panel's contents
            int totalWidth = flowLayoutPanel1.Controls.Cast<Control>().Sum(control => control.Width + control.Margin.Horizontal);

            // Set the maximum value of the external scrollbar to the total width
            hScrollBar1.Maximum = totalWidth;

            // Set the small change and large change values of the scrollbar
            hScrollBar1.SmallChange = 10;
            hScrollBar1.LargeChange = flowLayoutPanel1.ClientSize.Width;
        }
    }
}

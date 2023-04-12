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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int pidCounter = 1;
        int counter = 0;
        bool timer = false;
        List<Process> processList = new List<Process>();
        List<ListViewItem> listViewItems = new List<ListViewItem>();
        int processIndex;
        public static System.Timers.Timer aTimer;
        int timeQuantum = 1; //Default Time Quantum
        int timeQuantumCount = 1;
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

        }

        public void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (FuncPtr != null)
            {
                var tuple = FuncPtr(processList, timeQuantum,counter);
                processList = tuple.Item1;
                processIndex = tuple.Item2;
            }
            if (counter % 12 == 0)
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
                        listView3.Columns.Add("#");
                    });
                }
            }
            catch(Exception ex)
            {
                listView3.Invoke((MethodInvoker)delegate {
                    listView3.Columns.Add("#");
                });
            }
            counter++;
            listViewItems.Clear();
            for (int i = processList.Count - 1; i >= 0; i--)
            {
                Process p = processList[i];

                ListViewItem list_item = new ListViewItem(p.pid.ToString());
                list_item.SubItems.Add(p.burst_time.ToString());
                list_item.SubItems.Add(p.arrival_time.ToString());
                list_item.SubItems.Add(p.priority.ToString());
                listViewItems.Add(list_item);
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AddProcess_Click(object sender, EventArgs e)
        {
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
                Process p = new Process(pid, arrival_time, burst_time, priority);
                processList.Add(p);
                if (!timer)
                {
                    ListViewItem list_item = new ListViewItem(p.pid.ToString());
                    list_item.SubItems.Add(p.burst_time.ToString());
                    list_item.SubItems.Add(p.arrival_time.ToString());
                    list_item.SubItems.Add(p.priority.ToString());
                    listViewItems.Add(list_item);
                    listView1.Items.Clear();
                    foreach (ListViewItem item in listViewItems)
                    {
                        listView1.Items.Add(item);
                    }
                }
            }
        }

        private void FCFS_Click(object sender, EventArgs e)
        {
            listView2.Clear();
            listView3.Clear();
            counter = 0;
            FuncPtr = Scheduler.FCFS;
            aTimer.Close();
            // Start the timer
            aTimer.Enabled = true;
            timer = true;
        }

        private void SJFNonPreemptive_Click(object sender, EventArgs e)
        {
            listView2.Clear();
            listView3.Clear();
            counter = 0;
            FuncPtr = Scheduler.SJFNonPreemptive;
            aTimer.Close();
            // Start the timer
            aTimer.Enabled = true;
            timer = true;
        }

        private void SJFPreemptive_Click(object sender, EventArgs e)
        {
            listView2.Clear();
            listView3.Clear();
            counter = 0;
            FuncPtr = Scheduler.SJFPreemptive;
            aTimer.Close();
            // Start the timer
            aTimer.Enabled = true;
            timer = true;
        }


        private void PriorityNonPreemptive_Click(object sender, EventArgs e)
        {
            listView2.Clear();
            listView3.Clear();
            counter = 0;
            FuncPtr = Scheduler.PriorityNonPreemptive;
            aTimer.Close();
            // Start the timer
            aTimer.Enabled = true;
            timer = true;

        }

        private void PriorityPreemptive_Click(object sender, EventArgs e)
        {
            listView2.Clear();
            listView3.Clear();
            counter = 0;
            FuncPtr = Scheduler.PriorityPreemptive;
            aTimer.Close();
            // Start the timer
            aTimer.Enabled = true;
            timer = true;
        }

        private void RoundRobin_Click(object sender, EventArgs e)
        {
            listView2.Clear();
            listView3.Clear();
            counter = 0;
            int.TryParse(TimeQuantum.Text.ToString(), out timeQuantum);
            timeQuantumCount = (int)timeQuantum;
            FuncPtr = Scheduler.RoundRobin;
            aTimer.Close();
            // Start the timer
            aTimer.Enabled = true;
            timer = true;
        }
    }
}

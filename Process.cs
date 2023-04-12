using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Process
    {
        public int pid { get; set; }
        public int arrival_time { get; set; }
        public int burst_time { get; set; }
        public int priority { get; set; } 

        public int waiting_time {  get; set; }

        public int turnaround_time { get; set; }

        public static int noOfProcesses { get; set; }

        public Process(int pid, int arrival_time, int burst_time)
        {
            this.pid = pid;
            this.arrival_time= arrival_time;
            this.burst_time= burst_time;
            this.priority = 0;
            noOfProcesses++;
        }

        public Process(int pid, int arrival_time, int burst_time, int priority)
        {
            this.pid = pid;
            this.arrival_time = arrival_time;
            this.burst_time = burst_time;
            this.priority = priority;
            noOfProcesses++;
        }
    }
}

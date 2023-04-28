using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Scheduler
    {
        static List<Process> processList;
        public static int timeQuantum = 1;
        public static int timeQuantumCount = 0;
        public static bool locked = false;
        public static int processIndex = -1;

        public Scheduler(ref List<Process> processList_a)
        {
            processList = processList_a;
            locked = false;
        }

        public Scheduler(ref List<Process> processList_a, int timeQuantum_a)
        {
            processList = processList_a;
            timeQuantum = timeQuantum_a;
            locked = false;
        }

        public static Tuple<List<Process>, int> FCFS(List<Process> processList_a, int timeQuantum_a, int timer)
        {
            processList = processList_a;
            try
            {
                if (processList.ElementAt(processIndex).burst_time <= 0)
                {
                    locked = false;
                    processList.RemoveAt(processIndex);
                }
            }
            catch (Exception e)
            {
                locked = false;
            }
            if (!locked)
            {
                processIndex = -1;
                int minArrivalTime = int.MaxValue;
                for (int i = 0; i < processList.Count; i++)
                {
                    if (processList.ElementAt(i).arrival_time < minArrivalTime)
                    {
                        if (!(processList.ElementAt(i).arrival_time <= timer))
                        {
                            continue;
                        }
                        minArrivalTime = processList.ElementAt(i).arrival_time;
                        processIndex = i;
                    }
                }
                locked = true;

            }
            if (processList != null && processList.Count > 0 && processIndex < processList.Count && processIndex != -1)
            {
                processList.ElementAt(processIndex).burst_time--;
                processList.ElementAt(processIndex).turnaround_time++;
                Process.total_turnaround_time++;
            }
            for (int i = 0; i < processList.Count; i++)
            {
                if (i != processIndex)
                {
                    if (!(processList.ElementAt(i).arrival_time <= timer))
                    {
                        continue;
                    }
                    processList.ElementAt(i).waiting_time++;
                    processList.ElementAt(i).turnaround_time++;
                    Process.total_turnaround_time++;
                    Process.total_waiting_time++;
                }
            }
            return Tuple.Create(processList, processIndex);
        }

        public static Tuple<List<Process>, int> SJFNonPreemptive(List<Process> processList_a, int timeQuantum_a, int timer)
        {
            processList = processList_a;
            try
            {
                if (processList.ElementAt(processIndex).burst_time <= 0)
                {
                    locked = false;
                    processList.RemoveAt(processIndex);
                }
            }
            catch (Exception e)
            {
                locked = false;
            }
            if (!locked)
            {
                processIndex = -1;
                int minBurstTime = int.MaxValue;
                for (int i = 0; i < processList.Count; i++)
                {
                    if (processList.ElementAt(i).burst_time < minBurstTime)
                    {
                        if (!(processList.ElementAt(i).arrival_time <= timer))
                        {
                            continue;
                        }
                        minBurstTime = processList.ElementAt(i).burst_time;
                        processIndex = i;
                    }
                }
                locked = true;

            }
            if (processList != null && processList.Count > 0 && processIndex < processList.Count && processIndex != -1)
            {
                processList.ElementAt(processIndex).burst_time--;
                processList.ElementAt(processIndex).turnaround_time++;
                Process.total_turnaround_time++;
            }
            for (int i = 0; i < processList.Count; i++)
            {
                if (i != processIndex)
                {
                    if (!(processList.ElementAt(i).arrival_time <= timer))
                    {
                        continue;
                    }
                    processList.ElementAt(i).waiting_time++;
                    processList.ElementAt(i).turnaround_time++;
                    Process.total_turnaround_time++;
                    Process.total_waiting_time++;
                }
            }
            return Tuple.Create(processList, processIndex);
        }

        public static Tuple<List<Process>, int> SJFPreemptive(List<Process> processList_a, int timeQuantum_a, int timer)
        {
            processList = processList_a;
            try
            {
                if (processList.ElementAt(processIndex).burst_time <= 0)
                {
                    processList.RemoveAt(processIndex);
                }
                locked = false;
            }
            catch (Exception e)
            {
                locked = false;
            }
            processIndex = -1;
            int minBurstTime = int.MaxValue;
            for (int i = 0; i < processList.Count; i++)
            {
                if (processList.ElementAt(i).burst_time < minBurstTime)
                {
                    if (!(processList.ElementAt(i).arrival_time <= timer))
                    {
                        continue;
                    }
                    minBurstTime = processList.ElementAt(i).burst_time;
                    processIndex = i;
                }
            }
            if (processList != null && processList.Count > 0 && processIndex < processList.Count && processIndex != -1)
            {
                processList.ElementAt(processIndex).burst_time--;
                processList.ElementAt(processIndex).turnaround_time++;
                Process.total_turnaround_time++;
            }
            for (int i = 0; i < processList.Count; i++)
            {
                if (i != processIndex)
                {
                    if (!(processList.ElementAt(i).arrival_time <= timer))
                    {
                        continue;
                    }
                    processList.ElementAt(i).waiting_time++;
                    processList.ElementAt(i).turnaround_time++;
                    Process.total_turnaround_time++;
                    Process.total_waiting_time++;
                }
            }
            return Tuple.Create(processList, processIndex);
        }

        public static Tuple<List<Process>, int> PriorityNonPreemptive(List<Process> processList_a, int timeQuantum_a, int timer)
        {
            processList = processList_a;
            try
            {
                if (processList.ElementAt(processIndex).burst_time <= 0)
                {
                    locked = false;
                    processList.RemoveAt(processIndex);
                }
            }
            catch (Exception e)
            {
                locked = false;
            }
            if (!locked)
            {
                processIndex = -1;
                int minPriority = int.MaxValue;
                for (int i = 0; i < processList.Count; i++)
                {
                    if (!(processList.ElementAt(i).arrival_time <= timer))
                    {
                        continue;
                    }
                    if (processList.ElementAt(i).priority < minPriority)
                    {
                        minPriority = processList.ElementAt(i).priority;
                        processIndex = i;
                    }
                }
                locked = true;

            }
            if (processList != null && processList.Count > 0 && processIndex < processList.Count && processIndex != -1)
            {
                processList.ElementAt(processIndex).burst_time--;
                processList.ElementAt(processIndex).turnaround_time++;
                Process.total_turnaround_time++;
            }
            for (int i = 0; i < processList.Count; i++)
            {
                if (i != processIndex)
                {
                    if (!(processList.ElementAt(i).arrival_time <= timer))
                    {
                        continue;
                    }
                    processList.ElementAt(i).waiting_time++;
                    processList.ElementAt(i).turnaround_time++;
                    Process.total_turnaround_time++;
                    Process.total_waiting_time++;
                }
            }
            return Tuple.Create(processList, processIndex);
        }

        public static Tuple<List<Process>, int> PriorityPreemptive(List<Process> processList_a, int timeQuantum_a, int timer)
        {
            processList = processList_a;
            try
            {
                if (processList.ElementAt(processIndex).burst_time <= 0)
                {
                    processList.RemoveAt(processIndex);
                }
                locked = false;
            }
            catch (Exception e)
            {
                locked = false;
            }
            processIndex = -1;
            int minPriority = int.MaxValue;
            for (int i = 0; i < processList.Count; i++)
            {
                if (processList.ElementAt(i).priority < minPriority)
                {
                    if (!(processList.ElementAt(i).arrival_time <= timer))
                    {
                        continue;
                    }
                    minPriority = processList.ElementAt(i).priority;
                    processIndex = i;
                }
            }
            if (processList != null && processList.Count > 0 && processIndex < processList.Count && processIndex != -1)
            {
                processList.ElementAt(processIndex).burst_time--;
                processList.ElementAt(processIndex).turnaround_time++;
                Process.total_turnaround_time++;
            }
            for (int i = 0; i < processList.Count; i++)
            {
                if (i != processIndex)
                {
                    if (!(processList.ElementAt(i).arrival_time <= timer))
                    {
                        continue;
                    }
                    processList.ElementAt(i).waiting_time++;
                    processList.ElementAt(i).turnaround_time++;
                    Process.total_turnaround_time++;
                    Process.total_waiting_time++;
                }
            }
            return Tuple.Create(processList, processIndex);
        }

        public static Tuple<List<Process>, int> RoundRobin(List<Process> processList_a, int timeQuantum_a, int timer)
        {
            Process p = null;
            processList = processList_a;
            timeQuantum = timeQuantum_a;
            try
            {
                if (processList.ElementAt(processIndex).burst_time <= 0)
                {
                    locked = false;
                    processList.RemoveAt(processIndex);
                    timeQuantumCount = timeQuantum;
                }
            }
            catch (Exception e)
            {
                locked = false;
            }
            if(timeQuantumCount == 0)
            {
                if (processList != null && processList.Count > 0 && processIndex < processList.Count && processIndex != -1)
                {
                    Console.WriteLine("In RR" + processList.ElementAt(processIndex).pid + " " + processIndex);
                    p = processList.ElementAt(processIndex);
                    processList.RemoveAt(processIndex);
                    processList.Add(p);
                    for(int i = processList.Count - 2; i >= 0; i --)
                    {
                        if (!(processList.ElementAt(i).arrival_time <= timer))
                        {
                            Process p1 = processList.ElementAt(i);
                            processList[i] = processList[i + 1];
                            processList[i + 1] = p1;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                locked = false;
                timeQuantumCount = timeQuantum;
            }
            if (!locked)
            {
                processIndex = -1;
                for (int i = 0; i < processList.Count; i++)
                {
                    if (!(processList.ElementAt(i).arrival_time <= timer))
                    {
                        continue;
                    }
                    processIndex = i;
                    break;
                }
                locked = true;

            }
            if (processList != null && processList.Count > 0 && processIndex < processList.Count && processIndex != -1)
            {
                processList.ElementAt(processIndex).burst_time--;
                processList.ElementAt(processIndex).turnaround_time++;
                Process.total_turnaround_time++;
            }
            for (int i = 0; i < processList.Count; i++)
            {
                if (i != processIndex)
                {
                    if (!(processList.ElementAt(i).arrival_time <= timer))
                    {
                        continue;
                    }
                    processList.ElementAt(i).waiting_time++;
                    processList.ElementAt(i).turnaround_time++;
                    Process.total_turnaround_time++;
                    Process.total_waiting_time++;
                }
            }
            if (processList != null && processList.Count > 0 && processIndex < processList.Count && processIndex != -1)
            {
                timeQuantumCount--;
            }
            return Tuple.Create(processList, processIndex);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp17
{
   public class Process: IComparable
    {
     
        
        string[] names = {" main process", "first process", "second pr" ,"proc1z","proc2x","proc45y" };
        private Random rand;        
        public string name;
        public int identifier;        //идентификатор
        public int admission_time;   //время поступления
        public int burst_time;       //интервал  обслуживания
        public int work_on_processor;  //время работы на процессоре
        public int queuing_process;    //время постановки в очередь
        public int waiting_time;       //время ожидания
        public string process_status;
        public int kol_vo;
      
        public Process(int time)
        {
            //создается процесс с параметр-время его создания
            //process = new Process(time);
           
            rand = new Random();
            admission_time = time;
            work_on_processor = 0;
            queuing_process = time;
            waiting_time = 0;
          
        }

        public void set_name()
        {
            name = names[rand.Next(0, names.Length)] + "_"+admission_time.ToString();
        }
        public int CompareTo(object p)
        {
            Process proc = p as Process;
             if ((this.burst_time-this.work_on_processor) > (proc.burst_time-proc.work_on_processor))
                 return 1;
             if ((this.burst_time - this.work_on_processor) < (proc.burst_time - proc.work_on_processor))
                 return -1;
             else
                 return 0;
           
        }
        public int get_burst_time()
        {
            return burst_time;
        }
        public string get_name()
        {
            return name;
        }
        public string get_process_status()
        {
            return process_status;
        }
        public int get_identifier()
        {
            return identifier;
        }
        public int get_admission_time()
        {
            
            return admission_time;
        }
        public int get_work_on_processor()
        {
            return work_on_processor;
        }
        public int get_waiting_time()
        {
            return waiting_time;
        }
        
        public void Next_step()
        {
            work_on_processor = work_on_processor + 1;
           
        }
        public void Next_time()
        {
           waiting_time = waiting_time + 1;

        }
        public bool Ended()
        {

            return burst_time == work_on_processor;
        }
        public void End()
        {

            burst_time = burst_time- work_on_processor;
            
            work_on_processor = 0;
            if (burst_time == 0)
            {
                Random rand = new Random();
                int r = rand.Next(0, 5);

                if (r != 0)
                {

                   burst_time = rand.Next(4, 7);
                    process_status = "ожидающий";
                   
                }
                else
                {
                    process_status = "завершенный";
                   
                }
            }
        }
 
        

    }
}

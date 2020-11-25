using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp17
{
    public class CPU  
    {
        
        public Process act_pr;
        public bool busy_pr; //занят ли процессор
        public CPU()
        {
            busy_pr = false;
           // cpu = new CPU();

        }
        
        public Process active_process
        {
            get { return act_pr; }
        }
        public bool Free()
        {
            if (busy_pr == true)
                return false;
            else
                return true; 
        }
        public void start_pr(Process p)
        {
            busy_pr = true;
            act_pr = p;
        }
        public Process stop_pr()
        {
            busy_pr = false;
            return act_pr;
        }
        //нужно ,чтобы кл процесс тоже выполнил некст степ
        public void Next_step()
        {
            if(act_pr!=null)
            {
               act_pr.work_on_processor = act_pr.work_on_processor + 1;
             
            }
                 //busy_pr = true; 
        }
        public void Clear()
        {
            busy_pr = false;
        }
    }
}

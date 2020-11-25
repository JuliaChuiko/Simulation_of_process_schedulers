using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp17
{
    public class Resource
    {
        
        public bool busy_res;
        public Process activ_pr;
        public Resource()
        {
            busy_res = false;
        }
        public Process active_process
        {
            get { return activ_pr; }
        }
        public bool Free()
        {
            if (busy_res == true)
                return false;
            else
                return true;
        }
        public void start_pr(Process p)
        {
            busy_res = true;
            activ_pr = p;
        }
        public Process stop_pr()
        {
            busy_res = false;
            return activ_pr;
        }
        public void Next_step()
        {
            if (activ_pr != null)
            {
                activ_pr.work_on_processor = activ_pr.work_on_processor + 1;

            }
            
        }
        public void Clear()
        {
            busy_res = false;
        }
    }
}

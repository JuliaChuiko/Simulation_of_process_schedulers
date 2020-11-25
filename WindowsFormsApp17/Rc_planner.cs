using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp17
{
    public class Rc_planner
    {

        public SimpleQ<Process> queue;
        Resource resource;

        public Rc_planner(Resource r, SimpleQ<Process> q)
        {

            resource = r;
            queue = q;


        }
        public void Next_step()
        {
           
            if (!resource.Free() && resource.active_process.Ended())
            {
                resource.active_process.process_status = "готовый";
                resource.stop_pr();

            }
            resource.activ_pr = null;
            if (resource.Free() && !queue.Empty())
            {
                if (queue.Count() > 0)
                {
                    resource.start_pr(queue.Item());
                    queue.Remove();
                }

            }
            


        }
    }
        
    }

            

        
    


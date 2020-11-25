using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp17
{
    public class Planner 
    {
       
        
        CPU cpu;
     
       
        public Piramida<Process> piramida;
       public Planner(CPU centr_rp,Piramida<Process> p)
       {
            cpu = centr_rp;
            piramida = p;
           
            
           
       }
      
       //реализуем алгоритм планирования
        //SJF с вытеснением по оставшемуся времени
       //подумать по оставшемуся времени ,это по берст тайм
        public void Next_Step()
        {
            
            
            if (!cpu.Free() && cpu.active_process.Ended())
            {
               
                cpu.active_process.End();
                
                cpu.stop_pr();
                cpu.act_pr= null;
                cpu.busy_pr = false;
                
                
            }
           
           
           if (cpu.Free() &&  piramida.C()!=0 && piramida.Count()!=0)//!piramida.Empty())
            { 
                    cpu.start_pr(piramida.Item());

                    piramida.Remove_max();
                  
               
            }
            if (!cpu.Free() && piramida.C() != 0 && piramida.Count() != 0 )
            {
                if (cpu.active_process.CompareTo(piramida.Item()) == 1)
                {

                    // cpu.active_process.End();
                    Process p = cpu.active_process;
                    cpu.start_pr(piramida.Item());
                    piramida.Remove_max();
                    piramida.Put(p);
                   

                }
            }
           
            }
          
        
    }
}

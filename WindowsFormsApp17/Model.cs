using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp17
{
    class Model
    {
        //создать какую-то переменную,которой будет будет присваиваться завершенный процесс из цпу
        //или через возвращения процесса от некст степ
        public Piramida<Process> ready_pr;
        public SimpleQ<Process> queue;
        public Planner planner;
        public CPU cpu ;
        public Rc_planner pl;
        public Resource resource;
        public Clock clock;

        public int zadania;       //количество поступивших процессов
        public int kol_vo;        //завершенные процессы
        public int max_length;
        public int takt;            //простой процессора в тактах
        public int srednee_waiting; 
        public int res;             //среднее время ожидания для завершенных процессов
        public int srednee_oborot;
        public int res1;
        int p;
        //порог интенсивности поступления 
        private double intensive;
        //минимальная велич интерв обсл
        private int burst_min;
        //максимальная велич интерв обсл
        private int burst_max;
        private Random rand;
        public Model(double intens,int b_min, int b_max)
        {
            queue = new SimpleQ<Process>();
            ready_pr = new Piramida<Process>();
            clock = new Clock();
            cpu = new CPU();
            resource = new Resource();
            planner = new Planner(cpu, ready_pr);
            rand = new Random();
            pl = new Rc_planner(resource,queue);
            
            intensive = intens;
            burst_min = b_min;
            burst_max = b_max;
            zadania = 0;
            max_length = 0;
            takt = 0;
            p = 0;
            srednee_waiting = 0;
            res = 0;
            srednee_oborot = 0;
            res1 = 0;
        }
        //действия модели на такте работы
        public void Next_time()
        {
            //увеличиваем номер такта
            clock.Next_time();
            //если порог интенсивности не превышен
            if(rand.NextDouble()<intensive)
            {
                    Process new_pr = new Process(clock.get_time());
                    //генерируется интервал обсл процесса процессором
                    new_pr.set_name();
                    new_pr.burst_time = rand.Next(burst_min, burst_max + 1);
                    //помещаем в очередь готовых процессов
  //почему-то некоректно вставляется
  //как сделать сортировку по берст тайм???
                    ready_pr.Put(new_pr);
                    
                if (ready_pr.C() > 0 && ready_pr.C() > max_length)
                {
                    max_length = ready_pr.C();
                }
                zadania++;
                    
                
            }

            
                if (Need_planirovka())
                    {
                
                    Process z_process = cpu.active_process;
                    planner.Next_Step();
                if (z_process == null)
               {
                 takt++;
               }
                    if ((ready_pr.C()==ready_pr.Count())   && ready_pr.C()>max_length )
                     {
                        max_length = ready_pr.C();
                     }  
                     if(z_process!=null && z_process.process_status=="завершенный")
                     {
                        kol_vo++;
                        srednee_waiting += z_process.waiting_time;
                        res = srednee_waiting / kol_vo;
                        srednee_oborot += clock.get_time() - z_process.admission_time;
                        res1 = srednee_oborot / kol_vo;

                    }
                    if (z_process != null && z_process.process_status == "ожидающий")
                    {
                    queue.Put(z_process);

                    }
              
                   
                      
                }
                            
                
                if(Need_pl_2())
                {
                 Process z_process = resource.active_process;
                  pl.Next_step();
                 
                if (z_process != null && z_process.process_status == "готовый")
                {
                  
                    z_process.burst_time = rand.Next(3, 6);
                    z_process.work_on_processor = 0;
                    ready_pr.Put(z_process);
                    if (ready_pr.C() > 0 && ready_pr.C() > max_length)
                    {
                        max_length = ready_pr.C();
                    }
                    zadania++;
                }
                
                  }

            if (cpu.active_process!=null  && ready_pr.Count() != 0)
            {
                p = ready_pr.Count();
                for (int i = 0; i < p; i++)
                {
                    ready_pr.GetQ[i].Next_time();

                }
            }
            else if(cpu.active_process != null && ready_pr.C()==ready_pr.Count() && ready_pr.Count()>0)
            {
                p = ready_pr.Count();
                for (int i = 0; i < p; i++)
                {
                    ready_pr.GetQ[i].Next_time();

                }
            }



            cpu.Next_step();
                    resource.Next_step();
           
            
        }
        public int Get_zadania()
        {
            return zadania;
        }
       //помогательный метод,определяющий
       //нужна ли перепланировка
       private bool Need_planirovka()
       {
       return (cpu.Free() || cpu.active_process.work_on_processor == cpu.active_process.burst_time || cpu.active_process.CompareTo(ready_pr.Item())==1);
            
       }
        private bool Need_pl_2()
        {

            return (resource.Free()&&!queue.Empty() || !resource.Free() && resource.active_process.work_on_processor == resource.active_process.burst_time);
           
        }
       public void Clear()
        {
            clock.Clear();
            ready_pr.Clear();
            cpu.Clear();
        }
        public Clock get_clock
        {
            get {return clock; }
        }
        public CPU Cpu
        {
            get { return cpu; }
        }
        public Planner Planner
        {
            get { return planner; }
        }
        public Piramida<Process> Ready_pr
        {
            get { return ready_pr; }
        }
        public Random Rand
        {
            get { return rand; }
        }
        public int Get_kol_vo()
        {
            return kol_vo;
        }
        public int Get_max_length()
        {
            return max_length;
        }
        public int Get_takt()
        {
            return takt;
        }
        public int Get_srednee_waiting()
        {
            return res;
        }
        public int Get_sum()
        {
            return srednee_waiting;
        }
        public int Get_srednee_oborot()
        {
            return res1;
        }
        public int Get_sum_oborot()
        {
            return srednee_oborot;
        }
    }
}

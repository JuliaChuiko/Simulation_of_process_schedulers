using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp17
{
    public partial class Form2 : Form
    {

        Model model;
       // Statistika statistika;
        private Random r=new Random();
        private double intensive;
        private int burst_min;
        private int burst_max;
        NumericUpDown n = new NumericUpDown();
      
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           /// intensive = 0.3;
            ///burst_min = 2;
            ///burst_max =3;
           //model = new Model(intensive, burst_min, burst_max);
        }
        private void button2_Click_1(object sender, EventArgs e)
        {

           intensive = Convert.ToDouble(numericUpDown1.Value);
            burst_min = Convert.ToInt32(numericUpDown2.Value);
            burst_max = Convert.ToInt32(numericUpDown3.Value);
            model = new Model(intensive, burst_min, burst_max);
            button2.Enabled = false;
        }
         private void button1_Click_1(object sender, EventArgs e)
         {
            
            model.Next_time();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            if (!model.cpu.Free())
            {
                listBox2.Items.Add(model.cpu.active_process.name);
                listBox2.Items.Add(model.cpu.active_process.burst_time);
                listBox2.Items.Add(model.cpu.active_process.work_on_processor);
                listBox2.Items.Add("w " + model.cpu.active_process.waiting_time.ToString());
              
            }
            if(!model.resource.Free())
            {
                listBox4.Items.Add(model.resource.active_process.name);
                listBox4.Items.Add(model.resource.active_process.burst_time);
                listBox4.Items.Add(model.resource.active_process.work_on_processor);
                listBox4.Items.Add("w " + model.resource.active_process.waiting_time.ToString());
            }
            //listBox2.Items.Add(model.cpu.active_process.ToString());

            try
            {

                for (int i = 0; i < model.Ready_pr.Count(); i++)
                {
                    listBox1.Items.Add(model.Ready_pr.GetQ[i].name);
                    listBox1.Items.Add(model.Ready_pr.GetQ[i].burst_time.ToString() + " " + model.Ready_pr.GetQ[i].work_on_processor.ToString()+ " w " +model.Ready_pr.GetQ[i].waiting_time.ToString());
                    
                }
                for(int i=0; i<model.queue.Count(); i++)
                {
                    listBox3.Items.Add(model.queue.GetQ[i].name);
                    listBox3.Items.Add(model.queue.GetQ[i].burst_time.ToString() + " " + model.queue.GetQ[i].work_on_processor.ToString() + " w " + model.queue.GetQ[i].waiting_time.ToString());
                }
                label15.Text = Convert.ToString(model.clock.get_time());
            }
            catch
            {
                MessageBox.Show("Поле не заполнено");
            }
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox5.Items.Clear();
            listBox5.Items.Add("Количество поступивших процессов -  " + model.Get_zadania().ToString());
            listBox5.Items.Add("Завершенные процессы -  " + model.Get_kol_vo().ToString());
            listBox5.Items.Add("Макс длина очереди к ЦП - " + model.Get_max_length().ToString());
            listBox5.Items.Add("Такт простоя процессора - " + model.Get_takt().ToString());
            listBox5.Items.Add("среднее время ожидания заверш. пр.  - " + model.Get_srednee_waiting().ToString());
            listBox5.Items.Add("суммарное ожидание заверш. процессов- " + model.Get_sum().ToString());
            listBox5.Items.Add("среднее время оборота для заверш. пр.- " + model.Get_srednee_oborot().ToString());
            listBox5.Items.Add("суммарный оборот заверш. пр. - " + model.Get_sum_oborot().ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Close();
           
        }
    }
}


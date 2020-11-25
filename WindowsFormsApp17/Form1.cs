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
    public partial class Form1 : Form
    {
        Piramida<int> q = new Piramida<int>();
        //Model<int> m = new Model<int>();
       // List<int> y = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (Char.IsLetter(c) || Char.IsPunctuation(c)) e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            listBox1.Items.Clear();
            try
            {

                 int k = Convert.ToInt32(textBox1.Text);
                    q.Put(k);
               
               
                for (int i = 0; i < q.Count(); i++)
                {
                   
                    listBox1.Items.Add(q.GetQ[i]);
                }

            }
            catch
            {
                MessageBox.Show("Поле не заполнено");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(q.Count()==0)
            {
                MessageBox.Show("Элементов больше нет");
                // q = new Piramida<int>();
                q = new Piramida<int>();
            }
            try
            {
               
                    q.Remove_max();
              
                   listBox1.Items.Clear();
                   for(int i=0; i<q.Count(); i++)
                   {
                    
                        listBox1.Items.Add(q.GetQ[i]);
                   }
                 
         
            }
            catch
            {
               
                label2.Text =Convert.ToString(0);
            }
               
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
                label2.Text = Convert.ToString(q.Count());
               
        }

        private void button4_Click(object sender, EventArgs e)
        {
                while(q.Count()>0)
             {
                
                q.Clear();
                listBox1.Items.Clear();

             }
            q = new Piramida<int>();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }
    }
}

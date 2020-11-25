using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp17
{
    class Clock
    {
        private int current_time;
        public Clock()
        {
            current_time = 0;

        }
        public void Next_time()
        {
            current_time = current_time + 1;
        }
        public int get_time()
        {
            return current_time;
        }
        public void Clear()
        {
            current_time = 0;
        }

    }
}

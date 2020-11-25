using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp17
{
   public  class SimpleQ<T>
    {
        private List<T> queue; //лист это сылочный тип
        public List<T> GetQ { get { return queue; } }
        public SimpleQ()
        {
            //создается пустая очередь
            queue = new List<T>();
        }
        public void Put(T e) //добавляем новый элемент в очередь
        {
            queue.Add(e);
        }
        public void Remove()
        {
            if (queue.Count == 0)
                throw new Exception("Queue Empty");
            queue.RemoveAt(0);
        }
        public T Item()   //поиск верхнего
        {
            if (queue.Count == 0)
                throw new Exception("Queue Empty");
            return queue[0];
        }
        public bool Empty()
        {
            return queue.Count == 0;
        }
        public int Count()
        {
            return queue.Count();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp17
{
    public class Piramida<T> where T : IComparable
    {
        private List<T> body;
        public List<T> GetQ { get { return body; } }
        T data { get; set; }
        int Heap_size;
        public Piramida()
        {
            body = new List<T>();
            Heap_size = 0;
        }
       
        public int Parent(int i)
        {
            return (i - 1) / 2;
        }
        public int Left(int i)
        {
            return (2 * i + 1);
        }
        public int Right(int i)
        {
            return (2 * i + 2);
        }
        public bool Empty()
        {
            return body.Count == 0;
        }
        public int Count()
        {
            return Heap_size;
        }
        public int C()
        {
            return body.Count();
        }
        public void shift_up()
        {
            int i = Heap_size - 1;

            while (i != 0)
            {
                if (body[i].CompareTo(body[(i-1) / 2]) < 0)
                {
                    T r;
                    r = body[i];
                    body[i] = body[(i - 1) / 2];

                    body[(i - 1) / 2] = r;
                   
                }
                 i = (i - 1) / 2;
            }
        }
        public void shift_down()
        {
            int i = 0;
            int l;
            int r;
            int j = i;
            while (2 * i + 1 < Heap_size )
            {

                    l = 2 * i + 1;
                    r = 2 * i + 2;
                int max;
                    if(l>Heap_size-1)
                        {
                            break;
                        }
                    if(r>Heap_size-1)
                     {
                    max = l;
                      }
                    else if ( body[l].CompareTo(body[r]) < 0)
                    {
                        max = l;
                    }
                     else max = r;
                    if ( body[i].CompareTo(body[max]) > 0)
                    {
                    T e;
                    e = body[i];
                    body[i] = body[max];
                    body[max] = e;
                     
                    }
                   i = max;
                    
                }

            }

        
        public void Put(T data)
        {
            if(Heap_size<body.Count)
            {
                body[Heap_size] = data;
                
            }
            else
            {
                body.Add(data);
               
            }
                Heap_size = Heap_size + 1;
                shift_up();

        }
        public void Clear()
        {
            while (Heap_size > 0)
            {
                Remove_max();
            }
        }
        public void Remove_max()
        {
            
           
            int i = Heap_size - 1;
            body[0] = body[i];
            Heap_size = Heap_size - 1;
            shift_down();
           
        }
        
        public T Item()
        {
            if (body.Count == 0)
                throw new Exception("Queue Empty");
            return body[0];
        }
        
       
        public class QueueException : Exception
        {
            public QueueException() : base() { }

            public QueueException(String msg) : base(msg) { }
        }
    }
}

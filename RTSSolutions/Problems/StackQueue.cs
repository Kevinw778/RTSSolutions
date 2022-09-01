using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTSSolutions.Problems
{
    public class StackQueue<T>
    {
        private Stack<T> one = new();
        private Stack<T> two = new();

        public void Enqueue(T value)
        {
            two.Push(value);
        }

        public T DeQueue()
        {
            if (one.Count > 0)
            {
                return one.Pop();
            }
            else
            {
                MoveStack();
                return one.Pop();
            }
        }

        private void MoveStack()
        {
            while (two.Count > 0)
            {
                one.Push(two.Pop());
            }
        }

        public T Peek()
        {
            if (one.Count == 0)
                MoveStack();
            return one.Peek();
        }

        public void Print()
        {
            Console.WriteLine(Peek());
        }
    }
}

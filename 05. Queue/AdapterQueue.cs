using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05._Queue
{
    /******************************************************
	 * 어댑터 패턴 (Adapter)
	 * 
	 * 한 클래스의 인터페이스를 사용하고자 하는 다른 인터페이스로 변환
	 ******************************************************/

    internal class AdapterQueue<T>
    {
        private LinkedList<T> container;

        public AdapterQueue()
        {
            container = new LinkedList<T>();
        }

        public void EnQueue(T item)
        {
            container.AddLast(item);
        }

        public T DeQueue()
        {
            T item = container.First.Value;
            container.RemoveFirst();
            return item;
        }

        public T Peek()
        {
            return container.First.Value;
        }
    }
}

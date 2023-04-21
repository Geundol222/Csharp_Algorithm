using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    /*
     * 어댑터 패턴을 이용하여 Queue를 구현하게 될 경우 Stack과 동일하게 꽤나 간단하게 Queue를 구현해 줄 수 있다.
     * 하지만 C#의 경우 노드 기반의 자료구조들은 GC의 존재로 인해 잘 사용되지 않고 있으며 LinkedList로 구현하게 되는 Queue의 경우 GC에 부담이 될 수 있다는 리스크가 있다. 
     * 따라서 Queue의 경우는 직접 구현하는 방법이 더 좋다.
     * 실제로 기술면접에서도 Queue의 구현이 Stack 보다는 많이 나오는 편(C#)
     * 선형 자료구조의 특성 때문에 Queue에서 데이터를 꺼내오는 작업은 자원이 많이 들게 된다.
     * 따라서 Queue에서는 자료를 꺼내면 인덱스들을 앞으로 당겨오지 않고 가르키고 있는 대상을 다음 인덱스로 옮겨서 가장 앞에있는 값이 될 수 있게 한다.
     * 또한 가장 뒤를 가르키는 back도 가지고 있으며, 만약에 데이터를 어느정도 꺼낸 후 데이터를 추가할 경우 back이 맨 앞으로 가서 데이터들을 채운다.
     * 말로는 어렵...
     * Queue에서 사용하는 배열을 원형(환형) 배열이라고 하며, 각 인덱스를 순환하면서 데이터를 채우고 꺼내오고를 진행한다.
     * 만약 전단과 후단이 서로 같은 곳을 바라보고 있는 경우 그 배열이 비어있는 배열인지 꽉 차있는 배열인지를 판단하기 어렵게된다.
     * 그렇기 때문에 만약 배열이 꽉 차게 될 경우 배열의 크기를 하나 늘려주어 후단이 늘어난 배열의 칸을 가르키게 만들어준다.
     * 그렇게 후단이 전단의 바로 뒤에 오게 되면 컴퓨터가 이 배열은 꽉 찼다라고 확인할 수 있게 해준다.
     * 전단은 가장 앞을 가르키며 빼야할 데이터를 가르키게 되고, 후단은 데이터를 추가할 빈 인덱스를 가르키게 된다.
     */
    internal class Queue<T>
    {
        private const int DefaultCapacity = 4;

        private T[] array;
        private int head;
        private int tail;

        public Queue()
        {
            array = new T[DefaultCapacity + 1];
            head = 0;
            tail = 0;
        }

        public void Enqueue(T item)
        {
            array[tail] = item;
            MoveNext(ref tail);
        }

        private void MoveNext(ref int index)
        {
            index = (index == array.Length - 1) ? 0 : index + 1;
        }

        public T Dequeue()
        {
            T result = array[head];
            MoveNext(ref head);
            return result;
        }

        public T Peek()
        {
            return array[head];
        }

        private bool IsEmpty()
        {
            return head == tail;
        }

        private bool IsFull()
        {
            if (head > tail)
                return head == tail + 1;
            else
                return head == 0 && tail == array.Length - 1;
        }
    }
}

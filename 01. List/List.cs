using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    internal class List<T>
    {
        private const int DefaultCapacity = 10;

        private T[] items;
        private int size;

        public List()
        {
            this.items = new T[DefaultCapacity];
            this.size = 0;
        }

        public int Count { get { return size; } }
        public int Capacity { get { return items.Length; } }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();

                return items[index];
            }
            set
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();

                items[index] = value;
            }
        }

        public void Add(T item)
        {
            if (size < items.Length)
            {
                items[size++] = item;
            }
            else
            {
                Grow();
                items[size++] = item;
            }
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                // 인덱스를 찾은 경우
                RemoveAt(index);
                return true;
            }
            else
            {
                // 인덱스를 못찾은 경우
                return false;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();

            size--;
            Array.Copy(items, index + 1, items, index, size - index);
        }

        public int IndexOf(T item)
        {
            /*
            for (int i = 0; i < size; i++)
            {
                if (item == items[i])
                    return i;
            }
            return -1;
            */

            return Array.IndexOf(items, item, 0, size);
        }

        public T? Find(Predicate<T> match)      // Predicate : 반환형이 bool인 일반화된 델리게이트
        {
            if (match == null)
                throw new ArgumentNullException("match");

            for (int i = 0; i < size; i++)
            {
                if (match(items[i]))
                    return items[i];
            }

            return default(T);
        }

        public int FindIndex(Predicate<T> match)
        {
            for (int i = 0; i < size; i++)
            {
                if (match(items[i]))
                    return i;
            }

            return -1;
        }

        private void Grow()     // List 배열에 Capacity가 다 찼을 경우 새로운 값을 집어넣을 때 호출될 함수
        {
            int newCapacity = items.Length * 2;         // items 길이의 2배만큼의 길이를 생성
            T[] newItems = new T[newCapacity];          // newCapacity의 크기를 가지는 newItems 배열 선언
            Array.Copy(items, 0, newItems, 0, size);    // items의 내용들을 newItems배열에 복사한다.
            items = newItems;                           // items를 newItems로 교체하여 힙 영역에서 items를 해제한다
        }
    }
}

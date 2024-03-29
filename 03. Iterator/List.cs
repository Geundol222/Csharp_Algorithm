﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    internal class List<T> : IEnumerable<T>
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

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<T>
        {
            private List<T> list;
            private int index;
            private T current;

            public T Current { get { return current; } }

            public Enumerator(List<T> list)
            {
                this.list = list;
                this.index = 0;
                this.current = default(T);
            }

            object IEnumerator.Current { get { return current; } }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (index < list.Count)
                {
                    current = list[index++];        // index가 0부터 시작하기 때문에, 인덱스값을 주고 1을 증가시키기 위해 후위증가연산자를 사용한다.
                    return true;                    // 만약 전위중가연산자를 사용할 경우 먼저 index값이 1을 추가하고 반환하기 때문에 후위증가연산자를 사용하는 것이 적합하다.
                }                                   // 단, 이는 current의 Default를 앞에 두느냐 뒤에 두느냐에 따라 조금 다른데, 만약 default를 배열 앞에 두는 경우
                else                                // 
                {
                    current = default(T);
                    return false;
                }                
            }

            public void Reset()
            {
                index = 0;
                current = default(T);
            }
        }
    }
}

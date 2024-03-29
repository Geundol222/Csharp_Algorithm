﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    public class LinkedListNode<T>
    {
        internal LinkedList<T> list;
        internal LinkedListNode<T> prev;
        internal LinkedListNode<T> next;
        private T item;

        public LinkedListNode(T value)
        {
            this.list = null;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        public LinkedListNode(LinkedList<T> list, T value)
        {
            this.list = list;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        public LinkedListNode(LinkedList<T> list, LinkedListNode<T> prev, LinkedListNode<T> next, T value)
        {
            this.list = list;
            this.prev = prev;
            this.next = next;
            this.item = value;
        }

        public LinkedList<T> List { get { return list; } }
        public LinkedListNode<T> Prev { get { return prev; } }
        public LinkedListNode<T> Next { get { return next; } }
        public T Value { get { return item; } set { item = value; } }
    }

    public class LinkedList<T> : IEnumerable<T>
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;
        private int count;

        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public LinkedListNode<T> First { get { return head; } }
        public LinkedListNode<T> Last { get { return tail; } }
        public int Count { get { return count; } }

        public LinkedListNode<T> AddFirst(T value)
        {
            // 1. 새로운 노드 생성
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            // 2. 연결구조 바꾸기
            if (head != null)
            {
                // 2-1. Head 노드가 있을 경우
                newNode.next = head;
                head.prev = newNode;
                head = newNode; // 3. 새로운 노드를 head노드로 지정
            }
            else    // 2-2. head 노드가 없을 경우
            {
                head = newNode;
                tail = newNode;
            }
            count++;

            return newNode;
        }

        public LinkedListNode<T> AddLast(T value)
        {
            LinkedListNode<T> lastNode = new LinkedListNode<T>(this, value);

            if (tail != null)
            {
                lastNode.prev = tail;
                tail.next = lastNode;
                tail = lastNode;
            }
            else
            {
                head = lastNode;
                tail = lastNode;
            }
            count++;

            return lastNode;
        }

        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            if (node.list != this)
                throw new InvalidOperationException();
            if (node == null || newNode == null)
                throw new ArgumentNullException();

            if (node == tail)
            {
                newNode = AddLast(value);
            }
            else
            {
                newNode.next = node.next;
                newNode.prev = node;
                node.next.prev = newNode;
                node.next = newNode;
            }
            count++;

            return newNode;
        }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            if (node.list != this)
                throw new InvalidOperationException();
            if (node == null || newNode == null)
                throw new ArgumentNullException();

            if (node == head)
            {
                newNode = AddFirst(value);
            }
            else
            {
                newNode.prev = node.prev;
                newNode.next = node;
                node.prev.next = newNode;
                node.prev = newNode;
            }
            count++;

            return newNode;
        }

        public void Remove(LinkedListNode<T> node)
        {
            if (node.list != this)
                throw new InvalidOperationException();
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            // 0. 지웠을 때 head나 tail이 변경되는 경우
            if (head == node)
                head = node.next;
            if (tail == node)
                tail = node.prev;

            // 1. 연결구조 바꾸기
            if (node.prev != null)
                node.prev.next = node.next;
            if (node.next != null)
                node.next.prev = node.prev;

            // 2. 갯수 줄이기
            count--;
        }

        public bool Remove(T value)
        {
            LinkedListNode<T> findNode = Find(value);
            if (findNode != null)
            {
                Remove(findNode);
                return true;
            }
            else
            {
                return false;
            }
        }

        public LinkedListNode<T> Find(T value)
        {
            LinkedListNode<T> target = head;
            EqualityComparer<T> compare = EqualityComparer<T>.Default;

            while (target != null)
            {
                if (compare.Equals(target.Value, value))
                    return target;
                else
                    target = target.next;
            }

            return null;
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
            private LinkedList<T> linkedList;
            private LinkedListNode<T> node;
            private T current;

            public Enumerator (LinkedList<T> linkedList)
            {
                this.linkedList = linkedList;
                this.node = linkedList.head;
                this.current = default(T);
            }

            public T Current { get { return current; } }

            object IEnumerator.Current { get { return current; } }

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                if (node != null)
                {
                    current = node.Value;
                    node = node.next;
                    return true;
                }
                else
                {
                    current = default(T);
                    return false;
                }
            }

            public void Reset()
            {
                node = linkedList.head;
                current = default(T);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Dictionary<TKey, TValue> where TKey : IEquatable<TKey>     // Key는 비교가능해야하므로 IEquatable 인터페이스 사용
    {
        private const int DefaultCapacity = 1000;

        private struct Entry
        {
            public enum State { None, Using, Deleted }

            public State state;
            public int hashCode;
            public TKey key;
            public TValue value;
        }

        private Entry[] table;

        public Dictionary()
        {
            table = new Entry[DefaultCapacity];
        }

        public TValue this[TKey key]
        {
            get
            {
                // 1. key를 index로 해싱
                int index = Math.Abs(key.GetHashCode() % table.Length);     // Math.Abs : 절대값

                // 2. key가 일치하는 데이터가 나올때까지 다음으로 이동
                while (table[index].state == Entry.State.Using)
                {
                    // 3. 동일한 키값을 찾았을때 반환하기
                    if (key.Equals(table[index].key))
                    {
                        return table[index].value;
                    }
                    if (table[index].state == Entry.State.None)
                        break;

                    index = index < table.Length ? index + 1 : 0;   // 선형탐사, index * index : 제곱탐사, Math.Abs(key.GetHashCode() : 이중해싱
                }

                throw new InvalidOperationException();
            }

            set
            {
                // 1. key를 index로 해싱
                int index = Math.Abs(key.GetHashCode() % table.Length);     // Math.Abs : 절대값

                // 2. key가 일치하는 데이터가 나올때까지 다음으로 이동
                while (table[index].state == Entry.State.Using)
                {
                    // 3. 동일한 키값을 찾았을 때 해당 데이터로 덮어쓰기
                    if (key.Equals(table[index].key))
                    {                        
                        table[index].value = value;
                        return;
                    }
                    if (table[index].state == Entry.State.None)
                        break;

                    index = index < table.Length ? index + 1 : 0;   // 선형탐사, index * index : 제곱탐사, Math.Abs(key.GetHashCode() : 이중해싱
                }
            }
        }


        public void Add(TKey key, TValue value)
        {
            // 1. key를 index로 해싱
            int index = Math.Abs(key.GetHashCode() % table.Length);     // Math.Abs : 절대값

            // 충돌을 고려하지 않았을 경우
            // table[index].key = key;
            // table[index].value = value;

            // 2. 사용중이 아닌 index까지 다음으로 이동
            while (table[index].state == Entry.State.Using)
            {
                if (key.Equals(table[index].key))
                {
                    throw new ArgumentException();              // C#에서는 중복된 키값을 허용해주지 않음 예외 발생
                }
                index = index < table.Length ? index + 1 : 0;   // 선형탐사, index * index : 제곱탐사, Math.Abs(key.GetHashCode() : 이중해싱

            }

            // 3. 사용중이 아닌 index를 발견한 경우 그 위치에 저장
            table[index].hashCode = key.GetHashCode();
            table[index].key = key;
            table[index].value = value;
            table[index].state = Entry.State.Using;
        }

        public void Remove(TKey key)
        {
            // 1. key를 index로 해싱
            int index = Math.Abs(key.GetHashCode() % table.Length);

            // 2. key값과 동일한 데이터를 찾을때까지 index 증가
            while (table[index].state == Entry.State.Using)
            {
                if (key.Equals(table[index].key))
                {
                    table[index].state = Entry.State.Deleted;
                }
                if (table[index].state == Entry.State.None)
                    break;

                index = index < table.Length ? index + 1 : 0;

            }
            throw new InvalidOperationException();
        }
    }
}

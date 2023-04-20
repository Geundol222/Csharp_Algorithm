namespace _03._Iterator
{
    internal class Program
    {
        /******************************************************
		 * 반복기 (Enumerator(Iterator))
		 * 
		 * 자료구조에 저장되어 있는 요소들을 순회하는 인터페이스
		 * 자료구조에 자료를 담는 구조는 다 다르다.
		 * 하지만, 탐색의 경우 반복을 통해 자료구조 안의 요소들을 하나씩 돌면서 처리하는 구조일 경우,
		 * 해당 자료구조의 내부 구조를 알지 못하더라도 반복기를 지원하기 때문에 반복기를 이용하여 자료구조 내부의 자료를 꺼내오기 수월하다.
		 * 반복기의 실행중 배열이나 리스트의 값이 달라지게 되는경우, 선형자료구조의 특성상 새로운 배열을 생성하여 값을 복사하고 넘기는 식으로 진행되는데
		 * 이때 반복기는 더이상 반복할만한 것이 없어지게 되므로 반복기가 터지게 된다.
		 * 따라서 새로운 배열을 생성하거나 값을 추가 삭제 할 경우 새로운 반복기를 따로 할당해 주어야 한다.
		 ******************************************************/

        void Iterator()
        {
            // 대부분의 자료구조가 반복기를 지원함
            // 반복기를 이용한 기능을 구현할 경우, 그 기능은 대부분의 자료구조를 호환할 수 있음
            List<int> list = new List<int>();
            LinkedList<int> linkedList = new LinkedList<int>();
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();
            SortedList<int, int> sList = new SortedList<int, int>();
            SortedSet<int> set = new SortedSet<int>();
            SortedDictionary<int, int> map = new SortedDictionary<int, int>();
            Dictionary<int, int> dic = new Dictionary<int, int>();

            // 반복기를 이용한 순회
            // foreach 반복문은 데이터집합의 반복기를 통해서 단계별로 반복
            // 즉, 반복기가 있다면 foreach 반복문으로 순회 가능
            foreach (int i in list) { }
            foreach (int i in linkedList) { }
            foreach (int i in stack) { }
            foreach (int i in queue) { }
            foreach (int i in set) { }
            foreach (KeyValuePair<int, int> i in sList) { }
            foreach (KeyValuePair<int, int> i in map) { }
            foreach (KeyValuePair<int, int> i in dic) { }
            foreach (int i in IterFunc()) { }

            // 반복기 직접조작
            List<string> strings = new List<string>();
            for (int i = 0; i < 5; i++) strings.Add(string.Format($"{i}데이터"));

            IEnumerator<string> iter = strings.GetEnumerator();
            iter.MoveNext();
            Console.WriteLine(iter.Current);    // output : 0데이터
            iter.MoveNext();
            Console.WriteLine(iter.Current);    // output : 1데이터

            iter.Reset();
            while (iter.MoveNext())
            {
                Console.WriteLine(iter.Current);
            }
        }

        public void Find(IEnumerable<int> container)
        {
            IEnumerator<int> iter = container.GetEnumerator();

            iter.Reset();
            while(iter.MoveNext())
            {
                if (iter.Current == 10)
                {
                    Console.WriteLine("10을 찾음");
                }
            }
        }

        IEnumerable<int> IterFunc()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }

        static void Main(string[] args)
        {
            Iterator.List<int> list = new Iterator.List<int>();
            for (int i = 1; i <= 5; i++) list.Add(i);

            foreach (int i in list)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();
            Console.WriteLine();

            IEnumerator<int> iter = list.GetEnumerator();
            Console.WriteLine(iter.Current);        // output : 0 => 배열의 범위를 넘어선 범위를 출력할 경우 default(int)인 0을 출력하게 된다.
            while (iter.MoveNext())
            {
                Console.WriteLine(iter.Current);    // output : 1, 2, 3, 4, 5
            }
            Console.WriteLine(iter.Current);        // output : 0
        }
    }
}
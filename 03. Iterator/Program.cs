namespace _03._Iterator
{
    internal class Program
    {
        /******************************************************
		 * 반복기 (Enumerator(Iterator))
		 * 
		 * 자료구조에 저장되어 있는 요소들을 순회하는 인터페이스
		 ******************************************************/


        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            LinkedList<int> linkedList = new LinkedList<int>();

            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();
            SortedList<int, int> sList = new SortedList<int, int>();
            SortedSet<int> set = new SortedSet<int>();
            SortedDictionary<int, int> map = new SortedDictionary<int, int>();
            Dictionary<int, int> dic = new Dictionary<int, int>();

            for (int i = 1; i <= 5; i++)
            {
                list.Add(i);
                linkedList.AddLast(i);
            }

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            // LinkedList는 인덱스의 개념이 없으므로 다음과 같이 작성하게 되면 오류 발생
            //for (int i = 0; i < linkedList.Count; i++)
            //{
                //Console.WriteLine(linkedList[i]);
            //}

            LinkedListNode<int> node = linkedList.First;
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
        }
    }
}
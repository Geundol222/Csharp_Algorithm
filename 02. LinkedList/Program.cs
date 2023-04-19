namespace _02._LinkedList
{
    internal class Program
    {
        /******************************************************
		 * 연결리스트 (Linked List)
		 * 
		 * 데이터를 포함하는 노드들을 연결식으로 만든 자료구조
		 * 노드는 데이터와 이전/다음 노드 객체를 참조하고 있음
		 * 노드가 메모리에 연속적으로 배치되지 않고 이전/다음노드의 위치를 확인
		 * 배열 기반의 자료구조가 아니기 때문에 인덱스 개념이 없으며, 접근에 있어서 인덱스로 바로 접근 가능한 선형 자료구조와는 달리 접근에 시간복잡도에서 불리하다.
		 * 하지만, 연속적인 데이터가 아니므로 중간의 것을 지우거나 중간에 삽입하는데에 제약이 없으므로 매우 효율적이다.
		 ******************************************************/

        /* <연결리스트의 종류>
         * 1. 단방향 LinkedList : 참조용 데이터가 하나 적으므로 데이터를 아낄 수 있으며, 역방향이 굳이 필요없다면 사용
         * 2. 양방향 LinkedList : 이전 데이터도 참조하고 있으므로 여러 작업이 가능해지지만, 양방향을 참조하므로 데이터 양이 많아질 수록 비효율 적이다.
         * 3. 원형(환형) LinkedList : C#에서 쓰이는 LinkedList 맨 마지막데이터는 맨 처음 데이터를 참조하고 맨 처음 데이터의 Prev는 맨 마지막 데이터를 참조한다.
         */

        // <링크드리스트 사용>
        void LinkedList()
        {
            LinkedList<string> linkedList = new LinkedList<string>();

            // 링크드리스트 요소 삽입
            linkedList.AddFirst("0번 앞데이터");
            linkedList.AddFirst("1번 앞데이터");
            linkedList.AddLast("0번 뒤데이터");
            linkedList.AddLast("1번 뒤데이터");

            // 링크드리스트 요소 삭제 : O(n)
            linkedList.Remove("1번 앞데이터");

            // 링크드리스트 요소 탐색
            LinkedListNode<string> findNode = linkedList.Find("0번 뒤데이터");

            // 링크드리스트 노드를 통한 노드 참조
            LinkedListNode<string> prevNode = findNode.Previous;
            LinkedListNode<string> nextNode = findNode.Next;

            // 링크드리스트 노드를 통한 노드 삽입
            linkedList.AddBefore(findNode, "찾은노드 앞데이터");
            linkedList.AddAfter(findNode, "찾은노드 뒤데이터");

            // 링크드리스트 노드를 통한 삭제 : O(1)
            linkedList.Remove(findNode);
        }

        // <LinkedList의 시간복잡도>
        // 접근		탐색	삽입	삭제
        // O(n)		O(n)	O(1)	O(1)

        static void Main(string[] args)
        {
            DataStructure.LinkedList<int> linkedList = new DataStructure.LinkedList<int>();

            linkedList.AddLast(0);
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);
        }
    }
}

namespace _06._Heap
{
    internal class Program
    {
        /******************************************************
		 * 힙 (Heap) => Heap 영역과 전혀 다른 것, 아예 공통분모 조차 없으므로 주의
		 * 
		 * 부모 노드가 항상 자식노드보다 우선순위가 높은 속성을 만족하는 트리기반의 자료구조(이진트리)
		 * 많은 자료 중 우선순위가 가장 높은 요소를 빠르게 가져오기 위해 사용
		 * 
		 * <트리기반 자료구조의 조건>
		 *  1. 부모는 여러개의 자식을 둘 수 있다. => 자식을 안 둘수도 있음
		 *  2. 역순 X (자식이 부모를 가질 수 없다.) => 순환구조가 아니어야한다. (순환구조라면 그래프라고 한다.)
		 *  3. 그 중에서도 부모가 최대 두개의 자식을 가질 수 있는 경우를 이진트리라고 한다.
		 *  4. 최대 6개의 자식을 가지면 헥사트리, 8개의 자식을 가지면 옥타트리라고 한다.
		 *  5. 배열이나 리스트처럼 선형자료구조가 아닌, 비 선형자료구조이다.(트리 or 그래프)
		 ******************************************************/

        static void PriorityQueue()
        {
            // 앞의 자료형은 실질적으로 저장되는 값의 자료형 뒤의 자료형은 비교연산이 가능한 자료형으로 우선순위를 판단하기 위한 Key로 사용한다.
            PriorityQueue<string, int> acsendingPQ = new PriorityQueue<string, int>();

            acsendingPQ.Enqueue("감자", 3);
            acsendingPQ.Enqueue("양파", 5);
            acsendingPQ.Enqueue("당근", 1);
            acsendingPQ.Enqueue("토마토", 2);
            acsendingPQ.Enqueue("마늘", 4);

            while (acsendingPQ.Count > 0)
            {
                Console.WriteLine(acsendingPQ.Dequeue());        // 우선순위가 높은 순서대로 데이터 출력 (오름차순)
            }

            Console.WriteLine();

            PriorityQueue<string, int> desendingPQ 
                = new PriorityQueue<string, int>(Comparer<int>.Create((a, b) => b - a));

            desendingPQ.Enqueue("왼쪽", 70);
            desendingPQ.Enqueue("위쪽", 100);
            desendingPQ.Enqueue("오른쪽", 10);
            desendingPQ.Enqueue("아래쪽", 20);

            string nextDir = desendingPQ.Dequeue();
            Console.WriteLine(nextDir);
            desendingPQ.Clear();
        }

        static void Main(string[] args)
        {
            PriorityQueue();
        }
    }
}
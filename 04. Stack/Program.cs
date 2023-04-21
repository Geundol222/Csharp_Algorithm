namespace _04._Stack
{
    internal class Program
    {
        /******************************************************
		 * 스택 (Stack)
		 * 
		 * 선입후출(FILO), 후입선출(LIFO) 방식의 자료구조
		 * 가장 최신 입력된 순서대로 처리해야 하는 상황에 이용
		 * 뒤로가기 기능이나, 순차적 스킬트리를 구성하는 경우 사용할 수있다.
		 * 시간복잡도에 의해 사용한다기 보다는 역할로 인해 사용하는 기능이다.
		 * 
		 * 스택 vs 큐(Queue)
		 * 큐는 선입선출(FIFO) 구조 스택은 박스형태이지만, 큐는 파이프형태라고 생각하면 됨
		 * 큐는 대표적으로 대기열이나 진행 순서를 처리할 때 사용한다.
		 ******************************************************/

        static void Test()
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < 10; i++) stack.Push(i);         // 0 1 2 3 4 5 6 7 8 9

            Console.WriteLine(stack.Peek());                    // 들어간 데이터 중 최상단 값 확인 : 9

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());                 // 9 8 7 6 5 4 3 2 1 0 
            }
        }

        static void Main(string[] args)
        {
            Test();
        }
    }
}
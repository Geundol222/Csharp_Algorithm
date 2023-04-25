namespace _07._BinarySearchTree
{
    internal class Program
    {
        /******************************************************
		 * 트리 (Tree)
		 * 
		 * 계층적인 자료를 나타내는데 자주 사용되는 자료구조
		 * 부모노드가 0개 이상의 자식노드들을 가질 수 있음
		 * 한 노드에서 출발하여 다시 자기 자신의 노드로 돌아오는 순환구조를 가질 수 없음
		 ******************************************************/

        /******************************************************
		 * 이진탐색트리 (BinarySearchTree)
		 * 
		 * 이진속성과 탐색속성을 적용한 트리
		 * 이진탐색을 통한 탐색영역을 절반으로 줄여가며 탐색 가능
		 * 이진 : 부모노드는 최대 2개의 자식노드들을 가질 수 있음
		 * 탐색 : 자신의 노드보다 작은 값들은 왼쪽, 큰 값들은 오른쪽에 위치 (L < 부모 < R)
		 ******************************************************/

        // <이진탐색트리의 시간복잡도>
        //  접근		  탐색	      삽입		  삭제
        // O(log n)		O(log n)	O(log n)	O(log n)

        // <이진탐색트리의 주의점>
        // 이진탐색트리의 노드들이 한쪽 자식으로만 추가되는 불균형 발생 가능
        // 이 경우 탐색영역이 절반으로 줄여지지 않기 때문에 시간복잡도 증가
        // 이러한 현상을 막기 위해 자가균형기능을 추가한 트리의 사용이 일반적
        // 대표적인 방식으로 Red-Black Tree, AVL Tree 등이 있음
        // 위 방식은 불균형이 일어난 노드의 균형을 맞추기 위해 사용하는 것, 알아만 두자

        // <트리기반 자료구조의 순회>
        // 1. 전위 순회 : 노드, 왼쪽, 오른쪽 
        // 2. 중위 순회 : 왼쪽, 노드, 오른쪽       <= 이진탐색트리의 순회 : 오름차순 정렬
        // 3. 후위 순회 : 왼쪽, 오른쪽, 노드

        void BinarySearchTree()
        {
            // 키 == 데이터
            SortedSet<int> sortedSet = new SortedSet<int>();

            // 추가
            sortedSet.Add(1);
            sortedSet.Add(2);
            sortedSet.Add(3);
            sortedSet.Add(4);
            sortedSet.Add(5);

            // 탐색
            int searchValue1;
            bool find = sortedSet.TryGetValue(3, out searchValue1); // 탐색시도

            // 삭제
            sortedSet.Remove(3);

            // 탐색용 키, 실제 데이터 (앞의 자료형이 키)
            SortedDictionary<string, Monster> sortedDic = new SortedDictionary<string, Monster>();

            sortedDic.Add("피카츄", new Monster() { name = "피카츄", hp = 100 });
            sortedDic.Add("파이리", new Monster() { name = "파이리", hp = 120 });
            sortedDic.Add("꼬부기", new Monster() { name = "꼬부기", hp = 80 });
            sortedDic.Add("리아코", new Monster() { name = "리아코", hp = 110 });
            sortedDic.Add("이상해씨", new Monster() { name = "이상해씨", hp = 130 });

            Monster monster;
            sortedDic.TryGetValue("파이리", out monster);      // 파이리 탐색 시도
            Monster indexerMonster = sortedDic["파이리"];      // 인덱서를 통한 탐색 (이 것을 더 많이 사용함 단, 키 값이 있어야함)

            sortedDic.Remove("리아코");
        }

        static void Main(string[] args)
        {
            DataStructure.BinarySearchTree<int> bst = new DataStructure.BinarySearchTree<int>();

            bst.Add(3);
            bst.Add(1);
            bst.Add(5);
            bst.Add(4);
            bst.Add(7);
            bst.Add(9);
            bst.Add(8);
            bst.Add(2);
            bst.Add(6);

            bst.Print();
        }

        class Monster
        {
            public string name;
            public int hp;
            public int mp;
            public int ap;
            public int dp;
        }
    }
}
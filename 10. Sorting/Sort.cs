using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._Sorting
{
    public class Sort
    {
        /******************************************************
		 * 선형 정렬
		 * 
		 * 1개의 요소를 재위치시키기 위해 전체를 확인하는 정렬
		 * n개의 요소를 재위치시키기 위해 n개를 확인하는 정렬
		 * 버블 빼고는 잘 안쓰임 (사실 버블도 잘 안쓰임) 단, Linked List는 분할정복정렬이 안되므로 버블정렬을 사용하기도 함
		 * 시간복잡도 : O(N^2)
		 ******************************************************/

        // <선택정렬>
        // 데이터 중 가장 작은 값부터 하나씩 선택하여 정렬
        public static void SelectionSort(IList<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[minIndex])
                        minIndex = j;
                }
                Swap(list, i, minIndex);
            }
        }

        // <삽입정렬>
        // 데이터를 하나씩 꺼내어 정렬된 자료 중 적합한 위치에 삽입하여 정렬
        public static void InsertionSort(IList<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                int key = list[i];
                int j;
                for (j = i - 1; j >= 0 && key < list[j]; j--)
                {
                    list[j + 1] = list[j];
                }
                list[j + 1] = key;
            }
        }

        // <버블정렬>
        // 서로 인접한 데이터를 비교하여 정렬
        public static void BubbleSort(IList<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 1; j < list.Count; j++)
                {
                    if (list[j - 1] > list[j])
                        Swap(list, j - 1, j);
                }
            }
        }

        /******************************************************
		 * 분할정복 정렬
		 * 
		 * 1개의 요소를 재위치시키기 위해 전체의 1/2를 확인하는 정렬
		 * n개의 요소를 재위치시키기 위해 n/2개를 확인하는 정렬
		 * 시간복잡도 : O(NlogN)
		 ******************************************************/

        /* <3가지 정렬들의 차이>
         *  합병 정렬의 경우 반절의 데이터를 다른곳에 저장할 공간이 새로 필요함 즉, 새로운 배열을 복사해서 할당하여 사용하게됨
         * 따라서 메모리 측면에서 효율적인 정렬은 아니다. 따라서 메모리를 아껴야하거나 성능이 좋지않은 기기에서 게임을 돌려야한다면
         * 합병 정렬은 어울리지 않을 수 있음
         * 
         *  퀵정렬은 Swap하는 방식이므로 추가적인 메모리 사용은 하지 않음 
         * 하지만, 최악의 경우 정렬 시간이 n^2으로, 상황에 따라 조심해야할 필요가 있음
         * 만약 데이터가 역순 정렬이 되어있거나 피벗이 한쪽에 다 몰려있는 상황이라면 버블정렬이랑 시간복잡도가 다를게 없어진다.
         * 분산이 잘 되어있는 데이터들을 정렬할때는 조금 낫지만, 역순 정렬 등 한번 가공한 데이터일 경우 조심해야한다.
         * 또한 퀵정렬은 불안정성이 높은 정렬이다.
         * 
         *  힙정렬은 안정성측면에서 떨어지는 감이 있음
         * 안정성이 떨어진다는 의미는 예를 들어 같은 값의 데이터가 존재할 때 해당 데이터가 숫자만 같고 다른 객체를 나타내는 경우
         * 정렬을 진행했을 때 원래 데이터의 위치와 정렬된 데이터의 위치가 서로 뒤바뀌는 상황이 발생할 수 있다.
         * 즉, 동일한 데이터에 대해 동일한 정렬 위치를 보장해 주지 않으므로, 상황을 탈 수 있다.
         * 
         *  합병 정렬이나 퀵정렬의 경우 배열 기반의 정렬이다. 따라서 캐시메모리가 사용하기에 편하고 정렬을 빠르게 진행할 수 있다.
         * 그에 반해 힙정렬의 경우 연속된 배열 기반 정렬이긴 하지만, 트리기반의 자료구조이기 때문에 인덱스로의 접근이 일반적인 배열과는 다르다.
         * 이는 캐시 메모리에 배열을 두 세번 불러와야하는 경우가 생길 수 있으며, 이때문에 힙정렬이 퀵, 병합정렬보다 느리게 된다.
         * 정리하면 힙 정렬은 어떠한 처리를 하기 위해 들어가는 간접적인 처리 시간 즉, 오버헤드가 있을 수 있기 때문에 속도가 느린것
         * 
         * 3가지의 정렬이 모두 장단이 확실하기 때문에 정렬을 사용할 때에는 상황에 맞게 활용할 수 있어야한다.
         * 
         * 즉,
         * 1. 데이터의 분산이 잘 되어있는데, 메모리는 빡빡하며 가공되지 않은 데이터의 경우 퀵정렬
         * 2. 데이터의 중복이 많으며, 메모리에 여유가 있는 경우 합병 정렬
         * 3. 메모리는 빡빡하고 데이터는 가공되어 있으며, 데이터의 중복이 많지 않은 경우에는 힙정렬
         * 정도로 정리 가능
         */

        // <힙정렬>
        // 힙을 이용하여 우선순위가 가장 높은 요소부터 가져와 정렬
        public static void HeapSort(IList<int> list)
        {
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

            for (int i = 0; i < list.Count; i++)
            {
                pq.Enqueue(list[i], list[i]);
            }

            for (int i = 0; i < list.Count; i++)
            {
                list[i] = pq.Dequeue();
            }
        }

        // <합병정렬>
        // 데이터를 2분할하여 정렬 후 합병
        public static void MergeSort(IList<int> list, int left, int right)
        {
            if (left == right) return;

            int mid = (left + right) / 2;
            MergeSort(list, left, mid);
            MergeSort(list, mid + 1, right);
            Merge(list, left, mid, right);
        }

        public static void Merge(IList<int> list, int left, int mid, int right)
        {
            List<int> sortedList = new List<int>();
            int leftIndex = left;
            int rightIndex = mid + 1;

            // 분할 정렬된 List를 병합
            while (leftIndex <= mid && rightIndex <= right)
            {
                if (list[leftIndex] < list[rightIndex])
                    sortedList.Add(list[leftIndex++]);
                else
                    sortedList.Add(list[rightIndex++]);
            }

            if (leftIndex > mid)    // 왼쪽 List가 먼저 소진 됐을 경우
            {
                for (int i = rightIndex; i <= right; i++)
                    sortedList.Add(list[i]);
            }
            else  // 오른쪽 List가 먼저 소진 됐을 경우
            {
                for (int i = leftIndex; i <= mid; i++)
                    sortedList.Add(list[i]);
            }

            // 정렬된 sortedList를 list로 재복사
            for (int i = left; i <= right; i++)
            {
                list[i] = sortedList[i - left];
            }
        }

        // <퀵정렬>
        // 하나의 피벗을 기준으로 작은값과 큰값을 2분할하여 정렬
        public static void QuickSort(IList<int> list, int start, int end)
        {
            if (start >= end) return;

            int pivotIndex = start;
            int leftIndex = pivotIndex + 1;
            int rightIndex = end;

            while (leftIndex <= rightIndex) // 엇갈릴때까지 반복
            {
                // pivot보다 큰 값을 만날때까지
                while (list[leftIndex] <= list[pivotIndex] && leftIndex < end)
                    leftIndex++;
                while (list[rightIndex] >= list[pivotIndex] && rightIndex > start)
                    rightIndex--;

                if (leftIndex < rightIndex)     // 엇갈리지 않았다면
                    Swap(list, leftIndex, rightIndex);
                else    // 엇갈렸다면
                    Swap(list, pivotIndex, rightIndex);
            }

            QuickSort(list, start, rightIndex - 1);
            QuickSort(list, rightIndex + 1, end);
        }


        private static void Swap(IList<int> list, int left, int right)
        {
            int temp = list[left];
            list[left] = list[right];
            list[right] = temp;
        }
    }
}

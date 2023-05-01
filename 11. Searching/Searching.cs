using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._Searching
{
    public class Searching
    {
        // <순차 탐색>
        public static int SequentialSearch<T>(in IList<T> list, in T item) where T : IEquatable<T>
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (item.Equals(list[i]))
                    return i;
            }
            return -1;
        }

        // <이진 탐색> : 정렬된 자료구조의 탐색, 이진탐색을 진행하기 전에 자료구조를 정렬하고 사용하여야한다.
        public static int BinarySearch<T>(in IList<T> list, in T item) where T : IComparable<T>
        {
            int low = 0;
            int high = list.Count - 1;

            while (low <= high)
            {
                int middle = (low + high) >> 1;     // == (low + high) / 2;
                int compare = list[middle].CompareTo(item);

                if (compare < 0)
                    low = middle + 1;
                else if (compare > 0)
                    high = middle - 1;
                else
                    return middle;
            }
            return -1;
        }

        // <깊이 우선 탐색 (Depth First Search)>
        // 그래프의 분기를 만났을 때 최대한 깊이 내려간 뒤,
        // 더이상 깊이 갈 곳이 없을 경우 다음 분기를 탐색
        // 백트래킹 알고리즘 (분할정복)
        // stack 구조에 의한 구현
        public static void DFS(bool[,] graph, int start, out bool[] visited, out int[] parents)
        {
            visited = new bool[graph.GetLength(0)];
            parents = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false;
                parents[i] = -1;
            }
            SearchNode(graph, start, visited, parents);
        }

        private static void SearchNode(bool[,] graph, int start, bool[] visited, int[] parents)
        {
            visited[start] = true;
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (graph[start, i] &&          // 연결되어 있는 정점이며,
                    !visited[i])                // 방문한 적 없는 정점인 경우
                {
                    parents[i] = start;
                    SearchNode(graph, i, visited, parents);
                }
            }
        }

        // <너비 우선 탐색 (Breadth Frist Search)>
        // 그래프의 분기를 만났을 때 모든 분기를 하나씩 저장하고,
        // 저장한 한번씩 거치면서 탐색
        // Queue구조에 의한 구현
        public static void BFS(bool[,] graph, int start, out bool[] visited, out int[] parents)
        {
            visited = new bool[graph.GetLength(0)];
            parents = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false;
                parents[i] = -1;
            }

            Queue<int> bfsQueue = new Queue<int>();

            bfsQueue.Enqueue(start);
            while (bfsQueue.Count > 0)
            {
                int next = bfsQueue.Dequeue();
                visited[next] = true;

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[start, i] &&          // 연결되어 있는 정점이며,
                        !visited[i])                // 방문한 적 없는 정점인 경우
                    {
                        parents[i] = start;
                        bfsQueue.Enqueue(i);
                    }
                }
            }
        }
    }
}

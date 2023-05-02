using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace _12._ShortestPath
{
    internal class Dijkstra
    {
		/******************************************************
		 * 다익스트라 알고리즘 (Dijkstra Algorithm)
		 * 
		 * 특정한 노드에서 출발하여 다른 노드로 가는 각각의 최단 경로를 구함
		 * 방문하지 않은 노드 중에서 최단 거리가 가장 짧은 노드를 선택 후,
		 * 해당 노드를 거쳐 다른 노드로 가는 비용 계산
		 * A->B 의 경로가 다른 두 경로의 합보다 클경우
		 * 다른 두 경로의 합의 경로를 A->B의 거리로 만들어준다.
		 * 이 더 짧은 경로가 있을 경우 A->B를 바꾸는 것을 반복한다.
		 * 모든 경로에 대해서 탐색을 해야하는데, 해당 알고리즘은 최단 거리를 탐색하는 알고리즘이므로,
		 * 가장 먼저 탐색해야하는 대상은 가중치가 가장 작은 경로부터이다.
		 ******************************************************/

		const int INF = 99999;		// 오버플로우 방지를 위해 적당히 큰값을 저장

		public static void ShortestPath(int[,] graph, int start, out int[] distance, out int[] path)
		{
			int size = graph.GetLength(0);
			bool[] visited = new bool[size];

			distance = new int[size];
			path = new int[size];
			for (int i = 0; i < size; i++)
			{
				distance[i] = graph[start, i];
				path[i] = graph[start, i] < INF ? start : -1;
			}

            for (int i = 0; i < size; i++)
			{
				// 1. 방문하지 않은 정점 중 가장 가까운 정점부터 탐색
				int next = -1;
				int minCost = INF;
				for (int j = 0; j < size; j++)
				{
					if (!visited[j] && distance[j] < minCost)
					{
						next = j;
						minCost = distance[j];
					}
				}
				if (next < 0)
					break;

				// 2.  직접연결된 거리보다 거쳐서 더 짧아진다면 갱신
				for (int j = 0; j < size; j++)
				{
					// distance[j] : 목적지까지 직접 연결된 거리
					// distance[next] : 탐색중인 정점까지 거리
					// graph[next, j] : 탐색중인 정점부터 목적지까지의 거리
					if (distance[j] > distance[next] + graph[next, j])
					{
						distance[j] = distance[next] + graph[next, j];
						path[j] = next;

                    }
				}
				visited[next] = true;
			}
		}
    }
}

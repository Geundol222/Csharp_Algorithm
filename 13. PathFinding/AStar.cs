using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._PathFinding
{
    internal class Astar
    {
		/******************************************************
		 * A* 알고리즘
		 * 
		 * 게임의 맵에서 다익스트라 알고리즘은 전방위적인 탐색을 진행하게 되므로 
		 * 목적지와는 상관없는 경로까지 탐색을 해버리게 되므로 효율성면에서 떨어질 수 있다.
		 * 다익스트라 알고리즘을 확장하여 만든 최단경로 탐색알고리즘
		 * 경로 탐색의 우선순위를 두고 유망한 해부터 우선적으로 탐색
		 * f, g, h에 대한 것을 기억해야 함
		 * f : g + h => 총 거리, 이 f가 가장 작은 경로부터 먼저 탐색을 진행한다.
		 * g : 지금까지 온 거리
		 * h : 예상거리 (휴리스틱) : 가장 중요한 개념
		 * f 가 같다면 g가 크고 h가 낮은 좌표부터 탐색을 진행한다.
		 * 맨해튼 거리에 의해 출발지에서 목적지까지 같은 가중치로 갈 수 있는 경우의 수는 매우 많게 되므로,
		 * 완전한 최단경로 탐색을 위해 새로운 가중치 개념을 적용하게 된다.
		 * 상하좌우의 한칸 당 가중치는 10으로 하며, 대각선은 대략 14의 가중치로 한다.
		 * 대각선은 삼각함수에 의해 (10 * (root)2 == 14.14...) 이므로 대략 14의 가중치가 나오는것
		 * h 의 경우 경로상 장애물의 여부와 관계 없이 가장 최단 경로로 계산된다. 
		 * ㄴ 하다보면 f의 값이 점점 커지기만 하므로 알아서 돌아가짐
		 ******************************************************/

		const int CostStraight = 10;
		const int CostDiagonal = 14;

		static Point[] Direction =
		{
			new Point(0, +1),	// 상
            new Point(0, -1),	// 하
            new Point(-1, 0),	// 좌
            new Point(+1, 0),	// 우
			new Point(-1, +1),	// 좌상
			new Point(-1, -1),	// 좌하
			new Point(+1, +1),	// 우상
			new Point(+1, -1),	// 우하
        };

		public static bool PathFinding(bool[,] tileMap, Point start, Point end, out List<Point> path)
		{
			// 요소 초기화
			int ySize = tileMap.GetLength(0);
			int xSize = tileMap.GetLength(1);

			bool[,] visited = new bool[ySize, xSize];
			ASNode[,] nodes = new ASNode[ySize, xSize];
			PriorityQueue<ASNode, int> nextPointPQ = new PriorityQueue<ASNode, int>();

			// 0. 시작 정점을 생성하여 추가
			ASNode startNode = new ASNode(start, null, 0, Heuristic(start, end));
			nodes[startNode.point.y, startNode.point.x] = startNode;
			nextPointPQ.Enqueue(startNode, startNode.f);

			while (nextPointPQ.Count > 0)
			{
				// 1. 다음으로 탐색할 정점 꺼내기
				ASNode nextNode = nextPointPQ.Dequeue();

				// 2. 방문한 정점은 방문표시
				visited[nextNode.point.y, nextNode.point.x] = true;

				// 3. 탐색할 정점이 도착지인 경우
				// 도착했다고 판단해서 경로반환
				if (nextNode.point.x == end.x && nextNode.point.y == end.y)
				{
					Point? pathPoint = end;
					path = new List<Point>();

					while (pathPoint != null)
					{
						Point point = pathPoint.GetValueOrDefault();
						path.Add(point);
						pathPoint = nodes[point.y, point.x].parent;
					}

					path.Reverse();
					return true;
				}

				// 4. Astar 탐색을 진행
				// 방향 탐색
				for (int i = 0; i < Direction.Length; i++)
				{
					int x = nextNode.point.x + Direction[i].x;
					int y = nextNode.point.y + Direction[i].y;

					// 4-1. 탐색하면 안되는 경우 제외
					// 맵을 벗어났을 경우
					if (x < 0 || x >= xSize || y < 0 || y >= ySize)
						continue;
					// 탐색할 수 없는 정점일 경우
					else if (tileMap[y, x] == false)
						continue;
					// 이미 방문한 정점일 경우
					else if (visited[y, x])
						continue;

					// 4-2. 점수 계산
					int g = nextNode.g + ((nextNode.point.x == x || nextNode.point.y == y) ? CostStraight : CostDiagonal);
					int h = Heuristic(new Point(x, y), end);
					ASNode newNode = new ASNode(new Point(x, y), nextNode.point, g, h);

					// 4-3. 정점의 갱신이 필요한 경우 새로운 정점으로 할당
					if (nodes[y, x] == null ||      // 점수계산이 되지 않은 정점이거나
						nodes[y, x].f > newNode.f)    // 가중치가 더 높은 정점인 경우
					{
						nodes[y, x] = newNode;
						nextPointPQ.Enqueue(newNode, newNode.f);
					}
				}
			}
			path = null;
			return false;
		}

        // 휴리스틱(Heuristic) : 최상의 경로를 추정하는 순위값, 휴리스틱에 의해 경로탐색 효율이 결정된다.
        private static int Heuristic(Point start, Point end)
		{
            int xSize = Math.Abs(start.x - end.x);  // 가로로 가야하는 횟수
            int ySize = Math.Abs(start.y - end.y);  // 세로로 가야하는 횟수

            // 맨해튼 거리 : 가로 세로를 통해 이동하는 거리
            // return CostStraight * (xSize + ySize);

            // 유클리드 거리 : 대각선을 통해 이동하는 거리
            return CostStraight * (int)Math.Sqrt(xSize * xSize + ySize * ySize);
        }

		private class ASNode
		{
			public Point point;     // 현재 정점 위치
			public Point? parent;	// 현재 정점을 탐색했던 정점 (parent 좌표는 출발선에서 없을 수 있으므로 Nullable 사용)

			public int f;			// f(x) = g(x) + h(x) : 총거리
			public int g;           // 현재까지 이동한 거리, 지금까지 경로 가중치
			public int h;			// 휴리스틱 : 앞으로 예상되는 거리, 목표까지 추정 경로 가중치

			public ASNode(Point point, Point? parent, int g, int h)
			{
				this.point = point;
				this.parent = parent;
				this.g = g;
				this.h = h;
				this.f = g + h;
			}
		}
    }

	public struct Point
	{
		public int x;
		public int y;

		public Point(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}
}

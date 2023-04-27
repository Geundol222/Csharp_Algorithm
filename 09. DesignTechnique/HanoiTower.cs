using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._DesignTechnique
{
    public class HanoiTower
    {
        public static Stack<int>[] stick;

        // 1. 하노이 탑 문제 <분할정복>
        public void MainHanoi()
        {
            int count = 7;

            stick = new Stack<int>[3];
            for (int i = 0; i < stick.Length; i++)
            {
                stick[i] = new Stack<int>();
            }

            for (int i = count; i > 0; i--)
            {
                stick[0].Push(i);
            }

            HanoiMove(count, 0, 2);
        }

        public static void HanoiMove(int count, int start, int end)
        {
            if (count == 1)
            {
                int node = stick[start].Pop();
                stick[end].Push(node);
                Console.WriteLine($"{start} 스틱에서 {end} 스틱으로 {node} 이동");
                return;
            }

            int other = 3 - start - end;

            HanoiMove(count - 1, start, other);
            HanoiMove(1, start, end);
            HanoiMove(count - 1, other, end);
        }
    }
}

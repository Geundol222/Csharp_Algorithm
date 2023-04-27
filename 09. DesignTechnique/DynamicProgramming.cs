using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._DesignTechnique
{
    internal class DynamicProgramming
    {
        /******************************************************
		 * 동적계획법 (Dynamic Programming)
		 * 
		 * 분할 정복과는 반대의 개념(완전반대..?)
		 * 분할 정복은 위에서 부터 시작하여 나누는 하향식 접근방식이지만, 동적계획법은 아래에서부터 차근차근 쌓아올리는 상향식 접근방식
		 * 작은문제의 해답을 큰문제의 해답의 부분으로 이용하는 상향식 접근 방식
		 * 주어진 문제를 해결하기 위해 부분 문제에 대한 답을 계속적으로 활용해 나가는 기법
		 ******************************************************/

        // 만약 분할정복으로 피보나치 수열을 계산한다면, 이분법적 계산이 아닌 양쪽에 있는 함수에 모두 접근하여 연산을 진행하는 것이 되기 때문에
        // 시간 복잡도가 O(2^n)이 되게 되므로 매우 비효율 적으로 돌아가게 된다.
        // 따라서 이러한 계산에서는 동적계획법이 더 나을 수 있다.
        //int Fibonachi2(int x)
        //{
        //    if (x == 1)
        //        return 1;
        //    if (x == 2)
        //        return 1;

        //    return Fibonachi2(x - 2) + Fibonachi2(x - 1);
        //}

        // 예시 - 피보나치 수열
        int Fibonachi(int x)
        {
            int[] fibonachi = new int[x + 1];
            fibonachi[1] = 1;
            fibonachi[2] = 1;

            for (int i = 3; i <= x; i++)
            {
                fibonachi[i] = fibonachi[i - 1] + fibonachi[i - 2];
            }

            return fibonachi[x];
        }
    }
}

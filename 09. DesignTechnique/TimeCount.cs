using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._DesignTechnique
{
    public class TimeCount
    {
        public static int CountTime(params int[] task)
        {
            Array.Sort(task);

            int result = 0;

            for (int i = 0; i < task.Length; i++)
                result += task[i];

            return result;
        }
    }
}

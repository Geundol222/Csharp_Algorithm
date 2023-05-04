using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class MapScene : Scene
    {
        public MapScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            PrintMap();
        }

        public override void Update()
        {
            string input = Console.ReadLine();
        }

        private void PrintMap()
        {
            StringBuilder sb = new StringBuilder();
            for (int y = 0; y < Data.map.GetLength(0); y++)
            {
                for (int x = 0; x < Data.map.GetLength(1); x++)
                {
                    if (Data.map[y, x])
                        sb.Append('　');
                    else
                        sb.Append('■');
                }
                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString());
        }
    }
}

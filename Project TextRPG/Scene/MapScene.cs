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
            ConsoleKeyInfo input = Console.ReadKey();

            // 플레이어 이동
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    Data.player.Move(Direction.Up);
                    break;
                case ConsoleKey.DownArrow:
                    Data.player.Move(Direction.Down);
                    break;
                case ConsoleKey.LeftArrow:
                    Data.player.Move(Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    Data.player.Move(Direction.Right);
                    break;
            }

            // 몬스터 이동
            foreach (Monster monster in Data.monsters)
            {
                monster.MoveAction();
            }
        }

        private void PrintMap()
        {
            Console.ForegroundColor = ConsoleColor.White;

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

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (Monster monster in Data.monsters)
            {
                Console.SetCursorPosition(monster.pos.x * 2, monster.pos.y);
                Console.Write(monster.icon);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Data.player.pos.x * 2, Data.player.pos.y);
            Console.Write(Data.player.icon);
        }
    }
}

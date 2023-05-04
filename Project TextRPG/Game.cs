using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Project_TextRPG
{
    public class Game
    {
        private bool isRunning = true;

        private Scene               curScene;
        // private Dictionary<string, Scene> sceneDic;  // 씬 딕셔너리로 처리하는 방법도 있음
        private MainMenuScene       mainMenuScene;
        private MapScene            mapScene;
        private InventoryScene      inventoryScene;
        private BattleScene         battleScene;

        public void Run()
        {
            // 초기화
            Init();

            // 게임 루프
            while (isRunning)
            {
                // 랜더링(Render)
                Render();
                // 갱신(Update)
                Update();
            }

            // 마무리
            Release();
        }

        private void Init()
        {
            Data.Init();

            mainMenuScene = new MainMenuScene(this);
            mapScene = new MapScene(this);
            inventoryScene = new InventoryScene(this);
            battleScene = new BattleScene(this);

            curScene = mainMenuScene;
        }

        public void GameStart()
        {
            Data.LoadLevel();
            curScene = mapScene;
        }

        public void GameOver()
        {
            Console.CursorVisible = false;
            Console.Clear();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine("  ***    *   *   * *****       ***  *   * ***** ****  ");
            sb.AppendLine(" *      * *  ** ** *          *   * *   * *     *   * ");
            sb.AppendLine(" * *** ***** * * * *****      *   * *   * ***** ****  ");
            sb.AppendLine(" *   * *   * *   * *          *   *  * *  *     *  *  ");
            sb.AppendLine("  ***  *   * *   * *****       ***    *   ***** *   * ");
            sb.AppendLine();
            sb.AppendLine();

            Console.WriteLine(sb.ToString());

            isRunning = false;
        }

        private void Render()
        {
            Console.Clear();
            curScene.Render();
        }

        private void Update()
        {
            curScene.Update();
        }

        private void Release()
        {
            Data.Release();
        }
    }
}

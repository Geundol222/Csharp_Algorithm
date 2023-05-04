using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Game
    {
        private bool isRunning = true;

        private Scene               curScene;
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

        }

        private void Render()
        {
            curScene.Render();
        }

        private void Update()
        {
            curScene.Update();
        }

        private void Release()
        {

        }
    }
}

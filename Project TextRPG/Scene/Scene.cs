using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public abstract class Scene     // 씬이라는 씬은 없으므로 추상클래스로 만들어 자식클래스가 구현하게 함
    {
        protected Game game;

        public Scene(Game game)
        {
            this.game = game;
        }

        public abstract void Render();
        public abstract void Update();
    }
}

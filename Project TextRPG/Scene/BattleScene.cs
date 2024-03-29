﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class BattleScene : Scene
    {
        private Monster monster;

        public BattleScene(Game game) : base(game)
        {

        }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("엄청난 몬스터를 만났다.");
            sb.AppendLine("1. 공격하기");
            sb.AppendLine("2. 도망가기");
            sb.Append("행동을 선택하세요 : ");

            Console.Write(sb.ToString());
            // TODO : 배틀씬 표현 구현
        }

        public override void Update()
        {
            string input = Console.ReadLine();
            // TODO : 배틀씬 갱신 구현
        }

        public void BattleStart(Monster monster)
        {
            this.monster = monster;
            Data.monsters.Remove(monster);

            Console.Clear();
            Console.WriteLine("전투 시작!!!!!");
            Thread.Sleep(1000);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace 飞机大战
{
    class BeginScene : BeginOrEndBaseScene
    {
        public BeginScene()
        {
            strTitle = "飞机大战";
            strOne = "开始游戏";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(Game.w / 2 - 10, 6);
            Console.WriteLine("上下控制:ws，确认：j");
        }

        public override void EnterJDoSomthing()
        {
            //按J键做什么的逻辑
            if (nowSelIndex == 0)
            {
                Game.ChangeScene(E_SceneType.Game);
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}

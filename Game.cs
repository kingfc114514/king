using System;
using System.Collections.Generic;
using System.Text;
using static System.Formats.Asn1.AsnWriter;
namespace 飞机大战
{ 
  // 场景类型枚举
    enum E_SceneType
    {
        // 开始场景
        Begin,
        // 游戏场景
        Game,
        // 结束场景
        End,
    }

      class Game
    {
        //游戏窗口宽高
        public static int w = 80;
        public static int h = 50;
        //当前选中的场景


        public static ISceneUpdate nowScene;

        public Game()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(w, h);
            Console.SetBufferSize(w, h);
            ChangeScene(E_SceneType.Begin);
        }

        //游戏开始的方法
        public void Start()
        {
            //游戏主循环
            while (true)
            {
                //判断当前游戏场景不为空 就更新
                if (nowScene != null)
                {
                    nowScene.Update();
                }
            }
        }

        public static void ChangeScene(E_SceneType type)
        {
            //清除
            Console.Clear();

            switch (type)
            {
                case E_SceneType.Begin:
                    nowScene = new BeginScene();
                    break;
                case E_SceneType.Game:
                    nowScene = new GameScene();
                    break;
                case E_SceneType.End:
                    nowScene = new EndScene();
                    break;
            }
        }
        public static void ChangeScene(E_SceneType type,int score)
        {
            //清除
            int turn = 0;
            while (turn < 10)
            {
                turn++;
            }
            Console.Clear();

            switch (type)
            {
                case E_SceneType.Begin:
                    nowScene = new BeginScene();
                    break;
                case E_SceneType.Game:
                    nowScene = new GameScene();
                    break;
                case E_SceneType.End:
                    nowScene = new EndScene();
                    Console.ForegroundColor=ConsoleColor.Yellow;
                    Console.SetCursorPosition(Game.w / 2-7 , 6);
                    Console.WriteLine("你的分数是：{0}", score);
                    break;
            }
        }
    }
}

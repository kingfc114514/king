
namespace 飞机大战
{
     class Map : IDraw
    {
        Brick[] bricks = new Brick[Game.h * 2 - 2];
        public void Draw(int hp,int atk,int score,int Level,int Reward,int BulletNum)
        {
            int index = 0;
            for(int i = 0; i < Game.h-1; i++)
            {
                bricks[index] = new Brick(10, i);
                bricks[index].Draw();
                index++;
                bricks[index] = new Brick(50, i);
                bricks[index].Draw();
                index++;
            }
            Console.SetCursorPosition(65, 6);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("LEVEL:{0}",Level);
            Console.SetCursorPosition(65, 25);
            Console.WriteLine("                       ");
            Console.SetCursorPosition(65, 25);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("HP:{0}",hp);
            Console.SetCursorPosition(65, 27);
            Console.WriteLine("Atk:{0}",atk);
            Console.SetCursorPosition(65, 29);
            Console.WriteLine("Reward:{0}",Reward);
            Console.SetCursorPosition(65, 31);
            Console.WriteLine("                   ");
            Console.SetCursorPosition(61, 31);
            Console.WriteLine("当前可打出弹药数:{0}",BulletNum);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(65, 4);
            Console.WriteLine("SCORE:{0}",score);
            Console.SetCursorPosition(64, 13);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("攻击加1  生命加{0}",5+1*Level);
            Console.SetCursorPosition(64, 14);
            Console.WriteLine("消耗1点  消耗1点");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 飞机大战
{
    internal class Bullet : GameObject
    {
        public int atk;
        E_PlaneType type;
        public Bullet(int atk,int x,int y, E_PlaneType type)
        {
            this.atk = atk;
            this.pos = new Position(x,y);
            this.type = type;
        }
        public override void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor =type==E_PlaneType.Myplane? ConsoleColor.Blue:ConsoleColor.Yellow;
            Console.Write("*");
        }
        public void Move()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.Write(" ");
            if (type == E_PlaneType.Myplane)
            {
                pos.y--;
                Draw();
            }
            else
            {
                pos.y++;
                Draw();
            }
        }
        public bool Hit(Myplane plane)
        {
            for(int i = 0; i < plane.planes.Length; i++)
            {
                if (  plane.planes[i].pos.x == pos.x && plane.planes[i].pos.y == pos.y)
                {
                    Console.SetCursorPosition(pos.x, pos.y);
                    Console.Write(" ");
                    return true;
                }
            
            }
            return false;
        }
        public bool Hit(Enemyplane plane)
        {
            for (int i = 0; i < plane.planes.Length; i++)
            {
                if (plane.planes[i].pos.x == pos.x && plane.planes[i].pos.y == pos.y)
                {
                    Console.SetCursorPosition(pos.x, pos.y);
                    Console.Write(" ");
                    return true;
                }

            }
            return false;
        }
        public bool Hit(BossPlane plane)
        {
            for (int i = 0; i < plane.planes.Length; i++)
            {
                if (plane.planes[i].pos.x == pos.x && plane.planes[i].pos.y == pos.y)
                {
                    Console.SetCursorPosition(pos.x, pos.y);
                    Console.Write(" ");
                    return true;
                }

            }
            return false;
        }
    }
}

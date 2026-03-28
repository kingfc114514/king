using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace 飞机大战
{
    internal class Myplane: plane
    {
       public  Bullet[] bullets;
       E_PlaneType type;

        public Myplane(Position pos):base(E_PlaneType.Myplane)
        {
            type=E_PlaneType.Myplane;
            hp = 10;
            atk = 1;
            bullets= new Bullet[30];
            planes = new PlanePart[10];
            for (int i = 0; i < planes.Length; i++)
            {
                planes[i] = new PlanePart(type);     // 每个元素都要创建对象
            }
            planes[0].pos=pos;
            planes[1].pos = new Position(pos.x + 1, pos.y);
            planes[2].pos = new Position(pos.x + 2, pos.y);
            planes[3].pos = new Position(pos.x - 1, pos.y);
            planes[4].pos = new Position(pos.x - 2, pos.y);
            planes[5].pos = new Position(pos.x, pos.y - 1);
            planes[6].pos = new Position(pos.x, pos.y + 1);
            planes[7].pos = new Position(pos.x, pos.y + 2);
            planes[8].pos = new Position(pos.x - 1, pos.y + 2);
            planes[9].pos = new Position(pos.x + 1, pos.y + 2);
        }
        override public void Draw()
        {
            for (int i = 0; i < planes.Length; i++)
            {
                planes[i].Draw();
            }
        }
        public void Move(char key)
        {
            for (int i = 0; i < planes.Length; i++)
            {
                Console.SetCursorPosition(planes[i].pos.x, planes[i].pos.y);
                Console.Write(" ");
            }
            switch (key)
            {
                case 'w':
                case 'W':
                    if (planes[5].pos.y > 10)
                    {
                        for (int i = 0; i < planes.Length; i++)
                        {
                            planes[i].pos.y--;
                        }
                    }
                    break;
                case 's':
                case 'S':
                    if (planes[7].pos.y < Game.h - 4)
                    {
                        for (int i = 0; i < planes.Length; i++)
                        {
                            planes[i].pos.y++;
                        }
                    }

                    break;
                case 'a':
                case 'A':
                    if (planes[4].pos.x > 11)
                    {
                        for (int i = 0; i < planes.Length; i++)
                        {
                            planes[i].pos.x--;
                        }
                    }

                    break;
                case 'd':
                case 'D':
                    if (planes[2].pos.x < 48)
                    {
                        for (int i = 0; i < planes.Length; i++)
                        {
                            planes[i].pos.x++;
                        }
                    }
                    break;
            }
        }
        public void attack()
        {
            for(int i = 0; i < bullets.Length; i++)
            {
                if (bullets[i] == null)
                {
                    bullets[i] = new Bullet(atk, planes[5].pos.x, planes[5].pos.y - 1,type);
                    bullets[i].Draw();
                    break;
                }
            }
        }
        public int ATKup(int Reward)
        {
            if(Reward >= 1)
            {
                atk += 1;
                return Reward - 1;
            }
            else
            {
                return Reward;
            }
        }
        public int HPup(int Reward,int Level)
        {
            if (Reward >= 1)
            {
                hp += 5+1*Level;
                return Reward - 1;
            }
            else
            {
                return Reward;
            }
        }
     }
}


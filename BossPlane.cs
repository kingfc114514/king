using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 飞机大战
{
    internal class BossPlane : Enemyplane
    {
        public BossPlane(Position pos,int Level) : base(pos, Level)
        {
            type = E_PlaneType.Enemy;
            hp = 25+5*Level;
            atk = 1+1*Level;
            this.pos = pos;
            planes = new PlanePart[16];
            bullets = new Bullet[100];
            for (int i = 0; i < planes.Length; i++)
            {
                planes[i] = new PlanePart(type);     // 每个元素都要创建对象
            }
            planes[0].pos = pos;
            planes[1].pos = new Position(pos.x + 1, pos.y);
            planes[2].pos = new Position(pos.x + 2, pos.y);
            planes[3].pos = new Position(pos.x - 1, pos.y);
            planes[4].pos = new Position(pos.x - 2, pos.y);
            planes[5].pos = new Position(pos.x, pos.y + 1);
            planes[6].pos = new Position(pos.x, pos.y + 2);
            planes[7].pos = new Position(pos.x+1, pos.y + 1);
            planes[8].pos = new Position(pos.x - 1, pos.y + 1);
            planes[9].pos = new Position(pos.x , pos.y - 1);
            planes[10].pos = new Position(pos.x + 1, pos.y - 1);
            planes[11].pos = new Position(pos.x - 1, pos.y - 1);
            planes[12].pos = new Position(pos.x + 2, pos.y - 1);
            planes[13].pos = new Position(pos.x - 2, pos.y - 1);
            planes[14].pos = new Position(pos.x + 3, pos.y - 1);
            planes[15].pos = new Position(pos.x - 3, pos.y - 1);
        }
    
        public void Move()
        {
            for (int i = 0; i < planes.Length; i++)
            {
                Console.SetCursorPosition(planes[i].pos.x, planes[i].pos.y);
                Console.Write(" ");
            }
            Random r = new Random();
            int leftorright = r.Next(0, 2);
            if(leftorright == 0)
            {
                if (planes[7].pos.x > 20)
                {
                    for (int i = 0; i < planes.Length; i++)
                    {
                        planes[i].pos.x--;
                    }
                }
            }
            else
            {
                if (planes[7].pos.x <48)
                {
                    for (int i = 0; i < planes.Length; i++)
                    {
                        planes[i].pos.x++;
                    }
                }
            }

        }
        public void Attack()
        {
            int count = 0;
            Random r = new Random();
            int BulletPosition = r.Next(planes[15].pos.x, planes[14].pos.x + 1);
            for (int i = 0; i < bullets.Length; i++)
            {
                if (bullets[i] == null)
                {
                    if(count == 0)
                    {
                        bullets[i] = new Bullet(atk, BulletPosition, planes[5].pos.y - 2, type);
                        bullets[i].Draw();
                        count++;
                        continue;
                    }
                   if(count == 1)
                    {
                        bullets[i] = new Bullet(atk, BulletPosition, planes[5].pos.y - 4, type);
                        bullets[i].Draw();
                        count++;
                        continue;
                    }
                   if(count == 2)
                    {
                        bullets[i] = new Bullet(atk, BulletPosition, planes[5].pos.y - 6, type);
                        bullets[i].Draw();
                        count++;
                        continue;
                    }
                    if(count == 3)
                    {
                        break;
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 飞机大战
{
    internal class Enemyplane:plane
    {
        E_PlaneType type;
        public Bullet[] bullets;
        public Enemyplane(Position pos,int Level):base(E_PlaneType.Enemy)
        {
            type=E_PlaneType.Enemy;
            hp = 4+2*Level;
            atk = 1+Level/2;
            this.pos = pos;
            planes = new PlanePart[10];
            bullets = new Bullet[20];
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
            planes[6].pos = new Position(pos.x, pos.y - 1);
            planes[7].pos = new Position(pos.x, pos.y - 2);
            planes[8].pos = new Position(pos.x - 1, pos.y - 2);
            planes[9].pos = new Position(pos.x + 1, pos.y - 2);
        }
        override public void Draw()
        {
            for (int i = 0; i < planes.Length; i++)
            {
                planes[i].Draw();
            }
        }
        public void Move()
        {
            for (int i = 0; i < planes.Length; i++)
            {
                Console.SetCursorPosition(planes[i].pos.x, planes[i].pos.y);
                Console.Write(" ");
            }
            if (planes[7].pos.y < Game.h - 4)
            {
                for (int i = 0; i < planes.Length; i++)
                {
                    planes[i].pos.y++;
                }
            }
        }
        public void Attack()
        {
            for (int i = 0; i < bullets.Length; i++)
            {
                if (bullets[i] == null)
                {
                    bullets[i] = new Bullet(atk, planes[5].pos.x, planes[5].pos.y - 1,type);
                    bullets[i].Draw();
                    break;
                }
            }
        }
    }
}

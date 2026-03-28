using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 飞机大战
{
    public enum E_PlaneType
    {
        Enemy,
        Myplane
    }
    public class PlanePart : GameObject
    {
        public E_PlaneType type;
        public PlanePart(E_PlaneType type)
        {
            this.type = type;
        }
        public PlanePart(){

        }

        public override void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = type == E_PlaneType.Myplane ? ConsoleColor.White : ConsoleColor.Red;
            Console.WriteLine("■");
        }
    }
}

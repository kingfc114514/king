using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 飞机大战
{
    abstract class plane : PlanePart
    {
        public int hp;
        public int atk;
        public PlanePart[] planes; 
        public plane(E_PlaneType type)
        {
            this.type = type;
        }
    }
}

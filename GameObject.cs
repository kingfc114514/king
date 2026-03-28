using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 飞机大战
{
    public abstract class GameObject : IDraw
    {
        public Position pos;
        abstract public void Draw();
    }
}

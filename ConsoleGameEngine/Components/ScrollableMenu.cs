using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameEngine.Components
{
    public class ScrollableMenu<T> : Menu<T>
    {
        int sizeY;
        public ScrollableMenu(int positionX, int positionY, int sizeX, int sizeY,
            Alignment alignment = Alignment.Center)
            : base(positionX, positionY, sizeX, alignment)
        {
            this.sizeY = sizeY;
        }
    }
}

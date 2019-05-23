using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameEngine.Components
{
    public class ScrollableMenu<T> : Menu<T>
    {
        int maxItemShown;
        int firstShown = 0, lastShown;

        #region Constructor
        public ScrollableMenu(int positionX, int positionY, int sizeX, int maxItemShown,
            Alignment alignment = Alignment.Center)
            : base(positionX, positionY, sizeX, alignment)
        {
            this.maxItemShown = maxItemShown;
            lastShown = maxItemShown - 1;
        }

        public ScrollableMenu(int positionX, int positionY, int sizeX, int maxItemShown,
            Color color1Default, Color color2Default,
            Alignment alignment = Alignment.Center)
            : base(positionX, positionY, sizeX,
              color1Default, color2Default,
              alignment)
        {
            this.maxItemShown = maxItemShown;
            lastShown = maxItemShown - 1;
        }

        #endregion

        #region Manipulation
        public override bool Up()
        {
            if (currentSelectedIndex > 0)
            {
                menuItems[currentSelectedIndex].OutOfFocus();
                currentSelectedIndex--;
                menuItems[currentSelectedIndex].InToFocus();
                if (currentSelectedIndex < firstShown)
                {
                    firstShown--;
                    lastShown--;
                }
                return true;
            }
            return false;
        }

        public override bool Down()
        {
            if (currentSelectedIndex < menuItems.Count - 1)
            {
                menuItems[currentSelectedIndex].OutOfFocus();
                currentSelectedIndex++;
                menuItems[currentSelectedIndex].InToFocus();
                if (currentSelectedIndex > lastShown)
                {
                    firstShown++;
                    lastShown++;
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Gets
        public int GetMaxShown() => maxItemShown;
        public bool FirstIsInScope() => firstShown == 0;
        public bool LastIsInScope() => lastShown >= menuItems.Count - 1;
        public List<MenuItem<T>> GetMenuItemsInScope() => menuItems.GetRange(firstShown,
            Math.Min(maxItemShown, menuItems.Count - firstShown));
        #endregion

        public override void Print()
        {
            Renderer.PrintScrollableMenu(this);
        }
    }
}

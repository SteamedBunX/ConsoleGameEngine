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
        int maxItemInScope;
        int firstInScope = 0, lastInScope;

        #region Constructor
        public ScrollableMenu(int positionX, int positionY, int sizeX, int maxItemShown,
            Alignment alignment = Alignment.Center)
            : base(positionX, positionY, sizeX, alignment)
        {
            this.maxItemInScope = maxItemShown;
            lastInScope = maxItemShown - 1;
        }

        public ScrollableMenu(int positionX, int positionY, int sizeX, int maxItemShown,
            Color color1Default, Color color2Default,
            Alignment alignment = Alignment.Center)
            : base(positionX, positionY, sizeX,
              color1Default, color2Default,
              alignment)
        {
            this.maxItemInScope = maxItemShown;
            lastInScope = maxItemShown - 1;
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
                if (currentSelectedIndex < firstInScope + 1 && firstInScope != 0)
                {
                    firstInScope--;
                    lastInScope--;
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
                if (currentSelectedIndex > lastInScope - 1 && lastInScope != menuItems.Count - 1)
                {
                    firstInScope++;
                    lastInScope++;
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Gets
        public int GetScopeSize() => maxItemInScope;
        public bool FirstIsInScope() => firstInScope == 0;
        public bool LastIsInScope() => lastInScope >= menuItems.Count - 1;
        public List<MenuItem<T>> GetMenuItemsInScope() => menuItems.GetRange(firstInScope,
            Math.Min(maxItemInScope, menuItems.Count - firstInScope));

        public int GetFirstItemIndexInScope() => firstInScope;
        #endregion

        public override void Print()
        {
            Renderer.PrintScrollableMenu(this);
        }
    }
}

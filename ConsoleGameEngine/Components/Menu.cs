﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameEngine.Components
{
    public class Menu<T>
    {
        protected int positionX, positionY, sizeX;
        protected Color color1Default = Color.White, color2Default = Color.Black;
        protected Alignment alignment;
        protected List<MenuItem<T>> menuItems = new List<MenuItem<T>>();
        protected int currentSelectedIndex = 0;

        #region Constructors
        public Menu(int positionX, int positionY, int sizeX,
            Alignment alignment = Alignment.Center)
        {
            this.positionX = positionX;
            this.positionY = positionY;
            this.sizeX = sizeX;
            this.alignment = alignment;
        }

        public Menu(int positionX, int positionY, int sizeX,
            Color color1Default, Color color2Default,
            Alignment alignment = Alignment.Center)
            : this(positionX, positionY, sizeX, alignment)
        {
            this.color1Default = color1Default;
            this.color2Default = color2Default;
        }

        #endregion

        #region Manipulation
        public void ChangeSelection(int selection)
        {
            if (selection <= 0)
            {
                ChangeSelection(0);
            }
            else if (selection >= menuItems.Count)
            {
                ChangeSelection(menuItems.Count - 1);
            }
            else
            {
                if (currentSelectedIndex != selection)
                {
                    currentSelectedIndex = selection;
                    menuItems[currentSelectedIndex].InToFocus();
                }
            }
        }

        public void LoadInToFocusAction(string text, Action inToFocusAct)
        {
            if (menuItems.Any(x => x.GetText() == text))
            {
                menuItems.First(x => x.GetText() == text).LoadInToFocusAction(inToFocusAct);
            }
        }

        public void LoadInToFocusAction(int itemIndex, Action inToFocusAct)
        {
            if (itemIndex < menuItems.Count && itemIndex >= 0)
            {
                menuItems[itemIndex].LoadInToFocusAction(inToFocusAct);
            }
        }

        public void LoadOutOfFocusAction(string text, Action outOfFocusAct)
        {
            if (menuItems.Any(x => x.GetText() == text))
            {
                menuItems.First(x => x.GetText() == text).LoadOutOfFocusAction(outOfFocusAct);
            }
        }

        public void LoadOutOfFocusAction(int itemIndex, Action outOfFocusAct)
        {
            if (itemIndex < menuItems.Count && itemIndex >= 0)
            {
                menuItems[itemIndex].LoadOutOfFocusAction(outOfFocusAct);
            }
        }

        public void LoadSelectedAction(string text, Action selectedAct)
        {
            if (menuItems.Any(x => x.GetText() == text))
            {
                menuItems.First(x => x.GetText() == text).LoadSelectedAction(selectedAct);
            }
        }

        public void LoadSelectedAction(int itemIndex, Action selectedAct)
        {
            if (itemIndex < menuItems.Count && itemIndex >= 0)
            {
                menuItems[itemIndex].LoadSelectedAction(selectedAct);
            }
        }


        public void AddItem(string text, T returnValue)
        {
            if (text.Length > sizeX)
            {
                text = text.Substring(0, sizeX);
            }
            menuItems.Add(new MenuItem<T>(text, returnValue, color1Default, color2Default));
        }

        public void AddItem(string text, T returnValue, Color color1, Color color2)
        {
            if (text.Length > sizeX)
            {
                text = text.Substring(0, sizeX);
            }
            menuItems.Add(new MenuItem<T>(text, returnValue, color1, color2));
        }

        public bool AtTop()
        {
            return !(currentSelectedIndex > 0);
        }
        public virtual bool Up()
        {
            if (currentSelectedIndex > 0)
            {
                menuItems[currentSelectedIndex].OutOfFocus();
                currentSelectedIndex--;
                menuItems[currentSelectedIndex].InToFocus();
                return true;
            }
            return false;
        }

        public bool AtBottem()
        {
            return !(currentSelectedIndex < menuItems.Count - 1);
        }

        public virtual bool Down()
        {
            if (currentSelectedIndex < menuItems.Count - 1)
            {
                menuItems[currentSelectedIndex].OutOfFocus();
                currentSelectedIndex++;
                menuItems[currentSelectedIndex].InToFocus();
                return true;
            }
            return false;
        }

        public void LeftAlign()
        {
            alignment = Alignment.Left;
        }

        public void CenterAlign()
        {
            alignment = Alignment.Center;
        }

        public void RightAlign()
        {
            alignment = Alignment.Right;
        }

        public void SetAlignment(Alignment alignment)
        {
            this.alignment = alignment;
        }

        public T Select()
        {
            menuItems[currentSelectedIndex].Selected();
            return menuItems[currentSelectedIndex].GetReturn();
        }

        #endregion

        #region Gets
        public int GetPositionX() => positionX;
        public int GetPositionY() => positionY;
        public int GetSizeX() => sizeX;
        public Alignment GetAlignment() => alignment;
        public List<MenuItem<T>> GetMenuItems() => menuItems;
        public int GetCurrentSelectedIndex() => currentSelectedIndex;
        public int GetTotalItemNumber() => menuItems.Count;
        public T GetReturn() => menuItems[currentSelectedIndex].GetReturn();

        #endregion
        public virtual void Print()
        {
            Renderer.PrintMenu(this);
        }


    }
}

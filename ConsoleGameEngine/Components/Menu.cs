using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameEngine.Components
{
    public class Menu<T>
    {
        int positionX, positionY, sizeX;
        Color color1Default = Color.White, color2Default = Color.Black;
        public Alignment alignment;

        List<MenuItem<T>> menuItems = new List<MenuItem<T>>();

        int currentSelection = 0;

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
            : this(positionX, positionY, sizeX,  alignment)
        {
            this.color1Default = color1Default;
            this.color2Default = color2Default;
        }

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
                if (currentSelection != selection)
                {
                    currentSelection = selection;
                    menuItems[currentSelection].InToFocus();
                }
            }
        }

        public void AddItem(string text, T returnValue)
        {
            if(text.Length > sizeX)
            {
                text.Substring(0, sizeX);
            }
            menuItems.Add(new MenuItem<T>(text, returnValue, color1Default, color2Default));
        }

        public void AddItem(string text, T returnValue, Color color1, Color color2)
        {
            menuItems.Add(new MenuItem<T>(text, returnValue, color1, color2));
        }

        public void Up()
        {
            if (currentSelection > 0)
            {
                menuItems[currentSelection].OutOfFocus();
                currentSelection--;
                menuItems[currentSelection].InToFocus();
            }
        }

        public void Down()
        {
            if (currentSelection < menuItems.Count - 1)
            {
                menuItems[currentSelection].OutOfFocus();
                currentSelection++;
                menuItems[currentSelection].InToFocus();
            }
        }

        public T Select()
        {
            menuItems[currentSelection].Selected();
            return menuItems[currentSelection].GetReturn();
        }
    }
}

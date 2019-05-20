using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameEngine.Components
{
    public class MenuItem<T>
    {
        T returnValue;
        string text;
        bool isInFocus = false;
        Color color1 = Color.White, color2 = Color.Black;

        public MenuItem(string text, T returnValue)
        {
            this.returnValue = returnValue;
            this.text = text;
        }

        public MenuItem(string text, T returnValue, Color color1, Color color2)
            :this(text,returnValue)
        {
            this.color1 = color1;
            this.color2 = color2;
        }

        public T GetReturn()
        {
            return returnValue;
        }

        public void InToFocus()
        {

        }

        public void OutOfFocus()
        {

        }

        public void Selected()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameEngine.Components
{
    public class Number
    {
        int number;
        int totalDigit;
        int max = int.MaxValue;
        int min = 0;
        int positionX, positionY;
        Color color1 = Color.White, color2 = Color.Black;
        int currentSelection = 0;

        #region Constructor
        public Number(int positionX, int positionY, int totalDigit, int max = int.MaxValue, int min = 0)
        {
            this.positionX = positionX;
            this.positionY = positionY;
            this.totalDigit = totalDigit;
            number = 0;
            this.max = Math.Min((int)Math.Pow(10, totalDigit) - 1, max);
            this.min = min > 0 ? min : 0;
            currentSelection = totalDigit - 1;
        }

        public Number(int positionX, int positionY, int totalDigit, Color color1, Color color2, int max = int.MaxValue, int min = 0)
            : this(positionX, positionY, totalDigit, max, min)
        {
            this.color1 = color1;
            this.color2 = color2;
        }

        #endregion

        #region Manipulation
        public void SetDigit(int totalDigit)
        {
            this.totalDigit = totalDigit;
            max = (int)Math.Pow(10, totalDigit - 1) - 1;
            number = Math.Max(number, max);
        }

        public void SetMax(int max)
        {
            this.max = Math.Min(max, (int)Math.Pow(10, totalDigit - 1) - 1);
        }

        public void SetMin(int min)
        {
            this.min = min > 0 ? min : 0;
        }

        public void Up()
        {
            number += (int)Math.Pow(10, currentSelection);
            // make sure the number does not exceed the max.
            number = number < max ? number : max;
        }

        public void Down()
        {
            number -= (int)Math.Pow(10, currentSelection);
            // make sure the number does not get lower than min.
            number = number > min ? number : min;
        }

        public void Left()
        {
            if (currentSelection < totalDigit)
            {
                currentSelection += 1;
            }
        }

        public void Right()
        {
            if (currentSelection > 0)
            {
                currentSelection -= 1;
            }
        }
        #endregion

        #region Gets

        public int this[int digit]
        {
            get
            {
                return (number % (int)Math.Pow(10, digit + 1)) / (int)Math.Pow(10, digit);
            }
        }

        public int GetPositionX() => positionX;
        public int GetPositionY() => positionY;
        public Color GetColor1() => color1;
        public Color GetColor2() => color2;
        public int GetNumber() => number;
        public int GetTotalDigit() => totalDigit;
        public int GetCurrentSelection() => currentSelection;
        #endregion

        public void Print()
        {
            Renderer.PrintNumber(this);
        }
    }
}

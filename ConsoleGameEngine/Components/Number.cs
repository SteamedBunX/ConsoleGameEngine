using System;
using System.Collections.Generic;
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
        int currentSelection = 0;

        #region Constructor
        public Number(int totalDigit, int max = int.MaxValue, int min = 0)
        {
            this.totalDigit = totalDigit;
            number = 0;
            this.max = Math.Min((int)Math.Pow(10, totalDigit - 1) - 1, max);
            this.min = min > 0 ? min : 0;
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
            number = number > min ? number : max;
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

        public int GetNumber() => number;
        public int GetTotalDigit() => totalDigit;
        public int GetCurrentSelection => currentSelection;
        #endregion

        public void Print()
        {

        }
    }
}

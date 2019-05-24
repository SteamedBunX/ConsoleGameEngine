using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameEngine.Components
{
    public class Digit
    {
        byte number;
        byte cap;

        #region Constructor

        public Digit(byte number = 0, byte cap = 9)
        {
            this.number = number;
            this.cap = cap;
        }

        #endregion

        #region Manipulation

        public bool Up()
        {
            if (number >= cap)
            {
                return true;
            }
            number++;
            return false;
        }

        public bool Down()
        {
            if (number <= 0)
            {
                return true;
            }
            number--;
            return false;
        }

        #endregion
    }
}

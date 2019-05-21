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
        Color color1 = Color.White, color2 = Color.Black;
        Action inToFocusAct, outOfFocusAct, selectedAct;


        #region Constructor
        public MenuItem(string text, T returnValue)
        {
            this.returnValue = returnValue;
            this.text = text;
        }

        public MenuItem(string text, T returnValue, Color color1, Color color2)
            : this(text, returnValue)
        {
            this.color1 = color1;
            this.color2 = color2;
        }
        #endregion

        #region Manipulation
        public void LoadInToFocusAction(Action inToFocusAct)
        {
            this.inToFocusAct = inToFocusAct;
        }

        public void LoadOutOfFocusAction(Action outOfFocusAct)
        {
            this.outOfFocusAct = outOfFocusAct;
        }

        public void LoadSelectedAction(Action selectedAct)
        {
            this.selectedAct = selectedAct;
        }
        #endregion

        #region Gets

        public Color GetColor1()
        {
            return color1;
        }

        public Color GetColor2()
        {
            return color2;
        }

        public string GetText()
        {
            return text;
        }

        public T GetReturn()
        {
            return returnValue;
        }

        #endregion

        #region Reactions
        public void InToFocus()
        {
            if (inToFocusAct != null)
            {
                inToFocusAct();
            }
        }

        public void OutOfFocus()
        {
            if (outOfFocusAct != null)
            {
                outOfFocusAct();
            }
        }

        public void Selected()
        {
            if (selectedAct != null)
            {
                selectedAct();
            }
        }
        #endregion
    }
}

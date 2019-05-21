using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameEngine.Components
{
    public class FreeStringBundle
    {
        int positionY, positionX;
        int maxTextLength;
        Color tColor = Color.White, bColor = Color.Black;
        Alignment alignment = Alignment.Left;
        List<string> content = new List<string>();

        #region Constructor
        public FreeStringBundle(int positionX, int positionY, int maxTextLength)
        {
            this.positionY = positionY;
            this.positionX = positionX;
            this.maxTextLength = maxTextLength;
        }

        public FreeStringBundle(int positionX, int positionY, int maxTextLength,
                          Color tColorDefault, Color bColorDefault)
                          : this(positionX, positionY, maxTextLength)
        {
            this.tColor = tColorDefault;
            this.bColor = bColorDefault;
        }

        public FreeStringBundle(int positionX, int positionY, int MaxTextLength, Alignment alignmentDefault)
            : this(positionX, positionY, MaxTextLength)
        {
            this.alignment = alignmentDefault;
        }

        public FreeStringBundle(int positionX, int positionY, int maxTextLength,
                           Color tColorDefault, Color bColorDefault, Alignment alignmentDefault)
                           : this(positionX, positionY, maxTextLength, tColorDefault, bColorDefault)
        {
            this.alignment = alignmentDefault;
        }
        #endregion

        #region Manipulation
        public void Move(int xDelta, int yDelta)
        {
            positionY += yDelta;
            positionX += xDelta;
        }

        public void ChangeDefaultTextColor(Color tColorDefault)
        {
            this.tColor = tColorDefault;
        }

        public void ChangeDefaultBackgroundColor(Color bColorDefault)
        {
            this.bColor = bColorDefault;
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

        public void Add(string text)
        {
            if (text.Length <= maxTextLength)
            {
                content.Add(text);
            }
            else
            {
                content.Add(text.Substring(0, maxTextLength));
                this.Add(text.Substring(maxTextLength));
            }
        }

        public void ClearContent()
        {
            content.Clear();
        }

        #endregion

        #region Gets
        public int GetPositionX() => positionX;
        public int GetMaxTextLength() => maxTextLength;
        public int GetPositionY() => positionY;
        public List<string> GetContents() => content;
        public Color GetTextColor() => tColor;
        public Color GetBackgroundColor() => bColor;
        public Alignment GetAlignment() => alignment;
        #endregion

        public void Print()
        {
            Renderer.PrintFreeStringBundle(this);
        }
    }
}

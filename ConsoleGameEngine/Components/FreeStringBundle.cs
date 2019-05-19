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
        public int startRow, startColumn, endColumn;
        public int maxTextSize;
        public Color tColor = Color.White, bColor = Color.Black;
        Alignment alignment = Alignment.Left;
        public List<string> content = new List<string>();

        #region Constructor
        public FreeStringBundle(int row, int leftLimit, int rightLimit)
        {
            startRow = row;
            startColumn = leftLimit;
            endColumn = rightLimit;
            maxTextSize = endColumn - startColumn;
        }

        public FreeStringBundle(int row, int leftLimit, int rightLimit,
                          Color tColorDefault, Color bColorDefault)
                          : this(row, leftLimit, rightLimit)
        {
            this.tColor = tColorDefault;
            this.bColor = bColorDefault;
        }

        public FreeStringBundle(int row, int leftLimit, int rightLimit, Alignment alignmentDefault)
            : this(row, leftLimit, rightLimit)
        {
            this.alignment = alignmentDefault;
        }

        public FreeStringBundle(int row, int leftLimit, int rightLimit,
                           Color tColorDefault, Color bColorDefault, Alignment alignmentDefault)
                           : this(row, leftLimit, rightLimit, tColorDefault, bColorDefault)
        {
            this.alignment = alignmentDefault;
        }
        #endregion

        #region ChangeSetting
        public void Move(int xDelta, int yDelta)
        {
            startRow += yDelta;
            startColumn += xDelta;
            endColumn += xDelta;
        }

        public void ChangeDefaultTextColor(Color tColorDefault)
        {
            this.tColor = tColorDefault;
        }

        public void ChangeDefaultBackgroundColor(Color bColorDefault)
        {
            this.bColor = bColorDefault;
        }
        #endregion
        public void Add(string text)
        {
            if (text.Length <= maxTextSize)
            {
                content.Add(text);
            }
            else
            {
                List<string> truncated = new List<string>();
                for (int i = 0; i < (text.Length - 1) / maxTextSize; i++)
                {
                    content.Add(text.Substring(0, maxTextSize));
                    text = text.Substring(10);
                }
                content.Add(text);
            }
        }

        public void Print()
        {
            Renderer.PrintFreeStringBundle(this);
        }

        public void ClearContent()
        {
            content.Clear();
        }

        #region Gets
        public int GetStartColumn() => startColumn;
        public int GetEndColumn() => endColumn;
        public int GetStartRow() => startRow;
        public List<string> GetContents() => content;
        public Color GetTextColor() => tColor;
        public Color GetBackgroundColor() => bColor;
        public Alignment GetAlignment() => alignment;
        #endregion
    }
}

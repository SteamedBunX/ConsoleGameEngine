using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameEngine.Components
{
    public class FreeString
    {
        Alignment alignment = Alignment.Left;
        string text;
        IntXYPair position;
        Color foregroundColor = Color.White,
            backgroundColor = Color.Black;

        public FreeString(string text, int x, int y)
        {
            this.text = text;
            position = new IntXYPair(x, y);
        }

        public FreeString(string text, int x, int y, Color foregroundColor, Color backgroundColor)
            : this(text, x, y)
        {
            this.SetForegroundColor(foregroundColor);
            this.SetBackgroundColor(backgroundColor);
        }

        public void Print()
        {
            Renderer.PrintFreeString(this);
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

        public void SetForegroundColor(Color foregroundColor)
        {
            this.foregroundColor = foregroundColor;
        }

        public void SetBackgroundColor(Color backgroundColor)
        {
            this.backgroundColor = backgroundColor;
        }

        public IntXYPair GetPositionActual()
        {
            switch (alignment)
            {
                case Alignment.Right:
                    return new IntXYPair(position.GetX() - GetTextLength() + 1,
                        position.GetY());
                case Alignment.Center:
                    return new IntXYPair(position.GetX() - (GetTextLength() - 1) / 2,
                        position.GetY());
                default:
                    return position;
            }
        }

        public string GetText() => text;
        public Color GetForegroundColor() => foregroundColor;
        public Color GetBackgroundColor() => backgroundColor;
        public IntXYPair GetPosition() => position;
        public Alignment GetAlignment() => alignment;
        public int GetTextLength() => text.Length;
    }
}

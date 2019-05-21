using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameEngine
{
    public struct Border
    {
        public int positionX, positionY, sizeX, sizeY;

        #region Constructors
        public Border(IntXYPair position, IntXYPair size)
        {
            positionX = position.x;
            positionY = position.y;
            sizeX = Math.Max(size.x, 2);
            sizeY = Math.Max(size.y, 2);
        }

        public Border(int positionX, int positionY, int sizeX, int sizeY)
        {
            this.positionX = positionX;
            this.positionY = positionY;
            this.sizeX = Math.Max(sizeX, 2);
            this.sizeY = Math.Max(sizeY, 2);
        }

        #endregion

        #region Manipulation
        public void Move(int positionX, int positionY)
        {
            this.positionX += positionX;
            this.positionY += positionY;
        }

        public void MoveTo(int positionX, int positionY)
        {
            this.positionX = positionX;
            this.positionY = positionY;
        }

        #endregion

        public void Print()
        {
            Renderer.PrintBorder(this);
        }

        public void PrintHollow()
        {
            Renderer.PrintHollowBorder(this);
        }
    }
}

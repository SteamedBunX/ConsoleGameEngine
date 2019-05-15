using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameEngine
{


    public struct IntXYPair
    {
        public int x, y;
        public IntXYPair(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int GetX() => x;
        public int GetY() => y;

        public static double operator -(IntXYPair p1, IntXYPair p2)
        {
            return Math.Sqrt(Math.Pow(p1.x - p2.x, 2) + Math.Pow(p1.y - p2.y, 2));
        }

        public static bool operator ==(IntXYPair p1, IntXYPair p2)
        {
            return (p1.x == p2.x && p1.y == p2.y);
        }

        public static bool operator !=(IntXYPair p1, IntXYPair p2)
        {
            return !(p1.x == p2.x && p1.y == p2.y);
        }

        public override bool Equals(object O)
        {
            if (O is IntXYPair p2)
            {
                return (this.x == p2.x && this.y == p2.y);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return x ^ y;
        }

    }

    public struct Border
    {
        public int positionX, positionY, sizeX, sizeY;

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
    }
}

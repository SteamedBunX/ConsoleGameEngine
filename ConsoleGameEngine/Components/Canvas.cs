using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Image = ConsoleGameEngine.Components.Image;

namespace ConsoleGameEngine.Components
{
    public class Canvas
    {
        IntXYPair size;
        IntXYPair position;
        List<Color> colors = new List<Color>();
        int[,] bitmap;

        public Canvas(int sizeX, int sizeY, int positionX, int positionY)
        {
            size = new IntXYPair(sizeX, sizeY);
            position = new IntXYPair(positionX, positionY);
            int[,] bitmap = new int[sizeX,sizeY];
            bitmap.FillArray(0);
        }

        public Canvas(IntXYPair size, IntXYPair position)
        {
            this.size = size;
            this.position = position;
            int[,] bitmap = new int[size.x, size.y];
            bitmap.FillArray(0);
        }

        
    }

    public static class ExtentionMethod
    {
        public static void FillArray(this int[,] array, int num)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = num;
                }
            }
        }
    }
}

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
            bitmap = new int[sizeX, sizeY];
            bitmap.FillArray(0);
        }

        public Canvas(IntXYPair size, IntXYPair position)
        {
            this.size = size;
            this.position = position;
            bitmap = new int[size.x, size.y];
            bitmap.FillArray(0);
        }

        public void Reset()
        {
            colors.Clear();
            bitmap.FillArray(0);
        }

        public void Move(int positionX, int positionY)
        {
            Move(new IntXYPair(positionX, positionY));
        }

        public void Move(IntXYPair position)
        {
            this.position = position;
        }

        public void DrawImage(Image image, IntXYPair position)
        {
            //load the colors, and keep track of the color conversion
            Dictionary<int, int> colorMap = new Dictionary<int, int>
            {
                // black and white
                [15] = 15,
                [16] = 16
            };
            int initialIndex = colors.Count();
            for (int i = 0; i <= image.Colors.Count; i++)
            {
                if (colors.Any(x => x.ToArgb() == image.Colors[i].ToArgb()))
                {
                    colorMap[i] = colors.FindIndex(x => x.ToArgb() == image.Colors[i].ToArgb());
                }
                else
                {
                    colors.Add(image.Colors[i]);
                    colorMap[i] = colors.Count - 1;
                }
            }



            int rightLimit = Math.Min(bitmap.GetLength(1), position.x + image.Bitmap[0].Length) - position.x;
            int bottemLimit = Math.Min(bitmap.GetLength(0), position.y + image.Bitmap.Count) - position.y;
            for (int y = 0; y < bottemLimit; y++)
            {
                for (int x = 0; x < rightLimit; x++)
                {
                    char currentPixel = image.Bitmap[y][x];
                    if (currentPixel != 'T')
                    {
                        if (currentPixel == 'W')
                        {
                            bitmap[x, y] = 15;
                        }
                        if (currentPixel == 'Z')
                        {
                            bitmap[x, y] = 16;
                        }
                        bitmap[x, y] = colorMap[Convert.ToInt32(image.Bitmap[y][x].ToString())];
                    }

                }
            }
        }

        public void DrawImage(Image image, int x, int y)
        {
            DrawImage(image, new IntXYPair(x, y));
        }

        public IntXYPair GetPosition()
        {
            return position;
        }

        public List<Color> GetColors()
        {
            return colors;
        }

        public int[,] GetBitmap()
        {
            return bitmap;
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

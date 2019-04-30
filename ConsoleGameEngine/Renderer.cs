﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameEngine.Components;
using Console = Colorful.Console;
using System.Drawing;
using Image = ConsoleGameEngine.Components.Image;

namespace ConsoleGameEngine
{
    public static class Renderer
    {

        public static void PrintCanvas(Canvas canvas)
        {
            int[,] bitmap = canvas.GetBitmap();
            List<Color> colors = canvas.GetColors();
            int row = canvas.GetPosition().y;
            for (int y = 0; y < bitmap.GetLength(0); y += 2)
            {
                Console.SetCursorPosition(canvas.GetPosition().x, row);

                for (int x = 0; x < bitmap.GetLength(1); x++)
                {
                    int nextColorIndex = bitmap[x, y];
                    SetForeground(nextColorIndex, colors);

                    if (y < bitmap.GetLength(0))
                    {
                        nextColorIndex = bitmap[x, y + 1];
                        SetBackground(nextColorIndex, colors);
                    }
                    else
                    {
                        System.Console.BackgroundColor = ConsoleColor.Black;
                    }
                    // A special character recognized by console that covers excactly the top half of the space
                    // it's also very square.
                    Console.Write("▀");
                }
                row++;
            }
        }

        public static void PrintImage(Image image, int x, int y)
        {
            PrintImage(image, new IntXYPair(x, y));
        }

        public static void PrintImage(Image image, IntXYPair position)
        {
            // isolate the Y for incrementing as each line is printed
            int row = position.y;
            for (int i = 0; i < image.Bitmap.Count; i += 2)
            {
                Console.SetCursorPosition(position.x, row);
                char[] nextLine1 = image.Bitmap[i].ToCharArray();
                char[] nextLine2;

                if (i + 1 >= image.Bitmap.Count)
                {
                    nextLine2 = new string('Z', image.Bitmap[i].Count()).ToCharArray();
                }
                else
                {
                    nextLine2 = image.Bitmap[i + 1].ToCharArray();
                }

                for (int j = 0; j < nextLine1.Length; j++)
                {
                    string nextPixel = nextLine1[j] + "";
                    int nextColorIndex;
                    nextColorIndex = GetPixelCode(nextPixel);
                    SetForeground(nextColorIndex, image.Colors);

                    nextPixel = nextLine2[j] + "";
                    nextColorIndex = GetPixelCode(nextPixel);
                    SetBackground(nextColorIndex, image.Colors);
                    // A special character recognized by console that covers excactly the top half of the space
                    // it's also very square.
                    Console.Write("▀");
                }

                row++;
            }
        }

        private static int GetPixelCode(string nextPixel)
        {
            if (nextPixel == "T" || nextPixel == "Z")
            {
                return 16;
            }
            if (nextPixel == "W")
            {
                return 15;
            }
            return Convert.ToInt32(nextPixel, 16);
        }


        // since colors are represented by hex number inside the "bitmap"s , they need to be read accordingly
        // with the actual list of color.
        public static void SetForeground(int colorIndex, List<Color> colors)
        {
            if (colorIndex == 16)
            {
                System.Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (colorIndex == 15)
            {
                System.Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = colors[colorIndex];
            }
        }

        public static void SetBackground(int colorIndex, List<Color> colors)
        {
            if (colorIndex == 16)
            {
                System.Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (colorIndex == 15)
            {
                System.Console.BackgroundColor = ConsoleColor.White;
            }
            else
            {
                Console.BackgroundColor = colors[colorIndex];
            }
        }

        public static void ResetConsoleColor()
        {
            Console.ReplaceAllColorsWithDefaults();
        }
    }
}

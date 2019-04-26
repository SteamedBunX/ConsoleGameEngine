using System;
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

        public static void PrintImage(Image image, int x, int y)
        {
            PrintImage(image, new IntXYPair(x, y));
        }

        public static void PrintImage(Image image, IntXYPair position)
        {
            int row = position.y;
            foreach (string line in image.Bitmap)
            {
                Console.SetCursorPosition(position.x, row);
                char[] nextLine = line.ToCharArray();
                for (int i = 0; i < nextLine.Length; i += 2)
                {
                    string nextPixel = nextLine[i] + "";
                    int nextColorIndex = Convert.ToInt32(nextPixel, 16);
                    setForeground(nextColorIndex, image.Colors);
                    nextPixel = nextLine[i + 1] + "";
                    nextColorIndex = Convert.ToInt32(nextPixel, 16);
                    setBackground(nextColorIndex, image.Colors);
                    Console.Write("▀");
                }
                row++;
            }
        }

        public static void setForeground(int colorIndex, List<Color> colors)
        {
            if (colorIndex == 0)
            {
                Console.ForegroundColor = Color.FromArgb(12, 12, 12);
            }
            else if (colorIndex == 15)
            {
                Console.ForegroundColor = Color.White;
            }
            else
            {
                Console.ForegroundColor = colors[colorIndex - 1];
            }
        }

        public static void setBackground(int colorIndex, List<Color> colors)
        {
            if (colorIndex == 0)
            {
                Console.BackgroundColor = Color.FromArgb(12, 12, 12);
            }
            else if (colorIndex == 15)
            {
                Console.BackgroundColor = Color.White;
            }
            else
            {
                Console.BackgroundColor = colors[colorIndex - 1];
            }
        }
    }
}

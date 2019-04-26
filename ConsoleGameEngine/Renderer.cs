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
            // isolate the Y for incrementing as each line is printed
            int row = position.y;
            foreach (string line in image.Bitmap)
            {
                //go to the starting point
                Console.SetCursorPosition(position.x, row);
                char[] nextLine = line.ToCharArray();

                //pixels are read by 2, corresponding to the top half and the bottem halve of the space.
                for (int i = 0; i < nextLine.Length; i += 2)
                {
                    string nextPixel = nextLine[i] + "";
                    int nextColorIndex = Convert.ToInt32(nextPixel, 16);
                    setForeground(nextColorIndex, image.Colors);
                    nextPixel = nextLine[i + 1] + "";
                    nextColorIndex = Convert.ToInt32(nextPixel, 16);
                    setBackground(nextColorIndex, image.Colors);
                    // A special character recognized by console that covers excactly the top half of the space
                    // it's also very square.
                    Console.Write("▀");
                }
                row++;
            }
        }


        // since colors are represented by hex number inside the "bitmap"s , they need to be read accordingly
        // with the actual list of color.
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

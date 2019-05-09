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
        // Image related rendering methods
        public static void PrintCanvas(Canvas canvas)
        {
            int[,] bitmap = canvas.GetBitmap();
            List<Color> colors = canvas.GetColors();
            int leftLimit = Math.Max(0, 0 - canvas.GetPosition().x);
            int topLimit = Math.Max(0, 0 - canvas.GetPosition().y);
            int row = Math.Max(canvas.GetPosition().y, 0);
            if (canvas.GetPosition().x < Console.BufferWidth)
            {
                for (int y = topLimit; y < bitmap.GetLength(0); y += 2)
                {
                    if (row < Console.WindowHeight)
                    {
                        Console.SetCursorPosition(Math.Max(0, canvas.GetPosition().x), row);

                        for (int x = leftLimit; x < bitmap.GetLength(1); x++)
                        {
                            if (Console.CursorTop == row)
                            {
                                int nextColorIndex = bitmap[x, y];
                                SetForeground(nextColorIndex, colors);

                                if (y + 1 < bitmap.GetLength(0))
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
                        }
                    }
                    row++;
                }
            }
            System.Console.BackgroundColor = ConsoleColor.Black;
            System.Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintImage(Image image, int x, int y)
        {
            PrintImage(image, new IntXYPair(x, y));
        }

        public static void PrintImage(Image image, IntXYPair position)
        {
            // isolate the Y for incrementing as each line is printed

            if (position.x < Console.BufferWidth && position.x + image.Bitmap[0].Length > 0
                && position.y < Console.BufferHeight && position.getY() + image.Bitmap.Count > 0)
            {
                int leftLimit = Math.Max(0, 0 - position.x);
                int topLimit = Math.Max(0, 0 - position.y);
                int row = Math.Max(position.y, 0);

                for (int i = topLimit; i < image.Bitmap.Count; i += 2)
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

                    for (int j = leftLimit; j < Math.Min(nextLine1.Length, Console.BufferWidth - position.y); j++)
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
                System.Console.BackgroundColor = ConsoleColor.Black;
                System.Console.ForegroundColor = ConsoleColor.White;
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


        // Menu related rendering methods


        public static void PrintBorder(Border border)
        {
            int bufferLimitY = Console.BufferHeight - 1;
            if (border.positionX < Console.BufferWidth && border.positionX + border.sizeX >= 0 &&
                border.positionY < bufferLimitY && border.positionY + border.sizeY >= 0)
            {
                string ceilingAndFloor = "";
                string middleSpace = "";

                int leftLimit = Math.Max(0, 0 - border.positionX);
                int topLimit = Math.Max(0, 0 - border.positionY);
                int row = Math.Max(border.positionY, 0);

                for (int i = 0; i < border.sizeX - 2; i++)
                {
                    ceilingAndFloor += "═";
                    middleSpace += " ";
                }
                string ceiling = $"╔{ceilingAndFloor}╗";
                string floor = $"╚{ceilingAndFloor}╝";
                string middle = $"║{middleSpace}║";

                //trim the string based on the actual size
                if (border.positionX < 0)
                {
                    ceiling = ceiling.Substring(0 - border.positionX);
                    floor = floor.Substring(0 - border.positionX);
                    middle = middle.Substring(0 - border.positionX);
                }
                if (border.positionX + border.sizeX > Console.BufferWidth)
                {
                    ceiling = ceiling.Substring(0, Console.BufferWidth - border.positionX);
                    floor = floor.Substring(0, Console.BufferWidth - border.positionX);
                    middle = middle.Substring(0, Console.BufferWidth - border.positionX);
                }

                for (int y = topLimit; y < border.sizeY && y + border.positionY < bufferLimitY; y++)
                {

                    Console.SetCursorPosition(Math.Max(0, border.positionX), border.positionY + y);

                    if (y == 0)
                    {
                        Console.Write(ceiling);
                    }
                    else if (y == border.sizeY - 1)
                    {
                        Console.Write(floor);
                    }
                    else
                    {
                        Console.Write(middle);
                    }
                }
                Console.CursorVisible = false;
            }
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

        public static void SetForeground(Color color)
        {
            if (color.ToArgb() == Color.Black.ToArgb())
            {
                System.Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (color.ToArgb() == Color.White.ToArgb())
            {
                System.Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = color;
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

        public static void SetBackground(Color color)
        {
            if (color.ToArgb() == Color.Black.ToArgb())
            {
                System.Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (color.ToArgb() == Color.White.ToArgb())
            {
                System.Console.BackgroundColor = ConsoleColor.White;
            }
            else
            {
                Console.BackgroundColor = color;
            }
        }

        public static void ResetConsoleColor()
        {
            Console.ReplaceAllColorsWithDefaults();
        }

    }
}
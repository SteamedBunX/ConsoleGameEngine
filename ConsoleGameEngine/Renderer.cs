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
        #region ImageGraphic
        public static void PrintCanvas(Canvas canvas)
        {
            if (IsInScope(canvas.GetPosition(), canvas.GetBitmap().GetLength(0), canvas.GetBitmap().GetLength(1)))
            {
                int[,] bitmap = canvas.GetBitmap();
                List<Color> colors = canvas.GetColors();

                int topLimit = Math.Max(0, 0 - canvas.GetPosition().y);
                int row = Math.Max(canvas.GetPosition().y, 0);

                for (int y = topLimit; y < bitmap.GetLength(1); y += 2)
                {
                    for (int x = 0; x < bitmap.GetLength(0); x++)
                    {
                        int nextColorIndex = bitmap[x, y];
                        SetForeground(nextColorIndex, colors);

                        if (y + 1 < bitmap.GetLength(1))
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
                        PrintComponent("▀", x + canvas.GetPosition().GetX(), row);

                    }
                    row++;
                }
                System.Console.BackgroundColor = ConsoleColor.Black;
                System.Console.ForegroundColor = ConsoleColor.White;
            }
            CleanUp();
        }

        public static void PrintImage(Image image, int x, int y)
        {
            PrintImage(image, new IntXYPair(x, y));
        }

        public static void PrintImage(Image image, IntXYPair position)
        {
            // isolate the Y for incrementing as each line is printed
            if (IsInScope(position, image.Bitmap[0].Length, image.Bitmap.Count))
            {
                int topLimit = Math.Max(0, 0 - position.y);
                int row = Math.Max(position.y, 0);

                for (int y = topLimit; y < image.Bitmap.Count; y += 2)
                {
                    char[] nextLine1 = image.Bitmap[y].ToCharArray();
                    char[] nextLine2;

                    if (y + 1 >= image.Bitmap.Count)
                    {
                        nextLine2 = new string('Z', image.Bitmap[y].Count()).ToCharArray();
                    }
                    else
                    {
                        nextLine2 = image.Bitmap[y + 1].ToCharArray();
                    }

                    for (int x = 0; x < Math.Min(nextLine1.Length, Console.BufferWidth - position.y); x++)
                    {
                        string nextPixel = nextLine1[x] + "";
                        int nextColorIndex;
                        nextColorIndex = GetPixelCode(nextPixel);
                        SetForeground(nextColorIndex, image.Colors);

                        nextPixel = nextLine2[x] + "";
                        nextColorIndex = GetPixelCode(nextPixel);
                        SetBackground(nextColorIndex, image.Colors);
                        // A special character recognized by console that covers excactly the top half of the space
                        // it's also very square.
                        PrintComponent("▀", x + position.x, row);
                    }

                    row++;
                }
                System.Console.BackgroundColor = ConsoleColor.Black;
                System.Console.ForegroundColor = ConsoleColor.White;
            }
            CleanUp();
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
        #endregion

        // Basic Texts

        #region FreeString
        public static void PrintFreeString(FreeString freeString)
        {
            SetForeground(freeString.GetForegroundColor());
            SetBackground(freeString.GetBackgroundColor());
            PrintComponent(freeString.GetText(), freeString.GetPositionActual());
        }

        public static void PrintFreeStringBundle(FreeStringBundle bundle)
        {
            int columnPoint;
            switch (bundle.GetAlignment())
            {
                case Alignment.Left:
                    columnPoint = bundle.GetPositionX();
                    break;
                case Alignment.Right:
                    columnPoint = bundle.GetPositionX() + bundle.GetMaxTextLength() - 1;
                    break;
                default:
                    columnPoint = (bundle.GetMaxTextLength()) / 2 + bundle.GetPositionX() - 1;
                    break;
            }
            int currentRow = bundle.GetPositionY();
            foreach (string s in bundle.GetContents())
            {
                FreeString current = new FreeString(s, columnPoint, currentRow,
                    bundle.GetTextColor(), bundle.GetBackgroundColor(),
                    bundle.GetAlignment());
                PrintFreeString(current);
                currentRow++;
            }

        }
        #endregion

        // Menu related rendering methods

        #region Border
        public static void PrintBorder(Border border)
        {
            int bufferLimitY = Console.BufferHeight - 1;
            if (IsInScope(border.positionX, border.positionY, border.sizeX, border.sizeY))
            {
                int topLimit = Math.Max(0, 0 - border.positionY);

                string ceilingAndFloor = new string('═', border.sizeX - 2);
                string middleSpace = new string(' ', border.sizeX - 2);

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
            }
            CleanUp();
        }

        public static void PrintBorder(Border border, Color color)
        {
            SetForeground(color);
            PrintBorder(border);
        }

        public static void PrintHollowBorder(Border border)
        {
            if (IsInScope(border.positionX, border.positionY, border.sizeX, border.sizeY))
            {
                string ceilingAndFloor = new string('═', border.sizeX - 2);
                int x2 = border.positionX + border.sizeX - 2;

                string ceiling = $"╔{ceilingAndFloor}╗";
                string floor = $"╚{ceilingAndFloor}╝";

                PrintComponent(ceiling, border.positionX, border.positionY);
                for (int yAlt = 0; yAlt < border.sizeY - 2; yAlt++)
                {
                    int row = border.positionY + 1 + yAlt;
                    PrintComponent("║", border.positionX, row);
                    PrintComponent("║", border.positionX + border.sizeX - 1, row);
                }
                PrintComponent(floor, border.positionX, border.positionY + border.sizeY - 1);
            }
            CleanUp();
        }

        public static void PrintHollowBorder(Border border, Color color)
        {
            SetForeground(color);
            PrintHollowBorder(border);
        }
        #endregion

        #region Menu
        public static void PrintMenu<T>(Menu<T> menu)
        {
            int currentRow = menu.GetPositionY();
            int positionX = menu.GetPositionX();
            switch (menu.GetAlignment())
            {
                case Alignment.Left:
                    break;
                case Alignment.Right:
                    positionX = positionX + menu.GetSizeX() - 1;
                    break;
                default:
                    positionX = positionX + (menu.GetSizeX() / 2 - 1);
                    break;
            }
            List<MenuItem<T>> menuitems = menu.GetMenuItems();
            for (int i = 0; i < menuitems.Count; i++)
            {
                if (i == menu.GetCurrentSelection())
                {
                    PrintFreeString(new FreeString(menuitems[i].GetText(), positionX, currentRow,
                        menuitems[i].GetColor2(), menuitems[i].GetColor1(), menu.GetAlignment()));
                }
                else
                {
                    PrintFreeString(new FreeString(menuitems[i].GetText(), positionX, currentRow,
                       menuitems[i].GetColor1(), menuitems[i].GetColor2(), menu.GetAlignment()));
                }
                currentRow++;
            }
            CleanUp();
        }

        #endregion

        // Rendering Special "Number" Components

        #region Numbers

        #endregion

        // Since colors are represented by hex number inside the "bitmap"s , they need to be read accordingly
        // with the actual list of color.
        // black will be printed with consolecolor black instead of true black
        // white will be printed with consolecolor write instead of true white
        #region BasicMethods

        static void PrintComponent(string component, int x, int y)
        {
            int stringLength = component.Length;
            // It's intentional not to print anything at the last line of buffer
            // if console prints anything at the last buffer and right hand corner
            // it would automatically goes to next line and push the entire page up
            if (y >= 0
                && y < Console.BufferHeight - 1
                && x < Console.BufferWidth
                && x + stringLength > 0)
            {
                int xActual = Math.Max(0, x);
                //truncate the string based on it's X position
                if (x + component.Length > Console.BufferWidth)
                {
                    int alternativeSize = Console.BufferWidth - x;
                    component = component.Substring(0, alternativeSize);
                }
                if (x < 0)
                {
                    int alternativeStart = 0 - x;
                    component = component.Substring(alternativeStart);
                }
                Console.SetCursorPosition(xActual, y);
                Console.Write(component);
            }
        }

        static void PrintComponent(string component, IntXYPair position)
        {
            PrintComponent(component, position.x, position.y);
        }

        static bool IsInScope(IntXYPair position, IntXYPair size)
        {
            return IsInScope(position.GetX(), position.GetY(), size.GetX(), size.GetY());
        }

        static bool IsInScope(int positionX, int positionY, IntXYPair size)
        {
            return IsInScope(positionX, positionY, size.GetX(), size.GetY());
        }

        static bool IsInScope(IntXYPair position, int sizeX, int sizeY)
        {
            return IsInScope(position.GetX(), position.GetY(), sizeX, sizeY);
        }

        static bool IsInScope(int positionX, int positionY, int sizeX, int sizeY)
        {
            int bufferLimitLeft = 0;
            int bufferLimitRight = Console.BufferWidth;
            int bufferLimitFloor = Console.BufferHeight - 1;
            int bufferLimitCieling = 0;
            if (positionX < bufferLimitRight
                && positionX + sizeX > bufferLimitLeft
                && positionY < bufferLimitFloor
                && positionY + sizeY > bufferLimitCieling)
            {
                return true;
            }
            return false;
        }

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

        public static void CleanUp()
        {
            Console.CursorVisible = false;
            SetBackground(Color.Black);
        }
        #endregion
    }
}
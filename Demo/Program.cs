using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameEngine.Components;
using ConsoleGameEngine;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            //p.CanvasDemo();
            //p.ImageDemo();
            p.BorderDemo();
        }

        public void ImageDemo()
        {
            ComponentHandler cHandler = new ComponentHandler();
            string imageFolderPath = Environment.CurrentDirectory + @"\Images\";
            cHandler.LoadImages(imageFolderPath);

            IntXYPair pikachuPosition = new IntXYPair(5, 5);
            bool exit = false;
            Console.CursorVisible = false;
            while (!exit)
            {
                Console.Clear();
                cHandler.PrintImage("Pikachu", pikachuPosition);
                var input = Console.ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.Escape:
                        exit = true;
                        break;
                    case ConsoleKey.LeftArrow:
                        pikachuPosition.x--;
                        break;
                    case ConsoleKey.UpArrow:
                        pikachuPosition.y--;
                        break;
                    case ConsoleKey.RightArrow:
                        pikachuPosition.x++;
                        break;
                    case ConsoleKey.DownArrow:
                        pikachuPosition.y++;
                        break;
                }
            }
        }

        public void CanvasDemo()
        {
            ComponentHandler cHandler = new ComponentHandler();
            string imageFolderPath = Environment.CurrentDirectory + @"\Images\";
            cHandler.LoadImages(imageFolderPath);
            bool exit = false;

            IntXYPair canvasPosition = new IntXYPair(5, 5);
            IntXYPair pikachuPosition = new IntXYPair(5, 5);
            cHandler.AddCanvas("BaseCanvas", new IntXYPair(20, 20), canvasPosition);

            Console.CursorVisible = false;

            while (!exit)
            {
                cHandler.ClearCanvas("BaseCanvas");
                cHandler.MoveCanvas("BaseCanvas", canvasPosition);
                cHandler.DrawToCanvas("BaseCanvas", "Pikachu", pikachuPosition);
                Console.Clear();
                cHandler.PrintCanvas("BaseCanvas");
                var input = Console.ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.Escape:
                        exit = true;
                        break;
                    case ConsoleKey.LeftArrow:
                        pikachuPosition.x--;
                        break;
                    case ConsoleKey.UpArrow:
                        pikachuPosition.y--;
                        break;
                    case ConsoleKey.RightArrow:
                        pikachuPosition.x++;
                        break;
                    case ConsoleKey.DownArrow:
                        pikachuPosition.y++;
                        break;

                    case ConsoleKey.A:
                        canvasPosition.x--;
                        break;
                    case ConsoleKey.D:
                        canvasPosition.x++;
                        break;
                    case ConsoleKey.S:
                        canvasPosition.y++;
                        break;
                    case ConsoleKey.W:
                        canvasPosition.y--;
                        break;

                    default:
                        break;
                }

            }
        }

        enum Mode { Filled, Hollow }
        public void BorderDemo()
        {
            Border border = new Border(-1, -2, 40, 20);
            Mode mode = Mode.Filled;
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine(new string('O', 3360));
                Console.Write("Press C to change between hollow and filled BorderBox");
                if (mode == Mode.Hollow)
                {
                    Renderer.PrintHollowBorder(border);
                }
                else
                {
                    Renderer.PrintBorder(border);
                }
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Escape:
                        exit = true;
                        break;
                    case ConsoleKey.C:
                        mode = mode == Mode.Hollow ? Mode.Filled : Mode.Hollow;
                        break;
                    case ConsoleKey.LeftArrow:
                        border.Move(-1, 0);
                        break;
                    case ConsoleKey.UpArrow:
                        border.Move(0, -1);
                        break;
                    case ConsoleKey.RightArrow:
                        border.Move(1, 0);
                        break;
                    case ConsoleKey.DownArrow:
                        border.Move(0, 1);
                        break;
                }
                Console.Clear();
            }
        }
    }
}

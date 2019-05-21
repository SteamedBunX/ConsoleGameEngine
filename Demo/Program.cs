﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameEngine.Components;
using ConsoleGameEngine;
using System.Drawing;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            //p.CanvasDemo();
            //p.ImageDemo();
            //p.BorderDemo();
            //p.FreeStringDemo();
            //p.FreeStringBundleDemo();
            p.MenuDemo();
        }

        public void DemoMainPage()
        {

        }

        public void MenuDemo()
        {
            ComponentHandler cHandler = new ComponentHandler();
            string imageFolderPath = Environment.CurrentDirectory + @"\Images\";
            cHandler.LoadImages(imageFolderPath);

            Menu<int> menu = new Menu<int>(30, 10, 20, Color.Green, Color.Black);

            menu.AddItem("1", 0);
            menu.AddItem("2", 1);
            menu.AddItem("3rd one is longer the the max length", 2);
            menu.AddItem("4. Different Color", 3, Color.Red, Color.Blue);
            menu.AddItem("5", 4);
            menu.AddItem("Exit", 5);
            menu.LoadInToFocusAction("1", PrintOnePikachu);
            menu.LoadInToFocusAction(1, PrintTwoPikachu);
            FreeString guide = new FreeString("Q | LeftAlign, W | CenterAlign, E | RightAlign", 5, 20);
            bool exit = false;
            while (!exit)
            {
                guide.Print();
                menu.Print();
                Renderer.SetBackground(Color.Black);
                ConsoleKey switcher = Console.ReadKey().Key;
                Console.Clear();
                switch (switcher)
                {
                    case ConsoleKey.Enter:
                        if (menu.GetReturn() == 5)
                        {
                            exit = true;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        menu.Up();
                        break;
                    case ConsoleKey.DownArrow:
                        menu.Down();
                        break;
                    case ConsoleKey.Q:
                        menu.LeftAlign();
                        break;
                    case ConsoleKey.W:
                        menu.CenterAlign();
                        break;
                    case ConsoleKey.E:
                        menu.RightAlign();
                        break;
                }
            }

            void PrintOnePikachu()
            {
                cHandler.PrintImage("Pikachu", 5, 5);
            }

            void PrintTwoPikachu()
            {
                cHandler.PrintImage("Pikachu", 5, 5);
                cHandler.PrintImage("Pikachu", 50, 5);
            }
        }

        public void FreeStringDemo()
        {
            IntXYPair textPosition = new IntXYPair(30, 10);
            FreeString freeString = new FreeString("Hello World!", textPosition, Color.Black, Color.Green);
            Border border = new Border(freeString.GetPosition().GetX() - freeString.GetTextLength()
                , freeString.GetPosition().GetY() - 1, freeString.GetTextLength() * 2 + 1, 3);
            bool exit = false;
            while (!exit)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.SetCursorPosition(10, 20);
                Console.Write("Q | LeftAlign, W | CenterAlign, E | RightAlign");
                border.Print();
                freeString.Print();
                var input = Console.ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.Escape:
                        exit = true;
                        break;
                    case ConsoleKey.LeftArrow:
                        freeString.Move(-1, 0);
                        border.Move(-1, 0);
                        break;
                    case ConsoleKey.UpArrow:
                        freeString.Move(0, -1);
                        border.Move(0, -1);
                        break;
                    case ConsoleKey.RightArrow:
                        freeString.Move(1, 0);
                        border.Move(1, 0);
                        break;
                    case ConsoleKey.DownArrow:
                        freeString.Move(0, 1);
                        border.Move(0, 1);
                        break;
                    case ConsoleKey.Q:
                        freeString.LeftAlign();
                        break;
                    case ConsoleKey.W:
                        freeString.CenterAlign();
                        break;
                    case ConsoleKey.E:
                        freeString.RightAlign();
                        break;
                }

            }
        }

        public void FreeStringBundleDemo()
        {
            FreeStringBundle fsBundle = new FreeStringBundle(30, 5, 50, Color.Black, Color.Green, Alignment.Center);
            Border border = new Border(fsBundle.GetPositionX() - 1
                , fsBundle.GetPositionY() - 1, fsBundle.GetMaxTextLength() + 2, 10);
            fsBundle.Add("FirstLine");
            fsBundle.Add("This Line exceed the 20 character limit and will be warped to next line.");
            fsBundle.Add("Third Imput but in fourth line");
            fsBundle.Add("This Line Has Exactly 50 characters.##############");
            fsBundle.Add("This Line Has Exactly 49 characters.#############");
            fsBundle.Add("This Line Has Exactly 51 characters.###############");

            bool exit = false;
            while (!exit)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.SetCursorPosition(10, 20);
                Console.Write("Q | LeftAlign, W | CenterAlign, E | RightAlign");
                border.Print();
                fsBundle.Print();
                var input = Console.ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.Escape:
                        exit = true;
                        break;
                    case ConsoleKey.LeftArrow:
                        fsBundle.Move(-1, 0);
                        border.Move(-1, 0);
                        break;
                    case ConsoleKey.UpArrow:
                        fsBundle.Move(0, -1);
                        border.Move(0, -1);
                        break;
                    case ConsoleKey.RightArrow:
                        fsBundle.Move(1, 0);
                        border.Move(1, 0);
                        break;
                    case ConsoleKey.DownArrow:
                        fsBundle.Move(0, 1);
                        border.Move(0, 1);
                        break;
                    case ConsoleKey.Q:
                        fsBundle.LeftAlign();
                        break;
                    case ConsoleKey.W:
                        fsBundle.CenterAlign();
                        break;
                    case ConsoleKey.E:
                        fsBundle.RightAlign();
                        break;
                }

            }
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
            cHandler.SetCanvas("BaseCanvas", new IntXYPair(20, 20), canvasPosition);

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
                    border.PrintHollow();
                }
                else
                {
                    border.Print();
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

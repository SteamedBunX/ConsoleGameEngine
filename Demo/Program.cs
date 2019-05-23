using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameEngine.Components;
using ConsoleGameEngine;
using System.Drawing;

namespace Demo
{
    class Demo
    {
        static void Main(string[] args)
        {
            Demo p = new Demo();
            p.DemoMainPage();
        }

        ComponentHandler cHandler;

        public Demo()
        {
            Ini();
        }

        public void Ini()
        {
            cHandler = new ComponentHandler();
            string imageFolderPath = Environment.CurrentDirectory + @"\Images\";
            cHandler.LoadImages(imageFolderPath);
        }

        public void DemoMainPage()
        {
            //setup
            Menu<int> mainMenu = new Menu<int>(46, 19, 28);
            mainMenu.AddItem("FreeString", 0);
            mainMenu.AddItem("FreeStringBundle", 1);
            mainMenu.AddItem("Border", 2);
            mainMenu.AddItem("Image", 3);
            mainMenu.AddItem("Canvas", 4);
            mainMenu.AddItem("Menu", 5);
            mainMenu.AddItem("ScrollableMenu", 6);
            mainMenu.AddItem("Numbers", 7);
            mainMenu.AddItem("Exit", 8);

            bool exit = false;
            bool needRefresh = true;
            while (!exit)
            {
                if (needRefresh)
                {
                    cHandler.Reset();
                    cHandler.SetCanvas("Logo", new Canvas(90, 35, 15, 0));
                    cHandler.DrawToCanvas("Logo", "ConsoleGameEngineDemo_Logo", new IntXYPair(0, 0));
                    cHandler.SetBorder("HomeMenuBorder", new Border(45, 18, 30, 11));

                    Console.Clear();
                    cHandler.PrintAllCanvas();
                    cHandler.PrintAllBorders();
                    needRefresh = false;
                }
                mainMenu.Print();
                var input = Console.ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.Escape:
                        exit = true;
                        break;
                    case ConsoleKey.UpArrow:
                        mainMenu.Up();
                        break;
                    case ConsoleKey.DownArrow:
                        mainMenu.Down();
                        break;
                    case ConsoleKey.Enter:
                        switch (mainMenu.GetReturn())
                        {
                            case 0:
                                FreeStringDemo();
                                needRefresh = true;
                                break;
                            case 1:
                                FreeStringBundleDemo();
                                needRefresh = true;
                                break;
                            case 2:
                                BorderDemo();
                                needRefresh = true;
                                break;
                            case 3:
                                ImageDemo();
                                needRefresh = true;
                                break;
                            case 4:
                                CanvasDemo();
                                needRefresh = true;
                                break;
                            case 5:
                                MenuDemo();
                                needRefresh = true;
                                break;
                            case 6:
                                ScrollableMenuDemo();
                                needRefresh = true;
                                break;
                            case 7:
                                break;
                            case 8:
                                exit = true;
                                break;
                        }

                        break;
                }
            }
            mainMenu.Print();
        }

        public void FreeStringDemo()
        {
            cHandler.Reset();
            IntXYPair textPosition = new IntXYPair(30, 10);
            cHandler.SetFreeString("Hello", new FreeString("Hello World!", textPosition, Color.Black, Color.Green));
            cHandler.SetBorder("DialogBorder", new Border(18, 9, 25, 3));
            bool exit = false;
            while (!exit)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.SetCursorPosition(10, 20);
                Console.Write("Q | LeftAlign, W | CenterAlign, E | RightAlign");
                cHandler.PrintAllBorders();
                cHandler.PrintAllFreeStrings();
                var input = Console.ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.Escape:
                        exit = true;
                        break;
                    case ConsoleKey.UpArrow:
                        cHandler.MoveFreeString("Hello", 0, -1);
                        cHandler.MoveBorder("DialogBorder", 0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        cHandler.MoveFreeString("Hello", 0, 1);
                        cHandler.MoveBorder("DialogBorder", 0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        cHandler.MoveFreeString("Hello", -1, 0);
                        cHandler.MoveBorder("DialogBorder", -1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        cHandler.MoveFreeString("Hello", 1, 0);
                        cHandler.MoveBorder("DialogBorder", 1, 0);
                        break;
                    case ConsoleKey.Q:
                        cHandler.ChangeFreeStringAlignment("Hello", Alignment.Left);
                        break;
                    case ConsoleKey.W:
                        cHandler.ChangeFreeStringAlignment("Hello", Alignment.Center);
                        break;
                    case ConsoleKey.E:
                        cHandler.ChangeFreeStringAlignment("Hello", Alignment.Right);
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

        public void BorderDemo()
        {
            cHandler.Reset();
            Console.Clear();
            Border border = new Border(30, 5, 40, 20);
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

        public void ImageDemo()
        {
            cHandler.Reset();

            IntXYPair pikachuPosition = new IntXYPair(5, 5);
            bool exit = false;
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
            cHandler.Reset();
            bool exit = false;

            IntXYPair canvasPosition = new IntXYPair(5, 5);
            IntXYPair pikachuPosition = new IntXYPair(5, 5);
            cHandler.SetCanvas("BaseCanvas", new IntXYPair(20, 20), canvasPosition);


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

        public void MenuDemo()
        {
            cHandler.Reset();
            Console.Clear();

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
                ConsoleKey switcher = Console.ReadKey().Key;
                switch (switcher)
                {
                    case ConsoleKey.Enter:
                        if (menu.GetReturn() == 5)
                        {
                            exit = true;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (!menu.AtTop())
                        {
                            Console.Clear();
                            menu.Up();
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (!menu.AtBottem())
                        {
                            Console.Clear();
                            menu.Down();
                        }
                        break;
                    case ConsoleKey.Q:
                        menu.LeftAlign();
                        Console.Clear();
                        break;
                    case ConsoleKey.W:
                        menu.CenterAlign();
                        Console.Clear();
                        break;
                    case ConsoleKey.E:
                        menu.RightAlign();
                        Console.Clear();
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

        public void ScrollableMenuDemo()
        {
            cHandler.Reset();
            Console.Clear();
            ScrollableMenu<int> menu = new ScrollableMenu<int>(30, 10, 20, 10, Color.Green, Color.Black);
            for (int i = 1; i <= 30; i++)
            {
                menu.AddItem($"{i}", i);
            }
            menu.AddItem("Exit", 0);

            FreeStringBundle guide = new FreeStringBundle(5, 20, 30);
            guide.Add("This menu contains 30 numbered items and an exit button");
            guide.Add("Q | LeftAlign, W | CenterAlign, E | RightAlign");
            bool exit = false;

            while (!exit)
            {
                guide.Print();
                menu.Print();
                ConsoleKey switcher = Console.ReadKey().Key;
                switch (switcher)
                {
                    case ConsoleKey.Enter:
                        if (menu.GetReturn() == 0)
                        {
                            exit = true;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (!menu.AtTop())
                        {
                            Console.Clear();
                            menu.Up();
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (!menu.AtBottem())
                        {
                            Console.Clear();
                            menu.Down();
                        }
                        break;
                    case ConsoleKey.Q:
                        menu.LeftAlign();
                        Console.Clear();
                        break;
                    case ConsoleKey.W:
                        menu.CenterAlign();
                        Console.Clear();
                        break;
                    case ConsoleKey.E:
                        menu.RightAlign();
                        Console.Clear();
                        break;
                }
            }

        }

        enum Mode { Filled, Hollow }
    }
}

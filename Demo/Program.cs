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
            ComponentHandler cHandler = new ComponentHandler();
            string imageFolderPath = Environment.CurrentDirectory + @"\Images\";
            cHandler.LoadImages(imageFolderPath);
            cHandler.PrintImage("Pikachu", 0, 0);
            Console.ReadLine();
            Renderer.ResetConsoleColor();
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameEngine.Components;

namespace ConsoleGameEngine
{
    public static class Renderer
    { 
        public static void PrintImage(Image image, IntXYPair location)
        {

        }

        public static void PrintImage(Image image, int x, int y)
        {
            PrintImage(image, new IntXYPair(x, y));
        }
    }
}

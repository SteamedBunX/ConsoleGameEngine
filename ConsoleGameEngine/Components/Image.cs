using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameEngine.Components
{
    public class Image
    {
        public string Name { get; set; }
        public List<Color> Colors { get; set; }
        public List<string> Bitmap { get; set; }
    }
}

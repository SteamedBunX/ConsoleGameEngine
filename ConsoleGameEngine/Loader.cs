using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameEngine.Components;
using Image = ConsoleGameEngine.Components.Image;

namespace ConsoleGameEngine
{
    public static class Loader
    {






        // Image Loading Component
        public static Dictionary<string, Image> LoadImages(string folderPath)
        {
            Dictionary<string, Image> images = new Dictionary<string, Image>();
            foreach (string f in Directory.GetFiles(folderPath))
            {
                //Need to make sure the file is actually .ci before loading, to prevent errors.
                if (f.Substring(f.Length - 3).ToLower() == ".ci")
                {
                    Image image = LoadImage(f);
                    images.Add(image.Name, image);
                }
            }
            return images;
        }

        public static Image LoadImage(string path)
        {
            // Get the name of the Image
            string[] pathParts = path.Split('\\');
            string name = pathParts.Last();
            name = name.Split('.')[0];

            StreamReader img = new StreamReader(path);

            //Load the colors
            List<string> colorsInHax = new List<string>();
            List<Color> colors = new List<Color>();
            bool colorSet = false;
            string nextColor = img.ReadLine();
            do
            {
                colorsInHax.Add(nextColor);
                nextColor = img.ReadLine();
                if (nextColor == "")
                {
                    colorSet = true;
                }
            } while (!colorSet);
            colors = FillColor(colorsInHax);

            //Lost the bitmap
            List<string> bitmap = new List<string>();
            while (!img.EndOfStream)
            {
                bitmap.Add(img.ReadLine());
            }

            return new Image
            {
                Name = name,
                Colors = colors,
                Bitmap = bitmap
            };
        }

        public static List<Color> FillColor(List<string> hexColors)
        {
            List<Color> colors = new List<Color>();
            foreach (string hc in hexColors)
            {
                ColorConverter converter = new ColorConverter();
                colors.Add((Color)converter.ConvertFromString(hc));
            }
            return colors;
        }
    }
}

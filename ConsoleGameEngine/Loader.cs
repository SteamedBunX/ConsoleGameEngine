﻿using System;
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
        public static List<Image> LoadImages(string folderPath)
        {
            List<Image> images = new List<Image>();
            foreach (string f in Directory.GetFiles(folderPath))
            {
                if (f.Substring(f.Length - 3).ToLower() == ".ci")
                {
                    images.Add(LoadImage(f));
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
                if (nextColor == "")
                {
                    colorSet = true;
                }
                else
                {
                    colorsInHax.Add(nextColor);
                }
                nextColor = img.ReadLine();
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
                BitMap = bitmap
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

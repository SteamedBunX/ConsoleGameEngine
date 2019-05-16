using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameEngine.Components
{
    public class ComponentHandler
    {
        Dictionary<string, Image> images = new Dictionary<string, Image>();
        Dictionary<string, Canvas> canvases = new Dictionary<string, Canvas>();
        Dictionary<string, Border> borders = new Dictionary<string, Border>();


        #region Border
        public void AddBorder(string name, Border border)
        {
            borders.Add(name, border);
        }

        public void RemoveBorder(string name)
        {
            borders.Remove(name);
        }

        public void RemoveAllBorders()
        {
            borders.Clear();
        }

        public void PrintBorder(string name)
        {
            if (borders.ContainsKey(name))
            {
                Renderer.PrintBorder(borders[name]);
            }
        }

        public void PrintAllBorders()
        {
            foreach (KeyValuePair<string, Border> border in borders)
            {
                Renderer.PrintBorder(border.Value);
            }
        }

        public void PrintHollowBorder(string name)
        {
            if (borders.ContainsKey(name))
            {
                Renderer.PrintHollowBorder(borders[name]);
            }
        }

        public void PrintAllHollowBorder()
        {
            foreach (KeyValuePair<string, Border> border in borders)
            {
                Renderer.PrintHollowBorder(border.Value);
            }
        }

        #endregion

        #region Canvas
        public void AddCanvas(string name, IntXYPair size, IntXYPair position)
        {
            canvases[name] = new Canvas(size, position);
        }

        public void MoveCanvas(string name, IntXYPair position)
        {
            canvases[name].Move(position);
        }

        public void DrawToCanvas(string canvasName, string imageName, IntXYPair position)
        {
            canvases[canvasName].DrawImage(images[imageName], position);
        }

        public void ClearCanvas(string name)
        {
            if (canvases.ContainsKey(name))
            {
                canvases[name].Reset();
            }
        }

        public void RemoveCanvas(string name)
        {
            if (canvases.ContainsKey(name))
            {
                canvases.Remove(name);
            }
        }

        public void RemoveAllCanvas()
        {
            canvases.Clear();
        }

        public void PrintCanvas(string name)
        {
            if (canvases.ContainsKey(name))
            {
                Renderer.PrintCanvas(canvases[name]);
            }
        }

        public void PrintAllCanvas()
        {
            foreach (KeyValuePair<string, Canvas> c in canvases)
            {
                c.Value.Print();
            }
        }

        #endregion

        #region Image
        public void LoadImages(string folderPath)
        {
            var imageList = Loader.LoadImages(folderPath);
            foreach (var item in imageList)
            {
                images.Add(item.Key, item.Value);
            }
        }

        public void LoadImage(string path)
        {
            Image image = Loader.LoadImage(path);
            images.Add(image.Name, image);
        }

        public void ClearImages()
        {
            images.Clear();
        }

        public void PrintImage(string name, IntXYPair position)
        {
            if (images.ContainsKey(name))
            {
                Renderer.PrintImage(images[name], position);
            }
        }

        public void PrintImage(string name, int x, int y)
        {
            PrintImage(name, new IntXYPair(x, y));
        }
        #endregion

    }
}

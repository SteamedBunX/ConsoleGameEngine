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
        Dictionary<string, FreeString> freeStrings = new Dictionary<string, FreeString>();

        #region FreeString
        public void SetFreeString(string name, FreeString freeString, Alignment alignment = Alignment.Left)
        {
            freeStrings[name] = freeString;
        }

        public void ChangeFreeStringAlignment(string name, Alignment alignment)
        {
            if(freeStrings.ContainsKey(name))
            {
                switch (alignment)
                {
                    case Alignment.Left:
                        freeStrings[name].LeftAlign();
                        break;
                    case Alignment.Right:
                        freeStrings[name].RightAlign();
                        break;
                    case Alignment.Center:
                        freeStrings[name].CenterAlign();
                        break;
                }
            }
        }

        public void RemoveFreeString(string name)
        {
            if (freeStrings.ContainsKey(name))
            {
                freeStrings.Remove(name);
            }
        }

        public void RemoveAllFreeStrings()
        {
            freeStrings.Clear();
        }

        public void PrintFreeString(string name)
        {
            if (freeStrings.ContainsKey(name))
            {
                freeStrings[name].Print();
            }
        }

        public void PrintAllFreeStrings()
        {
            foreach (KeyValuePair<string, FreeString> item in freeStrings)
            {
                item.Value.Print();
            }
        }
        #endregion

        #region Border
        public void SetBorder(string name, Border border)
        {
            borders[name] = border;
        }

        public void MoveBorder(string name, int xDelta = 0, int yDelta = 0)
        {
            if (borders.ContainsKey(name))
            {
                borders[name].Move(xDelta,yDelta);
            }
        }

        public void TeleportBorder(string name, int x, int y)
        {
            if (borders.ContainsKey(name))
            {
                borders[name].MoveTo(x, y);
            }
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
        public void SetCanvas(string name, IntXYPair size, IntXYPair position)
        {
            canvases[name] = new Canvas(size, position);
        }

        public void SetCanvas(string name, Canvas canvas)
        {
            canvases[name] = canvas;
        }

        public void MoveCanvas(string name, IntXYPair position)
        {
            if (canvases.ContainsKey(name))
            {
                canvases[name].Move(position);
            }
        }

        public void DrawToCanvas(string canvasName, string imageName, IntXYPair position)
        {
            if (canvases.ContainsKey(canvasName) && images.ContainsKey(imageName))
            {
                canvases[canvasName].DrawImage(images[imageName], position);
            }
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
                canvases[name].Print();
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

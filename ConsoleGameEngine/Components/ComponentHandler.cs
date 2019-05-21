using System;
using System.Collections.Generic;
using System.Drawing;
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
        Dictionary<string, FreeStringBundle> freeStringBundles = new Dictionary<string, FreeStringBundle>();

        #region FreeString
        public void SetFreeString(string name, FreeString freeString, Alignment alignment = Alignment.Left)
        {
            freeStrings[name] = freeString;
            freeStrings[name].SetAlignment(alignment);
        }
        public void MoveFreeString(string name, int deltaX, int deltaY)
        {
            if (freeStrings.ContainsKey(name))
            {
                freeStrings[name].Move(deltaX, deltaY);
            }
        }

        public void SetFreeStringPosition(string name, int x, int y)
        {
            if (freeStrings.ContainsKey(name))
            {
                freeStrings[name].MoveTo(x, y);
            }
        }

        public void ChangeFreeStringAlignment(string name, Alignment alignment)
        {
            if (freeStrings.ContainsKey(name))
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

        #region FreeStringBundle

        public void SetFSBundle(string name, FreeStringBundle bundle)
        {
            freeStringBundles[name] = bundle;
        }

        public void AddContentToFSBundle(string name, string text)
        {
            if (borders.ContainsKey(name))
            {
                freeStringBundles[name].Add(text);
            }
        }

        public void ChangeFSBundleTextColor(string name, Color textColor)
        {
            if (borders.ContainsKey(name))
            {
                freeStringBundles[name].ChangeTextColor(textColor);
            }
        }

        public void ChangeFSBundleBGColor(string name, Color bgColor)
        {
            if (borders.ContainsKey(name))
            {
                freeStringBundles[name].ChangeBackgroundColor(bgColor);
            }
        }

        public void ClearFreeStringBundle(string name)
        {
            if (borders.ContainsKey(name))
            {
                freeStringBundles[name].ClearContent();
            }
        }

        public void ClearAllFreeStringBundle()
        {
            foreach (KeyValuePair<string, FreeStringBundle> item in freeStringBundles)
            {
                item.Value.ClearContent();
            }

        }

        public void RemoveFreestringBundle(string name)
        {
            if (borders.ContainsKey(name))
            {
                freeStringBundles.Remove(name);
            }
        }
        public void RemoveAllFreeStringBundle()
        {
            freeStringBundles.Clear();
        }
        #endregion


        #region Border
        public void SetBorder(string name, Border border)
        {
            borders[name] = border;
        }

        public void MoveBorder(string name, int xDelta, int yDelta)
        {
            if (borders.ContainsKey(name))
            {
                borders[name].Move(xDelta, yDelta);

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
                images[item.Key] = item.Value;
            }
        }

        public void LoadImage(string path)
        {
            Image image = Loader.LoadImage(path);
            images[image.Name] = image;
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

        public void Reset()
        {
            RemoveAllFreeStrings();
            RemoveAllCanvas();
            RemoveAllBorders();
            RemoveAllFreeStringBundle();
        }
    }
}

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

        public void LoadImages(string folderPath)
        {
            var imageList = Loader.LoadImages(folderPath);
            foreach(var item in imageList)
            {
                images.Add(item.Key,item.Value);
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
                Renderer.PrintImage(images[name],position);
            }
        }


    }
}

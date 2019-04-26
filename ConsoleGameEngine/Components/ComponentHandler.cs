using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameEngine.Components
{
    public class ComponentHandler
    {
        List<Image> images = new List<Image>();

        public void LoadImages(string folderPath)
        {
            images.AddRange(Loader.LoadImages(folderPath));
        }

        public void LoadImage(string path)
        {
            images.Add(Loader.LoadImage(path));
        }

        public void ClearImages()
        {
            images.Clear();
        }
    }
}

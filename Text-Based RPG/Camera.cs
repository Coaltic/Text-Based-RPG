using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Camera
    {
        static public string[] data = System.IO.File.ReadAllLines("CameraData.txt");
        static public string[] gottenData = data[1].Split(';');

        public int offsetX;
        public int offsetY;

        
        public int Xstart;
        public int Xend = int.Parse(gottenData[0]);

        public int Ystart;
        public int Yend = int.Parse(gottenData[1]);

        public int scrollRight;
        public int scrollLeft;
        public int scrollUp;
        public int scrollDown;

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Camera
    {
        private char[,] cameraDisplay = new char[220, 56];

        private string[] cameraData;
        private int x;
        private int y;

        public int rightSide;
        public int leftSide;
        public int topSide;
        public int bottomSide;

        public Camera()
        {
            cameraData = System.IO.File.ReadAllLines("Map.txt");

            for (y = 0; y <= cameraData.Length - 1; y++)
            {
                string currentCameraLine = cameraData[y];
                for (x = 0; x <= currentCameraLine.Length - 1; x++)
                {
                    char mapTile = currentCameraLine[x];
                    cameraDisplay[x, y] = mapTile;
                }
            } 
        }

        public void DisplayCamera()
        {
            Console.SetCursorPosition(0, 0);

            for (y = 0; y <= 22; y++)
            {
                for (x = 0; x <= 55; x++)
                {
                    Console.Write(cameraDisplay[x, y]);
                }
                Console.WriteLine();
                x = 0;
            }

            y = 0;
        }

        public void Update(Map map)
        {
            for (y = 0; y <= cameraData.Length - 1; y++)
            {
                string currentMapLine = cameraData[map.y];
                for (x = 0; x <= currentMapLine.Length - 1; x++)
                {
                    char mapTile = currentMapLine[map.x];
                    cameraDisplay[x, y] = mapTile;
                }
            }
        }
    }

    
}

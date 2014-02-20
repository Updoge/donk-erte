using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DonkErte.Map
{
    public class Map
    {
        public delegate void MapEventHandler(object sender, EventArgs e);

        public event MapEventHandler Loaded;
        public event MapEventHandler Unloaded;
        public Tile[,] Squares;

        public Map(int width, int height)
        {
            Squares = new Tile[width,height];
        }
    }
}

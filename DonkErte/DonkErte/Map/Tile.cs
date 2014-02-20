using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DonkErte.Map
{
    public abstract class Tile
    {
        public delegate void TileEventHandler(object sender, TileEventArgs e);
        private int _graphicTile;
        private Map _parent;
        protected Tile(int graphic, Map parent)
        {
            _graphicTile = graphic;
            _parent = parent;
        }
        //public Graphic Render();

        public abstract bool CanPlayerEnter();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DonkErte.Map
{
    public class Tile
    {
        public delegate void TileEventHandler(object sender, EventArgs e);
        public event TileEventHandler InteractedWith;
        public event TileEventHandler Entered;
        private int _graphicTile;
        private Map _parent;
        public bool Enterable;
        protected Tile(int graphic, Map parent, bool enterable)
        {
            _graphicTile = graphic;
            _parent = parent;
            Enterable = enterable;
        }
        //public Graphic Render();

        public void Interact()
        {
            if (InteractedWith != null)
            {
                InteractedWith.Invoke(this, EventArgs.Empty);
            }
        }

        public void OnEnter()
        {
            if (Entered != null)
            {
                Entered.Invoke(this, EventArgs.Empty);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DonkErte.World;

namespace DonkErte.Characters
{
    public class CharEventArgs : EventArgs
    {
        public Character Character;
        public CharEventArgs(Character c)
        {
            Character = c;
        }
    }
    public abstract class Character
    {
        private int characterSprite;
        public Point Location;
        private readonly Map _map;

        protected Character(Point loc, Map map)
        {
            _map = map;
            Location = loc;
        }
        public virtual bool Move(int dir)
        {
            Tile toEnter = GetTileInDirection(dir);
            if (!toEnter.Enterable)
            {
                return false;
            }
            toEnter.OnEnter(this);
            Point toMoveTo = GetPointInDirection(dir);
            AnimateMoveTo(toMoveTo);
            Location = toMoveTo;
        }

        public bool Interact(int dir)
        {
            GetTileInDirection(dir).Interact(this);
        }
        #region Helpers
        private Point GetPointInDirection(int dir)
        {
            Point moveAdjustment;
            switch (dir)
            {
                case 0:
                    moveAdjustment = new Point(0, -1);
                    break;
                case 1:
                    moveAdjustment = new Point(1, 0);
                    break;
                case 2:
                    moveAdjustment = new Point(0, 1);
                    break;
                case 3:
                    moveAdjustment = new Point(-1, 0);
                    break;
                default:
                    throw new ArgumentException("Invalid direction", "dir");
            }
            return Location + moveAdjustment;
        }

        private Tile GetTileInDirection(int dir)
        {
            Point newLocation = GetPointInDirection(dir);
            return _map.Squares[newLocation.X, newLocation.Y];
        }

        private void AnimateMoveTo(Point newLoc)
        {

        }
        #endregion
    }
}

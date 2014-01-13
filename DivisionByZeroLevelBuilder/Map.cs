using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionByZeroLevelBuilder
{
    public class Tile
    {
        private const int TILE_BLOCKED = 0x1;
        private const int TILE_BUILDABLE = 0x2;

        private int flags;

        private string symbolList = "";

        public Tile()
        {
            // a tile is by default, not blocked and buildable.
            flags |= TILE_BUILDABLE;
        }

        public void ClearFlags()
        {
            flags = 0;
        }

        public bool IsBlocked()
        {
            return (flags & TILE_BLOCKED) != 0;
        }

        public void SetIsBlocked(bool state)
        {
            if (state)
            {
                flags |= TILE_BLOCKED;
            }
            else
            {
                flags &= ~TILE_BLOCKED;
            }
        }

        public bool IsBuildable()
        {
            return (flags & TILE_BUILDABLE) != 0;
        }

        public void SetIsBuildable(bool state)
        {
            if (state)
            {
                flags |= TILE_BUILDABLE;
            }
            else
            {
                flags &= ~TILE_BUILDABLE;
            }
        }

        public void AddSymbol(char c)
        {
            symbolList += c;
        }

        public bool HasSymbols()
        {
            return (symbolList.Length != 0);
        }

        public string GetSymbolList()
        {
            return symbolList;
        }

        public void ResetSymbolList()
        {
            symbolList = "";
        }
    }

    public class Map
    {
        public int mapId;

        public int PathCount
        {
            get;
            set;
        }

        public int Width
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        public bool isBuilt = false;
        public List<List<Tile>> tiles = new List<List<Tile>>();

        public void build()
        {
            for (int i = 0; i < Width; i++)
            {
                List<Tile> l = new List<Tile>(Height);
                for (int j = 0; j < Height; j++)
                {
                    l.Add(new Tile());
                }
                tiles.Add(l);
            }

            isBuilt = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DivisionByZeroLevelBuilder
{
    public delegate void NameChangedHandler(string newName);

    class Level
    {
        interface OnStateChanged
        {
            void onNameChanged(string newName);
            void onDifficultyChanged(int newDiff);
        }

        public event NameChangedHandler NameChanged;

        public Level()
        {
            Waves = new List<Wave>();
            Map = new Map();
        }

        // a level is madde up of several components...
        public Map Map
        {
            get;
            set;
        }

        private string _Name;
        private bool disableCallbacks = false;

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                if (!disableCallbacks && NameChanged != null)
                {
                    disableCallbacks = true;
                    NameChanged(value);
                    disableCallbacks = false;
                }
            }
        }

        public int Difficulty
        {
            get;
            set;
        }

        public List<Wave> Waves
        {
            get;
            set;
        }

        public int StartingLives
        {
            get;
            set;
        }

        public int StartingGold
        {
            get;
            set;
        }
    }
}

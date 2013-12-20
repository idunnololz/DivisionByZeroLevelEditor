using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionByZeroLevelBuilder
{
    class Wave
    {
        public SpriteType spriteType;
        public int spawnCount;
        public int spawnDelay;
        public int hp;
        public int reward;
        public char entrance = '\0';
        public int index;
        public int timeAllotted = 0;

        public Wave()
        {
            spriteType = null;
            spawnCount = 0;
            spawnDelay = 0;
            hp = 0;
            reward = 0;
        }
    }
}

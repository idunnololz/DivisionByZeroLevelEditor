using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionByZeroLevelBuilder
{
    class ObjectManager
    {
        private Map map;
        private static ObjectManager instance = null;

        public static ObjectManager getInstance()
        {
            if (instance == null)
                instance = new ObjectManager();

            return instance;
        }

        private ObjectManager()
        {
            map = new Map();
        }

        public Map getMap()
        {
            return map;
        }
    }
}

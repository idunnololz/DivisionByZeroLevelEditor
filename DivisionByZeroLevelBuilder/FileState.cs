using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionByZeroLevelBuilder
{
    class FileState
    {
        public string FileName
        {
            get;
            set;
        }

        public bool IsDirty
        {
            get;
            set;
        }

        public FileState()
        {
            FileName = null;
            IsDirty = false;
        }
    }
}

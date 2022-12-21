using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2
{
    internal class DynamicArrayEventArgs : EventArgs
    {
        public int OldCapacity { get;  }
        public int NewCapacity { get; }

        public DynamicArrayEventArgs(int oldCapacity, int newCapacity)
        {
            OldCapacity = oldCapacity;
            NewCapacity = newCapacity;
        }    
    }
}

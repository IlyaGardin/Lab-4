using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2
{
    internal class DynamicArrayEnumerator<Type> : IEnumerator<Type>
    {
        private Type[] _array;
        private int _length;
        private int _iIndx = -1;
        public DynamicArrayEnumerator(Type[] array, int length)
        {
            _array = array;
            _length = length;
        }
        Type IEnumerator<Type>.Current
        {
            get
            {
                return _array[_iIndx];
            }
        }

        object? IEnumerator.Current
        {
            get
            {
                return _array[_iIndx];
            }
        }

        public bool MoveNext()
        {
            _iIndx++;
            return (_iIndx < _length);
        }

        public void Reset()
        {
            _iIndx = -1;
        }

        public void Dispose()
        {
           
        }
    }
}

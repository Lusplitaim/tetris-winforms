using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class TetrisCellSpecsEqualityComparer : IEqualityComparer<TetrisCellSpecs>
    {
        public bool Equals(TetrisCellSpecs x, TetrisCellSpecs y)
        {
            bool rowsEqual = x.Row == y.Row;
            bool columnsEqual = x.Column == y.Column;
            return rowsEqual && columnsEqual;
        }

        public int GetHashCode([DisallowNull] TetrisCellSpecs obj)
        {
            return obj.Row + obj.Column;
        }
    }
}

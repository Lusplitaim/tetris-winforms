using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class TetrisBlock
    {
        public List<TetrisCellSpecs> Cells { get; internal set; } = new List<TetrisCellSpecs>();
    }

    public struct TetrisCellSpecs
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int Width { get; init; }
        public int Height { get; init; }

        public int X
        {
            get { return Column * Width; }
        }

        public int Y
        {
            get { return Row * Height; }
        }
    }
}

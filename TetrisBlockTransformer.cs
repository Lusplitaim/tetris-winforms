using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal static class TetrisBlockTransformer
    {
        internal static void MoveBlockToRight(TetrisBlock block)
        {
            for (int i = 0; i < block.Cells.Count(); i++)
            {
                var cellSpecs = block.Cells[i];
                cellSpecs.Column++;
                block.Cells[i] = cellSpecs;
            }
        }

        internal static void MoveBlockToLeft(TetrisBlock block)
        {
            for (int i = 0; i < block.Cells.Count(); i++)
            {
                var cellSpecs = block.Cells[i];
                cellSpecs.Column--;
                block.Cells[i] = cellSpecs;
            }
        }
    }
}

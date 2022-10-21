using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class BlockTransformer
    {
        internal void MoveToRight(TetrisBlock block)
        {
            for (int i = 0; i < block.Cells.Count(); i++)
            {
                var cellSpecs = block.Cells[i];
                cellSpecs.Column++;
                block.Cells[i] = cellSpecs;
            }
        }

        internal void MoveToLeft(TetrisBlock block)
        {
            for (int i = 0; i < block.Cells.Count(); i++)
            {
                var cellSpecs = block.Cells[i];
                cellSpecs.Column--;
                block.Cells[i] = cellSpecs;
            }
        }

        internal void MoveUp(TetrisBlock block)
        {
            for (int i = 0; i < block.Cells.Count(); i++)
            {
                var cellSpecs = block.Cells[i];
                cellSpecs.Row--;
                block.Cells[i] = cellSpecs;
            }
        }

        internal void MoveDown(TetrisBlock block)
        {
            for (int i = 0; i < block.Cells.Count(); i++)
            {
                var cellSpecs = block.Cells[i];
                cellSpecs.Row++;
                block.Cells[i] = cellSpecs;
            }
        }
    }
}

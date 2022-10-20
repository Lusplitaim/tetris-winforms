using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class TetrisField
    {
        private TetrisFieldSpecs _fieldSpecs;
        private GridDrawer _gridDrawer;
        private BlockDrawer _blockDrawer;

        internal TetrisField(TetrisFieldSpecs fieldSpecs)
        {
            _fieldSpecs = fieldSpecs;
            InitGridDrawer();
            InitBlockDrawer();
        }

        internal Bitmap DrawField(TetrisBlock fallingBlock, IEnumerable<TetrisCellSpecs> groundedCells)
        {
            Bitmap bmp = new(_fieldSpecs.Width, _fieldSpecs.Height);

            _gridDrawer.DrawGrid(bmp);

            _blockDrawer.DrawBlock(bmp, fallingBlock);

            _blockDrawer.DrawCells(bmp, groundedCells);

            return bmp;
        }

        private void InitGridDrawer()
        {
            GridStyle gridStyle = new()
            {
                RowCount = _fieldSpecs.RowCount,
                ColumnCount = _fieldSpecs.ColumnCount,
                CellHeight = _fieldSpecs.RowHeight,
                CellWidth = _fieldSpecs.ColumnWidth,
            };
            _gridDrawer = new GridDrawer(gridStyle);
        }

        private void InitBlockDrawer()
        {
            _blockDrawer = new BlockDrawer();
        }
    }

    internal struct TetrisFieldSpecs
    {
        internal int RowCount { get; init; }
        internal int ColumnCount { get; init; }
        internal int ColumnWidth { get; init; }
        internal int RowHeight { get; init; }

        internal int Width
        {
            get => ColumnCount * ColumnWidth;
        }
        internal int Height
        {
            get => RowCount * RowHeight;
        }
    }
}

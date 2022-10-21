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

        private TetrisBlock _fallingBlock;
        private List<TetrisCellSpecs> _groundedCells = new();

        private GridDrawer _gridDrawer;
        private BlockDrawer _blockDrawer;

        private BlockTransformer _blockTransformer;

        internal TetrisField(TetrisFieldSpecs fieldSpecs)
        {
            _fieldSpecs = fieldSpecs;
            InitGridDrawer();
            InitBlockDrawer();
            _blockTransformer = new BlockTransformer();
            CreateFallingBlock();
        }

        private void CreateFallingBlock()
        {
            _fallingBlock = TetrisBlock
                .CreateLine(5, _fieldSpecs.RowHeight, _fieldSpecs.ColumnWidth);
        }

        internal Bitmap DrawField()
        {
            Bitmap bmp = new(_fieldSpecs.Width, _fieldSpecs.Height);

            _gridDrawer.DrawGrid(bmp);

            _blockDrawer.DrawBlock(bmp, _fallingBlock);

            _blockDrawer.DrawCells(bmp, _groundedCells);

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

        internal void ShiftFallingBlock()
        {
            _blockTransformer.MoveDown(_fallingBlock);

            bool isAtBottom = _fallingBlock.Cells.Any(cellSpecs =>
            {
                return cellSpecs.Row == (_fieldSpecs.RowCount - 1);
            });

            var tmpBlocks = _fallingBlock.Cells.Select(c =>
            {
                c.Row++;
                return c;
            });

            bool isCollidedWithGroundCells = tmpBlocks.Intersect(_groundedCells).Any();

            isAtBottom = isAtBottom || isCollidedWithGroundCells;

            if (isAtBottom)
            {
                _groundedCells.AddRange(_fallingBlock.Cells);

                CreateFallingBlock();
            }

            if (CheckForFullGroundRows()) RemoveFullRows();
        }

        private bool CheckForFullGroundRows()
        {
            var groundRowStats = _groundedCells.GroupBy(c => c.Row)
                .Select(c => new { Row = c.Key, ColumnCount = c.Count() })
                .OrderBy(s => s.Row);

            var rowsForDeletion = groundRowStats.Where(s => s.ColumnCount == _fieldSpecs.ColumnCount);

            return rowsForDeletion.Any();
        }

        private void RemoveFullRows()
        {
            var groundRowStats = _groundedCells.GroupBy(c => c.Row)
                .Select(c => new { Row = c.Key, ColumnCount = c.Count() })
                .OrderBy(s => s.Row);

            var rowsForDeletion = groundRowStats.Where(s => s.ColumnCount == _fieldSpecs.ColumnCount);

            foreach (var rowStat in rowsForDeletion)
            {
                _groundedCells = _groundedCells.Where(c => c.Row != rowStat.Row).ToList();

                _groundedCells = _groundedCells.Select(c =>
                {
                    if (c.Row < rowStat.Row) c.Row++;
                    return c;
                }).ToList();
            }
        }

        internal void MoveBlockToLeft()
        {
            _blockTransformer.MoveToLeft(_fallingBlock);
            if (CheckFallingBlockBoundary())
            {
                _blockTransformer.MoveToRight(_fallingBlock);
            }
        }

        internal void MoveBlockToRight()
        {
            _blockTransformer.MoveToRight(_fallingBlock);
            if (CheckFallingBlockBoundary())
            {
                _blockTransformer.MoveToLeft(_fallingBlock);
            }
        }

        private bool CheckFallingBlockBoundary()
        {
            bool isCollidedWithGroundBlocks = _fallingBlock.Cells
                .Intersect(_groundedCells).Any();

            bool isOutOfBoundary = _fallingBlock.Cells.Any((cellSpec) =>
            {
                return cellSpec.Column < 0 || cellSpec.Column >= _fieldSpecs.ColumnCount;
            });

            return isCollidedWithGroundBlocks || isOutOfBoundary;
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

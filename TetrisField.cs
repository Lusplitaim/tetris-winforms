using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class TetrisField
    {
        private TetrisFieldSpecs _fieldSpecs;

        private TetrisBlock _fallingBlock;
        private List<TetrisCellSpecs> _groundedCells = new();

        private GridDrawer _gridDrawer;
        private BlockDrawer _blockDrawer;
        private List<BasicBlockDelegate> _blockCreators;

        private BlockTransformer _blockTransformer;

        public TetrisField(TetrisFieldSpecs fieldSpecs)
        {
            _fieldSpecs = fieldSpecs;
            InitGridDrawer();
            InitBlockDrawer();
            _blockTransformer = new BlockTransformer();
            _blockCreators = BlockCreator.CreateBasicBlocks().ToList();
            CreateFallingBlock();
        }

        private void CreateFallingBlock()
        {
            Random random = new();
            var index = random.Next(0, _blockCreators.Count - 1);

            _fallingBlock = _blockCreators[index]
                (_fieldSpecs.RowHeight, _fieldSpecs.ColumnWidth);
        }

        public Bitmap DrawField()
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

        public bool TryShiftingFallingBlock()
        {
            _blockTransformer.MoveDown(_fallingBlock);

            bool isOutsideOfBoundary = CheckFallingBlockBoundary();
            if (isOutsideOfBoundary)
            {
                _blockTransformer.MoveUp(_fallingBlock);

                bool isFieldOverflowed = CheckForOverflow();
                if (isFieldOverflowed)
                {
                    return false;
                }

                _groundedCells.AddRange(_fallingBlock.Cells);

                CreateFallingBlock();
            }

            if (CheckForFullGroundRows()) RemoveFullRows();

            return true;
        }

        private bool CheckForOverflow()
        {
            return _fallingBlock.Cells.Any(c => c.Row == 0);
        }

        private bool CheckForBoundaryViolation()
        {
            bool isAtBottom = _fallingBlock.Cells.Any(cellSpecs =>
            {
                return cellSpecs.Row == _fieldSpecs.RowCount
                || cellSpecs.Column < 0 || cellSpecs.Column >= _fieldSpecs.ColumnCount;
            });
            return isAtBottom;
        }

        private bool CheckForCollision()
        {
            bool isCollidedWithGroundCells = _fallingBlock.Cells.Intersect(_groundedCells).Any();
            return isCollidedWithGroundCells;
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

        public void MoveBlockToLeft()
        {
            _blockTransformer.MoveToLeft(_fallingBlock);
            if (CheckFallingBlockBoundary())
            {
                _blockTransformer.MoveToRight(_fallingBlock);
            }
        }

        public void MoveBlockToRight()
        {
            _blockTransformer.MoveToRight(_fallingBlock);
            if (CheckFallingBlockBoundary())
            {
                _blockTransformer.MoveToLeft(_fallingBlock);
            }
        }

        private bool CheckFallingBlockBoundary()
        {
            bool isCollidedWithGroundBlocks = CheckForCollision();

            bool isOutOfBoundary = CheckForBoundaryViolation();

            return isCollidedWithGroundBlocks || isOutOfBoundary;
        }
    }

    public struct TetrisFieldSpecs
    {
        public int RowCount { get; init; }
        public int ColumnCount { get; init; }
        public int ColumnWidth { get; init; }
        public int RowHeight { get; init; }

        public int Width
        {
            get => ColumnCount * ColumnWidth;
        }
        public int Height
        {
            get => RowCount * RowHeight;
        }
    }
}

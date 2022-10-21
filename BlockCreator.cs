using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public delegate TetrisBlock BasicBlockDelegate(int rowHeight, int columnWidth);
    public class BlockCreator
    {
        public static TetrisBlock CreateBlockFromCells(IEnumerable<TetrisCellSpecs> cells)
        {
            return new TetrisBlock() { Cells = cells.ToList() };
        }

        public static IEnumerable<BasicBlockDelegate> CreateBasicBlocks()
        {
            List<BasicBlockDelegate> blockDelegates = new();

            blockDelegates.Add(CreateHero);
            blockDelegates.Add(CreateSmashboy);
            blockDelegates.Add(CreateOrangeRicky);
            blockDelegates.Add(CreateBlueRicky);
            blockDelegates.Add(CreateTeewee);
            blockDelegates.Add(CreateClevelandZ);
            blockDelegates.Add(CreateRhodeIslandZ);

            return blockDelegates;
        }

        private static TetrisBlock CreateClevelandZ(int rowHeight, int columnWidth)
        {
            List<TetrisCellSpecs> cells = new();

            cells.Add(new() { Row = 0, Column = 0, Height = rowHeight, Width = columnWidth });
            cells.Add(new() { Row = 0, Column = 1, Height = rowHeight, Width = columnWidth });
            cells.Add(new() { Row = 1, Column = 1, Height = rowHeight, Width = columnWidth });
            cells.Add(new() { Row = 1, Column = 2, Height = rowHeight, Width = columnWidth });

            return CreateBlockFromCells(cells);
        }

        private static TetrisBlock CreateRhodeIslandZ(int rowHeight, int columnWidth)
        {
            List<TetrisCellSpecs> cells = new();

            cells.Add(new() { Row = 1, Column = 0, Height = rowHeight, Width = columnWidth });
            cells.Add(new() { Row = 1, Column = 1, Height = rowHeight, Width = columnWidth });
            cells.Add(new() { Row = 0, Column = 1, Height = rowHeight, Width = columnWidth });
            cells.Add(new() { Row = 0, Column = 2, Height = rowHeight, Width = columnWidth });

            return CreateBlockFromCells(cells);
        }

        private static TetrisBlock CreateTeewee(int rowHeight, int columnWidth)
        {
            List<TetrisCellSpecs> cells = new();

            cells.Add(new() { Row = 1, Column = 0, Height = rowHeight, Width = columnWidth });
            cells.Add(new() { Row = 1, Column = 1, Height = rowHeight, Width = columnWidth });
            cells.Add(new() { Row = 1, Column = 2, Height = rowHeight, Width = columnWidth });
            cells.Add(new() { Row = 0, Column = 1, Height = rowHeight, Width = columnWidth });

            return CreateBlockFromCells(cells);
        }

        private static TetrisBlock CreateBlueRicky(int rowHeight, int columnWidth)
        {
            List<TetrisCellSpecs> cells = new();

            cells.Add(new() { Row = 0, Column = 0, Height = rowHeight, Width = columnWidth });
            cells.Add(new() { Row = 1, Column = 0, Height = rowHeight, Width = columnWidth });
            cells.Add(new() { Row = 1, Column = 1, Height = rowHeight, Width = columnWidth });
            cells.Add(new() { Row = 1, Column = 2, Height = rowHeight, Width = columnWidth });

            return CreateBlockFromCells(cells);
        }

        private static TetrisBlock CreateOrangeRicky(int rowHeight, int columnWidth)
        {
            List<TetrisCellSpecs> cells = new();

            cells.Add(new(){ Row = 1, Column = 0, Height = rowHeight, Width = columnWidth });
            cells.Add(new(){ Row = 1, Column = 1, Height = rowHeight, Width = columnWidth });
            cells.Add(new(){ Row = 1, Column = 2, Height = rowHeight, Width = columnWidth });
            cells.Add(new(){ Row = 0, Column = 2, Height = rowHeight, Width = columnWidth });

            return CreateBlockFromCells(cells);
        }

        private static TetrisBlock CreateHero(int rowHeight, int columnWidth)
        {
            TetrisBlock tetrisBlock = new();

            int cellsCount = 4;

            for (int i = 0; i < cellsCount; i++)
            {
                TetrisCellSpecs cellSpecs = new()
                {
                    Row = 0,
                    Column = i,
                    Width = columnWidth,
                    Height = rowHeight,
                };
                tetrisBlock.Cells.Add(cellSpecs);
            }

            return tetrisBlock;
        }

        private static TetrisBlock CreateSmashboy(int rowHeight, int columnWidth)
        {
            TetrisBlock tetrisBlock = new();

            int columnCount = 2;
            int rowCount = 2;

            for (int col = 0; col < columnCount; col++)
            {
                for (int row = 0; row < rowCount; row++)
                {
                    TetrisCellSpecs cellSpecs = new()
                    {
                        Row = row,
                        Column = col,
                        Width = columnWidth,
                        Height = rowHeight,
                    };
                    tetrisBlock.Cells.Add(cellSpecs);
                }
            }

            return tetrisBlock;
        }
    }
}

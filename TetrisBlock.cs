using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class TetrisBlock
    {
        public List<TetrisCellSpecs> Cells { get; } = new List<TetrisCellSpecs>();

        public static TetrisBlock CreateLine(int cellsCount, int rowHeight, int columnWidth)
        {
            TetrisBlock tetrisBlock = new();

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

        public static TetrisBlock CreateSquare(int rowHeight, int columnWidth)
        {
            TetrisBlock tetrisBlock = new();

            int columnCount = 2;
            int rowCount = 2;

            for (int col = 0; col < columnCount; col++)
            {
                for (int row = 0; row < rowCount; row++)
                {
                    TetrisCellSpecs cellSpecs1 = new()
                    {
                        Row = row,
                        Column = col,
                        Width = columnWidth,
                        Height = rowHeight,
                    };
                    tetrisBlock.Cells.Add(cellSpecs1);
                }
            }

            return tetrisBlock;
        }
    }

    internal struct TetrisCellSpecs
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

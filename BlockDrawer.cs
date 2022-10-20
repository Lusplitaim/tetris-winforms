using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class BlockDrawer
    {
        internal void DrawBlock(Bitmap bmp, TetrisBlock block)
        {
            DrawCells(bmp, block.Cells);
        }

        internal void DrawCells(Bitmap bmp, IEnumerable<TetrisCellSpecs> cells)
        {
            foreach (var cellSpecs in cells)
            {
                Point upperLeftPoint = new(cellSpecs.X, cellSpecs.Y);
                FillCell(bmp, upperLeftPoint, cellSpecs.Width, cellSpecs.Height);
            }
        }

        private void FillCell(Bitmap bmp, Point upperLeft, int width, int height)
        {
            using var graphics = Graphics.FromImage(bmp);
            Brush brush = Brushes.Yellow;

            graphics.FillRectangle(brush,
                new(upperLeft.X + 1, upperLeft.Y + 1, width - 1, height - 1));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
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
                Color cellColor = Color.FromArgb(cellSpecs.ArgbColor);
                FillCell(bmp, upperLeftPoint, cellSpecs.Width, cellSpecs.Height, cellColor);
            }
        }

        private void FillCell(Bitmap bmp, Point upperLeft, int width, int height, Color cellColor)
        {
            using var graphics = Graphics.FromImage(bmp);
            SolidBrush brush = new SolidBrush(cellColor);

            graphics.FillRectangle(brush,
                new(upperLeft.X + 1, upperLeft.Y + 1, width - 1, height - 1));
        }
    }
}

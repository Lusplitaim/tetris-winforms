using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class GridDrawer
    {
        private GridStyle _gridStyle;

        internal GridDrawer(GridStyle gridStyle)
        {
            _gridStyle = gridStyle;
        }

        public void DrawGrid(Bitmap bmp)
        {
            using var graphics = Graphics.FromImage(bmp);
            using Pen pen = new(Color.Black);

            DrawRows(graphics, pen);
            DrawColumns(graphics, pen);
        }

        private void DrawRows(Graphics graphics, Pen pen)
        {
            for (int rowIndex = 0; rowIndex < _gridStyle.RowCount + 1; rowIndex++)
            {
                int x1 = 0;
                int x2 = _gridStyle.CellWidth * _gridStyle.ColumnCount;
                int y1 = rowIndex * _gridStyle.CellHeight;
                int y2 = y1;
                graphics.DrawLine(pen, x1, y1, x2, y2);
            }
        }

        private void DrawColumns(Graphics graphics, Pen pen)
        {
            for (int columnIndex = 0; columnIndex < _gridStyle.ColumnCount + 1; columnIndex++)
            {
                int x1 = columnIndex * _gridStyle.CellWidth;
                int x2 = x1;
                int y1 = 0;
                int y2 = _gridStyle.CellHeight * _gridStyle.RowCount;
                graphics.DrawLine(pen, x1, y1, x2, y2);
            }
        }
    }
    internal struct GridStyle
    {
        public int RowCount { get; set; }
        public int ColumnCount { get; set; }
        public int CellHeight { get; set; }
        public int CellWidth { get; set; }
    }
}

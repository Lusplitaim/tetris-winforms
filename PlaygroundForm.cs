using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Tetris
{
    public partial class PlaygroundForm : Form
    {
        private int _cellHeight = 20;
        private int _cellWidth = 20;
        private int _columnCount = 15;
        private int _rowCount = 20;

        private Timer _timer;

        private TetrisBlock _fallingBlock;
        private List<TetrisCellSpecs> _groundedCells = new();

        private GridDrawer _gridDrawer;

        private int _currentRow = 0;

        public PlaygroundForm()
        {
            InitializeComponent();
            InitGridDrawer();
            InitBlock();
            InitTimer();
        }

        private void InitBlock()
        {
            _fallingBlock = TetrisBlock
                .CreateLine(4, _cellHeight, _cellWidth);
        }

        private void InitGridDrawer()
        {
            GridStyle gridStyle = new()
            {
                RowCount = _rowCount,
                ColumnCount = _columnCount,
                CellHeight = _cellHeight,
                CellWidth = _cellWidth,
            };
            _gridDrawer = new GridDrawer(gridStyle);
        }

        private void InitTimer()
        {
            _timer = new();
            _timer.Interval = 500;
            _timer.Enabled = true;
            _timer.Tick += timer_Tick;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DrawPlayground();

            ShiftFallingBlock();

            bool isAtBottom = _fallingBlock.Cells.Any(cellSpecs =>
            {
                return cellSpecs.Row == (_rowCount - 1);
            });

            var tmpBlocks = _fallingBlock.Cells.Select(c =>
            {
                c.Row++;
                return c;
            });

            isAtBottom = isAtBottom || tmpBlocks.Intersect(_groundedCells).Any();
            //_fallingBlock.Cells.Intersect(_groundedCells).Any()


            if (isAtBottom)
            {
                _groundedCells.AddRange(_fallingBlock.Cells);

                _fallingBlock = TetrisBlock
                    .CreateLine(4, _cellHeight, _cellWidth);
            }
        }

        private void DrawPlayground()
        {
            Bitmap bmp = new(Width, Height);

            _gridDrawer.DrawGrid(bmp);

            DrawFallingBlock(bmp);

            DrawGroundedCells(bmp);

            UpdatePlayground(bmp);
        }

        private void DrawGroundedCells(Bitmap bmp)
        {
            foreach (var cellSpecs in _groundedCells)
            {
                Point upperLeftPoint = new(cellSpecs.X, cellSpecs.Y);
                FillCell(bmp, upperLeftPoint);
            }
        }

        private void ShiftFallingBlock()
        {
            for (int i = 0; i < _fallingBlock.Cells.Count(); i++)
            {
                var cellSpecs = _fallingBlock.Cells[i];
                if (++cellSpecs.Row >= _rowCount) cellSpecs.Row = _rowCount - 1;
                _fallingBlock.Cells[i] = cellSpecs;
            }
        }

        private void DrawFallingBlock(Bitmap bmp)
        {
            for (int i = 0; i < _fallingBlock.Cells.Count(); i++)
            {
                var cellSpecs = _fallingBlock.Cells[i];
                Point upperLeftPoint = new(cellSpecs.X, cellSpecs.Y);
                FillCell(bmp, upperLeftPoint);
            }
        }

        private void FillCell(Bitmap bmp, Point upperLeft)
        {
            using var graphics = Graphics.FromImage(bmp);
            Brush brush = Brushes.Yellow;

            graphics.FillRectangle(brush,
                new(upperLeft.X + 1, upperLeft.Y + 1, _cellWidth - 1, _cellHeight - 1));
        }

        private void UpdatePlayground(Bitmap bmp)
        {
            PlaygroundBox.Image = bmp;
            PlaygroundBox.Update();
        }

        private void Playground_Load(object sender, EventArgs e)
        {
            Width = (_columnCount * _cellWidth) + 18;
            Height = (_rowCount * _cellHeight) + 47;

            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private bool CheckFallingBlockBoundary()
        {
            return _fallingBlock.Cells.Any((cellSpec) =>
            {
                return cellSpec.Column < 0 || cellSpec.Column >= _columnCount;
            });
        }

        private void form_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    TetrisBlockTransformer.MoveBlockToRight(_fallingBlock);
                    if (CheckFallingBlockBoundary())
                    {
                        TetrisBlockTransformer.MoveBlockToLeft(_fallingBlock);
                    }
                    break;

                case Keys.Left:
                    TetrisBlockTransformer.MoveBlockToLeft(_fallingBlock);
                    if (CheckFallingBlockBoundary())
                    {
                        TetrisBlockTransformer.MoveBlockToRight(_fallingBlock);
                    }
                    break;

                case Keys.Up:
                    break;

                case Keys.Down:
                    break;
            }

            DrawPlayground();
        }
    }
}

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

        private TetrisField _field;

        private Bitmap _bmp;

        private TetrisBlock _fallingBlock;
        private List<TetrisCellSpecs> _groundedCells = new();

        public PlaygroundForm()
        {
            InitializeComponent();
            InitField();
            InitFallingBlock();
            InitTimer();
        }

        private void InitField()
        {
            TetrisFieldSpecs fieldSpecs = new() 
            { RowCount = _rowCount, ColumnCount = _columnCount, 
                ColumnWidth = _cellWidth, RowHeight = _cellHeight };

            _field = new TetrisField(fieldSpecs);
        }

        private void InitFallingBlock()
        {
            _fallingBlock = TetrisBlock
                .CreateSquare(_cellHeight, _cellWidth);
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
        }

        private void DrawPlayground()
        {
            if (_bmp is not null) _bmp.Dispose();

            _bmp = _field.DrawField(_fallingBlock, _groundedCells);

            UpdatePlayground(_bmp);
        }

        private void ShiftFallingBlock()
        {
            BlockTransformer.MoveDown(_fallingBlock);

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

            if (isAtBottom)
            {
                _groundedCells.AddRange(_fallingBlock.Cells);

                _fallingBlock = TetrisBlock
                    .CreateLine(4, _cellHeight, _cellWidth);
            }
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
                    BlockTransformer.MoveToRight(_fallingBlock);
                    if (CheckFallingBlockBoundary())
                    {
                        BlockTransformer.MoveToLeft(_fallingBlock);
                    }
                    break;

                case Keys.Left:
                    BlockTransformer.MoveToLeft(_fallingBlock);
                    if (CheckFallingBlockBoundary())
                    {
                        BlockTransformer.MoveToRight(_fallingBlock);
                    }
                    break;

                case Keys.Up:
                    break;

                case Keys.Down:
                    ShiftFallingBlock();
                    break;
            }

            DrawPlayground();
        }
    }
}

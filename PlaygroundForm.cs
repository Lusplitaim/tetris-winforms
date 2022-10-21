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

        public PlaygroundForm()
        {
            InitializeComponent();
            InitField();
            InitTimer();
        }

        private void InitField()
        {
            TetrisFieldSpecs fieldSpecs = new() 
            { RowCount = _rowCount, ColumnCount = _columnCount, 
                ColumnWidth = _cellWidth, RowHeight = _cellHeight };

            _field = new TetrisField(fieldSpecs);
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

            _bmp = _field.DrawField();

            UpdatePlayground(_bmp);
        }

        private void ShiftFallingBlock()
        {
            _field.ShiftFallingBlock();
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

        private void form_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    _field.MoveBlockToRight();
                    break;

                case Keys.Left:
                    _field.MoveBlockToLeft();
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

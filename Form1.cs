namespace Tetris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            PlaygroundForm playground = new();
            playground.ShowDialog();
        }
    }
}
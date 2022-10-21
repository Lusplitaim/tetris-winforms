namespace Tetris
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartGame = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RowCountUpDown = new System.Windows.Forms.NumericUpDown();
            this.ColumnCountUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.RowCountUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnCountUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // StartGame
            // 
            this.StartGame.Location = new System.Drawing.Point(325, 168);
            this.StartGame.Name = "StartGame";
            this.StartGame.Size = new System.Drawing.Size(164, 71);
            this.StartGame.TabIndex = 0;
            this.StartGame.Text = "Start Game";
            this.StartGame.UseVisualStyleBackColor = true;
            this.StartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Rows";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 357);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Columns";
            // 
            // RowCountUpDown
            // 
            this.RowCountUpDown.Location = new System.Drawing.Point(339, 288);
            this.RowCountUpDown.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.RowCountUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.RowCountUpDown.Name = "RowCountUpDown";
            this.RowCountUpDown.Size = new System.Drawing.Size(150, 27);
            this.RowCountUpDown.TabIndex = 5;
            this.RowCountUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // ColumnCountUpDown
            // 
            this.ColumnCountUpDown.Location = new System.Drawing.Point(339, 357);
            this.ColumnCountUpDown.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.ColumnCountUpDown.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.ColumnCountUpDown.Name = "ColumnCountUpDown";
            this.ColumnCountUpDown.Size = new System.Drawing.Size(150, 27);
            this.ColumnCountUpDown.TabIndex = 6;
            this.ColumnCountUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ColumnCountUpDown);
            this.Controls.Add(this.RowCountUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartGame);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.RowCountUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnCountUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button StartGame;
        private Label label1;
        private Label label2;
        private NumericUpDown RowCountUpDown;
        private NumericUpDown ColumnCountUpDown;
    }
}
namespace Tetris
{
    partial class PlaygroundForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PlaygroundBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PlaygroundBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PlaygroundBox
            // 
            this.PlaygroundBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlaygroundBox.Location = new System.Drawing.Point(0, 0);
            this.PlaygroundBox.Name = "PlaygroundBox";
            this.PlaygroundBox.Size = new System.Drawing.Size(800, 450);
            this.PlaygroundBox.TabIndex = 0;
            this.PlaygroundBox.TabStop = false;
            // 
            // PlaygroundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PlaygroundBox);
            this.Name = "PlaygroundForm";
            this.Text = "PlaygroundForm";
            this.Load += new System.EventHandler(this.Playground_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.form_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.PlaygroundBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox PlaygroundBox;
    }
}
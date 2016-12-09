namespace Chess
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.NewGameToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.StandartGameToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomGameToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(305, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Chess.Properties.Resources.WhiteQueen;
            this.pictureBox1.Location = new System.Drawing.Point(280, 265);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 81);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuToolStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(680, 24);
            this.menuStrip1.TabIndex = 0;
            // 
            // MenuToolStrip
            // 
            this.MenuToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewGameToolStrip});
            this.MenuToolStrip.Name = "MenuToolStrip";
            this.MenuToolStrip.Size = new System.Drawing.Size(53, 20);
            this.MenuToolStrip.Text = "Меню";
            // 
            // NewGameToolStrip
            // 
            this.NewGameToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StandartGameToolStrip,
            this.CustomGameToolStrip});
            this.NewGameToolStrip.Name = "NewGameToolStrip";
            this.NewGameToolStrip.Size = new System.Drawing.Size(152, 22);
            this.NewGameToolStrip.Text = "Новая игра";
            // 
            // StandartGameToolStrip
            // 
            this.StandartGameToolStrip.Name = "StandartGameToolStrip";
            this.StandartGameToolStrip.Size = new System.Drawing.Size(184, 22);
            this.StandartGameToolStrip.Text = "Стандартная партия";
            // 
            // CustomGameToolStrip
            // 
            this.CustomGameToolStrip.Name = "CustomGameToolStrip";
            this.CustomGameToolStrip.Size = new System.Drawing.Size(184, 22);
            this.CustomGameToolStrip.Text = "Своя партия";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 704);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(696, 743);
            this.MinimumSize = new System.Drawing.Size(696, 743);
            this.Name = "MainForm";
            this.Text = "Шахматы";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuToolStrip;
        private System.Windows.Forms.ToolStripMenuItem NewGameToolStrip;
        private System.Windows.Forms.ToolStripMenuItem StandartGameToolStrip;
        private System.Windows.Forms.ToolStripMenuItem CustomGameToolStrip;
    }
}


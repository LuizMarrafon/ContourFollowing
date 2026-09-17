namespace ContourFollowing
{
    partial class ContourFollowing
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
            menuStrip1 = new MenuStrip();
            arquivoToolStripMenuItem = new ToolStripMenuItem();
            abrirToolStripMenuItem = new ToolStripMenuItem();
            fecharToolStripMenuItem = new ToolStripMenuItem();
            algoritmoDoCegoToolStripMenuItem = new ToolStripMenuItem();
            trabalhoToolStripMenuItem = new ToolStripMenuItem();
            algoritmoDoCego = new ToolStripMenuItem();
            openFileDialog = new OpenFileDialog();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { arquivoToolStripMenuItem, algoritmoDoCegoToolStripMenuItem, trabalhoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1347, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            arquivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { abrirToolStripMenuItem, fecharToolStripMenuItem });
            arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            arquivoToolStripMenuItem.Size = new Size(75, 24);
            arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // abrirToolStripMenuItem
            // 
            abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            abrirToolStripMenuItem.Size = new Size(135, 26);
            abrirToolStripMenuItem.Text = "Abrir";
            abrirToolStripMenuItem.Click += abrirToolStripMenuItem_Click;
            // 
            // fecharToolStripMenuItem
            // 
            fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
            fecharToolStripMenuItem.Size = new Size(135, 26);
            fecharToolStripMenuItem.Text = "Fechar";
            // 
            // algoritmoDoCegoToolStripMenuItem
            // 
            algoritmoDoCegoToolStripMenuItem.Name = "algoritmoDoCegoToolStripMenuItem";
            algoritmoDoCegoToolStripMenuItem.Size = new Size(14, 24);
            // 
            // trabalhoToolStripMenuItem
            // 
            trabalhoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { algoritmoDoCego });
            trabalhoToolStripMenuItem.Name = "trabalhoToolStripMenuItem";
            trabalhoToolStripMenuItem.Size = new Size(81, 24);
            trabalhoToolStripMenuItem.Text = "Trabalho";
            // 
            // algoritmoDoCego
            // 
            algoritmoDoCego.Name = "algoritmoDoCego";
            algoritmoDoCego.Size = new Size(224, 26);
            algoritmoDoCego.Text = "Algoritmo do cego";
            algoritmoDoCego.Click += algoritmoDoCego_Click;
            // 
            // ContourFollowing
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1347, 619);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "ContourFollowing";
            Text = "ContourFollowing";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem arquivoToolStripMenuItem;
        private ToolStripMenuItem abrirToolStripMenuItem;
        private ToolStripMenuItem fecharToolStripMenuItem;
        private OpenFileDialog openFileDialog;
        private ToolStripMenuItem algoritmoDoCegoToolStripMenuItem;
        private ToolStripMenuItem trabalhoToolStripMenuItem;
        private ToolStripMenuItem algoritmoDoCego;
    }
}

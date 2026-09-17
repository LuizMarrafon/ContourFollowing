using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ContourFollowing
{
    public partial class frmMostraImagem : Form
    {
        public frmMostraImagem(Image imagem)
        {
            InitializeComponent();
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Image = imagem;
        }
    }
}

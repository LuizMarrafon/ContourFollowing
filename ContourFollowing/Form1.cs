using static System.Net.Mime.MediaTypeNames;

namespace ContourFollowing
{
    public partial class ContourFollowing : Form
    {
        private System.Drawing.Image imagem;
        public ContourFollowing()
        {
            InitializeComponent();
        }


        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagem = System.Drawing.Image.FromFile(openFileDialog.FileName);
                frmMostraImagem frmMostra = new frmMostraImagem(imagem);

                frmMostra.Show();
            }
        }

        private void algoritmoDoCego_Click(object sender, EventArgs e)
        {
            Bitmap imagemOrigem = new Bitmap(imagem);
            Bitmap imagemDest = new Bitmap(imagemOrigem.Width, imagemOrigem.Height);
            algoritmo.algoritmoCego(imagemOrigem, imagemDest);
            frmMostraImagem form = new frmMostraImagem(imagemDest);
            form.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ContourFollowing
{
    internal class algoritmo
    {
        public static void algoritmoCego(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width - 1; x++)
                {
                    Color cor = imageBitmapSrc.GetPixel(x, y);
                    Color cor2 = imageBitmapSrc.GetPixel(x + 1, y);
                    //pega o pixel da imagem de destino pra saber se esse ponto ja foi usado em algum contorno
                    Color corDestino = imageBitmapDest.GetPixel(x, y);

                    //verifica se o pixel atual é branco
                    bool pixelAtualBranco = cor.R == 255 && cor.G == 255 && cor.B == 255;
                    //verifica se o pixel da direita é preto
                    bool pixelDireitaPreto = cor2.R == 0 && cor2.G == 0 && cor2.B == 0;

                    //se estiver vermelho na imagem de destino quer dizer que esse ponto ja foi contornado antes
                    bool jaFoiContornado = corDestino.R == 255 && corDestino.G == 0 && corDestino.B == 0;

                    //se eu estou em um pixel branco e o da direita é preto e esse ponto ainda nao foi usado em outro contorno entao achei o inicio de um novo contorno
                    if (pixelAtualBranco && pixelDireitaPreto && !jaFoiContornado)
                    {
                        int xInicial = x;
                        int yInicial = y;
                        //pinta o primeiro ponto desse novo contorno
                        imageBitmapDest.SetPixel(x, y, Color.Red);
                        //agora faz o contorno inteiro desse objeto
                        fazerContorno(imageBitmapSrc, imageBitmapDest, xInicial, yInicial);
                    }
                }
            }
        }

        private static void fazerContorno(Bitmap imageBitmapSrc, Bitmap imageBitmapDest, int xInicial, int yInicial)
        {
            //x e y começam no primeiro ponto que eu achei
            int x = xInicial;
            int y = yInicial;

            //coloquei -1 pq no primeiro ponto eu nao sei onde eu vim, mas depois que achar o segundo ponto eu vou saber
            int direcaoDeOndeVim = -1;

            //o primeiro movimento é diferente dos outros por isso primeiro eu procuro o segundo pixel separado
            bool encontrouSegundo = acharSegundoPixel(imageBitmapSrc, ref x, ref y, ref direcaoDeOndeVim);
            if (encontrouSegundo)
            {
                imageBitmapDest.SetPixel(x, y, Color.Red);
                bool terminou = false;
                bool encontrouProximo = true;
                //agora com o segundo ponto, o algoritmo vai indo sozinho
                while (!terminou && encontrouProximo)
                {
                    encontrouProximo = mascara8conectado(imageBitmapSrc, ref x, ref y, ref direcaoDeOndeVim);
                    if (encontrouProximo)
                    {
                        //pinta o novo ponto do contorno
                        imageBitmapDest.SetPixel(x, y, Color.Red);
                        if (x == xInicial && y == yInicial)
                        {
                            terminou = true;
                        }
                    }
                }
            }
        }

        private static bool acharSegundoPixel(Bitmap imageBitmapSrc, ref int x, ref int y, ref int direcaoDeOndeVim)
        {
            int[] vetorX = { 1, 1, 0, -1, -1, -1, 0, 1 };
            int[] vetorY = { 0, -1, -1, -1, 0, 1, 1, 1 };
            bool candidatoDisponivel = false;
            //vai guardar onde esta o segundo pixel caso encontre
            int proxX = -1;
            int proxY = -1;
            //vai guardar de qual direcao eu vim depois que andar pro segundo pixel
            int novaDirecaoDeOndeVim = -1;
            //no primeiro ponto eu testo somente do 4 ate o 7 e paro no primeiro candidato valido que encontrar
            for (int i = 4; i < 8 && !candidatoDisponivel; i++)
            {
                //pega a posicao seguinte
                int proximo = (i + 1) % 8;
                //coordenada do pixel que pode ser o proximo ponto do contorno
                int xCandidato = x + vetorX[i];
                int yCandidato = y + vetorY[i];
                //coordenada do pixel seguinte na mascara
                int xVizinho = x + vetorX[proximo];
                int yVizinho = y + vetorY[proximo];
                //verifica se os dois pixels estao dentro da imagem
                if (xCandidato >= 0 && xCandidato < imageBitmapSrc.Width && yCandidato >= 0 && yCandidato < imageBitmapSrc.Height && xVizinho >= 0 && xVizinho < imageBitmapSrc.Width && yVizinho >= 0 && yVizinho < imageBitmapSrc.Height)
                {
                    Color corCandidato = imageBitmapSrc.GetPixel(xCandidato, yCandidato);
                    Color corVizinho = imageBitmapSrc.GetPixel(xVizinho, yVizinho);
                    //o primeiro pixel do par tem que ser branco e o pixel seguinte tem que ser preto se isso acontecer é um candidato pro contorno
                    if (corCandidato.R == 255 && corCandidato.G == 255 && corCandidato.B == 255 && corVizinho.R == 0 && corVizinho.G == 0 && corVizinho.B == 0)
                    {
                        proxX = xCandidato;
                        proxY = yCandidato;
                        //posição oposta tendeu
                        //i é a direcao que eu estou indo somando 4 eu descubro onde ficou o pixel de onde eu vim em relacao ao novo P
                        novaDirecaoDeOndeVim = (i + 4) % 8;
                        candidatoDisponivel = true;
                    }
                }
            }
            if (candidatoDisponivel)
            {
                //agora x e y deixam de ser o primeiro ponto e passam a ser o segundo ponto
                x = proxX;
                y = proxY;
                //guardo onde esta o pixel de onde eu vim
                direcaoDeOndeVim = novaDirecaoDeOndeVim;
            }
            return candidatoDisponivel;
        }

        private static bool mascara8conectado(Bitmap imageBitmapSrc, ref int x, ref int y, ref int direcaoDeOndeVim)
        {
            int[] vetorX = { 1, 1, 0, -1, -1, -1, 0, 1 };
            int[] vetorY = { 0, -1, -1, -1, 0, 1, 1, 1 };
            bool candidatoDisponivel = false;
            int proxX = -1;
            int proxY = -1;
            int novaDirecaoDeOndeVim = -1;
            //aqui eu ja sei de onde eu vim entao começo a busca por essa direcao e vou dando a volta na mascara
            for (int contador = 0; contador < 7; contador++)
            {
                int i = (direcaoDeOndeVim + contador) % 8;
                int proximo = (i + 1) % 8;
                //pega a coordenada do candidato
                int xCandidato = x + vetorX[i];
                int yCandidato = y + vetorY[i];
                //pega a coordenada do pixel seguinte
                int xVizinho = x + vetorX[proximo];
                int yVizinho = y + vetorY[proximo];
                //primeiro verifica se os pixels estao dentro da imagem
                if (xCandidato >= 0 && xCandidato < imageBitmapSrc.Width && yCandidato >= 0 && yCandidato < imageBitmapSrc.Height && xVizinho >= 0 && xVizinho < imageBitmapSrc.Width && yVizinho >= 0 && yVizinho < imageBitmapSrc.Height)
                {
                    Color corCandidato = imageBitmapSrc.GetPixel(xCandidato, yCandidato);
                    Color corVizinho = imageBitmapSrc.GetPixel(xVizinho, yVizinho);
                    //se o candidato for branco e o proximo da mascara for preto esse pixel pode fazer parte do contorno
                    if (corCandidato.R == 255 && corCandidato.G == 255 && corCandidato.B == 255 && corVizinho.R == 0 && corVizinho.G == 0 && corVizinho.B == 0)
                    {
                        //na busca normal eu nao paro no primeiro, vou salvando e no final fica o ultimo candidato valido
                        proxX = xCandidato;
                        proxY = yCandidato;
                        //descubro onde vai ficar o pixel atual quando eu andar pro novo pixel
                        novaDirecaoDeOndeVim = (i + 4) % 8;
                        candidatoDisponivel = true;
                    }
                }
            }
            if (candidatoDisponivel)
            {
                //ando pro proximo ponto
                x = proxX;
                y = proxY;
                //e atualizo de onde eu vim
                direcaoDeOndeVim = novaDirecaoDeOndeVim;
            }
            return candidatoDisponivel;
        }
    }
}
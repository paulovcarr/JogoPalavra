namespace JogoPalavra
{
    public partial class Form1 : Form
    {
        PalavraJogo palavra = new PalavraJogo();
        public Form1()
        {
            InitializeComponent();
            lbl_Palavra.Text = palavra.exibePalavra();
            lbl_Tentadas.Text = "Informe uma letra ou a palavra completa";
            lbl_Dica.Text = "Dica: " + palavra.exibeDica();
        }

        private class PalavraJogo
        {
            private string palavraSecreta;
            private string dica;
            private List<char> letrasTentadas;
            private int tentativasRestantes;
            private bool ganhouJogo;


            public PalavraJogo()
            {
                EscolhePalavra();
                tentativasRestantes = 2 * contaLetras();
                letrasTentadas = new List<char>();
                ganhouJogo = false;
            }

            private void EscolhePalavra()
            {
                string caminhoArquivo = "palavras.txt";
                string palavraEscolhida = "PALAVRA";
                string dicaEscolhida = "É uma palavra...";

                if (File.Exists(caminhoArquivo))
                {
                    var linhas = File.ReadAllLines(caminhoArquivo)
                        .Select(l => l.Trim())
                        .Where(l => !string.IsNullOrEmpty(l))
                        .ToList();

                    if (linhas.Count > 0)
                    {
                        Random rnd = new Random();
                        int idx = rnd.Next(linhas.Count);

                        // Espera-se que cada linha seja: PALAVRA;DICA
                        var partes = linhas[idx].Split(';');
                        if (partes.Length >= 2)
                        {
                            palavraEscolhida = partes[0].ToUpper();
                            dicaEscolhida = partes[1];
                        }
                        else
                        {
                            palavraEscolhida = linhas[idx].ToUpper();
                        }
                    }
                }

                palavraSecreta = palavraEscolhida;
                dica = dicaEscolhida;
            }

            private int contaLetras()
            {
                List<char> Letras;
                Letras = new List<char>();
                foreach (char letra in palavraSecreta)
                {
                    if (!Letras.Contains(letra))
                    {
                        Letras.Add(letra);
                    }
                }
                return Letras.Count;
            }

            public bool Tentativa(string entrada)
            {
                if (entrada.Length == 1)
                {
                    char letra = entrada[0];
                    if (letrasTentadas.Contains(letra))
                    {
                        // Letra já foi tentada
                        return false;
                    }
                    letrasTentadas.Add(letra);
                    if (palavraSecreta.Contains(letra))
                    {
                        // Letra correta
                        return true;
                    }
                    else
                    {
                        // Letra incorreta
                        tentativasRestantes--;
                        return false;
                    }
                }
                else if (entrada.Length == palavraSecreta.Length)
                {
                    if (entrada == palavraSecreta)
                    {
                        // Palavra correta
                        foreach (char letra in palavraSecreta)
                        {
                            if (!letrasTentadas.Contains(letra))
                            {
                                letrasTentadas.Add(letra);
                            }
                        }
                        ganhouJogo = true;
                        return true;
                    }
                    else
                    {
                        // Palavra incorreta
                        tentativasRestantes--;
                        return false;
                    }
                }
                else
                {
                    // Entrada inválida
                    return false;
                }
            }

            public int TentativasRestantes()
            {
                return tentativasRestantes;
            }

            public string exibeLetrasTentadas()
            {
                return string.Join(", ", letrasTentadas);
            }

            public string exibePalavra()
            {
                string exibicao = "";
                bool faltaLetra = false;
                if (tentativasRestantes <= 0)
                {
                    return palavraSecreta; // Revela a palavra se as tentativas acabaram
                }
                else
                {
                    foreach (char letra in palavraSecreta)
                    {
                        if (letrasTentadas.Contains(letra))
                        {
                            exibicao += letra + " ";
                        }
                        else
                        {
                            exibicao += "? ";
                            faltaLetra = true;
                        }
                    }
                    ganhouJogo = !faltaLetra;
                    return exibicao.Trim();
                }
            }

            public bool ganhou()
            {
                return ganhouJogo;
            }
            public string exibeDica()
            {
                return dica;
            }
        }

        private void btn_Teste_Click(object sender, EventArgs e)
        {
            if (palavra.TentativasRestantes() <= 0 || palavra.ganhou())
            {
                palavra = new PalavraJogo();
                lbl_Palavra.Text = palavra.exibePalavra();
                lbl_Tentadas.Text = "Informe uma letra ou a palavra completa";
                lbl_Dica.Text = "Dica: " + palavra.exibeDica();
                btn_Teste.Text = "Verificar";
                return;
            }
            else
            {
                if (palavra.Tentativa(txt_Entrada.Text))
                {
                    MessageBox.Show("Correto!");
                    if (palavra.ganhou())
                    {
                        MessageBox.Show("Parabéns! Você ganhou o jogo!");
                        btn_Teste.Text = "Novo Jogo";
                    }
                }
                else
                {
                    if (palavra.TentativasRestantes() <= 0)
                    {
                        MessageBox.Show("Game Over! A palavra era: " + palavra.exibePalavra());
                        btn_Teste.Text = "Novo Jogo";

                    }
                    else
                        MessageBox.Show("Incorreto! Tentativas restantes: " + palavra.TentativasRestantes());
                }
                lbl_Palavra.Text = palavra.exibePalavra();
                lbl_Tentadas.Text = "Letras tentadas: " + palavra.exibeLetrasTentadas();
                txt_Entrada.Clear();
            }
        }

        private void txt_Entrada_TextChanged(object sender, EventArgs e)
        {
            txt_Entrada.Text = txt_Entrada.Text.ToUpper();
            txt_Entrada.SelectionStart = txt_Entrada.Text.Length;
        }

        //Se o jogo for fechado, exibe a palavra secreta
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("A palavra secreta era: " + palavra.exibePalavra());
        }
    }
}

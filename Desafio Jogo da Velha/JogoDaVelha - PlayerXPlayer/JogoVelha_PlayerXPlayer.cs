namespace teste
{
    internal class JogoVelhaPlayerXPlayer
    {
        static char[,] jogo = new char[3, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
        static Random r = new Random();

        static char playerAtual = 'X';
        static bool fimJogo = false;

        static void Main(string[] args)
        {

            char resposta;

            Console.WriteLine("## JOGO DA VELHA ##");
            Console.WriteLine();
            Console.WriteLine("Digite uma tecla para iniciar");
            Console.ReadKey();

            do
            {
                reiniciarJogo();
                Console.WriteLine("Gostaria de jogar novamente? (s/n)");
                resposta = char.Parse(Console.ReadLine());
            } while (resposta == 's');

            static void tabelaInicial()
            {
                Console.WriteLine("Escolha uma das posições abaixo:");
                for (int i = 0; i < jogo.GetLength(0); i++)
                {
                    for (int j = 0; j < jogo.GetLength(1); j++)
                    {
                        Console.Write("[" + jogo[i, j] + "]");
                    }
                    Console.WriteLine();
                }
            }

            static void jogada()
            {
                Console.WriteLine("Vez do jogador " + playerAtual + ": ");
                int escolha;
                int escolhaComp;

                while (true)
                {
                    if (playerAtual == 'X')
                    {

                        if (int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= 9)
                        {
                            int linha = (escolha - 1) / 3;
                            int coluna = (escolha - 1) % 3;

                            if (jogo[linha, coluna] != 'X' && jogo[linha, coluna] != 'O')
                            {
                                jogo[linha, coluna] = playerAtual;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Posição ocupada, escolha outra");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida, tente novamente");
                        }
                    }
                    else if (playerAtual == 'O')
                    {
                        if (int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= 9)
                        {
                            int linha = (escolha - 1) / 3;
                            int coluna = (escolha - 1) % 3;

                            if (jogo[linha, coluna] != 'X' && jogo[linha, coluna] != 'O')
                            {
                                jogo[linha, coluna] = playerAtual;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Posição ocupada, escolha outra");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida, tente novamente");
                        }
                    }
                }
            }

            static bool verificarVitoria(char jogador)
            {
                for (int i = 0; i < 3; i++)
                {
                    if ((jogo[i, 0] == jogador && jogo[i, 1] == jogador && jogo[i, 2] == jogador) ||
                        (jogo[0, i] == jogador && jogo[1, i] == jogador && jogo[2, i] == jogador))
                    {
                        return true;
                    }
                }

                if ((jogo[0, 0] == jogador && jogo[1, 1] == jogador && jogo[2, 2] == jogador) ||
                        (jogo[0, 2] == jogador && jogo[1, 1] == jogador && jogo[2, 0] == jogador))
                {
                    return true;
                }
                return false;
            }

            static void verificarVencedor()
            {
                if (verificarVitoria('X'))
                {
                    Console.Clear();
                    tabelaInicial();
                    Console.WriteLine("O jogador X venceu");
                    fimJogo = true;
                }
                else if (verificarVitoria('O'))
                {
                    Console.Clear();
                    tabelaInicial();
                    Console.WriteLine("O jogador O venceu");
                    fimJogo = true;
                }
                else if (verificarEmpate())
                {
                    Console.Clear();
                    tabelaInicial();
                    Console.WriteLine("Empatou");
                    fimJogo = true;
                }
            }

            static void trocarJogador()
            {
                playerAtual = (playerAtual == 'X') ? 'O' : 'X';
            }

            static bool verificarEmpate()
            {
                for (int i = 0; i < jogo.GetLength(0); i++)
                {
                    for (int j = 0; j < jogo.GetLength(1); j++)
                    {
                        if (jogo[i, j] != 'X' && jogo[i, j] != 'O')
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            static int ObterEscolhaComputador()
            {
                int escolhaComp = r.Next(1, 10);
                return escolhaComp;
            }

            static void reiniciarJogo()
            {
                jogo = new char[3, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };

                playerAtual = 'X';
                fimJogo = false;

                do
                {
                    Console.Clear();
                    tabelaInicial();
                    jogada();
                    verificarVencedor();
                    trocarJogador();

                } while (!fimJogo);

            }
        }
    }
}
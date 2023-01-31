using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameHub.Enum;

namespace GameHub.Entity
{

    public class BatalhaNaval
    {
        private readonly Random _random= new Random();
        public int[,] tabuleiro = new int[10,10];
        private readonly List<Navio> _navioList = new List<Navio>();
        
        
        public void Play()
        {
            ColocarNavioAleatoriamente();
            ColocarNavioAleatoriamente();
            Console.WriteLine("Tabuleiro Jogador 1");
            imprimeTabuleiro();
            Console.WriteLine();
            Console.WriteLine("Tabuleiro Jogador 2");
            imprimeTabuleiro();

            do
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("Jogador 1, prepare-se para fazer sua jogada!");
                fazerJogada(tabuleiro);
                Console.WriteLine("Tabuleiro Jogador 2");
                imprimeTabuleiro();
                Console.WriteLine("--------------------------");
                Console.WriteLine("Jogador 2, prepare-se para fazer sua jogada!");
                fazerJogada(tabuleiro);
                Console.WriteLine("Tabuleiro Jogador 1");
                imprimeTabuleiro();
            } while (!AfundouTodos(tabuleiro) || !AfundouTodos(tabuleiro));
        }
        public void ColocarNavioAleatoriamente()
        {
            ColocarCorveta();
        }
        public void ColocarCorveta()
        {
            Navio corveta = new Navio();
            {
                corveta.Comprimento = 2;
                corveta.Orientacao = _random.Next(0,2) == 0? Orientacao.Horizontal : Orientacao.Vertical;
            }
            while (!ValidaPosicao(corveta))
            {
                corveta.X = _random.Next(0, tabuleiro.GetLength(0));
                corveta.Y = _random.Next(0, tabuleiro.GetLength(1));
            }
            _navioList.Add(corveta);
            ColocarNoTabuleiro(corveta);
            ColocarSubmarino();
        }

        public void ColocarSubmarino()
        {
            Navio submarino = new Navio();
            {
                submarino.Comprimento = 3;
                submarino.Orientacao = _random.Next(0, 2) == 0 ? Orientacao.Horizontal : Orientacao.Vertical;
            }
            while (!ValidaPosicao(submarino))
            {
                submarino.X = _random.Next(0, tabuleiro.GetLength(0));
                submarino.Y = _random.Next(0, tabuleiro.GetLength(1));
            }
            _navioList.Add(submarino);
            ColocarNoTabuleiro(submarino);
            ColocarDestroyer();
        }

        public void ColocarDestroyer()
        {
            Navio destroyer = new Navio();
            {
                destroyer.Comprimento = 3;
                destroyer.Orientacao = _random.Next(0, 2) == 0 ? Orientacao.Horizontal : Orientacao.Vertical;
            }
            while (!ValidaPosicao(destroyer))
            {
                destroyer.X = _random.Next(0, tabuleiro.GetLength(0));
                destroyer.Y = _random.Next(0, tabuleiro.GetLength(1));
            }
            _navioList.Add(destroyer);
            ColocarNoTabuleiro(destroyer);
            ColocarCruzador();
        }

        public void ColocarCruzador()
        {
            Navio cruzador = new Navio();
            {
                cruzador.Comprimento = 4;
                cruzador.Orientacao = _random.Next(0, 2) == 0 ? Orientacao.Horizontal : Orientacao.Vertical;
            }
            while (!ValidaPosicao(cruzador))
            {
                cruzador.X = _random.Next(0, tabuleiro.GetLength(0));
                cruzador.Y = _random.Next(0, tabuleiro.GetLength(1));
            }
            _navioList.Add(cruzador);
            ColocarNoTabuleiro(cruzador);
            ColocarPortaAvioes();
        }

        public void ColocarPortaAvioes()
        {
            Navio PortaAvioes = new Navio();
            {
                PortaAvioes.Comprimento = 5;
                PortaAvioes.Orientacao = _random.Next(0, 2) == 0 ? Orientacao.Horizontal : Orientacao.Vertical;
            }
            while (!ValidaPosicao(PortaAvioes))
            {
                PortaAvioes.X = _random.Next(0, tabuleiro.GetLength(0));
                PortaAvioes.Y = _random.Next(0, tabuleiro.GetLength(1));
            }
            _navioList.Add(PortaAvioes);
            ColocarNoTabuleiro(PortaAvioes);
        }

        public bool ValidaPosicao(Navio navio)
        {
            if(navio.Orientacao == Orientacao.Horizontal)
            {
                if (navio.X + navio.Comprimento > tabuleiro.GetLength(0)) return false;
            }
            else
            {
                if (navio.Y + navio.Comprimento > tabuleiro.GetLength(1)) return false;
            }
            if(navio.Orientacao == Orientacao.Horizontal)
            {
                for(int x = navio.X; x < navio.X + navio.Comprimento; x++)
                {
                    if (tabuleiro[x,navio.Y] != 0) return false;
                }
            }
            else
            {
                for (int y = navio.Y; y < navio.Y + navio.Comprimento; y++)
                {
                    if (tabuleiro[navio.X, y] != 0) return false;
                }
            }
            return true;
        }

        private void ColocarNoTabuleiro(Navio navio)
        {
            if (navio.Orientacao == Orientacao.Horizontal)
            {
                for (int x = navio.X; x < navio.X + navio.Comprimento; x++)
                {
                    tabuleiro[x, navio.Y] = 1;
                }
            }
            else
            {
                for (int y = navio.Y; y < navio.Y + navio.Comprimento; y++)
                {
                    tabuleiro[navio.X, y] = 1;
                }
            }
        }


        public bool AfundouTodos(int[,]tabuleiro)
        {
            foreach (var navio in _navioList)
            {
                if (_navioList.Count == 0)
                {
                    return true;
                }
            }
            return false;
        }
       
        public void fazerJogada(int[,] tabuleiro)
        {
            if (AfundouTodos(tabuleiro) == false)
            {
                Console.Write("Digite a linha: para fazer a jogada: ");
                int x = int.Parse(Console.ReadLine());
                Console.Write("Digite a coluna para fazer a jogada: ");
                int y = int.Parse(Console.ReadLine());
                Atirar(x - 1, y - 1);
            }
            
        }

        private void Atirar (int x, int y)
        {
            bool Acertou = false;
            foreach(var navio in _navioList)
            {
                if(navio.X == x && navio.Y == y)
                {
                    navio.fazerJogada(x, y);
                    _navioList.RemoveAt(_navioList.FindIndex(X => navio.X == x && navio.Y == y));
                    
                    Acertou = true;

                    break;
                }
            }
            if(Acertou)
            {

                //_tabuleiro[x, y] = 'X';
                tabuleiro[x, y] = 0;
            }
            else
            {
                tabuleiro[x, y] = 'O';
            }

        }
        public void imprimeTabuleiro()
        {
            Console.WriteLine("  1 2 3 4 5 6 7 8 9 10");
            for(int i = 0; i < 10; i++)
            {
                Console.Write((i + 1)+ " ");
                for(int j = 0; j < 10; j++)
                {
                    if (tabuleiro[i, j] == 1)
                    {
                        Console.Write("N ");//onde os navios estão (para facilitar teste)


                    }
                    else
                    {
                        Console.Write("- ");
                    }

                }
                Console.WriteLine();
            }
        }
    }
}

using GameHub.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameHub.Entity
{
    public class JogoDaVelha
    {
        
        JogadorRepository repository = new JogadorRepository();
        public char[,] tabuleiro = { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
        public void imprimeTabuleiro(char[,] tabuleiro)
        {
            Console.WriteLine($"{tabuleiro[0, 0]} | {tabuleiro[0, 1]} | {tabuleiro[0, 2]} ");
            Console.WriteLine("---------"); 
            Console.WriteLine($"{tabuleiro[1, 0]} | {tabuleiro[1, 1]} | {tabuleiro[1, 2]} ");
            Console.WriteLine("---------");
            Console.WriteLine($"{tabuleiro[2, 0]} | {tabuleiro[2, 1]} | {tabuleiro[2, 2]} ");
        }
        public void imprimeAuxiliar()
        {
            Console.WriteLine($"1 | 2 | 3 ");
            Console.WriteLine("---------");
            Console.WriteLine($"4 | 5 | 6 ");
            Console.WriteLine("---------");
            Console.WriteLine($"7 | 8 | 9 ");
        }

        public void fazerJogada(char[,] tabuleiro, string posicao, char simbolo)
        {
            switch (posicao)
            {
                case "1": tabuleiro[0, 0] = simbolo; break;
                case "2": tabuleiro[0, 1] = simbolo; break;
                case "3": tabuleiro[0, 2] = simbolo; break;
                case "4": tabuleiro[1, 0] = simbolo; break;
                case "5": tabuleiro[1, 1] = simbolo; break;
                case "6": tabuleiro[1, 2] = simbolo; break;
                case "7": tabuleiro[2, 0] = simbolo; break;
                case "8": tabuleiro[2, 1] = simbolo; break;
                case "9": tabuleiro[2, 2] = simbolo; break;
                default: break;

            }
        }

        public bool validaJogada(char[,] tabuleiro, string posicao)
        {
            switch (posicao)
            {
                case "1": return (tabuleiro[0, 0] == ' ');
                case "2": return (tabuleiro[0, 1] == ' ');
                case "3": return (tabuleiro[0, 2] == ' ');
                case "4": return (tabuleiro[1, 0] == ' ');
                case "5": return (tabuleiro[1, 1] == ' ');
                case "6": return (tabuleiro[1, 2] == ' ');
                case "7": return (tabuleiro[2, 0] == ' ');
                case "8": return (tabuleiro[2, 1] == ' ');
                case "9": return (tabuleiro[2, 2] == ' ');
                default: return false;
            }
        }
        public bool teveVencedor(char[,] tabuleiro, char simbolo)
        {
            if ((tabuleiro[0, 0] == simbolo && tabuleiro[0, 1] == simbolo && tabuleiro[0, 2] == simbolo) ||
               (tabuleiro[1, 0] == simbolo && tabuleiro[1, 1] == simbolo && tabuleiro[1, 2] == simbolo) ||
               (tabuleiro[2, 0] == simbolo && tabuleiro[2, 1] == simbolo && tabuleiro[2, 2] == simbolo) ||
               (tabuleiro[0, 0] == simbolo && tabuleiro[1, 0] == simbolo && tabuleiro[2, 0] == simbolo) ||
               (tabuleiro[0, 1] == simbolo && tabuleiro[1, 1] == simbolo && tabuleiro[2, 1] == simbolo) ||
               (tabuleiro[0, 2] == simbolo && tabuleiro[1, 2] == simbolo && tabuleiro[2, 2] == simbolo) ||
               (tabuleiro[0, 0] == simbolo && tabuleiro[1, 1] == simbolo && tabuleiro[2, 2] == simbolo) ||
               (tabuleiro[0, 2] == simbolo && tabuleiro[1, 1] == simbolo && tabuleiro[2, 0] == simbolo))
            {
                return true;
            }
            return false;
        }
        public void turnoJogador1(char[,] tabuleiro, Jogador jogador1)
        {
            string inputUsuario;
            while (true)
            {
                Console.WriteLine($"Vez de {jogador1.Nome} (X)");
                Console.Write("Em qual posição gostaria de fazer sua jogada? (1-9) ");
                inputUsuario = Console.ReadLine();
                if (validaJogada(tabuleiro, inputUsuario))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"A posição {inputUsuario} não é válida!");
                }

            }
            fazerJogada(tabuleiro, inputUsuario, 'X');
        }
        public void turnoJogador2(char[,] tabuleiro, Jogador jogador2)
        {
            string inputUsuario;
            while (true)
            {
                Console.WriteLine($"Vez de {jogador2.Nome} (O)");
                Console.Write("Em qual posição gostaria de fazer sua jogada? (1-9) ");
                inputUsuario = Console.ReadLine();
                if (validaJogada(tabuleiro, inputUsuario))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"A posição {inputUsuario} não é válida!");
                    imprimeTabuleiro(tabuleiro);
                }
            }
            fazerJogada(tabuleiro, inputUsuario, 'O');
        }
        public bool jogoAcabou(char[,] tabuleiro, Jogador jogador1, Jogador jogador2)
        {           
            
            if (teveVencedor(tabuleiro, 'X'))
            {
                imprimeTabuleiro(tabuleiro);
                Console.WriteLine($"{jogador1.Nome} venceu");
                jogador1.VitoriasJDV++;
                jogador1.VitoriasTotais++;
                return true;
            }
            if (teveVencedor(tabuleiro, 'O'))
            {
                repository.LerTodos();
                imprimeTabuleiro(tabuleiro);
                Console.WriteLine($"{jogador2.Nome} venceu");
                jogador2.VitoriasTotais++;
                jogador2.VitoriasJDV++;
                
                return true;
            }
            for (int i = 0; i < tabuleiro.GetLength(0); i++)
            {

                for (int j = 0; j < tabuleiro.GetLength(1); j++)
                {
                    if (tabuleiro[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }
            repository.LerTodos();
            imprimeTabuleiro(tabuleiro);
            Console.WriteLine("Empate!");            
            jogador1.Empates++;
            jogador2.Empates++;
            
            return true;
        }
        public void limpaTabuleiro(char[,] tabuleiro)
        {
            tabuleiro[0, 0] = ' ';
            tabuleiro[0, 1] = ' ';
            tabuleiro[0, 2] = ' ';
            tabuleiro[1, 0] = ' ';
            tabuleiro[1, 1] = ' ';
            tabuleiro[1, 2] = ' ';
            tabuleiro[2, 0] = ' ';
            tabuleiro[2, 1] = ' ';
            tabuleiro[2, 2] = ' ';
        }
        public void Play(Jogador jogador1, Jogador jogador2)
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------");
            imprimeAuxiliar();
            Console.WriteLine("-----------------------------");
            string input;
            

            do
            {
                while (true)
                {
                    turnoJogador1(tabuleiro, jogador1);
                    if (jogoAcabou(tabuleiro, jogador1, jogador2)) break;
                    imprimeTabuleiro(tabuleiro);
                    turnoJogador2(tabuleiro, jogador2);
                    if (jogoAcabou(tabuleiro, jogador2, jogador2)) break;
                    imprimeTabuleiro(tabuleiro);
                }
                Console.Write("Digite [1] - Para jogar novamente e  [2] - Para sair e mostrar os resultados ");
                input = Console.ReadLine();
                if (input != "1" && input != "2")
                {
                    Console.WriteLine("Opção inválida, digite novamente");
                    Console.Write("[1] - Para jogar novamente  [2] - Para sair e mostrar os resultados ");
                }
                if (input == "2")
                {
                    
                    Console.WriteLine($"Status de {jogador1.Nome}:");
                    Console.WriteLine($"Quantidade de vitórias: {jogador1.VitoriasTotais}");
                    Console.WriteLine($"Quantidade de empates: {jogador1.Empates}");

                    Console.WriteLine($"Status de {jogador2.Nome}:");
                    Console.WriteLine($"Quantidade de vitórias: {jogador2.VitoriasTotais}");
                    Console.WriteLine($"Quantidade de empates: {jogador2.Empates}");
                    Console.WriteLine("Encerrando programa...");
                    repository.LerTodosESalvar(jogador1, jogador1.VitoriasTotais, jogador1.Empates);
                    repository.LerTodosESalvar(jogador2, jogador2.VitoriasTotais, jogador2.Empates);
                    

                }
                if (input == "1")
                {
                    limpaTabuleiro(tabuleiro);
                    imprimeAuxiliar();
                }
            } while (input == "1");
        }
    }
}

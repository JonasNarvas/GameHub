using JogoDaVelha;
using System;

namespace jogodavelha;

public class Program
{

    

    public static void Main(string[] args)
    {
        
        string jogarDNV;
        char[,] tabuleiro = { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
        imprimeAuxiliar();
        Console.WriteLine("Vamos cadastrar os jogadores");
        Console.Write("Digite o nome do primeiro jogador: ");
        string nome = Console.ReadLine();
        Jogador jogador1 = new Jogador(nome);
        Console.WriteLine($"Jogador {nome} cadastrado com sucesso!");
        Console.Write("Agora digite o nome do segundo jogador: ");
        nome = Console.ReadLine();
        Jogador jogador2 = new Jogador(nome);
        Console.WriteLine($"Jogador {nome} cadastrado com sucesso!");
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
            if(input != "1" && input != "2")
            {
                Console.WriteLine("Opção inválida, digite novamente");
                Console.Write("[1] - Para jogar novamente  [2] - Para sair e mostrar os resultados ");
            }
            if(input == "2")
            {
                Console.WriteLine($"Status de {jogador1.nome}:");
                Console.WriteLine($"Quantidade de vitórias: {jogador1.vitorias}");
                Console.WriteLine($"Quantidade de empates: {jogador1.empates}"); 

                Console.WriteLine($"Status de {jogador2.nome}:");
                Console.WriteLine($"Quantidade de vitórias: {jogador2.vitorias}");
                Console.WriteLine($"Quantidade de empates: {jogador2.empates}");
                Console.WriteLine("Encerrando programa...");

            }
            if(input == "1")
            {
                limpaTabuleiro(tabuleiro);
                imprimeAuxiliar();
            }
        } while (input == "1");
    }
    static void imprimeTabuleiro(char[,] tabuleiro)
    {
        Console.WriteLine($"{tabuleiro[0,0]} | {tabuleiro[0,1]} | {tabuleiro[0,2]} ");
        Console.WriteLine("---------");
        Console.WriteLine($"{tabuleiro[1,0]} | {tabuleiro[1, 1]} | {tabuleiro[1, 2]} ");
        Console.WriteLine("---------");
        Console.WriteLine($"{tabuleiro[2,0]} | {tabuleiro[2, 1]} | {tabuleiro[2, 2]} ");
    }
    static void imprimeAuxiliar()
    {
        Console.WriteLine($"1 | 2 | 3 ");
        Console.WriteLine("---------");
        Console.WriteLine($"4 | 5 | 6 ");
        Console.WriteLine("---------");
        Console.WriteLine($"7 | 8 | 9 ");
    }

    static void fazerJogada(char[,] tabuleiro, string posicao, char simbolo)
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

    static bool validaJogada(char[,] tabuleiro, string posicao)
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
    static bool teveVencedor(char[,] tabuleiro, char simbolo)
    {
        if ((tabuleiro[0,0] == simbolo && tabuleiro[0,1] == simbolo && tabuleiro[0,2] == simbolo)||
           (tabuleiro[1,0] == simbolo && tabuleiro[1,1] == simbolo && tabuleiro[1,2] == simbolo)||
           (tabuleiro[2,0] == simbolo && tabuleiro[2,1] == simbolo && tabuleiro[2,2] == simbolo)||
           (tabuleiro[0,0] == simbolo && tabuleiro[1,0] == simbolo && tabuleiro[2,0] == simbolo)||
           (tabuleiro[0,1] == simbolo && tabuleiro[1,1] == simbolo && tabuleiro[2,1] == simbolo)||
           (tabuleiro[0,2] == simbolo && tabuleiro[1,2] == simbolo && tabuleiro[2,2] == simbolo)||
           (tabuleiro[0,0] == simbolo && tabuleiro[1,1] == simbolo && tabuleiro[2,2] == simbolo)||
           (tabuleiro[0,2] == simbolo && tabuleiro[1,1] == simbolo && tabuleiro[2,0] == simbolo)){
            return true;
        }       
        return false;       
    }
    static void turnoJogador1(char[,] tabuleiro, Jogador jogador1)
    {
        string inputUsuario;
        while (true)
        {
            Console.WriteLine($"Vez de {jogador1.nome} (X)");
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
    static void turnoJogador2(char[,] tabuleiro, Jogador jogador2)
    {
        string inputUsuario;
        while (true)
        {
            Console.WriteLine($"Vez de {jogador2.nome} (O)");
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
    static bool jogoAcabou(char[,]tabuleiro,Jogador jogador1, Jogador jogador2)
    {
        
        if(teveVencedor(tabuleiro, 'X'))
        {
            imprimeTabuleiro(tabuleiro);
            Console.WriteLine($"{jogador1.nome} venceu");            
            jogador1.vitorias++;
            return true;
        }
        if (teveVencedor(tabuleiro, 'O'))
        {
            imprimeTabuleiro(tabuleiro);
            Console.WriteLine($"{jogador2.nome} venceu");
            jogador2.vitorias++;
            return true;
        }
        for(int i = 0; i < tabuleiro.GetLength(0); i++) {

            for(int j = 0; j< tabuleiro.GetLength(1); j++)
            {
                if (tabuleiro[i,j] == ' ') 
                {
                    return false;
                }
            }
        }
        
        imprimeTabuleiro(tabuleiro);
        Console.WriteLine("Empate!");
        jogador1.empates++;
        jogador2.empates++;
        
        return true;
    }
    static void limpaTabuleiro(char[,] tabuleiro)
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
}
    
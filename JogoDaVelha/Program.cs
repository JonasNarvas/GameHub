using GameHub.Entity;
using System;
using GameHub.Enum;
using GameHub.Repository;

namespace GameHub;

public class Program
{

    

    public static void Main(string[] args)
    {

        int opt;
        JogadorRepository repository = new JogadorRepository();
        List<Jogador> jogadores = new List<Jogador>();
        repository.LerTodos();
        Hub hub= new Hub();
        Console.WriteLine("SEJA BEM VINDO(A) AO GAMEHUB!");
        do
        {
            hub.ShowMenu();
            opt = int.Parse(Console.ReadLine());
            switch (opt)
            {
                case 0: Console.WriteLine("Encerrando o programa...");break;
                case 1: repository.AdicionarJogador(); break;
                case 2: repository.DeletarUmJogador(jogadores); break;
                case 3: repository.LerTodos().ForEach(Console.WriteLine); ;break;
                case 4: repository.ApresentarUmJogador(jogadores);break;
                case 5: repository.Login(jogadores); break;
            }
        } while (opt != 0);
        
        
        
        
            
            
        
    }

}
    
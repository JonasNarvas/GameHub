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
        BatalhaNaval jogar = new BatalhaNaval();
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
                case 4: repository.Login(jogadores); break;
                case 5: jogar.Play();break;
            }
        } while (opt != 0);
        
        
        
        
            
            
        
    }

}
    
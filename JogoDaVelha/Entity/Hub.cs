using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHub.Entity
{
    public class Hub
    {

        public void ShowMenu()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1 - Inserir novo jogador");
            Console.WriteLine("2 - Deletar um jogador");
            Console.WriteLine("3 - Listar todos os jogadores registrados");
            Console.WriteLine("4 - Jogar Jogo da Velha");
            Console.WriteLine("5 - Jogar Batalha Naval | AVISO: AINDA NÃO COMPLETAMENTE FUNCIONAL");
            //Console.WriteLine("6 - Exibir ranking dos jogadores");
            Console.WriteLine("0 - Sair do programa");
            Console.WriteLine("-----------------------------");
            Console.Write("Digite a opção desejada: ");
        }


    }

}

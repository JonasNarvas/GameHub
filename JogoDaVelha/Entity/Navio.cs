using GameHub.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHub.Entity
{
    public  class Navio
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Orientacao Orientacao { get; set; }
        public int Comprimento { get; set; }
        public bool Acertou { get; set; } = false;

        public override string ToString()
        {
            return $"X = {X} \n"+
                $"Y = {Y} \n"+
                $"Orientacao = {Orientacao} \n"+
                $"Comprimento = {Comprimento}";
        }

        public void fazerJogada(int x, int y)
        {
            if (X == x && Y == y)
            {
                Acertou = true;
                Console.WriteLine("O navio foi acertado!");

            }
            else
            {
                Console.WriteLine("Errou!");
            }
        }
    }
}

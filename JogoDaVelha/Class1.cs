using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    class Jogador
    {   public string nome { get; set; }
        public int vitorias { get; set; }
        public int empates { get; set; }

        public Jogador(string nome) {
            this.nome = nome;
            vitorias = 0;
            empates = 0;
        }
    }
}

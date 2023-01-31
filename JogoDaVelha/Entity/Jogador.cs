using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameHub.Repository;

namespace GameHub.Entity
{
    public class Jogador
    {
        public string Nome { get; set; } 
        public string Usuario { get; private set; }
        public string Senha { get; private set; }
        public int VitoriasTotais { get; set; }
        public int VitoriasJDV { get; set; }
        public int VitoriasBN { get; set; }
        public int Empates { get; set; }

        public Jogador(string usuario, string senha)
        {
            Nome = null;
            this.Usuario= usuario;
            this.Senha = senha; ;
            VitoriasTotais = 0;
            VitoriasJDV = 0;
            VitoriasBN= 0;
            Empates = 0;
        }

        public override string ToString()
        {
            return $"Nome: {Nome} | Quantidade de vitórias: {VitoriasTotais} | Quantidade de empates: {Empates}";
        }

        public bool VerificarUsuarioSenha(string usuario)
        {
            if(this.Usuario== usuario) return true ;
            else
            {
                Console.WriteLine("Usuário incorreto, tente novamente...");
                return false;
            }
        }
        public bool VerificarSenha(string senha)
        {
            if(this.Senha==senha) return true ;
            else
            {
                Console.WriteLine("Senha incorreta, tente novamente...");
                return false;
            }
        }
    }
}

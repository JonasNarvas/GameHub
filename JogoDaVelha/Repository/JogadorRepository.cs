using GameHub.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GameHub.Repository
{
    public class JogadorRepository
    {
        public readonly string arquivojson = @"jogador.json";

        public List<Jogador> LerTodos()
        {
            var options = new JsonSerializerOptions { WriteIndented= true };
            string json = File.ReadAllText(arquivojson);
            List<Jogador> jogadores = new List<Jogador>();
            List <Jogador>? leitura = JsonSerializer.Deserialize<List<Jogador>>(json,options);
            if (leitura != null)
            {
                jogadores.AddRange(leitura);
            }
            return jogadores;
            
        }

        public List<Jogador> LerTodosESalvar(Jogador jogador, int vitorias, int empates)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = File.ReadAllText(arquivojson);
            List<Jogador> jogadores = new List<Jogador>();
            List<Jogador>? leitura = JsonSerializer.Deserialize<List<Jogador>>(json, options);
            int indiceParaUpdate;
            if (leitura != null)
            {              
                    indiceParaUpdate = jogadores.FindIndex(x => x.Nome == jogador.Nome);
                if (indiceParaUpdate != 1)
                {
                    jogadores[indiceParaUpdate].VitoriasTotais = vitorias;
                    jogadores[indiceParaUpdate].Empates = empates;

                }
                string jogadorJson = JsonSerializer.Serialize(jogadores, options);
                File.WriteAllText(arquivojson, jogadorJson);
            }
            
            return jogadores;

        }
        public bool SalvarTodos()//List<Jogador> jogadores
        {
            
            var options = new JsonSerializerOptions { WriteIndented= true };
            string json = File.ReadAllText(arquivojson);
            List<Jogador> jogadores = new List<Jogador>();
            List<Jogador>? leitura = JsonSerializer.Deserialize<List<Jogador>>(json, options);
            if (leitura != null) jogadores.AddRange(leitura);
            string jogadorJson = JsonSerializer.Serialize(jogadores,options);          
            File.WriteAllText(arquivojson, jogadorJson);
            return true;

        }

        public bool AdicionarJogador()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = File.ReadAllText(arquivojson);
            List<Jogador> jogadores = new List<Jogador>();
            List<Jogador>? leitura = JsonSerializer.Deserialize<List<Jogador>>(json, options);
            if (leitura != null)
            {
                jogadores.AddRange(leitura);
                Console.Write("Digite um nome de usuário para o jogador: ");
                string usuario = Console.ReadLine();
                Console.Write("Digite o nome do jogador: ");
                string nome = Console.ReadLine();
                Console.Write("Digite a senha para o jogador:");
                string senha = Console.ReadLine();
                Jogador jogador = new Jogador(usuario, senha);
                jogador.Nome = nome;
                jogadores.Add(jogador);

                string salvarEmJson = JsonSerializer.Serialize(jogadores, options);
                File.WriteAllText(arquivojson, salvarEmJson);
                Console.WriteLine("Jogador salvo com sucesso! ");
            }
            return true;
        }
        public bool SalvarUm(List <Jogador> jogador)
        {            
            var options = new JsonSerializerOptions { WriteIndented = true };
            string SalvarEmjson = JsonSerializer.Serialize(jogador, options);
            File.WriteAllText(arquivojson, SalvarEmjson);
            Console.WriteLine("Jogador Salvo com sucesso! ");
            return true;
        }
        public bool DeletarUmJogador(List<Jogador> jogadores)
        {
            string json = File.ReadAllText(arquivojson);
            jogadores = JsonSerializer.Deserialize<List<Jogador>>(json);          
            var options = new JsonSerializerOptions { WriteIndented = true };
            Console.Write("Digite o USUARIO do jogador a ser deletado: ");
            string usuarioParaDeletar = Console.ReadLine();
            int jogadorParaDeletar = jogadores.FindIndex(x => x.Usuario == usuarioParaDeletar);
            if (jogadorParaDeletar == -1)
            {
                Console.WriteLine("Usuário não encontrado ");
                Console.WriteLine("Tente novamente!");
            }
            else
            {
                jogadores.RemoveAt(jogadorParaDeletar);
                json = JsonSerializer.Serialize(jogadores, options);
                File.WriteAllText(arquivojson, json);
                Console.WriteLine("Jogador deletado com sucesso! ");
            }
            return true;
        }
        public void ApresentarUmJogador(List<Jogador> jogadores)
        {
            string json = File.ReadAllText(arquivojson);
            jogadores = JsonSerializer.Deserialize<List<Jogador>>(json);
            var options = new JsonSerializerOptions { WriteIndented = true };
            Console.Write("Digite o USUARIO do jogador a ser apresentado: ");
            string usuarioParaApresentar = Console.ReadLine();
            int jogadorParaApresentar = jogadores.FindIndex(x => x.Usuario == usuarioParaApresentar);
            if(jogadorParaApresentar == -1)
            {
                Console.WriteLine("Usuário não encontrado ");
                Console.WriteLine("Tente novamente! "); ;
            }
            else
            {
                jogadores.ForEach(Console.WriteLine); ;
                json = JsonSerializer.Serialize(jogadores, options);
                File.WriteAllText(arquivojson, json);

            }
        }

        public void Login(List<Jogador> jogadores)
        {
            Console.WriteLine("Para jogar o Jogo da Velha, primeiro precisamos logar 2 jogadores: ");
            string json = File.ReadAllText(arquivojson);
            jogadores = JsonSerializer.Deserialize<List<Jogador>>(json);
            var options = new JsonSerializerOptions { WriteIndented = true };
            int jogadorParaLogar;
            Jogador jogador1; Jogador jogador2;
            JogoDaVelha objJDV = new JogoDaVelha();
            do
            {
                Console.Write("Digite o USUARIO do primeiro jogador a ser logado: ");
                string usuarioParaLogar = Console.ReadLine();
                Console.Write("Digite a SENHA do primeiro jogador a ser logado: ");
                string senhaParaLogar = Console.ReadLine();
                
                jogadorParaLogar = jogadores.FindIndex(x => x.Usuario == usuarioParaLogar && x.Senha ==senhaParaLogar);
                if(jogadorParaLogar != -1)
                {
                    Console.WriteLine("-----------------------------");
                    jogador1 = jogadores[jogadorParaLogar];
                    Console.WriteLine($"Jogador {jogador1.Nome} foi logado com sucesso");
                    Console.WriteLine("-----------------------------");
                }
                else
                {
                    Console.WriteLine("Usuário ou senha inválido ");
                    Console.WriteLine("Tente novamente! ");
                    Console.WriteLine("-----------------------------");
                }
            } while (jogadorParaLogar == -1);

            int jogadorParaLogar2;
            do
            {
                Console.Write("Digite o USUARIO do segundo jogador a ser logado: ");
                string usuarioParaLogar2 = Console.ReadLine();
                Console.Write("Digite a SENHA do segundo jogador a ser logado: ");
                string senhaParaLogar2 = Console.ReadLine();                          
                jogadorParaLogar2 = jogadores.FindIndex(x => x.Usuario == usuarioParaLogar2 && x.Senha == senhaParaLogar2);
                if (jogadorParaLogar2 != -1)
                {
                    Console.WriteLine("-----------------------------");
                    jogador2 = jogadores[jogadorParaLogar2];
                    Console.WriteLine($"Jogador {jogador2.Nome} foi logado com sucesso");
                }
                else
                {
                    Console.WriteLine("Usuário ou senha inválido ");
                    Console.WriteLine("Tente novamente! ");
                    Console.WriteLine("-----------------------------");
                }
                
            } while (jogadorParaLogar2 == -1);
            objJDV.Play(jogadores[jogadorParaLogar], jogadores[jogadorParaLogar2]);
        }
        //repository.LerTodos().ForEach(Console.WriteLine);

    }
}

using System;
using System.Collections.Generic;

namespace JogoCartas
{
    // Classe que representa uma carta
    class Carta
    {
        public string Naipe { get; set; }
        public int Valor { get; set; }

        public Carta(string naipe, int valor)
        {
            Naipe = naipe;
            Valor = valor;
        }

        public override string ToString()
        {
            return $"{Valor} de {Naipe}";
        }
    }

    // Classe que representa um baralho
    class Baralho
    {
        private List<Carta> cartas;
        private Random random = new Random();

        public Baralho()
        {
            cartas = new List<Carta>();
            string[] naipes = { "Copas", "Ouros", "Espadas", "Paus" };

            foreach (var naipe in naipes)
            {
                for (int valor = 1; valor <= 13; valor++)
                {
                    cartas.Add(new Carta(naipe, valor));
                }
            }
        }

        public Carta ComprarCarta()
        {
            if (cartas.Count == 0) return null;
            int indice = random.Next(cartas.Count);
            Carta carta = cartas[indice];
            cartas.RemoveAt(indice);
            return carta;
        }
    }

    // Classe jogador
    class Jogador
    {
        public string Nome { get; set; }
        public Carta CartaAtual { get; set; }

        public Jogador(string nome)
        {
            Nome = nome;
        }
    }

    // Classe principal do jogo
    class Jogo
    {
        private Jogador jogador1;
        private Jogador jogador2;
        private Baralho baralho;

        public Jogo(string nome1, string nome2)
        {
            jogador1 = new Jogador(nome1);
            jogador2 = new Jogador(nome2);
            baralho = new Baralho();
        }

        public void JogarRodada()
        {
            jogador1.CartaAtual = baralho.ComprarCarta();
            jogador2.CartaAtual = baralho.ComprarCarta();

            Console.WriteLine($"{jogador1.Nome} comprou {jogador1.CartaAtual}");
            Console.WriteLine($"{jogador2.Nome} comprou {jogador2.CartaAtual}");

            if (jogador1.CartaAtual.Valor > jogador2.CartaAtual.Valor)
                Console.WriteLine($"{jogador1.Nome} venceu a rodada!");
            else if (jogador1.CartaAtual.Valor < jogador2.CartaAtual.Valor)
                Console.WriteLine($"{jogador2.Nome} venceu a rodada!");
            else
                Console.WriteLine("Empate!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Jogo jogo = new Jogo("Anderson", "Beatriz");
            jogo.JogarRodada();

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}

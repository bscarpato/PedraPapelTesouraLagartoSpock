using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {

        enum OpcoesArmas : byte
        {
            Nenhum = 0,
            Pedra = 1,
            Papel = 2,
            Tesoura = 3,
            Lagarto = 4,
            Spock = 5
        }

        enum Resultado : byte
        {
            Nenhum = 0,
            Empatou = 1,
            Perdeu = 2,
            Ganhou = 3
        }

        enum ModosJogo : byte
        {
            Nenhum = 0,
            Jogador = 1,
            Computador = 2,
            NJogadores = 3
        }

        static void Main(string[] args)
        {
            Random random = new Random();
            bool jogarNovamente = true;
            OpcoesArmas jogador;
            OpcoesArmas jogador2;
            OpcoesArmas computador;
            Resultado resultado;
            ModosJogo modoJogo;


            while (jogarNovamente)
            {
                jogador = OpcoesArmas.Nenhum;
                jogador2 = OpcoesArmas.Nenhum;
                computador = OpcoesArmas.Nenhum;
                resultado = Resultado.Nenhum;
                modoJogo = ModosJogo.Nenhum;
                var answer = 0;
                int numeroJogadores = 0;
                var fimJogada = false;

                Console.WriteLine("Escolha o modo de jogo:");
                Console.WriteLine("1 - Player VS Player");
                Console.WriteLine("2 - Player VS Computador");
                Console.WriteLine("3 - N Players (Random)");

                while ((!int.TryParse(Console.ReadLine(), out answer)))
                {
                    Console.Clear();
                    Console.WriteLine("Escolha o modo de jogo:");
                    Console.WriteLine("1 - Player VS Player");
                    Console.WriteLine("2 - Player VS Computador");
                    Console.WriteLine("3 - N Players (Random)");
                }

                modoJogo = (ModosJogo)answer;

                if (modoJogo == ModosJogo.Computador)
                {
                    ContraComputador(random, out jogador, out computador, resultado, out answer);
                }
                else if (modoJogo == ModosJogo.Jogador)
                {
                    ContraJogador(out jogador, out jogador2, resultado, out answer);
                }
                else
                {
                    ContraNJogadores(random, out resultado, out numeroJogadores, fimJogada);
                }

                Console.WriteLine();
                Console.WriteLine("Jogar novamente? (S/N)");
                if (Console.ReadLine().ToUpper() == "S")
                    jogarNovamente = true;
                else
                    jogarNovamente = false;

            }

            Console.ReadKey();
        }

        private static void ContraJogador(out OpcoesArmas jogador, out OpcoesArmas jogador2, Resultado resultado, out int answer)
        {
            Console.WriteLine("Player 1 - Escolha uma arma para jogar:");
            Console.WriteLine("1 - Pedra");
            Console.WriteLine("2 - Papel");
            Console.WriteLine("3 - Tesoura");
            Console.WriteLine("4 - Lagarto");
            Console.WriteLine("5 - Spock");

            while ((!int.TryParse(Console.ReadLine(), out answer)))
            {
                Console.Clear();
                Console.WriteLine("Player 1 - Escolha uma arma para jogar:");
                Console.WriteLine("1 - Pedra");
                Console.WriteLine("2 - Papel");
                Console.WriteLine("3 - Tesoura");
                Console.WriteLine("4 - Lagarto");
                Console.WriteLine("5 - Spock");
            }

            jogador = (OpcoesArmas)answer;

            Console.WriteLine("Player 2 - Escolha uma arma para jogar:");
            Console.WriteLine("1 - Pedra");
            Console.WriteLine("2 - Papel");
            Console.WriteLine("3 - Tesoura");
            Console.WriteLine("4 - Lagarto");
            Console.WriteLine("5 - Spock");

            while ((!int.TryParse(Console.ReadLine(), out answer)))
            {
                Console.Clear();
                Console.WriteLine("Player 2 - Escolha uma arma para jogar:");
                Console.WriteLine("1 - Pedra");
                Console.WriteLine("2 - Papel");
                Console.WriteLine("3 - Tesoura");
                Console.WriteLine("4 - Lagarto");
                Console.WriteLine("5 - Spock");
            }

            jogador2 = (OpcoesArmas)answer;

            Jogar(jogador, jogador2, ref resultado);

            Console.WriteLine($"Jogador 1: {jogador}");
            Console.WriteLine($"Jogador 2: {jogador2}");

            if (resultado == Resultado.Ganhou)
                Console.WriteLine($"Jogador 1 ganhou!");
            else if (resultado == Resultado.Perdeu)
                Console.WriteLine($"Jogador 2 ganhou!");
            else
                Console.WriteLine($"Empate");
        }
        private static void ContraComputador(Random random, out OpcoesArmas jogador, out OpcoesArmas computador, Resultado resultado, out int answer)
        {
            Console.WriteLine("Escolha uma arma para jogar:");
            Console.WriteLine("1 - Pedra");
            Console.WriteLine("2 - Papel");
            Console.WriteLine("3 - Tesoura");
            Console.WriteLine("4 - Lagarto");
            Console.WriteLine("5 - Spock");

            while ((!int.TryParse(Console.ReadLine(), out answer)))
            {
                Console.Clear();
                Console.WriteLine("Escolha uma arma para jogar:");
                Console.WriteLine("1 - Pedra");
                Console.WriteLine("2 - Papel");
                Console.WriteLine("3 - Tesoura");
                Console.WriteLine("4 - Lagarto");
                Console.WriteLine("5 - Spock");
            }

            jogador = (OpcoesArmas)answer;
            computador = (OpcoesArmas)random.Next(1, 6);

            Jogar(jogador, computador, ref resultado);

            Console.WriteLine($"Jogador: {jogador}");
            Console.WriteLine($"Computador: {computador}");

            if (resultado == Resultado.Ganhou)
                Console.WriteLine($"Jogador ganhou!");
            else if (resultado == Resultado.Perdeu)
                Console.WriteLine($"Computador ganhou!");
            else
                Console.WriteLine($"Empate");
        }
        private static void ContraNJogadores(Random random, out Resultado resultado, out int numeroJogadores, bool fimJogada)
        {
            var listaJogadores = new List<int[]>();

            resultado = Resultado.Nenhum;
            numeroJogadores = 0;

            Console.WriteLine("Escolha o número de jogadores: ");

            while ((!int.TryParse(Console.ReadLine(), out numeroJogadores)))
            {
                Console.Clear();
                Console.WriteLine("Escolha o número de jogadores: ");
            }


            // adicionando todos jogadores na lista
            for (int i = 0; i < numeroJogadores; i++)
            {
                var novoJogador = new int[] { i, random.Next(1, 6) };
                listaJogadores.Add(novoJogador);

                Console.WriteLine($"Jogador {novoJogador[0]} criado. - Arma {(OpcoesArmas)novoJogador[1]}");
            }

            while (true)
            {
                var listaJogadoresGanhadores = new List<int[]>();
                // pegando os pares para jogar
                for (int i = 0; i < listaJogadores.Count - 1; i += 2)
                {
                    var jogador_1 = listaJogadores[i];
                    var jogador_2 = listaJogadores[i + 1];

                    // jogar ate ter um vencedor
                    while (!fimJogada)
                    {
                        Jogar((OpcoesArmas)jogador_1[1], (OpcoesArmas)jogador_2[1], ref resultado);
                        if (resultado == Resultado.Ganhou || resultado == Resultado.Perdeu)
                            fimJogada = true;
                    }

                    if (resultado == Resultado.Ganhou)
                    {
                        listaJogadoresGanhadores.Add(jogador_1);
                        Console.WriteLine($"Jogador {jogador_1[0]} ganhou do jogador {jogador_2[0]}!");
                    }
                    else
                    {
                        listaJogadoresGanhadores.Add(jogador_2);
                        Console.WriteLine($"Jogador {jogador_2[0]} ganhou do jogador {jogador_1[0]}!");
                    }

                }

                listaJogadores = listaJogadoresGanhadores;
                if (listaJogadores.Count == 1)
                    break;
            }

            Console.WriteLine($"Jogador campeão -> {listaJogadores[0].GetValue(0)}");

        }
        private static void Jogar(OpcoesArmas arma1, OpcoesArmas arma2, ref Resultado resultado)
        {
            switch (arma1)
            {
                case OpcoesArmas.Papel:
                    if (arma2 == OpcoesArmas.Papel) resultado = Resultado.Empatou;
                    else if (arma2 == OpcoesArmas.Tesoura || arma2 == OpcoesArmas.Lagarto) resultado = Resultado.Perdeu;
                    else resultado = Resultado.Ganhou;
                    break;
                case OpcoesArmas.Pedra:
                    if (arma2 == OpcoesArmas.Pedra) resultado = Resultado.Empatou;
                    else if (arma2 == OpcoesArmas.Papel || arma2 == OpcoesArmas.Spock) resultado = Resultado.Perdeu;
                    else resultado = Resultado.Ganhou;
                    break;
                case OpcoesArmas.Tesoura:
                    if (arma2 == OpcoesArmas.Tesoura) resultado = Resultado.Empatou;
                    else if (arma2 == OpcoesArmas.Pedra || arma2 == OpcoesArmas.Spock) resultado = Resultado.Perdeu;
                    else resultado = Resultado.Ganhou;
                    break;
                case OpcoesArmas.Lagarto:
                    if (arma2 == OpcoesArmas.Lagarto) resultado = Resultado.Empatou;
                    else if (arma2 == OpcoesArmas.Pedra || arma2 == OpcoesArmas.Tesoura) resultado = Resultado.Perdeu;
                    else resultado = Resultado.Ganhou;
                    break;
                case OpcoesArmas.Spock:
                    if (arma2 == OpcoesArmas.Spock) resultado = Resultado.Empatou;
                    else if (arma2 == OpcoesArmas.Papel || arma2 == OpcoesArmas.Lagarto) resultado = Resultado.Perdeu;
                    else resultado = Resultado.Ganhou;
                    break;

            }
        }

    }


}

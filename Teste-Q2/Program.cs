using System;
using System.Collections.Generic;
using System.Linq;

namespace Teste_Q2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listaCombinação = new List<string>();
            string[] letrasDisponiveis = new string[2] { "A", "B" };
            int tamSequenciaAbrir = 10;
            int opescolhida = 0;

            do
            {
                try
                {

                    Console.WriteLine();
                    Console.WriteLine("=================");
                    Console.WriteLine("Gerar Combinações");
                    Console.WriteLine("=================");
                    Console.WriteLine();
                    Console.WriteLine("Cadeado aberto com a sequência: A B A A B B A B A B");
                    Console.WriteLine();
                    Console.WriteLine("1- Gerar Combinações");
                    Console.WriteLine("2- Sair");
                    opescolhida = int.Parse(Console.ReadLine());

                    //Gerar Combinações
                    if (opescolhida == 1)
                    {
                        ListarCombinações(listaCombinação, letrasDisponiveis, tamSequenciaAbrir, "");
                    }

                    //Sair
                    else if (opescolhida == 2)
                    {
                        break;
                    }

                    //Qualquer número diferente das opções disponíveis
                    else
                    {
                        Console.WriteLine("Opção inválida!");
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine("Opção inválida!");
                }

            } while (opescolhida != 2);
        }
        

        //Exibir Lista de Combinações
        public static void ListarCombinações(List<string> listaCombinação, string[] letrasDisponiveis, int tamSequenciaAbrir, string combinaçãoAtual)
        {
            List<string> listaCadeado = new List<string>();
            string[] sequenciaAbrir = new string[10] { "A", "B", "A", "A", "B", "B", "A", "B", "A", "B" };
            string guardaSequenciaAbrir = "";
            int contaPosição = 0;

            foreach (string letra in sequenciaAbrir)
            {
                guardaSequenciaAbrir = guardaSequenciaAbrir + letra;
            }

            NovaCombinação(listaCombinação, letrasDisponiveis, tamSequenciaAbrir, "");
            Console.WriteLine();
            Console.WriteLine("======================");
            Console.WriteLine("Gerando combinações...");
            Console.WriteLine("======================");
            Console.WriteLine();

            foreach (string combinação in listaCombinação)
            {
                contaPosição++;
                listaCadeado.Add(combinação);
                Console.WriteLine("Posição " + contaPosição + ": " + combinação);

                if (combinação == guardaSequenciaAbrir)
                {
                    Console.WriteLine();
                    Console.WriteLine("===============================");
                    Console.WriteLine("Cadeado aberto na " + contaPosição + "° posição!");
                    Console.WriteLine("===============================");
                    Console.WriteLine();

                    Console.WriteLine("Continuação das combinações possíveis: ");
                    Console.WriteLine();
                }
            }
        }


        //Método recursivo para gerar novas combinações de sequências com as letras disponíveis e tamanho indicado
        public static void NovaCombinação(List<string> listaCombinação, string[] letrasDisponiveis, int tamSequenciaAbrir, string combinaçãoAtual)
        {
            string combinação = combinaçãoAtual;

            for (int i = 0; i < letrasDisponiveis.Length; i++)
            {
                combinação = combinação + letrasDisponiveis[i];

                if (combinação.Length >= tamSequenciaAbrir)
                {
                    listaCombinação.Add(combinação);
                    combinação = combinaçãoAtual;
                }

                else
                {
                    //Recursividade
                    NovaCombinação(listaCombinação, letrasDisponiveis, tamSequenciaAbrir, combinação);
                    combinação = combinaçãoAtual;
                }
            }
        }
    }
}

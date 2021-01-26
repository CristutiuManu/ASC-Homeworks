using System;
using System.Collections.Generic;

namespace TemeASC
{
    public class DiscreteCantor
    {

        private static int Decimal(List<int> coefic)
        {
            int k = 0;
            int n = coefic.Count;
            for (int i = 0; i < coefic.Count; i++, n--)
            {
                k = k + coefic[i];
                k = k * n;
            }

            return k;
        }

        private static List<int> CantorParsing(string cantor)
        {
            List<int> coefic = new List<int>();

            for (int i = 0; i < cantor.Length; i++)
            {
                if (cantor[i] == '*')
                    coefic.Add(int.Parse(cantor[i - 2].ToString()));
            }
            return coefic;
        }

        private static void Cantor(int numar)
        {
            int n = 1;
            int cloneNumber = numar;
            List<int> coefficients = new List<int>();

            while (cloneNumber != 0)
            {
                int a_n = cloneNumber % (n + 1);
                coefficients.Add(a_n);
                cloneNumber = (cloneNumber - a_n) / (n + 1);
                n++;
            }

            Console.Write($"{numar} = ");
            for (int i = coefficients.Count - 1; i >= 1; i--)
            {
                Console.Write($"{coefficients[i]} * {i + 1}! + ");
            }
            Console.Write($"{coefficients[0]} * {1}!");
            Console.WriteLine();
        }

        private static int Number()
        {
            bool state = true;
            int n = 0;
            do
            {
                state = true;
                try
                {
                    Console.Write("Introduceti un numar: ");
                    n = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    state = false;
                }
            } while (!state);

            return n;
        }

        public DiscreteCantor()
        {
            int[] convertedNumbers = new int[] { 2, 7, 19, 87, 1000, 1000000 };
            for (int i = 0; i < convertedNumbers.Length; i++)
            {
                Cantor(convertedNumbers[i]);
            }

            int number = Number();
            Cantor(number);

            Console.Write("Expansion of the cantor: \n");
            string cantor1 = Console.ReadLine();
            List<int> coefic = CantorParsing(cantor1);
            Console.WriteLine(Decimal(coefic));

            Console.Write("Expansion of the cantor: \n");
            cantor1 = Console.ReadLine();
            Console.Write("Expansion of the cantor: \n");
            string cantor2 = Console.ReadLine();

            List<int> coefic2 = CantorParsing(cantor1);
            int first = Decimal(coefic2);
            List<int> coefic3 = CantorParsing(cantor2);
            int second = Decimal(coefic3);
            Cantor(first + second);
        }
    }
}

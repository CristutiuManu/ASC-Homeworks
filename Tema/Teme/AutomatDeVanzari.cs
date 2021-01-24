using System;
namespace TemeASC
{
    public class AutomatDeVanzari
    {
        static int valoareIntrodusa = 0;
        static bool existaRest = false;
        static int valoareRest = 0;

        public static void A()
        {
            Console.WriteLine($" Suma disponibila: {valoareIntrodusa} \n");

            if (existaRest == false)
            {
                Console.Write(" Introduceti o bacnota: ");
                char bacnota = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");

                if (bacnota >= 'a' && bacnota <= 'z')
                {
                    bacnota = (char)(bacnota - 32);
                }
                switch (bacnota)
                {
                    case 'N':
                        valoareIntrodusa = 5;
                        B();
                        break;
                    case 'D':
                        valoareIntrodusa = 10;
                        C();
                        break;
                    case 'Q':
                        existaRest = true;
                        valoareRest = 5;
                        A();
                        break;

                    default:
                        Console.Write("Bacnota introdusa nu este valida. Introduceti una valida. \n");
                        A();
                        break;
                }
            }
            else
            {
                afisare();
            }
        }
       
        public static void B()
        {
            Console.WriteLine($"Suma disponibila: {valoareIntrodusa} ");

            if (existaRest == false)
            {
                Console.WriteLine("Introduceti o bacnota: ");
                char bacnota = Console.ReadKey().KeyChar;

                Console.WriteLine();

                if (bacnota >= 'a' && bacnota <= 'z')
                {
                    bacnota = (char)(bacnota - 32);
                }

                switch (bacnota)
                {
                    case 'N':
                        valoareIntrodusa = 10;
                        C();
                        break;

                    case 'D':
                        valoareIntrodusa = 15;
                        D();
                        break;

                    case 'Q':
                        existaRest = true;
                        valoareRest = 10;
                        valoareIntrodusa = 0;
                        A();
                        break;

                    default:
                        Console.WriteLine(" Bacnota introdusa nu este valida. Introduceti una valida. ");
                        B();
                        break;
                }
            }
        }
      
        public static void C()
        {
            Console.WriteLine($"Valoarea disponibila: {valoareIntrodusa} ");

            if (existaRest == false)
            {
                Console.WriteLine("Introduceti suma de bani: ");
                char bacnota = Console.ReadKey().KeyChar;

                Console.WriteLine();

                if (bacnota >= 'a' && bacnota <= 'z')
                {
                    bacnota = (char)(bacnota - 32);
                }

                switch (bacnota)
                {
                    case 'N':
                        valoareIntrodusa = 15;
                        D();
                        break;

                    case 'D':
                        existaRest = true;
                        valoareRest = 0;
                        valoareIntrodusa = 0;
                        A();
                        break;

                    case 'Q':
                        existaRest = true;
                        valoareRest = 15;
                        valoareIntrodusa = 0;
                        A();
                        break;

                    default:
                        Console.WriteLine("Bacnota introdusa nu este valida. Introduceti una valida. \n");
                        C();
                        break;
                }
            }
        }
        public static void D()
        {
            Console.WriteLine($"Valoarea introdusa este: {valoareIntrodusa} \n");

            if (existaRest == false)
            {
                Console.Write("\n Introduceti o moneda: ");
                char bacnota = Console.ReadKey().KeyChar;

                Console.WriteLine("\n");

                if (bacnota >= 'a' && bacnota <= 'z')
                {
                    bacnota = (char)(bacnota - 32);
                }

                switch (bacnota)
                {
                    case 'N':
                        existaRest = true;
                        valoareRest = 0;
                        valoareIntrodusa = 0;
                        A();
                        break;

                    case 'D':
                        existaRest = true;
                        valoareRest = 5;
                        valoareIntrodusa = 0;
                        A();
                        break;

                    case 'Q':
                        existaRest = true;
                        valoareRest = 15;
                        valoareIntrodusa = 5;
                        A();
                        break;

                    default:
                        Console.WriteLine("Bacnota introdusa nu este valida. Introduceti una valida.");
                        D();
                        break;
                }
            }
        }
 
        public static void afisare()
        {
            Console.WriteLine("Puteti ridica produsul.");

            switch (valoareRest)
            {
                case 0:
                    break;
                case 5:
                    Console.Write("Restul de 5 (N) v-a fost eliberat.\n");
                    break;
                case 10:
                    Console.Write("Restul de 10 (D) v-a fost eliberat.\n");
                    break;
                case 15:
                    Console.Write("Restul de 15 (N si D) v-a fost eliberat.\n");
                    break;
            }

            if (valoareIntrodusa != 0)
            {
                Console.WriteLine();
                existaRest = false;
                valoareRest = 0;
                B();
            }
        }
    }
}

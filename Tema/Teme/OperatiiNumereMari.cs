using System;
namespace TemeASC
{
    public class OperatiiNumereMari
    {
        static int n, a, b;

        public void alegereOptiune()
        {
            Console.WriteLine("Operator de calcule pentru numere mari: \n\n");
            Console.Write("Selectati operatia dorita: \n 1. Adunare \n 2.Scadere \n 3. Inmultire \n 4. Impartire \n 5. Ridicare la putere \n 6. Radacina patrata \n");
            int variante = int.Parse(Console.ReadLine());
            switch (variante)
            {
                case 1:
                    Console.WriteLine(suma());
                    break;
                case 2:
                    Console.WriteLine(scadere());
                    break;
                case 3:
                    Console.WriteLine(inmultire());
                    break;
                case 4:
                    Console.WriteLine(impartire());
                    break;
                case 5:
                    Console.WriteLine(ridicareLaPutere());
                    break;
                case 6:
                    Console.WriteLine(radacinaPatrata());
                    break;
                default:
                    Console.WriteLine("\n Invalid input");
                    break;

            }

        }

        public int suma()
        {
            Console.Write("\n Insert inputs: ");
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());

            return a + b;
        }

        public int scadere()
        {
            Console.Write("\n Insert inputs \n");
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());

            return a - b;
        }

        public int inmultire()
        {
            Console.Write("\n Insert inputs \n");
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());

            return a * b;
        }

        public string impartire()
        {
            Console.Write("\n Insert inputs \n");
            a = (int)float.Parse(Console.ReadLine());
            b = (int)float.Parse(Console.ReadLine());
            string impartire = $"{a / b},{a % b} ";
            return impartire;
        }

        public float ridicareLaPutere()
        {
            Console.Write("\n Insert inputs \n");
            a = (int)float.Parse(Console.ReadLine());
            n = (int)float.Parse(Console.ReadLine());
            return (float)Math.Pow(a, n);
        }

        public double radacinaPatrata()
        {
            Console.Write("\n Insert inputs \n");
            n = (int)double.Parse(Console.ReadLine());
            return Math.Sqrt(n);
        }
    }
}

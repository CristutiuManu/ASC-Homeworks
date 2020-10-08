using System;

namespace Tema1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert a value");

            int n = int.Parse(Console.ReadLine());
            double years = 1.5 * Math.Log(n, 2);
      
             Console.WriteLine(years);





        }
    }
}

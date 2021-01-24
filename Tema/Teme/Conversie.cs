using System;
using System.Collections.Generic;
using System.Text;
using Tema1;

namespace TemeASC
{
    public class Conversie
    {
        static void conversii()
        {
            Console.WriteLine("Insert a value in base 2");
            string numberBase2;

            numberBase2 = Console.ReadLine();

            Console.WriteLine("Introduceti baza in care vreti sa faceti conversia: 4,8,16");

            int baza;

            baza = int.Parse(Console.ReadLine());


            Dictionary<String, string> base16 = new Dictionary<string, string>();
            base16.Add("0000", "0");
            base16.Add("0001", "1");
            base16.Add("0010", "2");
            base16.Add("0011", "3");

            base16.Add("0100", "4");
            base16.Add("0101", "5");
            base16.Add("0110", "6");
            base16.Add("0111", "7");

            base16.Add("1000", "8");
            base16.Add("1001", "9");
            base16.Add("1010", "A");
            base16.Add("1011", "B");

            base16.Add("1100", "C");
            base16.Add("1101", "D");
            base16.Add("1110", "E");
            base16.Add("1111", "F");

            Dictionary<String, string> base8 = new Dictionary<string, string>();


            base8.Add("000", "0");
            base8.Add("001", "1");
            base8.Add("010", "2");
            base8.Add("011", "3");

            base8.Add("100", "4");
            base8.Add("101", "5");
            base8.Add("110", "6");
            base8.Add("111", "7");




            Dictionary<String, string> base4 = new Dictionary<string, string>();

            base4.Add("00", "0");
            base4.Add("01", "1");
            base4.Add("10", "2");
            base4.Add("11", "3");



            int nrCifre;

            switch (baza)
            {
                case 4:
                    nrCifre = 2;
                    break;

                case 8:
                    nrCifre = 3;
                    break;

                case 16:
                    nrCifre = 4;
                    break;

                default:
                    throw new IncorrectBaseException("Baza nu este corecta");
            }


            int lungimeNumarB2;
            lungimeNumarB2 = numberBase2.Length;

            int nrZerouriDeAdaugat = 0;

            if (lungimeNumarB2 % nrCifre > 0)
            {
                nrZerouriDeAdaugat = nrCifre - lungimeNumarB2 % nrCifre;
            }

            numberBase2 = numberBase2.PadLeft(nrZerouriDeAdaugat + lungimeNumarB2, '0');

            // Console.WriteLine(numberBase2);

            StringBuilder sb = new StringBuilder();
            int i = 0;
            string key;
            Console.WriteLine("Rezultatul este:");
            while (i < numberBase2.Length / nrCifre)
            {
                key = numberBase2.Substring(i * nrCifre, nrCifre);

                switch (baza)
                {
                    case 4:
                        Console.Write(base4[key]);
                        break;

                    case 8:
                        Console.Write(base8[key]);
                        break;

                    case 16:
                        Console.Write(base16[key]);
                        break;

                    default:
                        throw new IncorrectBaseException("Baza nu este corecta");
                }
                i++;
            }
        }
    }
}

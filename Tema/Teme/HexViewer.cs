using System;
using System.IO;

namespace TemeASC
{
    public class HexViewer
    {
        public HexViewer()
        {
            bool lastLine = false;
            int k = 0;
            sbyte i, size = 16;
            string way, text, piece = "";


            Console.Write(" Introduceti calea spre fisier: ");
            way = Console.ReadLine();

            if (File.Exists(way))
            {
                Console.WriteLine("\n Continutul fisierului in hexazecimal este: \n");
            }
            else
            {
                throw new FileNotFoundException("\n Fisierul nu a fost gasit. \n");
            }

            text = File.ReadAllText(way);

            while (text.Length > 0)
            {
                Console.Write($"{k:X7}" + "0: ");

                for (i = 0; i < size; i++)
                {
                    Console.Write($"{(int)text[i]:X2} ");

                    Console.Write(i == 7 && size > 8 ? "| " : "");

                    if (text[i] > 31 && text[i] != 127)
                    {
                        piece += (char)text[i];
                    }
                    else
                    {
                        piece += ".";
                    }
                }
                if (lastLine == true)
                {
                    Console.Write(size > 8 ? piece.PadLeft(57 - 2 * piece.Length)
                        + "\n\n" : piece.PadLeft(59 - 2 * piece.Length) + "\n\n");
                }
                else
                {
                    Console.Write(" | " + piece);
                    Console.WriteLine();

                    piece = "";

                    k++;
                }

                text = text.Substring(size);

                if (text.Length < 16)
                {
                    size = (sbyte)text.Length;
                    lastLine = true;
                    piece = " | ";
                }
            }
        
        }
    }
}

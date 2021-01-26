using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace TemeASC
{
    public class Asamblor_Emulator
    {

        private static StringBuilder VarAndReg(StringBuilder bit, string line, Regex reg, MatchCollection regMatches, Regex var, MatchCollection varMatches)
        {
            string patHelper = ":";
            foreach (Match match in varMatches)
            {
                string pattern = "^" + match.ToString() + patHelper;
                Regex declared = new Regex(pattern);
                int locInMemorie = Memorie(declared);
                bit = RegSource2(bit, ConversionToBinary(locInMemorie));
            }
            Register(bit, line, reg, regMatches);

            return bit;
        }

        private static StringBuilder Register(StringBuilder bit, string line, Regex reg, MatchCollection regMatches)
        {
            int[] regNumbers = new int[regMatches.Count];

            int i = 0;
            foreach (Match match in regMatches)
            {
                regNumbers[i] = int.Parse(match.ToString());
                i++;
            }

            if (regNumbers.Length == 3)
            {
                bit = RegSolution(bit, ConversionToBinary(regNumbers[2]));
                bit = RegSource1(bit, ConversionToBinary(regNumbers[0]));
                bit = RegSource2(bit, ConversionToBinary(regNumbers[1]));
            }
            else if (regNumbers.Length == 2)
            {
                if (regNumbers[0] == 15)
                {
                    bit = RegSource2(bit, ConversionToBinary(4));
                    bit = RegSource1(bit, ConversionToBinary(15));
                    bit = RegSolution(bit, ConversionToBinary(regNumbers[1]));
                }
                else
                {
                    bit = RegSolution(bit, ConversionToBinary(regNumbers[1]));
                    bit = RegSource1(bit, ConversionToBinary(regNumbers[0]));
                }
            }
            else
            {
                bit = RegSolution(bit, ConversionToBinary(regNumbers[0]));
            }
            return bit;
        }

        private static StringBuilder RegSolution(StringBuilder bit, StringBuilder rd)
        {
            for (int i = 0; i < rd.Length; i++)
            {
                bit[i + 2] = rd[i];
            }
            return bit;
        }

        private static StringBuilder RegSource1(StringBuilder bit, StringBuilder rs1)
        {
            for (int i = 0; i < rs1.Length; i++)
            {
                bit[i + 13] = rs1[i];
            }
            return bit;
        }

        private static StringBuilder RegSource2(StringBuilder bit, StringBuilder rs2)
        {
            for (int i = 0; i < rs2.Length; i++)
            {
                bit[i + 27] = rs2[i];
            }
            return bit;
        }

        private static StringBuilder ConversionToBinary(int n)
        {
            int numInBin = 0;
            int putere = 1;

            while (n != 0)
            {
                int ultimCif = n % 2;
                n = n / 2;
                numInBin = numInBin + ultimCif * putere;
                putere = putere * 10;
            }

            string num = numInBin.ToString().PadLeft(5, '0');
            StringBuilder numar = new StringBuilder(num);

            return numar;
        }

        private static StringBuilder SettingBitsToOne(int fromIndex, int toIndex, StringBuilder bit)
        {
            for (int i = fromIndex; i <= toIndex; i++)
            {
                bit[i] = '1';
            }
            return bit;
        }

        static private StringBuilder FirstTwoBitsAndOp3(StringBuilder bit, string line, Regex pattern, MatchCollection matches)
        {
            foreach (Match match in matches)
            {
                string instruction = match.ToString();

                if (instruction == "ld" || instruction == "st")
                {
                    SettingBitsToOne(0, 1, bit);

                    if (instruction == "st")
                    {
                        bit[10] = '1';
                    }
                }
                else if (instruction == "addcc" || instruction == "jmpl")
                {
                    bit[0] = '1';
                    if (instruction == "addcc")
                    {
                        bit[8] = '1';
                    }
                    else
                    {
                        SettingBitsToOne(7, 9, bit);
                    }
                }
            }
            return bit;
        }

        static private int Memorie(Regex variable)
        {
            int m = -4;
            TextReader code = new StreamReader(@"date.in");
            Regex pattern = new Regex(@"\s+\.");    
            string buffer = " ";

            while (!variable.IsMatch(buffer))
            {
                buffer = code.ReadLine();
                if (!pattern.IsMatch(buffer))
                {
                    m = m + 4;
                }
            }
            return m;
        }

        static private int NumOfLines()
        {
            TextReader code = new StreamReader("date.in");
            int k = 0;
            while (code.ReadLine() != null)
            {
                k++;
            }
            return k;
        }

        public static void emulator()
        {
            StreamReader reader = new StreamReader("date.in");
            string binaryCode = "00000000000000000000000000000000";

            int lines = NumOfLines();
            Regex pseudoOp = new Regex(@"\s+\.");

            for (int i = 0; i < lines; i++)
            {
                StringBuilder bit = new StringBuilder(binaryCode);
                string line = reader.ReadLine();

                Regex instruction = new Regex(@"(ld|st|addcc|jmpl)");
                MatchCollection matches = instruction.Matches(line);
                if (instruction.IsMatch(line))
                {
                    bit = FirstTwoBitsAndOp3(bit, line, instruction, matches);
                }

                Regex reg = new Regex(@"(?<=%r)\d{1,2}");
                Regex var = new Regex(@"(?<=\[).+?(?=\])");
                MatchCollection regMatches = reg.Matches(line);
                MatchCollection varMatches = var.Matches(line);

                if (reg.IsMatch(line) && var.IsMatch(line))
                {
                    VarAndReg(bit, line, reg, regMatches, var, varMatches);
                }

                if (reg.IsMatch(line) && !(var.IsMatch(line)))
                {
                    Register(bit, line, reg, regMatches);
                }

                Regex varValue = new Regex(@"(?<=\s+)\d+$");
                MatchCollection m = varValue.Matches(line);

                foreach (Match match in m)
                {
                    int value = int.Parse(match.ToString());
                    StringBuilder val = new StringBuilder(ConversionToBinary(value).ToString());
                    string bitVal = val.ToString();
                    bitVal = bitVal.PadLeft(32, '0');
                    bit = new StringBuilder(bitVal);
                }

                if (!pseudoOp.IsMatch(line))
                {
                    Console.WriteLine(bit);
                }
            }
        }
    }
}
  
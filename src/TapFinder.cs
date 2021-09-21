using System;

namespace LFSR
{
    internal static class TapFinder
    {
        public static bool[] FindTaps(int registerLength)
        {
            Console.WriteLine("For an output stream of maximal period, we require the corresponding feedback polynomial with coefficients in GF(2) to be primitive.");

            bool[] result = new bool[registerLength + 1];

            if (!(2 <= registerLength && registerLength <= 512))
            {
                Console.WriteLine("Invalid register length.");
                return new bool[registerLength + 1];
            }

            string[] tapLookup = Properties.Resources.Taps.Split('\n')[registerLength - 2].Split(' ');
            for (int i = 0; i < tapLookup.Length; i++)
            {
                int.TryParse(tapLookup[i], out int n);

                if (0 <= n && n <= registerLength)
                {
                    result[n] = true;
                }
                else
                {
                    Console.WriteLine("Invalid lookup data encountered.");
                    return new bool[registerLength + 1];
                }
            }

            Console.Write("One such polynomial is");
            for (int i = registerLength; i >= 0; i--)
            {
                if (result[i])
                {
                    if (i > 0)
                    {
                        Console.Write($" x^{i} +");
                    }
                    else
                    {
                        Console.Write(" 1");
                    }
                }
            }
            Console.WriteLine(".");

            return result;
        }
    }
}
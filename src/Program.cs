using System;
using System.Numerics;
using System.Text;

namespace LFSR
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int registerLength = 0b1 << 8;

            LFSR lfsr = new((BigInteger)0b1u << (registerLength - 1) | 1, TapFinder.FindTaps(registerLength));

            BigInteger count = 0;
            while (++count < (BigInteger)0b1u << registerLength)
            {
                Console.Write(lfsr.State.ToNBase(2)[^1]);

                lfsr.Advance();
            }
        }
    }

    internal static class BigIntegerExtensions
    {
        public static string ToNBase(this BigInteger a, int n)
        {
            StringBuilder sb = new StringBuilder();
            while (a > 0)
            {
                sb.Insert(0, a % n);
                a /= n;
            }

            return sb.ToString();
        }
    }
}
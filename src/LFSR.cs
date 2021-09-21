using System.Numerics;

namespace LFSR
{
    internal class LFSR
    {
        private bool[] taps;

        public BigInteger State
        {
            get;
            private set;
        }

        public LFSR(BigInteger seed, bool[] _taps)
        {
            taps = _taps;
            State = seed;
        }

        public void Advance()
        {
            BigInteger temp = State;
            for (int i = 1; i < taps.Length - 1; ++i)
            {
                if (taps[i]) temp ^= State >> (taps.Length - 1 - i);
            }
            State = State >> 1 | ((temp & 1u) << (taps.Length - 2));
        }
    }
}
using System;

namespace Lab1Pseudo_random_sequences
{
    public class Testing
    {
        private static bool getBitValue(uint bitSeq, int bitNum)
        {
            return (bitSeq & 1 << bitNum) != 0;
        }
        
        public static int LinearTest(bool[] sequence)
        {
            int size = sequence.Length;
            uint C = 0;
            uint B = 0;
            int x = 0;
            int L = 0;
            int N = 0;
            while (N!=size)
            {
                bool d = sequence[N];
                for (int j = 1; j < L; j++)
                {
                    d ^= getBitValue(C, j) & sequence[N-j];
                }

                if (!d)
                {
                    x += 1;
                }
                else if (2*L > N)
                {
                    C ^= (uint)1 << x;
                    x += 1;
                }
                else
                {
                    uint temp = C;
                    C ^= (uint)((1 << x) * B);
                    B = temp;
                    L = N + 1 - L;
                    x = 0;
                }
                N += 1;
            }
            Console.WriteLine("Recombining register: {0}",Convert.ToString(C, 2));
            return L;
        }
    }
}
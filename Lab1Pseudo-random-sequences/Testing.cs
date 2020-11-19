using System;
using System.Linq;

namespace Lab1Pseudo_random_sequences
{
    public static class Testing
    {
        // private static bool getBitValue(uint bitSeq, int bitNum)
        // {
        //     return (bitSeq & 1 << bitNum) != 0;
        // }
        
        public static int LinearTest(bool[] sequence)
        {
            int size = sequence.Length;
            var CArr = new bool[size];
            var BArr = new bool[size];
            CArr[0] = true;
            BArr[0] = true;
            uint C = 1;
            uint B = 1;
            int x = 1;
            int L = 0;
            int N = 0;
            do
            {
                bool d = sequence[N];
                for (int j = 1; j < L; j++)
                {
                    d ^= CArr[j] & sequence[N - j];
                    //d ^= getBitValue(C, j) & sequence[N-j];
                }

                if (!d)
                {
                    x += 1;
                }
                else if (2 * L > N)
                {
                    for (int i = 0; i < L; i++)
                    {
                        CArr[i + x] ^= BArr[i];
                    }

                    //C ^= B << x;
                    x += 1;
                }
                else
                {
                    var temp = new bool[size];
                    for (int i = 0; i < size; i++)
                    {
                        temp[i] = CArr[i];
                    }

                    for (int i = 0; i < L; i++)
                    {
                        CArr[i + x] ^= BArr[i];
                    }

                    BArr = temp;
                    //uint temp = C;
                    //C ^= B << x;
                    //B = temp;
                    L = N + 1 - L;
                    x = 1;
                }

                N += 1;
            } while (N != size);

            string rR = string.Join(" ", CArr.Reverse());
            rR = rR.Substring(rR.IndexOf("True")).Replace("True", "1").Replace("False", "0").Replace(" ","");
            Console.WriteLine("Representing register: ");
            Console.WriteLine(rR);
            return L;
        }
    }
}
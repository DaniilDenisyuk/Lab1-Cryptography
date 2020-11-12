using System;

namespace Lab1Pseudo_random_sequences
{
    class Program
    {
        static void Main(string[] args)
        {
            int L = Lab1(8, 6, 10000);
            Console.WriteLine("Linear complexity : {0}", L);
        }

        private static int Lab1(int regCnt, int startingRegBitRate, int sequenceSize)
        {
            var tableGenerator = new TableGenerator(regCnt, startingRegBitRate);
            var sequence = new bool[sequenceSize];
            for (int i = 0; i < sequenceSize; i++)
            {
                sequence[i] = tableGenerator.Next();
            }
            var linearComplexity = Testing.LinearTest(sequence);
            Console.WriteLine("The linear complexity of the sequence is:{0:d}", linearComplexity);
            return linearComplexity;
        }
    }
}

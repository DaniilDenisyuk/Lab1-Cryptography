using System.Collections.Generic;

namespace Lab1Pseudo_random_sequences
{
    public class Rules
    {
        public static Dictionary<uint, uint> DRules = new Dictionary<uint, uint>
        {
            {4, 0b_1100},
            {5, 0b_10010},
            {6, 0b_100001},
            {7, 0b_1000100},
            {8, 0b_10001110},
            {9, 0b_100001000},
            {10, 0b_1000000100},
            {11, 0b_10000000010},
            {12, 0b_100000101001},
            {13, 0b_1000000001101},
            {14, 0b_10001000100001},
            {15, 0b_100000000000001},
            {16, 0b_1000100000000101},
            {32, 0b_10000000000000000000000001010111}
        };
    }
}
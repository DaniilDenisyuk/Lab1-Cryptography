using System;
using System.Collections.Generic;

namespace Lab1Pseudo_random_sequences
{
    public class LSFR
    {
        private uint _LSFRSequence;
        private uint _length;
        private List<int> _CFeedbackFuncPos = new List<int>();
        public LSFR(uint length, uint rule, uint seed)
        {
            _length = length;
            _LSFRSequence = seed;
            for (int i = 0; i < _length-1; i++)
            {
                if ((rule & (1 << i)) != 0)
                {
                    _CFeedbackFuncPos.Add(i);
                }
            }
        }

        private bool GetHighestBit()
        {
            return (_LSFRSequence & (1 << (int)_length-1)) != 0;
        }
        
        public bool Next()
        {
            bool next = GetHighestBit();
            bool temp = next;
            foreach (var pos in _CFeedbackFuncPos)
            {
                temp ^= (_LSFRSequence & 1 <<pos) != 0;
            }
            _LSFRSequence <<= 1;
            if (temp)
            {
                _LSFRSequence |= 1;
            }
            return next;
        }
    }
}
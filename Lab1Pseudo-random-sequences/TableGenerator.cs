using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lab1Pseudo_random_sequences
{
    public class TableGenerator
    {
        private bool[] _table;
        private LSFR[] _registers;
        public TableGenerator(int regCnt, int startingRegBitRate)
        {
            _registers = new LSFR[regCnt];
            var rules = Rules.DRules;
            for (int i = 0; i < regCnt; i++)
            {
                uint bitRate = (uint)(startingRegBitRate + i);
                _registers[i] = new LSFR(bitRate, rules[bitRate], RandomSeed(bitRate));
            }
            FillTable((int)Math.Pow(2, regCnt));
        }

        private void FillTable(int size)
        {
            _table = new bool[size];
            var random = new Random();
            for (int i = 0; i < size; i++)
            {
                _table[i] = random.Next(0,2) != 0;
            }
        }
        private uint RandomSeed(uint bitrate){
            var random = new Random();
            return (uint)random.Next(1,(int)Math.Pow(2, bitrate));
        }

        private int GetAddress()
        {
            int address = 0;
            int i = 0;
            foreach (var lfsr in _registers)
            {
                bool bit = lfsr.Next();
                address |= (bit ?1 : 0) << i;
                i++;
            }
            return address;
        }
        
        private int GetAddressParallel()
        {
            int address = 0;
            Parallel.For(0, _registers.Length, () => 0, (j,loop, subtotal) =>
            {
                bool bit = _registers[j].Next();
                if (bit)
                {
                    subtotal += 1 << j;
                }
                return subtotal;
            }, (x) =>
            {
                Interlocked.Add(ref address, x);

            });
            return address;
        }

        public bool Next()
        {
            return _table[GetAddress()];
        }
    }
    
}
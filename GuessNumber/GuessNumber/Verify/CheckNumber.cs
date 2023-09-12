using GuessNumber.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber.Verify
{
    internal class CheckNumber : ICheck
    {
        private int PrivateCompare(int Result, int GuessedNumber)
        {
            return GuessedNumber.CompareTo(Result);
        }

        public int Compare { get; private set; }

        public bool Verify(int Result, int GuessedNumber)
        {
            Compare = PrivateCompare(Result, GuessedNumber);
            if (Compare == 0) 
            {
                Console.WriteLine("Вы отгадали задуманное число!!!");
                return true;
            }
            if (Compare < 0)
                Console.WriteLine("Меньше");
            else
                Console.WriteLine("Больше");
            return false;
        }
    }
}

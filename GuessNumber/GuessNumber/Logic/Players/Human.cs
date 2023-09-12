using GuessNumber.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber.Logic.Players
{
    internal class Human : IPlayer
    {
        public int Step()
        {
            Console.Write("Введите число:");
            int.TryParse(Console.ReadLine(), out int number);
            return number;
        }
    }
}

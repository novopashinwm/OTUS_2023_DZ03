using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber.Interfaces
{
    public interface ICheck
    {
        int Compare { get; }
        bool Verify(int Result, int GuessedNumbe);
    }
}

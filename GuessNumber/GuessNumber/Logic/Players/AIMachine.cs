using GuessNumber.Config;
using GuessNumber.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber.Logic.Players
{
    /// <summary>
    /// Искуственный интеллект отгадывает число методом деления отрезка пополам
    /// </summary>
    public class AIMachine : IPlayer
    {        
        int Start, End, Mid;
        readonly ICheck  _check;
        public AIMachine(ICheck check, AppConfig config) 
        { 
            _check = check;
            Start = config.MinOfRange;
            End = config.MaxOfRange;
            Mid = (Start + End) / 2;
        }
        public int Step()
        {
            if (_check.Compare < 0)
                End = Mid;
            if (_check.Compare > 0)
                Start = Mid;
            Mid =(Start + End)/2;
            
            return Mid;
        }
    }
}

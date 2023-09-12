using GuessNumber.Config;
using GuessNumber.Interfaces;
using GuessNumber.Logic.Players;

using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber.Logic
{
    public class GuessNumberGame : IGame
    {
        ILogger<GuessNumberGame> _logger;
        AppConfig _appConfig;
        ICheck _resultCheck;
        IPlayer _player;
        private int gueesNumber;
        private int _attempt;
        private int _current;
        public GuessNumberGame(AppConfig appConfig,
                               ILogger<GuessNumberGame> logger,
                               ICheck resultCheck,
                               IPlayer player)
        {
            _logger = logger;
            _appConfig = appConfig;
            _resultCheck = resultCheck;
            _player = player;
            Random r = new Random();
            gueesNumber = r.Next(_appConfig.MinOfRange, _appConfig.MaxOfRange);
            _attempt = _appConfig.Attempts;
        }

        public void Start()
        {
            NewSessionGame();
        }

        private void NewSessionGame()
        {
            Console.WriteLine("Программа угадай число!");
            Console.WriteLine($"Число попыток {_appConfig.Attempts}");
            Console.WriteLine();
            Console.WriteLine();
            while (_attempt > 0) 
            {
                Console.WriteLine($"Попытка {_attempt}");
                _current = _player.Step();
                Console.WriteLine($"Ваше число {_current}");
                if (_resultCheck.Verify(_current, gueesNumber))
                    break;
                _attempt--;
                if (_attempt == 0) 
                {
                    Console.WriteLine("Вы исчерпали количество попыток!");
                    Console.WriteLine($"Я загадал число {gueesNumber}");
                    return;
                }
                Console.WriteLine(new string('=',50));
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public void Stop()
        {
            Console.WriteLine("Игра окончена!!!");
        }
    }
}

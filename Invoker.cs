using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandPatternArmy
{
    public class Commander
    {
        readonly string _armyName;
        readonly bool _isEnemy;
        readonly ConsoleColor _armyColor;

        IList<ICommand> _commands;

        public Commander(string armyName, bool isEnemy)
        {
            _commands = new List<ICommand>();
            _armyName = armyName;
            _isEnemy = isEnemy;
            _armyColor = isEnemy ? ConsoleColor.Red : ConsoleColor.Green;
        }

        public void ExecuteCommand(ICommand cmd)
        {
            StartResultLine();

            _commands.Add(cmd);
            cmd.Execute();
        }

        public void Status()
        {
            Console.ForegroundColor = _armyColor;
            Console.WriteLine($"____{_armyName}____");
            Console.ResetColor();

            Console.WriteLine($"##__Attack_Attempts__##:  {CommandCount<AttackCommand>()}");
            if(!_isEnemy)
                Console.WriteLine($"##___Move_Attempts___##:  {CommandCount<ForwardCommand>()}\n");
        }

        private int CommandCount<T>() => _commands.OfType<T>().ToList().Count;

        private void StartResultLine() 
        {
            Console.ForegroundColor = _armyColor;
            Console.Write($"{_armyName}: ");
            Console.ResetColor();
        }
    }
}

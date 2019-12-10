using System;

namespace CommandPatternArmy
{
    public class Game
    {
        readonly int _paces;

        string _cmd;
        HomeArmy _army;
        EnemyArmy _enemy;
        Commander _commander;
        Commander _enemyCommander;

        public Game(int paces, string armyName, string enemyName) 
        {
            _paces = paces;
            _army = new HomeArmy(paces * 10, _paces * 3);
            _commander = new Commander(armyName, false);
            _enemy = new EnemyArmy(paces * 10, _paces * 3);
            _enemyCommander = new Commander(enemyName, true);
        }

        public void Launch()
        {
            do
            {
                GameStatus();
                _cmd = Console.ReadLine().ToUpper();
                BreakBar();
                switch (_cmd)
                {
                    case "A":
                        _commander.ExecuteCommand(new AttackCommand(_army, _enemy));
                        if(_enemy.Count > 0)
                            _enemyCommander.ExecuteCommand(new AttackCommand(_enemy, _army));
                        Continue();
                        break;
                    case "F":
                        _commander.ExecuteCommand(new ForwardCommand(_army));
                        _enemyCommander.ExecuteCommand(new AttackCommand(_enemy, _army));
                        Continue();
                        break;
                    case "P":
                        _commander.Status();
                        _enemyCommander.Status();
                        Continue();
                        break;
                    case "X":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nInvalid Command");
                        Continue();
                        break;
                }
                Console.Clear();
            } while (ContinueGame());
            DetermineWinner();
        }

        private bool ContinueGame() => _paces > _army.Moves && _army.Count > 0 && _enemy.Count > 0 && _cmd != "X";
        
        #region Prompts
        public void GameStatus()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(">>>>>>>>>>>>>>>>  TAKE_the_FORT  <<<<<<<<<<<<<<<<");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Army Soldiers:       ");
            Console.ResetColor();
            Console.WriteLine(_army.Count);
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enemy Soldiers:      ");
            Console.ResetColor();
            Console.WriteLine(_enemy.Count);
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Distance from Fort:  ");
            Console.ResetColor();
            Console.WriteLine($"{_paces - _army.Moves}\n");

            Console.WriteLine("[A] Attack");
            Console.WriteLine("[F] Move Forward");
            Console.WriteLine("[P] Current Progress");
            Console.WriteLine("[X] Quit Game");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\nKey your command: ");
            Console.ResetColor();
        }

        public void DetermineWinner()
        {
            Console.Clear();

            if((_enemy.Count <= 0 && _army.Count > 0) 
               || (_paces == _army.Moves && _army.Count > _enemy.Count && _army.Count > 0))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("WINNER!! You destroyed the enemy army.");
            }
            else if (_army.Count <= 0 && _enemy.Count <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("---- Stalement ----\nWar is futile; you destroyed yourselves.");
            }
            else if (_cmd == "X")
                Environment.Exit(0);
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("YOU LOSE.\nYour army was destroyed by the enemy.");
            }
            Console.ResetColor();
            ExitGame();
        }

        private void Continue() 
        {
            Console.WriteLine("\nPress [enter] to continue...");
            BreakBar();
            Console.ReadLine();
        }

        private void ExitGame()
        {
            Console.Write("\nPress [enter] to exit game...");
            Console.ReadLine();
            Console.Clear();
            Environment.Exit(0);
        }

        private void BreakBar()
        {
            Console.WriteLine($"\n{new string('+', 40)}\n");
        }
        #endregion
    }
}

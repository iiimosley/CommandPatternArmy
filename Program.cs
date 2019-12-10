using System;

namespace CommandPatternArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("   Command Pattern - Demo App   ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nRULES:");
            Console.ResetColor();
            Console.WriteLine("To win, you must either...");
            Console.WriteLine("  A) Take the fort with a greater number of soldiers than your enemies");
            Console.WriteLine("  B) Destroy all of your enemies");
            Console.WriteLine("\nYou can either Attack or Move Forward - but not at the same time.\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Start a new game...");
            Console.ResetColor();

            Console.WriteLine("Please key your battle factor [+int >> rccmd: 5 - 15]");
            Console.Write("  >> factor impacts soldier count, paces to fort, & fatality: ");
            var paces = Int32.Parse(Console.ReadLine());
            Console.Write("Please key your army's name: ");
            var armyName = Console.ReadLine();
            Console.Write("Please key your enemy's name: ");
            var enemyName = Console.ReadLine();

            var game = new Game(paces, armyName, enemyName);
            game.Launch();
        }
    }
}

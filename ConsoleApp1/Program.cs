using BattleShip.BAL;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GameManager gameManager = new GameManager();
            string message = string.Empty;
            gameManager = new GameManager();
            for (int i = 0; i < 10; i++)
            {
                message = gameManager.AddShip(1, "h");
                Console.WriteLine(message);
            }

            for (int j = 0; j < 11; j++)
            {
                message = gameManager.Fire(j, 1);
                Console.WriteLine(message);
            }

            Console.ReadLine();
        }
    }
}

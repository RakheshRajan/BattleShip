using BattleShip.BAL;
using System;
using System.Net.Http;
using System.Text;

namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {
            //GameManager.GameInstance.CreateUser();

            //Case 1- When ship is of 1 unit

            //for (int i = 0; i < 110; i++)
            //{
            //    string message = GameManager.GameInstance.AddShip(1, "h");
            //    Console.WriteLine(message + " *** " + i.ToString());
            //}

            //Case 2- When ship is of 2 unit

            //for (int i = 0; i < 110; i++)
            //{
            //    string message = GameManager.GameInstance.AddShip(2, "h");
            //    Console.WriteLine(message + " *** " + i.ToString());
            //}
            //Console.ReadLine();

            //Case 3- When ship is of 2 unit
            //for (int i = 0; i < 110; i++)
            //{
            //    string message = GameManager.GameInstance.AddShip(3, "h");
            //    Console.WriteLine(message + " *** " + i.ToString());
            //}

            //Case 4- When ship is of 2 unit
            //for (int i = 0; i < 110; i++)
            //{
            //    string message = GameManager.GameInstance.AddShip(4, "h");
            //    Console.WriteLine(message + " *** " + i.ToString());
            //}

            //Case 5- When ship is of 2 unit
            //for (int i = 0; i < 110; i++)
            //{
            //    string message = GameManager.GameInstance.AddShip(5, "h");
            //    Console.WriteLine(message + " *** " + i.ToString());
            //}

            //Case - 6 - When size is given more than the boardsize 
            //string message = GameManager.GameInstance.AddShip(15, "h");
            //Console.WriteLine(message);


            //Case Random - Checks to check if the cordinate is correct 
            //string message = GameManager.GameInstance.AddShip(3, "h");
            //Console.WriteLine(message);
            //message = GameManager.GameInstance.AddShip(7, "h");
            //Console.WriteLine(message);
            //message = GameManager.GameInstance.AddShip(8, "h");
            //Console.WriteLine(message);
            //message = GameManager.GameInstance.AddShip(2, "h");
            //Console.WriteLine(message);


            //Case 1- When ship is of 1 unit

            //for (int i = 0; i < 110; i++)
            //{
            //    string message = GameManager.GameInstance.AddShip(1, "v");
            //    Console.WriteLine(message + " *** " + i.ToString());
            //}

            //Case 2- When ship is of 2 unit

            //for (int i = 0; i < 110; i++)
            //{
            //    string message = GameManager.GameInstance.AddShip(2, "v");
            //    Console.WriteLine(message + " *** " + i.ToString());
            //}

            //Case 3- When ship is of 2 unit
            //for (int i = 0; i < 110; i++)
            //{
            //    string message = GameManager.GameInstance.AddShip(3, "v");
            //    Console.WriteLine(message + " *** " + i.ToString());
            //}

            //Case 4- When ship is of 2 unit
            //for (int i = 0; i < 110; i++)
            //{
            //    string message = GameManager.GameInstance.AddShip(4, "v");
            //    Console.WriteLine(message + " *** " + i.ToString());
            //}

            //Case 5- When ship is of 2 unit
            //for (int i = 0; i < 110; i++)
            //{
            //    string message = GameManager.GameInstance.AddShip(5, "v");
            //    Console.WriteLine(message + " *** " + i.ToString());
            //}

            //Case - 6 - When size is given more than the boardsize 
            //string message = GameManager.GameInstance.AddShip(15, "v");
            //Console.WriteLine(message);


            //Case Random - Checks to check if the cordinate is correct 
            //string message = GameManager.GameInstance.AddShip(3, "v");
            //Console.WriteLine(message);
            //message = GameManager.GameInstance.AddShip(7, "v");
            //Console.WriteLine(message);
            //message = GameManager.GameInstance.AddShip(8, "v");
            //Console.WriteLine(message);
            //message = GameManager.GameInstance.AddShip(2, "v");
            //Console.WriteLine(message);

            //string message = GameManager.GameInstance.AddShip(2, "v");

            HttpClient client = new HttpClient();
            var stringContent = new StringContent("test", Encoding.UTF8, "application/json");
            client.PostAsync("https://localhost:44398/api/BattleShip/CreateShip/1/s", stringContent);
            Console.ReadLine();
        }
    }
}

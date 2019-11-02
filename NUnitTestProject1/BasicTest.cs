using BattleShip.BAL;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        GameManager gameManager;

        [SetUp]
        public void Setup()
        {
            gameManager = new GameManager();
        }

        [Test]
        ///This test is to check whether the right amount of ships are being allocated with the right sizes.
        public void ShipCountChecksCase1()
        {
            for (int i = 0; i < 110; i++)
            {
                gameManager.AddShip(1, "h");
            }

            //Since the unit is 10 X 10. It will allow to allocated a maximum of 100 units.
            if (gameManager.players[0].PlayerBoard.ListShips.Count == 100)
                Assert.Pass();
            else
                Assert.Fail();
        }
        [Test]
        ///This test is to check whether the right amount of ships are being allocated with the right sizes.
        public void ShipCountChecksCase2()
        {
            gameManager = new GameManager();
            for (int i = 0; i < 100; i++)
            {
                gameManager.AddShip(2, "h");
            }

            //Since the unit is 10 X 10. It will allow to allocate a maximum of 50 units.
            if (gameManager.players[0].PlayerBoard.ListShips.Count == 50)
                Assert.Pass();
            else
                Assert.Fail();
        }
        [Test]
        //A ship should not be allocated any unit outside the board. In this case board is 10 x 10,hence a 12 size 
        //row vertically or horizontally is invalid
        public void ShipUnitValidityChecks1()
        {
            gameManager = new GameManager();

            gameManager.AddShip(12, "v");

            //Ship should not be allocated any unit.
            if (gameManager.players[0].PlayerBoard.ListShips.Count > 0)
                Assert.Fail();
            else
                Assert.Pass();
        }
        [Test]
        //Checking whether the correct cordinates are being assigned to the ships.
        public void ShipUnitValidityChecks2()
        {
            gameManager = new GameManager();

            gameManager.AddShip(1, "h"); // Should create ship of 1 unit size, in the cordinate 1,1
            gameManager.AddShip(3, "h"); // Should create ship of 3 unit size, in the cordinates 2,1; 3,1; 4,1
            gameManager.AddShip(7, "h"); // Should create ship of 7 unit size, in the cordinates 1,2; 2,2; 3,2; 4,2; 5,2; 6,2; 7,2; The logic should skip the cordinates 
            //in first row and then should pick from row 2. This is because there wont be 7 rows in available in first row.

            if (gameManager.players[0].PlayerBoard.ListShips[0].listShipUnit[0].XCordinate == 1 && gameManager.players[0].PlayerBoard.ListShips[0].listShipUnit[0].XCordinate == 1)
                Assert.Pass();
            else
                Assert.Fail();

            if (gameManager.players[0].PlayerBoard.ListShips[1].listShipUnit[0].XCordinate == 2 && gameManager.players[0].PlayerBoard.ListShips[0].listShipUnit[0].XCordinate == 1)
                Assert.Pass();
            else
                Assert.Fail();

            if (gameManager.players[0].PlayerBoard.ListShips[2].listShipUnit[0].XCordinate == 1 && gameManager.players[0].PlayerBoard.ListShips[0].listShipUnit[0].XCordinate == 2)
                Assert.Pass();
            else
                Assert.Fail();

        }
        [Test]
        // Allocate a cordinate to a ship. Then fire to the same cordinate and check.
        public void CheckFireCase1()
        {
            gameManager = new GameManager();
            for (int i = 0; i < 10; i++)
            {
                gameManager.AddShip(1, "v");
            }

            gameManager.Fire(1, 1);

            if (gameManager.players[0].PlayerBoard.ListShips[0].listShipUnit[0].IsHit)
                Assert.Pass();
            else
                Assert.Fail();
        }
        [Test]
        // Check if all units associated with a ship are hit, is the ship turning to sunk.
        public void CheckFireCase2()
        {
            gameManager = new GameManager();
            for (int i = 0; i < 10; i++)
            {
                gameManager.AddShip(1, "v");
            }

            gameManager.Fire(1, 1);

            if (gameManager.players[0].PlayerBoard.ListShips[0].IsSunk)
                Assert.Pass();
            else
                Assert.Fail();
        }
        [Test]
        // Add 10 ships and fire at the same 10 ships. All ship should be sunk and the game should be completed
        public void CheckFireCase3()
        {
            gameManager = new GameManager();
            for (int i = 0; i < 10; i++)
            {
                gameManager.AddShip(1, "h");
            }

            for (int j = 0; j < 11; j++)
            {
                gameManager.Fire(j, 1);               
            }

            if (gameManager.players[0].IsGameCompleted)
                Assert.Pass();
            else
                Assert.Fail();
        }
    }
}
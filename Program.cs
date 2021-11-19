using System;
using System.Collections.Generic;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.SetWindowSize(100, 40);
            Console.SetBufferSize(100, 40);
            Console.Clear();
            startGame();
            Console.WriteLine();
            var board = new Board();
            var guiBoard = new BoardGui(board);
            int[] fleetTable = { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
            Ship[] ships = new Ship[10];
            for (var i = 0; i < fleetTable.Length; i++)
            {
                ships[i] = new Ship(fleetTable[i], board);
            }

            for (var i = 0; i < fleetTable.Length; i++)
            {
                var positions = ships[i].positionShip();
                foreach (var item in positions)
                {
                    board.UpdateBoard(item, true, fleetTable[i]);
                }
            }
            guiBoard.DrawBoard();
            Console.ReadKey();
        }
        static void startGame()
        {
            string title = "Battleships";
            Console.SetCursorPosition(Console.WindowWidth / 2 - title.Length / 2, 0);
            Console.WriteLine(title);
            string firstName = "Zenek";
            string secondName = "Balbina";
            Console.SetCursorPosition(Console.WindowWidth / 4 - firstName.Length / 2, 2);
            Console.Write(firstName);
            Console.SetCursorPosition(Console.WindowWidth-(Console.WindowWidth / 4) - firstName.Length / 2, 2);
            Console.Write(secondName);
            Console.WriteLine();
        }
    }
}
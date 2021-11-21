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
            var board1 = new Board();
            var board2 = new Board();
            var guiBoard = new BoardGui(board1, board2);
            int[] fleetTable = { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
            Ship[] ships1 = new Ship[10];
            Ship[] ships2 = new Ship[10];
            for (var i = 0; i < fleetTable.Length; i++)
            {
                ships1[i] = new Ship(fleetTable[i], board1);
                ships2[i] = new Ship(fleetTable[i], board2);
            }

            for (var i = 0; i < fleetTable.Length; i++)
            {
                var positions1 = ships1[i].positionShip();
                foreach (var item in positions1)
                {
                    board1.UpdateBoard(item, true, fleetTable[i]);
                }
                var positions2 = ships2[i].positionShip();
                foreach (var item in positions2)
                {
                    board2.UpdateBoard(item, true, fleetTable[i]);
                }
            }
            Console.WriteLine();
            guiBoard.DrawBoard();

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
            Console.SetCursorPosition(Console.WindowWidth - (Console.WindowWidth / 4) - firstName.Length / 2, 2);
            Console.Write(secondName);
            Console.WriteLine();
        }
    }
}
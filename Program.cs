using System;
using System.Collections.Generic;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {      
            string title = "Battleships";

            Console.SetWindowSize(100, 40);
            Console.SetBufferSize(100, 40);
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth/2-title.Length/2,0);
            Console.WriteLine(title);

            var board = new Board();
            var guiBoard = new BoardGui(board);
            int[] fleetTable = { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
            Ship[] ships = new Ship[10];
            int[,] boardData = new int[30,30];
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

        }
    }
}
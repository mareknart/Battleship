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
            int[] fleetTable = { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
            var player1 = new Player(fleetTable)
            {
                Id = 1,
                Name = "Zenek",
                board = new Board()
            };
            var player2 = new Player(fleetTable)
            {
                Id = 2,
                Name = "Balbina",
                board = new Board()
            };

            startGame(player1.Name, player2.Name);

            var guiBoard = new BoardGui(player1.board, player2.board);

            Ship[] ships1 = new Ship[10];
            Ship[] ships2 = new Ship[10];
            List<int> positions1 = new List<int>();
            for (var i = 0; i < fleetTable.Length; i++)
            {
                ships1[i] = new Ship(fleetTable[i], player1.board);
                ships2[i] = new Ship(fleetTable[i], player2.board);
            }

            for (var i = 0; i < fleetTable.Length; i++)
            {
                positions1 = ships1[i].PositionShip();
                ships1[i].Lifes = positions1;
                foreach (var item in positions1)
                {
                    player1.board.UpdateBoard(item, true, false, fleetTable[i]);
                }
                var positions2 = ships2[i].PositionShip();
                foreach (var item in positions2)
                {
                    player2.board.UpdateBoard(item, true, false, fleetTable[i]);
                }
            }
            guiBoard.DrawBoard();
            //for (var i=0; i<)
            /*
            foreach (var item in ships1[0].Lifes)
            {
                Console.Write($"{item}, ");
            }

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine();
                Console.Write("Podaj pole: ");
                string pole = Console.ReadLine();
                int shot = int.Parse(pole);
                int previousCellValue = board1.BoardCells[shot].CellValue;
                board1.UpdateBoard(shot, board1.BoardCells[shot].IsFull, true, 1);
                if (previousCellValue > 1 && ships1[previousCellValue-5].Lifes.Count>0)
                {
                    ships1[previousCellValue-5].Lifes.Remove(shot);
                }
                Console.Clear();
                //Console.SetCursorPosition(0, 4);
                startGame();
                guiBoard.DrawBoard();
                
                foreach (var item in ships1[0].Lifes)
                {
                    Console.Write($"{item}, ");
                }
            }*/
        }
        static void startGame(string name1, string name2)
        {
            string title = "Battleships";
            title.Trim();
            Console.SetCursorPosition(Console.WindowWidth / 2 - title.Length / 2, 0);
            Console.WriteLine(title);
            Console.SetCursorPosition(Console.WindowWidth / 4 - name1.Length / 2, 2);
            Console.Write(name1);
            Console.SetCursorPosition(Console.WindowWidth - (Console.WindowWidth / 4) - name2.Length / 2, 2);
            Console.Write(name2);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
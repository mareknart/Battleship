using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Board: IBoardInitialise
    {
        
        public int BoardSize { get; set; }
        public Cell[] BoardCells { get; set; }
        public Board()
        {
            BoardSize = 10;
            BoardCells = new Cell[100];
            InitialiseBoard();
        }
        public void InitialiseBoard()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (var j = 0; j < BoardSize; j++)
                {
                    var id = (i * 10) + j;
                    BoardCells[id] = (new Cell() { Id = id, RowPosition = i, ColumnPosition = j, CellValue = 0 });
                }
            }
        }
        public void UpdateBoard(int cellNo, bool isFull, bool isHit, int shipNumber=0)
        {
            BoardCells[cellNo].IsFull = isFull;
            BoardCells[cellNo].CellValue = shipNumber;
            BoardCells[cellNo].IsHitted = isHit;
        }/*
        public void DrawBoard()
        {
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            for (var i = 0; i < BoardSize; i++)
            {
                for (var j = 0; j < BoardSize; j++)
                {
                    var id = (i*10)+j;

                    if (BoardCells[id].IsFull)
                    {
                        Console.ForegroundColor = colors[4];
                        Console.Write(BoardCells[id].CellValue);
                    }
                    else
                    {
                        Console.ForegroundColor = colors[3];
                        Console.Write("*");
                    }
                }
                Console.ForegroundColor = colors[15];
                Console.WriteLine();
            }
            Console.WriteLine();
        }*/
    }
}

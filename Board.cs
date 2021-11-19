using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Board: IBoardInitialise
    {
        private string _columnName = "ABCDEFGHIJ";
        public int BoardSize { get; set; }
        public Cell[] BoardCells { get; set; }
        public Board()
        {
            BoardSize = 10;
            BoardCells = new Cell[101];
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
            //randomFilling();
        }
        public void UpdateBoard(int cellNo, bool state, int shipNumber)
        {
            BoardCells[cellNo].IsFull = state;
            BoardCells[cellNo].CellValue = shipNumber;
        }
        private void randomFilling(){
            var randomField = new Random();
            for(var i=0; i<30;i++){
            BoardCells[randomField.Next(1,100)].IsFull=true;
            }
        }
        public void DrawBoard()
        {
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            for (var i = 0; i < BoardSize; i++)
            {
                for (var j = 0; j < BoardSize; j++)
                {
                    var id = (i*10)+j;
                    //Console.Write($"{_boardCells[((i-1)*10)+j].Id} ");

                    if (BoardCells[id].IsFull)
                    {
                        Console.ForegroundColor = colors[4];
                        Console.Write(BoardCells[id].CellValue);
                    }
                    else
                    {
                        Console.ForegroundColor = colors[3];
                        //Console.Write(BoardCells[id].Id);
                        Console.Write("*");
                    }
                }
                Console.ForegroundColor = colors[15];
                Console.WriteLine();
            }/*
            Console.WriteLine();
            for (var i = 0; i < BoardSize; i++)
            {
                for (var j = 0; j < BoardSize; j++)
                {
                    var id = (i*10)+j;
                    if (BoardCells[id].IsFull)
                    {
                        Console.ForegroundColor = colors[4];
                        Console.Write("Truee ");
                    }
                    else
                    {
                        Console.ForegroundColor = colors[3];
                        Console.Write($"False ");
                    }
                }
                Console.ForegroundColor = colors[15];
                Console.WriteLine();
            }*/
            Console.WriteLine();
            /*
            for (var i = 0; i < BoardSize; i++)
            {
                Console.Write($"  {_columnName[i]} ");
            }
            Console.WriteLine();
            Console.Write("+");
            for (int i = 0; i < BoardSize; i++)
            {
                Console.Write("---+");
            }

            */
            /*
                  A   B
                +---+---+
               1| M | H |
                +---+---+
            */
        }
    }
}

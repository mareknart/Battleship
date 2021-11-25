using System;

namespace Battleship
{
    public class BoardGui : IBoardGui
    {
        //private string _columnName = "ABCDEFGHIJ";
        private ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
        private readonly IBoardInitialise _board1;
        private readonly IBoardInitialise _board2;
        private string[,] boardData;
        private const int _columns = 42;
        private const int _rows = 22;
        private int indexOfColumn;
        private int indexOfRow;
        private int board1cell;
        private int board2cell;
        public BoardGui(IBoardInitialise board1, IBoardInitialise board2)
        {
            _board1 = board1;
            _board2 = board2;
            BoardGuiInitialise();
        }
        private int DrawRow(int i, int startingPoint, int indexOfRow, int indexOfColumn, int boardCell, IBoardInitialise board)
        {
            for (var j = startingPoint; j < _columns + startingPoint; j++)
            {
                if (i == indexOfRow && j == indexOfColumn)
                {
                    if (board.BoardCells[boardCell].CellValue > 0)
                    {
                        if (!board.BoardCells[boardCell].IsFull && board.BoardCells[boardCell].IsHitted)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("*");
                        }
                        if (board.BoardCells[boardCell].IsFull && board.BoardCells[boardCell].IsHitted)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("X");
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = colors[board.BoardCells[boardCell].CellValue];
                            if (board.BoardCells[boardCell].CellValue > 1)
                            {
                                Console.Write(board.BoardCells[boardCell].CellValue);
                            }
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                    }
                    boardCell++;
                    indexOfColumn += 4;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(boardData[i, j - startingPoint]);
                }
            }
            return boardCell;
        }
        private void BoardGuiInitialise()
        {
            boardData = new string[_rows, _columns]{
                {"  "," "," ","A"," "," "," ","B"," "," "," ","C"," "," "," ","D"," "," "," ","E"," "," "," ","F"," "," "," ","G"," "," "," ","H"," "," "," ","I"," "," "," ","J"," "," "},
                {"  ","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+"},
                {" 1","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"},
                {"  ","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+"},
                {" 2","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"},
                {"  ","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+"},
                {" 3","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"},
                {"  ","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+"},
                {" 4","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"},
                {"  ","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+"},
                {" 5","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"},
                {"  ","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+"},
                {" 6","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"},
                {"  ","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+"},
                {" 7","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"},
                {"  ","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+"},
                {" 8","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"},
                {"  ","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+"},
                {" 9","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"},
                {"  ","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+"},
                {"10","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"," "," "," ","|"},
                {"  ","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+","-","-","-","+"}
            };
        }
        public void DrawBoard()
        {
            indexOfColumn = 3;
            indexOfRow = 2;
            board1cell = 0;
            board2cell = 0;
            Console.BackgroundColor = ConsoleColor.Black;
            for (var i = 0; i < _rows; i++)
            {
                Console.Write("     ");
                board1cell = DrawRow(i, 0, indexOfRow, indexOfColumn, board1cell, _board1);
                Console.Write("     ");
                board2cell = DrawRow(i, 0, indexOfRow, indexOfColumn, board2cell, _board2);
                if (i == indexOfRow)
                {
                    indexOfColumn = 3;
                    indexOfRow += 2;
                }
                Console.WriteLine();
            }
        }
    }
}

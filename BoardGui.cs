using System;

namespace Battleship
{
    public class BoardGui : IBoardGui
    {
        private string _columnName = "ABCDEFGHIJ";
        
        private readonly IBoardInitialise _board;

        private int [,] boardData = new int[37,21];
        public BoardGui(IBoardInitialise board)
        {
            /*
                  A   B
                +---+---+
               1| M | H |
                +---+---+
            */
            _board = board;
        }
        private void boardGuiInitialise(){
            
        }
        public void DrawBoard()
        {
            
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            for (var i = 0; i < _board.BoardSize; i++)
            {
                for (var j = 0; j < _board.BoardSize; j++)
                {
                    var id = (i * 10) + j;

                    if (_board.BoardCells[id].IsFull)
                    {
                        Console.ForegroundColor = colors[4];
                        Console.Write(_board.BoardCells[id].CellValue);
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
        }
    }
}

namespace Battleship
{
    public interface IBoardInitialise
    {
        int BoardSize { get; set; }
        Cell [] BoardCells { get; set; }
        void InitialiseBoard();
        void UpdateBoard(int CellNo, bool full, int shipNumber);
        void DrawBoard();
    }
}
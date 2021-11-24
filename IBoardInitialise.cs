namespace Battleship
{
    public interface IBoardInitialise
    {
        int BoardSize { get; set; }
        Cell [] BoardCells { get; set; }
        void InitialiseBoard();
        void UpdateBoard(int cellNo, bool isFull, bool isHit, int shipNumber=0);
    }
}
namespace Battleship
{
    public class Cell
    {
        //isHitted=0 & isEmpty=0 => isHit=1 in cell display M
        //isHitted=0 & isEmpty=1 => isHit=1 in cell display H
        public int Id { get; set; }
        public int ColumnPosition{get; set;}
        public int RowPosition{get; set;}
        public bool IsHitted { get; set; }
        public bool IsFull { get; set; }
        public int CellValue { get; set; }
        
    }
}

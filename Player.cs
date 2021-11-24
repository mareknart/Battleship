namespace Battleship
{
    public class Player
    {
        public int Id {get; set;}
        public string Name { get; set; }
        public IBoardInitialise board { get; set; }
        public bool isActive { get; set; }
        private int[] _fleet;
        public Player(int[] fleet){
            _fleet = fleet;
        }

private 
        
    }
}
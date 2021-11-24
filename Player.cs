namespace Battleship
{
    public class Player
    {
        public int Id {get; set;}
        public string Name { get; set; }
        public IBoardInitialise board { get; set; }
        public bool isActive { get; set; }
        private int[] _fleetTable;
        public Ship[] ships {get; set;}
        public Player(int[] fleet){
            _fleetTable = fleet;
        }

        public void CreateShips(){
            ships = new Ship[_fleetTable.Length];
            for (var i=0; i<_fleetTable.Length;i++){
                ships[i] = new Ship(_fleetTable[i], board);
            }
        } 
        
    }
}
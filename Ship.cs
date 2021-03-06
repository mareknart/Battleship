using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship
{
    public class Ship
    {
        public int Id { get; set; }
        public List<int> Lifes {get; set;}
        private int _columnStartingPosition;
        private int _rowStartingPosition;
        private List<int> _directions;
        private int _shipSize;
        private int _startingCell;
        private int rowLength = 10;
        private readonly IBoardInitialise _board;
        public Ship(int shipSize, IBoardInitialise board)
        {
            _shipSize = shipSize;
            this._board = board;
        }

        private int RandomStartingCell()
        {
            var randomNumber = new Random();
            _startingCell = randomNumber.Next(0, 99);
            _rowStartingPosition = _startingCell / rowLength;
            _columnStartingPosition = _startingCell - (_rowStartingPosition * rowLength);
            return _startingCell;
        }

        private void GettingStartingPosition()
        {
            bool cellsChecker = false;
            do
            {
                cellsChecker = CheckCellsAround(RandomStartingCell());
            } while (_board.BoardCells[_startingCell].IsFull || cellsChecker);
        }

        private bool CheckCellsAround(int cellId)
        {
            List<bool> neigboursCells = new List<bool>();
            //upper cell
            if (_rowStartingPosition - 1 >= 0)
            {
                if (cellId > 9)
                {
                    neigboursCells.Add(_board.BoardCells[cellId - 10].IsFull);
                }
            }
            //bottom cell
            if (_rowStartingPosition + 1 <= 9)
            {
                if (cellId < 90)
                {
                    neigboursCells.Add(_board.BoardCells[cellId + 10].IsFull);
                }
            }
            //right cell
            if (_columnStartingPosition + 1 <= 9)
            {
                if (cellId % 10 != 9)
                {
                    neigboursCells.Add(_board.BoardCells[cellId + 1].IsFull);
                }
            }
            //left cell
            if (_columnStartingPosition - 1 <= 0)
            {
                if (cellId % 10 != 0)
                {
                    neigboursCells.Add(_board.BoardCells[cellId - 1].IsFull);
                }
            }
            if (neigboursCells.Contains(true))
            {
                return true;
            }
            else { return false; }
        }

        private void FindDirections()
        {
            _directions = new List<int>();
            //directions 0->up, 3->left, 6->down, 9->right
            if (_rowStartingPosition >= _shipSize - 1)
            {
                _directions.Add(0);
            }
            if (_columnStartingPosition + (_shipSize - 1) <= _board.BoardSize - 1)
            {
                _directions.Add(3);
            }
            if (_rowStartingPosition + (_shipSize - 1) <= _board.BoardSize - 1)
            {
                _directions.Add(6);
            }
            if (_columnStartingPosition >= _shipSize - 1)
            {
                _directions.Add(9);
            }
        }

        private int[,] FindPositions()
        {
            int[,] positions = new int[_directions.Count, _shipSize];
            int id = 0;
            for (var i = 0; i < _directions.Count; i++)
            {
                for (var j = 0; j < _shipSize; j++)
                {
                    switch (_directions[i])
                    {
                        case 0:
                            id = _startingCell - (j * rowLength);
                            positions[i, j] = id;
                            break;
                        case 3:
                            id = _startingCell + j;
                            positions[i, j] = id;
                            break;
                        case 6:
                            id = _startingCell + (j * rowLength);
                            positions[i, j] = id;
                            break;
                        case 9:
                            id = _startingCell - j;
                            positions[i, j] = id;
                            break;
                    }
                }
            }
            return positions;
        }

        private List<int> FindEmptyPositions(int[,] positions)
        {
            List<int> allAvailablePositions = new List<int>();
            var numberOfDirections = positions.Length / _shipSize;
            for (var i = 0; i < numberOfDirections; i++)
            {
                List<int> tempPositions = new List<int>();
                for (var j = 0; j < _shipSize; j++)
                {
                    if (!_board.BoardCells[positions[i, j]].IsFull)
                    {
                        tempPositions.Add(positions[i, j]);
                    }
                }
                if (tempPositions.Count == _shipSize)
                {
                    allAvailablePositions.AddRange(tempPositions);
                }
            }
            return allAvailablePositions;
        }

        private List<int> FindFinalPosition(List<int> allAvailablePositions)
        {
            int numberOfPossibilities = allAvailablePositions.Count / _shipSize;
            int positionIndexSet = 0;
            List<int> finalPositions = new List<int>();
            if (numberOfPossibilities > 1)
            {
                var randItem = new Random();
                positionIndexSet = randItem.Next(0, numberOfPossibilities - 1);
            }
            if (numberOfPossibilities > 0)
            {
                for (var i = 0; i < _shipSize; i++)
                {
                    finalPositions.Add(allAvailablePositions[(_shipSize * positionIndexSet) + i]);
                }
            }
            return finalPositions;
        }

        public List<int> PositionShip()
        {
            List<int> emptyPositions = new List<int>();
            List<int> cells = new List<int>();
            for (var i = 0; i < 100; i++)
            {
                cells.Add(i);
            }

            while (!emptyPositions.Any() || cells.Count < 1)
            {
                GettingStartingPosition();
                FindDirections();
                emptyPositions = FindFinalPosition((FindEmptyPositions(FindPositions())));
                cells.Remove(_startingCell);
            }
            return emptyPositions;
        }

    }
}
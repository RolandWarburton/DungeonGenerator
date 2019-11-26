using System;
using System.Collections.Generic;
using System.Text;

namespace MapGenerator
{
    public class Game
    {
        private int _width;
        private int _height;
        // all the cells in the game
        private Cell[,] _cells;
        // the set of cells to draw
        private List<Cell> _graphicCells;
        // registry of rooms
        private List<Room> _rooms;

        public Game(int width, int height)
        {
            _width = width;
            _height = height;
            _cells = new Cell[width, height];
            _graphicCells = new List<Cell>();
            _rooms = new List<Room>();
            GenerateRoom();
        }

        public bool CheckLeftWall(int col)
        {
            if (col == 0)
                return true;
            else
                return false;
        }
        public bool CheckRightWall(int col)
        {
            if (col == _width - 1)
                return true;
            else
                return false;
        }
        public bool CheckTopWall(int row)
        {
            if (row == 0)
                return true;
            else
                return false;
        }
        public bool CheckBottomWall(int row)
        {
            if (row == _height - 1)
                return true;
            else
                return false;
        }
        public bool CheckCorner(int col, int row)
        {
            if ((CheckLeftWall(col) || CheckRightWall(col)) && (CheckTopWall(row) || CheckBottomWall(row)))
                return true;
            else
                return false;
        }
        public bool CheckWall(int col, int row)
        {
            if (CheckLeftWall(col) || CheckRightWall(col) || CheckBottomWall(row) || CheckTopWall(row))
                return true;
            else
                return false;
        }

        /// <summary>
        /// populate the game with empty cells
        /// </summary>
        private void GenerateRoom()
        {
            for (int row = 0; row < _height; row++)
            {
                for (int col = 0; col < _width; col++)
                {
                    _cells[col, row] = new Cell(col, row, col, row, '\0');
                }
            }
        }

        /// <summary>
        /// draw each graphics cell
        /// </summary>
        public void Draw()
        {
            foreach (Cell c in _graphicCells)
            {
                c.Draw();
            }
        }

        /// <summary>
        /// return true if the target cell overlaps a target room
        /// </summary>
        public bool DoOverlap(Cell targetcell, Room targetRoom)
        {
            if (targetcell.X < targetRoom.BottomRight.X)
            {
                if(targetcell.X > targetRoom.TopLeft.X)
                {
                    if(targetcell.Y > targetRoom.TopLeft.Y)
                    {
                        if (targetcell.Y < targetRoom.BottomRight.Y)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// return a list of interceptions between a list of candidate cells and the graphics cells
        /// </summary>
        /// <param name="candidateCells">list of cells to check against the graphics cells list</param>
        public List<Cell> CheckInterceptions(List<Cell> candidateCells)
        {
            List<Cell> interceptions = new List<Cell>();

            foreach (Cell c in _graphicCells)
            {
                foreach (Room room in _rooms)
                {
                    if (DoOverlap(c, room))
                    {
                        interceptions.Add(c);
                    }
                }
            }
            return interceptions;
        }

        /// <summary>
        /// returns this cells neighbours
        /// </summary>
        public List<Cell> Neighbours(Cell candidateCell)
        {
            //rename the candidacecell to make the following query easier
            Cell c = candidateCell;
            List<Cell> neighbours = _graphicCells.FindAll(cell => cell.X == c.X);
            return neighbours;
        }

        /// <summary>
        /// registers a room and adds appropriate cells to the graphics cells list
        /// </summary>
        /// <param name="x">cartesian x (across)</param>
        /// <param name="y">cartesian y (down)</param>
        public void AddRoom(int x, int y, int w, int h, char wallvalue)
        {
            List<Cell> candidateCells = new List<Cell>();
            for (int row = 0; row < h; row++)
            {
                for (int col = 0; col < w; col++)
                {
                    if ((row == 0 || col == 0 || row == h - 1 || col == w - 1) && _cells[col + x, row + y].Value != wallvalue)
                    {
                        _cells[col + x, row + y].Value = wallvalue;
                        _graphicCells.Add(_cells[col + x, row + y]);
                    }
                    candidateCells.Add(_cells[col + x, row + y]);
                }
            }
            // create a new room and register it to the list of rooms
            Room candidateRoom = new Room(candidateCells[0], candidateCells[candidateCells.Count - 1]);
            _rooms.Add(candidateRoom);

            //remove all the garbage cells between the intercepting rooms
            foreach (Cell c in CheckInterceptions(candidateCells))
            {
                c.Value = '\0';
            }

        }
    }
}

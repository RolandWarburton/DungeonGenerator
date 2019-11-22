using System;
using System.Collections.Generic;
using System.Text;
using static System.ConsoleColor;
using System.IO;
using System.Linq;

namespace MapGenerator
{
    public class Room
    {
        private readonly int _width;
        private readonly int _height;
        private readonly int _x;
        private readonly int _y;
        private List<Cell> _cells;
        private int _index;
        private char _wallChar;

        public Room(int x, int y, int width, int height, char wallchar, int index)
        {
            _width = width;
            _height = height;
            _x = x;
            _y = y;
            _cells = new List<Cell>();
            _index = index;
            _wallChar = wallchar;
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



        private void GenerateRoom()
        {
            for (int row = 0; row < _height; row++)
            {
                for (int col = 0; col < _width; col++)
                {
                    // if its a corner draw a corner. otherwise check to see if a wall can go here
                    if (CheckCorner(col, row))
                    {
                        _cells.Add(new Cell(col + _y, row + _x, '+'));
                    }
                    else
                    {
                        if (CheckLeftWall(col))
                            _cells.Add(new Cell(col+_y, row + _x, _wallChar));

                        if (CheckRightWall(col))
                            _cells.Add(new Cell(col + _y, row + _x, _wallChar));

                        if (CheckTopWall(row))
                            _cells.Add(new Cell(col + _y, row + _x, _wallChar));

                        if (CheckBottomWall(row))
                            _cells.Add(new Cell(col + _y, row + _x, _wallChar));
                    }
                }
            }
        }

        // compare a room to another room and cut out the differences
        public void Collision(Room newRoom)
        {
            // controls cutting the new shape out
            foreach(Cell r in newRoom.Cells)
            {
                // replace the gaps left in the og wall
                if (this.Cells.Any(c => c.X == r.X && c.Y == r.Y))
                {
                    r.Value = '+';
                    continue;
                }

                // cut out walls on the og shape side
                if (this.Cells.Any(c => c.X == r.X))
                {
                    if (this.Cells.Any(c => c.Y == r.Y))
                    {
                        r.Value = '\0';
                    }
                }
            }

            //controls cutting the og shape
            foreach (Cell r in this.Cells)
            {
                // cut out walls on the og shape side
                if (newRoom.Cells.Any(c => c.X == r.X))
                {
                    if (newRoom.Cells.Any(c => c.Y == r.Y))
                    {
                        r.Value = '\0';
                    }
                }
            }
        }
        
        public void DrawOutline()
        {
            foreach(Cell cell in _cells)
            {
                cell.Draw();
            }
        }

        public int Width { get => _width; }
        public int Height { get => _height; }
        public int X { get => _x; }
        public int Y { get => _y; }
        public List<Cell> Cells { get => _cells; }
        public char WallChar { get => _wallChar; }
    }

    
}

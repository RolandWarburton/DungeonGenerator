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
        private int _width;
        private int _height;
        private int _x;
        private int _y;
        //private List<Cell> _cells;
        private Cell[,] _cells;
        private int _index;
        private char _wallChar;
        private char _roomChar;

        public Room(int x, int y, int width, int height, char wallchar, char roomchar, int index)
        {
            _width = width;
            _height = height;
            _x = x;
            _y = y;
            //_cells = new List<Cell>();
            _cells = new Cell[width, height];
            _index = index;
            _wallChar = wallchar;
            _roomChar = roomchar;
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
                    _cells[col, row] = new Cell(col + _y, row + _x, col, row, '\0');
                    if (CheckTopWall(row)) _cells[col, row].Value = this.WallChar;
                    if (CheckBottomWall(row)) _cells[col, row].Value = this.WallChar;
                    if (CheckLeftWall(col)) _cells[col, row].Value = this.WallChar;
                    if (CheckRightWall(col)) _cells[col, row].Value = this.WallChar;
                    if (CheckCorner(col, row)) _cells[col, row].Value = '+';
                }
            }
        }

        // compare this room to another room and cut out the differences
        //public void Collision(Room newRoom)
        //{
        //    // for each row
        //    for (int row = 0; row < newRoom.Height; row++)
        //    {
        //        // for each col
        //        for (int col = 0; col < newRoom.Width; col++)
        //        {
        //            if(CheckWall(col, row))
        //            {
        //                // compare this room with another room
        //                if (newRoom._cells[col, row].X > this._cells[0, 0].X)
        //                {
        //                    if (newRoom._cells[col, row].X < this._cells[_width - 1, 0].X)
        //                    {
        //                        if (newRoom._cells[col, row].Y > this._cells[0, 0].Y)
        //                        {
        //                            if (newRoom._cells[col, row].Y < this._cells[_width - 1, _height - 1].Y)
        //                            {
        //                                newRoom._cells[col, row].Value = '\0';
        //                                if(newRoom._cells[col+1, row].Value != '\0' && newRoom._cells[col, row - 1].Value != '\0')
        //                                {
        //                                    // its a corner
        //                                    //|-|#|-|
        //                                    //|-|+|#|
        //                                    //|-|-|-|
        //                                    newRoom._cells[col, row].Value = '+';
        //                                }

        //                                if (newRoom._cells[col - 1, row].Value != '\0' && newRoom._cells[col, row + 1].Value != '\0')
        //                                {
        //                                    // its a corner
        //                                    //|-|-|-|
        //                                    //|#|+|-|
        //                                    //|-|#|-|
        //                                    newRoom._cells[col, row].Value = '+';
        //                                }
        //                                //if (newRoom._cells[col, row].X == this._cells[col-1, row-1].X && newRoom._cells[col, row].Y == this._cells[col-3, row-3].Y)
        //                                //{
        //                                //    newRoom._cells[col, row].Value = '+';
        //                                //}
        //                            }
        //                        }
        //                    }
        //                }
        //            }
                    
        //        }
        //    }
        //}

        public bool CornerV2(Room newRoom, int col, int row)
        {
            int nw, nh;
            //aw = this.Cells.GetLength(0);
            //ah = this.Cells.GetLength(1);
            nw = newRoom.Cells.GetLength(0);
            nh = newRoom.Cells.GetLength(1);
            if ((col + 1 < nw && col - 1 >= 0))
            {
                if (row + 1 < nh && row - 1 >= 0)
                {
                    char localAbove = this._cells[col, row - 1].Value;
                    char newAbove = newRoom._cells[col, row - 1].Value;
                    char localLeft = this._cells[col + 1, row].Value;
                    char newLeft = newRoom._cells[col + 1, row].Value;
                    if ((localAbove != '#' || newAbove != '#') && (localLeft != '#' || newLeft != '#'))
                    {
                        // its a corner
                        //|-|#|-|
                        //|-|+|#|
                        //|-|-|-|
                        //newRoom._cells[col, row].Value = '+';
                        return true;
                    }

                    //if (newRoom._cells[col - 1, row].Value != '\0' && newRoom._cells[col, row + 1].Value != '\0')
                    //{
                    //    // its a corner
                    //    //|-|-|-|
                    //    //|#|+|-|
                    //    //|-|#|-|
                    //    //newRoom._cells[col, row].Value = '+';
                    //    return true;
                    //}
                }
            }
            return false;
        }

        public List<Cell> CheckIntersect(Room newRoom)
        {
            List<Cell> intersections = new List<Cell>();
            // for each row
            for (int row = 0; row < newRoom.Height; row++)
            {
                // for each col
                for (int col = 0; col < newRoom.Width; col++)
                {
                    if (CornerV2(newRoom, col, row))
                    {
                        newRoom._cells[col, row].Value = '*';
                    }

                    // compare this room with another room
                    if (newRoom._cells[col, row].X >= this._cells[0, 0].X)
                        {
                            if (newRoom._cells[col, row].X <= this._cells[_width - 1, 0].X)
                            {
                                if (newRoom._cells[col, row].Y >= this._cells[0, 0].Y)
                                {
                                    if (newRoom._cells[col, row].Y <= this._cells[_width - 1, _height - 1].Y)
                                    {
                                        if (newRoom._cells[col, row].Value != '\0')
                                        {
                                            intersections.Add(newRoom._cells[col, row]);
                                            continue;
                                        }
                                    }
                                }
                            }
                        }
                    }  
                }
            return intersections;
        }

        public void DrawOutline()
        {
            foreach(Cell cell in _cells)
            {
                cell.Draw();
            }
        }

        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }
        public int AbsX { get => _x; set => _x = value; }
        public int AbsY { get => _y; set => _y = value; }
        public Cell[,] Cells { get => _cells; set => _cells = value; }
        public char WallChar { get => _wallChar; }
        public char RoomChar { get => _roomChar; }
    }

    
}

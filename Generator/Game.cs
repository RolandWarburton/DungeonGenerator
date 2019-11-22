using System;
using System.Collections.Generic;
using System.Text;

namespace MapGenerator
{
    public class Game
    {
        private readonly List<Room> _rooms;
        public Game(int width, int height)
        {
            _rooms = new List<Room>();
        }

        public void DrawRooms()
        {
            foreach(Room r in _rooms)
            {
                r.DrawOutline();
                //Console.Clear();
            }
        }

        public void DrawRoom(Room r)
        {
            r.DrawOutline();
        }

        public void AddRoom(Room newRoom)
        {
            foreach(Room r in _rooms)
            {
                List<Cell> intersections; 

                intersections = r.CheckIntersect(newRoom);
                foreach(Cell c in intersections)
                {
                    newRoom.Cells[c.RelX, c.RelY].Value = '\0';
                }

                intersections = newRoom.CheckIntersect(r);
                foreach (Cell c in intersections)
                {
                    r.Cells[c.RelX, c.RelY].Value = '\0';
                }
            }
            _rooms.Add(newRoom);
        }

        // debugger
        public void WriteCells(Cell[,] a)
        {
            //Cell[,] cells = a.Cells;
            for (int row = 0; row < a.GetLength(0); row++)
            {
                // for each col
                for (int col = 0; col < a.GetLength(1); col++)
                {
                    a[row, col].Draw();
                }
            }
        }

        public List<Room> Rooms { get => _rooms; }
    }
}

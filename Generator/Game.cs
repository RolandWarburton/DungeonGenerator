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

        public void CheckBorders()
        {
            //foreach (Room r in _rooms)
            //{
            //    r.DrawOutline();
            //    Console.Clear();
            //}
        }

        public void AddRoom(Room newRoom)
        {
            foreach(Room r in _rooms)
            {
                r.Collision(newRoom);
            }
            _rooms.Add(newRoom);
        }

        public List<Room> Rooms
        {
            get { return _rooms; }
        }


    }
}

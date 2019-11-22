using System;

namespace MapGenerator
{
    public class Program
    {
        static void Main()
        {
            Game _game = new Game(50, 50);
            //_game.AddRoom(new Room(0, 0, 20, 10, 1));
            //_game.AddRoom(new Room(5, 8, 20, 10, 2));

            //_game.AddRoom(new Room(15, 80, 20, 10, 2));
            _game.AddRoom(new Room(0, 0, 10, 5, '#', '*', 3));
            _game.AddRoom(new Room(3, 3, 10, 5, '#', '*', 3));
            //_game.AddRoom(new Room(1, 6, 10, 5, 'c', '*', 3));
            //_game.AddRoom(new Room(8, 6, 12, 5, '#', 3));
            //_game.DrawRooms();
            _game.DrawRoom(_game.Rooms[0]);
            _game.DrawRoom(_game.Rooms[1]);
            while (true)
            {
                //_game.Draw();
            }

        }
    }
}

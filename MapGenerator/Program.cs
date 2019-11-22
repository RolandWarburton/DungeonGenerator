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
            _game.AddRoom(new Room(10, 60, 22, 7, '#', 3));
            _game.AddRoom(new Room(13, 53, 11, 7, '#', 4));
            _game.AddRoom(new Room(13, 67, 11, 7, '#', 4));
            _game.AddRoom(new Room(13, 15, 12, 6, '#', 4));
            _game.DrawRooms();
            while (true)
            {
                //_game.Draw();
            }

        }
    }
}

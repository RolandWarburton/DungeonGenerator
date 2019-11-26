using System;

namespace MapGenerator
{
    public class Program
    {
        static void Main()
        {
            Game _game = new Game(Console.WindowWidth, Console.WindowHeight);
            _game.AddRoom(1, 1, 10, 5, '#');
            _game.AddRoom(3, 3, 10, 5, '#');
            _game.AddRoom(30, 5, 10, 5, '#');
            _game.AddRoom(20, 3, 20, 5, '#');

            _game.Draw();
            while (true)
            {
                //_game.Draw();
            }

        }
    }
}

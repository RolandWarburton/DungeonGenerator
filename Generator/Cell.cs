using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MapGenerator
{
    public class Cell
    {
        private int _y;
        private int _x;
        private char _value;

        public Cell(int x, int y, char value)
        {
            _x = x;
            _y = y;
            _value = value;
        }

        public void Draw()
        {
            try
            {
                Console.SetCursorPosition(_x, _y);
                Console.Write(_value);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public char Value { get => _value; set => _value = value; }
    }
}

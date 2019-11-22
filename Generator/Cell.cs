using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MapGenerator
{
    public class Cell
    {
        private int _absx, _absy;
        private int _relx, _rely;
        private char _value;

        public Cell (int absx, int absy, int relx, int rely, char value)
        {
            // absolute position of cell
            _absx = absx;
            _absy = absy;
            _relx = relx;
            _rely = rely;
            _value = value;
        }

        public void Draw()
        {
            try
            {
                // put the cursor into the position of the cell
                Console.SetCursorPosition(_absx, _absy);
                Console.Write(_value);
                Console.SetCursorPosition(0, 0);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        public int X { get => _absx; set => _absx = value; }
        public int Y { get => _absy; set => _absy = value; }
        public int RelX { get => _relx; set => _relx = value; }
        public int RelY { get => _rely; set => _rely = value; }
        public char Value { get => _value; set => _value = value; }
    }
}

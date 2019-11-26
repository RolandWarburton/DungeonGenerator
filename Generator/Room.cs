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
        private List<Cell> _graphicCells;
        private Cell _topLeft;
        private Cell _bottomRight;
        public Room(Cell topleft, Cell bottomright)
        {
            _topLeft = topleft;
            _bottomRight = bottomright;
            _graphicCells = new List<Cell>();
    }
        public Cell TopLeft { get => _topLeft; }
        public Cell BottomRight { get => _bottomRight; }
        public List<Cell> Cells { get => _graphicCells;  set => _graphicCells = value; }
    }


}


//using System;
//using System.Collections.Generic;
//using System.Text;
//using static System.ConsoleColor;
//using System.IO;
//using System.Linq;

//namespace MapGenerator
//{
//    public class Room
//    {
//        private int[] _p1;
//        private int[] _p2;

//        public Room(int[] p1, int[] p2)
//        {
//            _p1 = p1;
//            _p2 = p2;
//        }
//        public int[] P1 { get => _p1; }
//        public int[] P2 { get => _p2; }
//    }


//}

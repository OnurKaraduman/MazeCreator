using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MazeExample1.model
{
    class BoardSquare
    {
        #region members
        double column;
        double row;
        double size;
        bool isFull = false;
        #endregion

        #region constructor
        public BoardSquare(Point point, double size)
        {
            Row = point.Y;
            Column = point.X;
            Size = size;

        }
        public BoardSquare()
        {

        }
        #endregion

        #region properties
        public double Column
        {
            get
            {
                return column;
            }
            set
            {
                column = value;
            }
        }
        public double Row
        {
            get
            {
                return row;
            }
            set
            {
                row = value;
            }
        }
        public double Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }
        public bool IsFull
        {
            get
            {
                return isFull;
            }
            set
            {
                isFull = value;
            }
        }
        #endregion

        #region methods

        #endregion
    }
}

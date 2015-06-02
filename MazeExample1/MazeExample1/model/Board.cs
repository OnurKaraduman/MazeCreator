using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MazeExample1.model
{
    /// <summary>
    /// <author>Onur Karaduman</author>
    /// <email>onrkrdmn at gmail dot com</email>
    /// <date>02.06.2015</date>
    /// </summary>
    class Board
    {
        #region members
        Canvas _canvas1;
        BoardSquare[,] squares;
        int LINE_PADDING = 50;
        Random random;
        #endregion

        #region constructor
        public Board(Canvas canvas)
        {
            Canvas1 = canvas;
            random = new Random();
        }
        #endregion

        #region properties
        public Canvas Canvas1
        {
            get
            {
                return _canvas1;
            }
            set
            {
                _canvas1 = value;
            }
        }
        #endregion

        #region methods
        /// <summary>
        /// createGrid to create mazeScene for finding way randomly.
        /// </summary>
        public void createGrid()
        {
            double width = Canvas1.Width;
            double height = Canvas1.Height;
            Point canvasPoint = new Point(0, 0);
            int totalColumnLine = (int)width / LINE_PADDING;
            int totalRowLine = (int)height / LINE_PADDING;
            squares = new BoardSquare[totalRowLine, totalColumnLine];

            //#region drawing RowLine
            //for (int i = 0; i < totalRowLine; i++)
            //{
            //    Line line = new Line();
            //    line.Stroke = SystemColors.WindowFrameBrush;
            //    //line.Stroke = new SolidColorBrush(Colors.Black);
            //    line.X1 = canvasPoint.X;
            //    line.Y1 = canvasPoint.Y + LINE_PADDING * i;
            //    line.X2 = canvasPoint.X + width;
            //    line.Y2 = canvasPoint.Y + LINE_PADDING * i;
            //    Canvas1.Children.Add(line);
            //}
            //#endregion
            #region drawing ColumnLine
            for (int i = 0; i < totalColumnLine; i++)
            {
                //Line line = new Line();
                //line.Stroke = SystemColors.WindowFrameBrush;
                //line.X1 = canvasPoint.X + LINE_PADDING * i;
                //line.Y1 = canvasPoint.Y;
                //line.X2 = canvasPoint.X + LINE_PADDING * i;
                //line.Y2 = canvasPoint.Y + height;
                //Canvas1.Children.Add(line);
                double x1 = canvasPoint.X + LINE_PADDING * i;
                double y1 = canvasPoint.Y;
                #region store each square in array
                for (int j = 0; j < totalRowLine; j++)
                {
                    if (i == totalColumnLine - 1)
                        break;
                    Point pointOfSquare = new Point(x1, (y1 + LINE_PADDING * j));
                    BoardSquare bSquare = new BoardSquare(pointOfSquare, LINE_PADDING);
                    squares[j, i] = bSquare;
                }
                #endregion
            }
            #endregion

        }

        int lastRow = -1;
        int lastColumn = -1;
        /// <summary>
        /// 0=right; 1=left; 2=up; 3=down;
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void mazeCreater(int row, int column)
        {
            if (row < squares.GetLength(0) && column < squares.GetLength(1) && row > -1 && column > -1)
            {
                try
                {
                    if (!squares[row, column].IsFull)
                    {
                        if (lastRow != -1 && lastColumn != -1)
                        {
                            if (Math.Abs(lastColumn - column) == 1)
                            {
                                if (lastRow == row)
                                {
                                    drawLine(squares[lastRow, lastColumn], squares[row, column]);
                                    squares[row, column].IsFull = true;
                                }

                            }
                            else if (Math.Abs(lastRow - row) == 1)
                            {
                                if (lastColumn == column)
                                {
                                    drawLine(squares[lastRow, lastColumn], squares[row, column]);
                                    squares[row, column].IsFull = true;
                                }
                            }
                        }
                        else
                            squares[row, column].IsFull = true;
                        lastRow = row;
                        lastColumn = column;

                        int nextDecision = random.Next(0, 4);
                        switch (nextDecision)
                        {
                            case 0:
                                mazeCreater(row, column + 1);//right
                                mazeCreater(row, column - 1);//left
                                mazeCreater(row + 1, column);//down
                                mazeCreater(row - 1, column);//up

                                break;
                            case 1:
                                mazeCreater(row, column - 1);//left
                                mazeCreater(row + 1, column);//down
                                mazeCreater(row, column + 1);//right
                                mazeCreater(row - 1, column);//up
                                break;
                            case 2:
                                mazeCreater(row - 1, column);//up
                                mazeCreater(row + 1, column);//down
                                mazeCreater(row, column - 1);//left
                                mazeCreater(row, column + 1);//right
                                break;
                            case 3:
                                mazeCreater(row + 1, column);//down
                                mazeCreater(row, column + 1);//right
                                mazeCreater(row - 1, column);//up
                                mazeCreater(row, column - 1);//left
                                break;
                        }//endSwitch
                    }//endIf(!squares[row, column].IsFull)
                }
                catch (Exception e)
                {
                    Console.WriteLine("Errorrrr!" + e);
                }
            }//endIf(row < squares.GetLength(0) && column < squares.GetLength(1))
        }//endMethod

        public void drawLine(BoardSquare bSquare1, BoardSquare bSquare2)
        {
            Line line = new Line();
            line.Stroke = new SolidColorBrush(Colors.Blue);
            line.X1 = bSquare1.Column;
            line.Y1 = bSquare1.Row;
            line.X2 = bSquare2.Column;
            line.Y2 = bSquare2.Row;
            Canvas1.Children.Add(line);
            //Canvas1.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(
            //delegate()
            //{
            //    Canvas1.Children.Add(line);
            //}));
            //Canvas1.Children.Add(line);
        }
        #endregion


    }
}

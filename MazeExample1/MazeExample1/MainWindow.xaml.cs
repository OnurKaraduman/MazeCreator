using MazeExample1.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MazeExample1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Board board;
        internal static MainWindow mw;
        public MainWindow()
        {
            //this.WindowState = WindowState.Maximized;
            InitializeComponent();
            canvas1.Height = this.Height;
            canvas1.Width = this.Width;
            mw = this;


        }

        private void canvas1_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void canvas1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            canvas1.Children.Clear();
            board = new Board(canvas1);
            board.createGrid();

            board.mazeCreater(0, 0);


        }

    }
}

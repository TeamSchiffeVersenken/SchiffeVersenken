using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SchiffeVersenken
{
    public partial class GameWindow : Window
    {
        private int orientation, length;
        private bool ready;
        private List<Rectangle> water = new List<Rectangle>();

        private MainWindow win;
        private Spielfeld sf; 

        public GameWindow(MainWindow win, int waterwidth)
        {
            InitializeComponent();

            this.win = win;
            orientation = 0;
            length = 5;
            ready = false;

            addWater(waterwidth);
            sf = new Spielfeld(water, waterwidth);
        }

        public MainWindow getMainWindow()
        {
            return this.win;
        }

        private void selectShip(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(Battleship))
                length = 5;
            else if (sender.Equals(Cruiser))      /*Equals verwenden wir wenn wir auf Verweisgleicheit(garantiert keine Wertgleicheit) prüfen also wenn es 
                                                  mehrere Verweise auf ein Objekt gibt*/
                length = 3;
            else if (sender.Equals(Destroyer))
                length = 2;
            else if (sender.Equals(Submarine))
                length = 1;
        }

        private void selectOrientation(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(Horizontal))
            {
                orientation = 0;
            }
            else if(sender.Equals(Vertical))
            {
                orientation = 1;
            }

        }

        private void waterClicked(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            if(win.controller.istGestarted())
            {
                win.controller.fire(rect, sf);
            }
            else
            {
                sf.Schiffsplatzierung(rect, orientation, length);
            }
        }

        private void startGame(object sender, RoutedEventArgs e)
        {
            if(!ready&& sf.allShipsplaced())
            {
                ready = true;
                win.controler.spielstarted(sf);
                win.checkForStart();
            }
        }

        private void addWater(int width)
        {
            if (width < 10)
                width = 10;
            if (width > 26)
                width = 26;

            for (int i =0; i < width; i++)
            {
                for (int o =1; o<width+1; o++)
                {
                    Rectangle rect = new Rectangle();
                    rect.Name = MainWindow.getLetterFromInt(i) + "_" + o;
                    rect.Fill = Brushes.LightBlue;
                    rect.Width = 25;
                    rect.Height = 25;
                    rect.Stroke = Brushes.White;
                    rect.HorizontalAlignment = HorizontalAlignment.Left;
                    rect.VerticalAlignment = VerticalAlignment.Top;
                    rect.Margin = new Thickness((o - 1)*25, i*25,0,0);
                    rect.MouseLeftButtonDown += waterClicked;

                    water.Add(rect);
                    Water.Children.Add(rect);
                }
            }

            Ships.Margin = new Thickness(width * 25 + 25, 0, 0, 0);
            Orientation.Margin = new Thickness(width * 25 + 25, 100, 0, 0);

            this.Height = width * 25 + 25;
            this.Width = width * 25 + 200;
            ResizeMode = ResizeMode.NoResize;       //NoResize verhindert das minimieren und Maximieren des Fensters!!!
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SchiffeVersenken
{
    class Spielfeld
    {
        private List<Rectangle> wasser;
        private List<Schiff> ships;

        private int[] maxShips;
        private double offset;

        public Spielfeld(List<Rectangle> wasser, double offset)
        {
            this.offset = offset;
            this.wasser = wasser;
            maxShips = new int[] { 1, 2, 2, 3 };
            ships = new List<Schiff>();
        }
        public void feuer(Rectangle sender)
        {
            SolidColorBrush sb = sender.Fill as SolidColorBrush;
            for(int i=0; i<ships.Count;i++)
            {
                for (int o = 0; o < ships.ElementAt(i).getLength();) ;
            }
        }

        public void Schiffsplatzierung(Rectangle sender, int orientierung, int length)
        {

        }

        private bool allShipsplaced(int type)
        {
            int shipsOfType = 0;
            foreach (Schiff ship in ships)
            {
                if (ship.GetType().Equals(type))
                {
                    shipsOfType++;
                }
                if (shipsOfType >= maxShips[type])
                {
                    MessageBox.Show("Maximale Anzahl dieses Schifftypes wurde erreicht! ");
                    return true;
                }
            }
            return false;
        }

        public bool allShipsplaced()
        {
            if(ships.Count==getMaxShips())
            {
                foreach (Schiff ship in ships)
                {
                    foreach(Rectangle part in ship.getTeile())
                    {
                        part.Fill = Brushes.LightBlue;
                    }
                }
                return true;
            }
             return false;
        }
       

        public List<Schiff> getShips()
        {
            return this.ships;
        }

        public int getMaxShips()
        {
            return this.maxShips.Sum();
        }
    }
}

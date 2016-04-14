using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;

namespace SchiffeVersenken
{
    class Schiff
    {
        private List<Rectangle> teile;
        private List<Rectangle> trefferpunkte;

        public Schiff(List<Rectangle> teile)
        {
            this.teile=teile;
            trefferpunkte = new List<Rectangle>();
        }
        public void hit(Rectangle sender)
        {
            if (!trefferpunkte.Contains(sender))
            {
                sender.Fill = Brushes.Red;
                trefferpunkte.Add(sender);
                if (trefferpunkte.Count == teile.Count)
                {
                    string type = "";
                    switch (getType())
                    {
                        case 0:
                            type = "Schlachtschiff";
                            break;

                        case 1:
                            type = "Kreuzer";
                            break;

                        case 2:
                            type = "Zerstörer";
                            break;

                        case 3:
                            type = "U-Boot";
                            break;
                    }
                    MessageBox.Show("Ein " + type + " wurde versenkt!");
                }
               }
            }
    }

        private int getType()
        {
            int length = teile.Count;
            switch(length)
            {
                case 5:
                    return 0;
                case 3:
                    return 1;
                case 2:
                    return 2;
                case 1:
                    return 3;

                default:
                    return 4;
            }
        }
        public List<Rectangle> getTrefferpunkte()
        {
            return this.trefferpunkte;
        }
        public List<Rectangle> getTeile()
        {
            return this.teile;
        }
    }


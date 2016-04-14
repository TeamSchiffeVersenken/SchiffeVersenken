using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;

namespace SchiffeVersenken
{
    class Schiff
    {
        private List<Rectangle> teile;
        private List<Rectangle> trefferpunkte=new List<Rectangle>();

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
                    switch(getType())
                }
            }
        }

        private void getType()
        {
            int length = teile.Count;

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
}

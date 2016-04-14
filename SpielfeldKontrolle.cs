using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SchiffeVersenken
{
    class SpielfeldKontrolle
    {
        private bool[] spielerBereit;
        private bool spiellaeuft;
        private Spielfeld sf1, sf2;
        private bool zugSpieler1;

        public SpielfeldKontrolle(Spielfeld sf1, Spielfeld sf2)
        {
            this.sf1 = sf2;
            this.sf2 = sf2;
            spielerBereit = new bool[] { false, false };
            spiellaeuft = false;
            zugSpieler1 = true;
        }
        private void wechsleSpieler()
        {
            zugSpieler1 = !zugSpieler1;
        }
        public void Fire(Rectangle sender, Spielfeld sf)
        {
            SolidColorBrush sb = sender.Fill as SolidColorBrush;
            if (zugSpieler1 && sf.Equals(sf1) && sb.Equals(Colors.LightBlue))
                sf1.Fire(sender);
            else if (!zugSpieler1 && sf.Equals(sf2) && sb.Equals(Colors.LightBlue))
                sf2.Fire(sender);
        }
        public bool Spieler1()
        {
            return this.zugSpieler1;
        }
        public void setGestartet(Spielfeld sf)
        {

        }
        public bool checkTreffer(Spielfeld sf)
        {
            return false;
        }
        public bool istGestartet()
        {
            return this.spiellaeuft;
        }
        public bool[] getBereiteSpieler()
        {
            return this.spielerBereit;
        }
    }
}

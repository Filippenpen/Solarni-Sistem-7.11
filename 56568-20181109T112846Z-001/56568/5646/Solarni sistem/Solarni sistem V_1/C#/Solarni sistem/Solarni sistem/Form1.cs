using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //sunce
        double sun_x = 0;
        double sun_y = 0;
        double sun_r = 3;

        //merkur
        double mer_x = 0;
        double mer_y = 0;
        double mer_r = 2;
        double mer_or = 12;
        double mer_Fi = 0;

        //venera
        double ven_x = 0;
        double ven_y = 0;
        double ven_r = 1;
        double ven_or = 23;
        double ven_Fi = 0;

        //zemlja
        double zem_x = 0;
        double zem_y = 0;
        double zem_r = 1;
        double zem_or = 32;
        double zem_Fi = 0;

        //mars
        double mar_x = 0;
        double mar_y = 0;
        double mar_r = 1;
        double mar_or = 49;
        double mar_Fi = 0;

        //jupiter
        double jup_x = 0;
        double jup_y = 0;
        double jup_r = 4;
        double jup_or = 167;
        double jup_Fi = 0;

        //satrun
        double sat_x = 0;
        double sat_y = 0;
        double sat_r = 4;
        double sat_or = 307;
        double sat_Fi = 0;
        
        //uran
        double ura_x = 0;
        double ura_y = 0;
        double ura_r = 2;
        double ura_or = 618;
        double ura_Fi = 0;

        //neptun
        double nep_x = 0;
        double nep_y = 0;
        double nep_r = 2;
        double nep_or = 969;
        double nep_Fi = 0;


        //pluto 
        double plu_x = 0;
        double plu_y = 0;
        double plu_r = 2;
        double plu_or = 1274;
        double plu_Fi = 0;



        


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Enabled =! timer1.Enabled;
            sun_x = pictureBox1.Width/2;
            sun_y = pictureBox1.Height/2;
            sun_r = 2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            
            //sunce
            Graphics g = pictureBox1.CreateGraphics();
            Pen sun = new Pen(Color.FromArgb(231, 76, 7), 5);
            g.DrawEllipse(sun,(float)sun_x,(float)sun_y,(float)sun_r,(float)sun_r);
            
            //merkur
            Pen mer = new Pen(Color.FromArgb(119, 119, 119),5);
            mer_x = sun_x + mer_or*Math.Cos(mer_Fi);
            mer_y = sun_y + mer_or*Math.Sin(mer_Fi);
            g.DrawEllipse(mer,(float)mer_x,(float)mer_y,(float)mer_r,(float)mer_r);
            mer_Fi = mer_Fi + 4.090909090909091 * (Math.PI / 360);

            //venera
            Pen ven = new Pen(Color.FromArgb(176, 108, 32), 5);
            ven_x = sun_x + ven_or * Math.Cos(ven_Fi);
            ven_y = sun_y + ven_or * Math.Sin(ven_Fi);
            g.DrawEllipse(ven, (float)ven_x, (float)ven_y, (float)ven_r, (float)ven_r);
            ven_Fi = ven_Fi + 1.6 * (Math.PI / 360);

            //zemlja
            Pen zem = new Pen(Color.FromArgb(97, 102, 124), 5);
            zem_x = sun_x + zem_or * Math.Cos(zem_Fi);
            zem_y = sun_y + zem_or * Math.Sin(zem_Fi);
            g.DrawEllipse(zem, (float)zem_x, (float)zem_y, (float)zem_r, (float)zem_r);
            zem_Fi = zem_Fi + 0.9863013698630137 * (Math.PI / 360);

            //mars
            Pen mar = new Pen(Color.FromArgb(195, 114, 85), 5);
            mar_x = sun_x + mar_or * Math.Cos(mar_Fi);
            mar_y = sun_y + mar_or * Math.Sin(mar_Fi);
            g.DrawEllipse(mar, (float)mar_x, (float)mar_y, (float)mar_r, (float)mar_r);
            mar_Fi = mar_Fi + 0.5240174672489083 * (Math.PI / 360);

            //jupiter
            Pen jup = new Pen(Color.FromArgb(170, 142, 129), 5);
            jup_x = sun_x + jup_or * Math.Cos(jup_Fi);
            jup_y = sun_y + jup_or * Math.Sin(jup_Fi);
            g.DrawEllipse(jup, (float)jup_x, (float)jup_y, (float)jup_r, (float)jup_r);
            jup_Fi = jup_Fi + 0.0821917808219178 * (Math.PI / 360);

            //satrun
            Pen sat = new Pen(Color.FromArgb(167, 150, 110), 5);
            sat_x = sun_x + sat_or * Math.Cos(sat_Fi);
            sat_y = sun_y + sat_or * Math.Sin(sat_Fi);
            g.DrawEllipse(sat, (float)sat_x, (float)sat_y, (float)sat_r, (float)sat_r);
            sat_Fi = sat_Fi + 0.0327272727272727 * (Math.PI / 360);

            //uran
            Pen ura = new Pen(Color.FromArgb(185, 223, 226), 5);
            ura_x = sun_x + ura_or * Math.Cos(ura_Fi);
            ura_y = sun_y + ura_or * Math.Sin(ura_Fi);
            g.DrawEllipse(ura, (float)ura_x, (float)ura_y, (float)ura_r, (float)ura_r);
            ura_Fi = ura_Fi + 0.0116129032258065 * (Math.PI / 360);

            //neptun
            Pen nep = new Pen(Color.FromArgb(56, 82, 199), 5);
            nep_x = sun_x + nep_or * Math.Cos(nep_Fi);
            nep_y = sun_y + nep_or * Math.Sin(nep_Fi);
            g.DrawEllipse(ura, (float)nep_x, (float)nep_y, (float)nep_r, (float)nep_r);
            nep_Fi = nep_Fi + 0.0059800664451827 * (Math.PI / 360);

            //pluto
            Pen plu = new Pen(Color.FromArgb(56, 82, 199), 5);
            plu_x = sun_x + plu_or * Math.Cos(plu_Fi);
            plu_y = sun_y + plu_or * Math.Sin(plu_Fi);
            g.DrawEllipse(plu, (float)plu_x, (float)plu_y, (float)plu_r, (float)plu_r);
            plu_Fi = plu_Fi + 0.0039823008849558 * (Math.PI / 360);
            






        }


    }
}

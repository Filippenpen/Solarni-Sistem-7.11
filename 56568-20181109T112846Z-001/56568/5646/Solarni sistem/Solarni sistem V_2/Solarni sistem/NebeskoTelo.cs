using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Nebesko_Telo
    {
        public string name;
        public static double zoom = 2;
        public static double tilt = 1;




        public double x;
        public double y;

        public double x_or;
        public double y_or;
        public double width_or;
        public double height_or;



        public double r;
        public double or;
        public double Fi;

        private static int re;
        private static int gr;
        private static int bl;

        public double Fi_mult;
        public double tilt_planet_nat;

        public double or_ofset_x;
        public double or_ofset_y;

        public double or_smush_x;
        public double or_smush_y;
        public double Mass;
        public double semi_major;


        public Nebesko_Telo(double _r, double _or,double _mass,double _semi_major, double _or_ofset_x, double _or_ofset_y, double _or_smush_x, double _or_smush_y,  double _Fi_mult, double _tilt_planet_nat, int _re, int _gr, int _bl)
        {

            r = _r;
            or = _or;
            Fi_mult = _Fi_mult;
            re = _re;
            gr = _gr;
            bl = _bl;
            tilt_planet_nat = _tilt_planet_nat;
            or_ofset_x = _or_ofset_x;
            or_ofset_y = _or_ofset_y;
            or_smush_x = _or_smush_x;
            or_smush_y = _or_smush_y;
            Mass = _mass;
            semi_major = _semi_major;

        }


        // ovo odredjuje dali je tilt preso preko neke odredjene tacke(u ovom slucaju 0 ili 1)
        public static void Tilt_tilt(double fi)
        {
            if (tilt - fi <= 0 || tilt - fi >= 1 ) {
                return;
            }
            tilt -= fi;
        }

        //ovde se izvodi tilt 
        public static void Tilt_tilt(double fi, bool gore)
        {
            if (gore)
            {
                Tilt_tilt(-fi);
            }
            else
            {
                Tilt_tilt(fi);
            }
        }

        Pen pla_boj = new Pen(Color.FromArgb(re, gr, bl),1);
        Pen or_boj = new Pen(Color.FromArgb(re, gr, bl));

        public void DrawPlanet (Graphics a)
        {
            a.DrawEllipse(pla_boj,(float) x, (float) y ,(float) r, (float) r);
            a.DrawEllipse(or_boj,(float)x_or,(float)y_or,(float)width_or,(float)height_or);
        }

        public void CalcPlanet(double rel_tel_x, double rel_tel_y) {

            /*planet poz*/
            x = rel_tel_x + or * Math.Cos(Fi) * zoom - r;

                                                                                 //x = ((rel_tel_x) + ((or + or_ofset_x) * Math.Cos(Fi)) * zoom)-r;

            y = rel_tel_y + tilt * or * Math.Sin(Fi) * zoom - r; 

                                                                                //y = (rel_tel_y) + tilt * (or * Math.Sin(Fi) * zoom)-r;
                                                                                //y = (rel_tel_y) + tilt * ((rel_tel_y + (or * Math.Sin(Fi)) * zoom) - rel_tel_y);

            Fi = Fi + Fi_mult * (Math.PI / 360);
            //fi merkura 
            Fi = Fi + Math.Sqrt(SpecialFunction.GRAV * 1.923e-30 * (2 / Math.Abs(Sun.x - x) - 1 / semi_major)) / Math.Abs(Sun.x - x) * TimerOptions.t;


            /*orbit poz*/
            x_or = rel_tel_x - (or * zoom);
                                                                                //x_or = (rel_tel_x + or_ofset_x) - (or * zoom);
            y_or = rel_tel_y - (or * zoom) * tilt;
                                                                                //y_or = (rel_tel_y + or_ofset_y) - (or * zoom) * tilt;
            width_or = (or * zoom) * 2;

            height_or = (or * zoom) * 2 * tilt;
        }
    }
}

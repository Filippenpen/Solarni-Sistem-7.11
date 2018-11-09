using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{

    class NebeskoTeloV2
    {
        public NebeskoTeloV2 parent;
        public double mass;
        public static double zoom = 2;
        public static double tilt = 1;
        public string name;
        public bool osenceno_planeta;
        public bool osenceno_or;

        public double ese;

        public double Fi_Plan;

        public double alfa;

        public double semi_major;

        public double pla_r;

        public Color plan_color;
        public Color plan_color_os;


        int re;
        int gr;
        int bl;

        protected SolidBrush pla_brush;
        Pen or_pen;
        public Color EdColor
        {
            get { return plan_color; }
            set { plan_color = value; NewBrush(); NewPen(); }
            
        }
        public void NewBrush() {
            pla_brush = new SolidBrush(plan_color);
        }
        public void NewPen()
        {
            or_pen = new Pen(plan_color,1);
        }
        public double EdMass
        {
            get { return mass; }
            set { mass = value; }
        }
        public double EdSemi_major 
        {
            get { return mass; }
            set { mass = value; }
        }
        public string EdName 
        {
            get { return name; }
            set { name = value; }
        }
        public double EdEse
        {
            get { return ese; }
            set { ese = value; }
        }
        public double EdAlfa
        {
            get { return alfa; }
            set { alfa = value; }
        }
        public double EdPla_r
        {
            get { return pla_r; }
            set { pla_r = value; }
        }
        

        

        
        

        /*public double x_prim;
        public double y_prim;*/

        /*
        public double x;
        public double y;
        public double _x;
        public double _y;
        public double x_or;
        public double y_or;
        public double x_ac;
        public double y_ac;
        public double or_width;
        public double or_height;
        */
        /*
        public double r;
        */


        /*
        public double semi_minor;
        */

        

        /*
        public double v_actual;
        public double v_angular;
        */



        //double ang = 0;
        
        public static void Tilt_tilt(double f_i, bool gore)
        {
            if (gore)
            {
                Tilt_tilt(-f_i);
            }
            else
            {
                Tilt_tilt(f_i);
            }
        }
        public static void Tilt_tilt(double f_i)
        {
            if (tilt - f_i <= 0 || tilt - f_i >= 1)
            {
                return;
            }
            tilt -= f_i;
        }
        public NebeskoTeloV2()
        {/*
            alfa = X_Ofset;
            mass = Mass_Of_The_Body;
            parent_mass = Parnet_Body_Mass;
            semi_major = Semi_Major_Axis_of_Orbit;
            ese = Eccentricity;
            pla_r = Circumference_of_the_planet;
            re = Rgb_Red;
            gr = Rgb_Green;
            bl = Rgb_Blue;
            parent = _parent;*/
        }
        public double semi_major_calc() {
            return semi_major * zoom;
            /*double ras = Math.Sqrt((foc_2_x() - parent.x()) * (foc_2_x() - parent.x()) + (foc_2_y() - parent.y()) * (foc_2_y() - parent.y()));
            return ras*ese;
            double sm_x = semi_major * Math.Cos(alfa);
            double sm_y = semi_major * Math.Sin(alfa);
            sm_y *= tilt;
            return zoom * Math.Sqrt(sm_x*sm_x+sm_y*sm_y);
            */

        }

        public NebeskoTeloV2(string _name, double Mass_Of_The_Body,
            double Semi_Major_Axis_of_Orbit, double Eccentricity, double X_Ofset,
            double Circumference_of_the_planet, NebeskoTeloV2 neb, Color Color)
        {
            alfa = X_Ofset;
            mass = Mass_Of_The_Body;
            semi_major = Semi_Major_Axis_of_Orbit;
            ese = Eccentricity;
            pla_r = Circumference_of_the_planet;
            plan_color = Color;

            pla_brush = new SolidBrush(plan_color);

            or_pen = new Pen(plan_color, 1);

            parent = neb;
            name = _name;
      
        }
        public void Cursor_Plan(double mis_x, double mis_y)
        {
            double tilted_y = tilt_y(y());
            if (mis_x >= x() - pla_r_calc(pla_r) && mis_x <= x() + pla_r_calc(pla_r) &&
                (mis_y >= tilted_y - pla_r_calc(pla_r) && mis_y <= tilted_y + pla_r_calc(pla_r)))
            {
                osenceno_planeta = true;
                plan_color_os = Color.FromArgb(plan_color.A - 20, plan_color.R, plan_color.G, plan_color.B);
                pla_brush = new SolidBrush(plan_color_os);
            }
            else
            {
                pla_brush = new SolidBrush(plan_color);
                osenceno_planeta = false;

            }
        }
        public virtual void Cursor_Or(double mis_x, double mis_y)
        {
            mis_y = tilt_y_reversed(mis_y);
            double pf1 = Math.Sqrt((mis_x - parent.x()) * (mis_x - parent.x()) + (mis_y - parent.y()) * (mis_y - parent.y()));
            double pf2 = Math.Sqrt((mis_x - foc_2_x()) * (mis_x - foc_2_x()) + (mis_y - foc_2_y()) * (mis_y - foc_2_y()));
            
            double zbir = pf1 + pf2;
            if (Math.Abs(zbir - 2 * semi_major_calc()) < 20)
            {
                osenceno_or = true;
                plan_color_os = Color.FromArgb(plan_color.A - 20, plan_color.R, plan_color.G, plan_color.B);
                or_pen = new Pen(plan_color_os, 2);
            }
            else
            {
                or_pen = new Pen(plan_color, 1);
                osenceno_or = false;

            }
        }
        public double c()
        {
            double c = Math.Sqrt((Math.Pow(semi_major, 2) - Math.Pow(semi_minor(), 2)));
            return c;
        }

        public virtual double ParentX()
        {

            return parent.x();
        }
        public virtual double ParentY()
        {
            return parent.y();
        }
        public virtual double SunX()
        {

            return parent.SunX();
        }
        public virtual double SunY()
        {
            return parent.SunY();
        }
        //second focus
        public double _foc_2_x()
        {
            return parent.x_() + c() * 2;
        }
        public double _foc_2_y()
        {
            return parent.y_();
        }
        public double foc_2_x() {
           double x_rot = (_foc_2_x() * Math.Cos(alfa) + _foc_2_y() * Math.Sin(alfa)) * zoom;
           return x_rot + parent.ParentX();

        }
        public double foc_2_y()
        {
            double y_rot = (-_foc_2_x() * Math.Sin(alfa) + _foc_2_y() * Math.Cos(alfa)) * zoom;
            return y_rot + parent.ParentY();
        }


        // semi minor
        private double semi_minor()
        {
            double semi_minor = Math.Sqrt(Math.Pow(semi_major, 2) * (1 - Math.Pow(ese, 2)));
            return semi_minor;
        }

        //pla_r
        public double pla_r_calc(double _pla_r)
        {
            return _pla_r * zoom;
        }

        // r----------------------------------------------------------------------------------
        private double r(double fi)
        {
            double r = semi_major * (1 - Math.Pow(ese, 2)) / (1 - ese * Math.Cos(fi));
            return r;
        }
        private double r()
        {
            return r(Fi_Plan);
        }
        //------------------------------------------------------------------------------------

        //fi----------------------------------------------------------------------------------
        private double fi_calc(double fi)
        {
            double _r = r(fi);
            double v_actual = Math.Sqrt(SpecialFunction.GRAV * parent.mass * (2 / _r - 1 / semi_major));
            double v_angular = v_actual / _r;
            return fi + (v_angular * TimerOptions.t);
        }
        private void fi_calc()
        {
            Fi_Plan = fi_calc(Fi_Plan);
            if (Fi_Plan >= 2 * Math.PI)
                Fi_Plan -= 2 * Math.PI;
        }
        //------------------------------------------------------------------------------------

        //x-----------------------------------------------------------------------------------
        public double x_(double fi)
        {
            double x = r(fi) * Math.Cos(fi);
            return x;
        }
        public double x_()
        {
            double x = r(Fi_Plan) * Math.Cos(Fi_Plan);
            return x;
        }
        private double x(double fi)
        {
            double x_rot = (x_(fi) * Math.Cos(alfa) + y_(fi) * Math.Sin(alfa)) * zoom;
            double x = (x_rot + parent.x());
            return x;
        }
        public virtual double x()
        {
            return x(Fi_Plan);
        }
        //------------------------------------------------------------------------------------

        //y-----------------------------------------------------------------------------------
        private double y_(double fi)
        {
            return r(fi) * Math.Sin(fi);
        }
        private double y_()
        {
            return r(Fi_Plan) * Math.Sin(Fi_Plan);
        }


        private double y(double fi)
        {
            double y_rot = (-x_(fi) * Math.Sin(alfa) + y_(fi) * Math.Cos(alfa)) * zoom;
            return y_rot + parent.y();
        }
        public virtual double y()
        {
            return y(Fi_Plan);
        }

        double tilt_y(double y)
        {
            return SunY() + (y - SunY()) * tilt;
        }

        double tilt_y_reversed(double y)
        {
            return SunY() + (y - SunY()) / tilt;
        }
        //-----------------------------------------------------------------------------------

        //Drawing----------------------------------------------------------------------------
        Font drawFont = new Font("Arial", 16);
        public void DrawName(Graphics a)
        {
            a.DrawString(name, drawFont,
                pla_brush,
                (float)(x() + pla_r_calc(pla_r)),
                (float)(tilt_y(y()) - pla_r_calc(pla_r)));


        }
        public void DrawPlanet(Graphics a)
        {
            a.FillEllipse(pla_brush,
                (float)(x() - pla_r_calc(pla_r)), 
                (float)(tilt_y(y()) - pla_r_calc(pla_r)), 
                (float)pla_r_calc(pla_r) * 2, 
                (float)pla_r_calc(pla_r) * 2);
            /*x_prim = x(Fi_Plan);
            y_prim = y(Fi_Plan);*/
        }
        public void DrawSecondFocus(Graphics a)
        {
            a.FillEllipse(pla_brush,
               (float)(foc_2_x() - pla_r_calc(pla_r)),
               (float)(tilt_y(foc_2_y()) - pla_r_calc(pla_r)),
               (float)pla_r_calc(pla_r) * 2,
               (float)pla_r_calc(pla_r) * 2);

        }
        public void DrawOrbit(Graphics a)
        {
            double i = 0;
            double k = 1000;
            double x_1 = x(i * 2 * Math.PI / k);
            double y_1 = tilt_y(y(i * 2 * Math.PI / k));
            while (i < k)
            {
                i++;
                double x_2 = x(i * 2 * Math.PI / k);
                double y_2 = tilt_y(y(i * 2 * Math.PI / k));
                a.DrawLine(or_pen, (float)x_1, (float)y_1, (float)x_2, (float)y_2);
                x_1 = x_2;
                y_1 = y_2;
            }

        }
        public virtual void Draw(Graphics a)
        {
            DrawPlanet(a);
            DrawOrbit(a);
            DrawName(a);
            fi_calc();

        }
        //-----------------------------------------------------------------------------------
    }
}

    
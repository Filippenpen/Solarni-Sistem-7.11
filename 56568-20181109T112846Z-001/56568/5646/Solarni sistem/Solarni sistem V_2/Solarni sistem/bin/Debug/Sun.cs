using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1

{
    class Sun : NebeskoTeloV2
    {
        public double Sun_x;
        public double Sun_y;
        
        public Sun(double _r, double _mass, Color c) 
            : base("Sun",_mass, 0, 0, 0, _r, null, c)
        {
            
        }

        public void move_x(double d)
        {
            Sun_x += d;
        
        }
        public void move_y(double d)
        {
            Sun_y += d;
        }
        public override double ParentX()
        {
            return Sun_x;
        }
        public override double ParentY()
        {
            return Sun_y;
        }

        public override double SunX()
        {
            return Sun_x;
        }
        public override double SunY()
        {
            return Sun_y;
        }
        public override void Cursor_Or(double x_mis, double y_mis)
        {

        }
        public override void Draw(Graphics a) 
        {
            a.FillEllipse(pla_brush, (float)(Sun_x - pla_r_calc(pla_r)), (float)(Sun_y - pla_r_calc(pla_r)), (float)(2 * pla_r_calc(pla_r)), (float)(2 * pla_r_calc(pla_r)));
            DrawName(a);
        
   
        }
        public override double x()
        {
            return Sun_x;
        }
        public override double y()
        {
            return Sun_y;
        }
        
    } 
}

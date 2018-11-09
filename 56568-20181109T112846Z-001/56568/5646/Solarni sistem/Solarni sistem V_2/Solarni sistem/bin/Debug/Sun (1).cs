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

        public Sun(double _r, double _mass, int Rgb_Red, int Rgb_Green, int Rgb_Blue) 
            : base(_mass, 0, 0, 0, _r, null, Rgb_Red, Rgb_Green, Rgb_Blue)
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
        public override double ParentParentX()
        {
            return Sun_x;
        }
        public override double ParentParentY()
        {
            return Sun_y;
        }
        public override void Cursor_Or()
        {
            
        }
        public override void Draw(Graphics a) 
        {
            a.DrawEllipse(pla_boj, (float)(Sun_x - pla_r_calc(pla_r)), (float)(Sun_y - pla_r_calc(pla_r)), (float)(2 * pla_r_calc(pla_r)), (float)(2 * pla_r_calc(pla_r)));
        
   
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

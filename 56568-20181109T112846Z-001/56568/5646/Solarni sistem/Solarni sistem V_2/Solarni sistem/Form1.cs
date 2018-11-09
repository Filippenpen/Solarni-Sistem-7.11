using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool zoom_plus = false;
        bool zoom_minus = false;
        int Form1_Width = 0;
        int Form1_Height = 0;


        
           
        private void Form1_Shown(object sender, EventArgs e)
        {

            Form1_Width = this.Width;
            Form1_Height = this.Height;
            this.Paint += new PaintEventHandler(Form1_paint);

        }

        Sun sun;

        IList<NebeskoTeloV2> tela = new List<NebeskoTeloV2>();
        

        private void Form1_Load_1(object sender, EventArgs e)
        {

            sun = new Sun(10, 1000 , Color.Orange);
            tela.Add(sun);
            tela.Add(new NebeskoTeloV2("Body1",100, 300, 0.5, 20, 5, tela[0], Color.Blue));
            //tela.Add(new NebeskoTeloV2(100, 300, 0.5, 20, 5, pronadji(tela, "sunce"), 50, 50, 50));
            tela.Add(new NebeskoTeloV2("Body2",23, 75, 0.5, 20, 5, tela[1], Color.Green));
            /*merkur = new NebeskoTeloV2(23, 50, 200, 0.9, -60, 5, sun, 255, 255, 255);
            mesec = new NebeskoTeloV2(2, 23, 25, 0.0002, 3, 2, merkur, 255, 255, 255);*/
        }

        bool key_down = false;
        bool key_up = false;
        //sunce
        






        //merkur
        //NebeskoTeloV2 merkur = new NebeskoTeloV2(3.285 * Math.Pow(10,23), 1.989 * Math.Pow(10, 30), 57909050, 0.205630, 15329,255,255,255);


        //Nebesko_Telo merkur = new Nebesko_Telo(2440, 12, 6, 0, 0, 0, 4.090909090909091, 1, 255, 255, 255);
        /*

       //venera
       Nebesko_Telo venera = new Nebesko_Telo(1, 23, 1.6,1, 176, 108, 32);


       //zemlja
       Nebesko_Telo zemlja = new Nebesko_Telo(1, 32, 0.9863013698630137,0.6,255, 255, 255);

       //mars
       Nebesko_Telo mars = new Nebesko_Telo(1, 49, 0.5240174672489083, 1, 195, 114, 85);

       //jupiter
       Nebesko_Telo jupiter = new Nebesko_Telo(4, 167, 0.0821917808219178, 1,  170, 142, 129);

       //satrun
       Nebesko_Telo saturn = new Nebesko_Telo(4, 307, 0.0327272727272727, 1, 167, 150, 110);

       //uran
       Nebesko_Telo uran = new Nebesko_Telo(2, 618, 0.0116129032258065, 1,  185, 223, 226);

       //neptun
       Nebesko_Telo neptun = new Nebesko_Telo(2, 969, 0.0059800664451827, 1,  56, 82, 199);


       //pluto 
       Nebesko_Telo pluto = new Nebesko_Telo(2, 1274, 0.0039823008849558, 1, 56, 82, 199);
       */


        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (key_down)
            {
                NebeskoTeloV2.Tilt_tilt(0.01, true);
            }
            else if (key_up)
            {
                NebeskoTeloV2.Tilt_tilt(0.01, false);
            }
            else if (zoom_plus)
            {
                NebeskoTeloV2.zoom += 0.01;
                
            }
            else if (zoom_minus /*&& Nebesko_Telo.zoom > 0*/)
            {
                NebeskoTeloV2.zoom -= 0.01;
               
            }   
            this.Refresh();

        }
            
        private void Form1_paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
           /* 
            if (TimerOptions.TimerOnOrOff) {
                merkur.IzracunajPlanetu(Sun.x, Sun.y);
                //merkur.CalcPlanet(Sun.x, Sun.y);
                /*
                venera.CalcPlanet(Sun.x, Sun.y);

                zemlja.CalcPlanet(Sun.x, Sun.y);

                mars.CalcPlanet(Sun.x, Sun.y);

                jupiter.CalcPlanet(Sun.x, Sun.y);

                saturn.CalcPlanet(Sun.x, Sun.y);

                uran.CalcPlanet(Sun.x, Sun.y);

                neptun.CalcPlanet(Sun.x, Sun.y);

                pluto.CalcPlanet(Sun.x, Sun.y);
                */
           
        
            
            //sun.Draw(e.Graphics);

            //mesec.Draw(e.Graphics);

            //merkur.Draw(e.Graphics);

            foreach(NebeskoTeloV2 neb in tela) {
                neb.Draw(e.Graphics);
            }
            
            
        
            //label1.Text = Convert.ToString(merkur.r());

            /*
            venera.DrawPlanet(e.Graphics);

            zemlja.DrawPlanet(e.Graphics);

            mars.DrawPlanet(e.Graphics);

            jupiter.DrawPlanet(e.Graphics);

            saturn.DrawPlanet(e.Graphics);

            uran.DrawPlanet(e.Graphics);

            neptun.DrawPlanet(e.Graphics);

            pluto.DrawPlanet(e.Graphics);
            */
        }
        /*
        double mouse_down_x = sun.x();
        double mouse_down_y = Sun.Sun_y;*/
        double mouse_down_x;
        double mouse_down_y;
        bool mouse_down = false;
        

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (NebeskoTeloV2 neb in tela)
            {
                neb.Cursor_Plan((double)e.X, (double)e.Y);
                neb.Cursor_Or((double)e.X, (double)e.Y);
            }

            if (mouse_down == true)
            {

                sun.move_x(e.X - mouse_down_x);
                sun.move_y(e.Y - mouse_down_y);
                /*Sun.x = Sun.x + ( e.X-mouse_down_x );
                Sun.y = Sun.y + ( e.Y-mouse_down_y );
                 */
                mouse_down_x = e.X;
                mouse_down_y = e.Y;

            }
            else
            {
            }
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_down = true;
            mouse_down_x = e.X;
            mouse_down_y = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_down = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                key_down = true;
            }
            else if (e.KeyCode == Keys.Up) {
                key_up = true;
            }
            else if (e.KeyCode == Keys.Add)
            {
                zoom_plus = true;
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                zoom_minus = true;

            }
        }
        
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                key_down = false;
            }
            else if (e.KeyCode == Keys.Up)
            {
                key_up = false;
            }
            else if (e.KeyCode == Keys.Add)
            {
                zoom_plus = false;
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                zoom_minus = false;

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            NebeskoTeloV2 refer = null;
            foreach (NebeskoTeloV2 neb in tela)
            {
                if (neb.EdName == comboBox1.Text)
                {
                    refer = neb;
                }
            }

            tela.Add(new NebeskoTeloV2(textBox6.Text,
                Convert.ToDouble(textBox1.Text),
                Convert.ToDouble(textBox2.Text),
                Convert.ToDouble(textBox3.Text),
                Convert.ToDouble(textBox4.Text),
                Convert.ToDouble(textBox5.Text),
                refer,
                colorDialog1.Color));

            panel1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TimerOptions.TimerOnOrOff = !TimerOptions.TimerOnOrOff;
            if (TimerOptions.TimerOnOrOff)
                TimerOptions.t = 0;
            else
                TimerOptions.t = 20000;


        }

        private void newPlanetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            foreach (NebeskoTeloV2 neb in tela) {
                comboBox1.Items.Add(neb.EdName);
            }
            panel1.Visible =! panel1.Visible; 
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           colorDialog1.ShowDialog();
           button2.BackColor = colorDialog1.Color;
        }
        NebeskoTeloV2 osenceno;
        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            foreach (NebeskoTeloV2 neb in tela)
            {
                if (neb.osenceno_planeta || neb.osenceno_or) {
                    osenceno = neb;
                    panel2.Visible = true;
                    label15.Text = osenceno.name;

                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            button3.BackColor = colorDialog1.Color;
            osenceno.plan_color = colorDialog1.Color;
        }


    }
}

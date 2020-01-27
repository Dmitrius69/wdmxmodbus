using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenAL;
using OpenTK.Audio.OpenAL;
using System.Windows.Forms;

namespace wdmxmodbus
{

    public partial class Form1 : Form
    {
        public int yglob = 0;
        public int xglob = 0;
        public int stepX;
        public int stepY;
        public Bitmap buffer;
        private Hexagon hexa;
        private Point p1;
        private Boolean canDraw;

        public Form1()
        {
            InitializeComponent();

            yglob = 0;
            xglob = 10;
            stepX = 20;
            stepY = 20;
            buffer = new Bitmap(pBox1.Width, pBox1.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            Color bClr = pBox1.BackColor;

            p1 = new Point(200, 200);
            hexa = new Hexagon(p1, 20, 40);
            hexa.hex_line = Color.Blue;
            hexa.hex_fill = Color.FromArgb(80, Color.Blue);

            Graphics bG = Graphics.FromImage(buffer);
            bG.FillRectangle(new SolidBrush(Color.Black), 0, 0, buffer.Width, buffer.Height);
            bG.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.Blue)), 0, 0, buffer.Width, buffer.Height);
            drawNet(bG, buffer.Width, buffer.Height, stepX, stepY);
            pBox1.Image = buffer;

            bG.Dispose();
            canDraw = false;
            Application.Idle += new EventHandler(mIdle);
            

        }

        //рисуем сетку
        private void drawNet(Graphics g, int w, int h, int stepX, int stepY)
        {
            //рисуем горизонтальные линии
            for (int i=0;i<h; i+= stepY)
            {
                g.DrawLine(new Pen(Color.Blue), 0, i, w, i);
            }

            //рисуем вертикальные линии
            for(int j = 0; j<w; j += stepX)
            {
                g.DrawLine(new Pen(Color.Blue), j, 0, j, h);
            }

        }


        //рисуем основной экран
        private void drawMain(Bitmap buffer)
        {
            Graphics bG = Graphics.FromImage(buffer);
            bG.FillRectangle(new SolidBrush(Color.Black), 0, 0, buffer.Width, buffer.Height);
            bG.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.Blue)), 0, 0, buffer.Width, buffer.Height);
            drawNet(bG, buffer.Width, buffer.Height, stepX, stepY);

            hexa.draw(bG);
            hexa.fill(bG);
            //pBox1.Image = buffer;

            //bG.Dispose();
        }

        private void mIdle(object sender, EventArgs e)
        {
            //MessageBox.Show("IDLE", "messages");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lloadMainFrm(object sender, EventArgs e)
        {
            Graphics g = pBox1.CreateGraphics();

            g.DrawString("GET CONTEXT load", new Font(FontFamily.GenericMonospace, 14), new SolidBrush(Color.Red), 10, 200);

            //g.Dispose();
        }

        private void fShown(object sender, EventArgs e)
        {
            Graphics g = pBox1.CreateGraphics();

            g.DrawString("GET CONTEXT shown", new Font(FontFamily.GenericMonospace, 30), new SolidBrush(Color.Red), 100, 200);

            pBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // Graphics g = pBox1.CreateGraphics();

            if (yglob < pBox1.Height - 16)
               yglob += 16;
            else
            {
                yglob = 10;
                xglob += 16; 
            }


            drawMain(buffer);
            Graphics g = Graphics.FromImage(buffer);
            //g.FillRectangle(new SolidBrush(Color.Black), 0, 0, buffer.Width, buffer.Height);
            //g.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.Blue)), 0, 0, buffer.Width, buffer.Height);



            g.DrawString("GET CONTEXT button", new Font(FontFamily.GenericMonospace, 14), new SolidBrush(Color.Red), xglob, yglob);


            pBox1.Image = buffer;

            g.Dispose();

        }

        private void pBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("MOUSE CLICK");

            int xM = e.X;
            int yM = e.Y;

            Hexagon h = new Hexagon(new Point(xM, yM), 5, 10);

            drawMain(buffer);

            Graphics bG = Graphics.FromImage(buffer);

            h.draw(bG);
            h.fill(bG);

            pBox1.Image = buffer;
            bG.Dispose();

        }


        //функцию доработать , сейчас не работает корректно 09.04.2018
        private void onResizepBox1(object sender, EventArgs e)
        {
            //вносим изменения в размер отображаемой картинки 
            //получаем размер родного gbox и после этого погоняем размер нашей картинки
            int h = groupBox1.Height;
            int w = groupBox1.Width;
            h = h - 6; //размеры вычисленны эмпирически 
            w = w - 19;
            buffer = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            drawMain(buffer);

            using (Graphics g = Graphics.FromImage(buffer))
            {
                pBox1.Width = w;
                pBox1.Height = h;
                g.DrawString(String.Format("RESIZE PBOX EVENT {0} {1}", pBox1.Width, pBox1.Height), new Font(FontFamily.GenericMonospace, 14), new SolidBrush(Color.Red), xglob, yglob);


                pBox1.Image = buffer;
            }
            groupBox1.Invalidate();
            //g.Dispose();
        }

        private void onResizegBox(object sender, EventArgs e)
        {
            // MessageBox.Show("RESIZE gBox");
            //pBox1.Dock = DockStyle.Fill;
        }

        private void pBox1_MouseDown(object sender, MouseEventArgs e)
        {
            canDraw = true;
        }

        private void pBox1_MouseUp(object sender, MouseEventArgs e)
        {
            canDraw = false;
        }

        private void pBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int xM = e.X;
            int yM = e.Y;

            if (canDraw)
            {

                Hexagon h = new Hexagon(new Point(xM, yM), 5, 10);

                drawMain(buffer);

                Graphics bG = Graphics.FromImage(buffer);

                h.draw(bG);
                h.fill(bG);

                pBox1.Image = buffer;
                bG.Dispose();
            }
        }
    }
}

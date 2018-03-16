using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wdmxmodbus
{
    public class Hexagon
    {
        //START
            public Point[] hex;
            public Pen p;
            public SolidBrush br;
            private Color color_line;
            private Color color_fill;
            private Point cnthex;
            private int sX;
            private int sY;
            public Point central { set { recalc_coord(value); } get { return cnthex; } }
            public Color hex_line { set { set_color_line(value); } get { return color_line; } }
            public Color hex_fill { set { set_color_fill(value); } get { return color_fill; } }

            //конструктор класса
            public Hexagon(Point center, int sizeX, int sizeY)
            {
                hex = new Point[6];
                hex[0].X = center.X + sizeX;
                hex[0].Y = center.Y - sizeY;
                hex[1].X = center.X + 2 * sizeX;
                hex[1].Y = center.Y;
                hex[2].X = center.X + sizeX;
                hex[2].Y = center.Y + sizeY;
                hex[3].X = center.X - sizeX;
                hex[3].Y = center.Y + sizeY;
                hex[4].X = center.X - 2 * sizeX;
                hex[4].Y = center.Y;
                hex[5].X = center.X - sizeX;
                hex[5].Y = center.Y - sizeY;
                color_line = Color.Green;
                color_fill = Color.FromArgb(80, Color.Green);
                p = new Pen(color_line);
                br = new SolidBrush(color_fill);
                cnthex = center;
                sX = sizeX;
                sY = sizeY;
            }

            //деструктор класса
            ~Hexagon()
            {
                Dispose();
            }

            void recalc_coord(Point center)
            {
                cnthex = center;
                hex[0].X = center.X + sX;
                hex[0].Y = center.Y - sY;
                hex[1].X = center.X + 2 * sX;
                hex[1].Y = center.Y;
                hex[2].X = center.X + sX;
                hex[2].Y = center.Y + sY;
                hex[3].X = center.X - sX;
                hex[3].Y = center.Y + sY;
                hex[4].X = center.X - 2 * sX;
                hex[4].Y = center.Y;
                hex[5].X = center.X - sX;
                hex[5].Y = center.Y - sY;
            }


            private void set_color_line(Color cl)
            {
                color_line = cl;
            }

            private void set_color_fill(Color cl)
            {
                color_fill = cl;
            }

            public void draw(Graphics g)
            {
                p.Color = color_line;
                try
                {
                    g.DrawPolygon(p, hex);
                }
                catch { }
            }

            public void fill(Graphics g)
            {
                br.Color = color_fill;
                try
                {
                    g.FillPolygon(br, hex);
                }
                catch { }
            }

            public bool inhex(Point ptr)
            {
                // проверяем попала ли точка в шестиугольник
                bool inner = false;
                if ((ptr.Y >= hex[0].Y) && (ptr.Y <= hex[3].Y))
                {
                    if ((ptr.X >= hex[4].X) && (ptr.X <= hex[1].X))
                    {
                        if (((ptr.X > hex[4].X) && (ptr.X < hex[5].X)) || ((ptr.X > hex[0].X) && (ptr.X < hex[1].X)))
                        {
                            // если мы попадаем в один из 4-х треугольников то false
                            inner = false;

                        }
                        else
                        {
                            inner = true;
                        }
                    }
                }
                return inner;

            }

            public void Dispose()
            {
                //
                br.Dispose();
                p.Dispose();
            }


        

        //END OF CLASS
    }
}

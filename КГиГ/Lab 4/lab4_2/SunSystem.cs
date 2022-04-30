using System;
using System.Drawing;


namespace lab4_2
{
    public class SunSystem
    {
        public Planet sun = new Planet(70, 0, System.Drawing.Brushes.Yellow);
        public Planet marth = new Planet(35, 100, System.Drawing.Brushes.Red);
        public Planet earth = new Planet(60, 200, System.Drawing.Brushes.Blue);
        public Planet moon = new Planet(20, 80, System.Drawing.Brushes.LightGray);
        public Planet test = new Planet(80, 380, System.Drawing.Brushes.Blue);
        public Planet test_moon = new Planet(30, 80, System.Drawing.Brushes.Red);
        public Planet sputnik = new Planet(15, 60, System.Drawing.Brushes.Red);
        public float kx = 1;
        public float ky = 1;

        public int earth_angel;

        Bitmap bitmap;
        Graphics gr;

        public SunSystem(Bitmap bitmap)
        {
            this.bitmap = bitmap;
            gr = Graphics.FromImage(bitmap);
        }

        public CMatrix per_planet(float angel, Planet p)
        {
            CMatrix ret = new CMatrix(1, 3);

            double y = Math.Sin(angel * 0.0174533d) * p.Distanse - p.Size/2;
            double x = Math.Cos(angel * 0.0174533d) * p.Distanse - p.Size/2;

            ret.arr[0, 0] = Convert.ToInt32(x);
            ret.arr[0, 1] = Convert.ToInt32(y);
            ret.arr[0, 2] = 1;

            return ret;
        }

        public CMatrix pos()
        {
            CMatrix ret = new CMatrix(3, 3);

            ret.arr[0, 0] = kx;
            ret.arr[0, 1] = 0;
            ret.arr[0, 2] = 0;

            ret.arr[1, 0] = 0;
            ret.arr[1, 1] = ky;
            ret.arr[1, 2] = 0;

            ret.arr[2, 0] = bitmap.Width / 2;
            ret.arr[2, 1] = bitmap.Height / 2;        
            ret.arr[2, 2] = 1;

            return ret;
        }
        public CMatrix pos(float x, float y)
        {
            CMatrix ret = new CMatrix(3, 3);

            ret.arr[0, 0] = kx;
            ret.arr[0, 1] = 0;
            ret.arr[0, 2] = 0;

            ret.arr[1, 0] = 0;
            ret.arr[1, 1] = ky;
            ret.arr[1, 2] = 0;

            ret.arr[2, 0] = x;
            ret.arr[2, 1] = y;
            ret.arr[2, 2] = 1;

            return ret;
        }


        public void Draw(float ang1, float ang2, float ang3, float ang4, float ang5, float ang6)
        {
            gr.Clear(Color.Black);
            
            CMatrix marth_p = new CMatrix(3, 1);
            CMatrix earth_p = new CMatrix(3, 1);
            CMatrix moon_p = new CMatrix(3, 1);
            CMatrix test_p = new CMatrix(3, 1);
            CMatrix tmoon_p = new CMatrix(3, 1);
            CMatrix sputnik_p = new CMatrix(3, 1);


            marth_p.arr = CMatrix.Multiplication(per_planet(ang1, marth).arr, pos().arr);
            earth_p.arr = CMatrix.Multiplication(per_planet(ang2, earth).arr, pos().arr);
            moon_p.arr = CMatrix.Multiplication(per_planet(ang3, moon).arr, pos(earth_p.arr[0, 0] + earth.Size/2,
                earth_p.arr[0, 1] + earth.Size / 2).arr);
            test_p.arr = CMatrix.Multiplication(per_planet(ang4, test).arr, pos().arr);
            tmoon_p.arr = CMatrix.Multiplication(per_planet(ang5, test_moon).arr, pos(test_p.arr[0, 0] + test.Size / 2,
                test_p.arr[0, 1] + test.Size / 2).arr);
            sputnik_p.arr = CMatrix.Multiplication(per_planet(ang6, sputnik).arr, pos(tmoon_p.arr[0, 0] + test_moon.Size / 2,
                 tmoon_p.arr[0, 1] + test_moon.Size / 2).arr);
            Pen blackPen = new Pen(Color.White, 2); //Орбитальная кисть

            //Иниациальзирование орбит
            Rectangle rect = new Rectangle(bitmap.Width / 2 - marth.Distanse, bitmap.Height / 2 - marth.Distanse,
                marth.Distanse * 2, marth.Distanse * 2);
            Rectangle rect2 = new Rectangle((int)earth_p.arr[0, 0] - moon.Distanse + earth.Size / 2,
                (int)earth_p.arr[0, 1] - moon.Distanse + earth.Size / 2, moon.Distanse * 2, moon.Distanse * 2);
            Rectangle rect3 = new Rectangle(bitmap.Width / 2 - earth.Distanse, bitmap.Height / 2 - earth.Distanse, 
                earth.Distanse * 2, earth.Distanse * 2);
            Rectangle rect4 = new Rectangle(bitmap.Width / 2 - test.Distanse, bitmap.Height / 2 - test.Distanse,
                test.Distanse * 2, test.Distanse * 2);
            Rectangle rect5 = new Rectangle((int)test_p.arr[0, 0] - test_moon.Distanse + test.Size / 2,
            (int)test_p.arr[0, 1] - test_moon.Distanse + test.Size / 2, test_moon.Distanse * 2, test_moon.Distanse * 2);
            Rectangle rect6 = new Rectangle((int)tmoon_p.arr[0, 0] - sputnik.Distanse + test_moon.Size / 2,
            (int)tmoon_p.arr[0, 1] - sputnik.Distanse + test_moon.Size / 2, sputnik.Distanse * 2, sputnik.Distanse * 2);

            //Отрисовка орбит
            gr.DrawArc(blackPen, rect, 0, 360);
            gr.DrawArc(blackPen, rect2, 0, 360);
            gr.DrawArc(blackPen, rect3, 0, 360);
            gr.DrawArc(blackPen, rect4, 0, 360);
            gr.DrawArc(blackPen, rect5, 0, 360);
            gr.DrawArc(blackPen, rect6, 0, 360);
            //Обрисовка астр. объ.
            sun.Fill(gr, bitmap.Width/2 - sun.Size/2, bitmap.Height/2 - sun.Size / 2);            
            marth.Fill(gr, marth_p.arr[0,0], marth_p.arr[0, 1]);
            earth.Fill(gr, earth_p.arr[0, 0], earth_p.arr[0, 1]);
            moon.Fill(gr, moon_p.arr[0, 0], moon_p.arr[0, 1]);
            test.Fill(gr, test_p.arr[0, 0], test_p.arr[0, 1]);
            test_moon.Fill(gr, tmoon_p.arr[0, 0], tmoon_p.arr[0, 1]);
            sputnik.Fill(gr, sputnik_p.arr[0, 0], sputnik_p.arr[0, 1]);

        }
    }
}

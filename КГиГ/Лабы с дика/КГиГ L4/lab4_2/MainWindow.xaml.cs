using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace lab4_2
{
        public partial class MainWindow : Window
    {
        BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            s.Draw(mars_ang, earth_ang, moon_ang, test_ang, tmoon_ang, sputnik_2_ang);
            photo1.Source = BitmapToImageSource(bitmap);

            mars_ang += -1;
            earth_ang += 1;
            moon_ang += 3;
            test_ang += -1;
            tmoon_ang += 4;
            sputnik_2_ang += 13;
        }

        static int x1 = 1040;
        static int y1 = 680;

        static float mars_ang;
        static float earth_ang;
        static float moon_ang;
        static float test_ang;
        static float tmoon_ang;
        static float sputnik_2_ang;

        static Bitmap bitmap = new Bitmap(x1, y1);
        Timer timer = new Timer();

        static SunSystem s = new SunSystem(bitmap);


        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = 1000 / 60;
            timer.Tick += new EventHandler(timer_Tick);
        }

        private void But_Planets_Click(object sender, RoutedEventArgs e)
        {
            if (!timer.Enabled)
                timer.Start();
            else
                timer.Stop();
        }
    }
}

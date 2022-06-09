using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NBitcoin;
using QRCoder;


namespace Kyrsach.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для Receive.xaml
    /// </summary>
    public partial class Receive : Page
    {
        public Receive()
        {
            InitializeComponent();

            var s = Application.Current.Resources["Mnenomics"];
            var d = Application.Current.Resources["USER_ID"].ToString();
            var cID = Application.Current.Resources["CurID"].ToString();

            using(var db = new CursachContext())
            {
                var tokens = db.CurrencyList.Where(x => x.IdCurrency == Convert.ToInt32(cID)).FirstOrDefault();
                var Tok = db.Tokens.Where(x => x.IdWallet == Convert.ToInt32(d)).Where(x => x.IdCurrency == Convert.ToInt32(cID)).FirstOrDefault();
                Site.Text = tokens.TokenSite;
                Explorer.Text = tokens.ExplorerSite;
                TokenName.Text = tokens.Abbrecitation;
                IDAddress.Text = Tok.Adres;
                QRcodeGenerate(Tok.Adres);
            }
            

        }

        public void QRcodeGenerate(string key)
        {
            var Qg = new QRCodeGenerator();
            var qRCodeData = Qg.CreateQrCode(key, QRCodeGenerator.ECCLevel.M);
            var qRCode = new QRCode(qRCodeData);
            var qrCodeImage = qRCode.GetGraphic(50);

            pictureBox.Source = BitmapToImageSourse(qrCodeImage);
        }

        private ImageSource BitmapToImageSourse(Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }

        private void Close_Window(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void CopyInBufer(object sender, RoutedEventArgs e)
        {
            System.Windows.Clipboard.SetText(IDAddress.Text);
            System.Windows.MessageBox.Show("Скопировано в буфер обмена");
        }
    }
}
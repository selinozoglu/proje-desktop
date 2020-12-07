using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.IO;

namespace uygulama11
{
    /// <summary>
    /// Interaction logic for seviye3Window.xaml
    /// </summary>
    public partial class seviye3Window : Window
    {
        public static bool dolarSecildiMi;
        public static bool euroSecildiMi;
        public static bool digerSecildiMi;
        public static bool alakasizSecildiMi;
        public seviye3Window()
        {
            InitializeComponent();
        }
        public void DosyaYaz(string path, string konu)
        {
            List<string> temizTweet = new List<string>();
            temizTweet.Add(MainWindow.seciliTweet.ToString());

            FileStream dosya = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(dosya);
            for (int i = 0; i < temizTweet.Count; i++)
                sw.WriteLine(temizTweet[i].ToString() + konu);
            sw.Close();
            dosya.Close();
        }

        private void BtnDolar_Click(object sender, RoutedEventArgs e)
        {
            dolarSecildiMi = true;
            DosyaYaz("Doviz-Dolar.txt", "Doviz_Dolar");
            seviye2Window seviye2 = new seviye2Window();
            seviye2.ShowDialog();
            this.Close();
        }

        private void BtnEuro_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.DovizTıklandıMı = true;
            euroSecildiMi = true;
            DosyaYaz("Doviz_Euro.txt", "Doviz_Euro");
            seviye2Window seviye2 = new seviye2Window();
            seviye2.ShowDialog();
            this.Close();
        }

        private void BtnDiger_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.DovizTıklandıMı = true;
            digerSecildiMi = true;
            DosyaYaz("Doviz_Diger.txt", "Doviz_Diger");
            seviye2Window seviye2 = new seviye2Window();
            seviye2.ShowDialog();
            if (seviye2Window.olumluTıklandıMı == true)
            {
                DosyaYaz("DovizDigerrOlumlu.txt", "Doviz_Diger_Olumlu");
            }
            if (seviye2Window.olumsuzTıklandıMı == true)
            {
                DosyaYaz("DovizDigerOlumsuz.txt", "Doviz_Diger_Olumsuz");
            }
            if (seviye2Window.tarafsizTıklandıMı == true)
            {
                DosyaYaz("DovizDigerTarafsiz.txt", "Doviz_Diger_Tarafsiz");
            }
            if (seviye2Window.alakasizTıklandıMı == true)
            {
                DosyaYaz("DovizDigerAlakasiz.txt", "Doviz_Diger_Alakasiz");
            }
            this.Close();
        }

        private void BtnAlakasız_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.DovizTıklandıMı = true;
            alakasizSecildiMi = true;
            DosyaYaz("Doviz_Alakasiz.txt", "Doviz_Alakasiz");
            this.Close();
        }
    }
}

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
using System.Text.RegularExpressions;

namespace uygulama11
{
    /// <summary>
    /// Interaction logic for seviye2Window.xaml
    /// </summary>
    public partial class seviye2Window : Window
    {
        public static bool olumluTıklandıMı; 
        public static bool olumsuzTıklandıMı; 
        public static bool tarafsizTıklandıMı; 
        public static bool alakasizTıklandıMı;
        public seviye2Window()
        {
            InitializeComponent();
        }
        MainWindow mainWindow = new MainWindow();
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
        public void BtnOlumlu_Click(object sender, RoutedEventArgs e)
        {
            olumluTıklandıMı = true;

            if(MainWindow.AltinTıklandıMı == true){
                DosyaYaz("AltınOlumlu.txt", "Altin_Olumlu");
            }
            if (MainWindow.BorsaTıklandıMı == true)
            {
                DosyaYaz("BorsaOlumlu.txt", "Borsa_Olumlu");
            }
            if (MainWindow.EkonomiTıklandıMı == true)
            {
                DosyaYaz("EkonomiOlumlu.txt", "Ekonomi_Olumlu");
            }
            if (MainWindow.EnflasyonTıklandıMı == true)
            {
                DosyaYaz("EnflasyonOlumlu.txt", "Enflasyon_Olumlu");
            }
            if (seviye3Window.euroSecildiMi == true )
            {
                DosyaYaz("DovizEuroOlumlu.txt", "Doviz_Euro_Olumlu");
            }
            if (seviye3Window.dolarSecildiMi == true)
            {
                DosyaYaz("DovizDolarOlumlu.txt", "Doviz_Dolar_Olumlu");
            }
            if (seviye3Window.digerSecildiMi == true)
            {
                DosyaYaz("DovizDigerOlumlu.txt", "Doviz_Diger_Olumlu");
            }
            this.Close();

        }

        private void BtnOlumsuz_Click(object sender, RoutedEventArgs e)
        {
            olumsuzTıklandıMı = true;

            if (MainWindow.AltinTıklandıMı == true)
            {
                DosyaYaz("AltınOlumsuz.txt", "Altin_Olumsuz");
            }
            if (MainWindow.BorsaTıklandıMı == true)
            {
                DosyaYaz("BorsaOlumsuz.txt", "Borsa_Olumsuz");
            }
            if (MainWindow.EkonomiTıklandıMı == true)
            {
                DosyaYaz("EkonomiOlumsuz.txt", "Ekonomi_Olumsuz");
            }
            if (MainWindow.EnflasyonTıklandıMı == true)
            {
                DosyaYaz("EnflasyonOlumsuz.txt", "Enflasyon_Olumsuz");
            }
            this.Close();
        }

        private void BtnAlakasız_Click(object sender, RoutedEventArgs e)
        {
            alakasizTıklandıMı = true;

            if (MainWindow.AltinTıklandıMı == true)
            {
                DosyaYaz("AltınAlakasız.txt", "Altin_Alakasiz");
            }
            if (MainWindow.BorsaTıklandıMı == true)
            {
                DosyaYaz("BorsaAlakasız.txt", "Borsa_Alakasiz");
            }
            if (MainWindow.EkonomiTıklandıMı == true)
            {
                DosyaYaz("EkonomiAlakasız.txt", "Ekonomi_Alakasiz");
            }
            if (MainWindow.EnflasyonTıklandıMı == true)
            {
                DosyaYaz("EnflasyonAlakasız.txt", "Enflasyon_Alakasiz");
            }
            this.Close();
        }

        private void BtnTarafsiz_Click(object sender, RoutedEventArgs e)
        {
            tarafsizTıklandıMı = true;
            if (MainWindow.AltinTıklandıMı == true)
            {
                DosyaYaz("AltınTarafsız.txt", "Altin_Tarafsiz");
            }
            if (MainWindow.BorsaTıklandıMı == true)
            {
                DosyaYaz("BorsaTarafsız.txt", "Borsa_Tarafsiz");
            }
            if (MainWindow.EkonomiTıklandıMı == true)
            {
                DosyaYaz("EkonomiTarafsız.txt", "Ekonomi_Tarafsiz");
            }
            if (MainWindow.EnflasyonTıklandıMı == true)
            {
                DosyaYaz("EnflasyonTarafsız.txt", "Enflasyon_Tarafsiz");
            }
            this.Close();
        }
    }
        
}

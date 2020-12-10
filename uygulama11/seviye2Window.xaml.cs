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
        MainWindow mainWindow = new MainWindow();
        
        public static bool olumluTiklandiMi; 
        public static bool olumsuzTiklandiMi; 
        public static bool tarafsizTiklandiMi; 
        public static bool alakasizTiklandiMi;
        
        public seviye2Window(MainWindow nmain)
        {
            mainWindow = nmain;
            
            InitializeComponent();
            
        }
        public void BtnOlumlu_Click(object sender, RoutedEventArgs e)
        { 
            olumluTiklandiMi = true;
            MainWindow.KucukHarfeCevrilsinMi = true;
            if (MainWindow.AltinTiklandiMi == true && MainWindow.BorsaTiklandiMi == false
                && MainWindow.EkonomiTiklandiMi == false &&
                MainWindow.EnflasyonTiklandiMi == false)
            {
                mainWindow.DosyaYaz("AltinOlumlu.txt", " Altin_Olumlu");
                
                if(MainWindow.KucukHarfeCevrilsinMi == true)
                {
                    mainWindow.KucukHarfeCevir();
                    mainWindow.DosyaYaz("TekKatmanKucukHarf.txt", "Altin_Olumlu");
                }
                MessageBox.Show(MainWindow.seciliTweet);                 
            }
            else if(MainWindow.BorsaTiklandiMi == true && MainWindow.AltinTiklandiMi == false
                && MainWindow.EkonomiTiklandiMi == false && 
                MainWindow.EnflasyonTiklandiMi == false)
            {
                mainWindow.DosyaYaz("BorsaOlumlu.txt", " Borsa_Olumlu");
            }
            
            if (MainWindow.EkonomiTiklandiMi == true && MainWindow.BorsaTiklandiMi == false 
                && MainWindow.AltinTiklandiMi == false
              && MainWindow.EnflasyonTiklandiMi == false)
            {
                mainWindow.DosyaYaz("EkonomiOlumlu.txt", " Ekonomi_Olumlu");
            }
            if (MainWindow.EnflasyonTiklandiMi == true && MainWindow.BorsaTiklandiMi == false 
                && MainWindow.AltinTiklandiMi == false
                && MainWindow.EkonomiTiklandiMi == false )
            {
                mainWindow.DosyaYaz("EnflasyonOlumlu.txt", " Enflasyon_Olumlu");
            }
            if (seviye3Window.euroTiklandiMi == true && seviye3Window.dolarTiklandiMi == false 
                && seviye3Window.digerTiklandiMi == false && MainWindow.DovizTiklandiMi == true)
            {
                mainWindow.DosyaYaz("DovizEuroOlumlu.txt", " Doviz_Euro_Olumlu");
            }
            if (seviye3Window.euroTiklandiMi == false && seviye3Window.dolarTiklandiMi == true
                && seviye3Window.digerTiklandiMi == false && MainWindow.DovizTiklandiMi == true)
            {
                mainWindow.DosyaYaz("DovizDolarOlumlu.txt", " Doviz_Dolar_Olumlu");
            }
            if (seviye3Window.euroTiklandiMi == false && seviye3Window.dolarTiklandiMi == false
                && seviye3Window.digerTiklandiMi == true && MainWindow.DovizTiklandiMi == true)
            {
                mainWindow.DosyaYaz("DovizDigerOlumlu.txt", " Doviz_Diger_Olumlu");
            }
            this.Hide();

        }

        private void BtnOlumsuz_Click(object sender, RoutedEventArgs e)
        {
            olumsuzTiklandiMi = true;

            if (MainWindow.AltinTiklandiMi == true && MainWindow.BorsaTiklandiMi == false
                && MainWindow.EkonomiTiklandiMi == false &&
                MainWindow.EnflasyonTiklandiMi == false)
            {
                mainWindow.DosyaYaz("AltinOlumsuz.txt", " Altin_Olumsuz");
            }
            else if (MainWindow.BorsaTiklandiMi == true && MainWindow.AltinTiklandiMi == false
                && MainWindow.EkonomiTiklandiMi == false &&
                MainWindow.EnflasyonTiklandiMi == false)
            {
                mainWindow.DosyaYaz("BorsaOlumsuz.txt", " Borsa_Olumsuz");
            }
            else if (MainWindow.EkonomiTiklandiMi == true && MainWindow.BorsaTiklandiMi == false
                && MainWindow.AltinTiklandiMi == false
              && MainWindow.EnflasyonTiklandiMi == false)
            {
                mainWindow.DosyaYaz("EkonomiOlumsuz.txt", " Ekonomi_Olumsuz");
            }
            else if (MainWindow.EnflasyonTiklandiMi == true && MainWindow.BorsaTiklandiMi == false
                && MainWindow.AltinTiklandiMi == false
                && MainWindow.EkonomiTiklandiMi == false)
            {
                mainWindow.DosyaYaz("EnflasyonOlumsuz.txt", " Enflasyon_Olumsuz");
            }
            else if (seviye3Window.euroTiklandiMi == false && seviye3Window.dolarTiklandiMi == true
                && seviye3Window.digerTiklandiMi == false && MainWindow.DovizTiklandiMi == true)
            {
                mainWindow.DosyaYaz("DovizDolarOlumsuz.txt", " Doviz_Dolar_Olumsuz");
            }
            else if (seviye3Window.euroTiklandiMi == true && seviye3Window.dolarTiklandiMi == false
                && seviye3Window.digerTiklandiMi == false && MainWindow.DovizTiklandiMi == true)
            {
                mainWindow.DosyaYaz("DovizEuroOlumsuz.txt", " Doviz_Euro_Olumsuz");
            }
            else if (seviye3Window.euroTiklandiMi == false && seviye3Window.dolarTiklandiMi == false
                && seviye3Window.digerTiklandiMi == true && MainWindow.DovizTiklandiMi == true)
            {
                mainWindow.DosyaYaz("DovizDigerOlumsuz.txt", " Doviz_Diger_Olumsuz");
            }
            this.Close();
        }

        private void BtnAlakasiz_Click(object sender, RoutedEventArgs e)
        {
            alakasizTiklandiMi = true;

            if (MainWindow.AltinTiklandiMi == true && MainWindow.BorsaTiklandiMi == false
                && MainWindow.EkonomiTiklandiMi == false &&
                MainWindow.EnflasyonTiklandiMi == false)
            {
                mainWindow.DosyaYaz("AltinAlakasız.txt", " Altin_Alakasiz");
            }
            else if (MainWindow.BorsaTiklandiMi == true && MainWindow.AltinTiklandiMi == false
                && MainWindow.EkonomiTiklandiMi == false &&
                MainWindow.EnflasyonTiklandiMi == false)
            {
                mainWindow.DosyaYaz("BorsaAlakasız.txt", " Borsa_Alakasiz");
            }
            else if (MainWindow.EkonomiTiklandiMi == true && MainWindow.BorsaTiklandiMi == false
                && MainWindow.AltinTiklandiMi == false
              && MainWindow.EnflasyonTiklandiMi == false)
            {
                mainWindow.DosyaYaz("EkonomiAlakasız.txt", " Ekonomi_Alakasiz");
            }
            else if (MainWindow.EnflasyonTiklandiMi == true && MainWindow.BorsaTiklandiMi == false
                && MainWindow.AltinTiklandiMi == false
                && MainWindow.EkonomiTiklandiMi == false)
            {
                mainWindow.DosyaYaz("EnflasyonAlakasız.txt", " Enflasyon_Alakasiz");
            }
            else if (seviye3Window.euroTiklandiMi == false && seviye3Window.dolarTiklandiMi == true
                && seviye3Window.digerTiklandiMi == false && MainWindow.DovizTiklandiMi == true)
            {
                mainWindow.DosyaYaz("DovizDolarAlakasiz.txt", " Doviz_Dolar_Alakasiz");
            }
            else if (seviye3Window.euroTiklandiMi == true && seviye3Window.dolarTiklandiMi == false
                && seviye3Window.digerTiklandiMi == false && MainWindow.DovizTiklandiMi == true)
            {
                mainWindow.DosyaYaz("DovizEuroAlakasiz.txt", " Doviz_Euro_Alakasiz");
            }
            else if (seviye3Window.euroTiklandiMi == false && seviye3Window.dolarTiklandiMi == false
                && seviye3Window.digerTiklandiMi == true && MainWindow.DovizTiklandiMi == true)
            {
                mainWindow.DosyaYaz("DovizDigerAlakasiz.txt", " Doviz_Diger_Alakasiz");
            }
            this.Close();
        }

        private void BtnTarafsiz_Click(object sender, RoutedEventArgs e)
        {
            tarafsizTiklandiMi = true;
            
            if (MainWindow.AltinTiklandiMi == true && MainWindow.BorsaTiklandiMi == false
                && MainWindow.EkonomiTiklandiMi == false &&
                MainWindow.EnflasyonTiklandiMi == false)
            {
                mainWindow.DosyaYaz("AltinTarafsız.txt", " Altin_Tarafsiz");
            }
            else if (MainWindow.BorsaTiklandiMi == true && MainWindow.AltinTiklandiMi == false
                && MainWindow.EkonomiTiklandiMi == false &&
                MainWindow.EnflasyonTiklandiMi == false)
            {
                mainWindow.DosyaYaz("BorsaTarafsız.txt", " Borsa_Tarafsiz");
            }
            else if (MainWindow.EkonomiTiklandiMi == true && MainWindow.BorsaTiklandiMi == false
                && MainWindow.AltinTiklandiMi == false
              && MainWindow.EnflasyonTiklandiMi == false)
            {
                mainWindow.DosyaYaz("EkonomiTarafsız.txt", " Ekonomi_Tarafsiz");
            }
            else if (MainWindow.EnflasyonTiklandiMi == true && MainWindow.BorsaTiklandiMi == false
                && MainWindow.AltinTiklandiMi == false
                && MainWindow.EkonomiTiklandiMi == false)
            {
                mainWindow.DosyaYaz("EnflasyonTarafsız.txt", " Enflasyon_Tarafsiz");
            }
            else if (seviye3Window.euroTiklandiMi == false && seviye3Window.dolarTiklandiMi == true
                && seviye3Window.digerTiklandiMi == false && MainWindow.DovizTiklandiMi == true)
            {
                mainWindow.DosyaYaz("DovizDolarTarafsiz.txt", " Doviz_Dolar_Tarafsiz");
            }
            else if (seviye3Window.euroTiklandiMi == true && seviye3Window.dolarTiklandiMi == false
                && seviye3Window.digerTiklandiMi == false && MainWindow.DovizTiklandiMi == true)
            {
                mainWindow.DosyaYaz("DovizEuroTarafsiz.txt", " Doviz_Euro_Tarafsiz");
            }
            else if (seviye3Window.euroTiklandiMi == false && seviye3Window.dolarTiklandiMi == false
                && seviye3Window.digerTiklandiMi == true && MainWindow.DovizTiklandiMi == true)
            {
                mainWindow.DosyaYaz("DovizDigerTarafsiz.txt", " Doviz_Diger_Tarafsiz");
            }
            this.Close();
        }
    }
        
}

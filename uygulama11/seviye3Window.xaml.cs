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
        MainWindow mainWindow = new MainWindow();
        public static bool dolarTiklandiMi;
        public static bool euroTiklandiMi;
        public static bool digerTiklandiMi;
        public static bool alakasizTiklandiMi;
        public seviye3Window(MainWindow m)
        {
            mainWindow = m;
            InitializeComponent();
        }

        private void BtnDolar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.DovizTiklandiMi = true;
            dolarTiklandiMi = true;
            alakasizTiklandiMi = false;
            digerTiklandiMi = false;
            euroTiklandiMi = false;
            mainWindow.DosyaYaz("Doviz-Dolar.txt", "Doviz_Dolar");
            seviye2Window seviye2 = new seviye2Window(mainWindow);
            seviye2.ShowDialog();
            this.Close();
        }

        private void BtnEuro_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.DovizTiklandiMi = true;
            euroTiklandiMi = true;
            alakasizTiklandiMi = false;
            digerTiklandiMi = false;
            dolarTiklandiMi = false;
            mainWindow.DosyaYaz("Doviz_Euro.txt", "Doviz_Euro");
            seviye2Window seviye2 = new seviye2Window(mainWindow);
            seviye2.ShowDialog();
            this.Close();
        }

        private void BtnDiger_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.DovizTiklandiMi = true;
            digerTiklandiMi = true;
            alakasizTiklandiMi = false;
            euroTiklandiMi = false;
            dolarTiklandiMi = false;
            mainWindow.DosyaYaz("Doviz_Diger.txt", "Doviz_Diger");
            seviye2Window seviye2 = new seviye2Window(mainWindow);
            seviye2.ShowDialog();
            this.Close();
        }

        private void BtnAlakasız_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.DovizTiklandiMi = true;
            alakasizTiklandiMi = true;
            digerTiklandiMi = false;
            euroTiklandiMi = false;
            dolarTiklandiMi = false;
            mainWindow.DosyaYaz("Doviz_Alakasiz.txt", "Doviz_Alakasiz");
            this.Close();
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using Microsoft.Win32;
using System.Data.OleDb;
using System.Data;
using net.zemberek.erisim;
using net.zemberek.yapi;
using net.zemberek.tr.yapi;
using net.zemberek.islemler.cozumleme;
using net.zemberek.araclar.turkce;
using net.zemberek.bilgi.kokler;
using net.zemberek.tr.yapi.kok;
using net.zemberek.tr.yapi.ek;

namespace uygulama11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string seciliTweet;
        public static bool AltinTıklandıMı;
        public static bool BorsaTıklandıMı;
        public static bool DovizTıklandıMı;
        public static bool EkonomiTıklandıMı;
        public static bool EnflasyonTıklandıMı;
      
        public MainWindow()
        {
            InitializeComponent();
        }
        
        public void DosyaYaz(string path, string konu)
        {
            if (!(listBox1.Items.IsEmpty) && !(listBox1.SelectedItem.Equals(null)))
            {
                List<string> temizTweet = new List<string>();
                temizTweet.Add(listBox1.SelectedItem.ToString());

                FileStream dosya = new FileStream(path, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(dosya);
                for (int i = 0; i < temizTweet.Count; i++)
                    sw.WriteLine(temizTweet[i].ToString() + konu);
                int secim = listBox1.SelectedIndex;
                if (secim != -1)
                {
                    //listBox1.Items.RemoveAt(secim);
                }
                sw.Close();
                dosya.Close();
            }
        }
        
       /* public void KucukHarfeCevir(string konu)
        {
            seciliTweet = listBox1.SelectedItem.ToString().ToLower();
            MessageBox.Show(listBox1.SelectedItem.ToString());
            MessageBox.Show(listBox1.SelectedItem.ToString().ToLower());
            DosyaYaz("kucukharfecevrilmisHamTweet.txt", konu);
        }*/
        private void BtnTemizle_Click(object sender, RoutedEventArgs e)
        {
            string tweetler = TbTweet.Text;
            tweetler = tweetler.ToLower();//büyük harfi küçük harfe çevirme
            tweetler = Regex.Replace(tweetler, @"[0-9\-]"," ");//sayıları silme
            tweetler = Regex.Replace(tweetler, @"((http|https)://[\w-]+(.[\w-]+)+([\w-.,@?^=%&amp;:/~+#]*[\w-@?^=%&amp;/~+#])?)", string.Empty);
            char hashtag = '#';
            tweetler = tweetler.Replace(hashtag, ' ');//hashtag silme
            //tweetler = Regex.Replace(tweetler, @"[^\u0000-\u007F]+", string.Empty);//emoji silme türkçe karakterler de gidiyor düzelt

            var sonuc = Regex.Split(tweetler, @"\r\n|\r\n");//her satırı ayrı sonuç olarak alma
            foreach (string s in sonuc)
            {
                listBox1.Items.Add(s);
            }
            //TbTweet.Clear();
        }
        
        private void BtnAltin_Click(object sender, RoutedEventArgs e)
        {
            AltinTıklandıMı = true;
            seciliTweet = listBox1.SelectedItem.ToString();
            DosyaYaz("Altin.txt", " Altin");
            seviye2Window seviye2 = new seviye2Window();
            //KucukHarfeCevir("Altin");

            seviye2.ShowDialog();
        }
        private void BtnBorsa_Click(object sender, RoutedEventArgs e)
        {
            BorsaTıklandıMı = true;
            seciliTweet = listBox1.SelectedItem.ToString();
            DosyaYaz("Borsa.txt", " Borsa");
            seviye2Window seviye2 = new seviye2Window();
            seviye2.ShowDialog();
        }

        private void BtnDoviz_Click(object sender, RoutedEventArgs e)
        {
            DovizTıklandıMı = true;
            seciliTweet = listBox1.SelectedItem.ToString();
            DosyaYaz("Doviz.txt", " Doviz");
            seviye3Window seviye3 = new seviye3Window();
            seviye3.ShowDialog();
        }

        private void BtnEkonomi_Click(object sender, RoutedEventArgs e)
        {
            EkonomiTıklandıMı = true;
            seciliTweet = listBox1.SelectedItem.ToString();
            //KucukHarfeCevir("ekonomi");
            DosyaYaz("Ekonomi.txt", " ,Ekonomi");
            seviye2Window seviye2 = new seviye2Window();
            seviye2.ShowDialog();
        }

        private void BtnEnflasyon_Click(object sender, RoutedEventArgs e)
        {
            EnflasyonTıklandıMı = true;
            seciliTweet = listBox1.SelectedItem.ToString();
            DosyaYaz("Enflasyon.txt", " Enflasyon");
            seviye2Window seviye2 = new seviye2Window();
            seviye2.ShowDialog();
        }


        private void BtnTweetSil_Click_1(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }
    }
}

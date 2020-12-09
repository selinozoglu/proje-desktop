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
    ///
    
    public partial class MainWindow : Window
    {
       
        public static string seciliTweet;
        public static bool AltinTiklandiMi;
        public static bool BorsaTiklandiMi;
        public static bool DovizTiklandiMi;
        public static bool EkonomiTiklandiMi;
        public static bool EnflasyonTiklandiMi;

        

        public MainWindow()
        {
            InitializeComponent();
           
        }
        static class StopwordTool
        {
            /// <summary>
            /// Words we want to remove.
            /// </summary>
            static Dictionary<string, bool> _stops = new Dictionary<string, bool>
    {
        { "a", true },
        { "aa", true },
        { "aaa", true },
        { "ve", true },
        { "ama", true },
        { "abe", true },
        { "abes", true },
        { "abo", true },
        { "acaba", true },
        { "acayip", true },
        { "acele", true },
        { "aceleten", true },
        { "acep", true },
        { "acımasız", true },
        { "acımasızcasına", true },
        { "acilen", true },
        { "âciz", true },
        { "âcizane", true },
        { "aç", true },
        { "açık", true },
        { "açıkçası", true },
        { "açıktan", true },
        { "adamakıllı", true },
        { "adamcasına", true },
        { "adedî", true },
        { "âdeta", true },
        { "adına", true },
        { "adilane", true },
        { "afedersin", true },
        { "aferin", true },
        { "agucuk", true },
        { "ağababa", true },
        { "ağabey", true },
        { "ağır", true },
        { "ağızdan", true },
        { "ah", true },
        { "aha", true },
        { "ahacık", true },
        { "ahbap", true },
        { "aheste", true },
        { "ahir", true },
        { "ahiren", true },
        { "ahlaken", true },
        { "ailecek", true },
        { "ait", true },
        { "akabinde", true },
        { "akıbet", true },
        { "maalesef", true },
        { "galiba", true }
    };

            /// <summary>
            /// Chars that separate words.
            /// </summary>
            static char[] _delimiters = new char[]
            {
        ' ',
        ',',
        ';',
        '.'
            };

            /// <summary>
            /// Remove stopwords from string.
            /// </summary>
            public static string RemoveStopwords(string input)
            {
                // 1
                // Split parameter into words
                var words = input.Split(_delimiters,
                    StringSplitOptions.RemoveEmptyEntries);
                // 2
                // Allocate new dictionary to store found words
                var found = new Dictionary<string, bool>();
                // 3
                // Store results in this StringBuilder
                StringBuilder builder = new StringBuilder();
                // 4
                // Loop through all words
                foreach (string currentWord in words)
                {
                    // 5
                    // Convert to lowercase
                    string lowerWord = currentWord.ToLower();
                    // 6
                    // If this is a usable word, add it
                    if (!_stops.ContainsKey(lowerWord) &&
                        !found.ContainsKey(lowerWord))
                    {
                        builder.Append(currentWord).Append(' ');
                        found.Add(lowerWord, true);
                    }
                }
                // 7
                // Return string with words removed
                return builder.ToString().Trim();
            }
        }

        public void DosyaYaz(string path, string konu)
        {
            if (!(listBox1.Items.IsEmpty) && !(listBox1.SelectedItem.Equals(null)))
            {
                seciliTweet = listBox1.SelectedItem.ToString();
                List<string> temizTweet = new List<string>();
                temizTweet.Add(seciliTweet);

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
            else MessageBox.Show("listeden eleman seçilmedi");
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
            tweetler = Regex.Replace(tweetler, @"[0-9\-]", " ");//sayıları silme
            tweetler = Regex.Replace(tweetler, @"((http|https)://[\w-]+(.[\w-]+)+([\w-.,@?^=%&amp;:/+#]*[\w-@?^=%&amp;/+#])?)", string.Empty);
            char hashtag = '#';
            tweetler = tweetler.Replace(hashtag, ' ');//hashtag silme
                                                      //tweetler = Regex.Replace(tweetler, @"[^\u0000-\u007F]+", string.Empty);//emoji silme türkçe karakterler de gidiyor düzelt


            /*foreach (string s in findStopWords)
            {
                listBox1.Items.Add(s);
            }*/




            var stopWords = StopwordTool.RemoveStopwords(tweetler);
            var sonuc = Regex.Split(stopWords, @"\r\n|\r\n");//her satırı ayrı sonuç olarak alma
            foreach (string s in sonuc)
            {
                listBox1.Items.Add(s);
            }
            //TbTweet.Clear();
        }

        private void BtnAltin_Click(object sender, RoutedEventArgs e)
        {
            AltinTiklandiMi = true;
            BorsaTiklandiMi = false;
            DovizTiklandiMi = false;
            EkonomiTiklandiMi = false;
            EnflasyonTiklandiMi = false;
        seviye2Window seviye2 = new seviye2Window(this);
            DosyaYaz("Altin.txt", " Altin");
            DosyaYaz("TemizTweet.txt", " Altin");
            seviye2.ShowDialog();
        }
        private void BtnBorsa_Click(object sender, RoutedEventArgs e)
        {
            BorsaTiklandiMi = true;
            AltinTiklandiMi = false;
            DovizTiklandiMi = false;
            EkonomiTiklandiMi = false;
            EnflasyonTiklandiMi = false;
            seviye2Window seviye2 = new seviye2Window(this);
            // seciliTweet = listBox1.SelectedItem.ToString();
            DosyaYaz("Borsa.txt", " Borsa");
            DosyaYaz("TemizTweet.txt", " Borsa");

            seviye2.ShowDialog();
        }

        private void BtnDoviz_Click(object sender, RoutedEventArgs e)
        {
            DovizTiklandiMi = true;
            BorsaTiklandiMi = false;
            AltinTiklandiMi = false;
            EkonomiTiklandiMi = false;
            EnflasyonTiklandiMi = false;
            DosyaYaz("Doviz.txt", " Doviz");
            DosyaYaz("TemizTweet.txt", " Doviz");
            seviye3Window seviye3 = new seviye3Window(this);
            seviye3.ShowDialog();
        }

        private void BtnEkonomi_Click(object sender, RoutedEventArgs e)
        {
            EkonomiTiklandiMi = true;
            BorsaTiklandiMi = false;
            AltinTiklandiMi = false;
            DovizTiklandiMi = false;
            EnflasyonTiklandiMi = false;
            //seciliTweet = listBox1.SelectedItem.ToString();
            seviye2Window seviye2 = new seviye2Window(this);
            //KucukHarfeCevir("ekonomi");
            DosyaYaz("Ekonomi.txt", " Ekonomi");
            DosyaYaz("TemizTweet.txt", " Ekonomi");
            //seviye2Window seviye2 = new seviye2Window();
            seviye2.ShowDialog();
        }

        private void BtnEnflasyon_Click(object sender, RoutedEventArgs e)
        {
            EnflasyonTiklandiMi = true;
            BorsaTiklandiMi = false;
            AltinTiklandiMi = false;
            DovizTiklandiMi = false;
            EkonomiTiklandiMi = false;
            //seciliTweet = listBox1.SelectedItem.ToString();
            DosyaYaz("Enflasyon.txt", " Enflasyon");
            DosyaYaz("TemizTweet.txt", " Enflasyon");
            seviye2Window seviye2 = new seviye2Window(this);
            //seviye2Window seviye2 = new seviye2Window();
            seviye2.ShowDialog();
        }


        private void BtnTweetSil_Click_1(object sender, RoutedEventArgs e)
        {
            if (!(listBox1.Items.IsEmpty) && !(listBox1.SelectedItem.Equals(null)))
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
            else MessageBox.Show("listeden eleman seçilmedi");
        }
    }
}

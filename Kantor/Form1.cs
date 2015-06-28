using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Kantor
{
    public partial class Kantor : Form
    {
        public Kantor()
        {
            InitializeComponent();
        }

        //okon pomocy
        private void pomoc_Click(object sender, EventArgs e)
        {
            Form okno_pomocy = new Form();
            okno_pomocy.Text = "Pomoc";
            okno_pomocy.Size = new Size(320, 250);
            okno_pomocy.MaximumSize = new Size(320, 250);
            okno_pomocy.MinimumSize = new Size(320, 250);
            okno_pomocy.MaximizeBox = false;
            okno_pomocy.MinimizeBox = false;

            //opis
            Label opis = new Label();
            opis.Location = new Point(70, 50);
            opis.Size = new Size(300, 80);
            opis.Text = "Aplikacja, której celem jest\nprzelicznie oraz sprawdzanie\naktualnego kursu walut.\nDane będą pobierane ze strony:\nkursy-walut.mybank.pl";
            okno_pomocy.Controls.Add(opis);

            //oprogramowanie przycisku
            Button zamknij = new Button();
            zamknij.Location = new Point(100, 150);
            zamknij.Size = new Size(100, 40);
            zamknij.Text = "OK";
            zamknij.DialogResult = System.Windows.Forms.DialogResult.OK;//zamykanie okna pomocy
            okno_pomocy.Controls.Add(zamknij);

            okno_pomocy.ShowDialog();

        }

        private void licz_Click(object sender, EventArgs e)
        {
            
            Form okno_liczenia = new Form();
            okno_liczenia.Size = new Size(350, 300);
            okno_liczenia.MaximumSize = new Size(350, 300);
            okno_liczenia.MinimumSize = new Size(350, 300);
            okno_liczenia.MaximizeBox = false;
            okno_liczenia.MinimizeBox = false;
            okno_liczenia.Text = "Przelicznik";

            //mijesce na dane do przeliczenia
            TextBox dane = new TextBox();
            dane.Location = new Point(340 / 2, 300 / 2);
            dane.Size = new Size(150, 100);
            okno_liczenia.Controls.Add(dane);
            //
            //opis miejsca na dane
            Label opis_dane = new Label();
            opis_dane.Location = new Point((340 / 2), (300 / 2)-20);
            opis_dane.Text = "wpisz kwotę:";
            okno_liczenia.Controls.Add(opis_dane);

            //miejsce na rodzaj waluty
            TextBox waluta = new TextBox();
            waluta.Location = new Point((340/2)-150, 300/2);
            waluta.Size = new Size(100, 100);
            okno_liczenia.Controls.Add(waluta);
            //
            //opis wybranej waluty
            Label opis_waluta= new Label();
            opis_waluta.Location = new Point((340 / 2)-150, (300 / 2) - 30);
            opis_waluta.Size = new Size(100, 100);
            opis_waluta.Text = "wpisz walutę: (np. PLN)";
            okno_liczenia.Controls.Add(opis_waluta);

            //przycisk przeliczający
            Button liczenie = new Button();
            liczenie.Size = new Size(100, 50);
            liczenie.Location = new Point(350 / 2, 200);
            liczenie.Text = "przelicz";
            okno_liczenia.Controls.Add(liczenie);

            //zwracanie wartości przez okno dialogowe
            liczenie.DialogResult = System.Windows.Forms.DialogResult.OK;


            okno_liczenia.ShowDialog();

            if (waluta.Text == "PLN") {
                //wyświetlanie danych
                wyb_wal.Text = waluta.Text;
                przel_PLN.Text = dane.Text;
                //przeliczanie danych
                przel_USD.Text = ((Double.Parse(dane.Text))/(Double.Parse(kurs_dolara.Text))).ToString();
                przel_EUR.Text = ((Double.Parse(dane.Text))/(Double.Parse(kurs_euro.Text))).ToString();
                przel_frank.Text = ((Double.Parse(dane.Text)) / (Double.Parse(kurs_frank.Text))).ToString();
                przel_funt.Text = ((Double.Parse(dane.Text))/(Double.Parse(kurs_funt.Text))).ToString();
                przel_jen.Text = ((Double.Parse(dane.Text))/(Double.Parse(kurs_jen.Text))).ToString();
                przel_kor_szwe.Text = ((Double.Parse(dane.Text))/(Double.Parse(kurs_kor.Text))).ToString();
                przel_ren_chiny.Text = ((Double.Parse(dane.Text))/(Double.Parse(kurs_ren_chiny.Text))).ToString();
                przel_RUB.Text = ((Double.Parse(dane.Text))/(Double.Parse(kurs_rubel.Text))).ToString();
            } 
            else if (waluta.Text == "USD")
            {
                //wyświetlanie danych
                wyb_wal.Text = waluta.Text;
                przel_USD.Text = dane.Text;
                //przeliczanie danych
                przel_PLN.Text = ((Double.Parse(dane.Text))*(Double.Parse(kurs_dolara.Text))).ToString();
                przel_EUR.Text = ((Double.Parse(przel_PLN.Text))/(Double.Parse(kurs_euro.Text))).ToString();
                przel_frank.Text = ((Double.Parse(przel_PLN.Text))/(Double.Parse(kurs_frank.Text))).ToString();
                przel_funt.Text = ((Double.Parse(przel_PLN.Text))/(Double.Parse(kurs_funt.Text))).ToString();
                przel_jen.Text = ((Double.Parse(przel_PLN.Text))/(Double.Parse(kurs_jen.Text))).ToString();
                przel_kor_szwe.Text = ((Double.Parse(przel_PLN.Text))/(Double.Parse(kurs_kor.Text))).ToString();
                przel_ren_chiny.Text = ((Double.Parse(przel_PLN.Text))/(Double.Parse(kurs_ren_chiny.Text))).ToString();
                przel_RUB.Text = ((Double.Parse(przel_PLN.Text))/(Double.Parse(kurs_rubel.Text))).ToString();
            }
            else if (waluta.Text == "EUR")
            {

                //wyświetlanie danych
                wyb_wal.Text = waluta.Text;
                przel_EUR.Text = dane.Text;
                //przeliczanie danych
                przel_PLN.Text = ((Double.Parse(dane.Text))*(Double.Parse(kurs_euro.Text))).ToString();
                przel_USD.Text = ((Double.Parse(przel_PLN.Text))/(Double.Parse(kurs_dolara.Text))).ToString();
                przel_frank.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_frank.Text))).ToString();
                przel_funt.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_funt.Text))).ToString();
                przel_jen.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_jen.Text))).ToString();
                przel_kor_szwe.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_kor.Text))).ToString();
                przel_ren_chiny.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_ren_chiny.Text))).ToString();
                przel_RUB.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_rubel.Text))).ToString();
            }
            else if (waluta.Text == "SEK")
            {
                //wyświetlanie danych
                wyb_wal.Text = waluta.Text;
                przel_kor_szwe.Text = dane.Text;
                //przeliczanie danych
                przel_PLN.Text = ((Double.Parse(dane.Text)) * (Double.Parse(kurs_kor.Text))).ToString();
                przel_ren_chiny.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_ren_chiny.Text))).ToString();
                przel_RUB.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_rubel.Text))).ToString();
                przel_USD.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_dolara.Text))).ToString();
                przel_frank.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_frank.Text))).ToString();
                przel_funt.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_funt.Text))).ToString();
                przel_jen.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_jen.Text))).ToString();
                przel_EUR.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_euro.Text))).ToString();
            }
            else if (waluta.Text == "GBP")
            {
                //wyświetlanie danych
                wyb_wal.Text = waluta.Text;
                przel_funt.Text = dane.Text;
                //przeliczanie danych
                przel_PLN.Text = ((Double.Parse(dane.Text)) * (Double.Parse(kurs_funt.Text))).ToString();
                przel_jen.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_jen.Text))).ToString();
                przel_EUR.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_euro.Text))).ToString();
                przel_ren_chiny.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_ren_chiny.Text))).ToString();
                przel_RUB.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_rubel.Text))).ToString();
                przel_USD.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_dolara.Text))).ToString();
                przel_frank.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_frank.Text))).ToString();
                przel_kor_szwe.Text = ((Double.Parse(przel_PLN.Text))/(Double.Parse(kurs_kor.Text))).ToString();
            }
            else if (waluta.Text == "CHF")
            {
                //wyświetlanie danych
                wyb_wal.Text = waluta.Text;
                przel_frank.Text = dane.Text;
                //przeliczanie danych
                przel_PLN.Text = ((Double.Parse(dane.Text)) * (Double.Parse(kurs_frank.Text))).ToString();
                przel_jen.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_jen.Text))).ToString();
                przel_EUR.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_euro.Text))).ToString();
                przel_ren_chiny.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_ren_chiny.Text))).ToString();
                przel_RUB.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_rubel.Text))).ToString();
                przel_USD.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_dolara.Text))).ToString();
                przel_kor_szwe.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_kor.Text))).ToString();
                przel_funt.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_funt.Text))).ToString();
            }
            else if (waluta.Text == "RUB")
            {
                //wyświetlanie danych
                wyb_wal.Text = waluta.Text;
                przel_RUB.Text = dane.Text;
                //przeliczane dane
                przel_PLN.Text = ((Double.Parse(dane.Text)) * (Double.Parse(kurs_rubel.Text))).ToString();
                przel_USD.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_dolara.Text))).ToString();
                przel_kor_szwe.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_kor.Text))).ToString();
                przel_funt.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_funt.Text))).ToString();
                przel_jen.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_jen.Text))).ToString();
                przel_EUR.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_euro.Text))).ToString();
                przel_ren_chiny.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_ren_chiny.Text))).ToString();
                przel_frank.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_frank.Text))).ToString();
            }
            else if (waluta.Text == "JPY")
            {
                //wyświetlanie danych
                wyb_wal.Text = waluta.Text;
                przel_jen.Text = dane.Text;
                //przeliczane dane
                przel_PLN.Text = ((Double.Parse(dane.Text)) * (Double.Parse(kurs_jen.Text))).ToString();
                przel_USD.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_dolara.Text))).ToString();
                przel_kor_szwe.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_kor.Text))).ToString();
                przel_funt.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_funt.Text))).ToString();
                przel_EUR.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_euro.Text))).ToString();
                przel_ren_chiny.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_ren_chiny.Text))).ToString();
                przel_frank.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_frank.Text))).ToString();
                przel_RUB.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_rubel.Text))).ToString();
            }
            else if (waluta.Text == "CNY")
            {
                //wyświetlanie danych
                wyb_wal.Text = waluta.Text;
                przel_ren_chiny.Text = dane.Text;
                //przeliczane dane
                przel_PLN.Text = ((Double.Parse(dane.Text)) * (Double.Parse(kurs_ren_chiny.Text))).ToString();
                przel_USD.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_dolara.Text))).ToString();
                przel_kor_szwe.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_kor.Text))).ToString();
                przel_funt.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_funt.Text))).ToString();
                przel_EUR.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_euro.Text))).ToString();
                przel_frank.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_frank.Text))).ToString();
                przel_RUB.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_rubel.Text))).ToString();
                przel_jen.Text = ((Double.Parse(przel_PLN.Text)) / (Double.Parse(kurs_jen.Text))).ToString();
            }
            else if (waluta.Text != "opis_PLN" || waluta.Text!="USD" || waluta.Text!="SEK" || 
                waluta.Text!="EUR" || waluta.Text!="GBP" || waluta.Text!="CHF" || waluta.Text!="RUB" ||
                waluta.Text!="JPY" || waluta.Text!="CNY") {
                    MessageBox.Show("Brak waluty w systemie", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
            }
        }

        private void UpDate_Click(object sender, EventArgs e)
        {
            //dodanie możliwości przeliczania
            this.licznik.Controls.Add(this.licz);
            ///////

            try
            {

                WebRequest zadanie = WebRequest.Create("http://kursy-walut.mybank.pl/");
                zadanie.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse odp = (HttpWebResponse)zadanie.GetResponse();
                Stream strumien = odp.GetResponseStream();
                StreamReader sr = new StreamReader(strumien);
                string tekst = sr.ReadToEnd();
                okno_tekst.Text = tekst;

                //wyłuskiwanie kursów walut
                string [] split=okno_tekst.Lines[646].Split(new char[] { '>', '<' });
                kurs_euro.Text =  split[2].ToString();

                string[] split2 = okno_tekst.Lines[640].Split(new char[] { '>', '<' });
                kurs_dolara.Text = split2[2].ToString();

                string[] split3 = okno_tekst.Lines[748].Split(new char[] { '>', '<' });
                kurs_kor.Text = split3[2].ToString();

                string[] split4 = okno_tekst.Lines[658].Split(new char[] { '>', '<' });
                kurs_funt.Text = split4[2].ToString();

                string[] split5 = okno_tekst.Lines[652].Split(new char[] { '>', '<' });
                kurs_frank.Text = split5[2].ToString();

                string[] split6 = okno_tekst.Lines[814].Split(new char[] { '>', '<' });
                kurs_rubel.Text = split6[2].ToString();

                string[] split7 = okno_tekst.Lines[712].Split(new char[] { '>', '<' });
                kurs_jen.Text = split7[2].ToString();

                string[] split8 = okno_tekst.Lines[718].Split(new char[] { '>', '<' });
                kurs_ren_chiny.Text = split8[2].ToString();   

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

       
    }
}

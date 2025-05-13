using System;
using System.Data.SqlClient;

namespace Komisja

{
    public partial class Form1 : Form
    {
        DatabaseManager databaseManager = new DatabaseManager();
        public Form1()
        {
            InitializeComponent();

        }




        private void button1_Click(object sender, EventArgs e)
        {
            string numerAlbumu = textBoxNumerAlbumu.Text;
            string nazwiskoImie = textBoxNazwiskoImie.Text;
            string semestr = textBoxSemestr.Text;
            string rok = textBoxRok.Text;
            string kierunek = textBoxKierunek.Text;
            string stopien = textBoxStopien.Text;
            string przedmiot = textBoxPrzedmiot.Text;
            double punkty;
            if (!double.TryParse(textBoxPunkty.Text, out punkty))
            {
                punkty = 0;
            }
            string prowadzacy = textBoxProwadzacy.Text;
            string uzasadnienie = textBoxUzasadnienie.Text;
            DateTime data;
            if (!DateTime.TryParse(textBoxData.Text, out data))
            {
                data = DateTime.Now;
                MessageBox.Show("Niepoprawny format daty. Użyto bieżącej daty: " + data.ToShortDateString());
            }

            bool decyzja = radioButton1.Checked;
            string komisja1 = textBoxKomisja1.Text;
            string komisja2 = textBoxKomisja2.Text;
            string komisja3 = textBoxKomisja3.Text;

            DateTime podpis;
            if (!DateTime.TryParse(textBoxPodpis.Text, out podpis))
            {
                podpis = DateTime.Now;
                MessageBox.Show("Niepoprawny format daty. Użyto bieżącej daty: " + data.ToShortDateString());
            }

            databaseManager.WriteData(numerAlbumu, nazwiskoImie, semestr, rok, kierunek, przedmiot, punkty, prowadzacy, uzasadnienie, data, decyzja, komisja1, komisja2, komisja3, podpis);

        }

        private void przedmiot_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxNumerAlbumu_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }


}

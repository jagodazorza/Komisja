using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komisja
{
    public partial class Form2 : Form
    {
        DatabaseManager databaseManager = new DatabaseManager();

        public Form2()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Id", "ID");
            dataGridView1.Columns.Add("NumerAlbumu", "Numer Albumu");
            dataGridView1.Columns.Add("NazwiskoImie", "Nazwisko i Imię");
            dataGridView1.Columns.Add("Semestr", "Semestr");
            dataGridView1.Columns.Add("Rok", "Rok");
            dataGridView1.Columns.Add("KierunekStopien", "Kierunek i Stopień");
            dataGridView1.Columns.Add("Przedmiot", "Przedmiot");
            dataGridView1.Columns.Add("PunktyECTS", "ECTS");
            dataGridView1.Columns.Add("Prowadzacy", "Prowadzący");
            dataGridView1.Columns.Add("Uzasadnienie", "Uzasadnienie");
            dataGridView1.Columns.Add("DataPodpisStudenta", "Data Podpisu Studenta");
            dataGridView1.Columns.Add("Zgoda", "Zgoda");
            dataGridView1.Columns.Add("CzlonekKomisji1", "Członek Komisji 1");
            dataGridView1.Columns.Add("CzlonekKomisji2", "Członek Komisji 2");
            dataGridView1.Columns.Add("CzlonekKomisji3", "Członek Komisji 3");
            dataGridView1.Columns.Add("DataDziekan", "Data Dziekana");

            databaseManager.ShowData(dataGridView1);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            databaseManager.ReadData();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

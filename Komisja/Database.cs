using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Forms;
using System.Collections;


namespace Komisja
{
    internal class DatabaseManager
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kotko\OneDrive\Pulpit\Komisja\Komisja\Database1.mdf;Integrated Security=True;";

        public DatabaseManager()
        {
            CreateTable();
        }




        public void CreateTable()
        {

            string drop = "DROP TABLE KOMISJA";
            string createTableQuery = @"
            CREATE TABLE KOMISJA
            (
             Id INT NOT NULL PRIMARY KEY,
            NumerAlbumu NVARCHAR(20) NULL,
            NazwiskoImie NVARCHAR(100) NULL,
            Semestr NVARCHAR(10) NULL,
            Rok NVARCHAR(20) NULL,
            KierunekStopien NVARCHAR(100) NULL,
            Przedmiot NVARCHAR(100) NULL,
            PunktyECTS INT NULL,
            Prowadzacy NVARCHAR(100) NULL,
            Uzasadnienie NVARCHAR(MAX) NULL,
            DataPodpisStudenta DATE NULL,
            Zgoda BIT NULL,
            CzlonekKomisji1 NVARCHAR(100) NULL,
            CzlonekKomisji2 NVARCHAR(100) NULL,
            CzlonekKomisji3 NVARCHAR(100) NULL,
            DataDziekan DATE NULL)";

           
          
            try
            {
              
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
               
                SqlCommand command = new SqlCommand(createTableQuery, connection);
              

                command.ExecuteNonQuery();
                MessageBox.Show("DataBase is Created Successfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

            public void ReadData()
{
            

            using (SqlConnection connection = new SqlConnection(connectionString))
    {
        string query = "SELECT * FROM KOMISJA";

        SqlCommand command = new SqlCommand(query, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string Id = reader["Id"].ToString();
                string numerAlbumu = reader["NumerAlbumu"].ToString();
                string nazwiskoImie = reader["NazwiskoImie"].ToString();
                string semestr = reader["Semestr"].ToString();
                string rok = reader["Rok"].ToString();
                string kierunekStopien = reader["KierunekStopien"].ToString();
                string przedmiot = reader["Przedmiot"].ToString();
                double punktyEcts = Convert.ToDouble(reader["PunktyECTS"]);
                string prowadzacy = reader["Prowadzacy"].ToString();
                string uzasadnienie = reader["Uzasadnienie"].ToString();
                DateTime dataPodpisStudenta = Convert.ToDateTime(reader["DataPodpisStudenta"]);
                bool zgoda = Convert.ToBoolean(reader["Zgoda"]);
                string czlonek1 = reader["CzlonekKomisji1"].ToString();
                string czlonek2 = reader["CzlonekKomisji2"].ToString();
                string czlonek3 = reader["CzlonekKomisji3"].ToString();
                DateTime dataDziekan = Convert.ToDateTime(reader["DataDziekan"]);


                        
                        MessageBox.Show(
                    $" {Id}: {numerAlbumu} {nazwiskoImie}, {semestr} {rok}, {kierunekStopien}, Przedmiot: {przedmiot}, " +
                    $"ECTS: {punktyEcts}, Prowadzący: {prowadzacy}, Uzasadnienie: {uzasadnienie}, " +
                    $"Data: {dataPodpisStudenta.ToShortDateString()}, Zgoda: {zgoda}, " +
                    $"Komisja: {czlonek1}, {czlonek2}, {czlonek3}, Dziekan: {dataDziekan.ToShortDateString()}"
                );
            }
            reader.Close();
        }
        catch (Exception ex)
        {
                    MessageBox.Show("Error: " + ex.Message);
        }
        }


        }


        public void ShowData(DataGridView dgv)
        {


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM KOMISJA";

                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string Id = reader["Id"].ToString();
                        string numerAlbumu = reader["NumerAlbumu"].ToString();
                        string nazwiskoImie = reader["NazwiskoImie"].ToString();
                        string semestr = reader["Semestr"].ToString();
                        string rok = reader["Rok"].ToString();
                        string kierunekStopien = reader["KierunekStopien"].ToString();
                        string przedmiot = reader["Przedmiot"].ToString();
                        double punktyEcts = Convert.ToDouble(reader["PunktyECTS"]);
                        string prowadzacy = reader["Prowadzacy"].ToString();
                        string uzasadnienie = reader["Uzasadnienie"].ToString();
                        DateTime dataPodpisStudenta = Convert.ToDateTime(reader["DataPodpisStudenta"]);
                        bool zgoda = Convert.ToBoolean(reader["Zgoda"]);
                        string czlonek1 = reader["CzlonekKomisji1"].ToString();
                        string czlonek2 = reader["CzlonekKomisji2"].ToString();
                        string czlonek3 = reader["CzlonekKomisji3"].ToString();
                        DateTime dataDziekan = Convert.ToDateTime(reader["DataDziekan"]);



                        dgv.Rows.Add(
      Id,
      numerAlbumu,
      nazwiskoImie,
      semestr,
      rok,
      kierunekStopien,
      przedmiot,
      punktyEcts,
      prowadzacy,
      uzasadnienie,
      dataPodpisStudenta.ToShortDateString(),
      zgoda,
      czlonek1,
      czlonek2,
      czlonek3,
      dataDziekan.ToShortDateString()
  );




                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }


        }













        public void WriteData(

         string numerAlbumu,
         string nazwiskoImie,
         string semestr,
         string rok,
         string kierunekStopien,
         string przedmiot,
         double punktyEcts,
         string prowadzacy,
         string uzasadnienie,
         DateTime dataPodpisStudenta,
         bool zgoda,
         string czlonekKomisji1,
         string czlonekKomisji2,
         string czlonekKomisji3,
         DateTime dataDziekan)

            {


            string gen = "SELECT MAX(Id) as maxid FROM KOMISJA GROUP BY Id";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand command_gen = new SqlCommand(gen, conn);
            SqlDataReader reader = command_gen.ExecuteReader();

            int number = 0;

            while (reader.Read())
            {
                string ajdi = reader["maxid"].ToString();
                number = Int32.Parse(ajdi)+1;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO KOMISJA
            (Id, NumerAlbumu, NazwiskoImie, Semestr, Rok, KierunekStopien, Przedmiot, PunktyECTS, 
             Prowadzacy, Uzasadnienie, DataPodpisStudenta, Zgoda, 
             CzlonekKomisji1, CzlonekKomisji2, CzlonekKomisji3, DataDziekan)
            VALUES 
            (@number, @NumerAlbumu, @NazwiskoImie, @Semestr, @Rok, @KierunekStopien, @Przedmiot, @PunktyECTS,
             @Prowadzacy, @Uzasadnienie, @DataPodpisStudenta, @Zgoda,
             @CzlonekKomisji1, @CzlonekKomisji2, @CzlonekKomisji3, @DataDziekan)";

                    SqlCommand command = new SqlCommand(query, connection);

 
                    command.Parameters.AddWithValue("@number", number);
                    command.Parameters.AddWithValue("@NumerAlbumu", numerAlbumu);
                    command.Parameters.AddWithValue("@NazwiskoImie", nazwiskoImie);
                    command.Parameters.AddWithValue("@Semestr", semestr);
                    command.Parameters.AddWithValue("@Rok", rok);
                    command.Parameters.AddWithValue("@KierunekStopien", kierunekStopien);
                    command.Parameters.AddWithValue("@Przedmiot", przedmiot);
                    command.Parameters.AddWithValue("@PunktyECTS", punktyEcts);
                    command.Parameters.AddWithValue("@Prowadzacy", prowadzacy);
                    command.Parameters.AddWithValue("@Uzasadnienie", uzasadnienie);
                    command.Parameters.AddWithValue("@DataPodpisStudenta", dataPodpisStudenta);
                    command.Parameters.AddWithValue("@Zgoda", zgoda);
                    command.Parameters.AddWithValue("@CzlonekKomisji1", czlonekKomisji1);
                    command.Parameters.AddWithValue("@CzlonekKomisji2", czlonekKomisji2);
                    command.Parameters.AddWithValue("@CzlonekKomisji3", czlonekKomisji3);
                    command.Parameters.AddWithValue("@DataDziekan", dataDziekan);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show($"{rowsAffected} row(s) inserted.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
        }

    }
}


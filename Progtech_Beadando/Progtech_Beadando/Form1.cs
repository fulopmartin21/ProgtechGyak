using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Progtech_Beadando
{
    public partial class Form1 : Form
    {
        List<string> Markak = new List<string>();
        List<string> Tipusok = new List<string>();
        List<Extras> Extrak = new List<Extras>();
        public Form1()
        {
            InitializeComponent();
            string connectionString = "Persist Security Info=False;database=autoszalon;server=localhost;Uid=root;Pwd=admin;port=3306";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "SELECT Nev FROM MARKAK";
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Markak.Add(reader.GetString(0));
                        }
                    }
                    connection.Close();
                }
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Nev FROM TIPUSOK";
                    using (MySqlCommand cmd2 = new MySqlCommand(query, connection))
                    {
                        MySqlDataReader reader = cmd2.ExecuteReader();
                        while (reader.Read())
                        {
                            Tipusok.Add(reader.GetString(0));
                        }
                    }
                    connection.Close();
                }
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {

                    connection.Open();
                    string query = "SELECT ExtraNev,Ar FROM EXTRA";
                    using (MySqlCommand cmd3 = new MySqlCommand(query, connection))
                    {
                        MySqlDataReader reader = cmd3.ExecuteReader();
                        while (reader.Read())
                        {
                            Extras extra = new Extras();
                            extra.name = reader.GetString(0);
                            extra.price = reader.GetInt32(1);
                            Extrak.Add(extra);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new FieldAccessException(ex.Message);
            }
        }
    }
}

using DocumentFormat.OpenXml.Office2016.Presentation.Command;
using MySqlConnector;
using Progtech_Beadando.AdapterPattern;
using Progtech_Beadando.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Progtech_Beadando.Services
{
    public class LocalGepjarmuAdatServices : IGepjarmuAdatServices
    {
        public string conString = "Persist Security Info=False;database=autoszalon;server=localhost;Uid=root;Pwd=admin;port=3306";
        public List<Marka> GetMarkak()
        {
            List<Marka> Markak = new List<Marka>();
            using (MySqlConnection connection = new MySqlConnection(conString))
            {
                string query = "SELECT ID, Nev FROM MARKAK";
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Markak.Add(new Marka { 
                            ID = reader.GetInt32(0),
                            Nev = reader.GetString(1)
                        });
                    }
                }
                connection.Close();
            }
            return Markak;
        }
        public List<Extra> GetExtras()
        {
            List<Extra> Extrak = new List<Extra>();
            using (MySqlConnection connection = new MySqlConnection(conString))
            {

                connection.Open();
                string query = "SELECT ID,ExtraNev,Ar FROM EXTRA";
                using (MySqlCommand cmd3 = new MySqlCommand(query, connection))
                {
                    MySqlDataReader reader = cmd3.ExecuteReader();
                    while (reader.Read())
                    {
                        Extras extra = new Extras();
                        extra.name = reader.GetString(0);
                        extra.price = reader.GetInt32(1);
                        Extrak.Add(new Extra
                        {
                            ID = reader.GetInt32(0),
                            ExtraNev= reader.GetString(1),
                            Ar = reader.GetInt32(2)
                    });
                    }
                }
            }
            return Extrak;
        }
        public List<Tipus> GetTipusok()
        {
            List<Tipus> Tipusok = new List<Tipus>();
            using (MySqlConnection connection = new MySqlConnection(conString))
            {
                connection.Open();
                string query = "SELECT ID, Nev FROM TIPUSOK";
                using (MySqlCommand cmd2 = new MySqlCommand(query, connection))
                {
                    MySqlDataReader reader = cmd2.ExecuteReader();
                    while (reader.Read())
                    {
                        Tipusok.Add(new Tipus
                        {
                            ID = reader.GetInt32(0),
                            Nev = reader.GetString(1)
                        });
                    }
                }
                connection.Close();
            }
            return Tipusok;
        }
        public bool InsertMegvasarolt(IEnumerable<Car> carList)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(conString))
                {
                    List<Car> AutoLista = carList.ToList();
                    string query = "INSERT INTO Megvasarolt(Marka,Tipus,Vegosszeg) VALUES (@Marka,@Tipus,@Vegosszeg)";
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        for (int i = 0; i < AutoLista.Count; i++)
                        {

                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@Vegosszeg", AutoLista[i].price);
                            switch (AutoLista[i].brand)
                            {
                                case "Suzuki":
                                    cmd.Parameters.AddWithValue("@Marka", 1);
                                    break;
                                case "Daewoo":
                                    cmd.Parameters.AddWithValue("@Marka", 2);
                                    break;
                                case "Audi":
                                    cmd.Parameters.AddWithValue("@Marka", 3);
                                    break;
                                case "Mercedes":
                                    cmd.Parameters.AddWithValue("@Marka", 4);
                                    break;
                            }
                            switch (AutoLista[i].type)
                            {
                                case "Sedan":
                                    cmd.Parameters.AddWithValue("@Tipus", 1);
                                    break;
                                case "SUV":
                                    cmd.Parameters.AddWithValue("@Tipus", 2);
                                    break;
                                case "Hibrid":
                                    cmd.Parameters.AddWithValue("@Tipus", 3);
                                    break;
                            }
                            cmd.ExecuteNonQuery();
                        }
                    }
                    connection.Close();
                    Target target = new Adapter();
                    target.export(AutoLista);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

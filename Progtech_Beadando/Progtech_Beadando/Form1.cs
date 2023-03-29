using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Progtech_Beadando.AdapterPattern;
using Progtech_Beadando.BuilderPattern;

namespace Progtech_Beadando
{
    public partial class Form1 : Form
    {
        List<string> Markak = new List<string>();
        List<string> Tipusok = new List<string>();
        List<Extras> Extrak = new List<Extras>();
        List<Extras> Kivalasztott = new List<Extras>();
        List<Car> AutoLista = new List<Car>();
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
                for(int i=0;i<Markak.Count;i++)
                {
                    comboBox1.Items.Add(Markak[i]);
                }
                for (int i = 0; i < Tipusok.Count; i++)
                {
                    comboBox3.Items.Add(Tipusok[i]);
                }
            }
            catch (Exception ex)
            {
                throw new FieldAccessException(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            for(int i=0;i<Extrak.Count;i++)
            {
                listBox2.Items.Add(Extrak[i].name+" "+Extrak[i].price);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex!=-1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(comboBox3.Text=="Sedan")
            {
                SedanCarBuilder builder = new SedanCarBuilder();
                Director director = new Director(builder);
                director.createSedanCar(Kivalasztott);
                Car car = builder.getCar();
                car.brand = comboBox1.SelectedItem.ToString();
                car.type = comboBox3.SelectedItem.ToString();
                AutoLista.Add(car);
                listBox1.Items.Add(car.ToString());
            }
            else if(comboBox3.Text=="SUV")
            {
                SUVCarBuilder builder = new SUVCarBuilder();
                Director director = new Director(builder);
                director.createSUVCar(Kivalasztott);
                Car car = builder.getCar();
                car.brand = comboBox1.SelectedItem.ToString();
                car.type = comboBox3.SelectedItem.ToString();
                AutoLista.Add(car);
                listBox1.Items.Add(car.ToString());
            }
            else if(comboBox3.Text=="Hibrid")
            {
                HibridCarBuilder builder = new HibridCarBuilder();
                Director director  = new Director(builder);
                director.createHibridCar(Kivalasztott);
                Car car = builder.getCar();
                car.brand = comboBox1.SelectedItem.ToString();
                car.type = comboBox3.SelectedItem.ToString();
                AutoLista.Add(car);
                listBox1.Items.Add(car.ToString());
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva típus vagy nem létezik ilyen!");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(listBox2.SelectedIndex!=-1)
            {
                Extras extra = new Extras();
                string szo = Convert.ToString(listBox2.SelectedItem);
                extra.name = szo.Split(' ')[0];
                extra.price = Convert.ToInt32(szo.Split(' ')[1]);
                Kivalasztott.Add(extra);
                listBox3.Items.Add(extra.name+" "+extra.price);
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva extra!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(listBox3.SelectedIndex!=-1)
            {
                listBox2.Items.Add(listBox3.SelectedItem);
                Kivalasztott.RemoveAt(listBox3.SelectedIndex);
                listBox3.Items.RemoveAt(listBox3.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva extra!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connectionString = "Persist Security Info=False;database=autoszalon;server=localhost;Uid=root;Pwd=admin;port=3306";
            
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                    string query = "INSERT INTO Megvasarolt(Marka,Tipus,Vegosszeg) VALUES (@Marka,@Tipus,@Vegosszeg)";
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        for(int i=0;i<AutoLista.Count;i++)
                        {

                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Vegosszeg",AutoLista[i].price);
                        switch(AutoLista[i].brand)
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
                        switch(AutoLista[i].type)
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
        }
    }
}

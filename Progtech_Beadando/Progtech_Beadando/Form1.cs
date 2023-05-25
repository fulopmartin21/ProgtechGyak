using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Progtech_Beadando.AdapterPattern;
using Progtech_Beadando.Tests;
using Progtech_Beadando.Services;

namespace Progtech_Beadando
{
    public partial class Form1 : Form
    {
        IGepjarmuAdatServices _gs = new LocalGepjarmuAdatServices();
        List<string> Markak = new List<string>();
        List<string> Tipusok = new List<string>();
        List<Extras> Extrak = new List<Extras>();
        List<Extras> Kivalasztott = new List<Extras>();
        List<Car> AutoLista = new List<Car>();
        public Form1()
        {
            InitializeComponent();
            BuilderTests builderTest = new BuilderTests();
            builderTest.BuilderTest1();
            try
            {
                var MarkakDAL = _gs.GetMarkak();
                foreach (var item in MarkakDAL)
                    Markak.Add(item.Nev);
                
                var TipusDal = _gs.GetTipusok();
                foreach (var item in TipusDal)
                    Tipusok.Add(item.Nev);

                var ExtraDal = _gs.GetExtras();
                foreach (var item in ExtraDal)
                    Extrak.Add(new Extras { name = item.ExtraNev, price = item.Ar});

                for (int i=0;i<Markak.Count;i++)
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
            _gs.InsertMegvasarolt(AutoLista);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

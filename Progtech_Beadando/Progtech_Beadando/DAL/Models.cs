using System;
using System.Collections.Generic;
using System.Text;

namespace Progtech_Beadando.DAL
{
    public class Marka
    {
        public int ID { get; set; }
        public string Nev { get; set; }
    }
    public class Tipus
    {
        public int ID { get; set; }
        public string Nev { get; set; }
    }
    public class Extra
    {
        public int ID { get; set; }
        public string ExtraNev { get; set; }
        public int Ar { get; set; }
    }
    public class Megvasarolt
    {
        public int ID { get; set; }
        public int MarkaID { get; set; }
        public int TipusID { get; set; }
        public int Vegosszeg { get; set; }

        public Marka Marka { get; set; }
        public Tipus Tipus { get; set; }
    }
}

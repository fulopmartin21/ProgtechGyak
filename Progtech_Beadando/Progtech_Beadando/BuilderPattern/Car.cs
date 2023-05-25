using System;
using System.Collections.Generic;
using System.Text;

namespace Progtech_Beadando
{
    public class Car
    {
        public int tires { get; set; }
        public int engine { get; set; }
        public bool computer { get; set; }
        public bool charger { get; set; }
        public int price { get; set; }
        public List<Extras> extra { get; set; }

        public string brand { get; set; }
        public string type { get; set; }

        public override string ToString()
        {
            return string.Format("Brand:{0} Type:{1} Price:{2} Computer:{3} Charger:{4} Engine:{5}", brand,type,price,computer,charger,engine);
        }
    }
}

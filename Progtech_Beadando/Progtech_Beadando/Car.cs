using System;
using System.Collections.Generic;
using System.Text;

namespace Progtech_Beadando
{
    class Car
    {
        public int tires { get; set; }
        public int engine { get; set; }
        public bool computer { get; set; }
        public bool charger { get; set; }
        public int price { get; set; }
        public List<Extras> extra { get; set; }
    }
}

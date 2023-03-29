using System;
using System.Collections.Generic;
using System.Text;

namespace Progtech_Beadando.AdapterPattern
{
    class Adapter : Target
    {
        private Adaption adaption = new Adaption();
        public override void export(List<Car> kocsik)
        {
            adaption.SpecialRequest(kocsik);
        }
    }
}

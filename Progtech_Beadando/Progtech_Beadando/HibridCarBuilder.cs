using System;
using System.Collections.Generic;
using System.Text;

namespace Progtech_Beadando
{
    class HibridCarBuilder : IBuilder
    {
            public override void reset()
            {
                Car newCar = new Car();
                this.car = newCar;     
            }

            public override void setComputer()
            {
                
            }

            public override void setEngine()
            {
            }

        public override void setExtras(List<Extras> extras)
        {
        }

        public override void setSportChanger()
            {
            }

            public override void setTires()
            {
            }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Progtech_Beadando
{
        class HibridCarBuilder : IBuilder
        {
            protected Car car;
            public override Car getCar()
            {
            return this.car;
            }

            public override int getPrice()
            {
                int price = (car.tires*20000)+(car.engine*10000);
                if(car.computer && car.charger)
                {
                    price*= 3;
                }
                else if(car.computer || car.charger)
                {
                    price *= 2;
                }
                for(int i=0;i<car.extra.Count;i++)
                {
                price += car.extra[i].price;
                }
                return price;
            }

            public override void reset()
            {
                Car newCar = new Car();
                this.car = newCar;
            }

            public override void setComputer()
            {
            this.car.computer = true;
            }

            public override void setEngine()
            {
            this.car.engine = 200;
            }

            public override void setExtras(List<Extras> extras)
            {
                for(int i=0;i<extras.Count;i++)
                {
                this.car.extra.Add(extras[i]);
                }
            }

            public override void setSportChanger()
            {
            this.car.charger = true;
            }

            public override void setTires()
            {
            this.car.tires = 4;
            }
        }   
}

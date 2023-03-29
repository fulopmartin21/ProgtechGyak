using System;
using System.Collections.Generic;
using System.Text;

namespace Progtech_Beadando
{
    class Director
    {
        private readonly IBuilder builder;

        public Director(IBuilder requestedBuilder)
        {
            builder = requestedBuilder;
        }

        public void createSedanCar(List<Extras> extras)
        {
            builder.reset();
            builder.setEngine();
            builder.setEngine();
            builder.setExtras(extras);
            builder.setTires();
            builder.setSportChanger();
            builder.getPrice();
        }
        public void createSUVCar(List<Extras> extras)
        {
            builder.reset();
            builder.setEngine();
            builder.setEngine();
            builder.setExtras(extras);
            builder.setTires();
            builder.setSportChanger();
            builder.getPrice();
        }
        public void createHibridCar(List<Extras> extras)
        {
            builder.reset();
            builder.setEngine();
            builder.setEngine();
            builder.setExtras(extras);
            builder.setTires();
            builder.setSportChanger();
            builder.getPrice();
        }
    }
}

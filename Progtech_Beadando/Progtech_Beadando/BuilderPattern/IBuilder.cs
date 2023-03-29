using System;
using System.Collections.Generic;
using System.Text;

namespace Progtech_Beadando
{
    abstract class IBuilder
    {
        public abstract void reset();
        public abstract void setEngine();
        public abstract void setTires();
        public abstract void setComputer();

        public abstract void setSportChanger();

        public abstract void setExtras(List<Extras> extras);

        public abstract void getPrice();

        public abstract Car getCar();
    }
}

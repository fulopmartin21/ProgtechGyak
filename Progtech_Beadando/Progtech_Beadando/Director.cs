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
    }
}

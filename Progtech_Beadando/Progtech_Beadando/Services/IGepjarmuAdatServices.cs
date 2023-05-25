using Progtech_Beadando.DAL;
using System.Collections.Generic;

namespace Progtech_Beadando.Services
{
    public interface IGepjarmuAdatServices
    {
        List<Extra> GetExtras();
        List<Marka> GetMarkak();
        List<Tipus> GetTipusok();
        bool InsertMegvasarolt(IEnumerable<Car> carList);
    }
}
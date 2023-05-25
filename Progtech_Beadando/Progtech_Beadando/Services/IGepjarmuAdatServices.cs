using Progtech_Beadando.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Progtech_Beadando.Services
{
    public interface IGepjarmuAdatServices
    {
        Task <List<Extra>> GetExtras();
        Task<List<Marka>> GetMarkak();
        Task<List<Tipus>> GetTipusok();
        Task<bool> InsertMegvasarolt(IEnumerable<Car> carList);
    }
}
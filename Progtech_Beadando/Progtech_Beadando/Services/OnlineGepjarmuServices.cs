using Newtonsoft.Json;
using Progtech_Beadando.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Security.Policy;
using System.Linq;

namespace Progtech_Beadando.Services
{
    internal class OnlineGepjarmuServices : IGepjarmuAdatServices
    {
        HttpClient httpClient;
        public OnlineGepjarmuServices()
        {
            httpClient= new HttpClient();
        }
        
        //string cim = "https://localhost:7244/api/car";
        string cim = "http://services.tg-games.hu/api/car";
        public async Task<List<Extra>> GetExtras()
        {
            List<Extra> result = new List<Extra>();
                string url = $"{cim}/extras";
                string json = await httpClient.GetStringAsync(url).ConfigureAwait(false);
                var extrak = JsonConvert.DeserializeObject<ERoot[]>(json);
                foreach (var item in extrak)
                    result.Add(new Extra { ID = item.id, ExtraNev = item.extraNev, Ar = item.ar });
            
            return result;
        }

        public async Task<List<Marka>> GetMarkak()
        {
            List<Marka> result = new List<Marka>();
                string url = $"{cim}/markak";
                string json = await httpClient.GetStringAsync(url).ConfigureAwait(false);
                var markak = JsonConvert.DeserializeObject<MRoot[]>(json);
                foreach (var item in markak)
                    result.Add(new Marka { ID = item.id, Nev = item.nev });
            
            return result;
        }

        public async Task<List<Tipus>> GetTipusok()
        {
            List<Tipus> result = new List<Tipus>();
                string url = $"{cim}/tipusok";
                string json = await httpClient.GetStringAsync(url).ConfigureAwait(false);
                var tipusok = JsonConvert.DeserializeObject<MRoot[]>(json);
                foreach (var item in tipusok)
                    result.Add(new Tipus { ID = item.id, Nev = item.nev });
            
            return result;
        }

        public async Task<bool> InsertMegvasarolt(IEnumerable<Car> carList)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{cim}";
                string json = JsonConvert.SerializeObject(carList.ToArray());
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                return response.IsSuccessStatusCode;
            }

        }
    }
    public class MRoot
    {
        public int id { get; set; }
        public string nev { get; set; }
    }
    public class ERoot
    {
        public int id { get; set; }
        public string extraNev { get; set; }
        public int ar { get; set; }
    }
}

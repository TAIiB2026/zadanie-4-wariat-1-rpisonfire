using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class ProduktyService : GetDataInterface, FormSubmitInterface
    {
        private int _idGenerator = 1;
        private readonly List<Produkt> _data;

        public ProduktyService()
        {
            _data = new List<Produkt>
            {
                new Produkt { Id = _idGenerator++, Nazwa = "Arbuz", Cena = 5.0, DataWaznosci = new DateTime(2026, 6, 10) },
                new Produkt { Id = _idGenerator++, Nazwa = "Banan", Cena = 7.5, DataWaznosci = new DateTime(2026, 7, 15) },
                new Produkt { Id = _idGenerator++, Nazwa = "Jabłko", Cena = 4.2, DataWaznosci = new DateTime(2026, 8, 20) },
                new Produkt { Id = _idGenerator++, Nazwa = "Pomarańcza", Cena = 6.8, DataWaznosci = new DateTime(2026, 9, 5) },
                new Produkt { Id = _idGenerator++, Nazwa = "Gruszka", Cena = 5.9, DataWaznosci = new DateTime(2026, 10, 12) }
            };
        }

        public IEnumerable<Produkt> Get() => _data;

        public Produkt? GetByID(int id) => _data.FirstOrDefault(x => x.Id == id);

        public bool Delete(int id)
        {
            var obj = _data.FirstOrDefault(x => x.Id == id);
            if (obj == null) return false;
            _data.Remove(obj);
            return true;
        }

        public bool Post(string nazwa, double cena, DateTime dataWaznosci)
        {
            _data.Add(new Produkt { Id = _idGenerator++, Nazwa = nazwa, Cena = cena, DataWaznosci = dataWaznosci });
            return true;
        }

        public bool Put(int id, string nazwa, double cena, DateTime dataWaznosci)
        {
            var obj = _data.FirstOrDefault(x => x.Id == id);
            if (obj == null) return false;
            obj.Nazwa = nazwa;
            obj.Cena = cena;
            obj.DataWaznosci = dataWaznosci;
            return true;
        }
    }
}

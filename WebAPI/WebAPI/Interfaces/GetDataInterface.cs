using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface GetDataInterface
    {
        IEnumerable<Produkt> Get();
        Produkt? GetByID(int id);
        bool Delete(int id);
    }
}

using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface FormSubmitInterface
    {
        bool Post(string nazwa, double cena, DateTime dataWaznosci);
        bool Put(int id, string nazwa, double cena, DateTime dataWaznosci);
    }
}

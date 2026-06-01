namespace WebAPI.Models
{
    public class Produkt
    {
        public int Id { get; set; }
        public string Nazwa { get; set; } = string.Empty;
        public double Cena { get; set; }
        public DateTime DataWaznosci { get; set; }
    }
}

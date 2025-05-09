namespace FastFoodAPI.Models
{
    public class Urun
    {
        public int Id { get; set; }               
        public string Kategori { get; set; }     
        public string Isim { get; set; }         
        public string Aciklama { get; set; }     
        public decimal Fiyat { get; set; }       
        public string ResimUrl { get; set; }
    }
}

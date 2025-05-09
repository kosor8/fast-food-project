namespace FastFoodAPI.Models
{
    public class Siparis
    {
        public int SiparisId { get; set; } 
        public List<SepetOgeleri> Ogeler { get; set; } = new(); 
        public string Adres { get; set; } = string.Empty;   
        public string OdemeBilgisi { get; set; } = string.Empty;  
        public string Durum { get; set; } = "Sipariş Alındı";  
        public DateTime OlusturulmaZamani { get; set; } = DateTime.Now;

    }
}

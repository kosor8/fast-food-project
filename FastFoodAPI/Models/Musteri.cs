namespace FastFoodAPI.Models
{
    public class Musteri //sipariş veren müsterinin adı adrrsi ve ödeme bilgilerini tutacak
    {
        public string Isim { get; set; } = string.Empty;           
        public string Adres { get; set; } = string.Empty;          
        public string OdemeBilgisi { get; set; } = string.Empty;
    }
}

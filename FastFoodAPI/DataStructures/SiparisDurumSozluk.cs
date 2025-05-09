namespace FastFoodAPI.DataStructures
{
    public class SiparisDurumSozluk
    {
        private Dictionary<string, string> siparisDurumlari = new();

        public void DurumEkle(string siparisId, string durum)
        {
            siparisDurumlari[siparisId] = durum;
        }

        public string? DurumuGetir(string siparisId)
        {
            if (siparisDurumlari.TryGetValue(siparisId, out var durum))
                return durum;

            return null;
        }

        public bool Guncelle(string siparisId, string yeniDurum)
        {
            if (siparisDurumlari.ContainsKey(siparisId))
            {
                siparisDurumlari[siparisId] = yeniDurum;
                return true;
            }
            return false;
        }

        public bool Sil(string siparisId)
        {
            return siparisDurumlari.Remove(siparisId);
        }

        public List<(string SiparisId, string Durum)> TumDurumlariListele()
        {
            return siparisDurumlari
                   .Select(kvp => (kvp.Key, kvp.Value))
                   .ToList();
        }

        public void Temizle()
        {
            siparisDurumlari.Clear();
        }
    }
}


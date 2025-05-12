const sepet = {};

function sepeteEkle(urunAdi) {
  if (sepet[urunAdi]) {
    sepet[urunAdi]++;
  } else {
    sepet[urunAdi] = 1;
  }
  sepetiGuncelle();
}

function sepeteCikar(urunAdi) {
  if (sepet[urunAdi] && sepet[urunAdi] > 1) {
    sepet[urunAdi]--;
  } else {
    delete sepet[urunAdi];
  }
  sepetiGuncelle();
}

function sepetiGuncelle() {
  const sepetListesi = document.getElementById('sepetListesi');
  sepetListesi.innerHTML = '';

  for (const urun in sepet) {
    const adet = sepet[urun];
    const li = document.createElement('li');
    li.innerHTML = `${urun} - ${adet}x`;
    sepetListesi.appendChild(li);
  }
}

document.getElementById('siparisVerBtn').addEventListener('click', () => {
  if (Object.keys(sepet).length === 0) {
    alert("Sepet boş. Lütfen ürün ekleyin.");
    return;
  }

  // Burada siparişi sunucuya gönderebilirsiniz
  console.log("Sipariş verildi:", sepet);
  alert("Sipariş başarıyla verildi!");

  // Sepeti temizle
  for (let urun in sepet) delete sepet[urun];
  sepetiGuncelle();
});

document.getElementById('sepetiTemizleBtn').addEventListener('click', () => {
  if (confirm("Sepeti temizlemek istediğinizden emin misiniz?")) {
    for (let urun in sepet) delete sepet[urun];
    sepetiGuncelle();
  }
});

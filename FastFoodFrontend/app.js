const baseURL = "http://localhost:5067/orders";

async function siparisEkle() {
  const customerName = document.getElementById("customerName").value;
  const content = document.getElementById("content").value;
  const sonuc = document.getElementById("sonuc");

  if (!customerName || !content) {
    sonuc.textContent = "Lütfen tüm alanları doldurun.";
    return;
  }

  try {
    const response = await fetch(baseURL, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ customerName, content })
    });

    const mesaj = await response.text();
    sonuc.textContent = mesaj;
    tumSiparisleriGetir();
  } catch (err) {
    console.error(err);
    sonuc.textContent = "Sunucuya ulaşılamadı.";
  }
}

async function tumSiparisleriGetir() {
  const response = await fetch(baseURL);
  const siparisler = await response.json();

  const div = document.getElementById("siparisListesi");
  div.innerHTML = "<h3>📋 Sipariş Listesi</h3>";
  if (siparisler.length === 0) {
    div.innerHTML += "<p>Hiç sipariş yok.</p>";
    return;
  }

  siparisler.forEach(order => {
    div.innerHTML += `<p><strong>ID:</strong> ${order.id} | <strong>Ad:</strong> ${order.customerName} | <strong>İçerik:</strong> ${order.content}</p>`;
  });
}

async function siradakiSiparisiGoster() {
  const response = await fetch(`${baseURL}/next`);
  const sonuc = document.getElementById("sonuc");

  if (response.status === 404) {
    sonuc.textContent = "Kuyrukta sipariş yok.";
    return;
  }

  const order = await response.json();
  sonuc.textContent = `Sıradaki Sipariş -> ${order.customerName} - ${order.content}`;
}

async function siradakiSiparisiTamamla() {
  const response = await fetch(`${baseURL}/complete`, { method: "POST" });
  const mesaj = await response.text();
  document.getElementById("sonuc").textContent = mesaj;
  tumSiparisleriGetir();
}

async function siparisSil() {
  const id = document.getElementById("deleteId").value;
  const sonuc = document.getElementById("sonuc");

  if (!id) {
    sonuc.textContent = "Lütfen bir ID girin.";
    return;
  }

  const response = await fetch(`${baseURL}/${id}`, { method: "DELETE" });
  const mesaj = await response.text();
  sonuc.textContent = mesaj;
  tumSiparisleriGetir();
}

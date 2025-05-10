const API_BASE = "http://localhost:5067/orders";

document.addEventListener("DOMContentLoaded", async () => {
  const eposta = localStorage.getItem("oturumEposta");
  if (!eposta) {
    alert("Lütfen önce giriş yapınız.");
    window.location.href = "login.html";
    return;
  }

  try {
    const response = await fetch(`http://localhost:5067/kullanici/isim?eposta=${eposta}`);
    const data = await response.json();
    const customerName = data.ad; // İsim alındı

    // customerName doğrudan sipariş eklerken kullanılacak
    tumSiparisleriGetir();
    siradakiSiparisiGoster();
    setInterval(() => {
      tumSiparisleriGetir();
      siradakiSiparisiGoster();
    }, 3000);

  } catch (err) {
    console.error("Kullanıcı adı alınamadı:", err);
  }
});

// Sipariş ekleme fonksiyonu
async function siparisEkle() {
  const eposta = localStorage.getItem("oturumEposta");
  const customerName = await getCustomerNameFromEmail(eposta); // Müşteri adı e-posta ile alınıyor
  const orderContent = document.getElementById("orderContent").value;

  if (!customerName || !orderContent) {
    alert("Lütfen tüm alanları doldurun.");
    return;
  }

  try {
    const response = await fetch(API_BASE, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ customerName, content: orderContent })
    });

    if (response.ok) {
      document.getElementById("orderContent").value = "";
      tumSiparisleriGetir();
      siradakiSiparisiGoster();
    } else {
      alert("Sipariş eklenemedi.");
    }
  } catch (error) {
    console.error("HATA:", error);
    alert("Sunucuya bağlanılamadı.");
  }
}

async function getCustomerNameFromEmail(eposta) {
  try {
    const response = await fetch(`http://localhost:5067/kullanici/isim?eposta=${eposta}`);
    const data = await response.json();
    return data.ad;  // İsim dönülüyor
  } catch (err) {
    console.error("Kullanıcı adı alınamadı:", err);
    return null;
  }
}

async function tumSiparisleriGetir() {
  try {
    const response = await fetch(API_BASE);
    const orders = await response.json();

    const list = document.getElementById("siparisListesi");
    list.innerHTML = "";

    orders.forEach(order => {
      const li = document.createElement("li");
      li.innerHTML = `
        <span>#${order.id} - ${order.customerName} (${order.content})</span>
        <button class="sil" onclick="siparisSil(${order.id})">×</button>
      `;
      list.appendChild(li);
    });
  } catch (err) {
    console.error("Listeleme hatası:", err);
  }
}

async function siradakiSiparisiGoster() {
  try {
    const response = await fetch(`${API_BASE}/next`);
    if (!response.ok) {
      document.getElementById("siradakiSiparis").innerText = "Henüz sıradaki sipariş yok";
      document.getElementById("hazirlaBtn").disabled = true;
      return;
    }

    const order = await response.json();
    document.getElementById("siradakiSiparis").innerText = `#${order.id} - ${order.customerName}: ${order.content}`;
    document.getElementById("hazirlaBtn").disabled = false;
  } catch (err) {
    console.error("Sıradaki sipariş hatası:", err);
  }
}

async function siparisHazirla() {
  try {
    const response = await fetch(`${API_BASE}/next`);
    if (!response.ok) {
      alert("Hazırlanacak sipariş yok.");
      return;
    }

    const order = await response.json();
    document.getElementById("hazirlananSiparis").innerText = `#${order.id} - ${order.customerName}: ${order.content} hazırlanıyor...`;

    document.getElementById("hazirlikSlider").value = 0;
    document.getElementById("hazirlikSlider").disabled = false;
    document.getElementById("tamamlaBtn").disabled = true;

    await fetch(`${API_BASE}/startPreparing`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ id: order.id })
    });

    siradakiSiparisiGoster();

    let progress = 0;
    const interval = setInterval(() => {
      progress += 10;
      document.getElementById("hazirlikSlider").value = progress;

      if (progress < 100) {
        document.getElementById("hazirlananSiparis").innerText =
          `#${order.id} - ${order.customerName}: ${order.content} hazırlanıyor...`;
      } else {
        clearInterval(interval);
        document.getElementById("hazirlananSiparis").innerText =
          `#${order.id} - ${order.customerName}: ${order.content} hazırlandı ✅`;
        document.getElementById("tamamlaBtn").disabled = false;
      }
    }, 500);
  } catch (err) {
    console.error("Hazırlama hatası:", err);
  }
}

async function siparisTamamla() {
  try {
    const response = await fetch(`${API_BASE}/complete`, {
      method: "POST"
    });

    if (response.ok) {
      document.getElementById("hazirlananSiparis").innerText = "Henüz bir sipariş hazırlanıyor değil";
      document.getElementById("hazirlikSlider").value = 0;
      document.getElementById("hazirlikSlider").disabled = true;
      document.getElementById("tamamlaBtn").disabled = true;
      tumSiparisleriGetir();
      siradakiSiparisiGoster();
    } else {
      alert("Sipariş tamamlanamadı.");
    }
  } catch (err) {
    console.error("Tamamlama hatası:", err);
  }
}

async function siparisSil(id) {
  const confirmed = confirm(`#${id} numaralı siparişi silmek istiyor musunuz?`);
  if (!confirmed) return;

  try {
    const response = await fetch(`${API_BASE}/${id}`, { method: "DELETE" });
    if (response.ok) {
      tumSiparisleriGetir();
      siradakiSiparisiGoster();
    } else {
      alert("Sipariş silinemedi.");
    }
  } catch (err) {
    console.error("Silme hatası:", err);
  }
}

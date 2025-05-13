// Siparişleri yükle ve göster
async function loadOrders() {
    try {
        console.log('Siparişler yükleniyor...');
        const response = await fetch('http://localhost:5067/api/Order');
        console.log('API yanıtı:', response.status);
        const orders = await response.json();
        console.log('Alınan siparişler (detaylı):', JSON.stringify(orders, null, 2));
        
        // Siparişleri FIFO sırasına göre düzenle
        const hazirlananSiparisler = orders
            .filter(order => {
                console.log('Sipariş durumu:', order.status);
                return order.status === 'Hazırlanıyor';
            })
            .sort((a, b) => a.orderId - b.orderId);
        
        console.log('Hazırlanan siparişler (detaylı):', JSON.stringify(hazirlananSiparisler, null, 2));

        // Sıradaki siparişi göster
        const siradakiSiparis = document.getElementById('siradakiSiparis');
        const hazirlaBtn = document.getElementById('hazirlaBtn');
        
        if (hazirlananSiparisler.length > 0) {
            const ilkSiparis = hazirlananSiparisler[0];
            console.log('İlk sipariş detayları:', JSON.stringify(ilkSiparis, null, 2));
            let siradakiIcerik = `<strong>Sipariş #${ilkSiparis.orderId}</strong><br>`;
            siradakiIcerik += '<strong>Ürünler:</strong><br>';
            ilkSiparis.items.forEach(item => {
                siradakiIcerik += `- ${item.productName} (${item.quantity} adet)<br>`;
            });
            const toplam = ilkSiparis.items.reduce((sum, item) => sum + (item.price * item.quantity), 0);
            siradakiIcerik += `<strong>Toplam:</strong> ₺${toplam.toFixed(2)}<br>`;
            siradakiSiparis.innerHTML = siradakiIcerik;
            
            if (hazirlaBtn) {
                hazirlaBtn.disabled = false;
                hazirlaBtn.onclick = () => completeOrder(ilkSiparis.orderId);
            }
        } else {
            siradakiSiparis.innerHTML = 'Henüz sıradaki sipariş yok';
            if (hazirlaBtn) {
                hazirlaBtn.disabled = true;
            }
        }

        // Tüm siparişleri listele
        const siparisListesi = document.getElementById('siparisListesi');
        siparisListesi.innerHTML = '';

        // Önce hazırlanan siparişleri göster
        hazirlananSiparisler.forEach((order, index) => {
            const li = document.createElement('li');
            li.className = 'siparis-item' + (index === 0 ? ' aktif-siparis' : '');
            
            let siparisIcerik = `<strong>Sipariş #${order.orderId}</strong>`;
            if (index === 0) {
                siparisIcerik += ' <span class="siparis-durum">(Sıradaki)</span>';
            }
            siparisIcerik += '<br>';
            siparisIcerik += '<strong>Ürünler:</strong><br>';
            
            order.items.forEach(item => {
                siparisIcerik += `- ${item.productName} (${item.quantity} adet)<br>`;
            });
            
            const toplam = order.items.reduce((sum, item) => sum + (item.price * item.quantity), 0);
            siparisIcerik += `<strong>Toplam:</strong> ₺${toplam.toFixed(2)}<br>`;
            
            li.innerHTML = siparisIcerik;
            siparisListesi.appendChild(li);
        });
    } catch (error) {
        console.error('Siparişler yüklenirken hata:', error);
        const siparisListesi = document.getElementById('siparisListesi');
        if (siparisListesi) {
            siparisListesi.innerHTML = '<li>Siparişler yüklenirken bir hata oluştu. Lütfen sayfayı yenileyin.</li>';
        }
    }
}

// Siparişi tamamla
async function completeOrder(orderId) {
    try {
        const response = await fetch(`http://localhost:5067/api/Order/complete-order/${orderId}`, {
            method: 'PUT'
        });
        
        if (response.ok) {
            loadOrders();
        } else {
            console.error('Sipariş tamamlanırken hata:', await response.text());
        }
    } catch (error) {
        console.error('Sipariş tamamlanırken hata:', error);
    }
}

// Sayfa yüklendiğinde siparişleri yükle
document.addEventListener('DOMContentLoaded', () => {
    loadOrders();
    setInterval(loadOrders, 2000);
}); 
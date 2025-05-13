# **FastFoodAPI Projesi – Fullstack Uygulama**

Bu proje, **modern bir fast-food sipariş sistemi** oluşturmak amacıyla geliştirilmiş **web tabanlı bir fullstack (frontend \+ backend) uygulamasıdır**. Projenin frontend tarafında **HTML, CSS, JavaScript**; Backend tarafında **C\# ve ASP.NET Core** kullanılarak **RESTful API** mimarisi uygulanmıştır. Kullanıcıların internet üzerinden restoran menüsünü görüntüleyerek sipariş verebildiği, sipariş geçmişini takip edebildiği ve işlemlerini gerçek zamanlı olarak gerçekleştirebildiği bir platform sunar.

Uygulama, hem müşteri hem de personel rollerine uygun olarak farklı arayüzler ve işlevsellikler içermektedir. Müşteri tarafında sipariş verme, sepet yönetimi, kullanıcı girişi ve kaydı gibi işlemler; personel tarafında ise siparişleri takip etme ve işleme alma gibi operasyonel süreçler yönetilmektedir. Tüm bu işlemler, kullanıcı dostu bir arayüz ve güçlü bir arka plan mimarisi ile entegre bir şekilde çalışmaktadır.

## **1\. Özellikler**

## **1.1 Frontend Özellikleri**

**Kullanıcı Yönetimi**

* Kayıt ve giriş sistemi

* Personel yetkilendirme

* LocalStorage ile oturum yönetimi

**Menü Sistemi**

* Kategorilere ayrılmış ürünler

* Ürün görselleri ve açıklamaları

**Sepet Yönetimi**

* Ürün ekleme/çıkarma ve miktar ayarı

* Fiyat hesaplama, KDV ve teslimat ücretleri dahil  
  


**Sipariş Yönetimi**

* Sipariş onaylama

* FIFO sıralı sipariş görünümü (personel ekranı)

**1.2 Backend Özellikleri**

* Kullanıcı ve personel giriş doğrulama

* Ürün listesi ve kategorileri sağlama

* Sepete ürün ekleme ve güncelleme (POST/PUT)

* Sipariş tamamlama ve kayıt

* Personel için siparişleri görüntüleme (FIFO)

##  **Kullanılan Teknolojiler**

### **Frontend:**

* HTML5

* CSS3

* JavaScript (ES6+)

* Fetch API

* LocalStorage

### **Backend:**

* RESTful API mimarisi

* C\# ve ASP.NET

* CORS ve güvenlik önlemleri

## 

## 

## **Kullanılan Veri Yapıları**

* Bağlı Liste (Linked List)   
    
* Ağaç (Tree)  
    
* Kuyruk (Queue)  
    
* Dictionary


**Ağaç Veri Yapısı Analizi (Menü Sistemi)**

**Yapısal Tasarım**

 Menü yapısı, 2 seviyeli ağaç (tree) veri yapısı ile modellenmiştir.

**Kök Seviyesi (Level 1):**

 List\<CategoryNode\> → Ana kategoriler (ör. Burgerler, Tatlılar).

**Yaprak Seviyesi (Level 2):** 

Her CategoryNode’un Children listesi → ProductNode’lar   (ürünler).

**Zaman Karmaşıklığı**

**GetMenu() Metodu:** O(1)  
 (Statik olarak tanımlanmış bir veri yapısı döndürüldüğü için sabit zamanlı çalışır.)

**Tüm Menüyü Okuma:** O(n)

n \= toplam kategori \+ toplam ürün

**Belirli Bir Kategoriyi Bulma:** O(c)

c \= kategori sayısı

**Belirli Bir Ürünü Bulma:** O(c \* m)

m \= bir kategorideki ortalama ürün sayısı

 **Alan Karmaşıklığı**

Toplam Düğüm Sayısı: O(n)

 4 kategori × 5 ürün \= **20 düğüm**

**Yapısal Özellikler**

**Derinlik (Depth):** 2

**Genişlik (Width):**

Seviye 1: 4 (kategori sayısı)

Seviye 2: 5 (her kategorideki ürün sayısı)

**Avantajlar**

**Doğal Hiyerarşi:** Kategoriler ile ürünler arasında doğal ebeveyn-çocuk ilişkisi kurulur.

**Kolay Yönetim:** Yeni kategori veya ürün ekleme, sadece ilgili düğümde yapılır.

**Verimli İşlemler:** Kategoriye özel listeleme, güncelleme veya silme işlemleri kolay ve hızlıdır.

**Kuyruk Veri Yapısı Analizi**

**Yapısal Tasarım **   
`Queue <T>` yapısı, System.Collections.Generic altında yer alır ve FIFO prensibiyle çalışır. Siparişler sırayla kuyruğa eklenir (`Enqueue`) ve ilk gelen sipariş ilk çıkar (`Dequeue`). `Order` sınıfı her bir siparişi temsil eder. ID ataması `int _nextId` ile otomatik artan şekilde yapılır.

**Zaman Karmaşıklığı**

***Enqueue(order)*****:** Kuyruğun sonuna sipariş ekler .O(1)  
***Dequeue():*** İlk siparişi çıkarır. O(1)  
***Peek():*** İlk siparişi gösterir.O(1)  
***GetAll():*** Kuyruğun tamamını liste olarak döner. O(n)  
***GetBy(id):*** Id’ye göre tarama yapar. O (n)  
***DeleteById(id)**:* Kuyruktan belirli ID’li öğeyi siler. O(n) (iki kez döner)  
***Count():*** Kuyruktaki öğe sayısını verir. O(1)

**Alan Karmaşıklığı**  
Queue\<Order\>  O(n)  
tempQueue O(n) sadece deletedById fonksiyonunda

Her sipariş (`Order`) nesnesi bellekte bir yer kaplar.  
En kötü durumda tüm siparişler geçici kuyrukta tekrar saklandığı için alan geçici olarak iki katına çıkabilir (`DeleteById` fonksiyonunda).

## **Avantajları**

***Basit ve Doğal FIFO Davranışı:*** Siparişlerin sırayla işlenmesini garantiler.  
***Hızlı İşlem:*** `Enqueue`, `Dequeue`, `Peek` gibi temel işlemler sabit zamanda yapılır.  
***Kolay Yönetim:*** Siparişlerin tarihine göre işlenmesini sağlar.  
***Kodun Okunabilirliği:*** .NET’in `Queue<T>` yapısı kullanıldığı için bakımı kolaydır.  
**Esneklik:** `DeleteById` gibi özel işlemler eklenerek yapı genişletilmiş. 

**Dictionary Veri Yapısı Analizi**

* Sözlük (dictionary), anahtarlar(keys) ve bu anahtarlara karşılık gelen değerlerden(value) oluşan bir veri yapısıdır. Tıpkı gerçek bir sözlük gibi, bir anahtar verildiğinde, ona karşılık gelen değeri  hızlıca bulmayı sağlar.


**Zaman Karmaşıklığı**

* **Ortalama Durum**: Ekleme, arama, silme ve anahtar kontrolü genellikle O(1) (sabit zaman).  
* **En Kötü Durum**: Nadiren görülür, ancak bazı durumlarda bu işlemler O(n)'ye (doğrusal zaman) çıkabilir.

**Avantajları**

* **Okunabilirlik:** İnsanlar tarafından kolayca okunabilir ve anlaşılabilir bir yapıya sahiptir.  
* **Basitlik:** Karmaşık olmayan, temel anahtar-değer çiftlerinden oluşur.  
* **Hafiflik:** XML gibi diğer veri formatlarına göre daha az yer kaplar ve daha hızlı işlenir.  
* **Yaygın Destek:** JavaScript başta olmak üzere birçok programlama dili tarafından kolayca ayrıştırılabilir ve oluşturulabilir.

**Kullanım Nedenleri**

* **Web Geliştirme:** Özellikle Front-end  ve Back-end arasındaki veri iletişiminde standart bir formattır. API'lar genellikle veri alışverişi için JSON kullanır.  
* **Veri Transferi:** Farklı uygulamalar ve sistemler arasında veri aktarımı için idealdir.  
* **Konfigürasyon Dosyaları:** Uygulama ayarlarını saklamak için basit ve kullanışlı bir yöntemdir.


## **Proje Yapısı**

`FastFood-Project/`  
`│`                 
`├── kullanicilar.json`         
`├── FastFoodAPI.csproj`	  
`├── Program.cs` 	  
`├── Models/`  
 `├── Kullanici.cs`  
 `├── Order.cs`  
`├── Controllers/`    
 `├── CartController.cs`  
  	 `├── KullaniciController.cs`    
 `├── MenuController.cs`  
   	 `├── OrderController.cs`      
`├── Services/`   
 `├── CartService.cs`  
 `├── MenuService.cs`  
 `├── OrderService.cs`  
`├── Data/`   
 `├── KullaniciVeritabani.cs`  
`├──...`              
`│`  
`├── front-end/`     
`│   ├── images/`  
`│   ├── videos/`  
`│   ├── sounds/`  
`│   ├── main2.html`  
`│   ├── menu.html`  
`│   ├── cart.html`  
`│   ├── login.html`  
`│   ├── register.html`  
`│   ├── personel.html`  
`│   ├── cart_style.css`  
`│   ├── menu_style.css`  
`│   └── ...`  
`└── README.md`

## **Backend API Entegrasyonu**

### **1\. Sepete Ekleme Fonksiyonu**

* Her ürünün "Sepete Ekle" butonuna tıklandığında:

  * JavaScript ile her ürüne atadığımız benzersiz ID’leri alır.

  * **`fetch()`** ile **`/api/cart/add/${ProductID}`** endpoint’ine **`POST`** isteği atılır ve Bu benzersiz ID’ler sayesinde müşterinin istediği ürün sepete eklenmiş olur.

  * Backend bu isteği karşılayarak sepeti günceller.

### **2\. Miktar Güncelleme (Artı/Eksi)**

* Kullanıcı, sepetteki ürünün miktarını arttırdığında:

  * Her “+” ya bastığımızda bir ClickEventListener ile bu olay dinlenir ve kişi artıya bastığı zaman Yeni miktar **`POST`** isteğiyle `/api/cart/add/${ProductID}` endpoint’ine gönderilir.  
  * Her “-” ye bastığımızda ise yine aynı şekilde ClickEventListener ile olay dinlenir ve kişi eksiye bastığı zaman Güncellenen miktar  **`DELETE`** isteğiyle **`/api/cart/remove/${ProductID}`** endpoint’ine gönderilir.

  * Backend bu aldığı etkileşimlere göre Veritabanını Günceller.

### **3\. Siparişi Tamamlama**

* **`Sepeti Onayla`** butonuna tıklandığında:

  * Sepet içeriği **`POST`** isteği ile **`/api/order/place-order`** adresine gönderilir ve bu sayede sepetteki ürünler Menü şeklinde ID ataması alır. 

  * Backend siparişi kaydeder ve personel ekranında gösterilmek üzere sıraya alır personel ekranında ise **`PUT`** isteği ile **`/api/order/Complete-order/{OrderID}`** eğer sipariş tamamlanırsa FIFO(First in First Out) veri yapısına uygun şekilde sıraya ilk giren ilk çıkacak şekilde düzenlenir ayrıca sıradaki siparişi görmek için personel ekranımızda **`GET`** isteği ile **`/api/order/Next`** ile sıradaki sipariş ekranda gösterilir.

  * Son Olarak Sepet temizlenir, kullanıcı ana sayfaya yönlendirilir.

### **4\. Siparişi Hazırla**

* Personel güncel olarak kullanıcılardan gelen siparişleri sipariş listesinde FIFO yapısında görüntüler.

  * Bu da javascripteki loadOrders fonksiyonunun her saniye başı güncellenmesiyle sağlanır. Bu fonksiyon **`api/Order`** adresine **`GET`** isteği atarak gönderilen sipariş bilgilerinin kuyruk yapısına uygun şekilde sipariş listesinde görüntülenmesini sağlar.

  * Siparişi tamamlama kısmında ise javascripteki completeOrder(orderId) fonksiyonu devreye girer. **`api/Order/complete-order/${orderId}`** adresine **`PUT`** isteği atarak sıradaki siparişin tamamlanmasını ve kuyruktan sıraya uygun şekilde çıkarılmasını sağlar.

### **5\. Siparişi Sil**

* Personel herhangi bir kullanıcının siparişi iptal etmesi durumunda burayı kullanabilir.

  * Bu işlem için de javascripteki deleteOrder(orderId) fonksiyonunun devreye girer. Bu fonksiyon çağırıldığında  **`api/Order/${orderId}`** adresine **`DELETE`** isteği atarak iptal edilen siparişin id numarasına göre kuyruk yapısına uygun şekilde sipariş listesinden çıkarılmasını sağlar.

### **6\. Giriş**

* **`Giriş`** butonuna tıklandığında:

  * Kullanıcıdan alınan e-posta ve parola değerleri  **`POST`** isteği ile **`/kullanici/login`**  adresine gönderilir.

  * Backend e-posta ve parolayı kontrol eder. Uyuşmaması durumunda uyarı mesajı verir, uyuşması durumunda 2 saniyelik bir gecikme sonrası kullanıcıyı ana sayfaya yönlendirir. Girilen e-postaya ait kayıt bulunamadıysa uyarı mesajı ile kullanıcının kayıt olması gerektiğini belirtir.

### **7\. Kayıt Olma**

* **`Kayıt Ol`** butonuna tıklandığında:

  * Kullanıcıdan alınan isim, e-posta ve parola değerleri **`POST`** isteği ile **`/kullanici/register`**  adresine gönderilir.

  * Backend isim, e-posta ve parolayı kullanicilar.json dosyasına kaydeder. Hali hazırda girilen e-postaya ait kayıtlı kullanıcı bulunuyorsa uyarı mesajı ile durumu belirtir. Aynı zamanda site içinde girilen kullanıcı adını kullanmak üzere localStorage ile girilen e-postayı tutar. Kayıt başarılı olması durumunda 2 saniyelik bir gecikme sonrasında kullanıcıyı giriş ekranına yönlendirir.

### **8\. Personel Girişi**

* **`Personel Girişi`** butonuna tıklandığında:

  * Kullanıcıyı personel giriş ekranına yönlendirir. Burada personel parolası girişi bekler. Parola önceden ***burgery1616*** olarak belirlenmiştir. 

  * Parolanın doğru girilmesi durumunda kişiyi personel sipariş sistemine/personel paneline yönlendirir.

## **Kurulum ve Çalıştırma**

### **Gereksinimler**

* .NET SDK (.NET 9.0)

* Geliştirme ortamı (örneğin: Visual Studio, Visual Studio Code)

* (Opsiyonel) Postman veya Swagger UI (API testleri için)

### **1\. Projeyi Klonlayın**

***`git clone https://github.com/kosor8/fast-food-project.git`***  
***`cd fast-food-project`***

### **2\. Gerekli Bağımlılıkların Yükleyin**

**`dotnet restore`**

### **3\. Uygulamayı Çalıştırın**

**`dotnet restore`**

### **3\. Frontend’i Çalıştırın**

Frontend dizinine gidin:

**`cd frontend`**

* **`main2.html`**'i çift tıklayarak tarayıcı üzerinden çalıştırın.

* Backend API ile bağlantı için URL’lerin doğru tanımlandığından emin olun (**`http://localhost:5067/api/...`**).

## **Kullanıcı Rolleri**

###      **Kullanıcı**

* Menüde gezinme

* Sepete ürün ekleme

* Sipariş verme

* Sisteme kayıt olma ve giriş yapma

###     **Personel**

* Giriş ekranı ile erişim

* Tüm siparişleri FIFO sırasına göre görüntüleme

* Siparişleri silme, hazırlama 

##    **Güvenlik**

* Yetkisiz kullanıcılar sipariş veremez.

* Personel paneli sadece giriş yapmış personele açıktır.

* API istekleri CORS ile koruma altındadır.

* LocalStorage üzerinden token veya session yönetimi yapılabilir.

##    **Tasarım Özellikleri**

* Video arka planlar ve sesler

* Kullanıcı dostu modern arayüz

* Dinamik animasyonlar

##    **Geliştiriciler**

* Mustafa Mert Bedez – 03239050@ogr.uludag.edu.tr

* Mustafa Ozan Aydın – 032390049@ogr.uludag.edu.tr

* Arda Berat Kosor – 032390048@ogr.uludag.edu.tr

* Berat Çam – 032390052@ogr.uludag.edu.tr

* Sevim Çıra – 032390053@ogr.uludag.edu.tr


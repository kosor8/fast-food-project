function Home() {
    return (
      <div className="p-4">
        {/* Banner */}
        <div className="bg-yellow-200 rounded-xl p-6 text-center mb-6 shadow-lg">
          <h2 className="text-3xl font-bold text-red-600 mb-2">Hoşgeldin!</h2>
          <p className="text-lg text-gray-700">Lezzetli burger ve pizzalar burada seni bekliyor 🍔🍕</p>
        </div>
  
        {/* Kategori Butonları */}
        <div className="flex justify-center gap-6 mb-8">
          <button className="bg-red-500 text-white px-6 py-3 rounded-full hover:bg-red-600 transition">
            🍔 Burger Menü
          </button>
          <button className="bg-yellow-500 text-white px-6 py-3 rounded-full hover:bg-yellow-600 transition">
            🍕 Pizza Menü
          </button>
        </div>
  
        {/* Günün Favorileri */}
        <div>
          <h3 className="text-2xl font-semibold mb-4">⭐ Günün Favorileri</h3>
          <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
            <div className="bg-white p-4 rounded-lg shadow-md">
              <img src="https://picsum.photos/200/120" alt="Burger" className="rounded-md mb-3 w-full h-32 object-cover" />
              <h4 className="font-bold text-lg mb-1">Klasik Cheeseburger</h4>
              <p className="text-sm text-gray-600 mb-2">Izgara dana köfte, cheddar, özel sos</p>
              <span className="font-semibold text-red-600">79.99₺</span>
            </div>
            <div className="bg-white p-4 rounded-lg shadow-md">
              <img src="https://picsum.photos/201/120" alt="Pizza" className="rounded-md mb-3 w-full h-32 object-cover" />
              <h4 className="font-bold text-lg mb-1">Pepperoni Pizza</h4>
              <p className="text-sm text-gray-600 mb-2">Bol mozzarella, pepperoni dilimleri</p>
              <span className="font-semibold text-red-600">99.99₺</span>
            </div>
            <div className="bg-white p-4 rounded-lg shadow-md">
              <img src="https://picsum.photos/202/120" alt="Burger" className="rounded-md mb-3 w-full h-32 object-cover" />
              <h4 className="font-bold text-lg mb-1">Acılı Tavuk Burger</h4>
              <p className="text-sm text-gray-600 mb-2">Izgara tavuk, acı sos, marul</p>
              <span className="font-semibold text-red-600">74.99₺</span>
            </div>
          </div>
        </div>
      </div>
    );
  }
  
  export default Home;
  
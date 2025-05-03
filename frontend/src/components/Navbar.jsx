import { useState } from 'react';

function Navbar() {
  const [isOpen, setIsOpen] = useState(false);

  return (
    <nav className="bg-white shadow-md px-4 py-3 flex items-center justify-between">
      {/* Logo */}
      <div className="text-2xl font-bold text-red-600">
        🍔 FastFood
      </div>

      {/* Mobile Menü Butonu */}
      <button
        className="md:hidden text-2xl"
        onClick={() => setIsOpen(!isOpen)}
      >
        ☰
      </button>

      {/* Menü Linkleri */}
      <ul
        className={`md:flex gap-6 font-medium ${
          isOpen ? 'block mt-4' : 'hidden'
        } md:block`}
      >
        <li><a href="#" className="hover:text-red-500">Ana Sayfa</a></li>
        <li><a href="#" className="hover:text-red-500">Menü</a></li>
        <li><a href="#" className="hover:text-red-500">Sepet</a></li>
        <li><a href="#" className="hover:text-red-500">Giriş</a></li>
      </ul>
    </nav>
  );
}

export default Navbar;
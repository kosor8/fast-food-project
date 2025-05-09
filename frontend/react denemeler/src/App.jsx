import './App.css';

function App() {
  return (
    <div className="min-h-screen bg-[#0d3f2c] text-white px-10 py-8 font-sansita">
      {/* Navbar */}
      <div className="flex justify-between items-center mb-16">
        <h1 className="text-3xl font-bold tracking-widest">BURGUR</h1>
        <nav className="space-x-8 text-lg">
          <a href="#" className="hover:text-[#FFBDAA]">Home</a>
          <a href="#" className="hover:text-[#FFBDAA]">Menu</a>
          <a href="#" className="hover:text-[#FFBDAA]">About</a>
          <a href="#" className="hover:text-[#FFBDAA]">Shop</a>
        </nav>
      </div>
      <div style={{width: '100%', height: '100%', textAlign: 'center', color: '#FBFADA', fontSize: 144, fontFamily: 'Sansita Swashed', fontWeight: '700', wordWrap: 'break-word'}}>Burger Club </div>
      <div style={{width: '100%', height: '100%', textAlign: 'center', color: '#ADBC9F', fontSize: 50, fontFamily: 'Lexend Zetta', fontWeight: '700', wordWrap: 'break-word'}}>THE ULTIMATE</div>
      <div style={{textAlign: 'center', color: '#ADBC9F', fontSize: 20, fontFamily: 'Lexend Zetta', fontWeight: '700', wordWrap: 'break-word'}}>Savor the Flavor, Join the Club!</div>

      <div style={{width: '100%', height: '100%', position: 'relative', overflow: 'hidden', borderRadius: 25}}>
    <div style={{width: 262, height: 100, paddingLeft: 92, paddingRight: 92, paddingTop: 19, paddingBottom: 19, left: 544, top: 0, position: 'absolute', background: 'rgba(255, 255, 255, 0)', overflow: 'hidden', justifyContent: 'center', alignItems: 'center', gap: 10, display: 'inline-flex'}}>
        <div style={{width: 68, height: 26, color: '#FBFADA', fontSize: 25, fontFamily: 'Sansita Swashed', fontWeight: '400', wordWrap: 'break-word'}}>Home</div>
    </div>
    <div style={{width: 262, height: 100, paddingLeft: 92, paddingRight: 92, paddingTop: 19, paddingBottom: 19, left: 804, top: 0, position: 'absolute', background: 'rgba(255, 255, 255, 0)', overflow: 'hidden', justifyContent: 'center', alignItems: 'center', gap: 10, display: 'inline-flex'}}>
        <div style={{width: 86, height: 26, color: '#FBFADA', fontSize: 25, fontFamily: 'Sansita Swashed', fontWeight: '400', wordWrap: 'break-word'}}>About</div>
    </div>
    <div style={{width: 262, height: 100, paddingLeft: 92, paddingRight: 92, paddingTop: 19, paddingBottom: 19, left: 954, top: 0, position: 'absolute', background: 'rgba(255, 255, 255, 0)', overflow: 'hidden', justifyContent: 'center', alignItems: 'center', gap: 10, display: 'inline-flex'}}>
        <div style={{width: 68, height: 26, color: '#FBFADA', fontSize: 25, fontFamily: 'Sansita Swashed', fontWeight: '400', wordWrap: 'break-word'}}>Shop</div>
    </div>
    <div style={{width: 274, height: 100, paddingLeft: 92, paddingRight: 92, paddingTop: 19, paddingBottom: 19, left: 664, top: 0, position: 'absolute', background: 'rgba(255, 255, 255, 0)', overflow: 'hidden', justifyContent: 'center', alignItems: 'center', gap: 10, display: 'inline-flex'}}>
        <div style={{width: 68, height: 26, color: '#FBFADA', fontSize: 25, fontFamily: 'Sansita Swashed', fontWeight: '400', wordWrap: 'break-word'}}>Menu</div>
    </div>
    <div style={{width: 385, height: 31, left: 12, top: 34, position: 'absolute', textAlign: 'center', color: '#FBFADA', fontSize: 50, fontFamily: 'Lexend Zetta', fontWeight: '700', wordWrap: 'break-word'}}>BURGUR CLUB</div>
</div>
      

      {/* Hero Section */}
      <div className="flex flex-col lg:flex-row items-center justify-between">
        <div className="text-center lg:text-left max-w-xl">
          <p className="text-sm tracking-widest text-[#FFBDAA] mb-2">THE ULTIMATE</p>
          <h2 className="text-[72px] font-bold text-[#FFBDAA] leading-tight mb-4">
            Burger Club
          </h2>
          <p className="text-md text-gray-300">Savor the Flavor, Join the Club!</p>
        </div>
        <img
          src="/images/burger.png"
          alt="Burger"
          className="w-[500px] mt-10 lg:mt-0"
        />
      </div>

      {/* Slider Icons */}
      <div className="flex justify-center gap-4 mt-10">
        <img src="/images/burger1.png" className="w-20 h-20 rounded-full" />
        <img src="/images/burger2.png" className="w-20 h-20 rounded-full" />
        <img src="/images/burger3.png" className="w-20 h-20 rounded-full" />
        <img src="/images/burger4.png" className="w-20 h-20 rounded-full" />
      </div>
    </div>
  );
}

export default App;

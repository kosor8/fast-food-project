import './App.css'
import Navbar from './components/Navbar'
import Home from './pages/Home'


function App() {
  return (
    <div>
      <Navbar />
      <Home/>
      <main className="p-4">
        <h1 className="text-3xl font-bold text-gray-800">Hoşgeldin 👋</h1>
        <p className="mt-2 text-gray-600">Bedez codinggggggg</p>
      </main>
    </div>
  );
}

export default App;

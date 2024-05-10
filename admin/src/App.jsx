import React from 'react'
import './App.css'
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import LoginPage from './Pages/LoginPage/LoginPage.jsx'
import DashboardPage from './Pages/DashboardPage/DashboardPage.jsx'
import EncontreEventosPage from './Pages/EncontreEventosPage/EncontreEventosPage.jsx'
import CidadesPage from './Pages/CidadesPage/CiadadesPage.jsx'
import RecuperarPage from './Pages/RecuperarPage/RecuperarPage.jsx'
import GraficosPage from './Pages/GraficosPage/GraficosPage.jsx'


function App() {

  return (
    <Router>
      <Routes>
        <Route path="/" element={<LoginPage />} />
        <Route path="/dash" element={<DashboardPage />} />
        <Route path="/encontreEventos" element={<EncontreEventosPage />} />
        <Route path="/cidades" element={<CidadesPage />} />
        <Route path="/graficos" element={<GraficosPage/>} />
        <Route path="/recuperarSenha" element={<RecuperarPage />} />
      </Routes>
    </Router>
  )
}

export default App
import React, { useState } from 'react';
import './SuporteQuadro.css';
import verificado from '../../assets/Images/verificado.png';
import { Link } from 'react-router-dom';

function SuporteQuadro() {
  const email = 'usuariogenerico@gmail.com';
  const nomeCompleto = 'Nome completo do usuário da Silva';
  const data = '17/04/2024';
  const [tipo, setTipo] = useState('Todos os tipos'); // Estado para armazenar o tipo selecionado

  // Dados dos itens
  const itens = [
    { id: 1, tipo: 'Bugs Relatados', respondido: false },
    { id: 2, tipo: 'Duvidas', respondido: true },
    // Adicione mais itens conforme necessário
  ];

  // Função para lidar com a seleção de um tipo
  const selecionarTipo = (event) => {
    setTipo(event.target.value);
  };

  // Função para filtrar os itens com base no tipo selecionado
  const itensFiltrados = tipo === 'Todos os tipos' ? itens : itens.filter(item => item.tipo === tipo);

  return (
    <div className="suporte-container">
      <div className='selequite'>
        <select id="opcoes" name="opcoes" value={tipo} onChange={selecionarTipo}>
          <option value="Todos os tipos">Todos os tipos</option>
          <option value="Bugs Relatados">Bugs Relatados</option>
          <option value="Duvidas">Duvidas</option>
        </select>
      </div>

      <div className='suportePai'>
        {itensFiltrados.map(item => (
          <div className="suporte-quadro" key={item.id}>
            <Link to='/suporte' className='suporteResposta'>
            <div className='informacao'>
              <p>E-mail: {email}</p>
              <p>Nome completo: {nomeCompleto}</p>
              <p>Data: {data}</p>
              <p>Tipo: {item.tipo}</p>
            </div>
            {item.respondido && (
              <div>
                <img src={verificado} alt="Verificado" className='image'/>
              </div>
            )}
            </Link>
          </div>
        ))}
      </div>
    </div>
  );
}

export default SuporteQuadro;
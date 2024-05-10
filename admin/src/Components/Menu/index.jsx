import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import senailogo from '../../assets/Images/senailogo.png';
import risco from '../../assets/Images/risco.png';
import lupa from '../../assets/Images/lupa.png';
import perfil from '../../assets/Images/perfil.png';
import './Menu.css';

function SearchComponent() {
    const [isSearchOpen, setSearchOpen] = useState(false);

    const handleSearchIconClick = () => {
        setSearchOpen((prev) => !prev); // Alterna o estado de aberto/fechado
    };

    const handleSearchInputChange = (event) => {
        const query = event.target.value;
        console.log('Pesquisar:', query);
    };

    const handleOverlayClick = () => {
        setSearchOpen(false); // Fecha a caixa de texto quando clicar na imagem novamente
    };

    return (
        <div className="search-component" style={{ display: 'flex', alignItems: 'center' }}>
            <button onClick={handleSearchIconClick} style={{ border: 'none', background: 'transparent', cursor: 'pointer' }}>
                <img src={lupa} alt="Ícone de pesquisa" style={{ width: '24px', height: '24px' }} />
            </button>

            {isSearchOpen && (
                <>
                    <div className="overlay" onClick={handleOverlayClick}></div>
                    <input
                        type="text"
                        placeholder="Pesquisar..."
                        onChange={handleSearchInputChange}
                        style={{
                            marginLeft: '10px',
                            padding: '5px',
                            borderRadius: '4px',
                            border: '1px solid #ccc',
                            
                            
                        }}
                    />
                </>
            )}
        </div>
    );
}

function Menu() {
    return (
        <div className='menu'>
            <img src={senailogo} alt="Logo" className="menu-logo" />

            <nav>
                <ul>
                    <li>
                        <Link to='/'>Login</Link>
                    </li>
                    <li>
                        <Link to='/dash'>Dashboard</Link>
                    </li>
       
                </ul>
            </nav>

            <Link to='/perfil' className='perfil'>
                <img src={perfil} alt="Perfil" className="lupa" />
            </Link>

            <img src={risco} alt="Risco" className="lupa" />

            <SearchComponent />
        </div>
    );
}

export default Menu;
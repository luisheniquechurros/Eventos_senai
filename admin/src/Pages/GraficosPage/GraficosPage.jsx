import React, { useState } from 'react';
import Menu from '../../Components/Menu/index.jsx';
import Rodape from '../../Components/Rodape/index.jsx';
import Categorias from '../../Components/Categorias/Categorias.jsx';
import GraficoIngresso from '../../Components/Grafico/GraficoIngresso.jsx';
import GraficoLote from '../../Components/Grafico/GraficoLote.jsx';

const GraficosPage = () => {
    const [tipoGrafico, setTipoGrafico] = useState('lote'); 

    const handleButtonClick = (tipo) => {
        setTipoGrafico(tipo);
    };

    return(
        <>
            <Menu />
            <Categorias onButtonClick={handleButtonClick} /> 
            {tipoGrafico === 'lote' ? <GraficoLote /> : <GraficoIngresso />}
            <Rodape />
            
        </>
    );
}

export default GraficosPage;

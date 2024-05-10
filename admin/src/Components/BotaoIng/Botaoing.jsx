import React from 'react';
import './Botaoing.css';

const Botaoing = ({ onButtonClick }) => {
    return(
        <>
            <h4>Selecionar Gráfico por: </h4>
            <div>
                
                <button onClick={() => onButtonClick('lote')} className='button' style={{marginRight: '40px'}}>Lote</button>
                <button onClick={() => onButtonClick('ingresso')} className='button'>Ingresso</button>
            </div>
        </>
    );
}

export default Botaoing;

import './Botaoing.css'

const Botao = () => {
    return(
        <>
        <h4>Selecionar Gráfico por: </h4>
         <div>
            <button className='button' style={{marginRight: '40px'}}>Lote</button>
            <button className='button'>Ingresso</button>
         </div>
        </>
       
    )
}

export default Botao
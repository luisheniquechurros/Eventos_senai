import './CampoTexto.css'

const CampoTexto = (props) => {
    return(
        <div className='campo_texto'>
            <label>{props.label}
            <input name={props.nome} 
                    placeholder={props.placeholder + (props.obrigatorio ? ' *' : '')} 
                    onChange={props.onAlterar} 
                    required={props.obrigatorio} 
                    type={props.tipo}/>  
                     </label>  
        </div>
    )
}

export default CampoTexto;
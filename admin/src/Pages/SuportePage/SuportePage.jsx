import './SuportePage.css';
import Rodape from '../../Components/Rodape/index.jsx'
import Menu from '../../Components/Menu/index.jsx'
import CampoTexto from "../../Components/CampoTexto/CampoTexto.jsx"

const SuportePage = () => {
    return (
        <div>
          <Menu />
          <div className='suporte'>
            <div className='texto'>
                <textarea rows='10' placeholder='Relate o Problema.'></textarea>
            </div>
            <div className='texto-2'>
                <textarea rows='5' placeholder='Aguarde sua Resposta...'></textarea>
                <button className='botao-enviar'>Enviar</button>
            </div>
          </div>
            
          <Rodape />

        </div>
      )
}

export default SuportePage;
import './RecuperarPage.css';
import Menu from "../../Components/Menu";
import Rodape from '../../Components/Rodape'
import RecuperarSenha from '../../Components/RecuperarSenha'

const RecuperarPage = () => {
    return (
      <div>
        
        <Menu />
        <h1>Recuperar Senha</h1>
        <h3>Preencha os campos</h3>
        <RecuperarSenha/>
        <Rodape />
      </div>
    )
  }
  
  export default RecuperarPage;
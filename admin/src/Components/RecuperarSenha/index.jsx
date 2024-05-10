import './RecuperarSenha.css';
import CampoTexto from '../CampoTexto/CampoTexto.jsx';
import { Link } from 'react-router-dom';

const LoginUsuario = () => {
  const handleRegisterClick = () => {
    // Lógica para o clique no botão de cadastro
    console.log('Cadastre-se Clicado');
  };
  const handleEsqueciClick = () => {
    // Lógica para o clique no botão de cadastro
    console.log('Esqueci minha senha Clicado');
  };

  const handleLoginClick = () => {
    // Lógica para o clique no botão de entrar
    console.log('Entrar Clicado');
  };

  return (
    <>
    <form>

      <div className='email'>
        <CampoTexto placeholder="E-mail"  obrigatorio={true} tipo="email"/>
      </div>
      <div className='senha'>
        <CampoTexto placeholder="Nova Senha"  obrigatorio={true} tipo="password"/>
      </div>
      <div className='senha'>
        <CampoTexto placeholder="Confirmar Nova Senha"  obrigatorio={true} tipo="password"/>
      </div>
      
      
      <div className='entrar'>
        <button className="login-button" onClick={handleLoginClick} type='submit'>
          Mudar
        </button>
      </div>
    </form>
    </>
  );
};

export default LoginUsuario;
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { notifyError } from '../../Components/Utils/msgToast.jsx';
import Menu from '../../Components/Menu/index.jsx';
import Rodape from '../../Components/Rodape/index.jsx';

import { ToastContainer, toast } from 'react-toastify';
import CampoTexto from '../../Components/CampoTexto/CampoTexto.jsx';
import Botao from '../../Components/Botao/Botao.jsx';

const LoginPage = () => {
  const navigate = useNavigate();

  const [email, setEmail] = useState('');
  const [senha, setSenha] = useState('');    

  const getLogin = async () => {
    const credencial = {
      email: email,
      senha: senha
    };

    try {
      const response = await fetch('https://www.senailp.com.br/eventos-api/api/Usuario/login/', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(credencial)
      });
      console.log(response)

      const data = await response.json();

      localStorage.setItem('email', data.email);
      localStorage.setItem('id', data.id);
      localStorage.setItem('nomeCompleto', data.nomeCompleto);
      localStorage.setItem('perfil', data.perfil);
      localStorage.setItem('telefone', data.telefone);
      localStorage.setItem('ativo', data.ativo);

      navigate('/InicioUsuario');
    } catch (error) {
      notifyError("Usuário ou senha inválidos " + error);
      console.log('Usuário ou senha inválidos ' + error);
    }
  };

  const handleLogin = () => {
    
    if (email == '' || senha == '') {
      notifyError("Preencha todos os campos!");
      console.log('Preencha todos os campos');
    } else {
      getLogin();
    }
  };

  const onAlterar = (event) => {
    const { name, value } = event.target;

    switch (name) {
      case 'email':
        setEmail(value);
        break;
      case 'senha':
        setSenha(value);
        break;
      default:
        break;
    }
  };

  return (
    <>
      <Menu />
      <div>
        <h1>Login</h1>
        <h3>Preencha os campos</h3>
      </div>
      <CampoTexto
        placeholder="E-mail"
        nome="email"
        label=""
        obrigatorio={true}
        tipo="email"
        onAlterar={onAlterar}
     
      />
      <CampoTexto
        label=""
        placeholder="Senha"
        nome="senha"
        tipo="password"
        obrigatorio={true}
        valor={senha}
        onAlterar={onAlterar}

      />
      <div className='botao_login'>
        <Botao children="Login" onClick={handleLogin} />
      </div>
      
      <Rodape />
      <ToastContainer />
    </>
  );
};

export default LoginPage;

import './Eventos.css'
import arraiaImg from "../../assets/Images/arraia.png"
import mundosenaiImg from "../../assets/Images/mundosenai.png"
import modadigitalImg from "../../assets/Images/modadigital.png"
import { Link } from 'react-router-dom';

const Eventos = () => {

    return(
        <div className='divContainer'>

            <div className='divBox'>
                <Link to='/graficos' className='divImagem'>
                    <img src={arraiaImg} alt="imagem1"/>
                </Link>
                <div className='divTexto'>
                    <p>
                        <span style={{color:'#187ccd'}}>SAB JUN  21 - 19:00</span><br></br>
                        <b>Arraiá Do Senai</b><br></br>
                        Lençóis Paulista - SP
                    </p>
                </div>
            </div>

            <div className='divBox'>
                <Link to='/graficos' className='divImagem'>
                    <img src={mundosenaiImg} alt="imagem2"/>
                </Link>
                <div className='divTexto'>
                    <p>
                        <span style={{color:'#187ccd'}}>SEX MAI  17 - 10:00</span><br></br>
                        <b>Mundo SENAI</b><br></br>
                        Lençóis Paulista - SP
                    </p>
                </div>
            </div>

            <div className='divBox'>
                <Link to='/graficos' className='divImagem'>
                    <img src={modadigitalImg} alt="imagem3"/>
                </Link>
                <div className='divTexto'>
                    <p>
                        <span style={{color:'#187ccd'}}>SEG NOV 11 - 16:00</span><br></br>
                        <b>Inova Mundo Digital</b><br></br>
                        Lençóis Paulista - SP
                    </p>
                </div>
            </div>

        </div>
    )
}

export default Eventos
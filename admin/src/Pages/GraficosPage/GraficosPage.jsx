import './GraficosPage.css'
import Menu from '../../Components/Menu/index.jsx'
import Rodape from '../../Components/Rodape/index.jsx'
import Categorias from '../../Components/Categorias/Categorias.jsx'
import Grafico from '../../Components/Grafico/Grafico.jsx'


const GraficosPage = () => {
    return(
        <>
        <Menu />
        <Categorias />
        <Grafico />
        <Rodape />
        </>
    )
}

export default GraficosPage
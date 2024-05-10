import './DashboardPage.css';
import Menu from "../../Components/Menu";
import Eventos from '../../Components/Eventos/Eventos';
import Rodape from "../../Components/Rodape";

const DashboardPage = () => {
    return (
      <div>
        <Menu />
        <Eventos/>
        <Rodape />
      </div>
    )
  }
  
  export default DashboardPage;
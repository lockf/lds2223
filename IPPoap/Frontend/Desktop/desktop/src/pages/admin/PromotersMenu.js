import React, { Component } from "react";
import SearchBar from "../components/SearchBar.js";
import GreenAddIcon from "../components/GreenAddIcon";
import jpIMG from "../global/assets/logoIPPoap.png"; /*import da imagem de logo*/

import { Link } from "react-router-dom";
import "../global/EventStyle.css";
import "./PromotersMenuStyle.css";
import EditIcon from "@mui/icons-material/Edit";
import DeleteForeverIcon from "@mui/icons-material/DeleteForever";

export class PromotersMenu extends Component {
  /* props -> usado para passar data de um componente para outro*/
  constructor(props) {
    super(props); /* usado para aceder a informação da class mãe */
    /* contem objectos que queremos usar  */
    this.state = { promoters: [] };
  }

  componentDidMount() {
    this.refreshList();
  }

  refreshList() {
    this.setState({
      promoters: [
        {
          ID: 1,
          Promoter: "Tusa",
          email: "tusa@mail.com",
          Eventos: "2",
        },
        {
          ID: 2,
          Promoter: "AE ESTG",
          email: "aestg@aestg.ipp.pt",
          Eventos: "3",
        },
        {
          ID: 3,
          Promoter: "Informática",
          email: "informatica_aestg@email.com",
          Eventos: "6",
        },
        {
          ID: 4,
          Promoter: "Solicitadoria",
          email: "solicitadoria_aestg@email.com",
          Eventos: "1",
        },
      ],
    });
  }

  render() {
    const { promoters } = this.state;
    return (
      <div className="container-fluid">
        <div className="container-event ">
          <div className="imageContainer">
            <img src={jpIMG} alt="LogoIPPoap" />
          </div>
          <div className="header">
            <div className="header-events">
              <Link
                to="/EventMenu"
                style={{ textDecoration: "none", color: "black" }}
              >
                Eventos
              </Link>
            </div>
            <div className="header-promoters-selected">
              <Link
                to="/PromotersMenu"
                style={{ textDecoration: "none", color: "white" }}
              >
                Promotores
              </Link>
            </div>
            <div className="header-definitions">
              <Link
                to="/DefinitionMenu"
                style={{ textDecoration: "none", color: "black" }}
              >
                Definições
              </Link>
            </div>
            <div className="header-account">
              <Link
                to="/AccountMenu"
                style={{ textDecoration: "none", color: "black" }}
              >
                Conta
              </Link>
            </div>
          </div>
        </div>
        <div className="wrap-event">
          <div className="wrap-searchBar">
          <Link
              to="/CreatePromoter"
              style={{ textDecoration: "none", color: "white" }}
            ><GreenAddIcon/>
            </Link>
            <SearchBar />
          </div>
          <div className="text-events">Promotores</div>
          <div className="container-table-events">
            <table className="table-events" bordered responsive="md">
              <thead>
                <tr>
                  <th>ID</th>
                  <th>Promotor</th>
                  <th>Email</th>
                  <th>Nr de Eventos</th>
                  <th>Opções</th>
                </tr>
              </thead>
              <tbody>
                {promoters.map((promoter) => (
                  <tr key={promoter.ID}>
                    <td>{promoter.ID}</td>
                    <td>{promoter.Promoter}</td>
                    <td>{promoter.email}</td>
                    <td>{promoter.Eventos}</td>
                    <td> 
                    <Link
                      to="/CreatePromoter"
                       >
                      <EditIcon/>
                    </Link>
                    <DeleteForeverIcon/>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>

        </div>
      </div>
    );
  }
}

export default PromotersMenu;

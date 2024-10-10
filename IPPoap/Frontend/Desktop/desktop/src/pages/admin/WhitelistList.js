import React, { Component } from "react";
import "../global/EventStyle.css";
import "../admin/PromotersMenuStyle.css";
import SearchBar from "../components/SearchBar";
import GreenAddIcon from "../components/GreenAddIcon";
import "../global/ListEventsStyle.css";
import "./WhitelistListStyle.css";
import EditIcon from "@mui/icons-material/Edit";
import DeleteForeverIcon from "@mui/icons-material/DeleteForever";

import jpIMG from "../global/assets/logoIPPoap.png"; /*import da imagem de logo*/

import { Link } from "react-router-dom";

export class WhitelistList extends Component {
  /* props -> usado para passar data de um componente para outro*/
  constructor(props) {
    super(props); /* usado para aceder a informação da class mãe */
    /* contem objectos que queremos usar  */
    this.state = { events: [] };
  }

  componentDidMount() {
    this.refreshList();
  }

  refreshList() {
    this.setState({
      events: [
        {
          Name: "@estg.ipp.pt",
        },
        {
          Name: "@ese.ipp.pt",
        },
        {
          Name: "@isep.ipp.pt",
        },
      ],
    });
  }

  render() {
    const { events } = this.state;
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
            <div className="header-promoters">
              <Link
                to="/PromotersMenu"
                style={{ textDecoration: "none", color: "black" }}
              >
                Promotores
              </Link>
            </div>
            <div className="header-definitions-selected">
              <Link
                to="/DefinitionMenu"
                style={{ textDecoration: "none", color: "white" }}
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
          <Link to="/CreateWhitelist">
              <GreenAddIcon />
            </Link>
            <SearchBar />
          </div>
          <div className="text-events">
            Whitelist
          </div>
          <div className="container-table-domains">
            <table className="table-domains" bordered responsive="md">
              <thead>
                <tr>
                  <th>Domains</th>
                  <th>Opções</th>
                </tr>
              </thead>
              <tbody>
                {events.map((event) => (
                  <tr key={event.Name}>
                    <td>{event.Name}</td>
                    <td>
                      {" "}
                      <Link to="/CreateWhitelist">
                        <EditIcon />
                      </Link>
                      <DeleteForeverIcon />
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
          <div className="container-table-emails">
            <table className="table-emails" bordered responsive="md">
              <thead>
                <tr>
                  <th>Emails</th>
                            <th>Opções</th>
                </tr>
              </thead>
              <tbody>
                {events.map((event) => (
                  <tr key={event.Name}>
                    <td>{event.Name}</td>
                    <td>
                      {" "}
                      <Link to="/CreateWhitelist">
                        <EditIcon />
                      </Link>
                      <DeleteForeverIcon />
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

export default WhitelistList;

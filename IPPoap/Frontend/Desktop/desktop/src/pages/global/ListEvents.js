import React, { Component } from "react";
import "./EventStyle.css";
import "../admin/PromotersMenuStyle.css";
import SearchBar from "../components/SearchBar";
import GreenAddIcon from "../components/GreenAddIcon";
import "../global/ListEventsStyle.css";
import EditIcon from '@mui/icons-material/Edit';
import DeleteForeverIcon from '@mui/icons-material/DeleteForever';

import jpIMG from "./assets/logoIPPoap.png"; /*import da imagem de logo*/

import { Link } from "react-router-dom";


export class ListEvents extends Component {
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
          ID: 1,
          Name: "Jornadas LEI",
          Date: "22/01/2023",
          Capacity: "200/300",
        },
        {
          ID: 2,
          Name: "Festival Tunas",
          Date: "01/05/2023",
          Capacity: "100/200",
        },
        {
          ID: 3,
          Name: "Simposio Redes",
          Date: "01/03/2023",
          Capacity: "100/100",
        },
        {
          ID: 4,
          Name: "Simposio Redes",
          Date: "01/03/2023",
          Capacity: "100/100",
        },
        {
          ID: 5,
          Name: "Simposio Redes",
          Date: "01/03/2023",
          Capacity: "100/100",
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
            <div className="header-events-selected">
              <Link
                to="/EventMenu"
                style={{ textDecoration: "none", color: "white" }}
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
              to="/CreateEvent"
              style={{ textDecoration: "none", color: "white" }}
            ><GreenAddIcon/>
            </Link>
            
            <SearchBar />
          </div>
          <div className="text-events">Eventos</div>
          <div className="container-table-events">
            <table className="table-events" bordered responsive="md">
              <thead>
                <tr>
                  <th>ID Evento</th>
                  <th>Nome</th>
                  <th>Data</th>
                  <th>Lotação</th>
                  <th>Opções</th>
                </tr>
              </thead>
              <tbody>
                {events.map((event) => (
                  <tr key={event.ID}>
                    <td>{event.ID}</td>
                    <td>{event.Name}</td>
                    <td>{event.Date}</td>
                    <td>{event.Capacity}</td>
                    <td> 
                    <Link
                      to="/CreateEvent"
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

export default ListEvents;

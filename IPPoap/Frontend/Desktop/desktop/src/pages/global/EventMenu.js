import React from "react";
import "./EventStyle.css";

import jpIMG from "./assets/logoIPPoap.png"; /*import da imagem de logo*/

import { Link } from "react-router-dom";

function EventMenu() {
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
        <div className="text-events">Eventos</div>
        <div className="boxes">
          <div className="boxes-create-events">
            <Link
              to="/CreateEvent"
              style={{ textDecoration: "none", color: "white" }}
            >
              Criar Evento
            </Link>
          </div>
          <div className="boxes-empty"></div>
          <div className="boxes-list-events">
            <Link
              to="/ListEvents"
              style={{ textDecoration: "none", color: "white" }}
            >
              Listar Eventos
            </Link>
          </div>
        </div>
      </div>
    </div>
  );
}

export default EventMenu;

import React from "react";
import "./EventStyle.css";
import "./DefinitionStyle.css";

import jpIMG from "./assets/logoIPPoap.png";

import { Link } from "react-router-dom";

function DefinitionMenu() {
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
        <div className="text-events">Definições</div>
        <div className="boxes">
          <div className="boxes-whitelist"><Link
              to="/WhitelistList"
              style={{ textDecoration: "none", color: "white" }}
            >
              Whitelist
            </Link></div>
          <div className="boxes-empty"></div>
          <div className="boxes-types"><Link
              to="/EventTypes"
              style={{ textDecoration: "none", color: "white" }}
            >
              Tipos
            </Link></div>
          <div className="boxes-empty"></div>
          <div className="boxes-groups"><Link
              to="/Groups"
              style={{ textDecoration: "none", color: "white" }}
            >
              Grupos
            </Link></div>
        </div>
      </div>
    </div>
  );
}

export default DefinitionMenu;

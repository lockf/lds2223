import React from "react";
import "../global/EventStyle.css";
import "../global/CreateEventStyle.css";
import jpIMG from "../global/assets/logoIPPoap.png"; /*import da imagem de logo*/
import { Link } from "react-router-dom";


function CreateGroup() {
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
        <div className="text-events">Grupos</div>
        <form>
          <div class="form-row">
            <div class="form-group1 col-md-4">
              <label for="Groups"></label>
              <input
                type="text"
                class="form-control"
                id="Groups"
                placeholder="Inserir"
              />
            </div>
          </div>

          <div class="form-row">
          <button type="button" class="btn-submit">
            <Link
              to="/Groups"
              style={{ textDecoration: "none", color: "Black" }}
            >
              Cancelar
            </Link>
          </button>

          <button type="button" class="btn-submit">
            <Link
              to="/Groups"
              style={{ textDecoration: "none", color: "Black" }}
            >
              Confirmar
            </Link>
          </button>
          </div>
        </form>
      </div>
    </div>
  );
}

export default CreateGroup;

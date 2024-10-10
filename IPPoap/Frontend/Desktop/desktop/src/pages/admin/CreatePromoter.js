import React from "react";
import "../global/EventStyle.css";
import "../global/CreateEventStyle.css";
import jpIMG from "../global/assets/logoIPPoap.png"; /*import da imagem de logo*/
import { Link } from "react-router-dom";
import { useState } from "react";

function CreatePromoter() {
  const [selectedDate, setSelectedDate] = useState(null);
  const [selectedTime, setSelectedTime] = useState(null);

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
        <div className="text-events">Promotor </div>
        <form>
          <div class="form-row">
            <div class="form-group1 col-md-4">
              <label for="Nome">Email: </label>
              <input
                type="email"
                class="form-control"
                id="emailPromotor"
                placeholder="email"
              />
            </div>
          </div>
          <div class="form-row">
          <button type="button" class="btn-submit">
            <Link
              to="/PromotersMenu"
              style={{ textDecoration: "none", color: "Black" }}
            >
              Cancelar
            </Link>
          </button>
          
          <button type="button" class="btn-submit">
            <Link
              to="/PromotersMenu"
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

export default CreatePromoter;

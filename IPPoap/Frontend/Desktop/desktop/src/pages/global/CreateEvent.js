import React from "react";
import "./EventStyle.css";
import "./CreateEventStyle.css";
import Form from "react-bootstrap/Form";
import jpIMG from "./assets/logoIPPoap.png"; /*import da imagem de logo*/
import { Link } from "react-router-dom";
import { useState } from "react";

function DropMenuEventTypes() {
  return (
    <Form.Select aria-label="Tipo de Evento">
      <option>Tipo de Evento</option>
      <option value="1">Académico</option>
      <option value="2">Lazer</option>
      <option value="3">Cientifico</option>
    </Form.Select>
  );
}

function DropMenuEventState() {
  return (
    <Form.Select aria-label="Estado do Evento">
      <option>Estado do Evento</option>
      <option value="1">Confirmado</option>
      <option value="2">Por Confirmar</option>
    </Form.Select>
  );
}

function CreateEvent() {
  const [selectedDate, setSelectedDate] = useState(null);
  const [selectedTime, setSelectedTime] = useState(null);

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
        <div className="text-events">Evento</div>
        <form>
          <div class="form-row">
            <div class="form-group1 col-md-3">
              <label for="Nome">Nome: </label>
              <input
                type="text"
                class="form-control"
                id="nome"
                placeholder="Nome"
              />
            </div>
            <div class="form-group2 col-md-3">
              <label for="Organizador">Organizador: </label>
              <input
                type="text"
                class="form-control"
                id="organizador"
                placeholder="Organizador"
              />
            </div>
            <div class="form-group3 col-md-3">
              <label for="local">Local: </label>
              <input
                type="text"
                class="form-control"
                id="local"
                placeholder="Local"
              />
            </div>
            <div class="form-group4 col-md-3">
              <label for="eventDate"> Date: </label>
              <input
                type="date"
                class="date"
                id="eventDate"
                placeholder="Data"
                value={selectedDate}
                onChange={(e) => setSelectedDate(e.target.value)}
              />
            </div>

          </div>

          <div class="form-row">
          <div class="form-group1 col-md-3">
              <label for="description">Descrição: </label>
              <input
                type="text"
                class="form-control"
                id="description"
                placeholder="Descrição"
              />
            </div>
            <div class="form-group2 col-md-3">
              <label for="state">Tipo: </label>
              <DropMenuEventTypes />
            </div>
            <div class="form-group3 col-md-3">
              <label for="state">Estado: </label>
              <DropMenuEventState />
            </div>
            <div class="form-group4 col-md-3">
              <label for="time">Hora: </label>
              <input
                type="timestamp"
                class="timestamp"
                id="eventTime"
                placeholder="HH:MM"
                value={selectedTime}
                onChange={(e) => setSelectedTime(e.target.value)}
              />
            </div>
          </div>

          <div class="form-row">
            <div class="form-group1 col-md-3">
              <label for="capacity">Lotação: </label>
              <input
                type="text"
                class="form-control"
                id="capacity"
                placeholder="Lotação"
              />
            </div>
            
            <div class="form-group2 col-md-3">
              <label class="form-label" for="eventFoto">
                Imagem do Evento: </label>
              <input type="file" class="form-control" id="addEventFoto" />
            </div>
            <div class="form-group3 col-md-3">
              <label class="form-label" for="poapFoto">
                Poap Participante: </label>
              <input type="file" class="form-control" id="addPoapFoto" />
            </div>
            <div class="form-group4 col-md-2">
              <label for="quantity">Quantidade: </label>
              <input
                type="text"
                class="form-control"
                id="quantity"
                placeholder="Quantidade"
              />
            </div>
          </div>

          <div class="form-row">
            <div class="form-check">
              <input class="form-check-input" type="checkbox" id="gridCheck" />
              <label class="form-check-label" for="gridCheck">
                Organizador 
              </label>
            </div>
            <div class="form-check">
            <label class="form-label" for="poapOrganizer">
                Poap Organizador: </label>
              <input type="file" class="form-control" id="addPoapOrganizer" />
            </div>
          </div>

          <button type="submit" class="btn-submit">
          <Link
              to="/ListEvents"
              style={{ textDecoration: "none", color: "Black" }}
            >
              Finalizar
            </Link>
          </button>
        </form>
      </div>
    </div>
  );
}

export default CreateEvent;

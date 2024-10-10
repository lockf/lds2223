import React from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import { useState } from 'react';
import { Link } from "react-router-dom";
import "./MessagePromoterCreatedStyle.css"


function MessagePromoterCreated() {
  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  return (
    <>
      <Button variant="primary" onClick={handleShow}>
        Launch static backdrop modal
      </Button>

      <Modal
        show={show}
        onHide={handleClose}
        backdrop="static"
        keyboard={false}
      >
        <Modal.Header closeButton>
          <Modal.Title>Promotor Criado</Modal.Title>
        </Modal.Header>
        <Modal.Body>
         Seja bem vindo à LogoIPPoap
         Aceda ao link com as seguintes credenciais:
         Email: promotor@email.com
         Password: PaSSword123
        </Modal.Body>
        <Modal.Footer>
          <Button variant="primary"
          ><Link
              to="/PromotersMenu"
              style={{ textDecoration: "none", color: "Black" }}
            >
              Confirmar
            </Link></Button>
        </Modal.Footer>
      </Modal>
    </>
  );
}

export default MessagePromoterCreated;
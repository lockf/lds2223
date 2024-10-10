import React from "react";
import jpIMG from "../global/assets/logoIPPoap.png"; /*import da imagem de logo*/
import { Link } from "react-router-dom";
import "../global/EventStyle.css";
import "./AccountStyle.css";
import "./DefinitionStyle.css";
import "./ListEventsStyle.css";
import "./EventStyle.css";
import "../admin/PromotersMenuStyle.css";
import EditIcon from "@mui/icons-material/Edit";
import PopUp from "../components/PopUpPassEdit";
import { useState } from "react";

function AccountMenu({ placeholder /*, data*/ }) {
  const [buttonPopUp, setButtonPopUp] = useState(false);
  const [password, setPassword] = useState();
  const [confirmPassword, setConfirmPassword] = useState();

  const [errorMessage, setErrorMessage] = useState(null);
  const [defaultAccount, setDefaultAccount] = useState(null);
  const [userBalance, setUserBalance] = useState(null);
  const [connButtonText, setConnButtonText] = useState("Connect Wallet");

  const connectWalletHandler = () => {
    if (window.ethereum && window.ethereum.isMetaMask) {
      console.log("MetaMask Here!");

      window.ethereum
        .request({ method: "eth_requestAccounts" })
        .then((result) => {
          accountChangedHandler(result[0]);
          setConnButtonText("Wallet Connected");
        })
        .catch((error) => {
          setErrorMessage(error.message);
        });
    } else {
      console.log("Need to install MetaMask");
      setErrorMessage("Please install MetaMask browser extension to interact");
    }
  };

  // update account, will cause component re-render
  const accountChangedHandler = (newAccount) => {
    setDefaultAccount(newAccount);
  };

  const chainChangedHandler = () => {
    // reload the page to avoid any errors with chain change mid use of application
    window.location.reload();
  };

  // listen for account changes
  window.ethereum.on("accountsChanged", accountChangedHandler);

  window.ethereum.on("chainChanged", chainChangedHandler);

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
          <div className="header-definitions">
            <Link
              to="/DefinitionMenu"
              style={{ textDecoration: "none", color: "black" }}
            >
              Definições
            </Link>
          </div>
          <div className="header-account-selected">
            <Link
              to="/AccountMenu"
              style={{ textDecoration: "none", color: "white" }}
            >
              Conta
            </Link>
          </div>
        </div>
      </div>
      <div className="wrap-event">
        <div className="text-events">Conta</div>
        <div className="container-table-events">
          <table className="table-events" bordered responsive="md">
            <thead>
              <tr>
                <th>Dados de Conta</th>
                <th></th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>Email</td>
                <td>aeestg.ipp.pt</td>
                <td> </td>
              </tr>
              <tr>
                <td>Password</td>
                <td>**********</td>
                <td>
                  <EditIcon onClick={() => setButtonPopUp(true)} />
                </td>
              </tr>
              <tr>
                <td>Conta Metamask</td>
                <td>{defaultAccount}</td>
                <td><button type="button" class="btn btn-danger" onClick={connectWalletHandler}>{connButtonText}</button> </td>
              </tr>
            </tbody>
          </table>
        </div>
        <div className="logoutButton">
          <Link
            to="/"
            style={{ textDecoration: "none", color: "white", align: "center" }}
          >
            <button className="logout-form-btn">LOGOUT</button>
          </Link>
        </div>
      </div>
      <PopUp trigger={buttonPopUp} setTrigger={setButtonPopUp}>
        <h3>Alterar Password</h3>
        <input
          className={password !== "" ? "has-val input" : "input"}
          type="password"
          placeholder="Nova Password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        ></input>
        <br></br>
        <input
          className={confirmPassword !== "" ? "has-val input" : "input"}
          type="password"
          placeholder="Repetir Password"
          value={confirmPassword}
          onChange={(e) => setConfirmPassword(e.target.value)}
        ></input>
      </PopUp>
    </div>
  );
}

export default AccountMenu;

import "./LoginStyles.css"; /*import do css*/
import React from "react";

import jpIMG from "./assets/logoIPPoap.png"; /*import da imagem de logo*/
import { Link } from "react-router-dom";

import { useState } from "react";

function CreateAccount() {
  /*criar um estado para o email*/
  const [email, setEmail] = useState();
  const [password, setPassword] = useState();
  const [confirmPassword, setConfirmPassword] = useState();
  const [wallet, setWallet] = useState();

  return (
    <div className="container-fluid">
      <div className="container-login">
        <div className="imageContainer">
          <img src={jpIMG} alt="LogoIPPoap" />
        </div>
        <div className="wrap-login">
          <form className="login_form">
            <span className="login-form-title"></span>
            <span className="login-form-title"> Sign In</span>
            <div className="wrap-input">
              <input
                className={
                  email !== "" ? "has-val input" : "input"
                } /*condição ternaria, se dentro do email for diferente de vazio, 
                adiciono 'has value input', se tiver vazio, a class é 'input' */
                type="email"
                value={email} /*atribuir valor ao email*/
                onChange={(e) =>
                  setEmail(e.target.value)
                } /*capturar valor da variavel*/
              ></input>
              <span className="focus-input" data-placeholder="Email"></span>
            </div>

            <div className="wrap-input">
              <input
                className={password !== "" ? "has-val input" : "input"}
                type="password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
              ></input>
              <span className="focus-input" data-placeholder="Password"></span>
            </div>

            <div className="wrap-input">
              <input
                className={confirmPassword !== "" ? "has-val input" : "input"}
                type="password"
                value={confirmPassword}
                onChange={(e) => setConfirmPassword(e.target.value)}
              ></input>
              <span
                className="focus-input"
                data-placeholder="Confirm Password"
              ></span>
            </div>

            <div className="wrap-input">
              <input
                className={wallet !== "" ? "has-val input" : "input"}
                type="wallet"
                value={wallet}
                onChange={(e) => setWallet(e.target.value)}
              ></input>
              <span className="focus-input" data-placeholder="Wallet"></span>
            </div>

            <div className="container-login-form-btn">
              <Link to ="/EventMenu" style={{ textDecoration:'none' }}>
              <button className="login-form-btn">Continue</button>
              </Link>
            </div>

            <div className="text-admin-promotor">
              <span className="textAdminPromotor"> For Participants</span>
            </div>

            <div className="text-sign-up">
              <div className="textSignUp">
                <Link to="/" style={{ textDecoration:'none', color: 'black' }}>Sign In</Link>
              </div>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
}

export default CreateAccount;

import "./LoginStyles.css"; /*import do css*/
import React from 'react';

import jpIMG from "./assets/logoIPPoap.png"; /*import da imagem de logo*/
import { Link } from "react-router-dom";
import { useState } from "react";

function Login() {
  /*criar um estado para o email*/
  const [email, setEmail] = useState();
  const [password, setPassword] = useState();

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
                className={
                  password !== "" ? "has-val input" : "input"
                }
                type="password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
              ></input>
              <span className="focus-input" data-placeholder="Password"></span>
            </div>

            <div className="container-login-form-btn">
              <Link to ="/EventMenu" style={{ textDecoration:'none' }}>
              <button className="login-form-btn">Sign In</button>
              </Link>
            </div>

            <div className="text-admin-promotor">
              <span className="textAdminPromotor"> For Admin and Manager</span>
            </div>

            <div className="text-sign-up">
              <div className="textSignUp">
                <Link to="/CreateAccount" style={{ textDecoration:'none', color: '#f85f6a' }}>Sign Up</Link>
              </div>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
}

export default Login;
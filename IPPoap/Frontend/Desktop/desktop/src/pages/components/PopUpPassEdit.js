import React from "react";
import "./PopUpPassEditStyle.css"

function PopUpPassEdit(props){
    /*trigger é um boolean*/
    return(props.trigger) ? (
        <div className="popup">
            <div className="popup-inner">
                <button className="cancel-btn" onClick={() => props.setTrigger(false)}>
                    Cancelar
                </button>
                <button className="confirm-btn" onClick={() => props.setTrigger(false)}>
                    Confirmar
                </button>
                {props.children}
            </div>
        </div>
    ) :"";
}

export default PopUpPassEdit;
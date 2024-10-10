import React, { useState } from 'react';
import { IonInput,IonCard, IonItem, IonLabel, IonList, IonButton, IonNote } from '@ionic/react';
import ExploreContainer from '../components/ExploreContainer';
import { IonContent, IonHeader, IonPage, IonTitle, IonToolbar } from '@ionic/react';
import './Login.css';

const Login: React.FC = () => {
    const [isTouched, setIsTouched] = useState(false);
    const [isValid, setIsValid] = useState<boolean>();
  
    const validateEmail = (email: string) => {
      return email.match(
        /^(?=.{1,254}$)(?=.{1,64}@)[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/
      );
    };
  
    const validate = (ev: Event) => {
      const value = (ev.target as HTMLInputElement).value;
  
      setIsValid(undefined);
  
      if (value === '') return;
  
      validateEmail(value) !== null ? setIsValid(true) : setIsValid(false);
    };
  
    const markTouched = () => {
      setIsTouched(true);
    };
    return (
      <IonContent className="content">
        <IonCard className="change">
                <IonList class="input">
                  <h1 className="header">IPPOAP</h1>
                    <IonItem fill="solid" className={`${isValid && 'ion-valid'} ${isValid === false && 'ion-invalid'} ${isTouched && 'ion-touched'}`}>
                        <IonLabel position="floating">Email</IonLabel>
                        <IonInput type="email" onIonInput={(event) => validate(event)} onIonBlur={() => markTouched()}></IonInput>
                        <IonNote slot="helper">Enter a valid email</IonNote>
                        <IonNote slot="error">Invalid email</IonNote>
                    </IonItem>
                    <IonItem fill="solid">
                        <IonLabel position="floating">Password</IonLabel>
                        <IonInput type="password"></IonInput>
                    </IonItem>
                    <IonButton class="login-btn" href="/home">Login</IonButton>
                    <IonButton class="signin-btn" href="/signin">Sign in</IonButton>
                    </IonList>
                  </IonCard>
              </IonContent>
    );
}
export default Login;
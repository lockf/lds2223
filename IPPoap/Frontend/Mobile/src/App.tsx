import { Redirect, Route } from 'react-router-dom';
import {
  IonApp,
  IonButton,
  IonContent,
  IonIcon,
  IonInput,
  IonItem,
  IonLabel,
  IonList,
  IonModal,
  IonNote,
  IonRouterOutlet,
  IonTabBar,
  IonTabButton,
  IonTabs,
  IonCard,
  setupIonicReact
} from '@ionic/react';
import { IonReactRouter } from '@ionic/react-router';
import { ellipse, calendar, home, person, add } from 'ionicons/icons';
import Home from './pages/Home';
import User from './pages/User';
import Events from './pages/Events';
import Poaps from './pages/Poaps';

/* Core CSS required for Ionic components to work properly */
import '@ionic/react/css/core.css';

/* Basic CSS for apps built with Ionic */
import '@ionic/react/css/normalize.css';
import '@ionic/react/css/structure.css';
import '@ionic/react/css/typography.css';

/* Optional CSS utils that can be commented out */
import '@ionic/react/css/padding.css';
import '@ionic/react/css/float-elements.css';
import '@ionic/react/css/text-alignment.css';
import '@ionic/react/css/text-transformation.css';
import '@ionic/react/css/flex-utils.css';
import '@ionic/react/css/display.css';

/* Theme variables */
import './theme/variables.css';
import ReedemPoap from './pages/ReedemPoap';
import ChangeWallet from './pages/ChangeWallet';
import ChangePassword from './pages/ChangePassword';
import Login from './pages/Login';
import { useState } from 'react';
import Signin from './pages/Signin';

setupIonicReact();

const App: React.FC = () => {
  
  const [loginModal, setloginModal] = useState({ isOpen: true });


return(
<IonApp>
      <LoginModal
        isOpen={loginModal.isOpen}
        onClose={() => setloginModal({ isOpen: false })}
      ></LoginModal> 
    <IonReactRouter>
      <IonTabs>
        <IonRouterOutlet>
          <Route exact path="/home">
            <Home />
          </Route>
          <Route exact path="/user">
            <User />
          </Route>
          <Route path="/events">
            <Events />
          </Route>
          <Route exact path="/poaps">
          <Poaps />
          </Route>
          <Route exact path="/redeemPoap">
          <ReedemPoap />
          </Route>
          <Route exact path="/changeWallet">
          <ChangeWallet />
          </Route>
          <Route exact path="/signin">
          <Signin />
          </Route>
          <Route exact path="/changePassword">
          <ChangePassword />
          </Route>
          <Route exact path="/">
            <Redirect to="/home"/>
          </Route>
        </IonRouterOutlet>
        <IonTabBar slot="bottom">
          <IonTabButton tab="tab1" href="/home">
            <IonIcon icon={home} />
            <IonLabel>Home</IonLabel>
          </IonTabButton>
          <IonTabButton tab="tab2" href="/user">
            <IonIcon icon={person} />
            <IonLabel>User</IonLabel>
          </IonTabButton>
          <IonTabButton tab="tab3" href="/events">
            <IonIcon icon={calendar} />
            <IonLabel>Events</IonLabel>
          </IonTabButton>
          <IonTabButton tab="tab4" href="/poaps">
            <IonIcon icon={add} />
            <IonLabel>Poaps</IonLabel>
          </IonTabButton>
        </IonTabBar>
      </IonTabs>
    </IonReactRouter>
  </IonApp>
)
};

export default App;

const LoginModal: React.FunctionComponent<any> = ({ isOpen, onClose, isOpened }) => {
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
    <IonModal isOpen={isOpen}>
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
                    <IonButton onClick={onClose} class="login-btn" >Login</IonButton>
                    <IonButton onClick={onClose} class="signin-btn" >Sign in</IonButton>
                    </IonList>
                  </IonCard>
              </IonContent>
    </IonModal>
  );
};

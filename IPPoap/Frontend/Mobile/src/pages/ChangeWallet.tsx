import { IonItem,IonButton,IonInput,IonContent, IonHeader, IonPage, IonTitle, IonToolbar } from '@ionic/react';
import ExploreContainer from '../components/ExploreContainer';
import './ChangeWallet.css';

const ChangeWallet: React.FC = () => {
  return (
    <IonPage>
       <IonContent fullscreen>
        <IonHeader collapse="condense">
          <IonToolbar>
            <IonTitle><img width="22%" height="20%" src="https://cdn.discordapp.com/attachments/1030429153415155780/1045648139165638706/logo200.png" /></IonTitle>
          </IonToolbar>
        </IonHeader>
        <h3 className="poaps-title">Change Wallet</h3>
        <div className="divStyle">
        <IonItem className="item-wallet">
        <IonInput placeholder="Metamask account"></IonInput>
        </IonItem>
        <IonButton className="buttonWalltet" routerLink="/user"> Submit</IonButton>
        </div>
      </IonContent>
    </IonPage>
  );
};

export default ChangeWallet;

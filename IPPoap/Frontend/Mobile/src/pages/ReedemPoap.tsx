import { IonItem,IonButton,IonInput,IonContent, IonHeader, IonPage, IonTitle, IonToolbar } from '@ionic/react';
import ExploreContainer from '../components/ExploreContainer';
import './ReedemPoap.css';

const ReedemPoap: React.FC = () => {
  return (
    <IonPage>
       <IonContent fullscreen>
        <IonHeader collapse="condense">
          <IonToolbar>
            <IonTitle><img width="22%" height="20%" src="https://cdn.discordapp.com/attachments/1030429153415155780/1045648139165638706/logo200.png" /></IonTitle>
          </IonToolbar>
        </IonHeader>
        <h3 className="poaps-title">Redeem Poap</h3>
        <IonItem className="item-redeem">
        <IonInput placeholder="Code"></IonInput>
        </IonItem>
        <IonButton className="buttonReedem" routerLink="/home"> Submit</IonButton>
      </IonContent>
    </IonPage>
  );
};

export default ReedemPoap;

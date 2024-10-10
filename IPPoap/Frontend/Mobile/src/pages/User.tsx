import {IonList,IonLabel,IonItem,IonButton, IonAvatar, IonContent, IonHeader, IonPage, IonTitle, IonToolbar, IonIcon, useIonActionSheet } from '@ionic/react';
import ExploreContainer from '../components/ExploreContainer';
import './User.css';
import { lockClosed, wallet} from 'ionicons/icons';
import type { OverlayEventDetail } from '@ionic/core';
import { useState } from 'react';
const User: React.FC = () => {
  const [present] = useIonActionSheet();
  const [result, setResult] = useState<OverlayEventDetail>();
  return (
    <IonPage>
       <IonContent fullscreen>
        <IonHeader collapse="condense">
          <IonToolbar>
            <IonTitle><img width="22%" height="20%" src="https://cdn.discordapp.com/attachments/1030429153415155780/1045648139165638706/logo200.png" /></IonTitle>
          </IonToolbar>
        </IonHeader>
        <h3 className="poaps-title">User</h3>
      <IonItem className="style">
       <IonAvatar>
        <img alt="Silhouette of a person's head" src="https://ionicframework.com/docs/img/demos/avatar.svg" />
      </IonAvatar>
      </IonItem>
      <IonItem routerLink="/changePassword">
        <IonIcon icon={lockClosed} slot="start"></IonIcon>
        <IonLabel>Change Password</IonLabel>
        </IonItem>
        <IonItem routerLink="/changeWallet">
        <IonIcon icon={wallet} slot="start"></IonIcon>
        <IonLabel>Change Metamask account</IonLabel>
        </IonItem>

        <IonButton
        onClick={() =>
          present({
            header: 'Logout',
            subHeader: 'Are you sure you want to logout?',
            buttons: [
              {
                text: 'Yes',
                role: 'destructive',
                data: {
                  action: 'logout',
                },
              },
              {
                text: 'No',
                data: {
                  action: '',
                },
              },
              {
                text: 'Cancel',
                role: 'cancel',
                data: {
                  action: 'cancel',
                },
              },
            ],
            onDidDismiss: ({ detail }) => setResult(detail),
          })
        } className="logout-btn"
      >
        Logout
      </IonButton>
      
      </IonContent>
    </IonPage>
  );
};

export default User;

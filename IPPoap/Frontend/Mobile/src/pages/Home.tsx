import { IonContent,IonModal,IonButton,IonList,IonItem,IonThumbnail,IonLabel,IonMenuButton,IonButtons,IonMenu , IonHeader, IonPage, IonTitle, IonToolbar, IonCard, IonCardContent, IonCardHeader, IonCardSubtitle, IonCardTitle, IonIcon, IonMenuToggle} from '@ionic/react';
import ExploreContainer from '../components/ExploreContainer';
import { key, qrCode} from 'ionicons/icons';

import { useRef } from 'react';
import './Home.css';


const Home: React.FC = () => {
  const modal = useRef<HTMLIonModalElement>(null);
  function dismiss() {
    modal.current?.dismiss();
  }
  return (
    <>
       <IonMenu contentId="main-content">
        <IonHeader>
          <IonToolbar>
            <IonTitle>Welcome</IonTitle>
          </IonToolbar>
        </IonHeader>
        <IonContent className="ion-padding">
        <IonItem routerLink="#">
          <IonLabel>Scan QR</IonLabel>
          <IonIcon icon={qrCode} slot="end"></IonIcon>
        </IonItem>
        <IonItem routerLink="/redeemPoap">
          <IonLabel>Redeem Poap</IonLabel>
          <IonIcon icon={key} slot="end"></IonIcon>
        </IonItem>
        </IonContent>
      </IonMenu>
      <IonPage id="main-content">
     <IonContent fullscreen>
     <IonHeader collapse="condense">
          <IonToolbar>
           <IonTitle><img width="22%" height="20%" src="https://cdn.discordapp.com/attachments/1030429153415155780/1045648139165638706/logo200.png" /></IonTitle>
            <IonButtons slot="end">
              <IonMenuButton></IonMenuButton>
            </IonButtons>
          </IonToolbar>
        </IonHeader>
      
      <h3 className="events-title">New Events</h3>
      <IonCard>
      <IonCardHeader>
        <IonCardTitle>16/12</IonCardTitle>
        <IonCardSubtitle>This Month</IonCardSubtitle>
      </IonCardHeader>
      <IonCardContent>
        <IonList>
          <IonItem>
            <IonThumbnail slot="start">
              <img src="https://images.unsplash.com/photo-1549488497-94b52bddac5d?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=2070&q=80"/>
            </IonThumbnail>
            <IonLabel>Bride to be</IonLabel>
            <IonButton id="open-modal" expand="block">
              See details
            </IonButton>
          <IonModal id="example-modal" ref={modal} trigger="open-modal">
          <IonContent>
            <IonToolbar>
              <IonTitle>Bride To Be</IonTitle>
                <IonButtons slot="end">
                  <IonButton color="light" onClick={() => dismiss()}>
                    Close
                  </IonButton>
              </IonButtons>
            </IonToolbar>
            <img src="https://images.unsplash.com/photo-1549488497-94b52bddac5d?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=2070&q=80"/>
            <h5 className="modaltext"> A event where you see the beautiful brides out there</h5>
            <h5 className="modaltext"> Starts at 20:00h</h5>
          </IonContent>
          </IonModal>
          </IonItem>

          <IonItem>
            <IonThumbnail slot="start">
              <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSfpjgLvKfZN3cS1pKHIYFTbtTaGoqgK-1qHIkMj5zG4qPq0EoRYPZy28aVtT_wv0kl1Q8&usqp=CAU" />
            </IonThumbnail>
            <IonLabel>IPP Masters</IonLabel>
            <IonButton id="open-modal" expand="block">
              See details
            </IonButton>

          </IonItem>
        </IonList>
      </IonCardContent>
    </IonCard>

    <h3 className="events-title">Upcoming Event</h3>

    <IonCard>
      <img width="100%" height="60%" src="https://images.unsplash.com/photo-1451772741724-d20990422508?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=2070&q=80" />
      <IonCardHeader>
        <IonCardTitle>Christmas Quiz</IonCardTitle>
        <IonCardSubtitle>25/12</IonCardSubtitle>
      </IonCardHeader>

      <IonCardContent>
        A quiz for the bests
      </IonCardContent>
    </IonCard>
    </IonContent>
    </IonPage>
    </>
  );
};

export default Home;

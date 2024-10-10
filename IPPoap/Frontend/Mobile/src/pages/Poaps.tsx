import { IonItem,IonContent,IonButton,IonGrid,IonCol,IonRow,IonCardSubtitle,IonCardTitle,IonCard,IonCardContent,IonCardHeader, IonHeader, IonPage, IonTitle, IonToolbar, IonModal, IonButtons, IonThumbnail } from '@ionic/react';
import ExploreContainer from '../components/ExploreContainer';
import './Poaps.css';

import { useRef, useState } from 'react';

const Poaps: React.FC = () => {
  const singledata = { title: 'Teste', event:'event1', img: 'https://events.org/images/about_promote.jpg' }
  const data = [
    {title:'Poap 1',event:'Event1',img:'https://classic.exame.com/wp-content/uploads/2021/12/BAYCcortado.png?w=723'},
   { title:'Poap 2',event:'Event2',img:'https://i.guim.co.uk/img/media/ef8492feb3715ed4de705727d9f513c168a8b196/37_0_1125_675/master/1125.jpg?width=1200&height=900&quality=85&auto=format&fit=crop&s=cb647d991d8897cc8a81d2c33c4406d5'},
   { title:'Poap 3',event:'Event3',img:'https://media.moneytimes.com.br/uploads/2022/03/bored-ape-yacht-club-835.jpg'},
    {title:'Poap 4',event:'Event4',img:'https://www.cointribune.com/app/uploads/2021/09/bayc2.jpg?nowebp'},
   { title:'Poap 5',event:'Event5',img:'https://conteudo.imguol.com.br/c/noticias/74/2022/06/06/bored-ape-nft-que-integra-a-colecao-do-bored-ape-yacht-club-1654521934017_v2_4x3.jpg'}
];

  let [results, setResults] = useState([...data]);

  const [selected, setSelected] = useState(singledata)

  const [isOpen, setIsOpen] = useState(false);
  
  return (
    <IonPage>
     <IonContent fullscreen>
        <IonHeader collapse="condense">
          <IonToolbar>
            <IonTitle><img width="22%" height="20%" src="https://cdn.discordapp.com/attachments/1030429153415155780/1045648139165638706/logo200.png" /></IonTitle>
          </IonToolbar>
        </IonHeader>
        <h3 className="poaps-title">Poaps Redimidos</h3>
    <IonContent>
     <IonGrid>
        <IonRow>
        {data.map(data =>
          <IonCol size="4">
          <IonThumbnail onClick={() => { setIsOpen(true); setSelected(data) }}>
                <img className="poapsIMG" src={data.img} />
          </IonThumbnail>
          </IonCol>         
        )}
        </IonRow>
      </IonGrid>
      </IonContent>
      <IonModal isOpen={isOpen}>
      
          <IonHeader>
            <IonToolbar>
              <IonTitle>{selected.title}</IonTitle>
              <IonButtons slot="end">
                <IonButton onClick={() => setIsOpen(false)}>Close</IonButton>
              </IonButtons>
            </IonToolbar>
          </IonHeader>
          <IonContent className="ion-padding">
            <div className="align_thumbnail">
            
          <IonThumbnail>
                <img onClick={() => setIsOpen(true)} className="poapsIMG" src={selected.img}/>
          </IonThumbnail>
            </div>
            <h3>{selected.event}</h3>
            <p>
          Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
          </p>
          </IonContent>
        </IonModal>
      </IonContent>
    </IonPage>
  );
};

export default Poaps;



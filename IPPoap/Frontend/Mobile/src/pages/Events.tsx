import { IonThumbnail, IonList, IonItem, IonSearchbar, IonCardSubtitle, IonCardTitle, IonCardContent, IonCardHeader, IonContent, IonHeader, IonPage, IonTitle, IonToolbar, IonModal, IonButtons, IonButton, IonRow, IonProgressBar } from '@ionic/react';
import './Events.css';
import { useRef, useState } from 'react';
import { GoogleMap } from '@capacitor/google-maps';

const Events: React.FC = () => {
  const singledata = { title: 'Teste', type: '', manager: '', hour: '', ocupied: 190, capacity: 1, local: '', description: '', img: 'https://events.org/images/about_promote.jpg' }
  const data = [
    { title: 'Event1', type: 'Type1', manager: 'Manager1', hour: '12:40', ocupied: 190, capacity: 200, local: 'Porto', description: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Magni illum quidem recusandae ducimus quos reprehenderit. Veniam, molestias quos, dolorum consequuntur nisi deserunt omnis id illo sit cum qui.Eaque, dicta.', img: 'https://events.org/images/about_promote.jpg' },
    { title: 'Event2', type: 'Type2', manager: 'Manager2', hour: '12:40', ocupied: 90, capacity: 100, local: 'Lisboa', description: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Magni illum quidem recusandae ducimus quos reprehenderit. Veniam, molestias quos, dolorum consequuntur nisi deserunt omnis id illo sit cum qui.Eaque, dicta.', img: 'https://about-events.com/wp-content/uploads/2020/08/slider-events.jpg' },
    { title: 'Event3', type: 'Type3', manager: 'Manager3', hour: '12:40', ocupied: 24, capacity: 200, local: 'Aveiro', description: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Magni illum quidem recusandae ducimus quos reprehenderit. Veniam, molestias quos, dolorum consequuntur nisi deserunt omnis id illo sit cum qui.Eaque, dicta.', img: 'https://www.bmi.bund.de/SharedDocs/bilder/DE/schmuckbilder/service/veranstaltungen/events-01.jpg?__blob=poster&v=4' },
    { title: 'Event4', type: 'Type4', manager: 'Manager4', hour: '12:40', ocupied: 190, capacity: 330, local: 'Braga', description: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Magni illum quidem recusandae ducimus quos reprehenderit. Veniam, molestias quos, dolorum consequuntur nisi deserunt omnis id illo sit cum qui.Eaque, dicta.', img: 'https://ngobox.org/news/Event-Management-Proposal-Hire4event.jpg' }];
  let [results, setResults] = useState([...data]);

  const [selected, setSelected] = useState(singledata)

  //Modal
  const [isOpen, setIsOpen] = useState(false);



  const mapRef = useRef<HTMLElement>();
  let newMap: GoogleMap;

  async function createMap() {
    if (!mapRef.current) return;

    newMap = await GoogleMap.create({
      id: 'my-cool-map',
      element: mapRef.current,
      apiKey: "AIzaSyBC1_e1gLoUudSGXiCXKHRMjw_i1M4cOlY",
      config: {
        center: {
          lat: 33.6,
          lng: -117.9
        },
        zoom: 8
      }
    })
  }

  const handleChange = (ev: Event) => {
    let query = "";
    const target = ev.target as HTMLIonSearchbarElement;
    if (target) query = target.value!.toLowerCase();
    setResults(data.filter(d => d.title.toLowerCase().indexOf(query) > -1));
  }
  return (
    <IonPage>
      <IonContent fullscreen>
        <IonHeader collapse="condense">
          <IonToolbar>
            <IonTitle><img width="22%" height="20%" src="https://cdn.discordapp.com/attachments/1030429153415155780/1045648139165638706/logo200.png" /></IonTitle>
          </IonToolbar>
        </IonHeader>
        <h3 className="poaps-title">Events</h3>
        <br></br>
        <IonSearchbar debounce={1000} onIonChange={(ev) => handleChange(ev)} animated={true} placeholder="Search Event"></IonSearchbar>
        <br></br>
        {results.map(result => (
          <IonList className="events-list">
            <IonItem button onClick={() => { setIsOpen(true); setSelected(result); }}>
              <IonThumbnail className="event-img">
                <img src={result.img} />
              </IonThumbnail>
              <IonCardHeader>
                <IonCardTitle>{result.title}</IonCardTitle>
                <IonCardSubtitle>Card Subtitle</IonCardSubtitle>
              </IonCardHeader>

            </IonItem>


          </IonList>
        ))}
        <IonModal isOpen={isOpen} >
          <IonHeader>
            <IonToolbar>
              <IonTitle>{selected.title}</IonTitle>
              <IonButtons slot="end">
                <IonButton onClick={() => setIsOpen(false)}>Close</IonButton>
              </IonButtons>
            </IonToolbar>
          </IonHeader>
          <IonContent className="ion-padding" >
            <img src={selected.img} />
            <IonRow className='title-hour'>
              <h1>{selected.title}</h1>
              <h1>{selected.hour}</h1>
            </IonRow>
            <h2>{selected.type}</h2>
            <h3>{selected.manager}</h3>
            <IonProgressBar value={
              selected.ocupied/selected.capacity
            }></IonProgressBar>
            <p>
              {selected.description}
            </p>
            <div id='map' className='map' ref={createMap}>
              <capacitor-google-map ref={mapRef} style={{
                display: 'inline-block',
                width: "100%",
                height: "100%"
              }}></capacitor-google-map>
            </div>

            <IonButton id="open-modal" expand="block" className=".toppd">
              Follow
            </IonButton>

          </IonContent>

        </IonModal>
      </IonContent>
    </IonPage>
  );
};

export default Events;

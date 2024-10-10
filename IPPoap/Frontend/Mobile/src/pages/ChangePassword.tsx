import { IonItem,IonButton,IonInput,IonContent, IonHeader, IonPage, IonTitle, IonToolbar, IonCard, IonList} from '@ionic/react';
import ExploreContainer from '../components/ExploreContainer';
import './ChangePassword.css';

const ChangePassword: React.FC = () => {
    return (
        <IonPage>
            <IonContent className="content">
                <IonCard class="change">
                    <IonList class="input">
                    <h1 className="header">Change Password</h1>
                        <IonItem className="item-Password">
                            <IonInput type="password" placeholder="Actual Password"></IonInput>
                        </IonItem>
                        <IonItem className="item-Password">
                            <IonInput type="password"  placeholder="New Password"></IonInput>
                        </IonItem>
                        <IonItem className="item-Password">
                            <IonInput  type="password"  placeholder="Confirm Password"></IonInput>
                        </IonItem>
                    <IonButton className="button-save" routerLink="/user"> Save Changes</IonButton>
                    </IonList>
                </IonCard>
            </IonContent>
    </IonPage>
    );
}
export default ChangePassword;

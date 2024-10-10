# OverView

## Preview
| Number | Title | Description |
| --- | --- | --- |
**1** | **User** | *contains all methods related to User*
1.1 |Create Account | Creates new account
1.2 |Edit Wallet | Updates new information about the Wallet
1.3 |Edit Password | Updates user's password
**2** |**Verify** | *contains all method related to user Validation*
2.1 |Log In| If credentials are correct returns token
2.2| Validate Token|Checks if token is valid
2.3 |Verify Admin| Verifies if token is from Admin account
2.4 | Verify Manager| Verifies if token is from Manager account
**3** |**WhiteList**| *contains all method related to user WhiteList*
3.1 | List| Lists all Domains in Whitelist 
3.2 |Create Rule| Adds a certain domain to the Whitelist
3.3 |Edit Rule| Edits a certain domain to the Whitelist
3.4 |Delete Rule| Delete a certain domain to the Whitelist
**4** |**Manager**| *contains all method related to Manager*
4.1 |Create|Creates a new Manager in a certain group
4.2| Delete | deletes a Manager from a certain group
4.3 |List | Lists all Managers
4.4| Change State | Activates or Deactivates Manager from certain group
**5**| **Events**| *contains all method related to Events*
5.1| Create | Creates new event
5.2 |List| Lists all events
5.3 |Follow |Follows event
5.4| Unfollow | Unfollows event
5.5| Saved| List Participants  saved event
5.6 |Search| Given a string returns events that match
5.7 |Edit | Updates event info
5.8| Delete | Deletes event
5.9 |Change State| Activates or Deactivates event
**6**| **Poap**| *contains all method related to Poap*
6.1| Create | Creates new Poap
6.2 |List| Lists all Poap
6.3 |Get by ID |returns poap by id
6.4| Redeem | redeems poap


## Premission

| Number | Title | Admin | Manager | Participant
| --- | --- | :---:  |:---:| :---:|
**1** | **User** |
1.1 |Create Account | <span style="color:red">NO</span> |<span style="color:red">NO</span> | <span style="color:green">YES</span>
1.2 |Edit Wallet | <span style="color:red">NO</span> |<span style="color:red">NO</span> | <span style="color:green">YES</span>
1.3 |Edit Password |<span style="color:red">NO</span> |<span style="color:red">NO</span> | <span style="color:green">YES</span>
**2** |**Verify** | 
2.1 |Log In| <span style="color:green">YES</span> |<span style="color:green">YES</span> |<span style="color:green">YES</span>
2.2| Validate Token|<span style="color:green">YES</span> |<span style="color:green">YES</span> |<span style="color:green">YES</span>
2.3 |Verify Admin|<span style="color:green">YES</span> |<span style="color:green">YES</span> |<span style="color:green">YES</span>
2.4 | Verify Manager| <span style="color:green">YES</span> |<span style="color:green">YES</span> |<span style="color:green">YES</span>
**3** |**WhiteList**|
3.1 | List| <span style="color:green">YES</span> |<span style="color:red">NO</span> |<span style="color:red">NO</span>
3.2 |Create Rule|  <span style="color:green">YES</span> |<span style="color:red">NO</span> |<span style="color:red">NO</span>
**4** |**Manager**| 
4.1 |Create Manager| <span style="color:green">YES</span> |<span style="color:red">NO</span> |<span style="color:red">NO</span>
4.2| Delete Manager| <span style="color:green">YES</span> |<span style="color:red">NO</span> |<span style="color:red">NO</span>
4.3 |List Manager| <span style="color:green">YES</span> |<span style="color:red">NO</span> |<span style="color:red">NO</span>
4.4| Activate Manager| <span style="color:green">YES</span> |<span style="color:red">NO</span> |<span style="color:red">NO</span>
4.5| Deactivate Manager| <span style="color:green">YES</span> |<span style="color:red">NO</span> |<span style="color:red">NO</span>
**5**| **Events**|
5.1| Create| <span style="color:green">YES</span> |<span style="color:green">YES</span> |<span style="color:red">NO</span>
5.2| List| <span style="color:green">YES</span> |<span style="color:green">YES</span> |<span style="color:green">YES</span>
5.3| Follow| <span style="color:red">NO</span> |<span style="color:red">NO</span> |<span style="color:green">YES</span>
5.3| Unfollow| <span style="color:red">NO</span> |<span style="color:red">NO</span> |<span style="color:green">YES</span>
5.5 | Saved | <span style="color:red">NO</span> |<span style="color:red">NO</span> |<span style="color:green">YES</span>
5.6 | Search |  <span style="color:green">YES</span> |<span style="color:green">YES</span> |<span style="color:green">YES</span> 
5.7 | Edit |  <span style="color:green">YES</span> |<span style="color:green">YES</span> |<span style="color:red">NO</span> 
5.8 | Delete |  <span style="color:green">YES</span> |<span style="color:green">YES</span> |<span style="color:red">NO</span> 
5.9 | Activate |  <span style="color:green">YES</span> |<span style="color:green">YES</span> |<span style="color:red">NO</span> 
5.10 | Deactivate |  <span style="color:green">YES</span> |<span style="color:green">YES</span> |<span style="color:red">NO</span> 
**6**| **Poap**|
6.1| Create |<span style="color:green">YES</span> |<span style="color:green">YES</span> |<span style="color:red">NO</span> 
6.2 |List| <span style="color:green">YES</span> |<span style="color:green">YES</span> |<span style="color:green">YES</span> 
 6.3 |Get by ID |<span style="color:red">NO</span> |<span style="color:red">NO</span> |<span style="color:green">YES</span> 
 6.4| Redeem |<span style="color:red">NO</span> |<span style="color:red">NO</span> |<span style="color:green">YES</span> 



# EndPoints

## 1 - User
### 1.1 Create Account
| | | |
| --- | --- | --- |
Método | POST
|Rota|    /users/
|Body|    ``creatUser{email,password,confirm_password,metamask_account}``
|Headers|  ---  | |
|Responses| <span style="color:green">201 - Success</span> <br> <span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>| Account created <br> Wrong Syntax <br> Server Error

### 1.2 Edit Wallet
| | | |
| --- | --- | --- |
Método | PUT
|Rota|    /users/editWallet
|Body|    ``editWallet {email,metamask_account}``
|Headers|  ``token``  | |
|Responses| <span style="color:green">201 - Success</span> <br> <span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>| Wallet Updated <br> Wrong Syntax <br> Server Error

### 1.3 Edit Password
| | | |
| --- | --- | --- |
Método | PUT
|Rota|    /users/editPassword
|Body|    ``verifyManager {email,old,new,confirm_new}``
|Headers|   ``token`` | |
|Responses| <span style="color:green">201 - Success</span><br><span style="color:green">202 - Wrong Password</span> <br><span style="color:green">203 - New Password</span><br> <span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>| Password updated<br> Wrong Password<br>Password and Confirm Password different<br> Wrong Syntax <br> Server Error

## 2 - Verify
### 2.1 Log In
| | | |
| --- | --- | --- |
Método | GET
|Rota|    /verify/login
|Body|    ``login {email,password}``
|Headers|    | |
|Responses| <span style="color:green">200 - Success</span> <br> <span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>| ``token`` <br> Wrong Syntax <br> Server Error
## 3 - WhiteList

### 3.1 List
| | | | 
| --- | --- | --- |
Método | GET
|Rota|    /whiteList/
|Body|    ``list {email}``
|Headers|   ``token`` | |
|Responses| <span style="color:green">200 - Success</span><br> <span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|``WhiteList{every domain}``<br> Wrong Syntax <br> Server Error

### 3.2 Create Rule
| | | | 
| --- | --- | --- |
Método | POST
|Rota|    /whiteList/
|Body|    ``createRule {email,domain}``
|Headers|   ``token`` | |
|Responses| <span style="color:green">201 - Success</span><br> <span style="color:green">202 - Rule not added</span><br> <span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|Rule created<br>Rule already exists<br> Wrong Syntax <br> Server Error

### 3.3 Edit Rule
| | | | 
| --- | --- | --- |
Método | PUT
|Rota|    /whiteList/
|Body|    ``UpdateRule {email,domain}``
|Headers|   ``token`` | |
|Responses| <span style="color:green">201 - Success</span><br> <span style="color:green">202 - Rule not added</span><br> <span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|Rule created<br>Rule already exists<br> Wrong Syntax <br> Server Error

### 3.4 Delete Rule
| | | | 
| --- | --- | --- |
Método | DELETE
|Rota|    /whiteList/
|Body|    ``DeleteRule {email,domain}``
|Headers|   ``token`` | |
|Responses| <span style="color:green">201 - Success</span><br> <span style="color:green">202 - Rule not added</span><br> <span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|Rule created<br>Rule already exists<br> Wrong Syntax <br> Server Error

## 4 - Manager
### 4.1 Create
| | | | 
| --- | --- | --- |
Método | POST
|Rota|    /manager/
|Body|    ``create {manager_email,group_id}``
|Headers|   ``token`` | |
|Responses| <span style="color:green">201 - Success</span><br> <span style="color:green">202 - Manager not added</span><br> <span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|Manager created<br>Manager already exists<br> Wrong Syntax <br> Server Error

### 4.2 Delete 
| | | | 
| --- | --- | --- |
Método | DELETE
|Rota|    /manager/
|Body|    ``delete {manager_email,group_id}``
|Headers|   ``token`` | |
|Responses| <span style="color:green">201 - Deleted</span><br><span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|Manager created<br>Wrong Syntax <br> Server Error

### 4.3 List 
| | | | 
| --- | --- | --- |
Método | GET
|Rota|    /manager/
|Body|    ``list {manager_email,group_id}``
|Headers|   ``token`` | |
|Responses| <span style="color:green">201 - Deleted</span><br><span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|Manager created<br>Wrong Syntax <br> Server Error

### 4.4 Change State 
| | | | 
| --- | --- | --- |
Método | PUT
|Rota|    /manager/changeStage
|Body|    ``changeState {manager_email,group_id}``
|Headers|   ``token`` | |
|Responses| <span style="color:green">201 - Active</span><br><span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|Manager is now Active<br>Wrong Syntax <br> Server Error

## 5 - Events
### 5.1 Create 
| | | | 
| --- | --- | --- |
Método | POST
|Rota|    /events/
|Body|    ``create {``<br>``name,organizer,local,datetime``<br>``,description,foto,capacity,state,type``<br>``}``
|Headers|   ``token`` | |
|Responses| <span style="color:green">201 - Created</span><br><span style="color:green">202 - Not Created</span><br><span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|link to redem poap<br>Denied<br>Wrong Syntax <br> Server Error

### 5.2 List 
| | | | 
| --- | --- | --- |
Método | GET
|Rota|    /events/
|Body| ``list{}``
|Headers|   ``token`` | |
|Responses| <span style="color:green">200 - OK</span><br><span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|``Events{}``<br>Wrong Syntax <br> Server Error

### 5.3 Follow 
| | | | 
| --- | --- | --- |
Método | PUT
Rota|    /events/follow
|Body| ``follow{id}``
|Headers|   ``token`` | |
|Responses| <span style="color:green">201 - OK</span><br><span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|Following<br>Wrong Syntax <br> Server Error

### 5.4 Unfollow 
| | | | 
| --- | --- | --- |
Método | PUT
|Rota|    /events/unfollow
|Body| ``unfollow{id}``
|Headers|   ``token`` | |
|Responses| <span style="color:green">201 - OK</span><br><span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|Unfollowed<br>Wrong Syntax <br> Server Error

### 5.5 Saved  
| | | | 
| --- | --- | --- |
Método | GET
|Rota|    /events/saved
|Body| ``saved{}``
|Headers|   ``token`` | |
|Responses| <span style="color:green">200 - OK</span><br><span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|``Events{}``<br>Wrong Syntax <br> Server Error

### 5.6 Search 
| | | | 
| --- | --- | --- |
Método | GET
|Rota|    /events/search
|Body| ``search{string}``
|Headers|   ``token`` | |
|Responses| <span style="color:green">201 - OK</span><br><span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|``Events{}``<br>Wrong Syntax <br> Server Error

### 5.7 Edit 
| | | | 
| --- | --- | --- |
Método | PUT
|Rota|    /events/
|Body| ``edit{name,organizer,local,datetime``<br>``,description,foto,capacity,state,type}``
|Headers|   ``token`` | |
|Responses| <span style="color:green">201 - OK</span><br> <span style="color:green">202 - Denied</span><br><span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|Event updated<br>Not Permitted<br>Wrong Syntax <br> Server Error

### 5.8 Delete 
| | | | 
| --- | --- | --- |
Método | DELETE
|Rota|    /events/
|Body| ``delete{id}``
|Headers|   ``token`` | |
|Responses| <span style="color:green">201 - OK</span><br> <span style="color:green">202 - Denied</span><br><span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|Event Deleted<br>Not Permitted<br>Wrong Syntax <br> Server Error

### 5.9 Change State 
| | | | 
| --- | --- | --- |
Método | PUT
|Rota|    /events/changeState
|Body| ``changeState{id}``
|Headers|   ``token`` | |
|Responses| <span style="color:green">201 - OK</span><br> <span style="color:green">202 - Denied</span><br><span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|Event Ative<br>Not Permitted<br>Wrong Syntax <br> Server Error


### 5.10 New Type 
| | | | 
| --- | --- | --- |
Método | POST
|Rota|    /events/type
|Body| ``changeState{name}``
|Headers|   ``token`` | |
|Responses| <span style="color:green">201 - OK</span><br><span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|Created <br>Wrong Syntax <br> Server Error

### 5.11 Update Type 
| | | | 
| --- | --- | --- |
Método | PUT
|Rota|    /events/type
|Body| ``changeState{name}``
|Headers|   ``token`` | |
|Responses| <span style="color:green">201 - OK</span><br><span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|``Updated: $name``<br>Wrong Syntax <br> Server Error

### 5.12 Delete Type 
| | | | 
| --- | --- | --- |
Método | DELETE
|Rota|    /events/type
|Body| ``changeState{name}``
|Headers|   ``token`` | |
|Responses| <span style="color:green">201 - OK</span><br><span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|``$name deleted``<br>Wrong Syntax <br> Server Error

### 5.12 List Type 
| | | | 
| --- | --- | --- |
Método | GET
|Rota|    /events/type
|Body| ``changeState{name}``
|Headers|   ``token`` | |
|Responses| <span style="color:green">201 - OK</span><br><span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|List\<EventType><br>Wrong Syntax <br> Server Error


## 6 - Poap
### 6.1 Create 
| | | | 
| --- | --- | --- |
Método | POST
|Rota|    /poap/create
|Body|``{"name": name of your Drop,``<br>``"description": Description of your drop,``<br>``"city": city where the event will be taking place,``<br>``"country": country where the event will be taking place,``<br>``"start_date": Start date for your Drop,``<br>``"end_date": Can be the same as the End date,``<br>``"expiry_date": From this day onward, no Collectors will be able to mint POAPs from your Drop,``<br>``"year": <number>,``<br>``"event_url": entity_url_,``<br>``"virtual_event": true or false,``<br>``"image": Image should be 500x500, circle cropped, under 4MB and can either be .png or .gif with .png extension,``<br>``"secret_code": 6 digit secret code that can be used to edit your Drop afterwards,``<br>``"event_template_id": <number: default 0> add a template to customize the page where your Collectors will mint their POAP,``<br>``"email": Manager email,``<br>``"requested_codes": <number> of Mints,``<br>``"private_event": true``<br>``}`` | |
|Responses| <span style="color:green">201 - Created</span><br><span style="color:green">202 - Not Created</span><br><span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|link to redem poap<br>Denied<br>Wrong Syntax <br> Server Error

### 6.2 List 
| | | | 
| --- | --- | --- |
Método | GET
|Rota|    /poap/list
|Body| ``list{}``
|Headers|   ``token`` | |
|Responses| <span style="color:green">200 - OK</span><br><span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|``Events{}``<br>Wrong Syntax <br> Server Error
### 6.3 Get by ID 

| | | | 
| --- | --- | --- |
Método | GET
|Rota|    /poap/getbyID
|Body| ``getbyid{id}``
|Headers|   ``token`` | |
|Responses| <span style="color:green">200 - OK</span><br><span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|``poap{}``<br>Wrong Syntax <br> Server Error
### 6.4 Redeem 

| | | | 
| --- | --- | --- |
Método | POST
|Rota|    /poap/redem
|Body| ``redem{id, address}``
|Headers|   ``token`` | |
|Responses| <span style="color:green">200 - OK</span><br><span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|``poap{}``<br>Wrong Syntax <br> Server Error

## 7 - Entity
### 7.1 Create 
| | | | 
| --- | --- | --- |
Método | POST
|Rota|    /entity/
|Body| name, admin{email,password}| |
|Responses| <span style="color:green">201 - Created</span><br><span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|``entity{}``<br>Wrong Syntax <br> Server Error

### 7.2 Update 
| | | | 
| --- | --- | --- |
Método | PUT
|Rota|    /entity/
|Body| name | |
|Responses| <span style="color:green">201 - Updated</span><br><span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|``entity{}``<br>Wrong Syntax <br> Server Error

### 7.3 Delete 
| | | | 
| --- | --- | --- |
Método | DELETE
|Rota|    /entity/
|Body| name | |
|Responses| <span style="color:green">201 - Deleted</span><br><span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|<br>Wrong Syntax <br> Server Error

### 7.4 Create Admin
| | | | 
| --- | --- | --- |
Método | POST
|Rota|    /entity/admin
|Body| entity, admin{email,password}| |
|Responses| <span style="color:green">201 - Created</span><br><span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|``Admin{}``<br>Wrong Syntax <br> Server Error

### 7.5 Update Admin
| | | | 
| --- | --- | --- |
Método | PUT
|Rota|    /entity/admin
|Body| name,id,Admin{} | |
|Responses| <span style="color:green">201 - Updated</span><br><span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|``newAdmin{}``<br>Wrong Syntax <br> Server Error

### 7.6 Delete Admin
| | | | 
| --- | --- | --- |
Método | DELETE
|Rota|    /entity/admin
|Body| name, admin.id | |
|Responses| <span style="color:green">201 - Deleted</span><br><span style="color:yellow">400 - Syntax</span> <br> <span style="color:red">500 - Internal Server Error</span>|<br>Wrong Syntax <br> Server Error
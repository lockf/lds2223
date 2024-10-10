### Evento - Composição
 
- Nome
- Organizador
- Local
- Hora e Data
- Descrição
- Foto
- Lotação
- Estado (Aberto/Privado)
- Tipo
 
---
 
<br>

## Requisitos

<br>

 ID: RF 3.1 | Nome: Criar Eventos | Tipo:Evento  | Prioridade:Alta |
| --- | --- | --- | --- |
 
**Descrição:** O programa deverá pedir Nome, Organizador, Local, Hora e Data, Descrição, Foto, Lotação, Estado do Evento e criar o mesmo na base de dados,
deixando disponível para acesso aos diferentes Utilizadores mediante o estado escolhido.
 
**Verificações:**
- A Data e Hora do evento deverá ter 7 dias de Antecedência
- Estado deve ser Aberto ou Privado
- Lotação deve ser entre 5 e 1800 
- Imagem deve ter as medidas certas pedidas pelo programa
 
**Restrições:**
- Administrador estar autenticado
 
---
 
<br>

| ID: RF 3.2 | Nome: Listar Eventos| Tipo:  Evento| Prioridade: Media|
| --- | --- | --- | --- |
 
**Descrição:** O Programa deverá aceder aos eventos na base de dados e retornar os as
suas informações como Nome, Organizador, Local, Hora e Data, Descrição, Foto, Lotação, Estado do Evento.
 
**Verificações:**
- Existir eventos criados
 
**Restrições:**
- Administrador/Participante estar autenticado
 
---
 
<br>

| ID: RF 3.3 | Nome: Seguir Evento | Tipo: Evento | Prioridade: Media|
| --- | --- | --- | --- |
 
**Descrição:** Esta funcionalidade permitirá aos Participantes informarem o programa que estarão presentes no evento
 
**Verificações:**
- Haver lotação no evento
- Data e Hora actual deverá anterior à Data e hora do Evento
 
**Restrições:**
- Participante estar autenticado
 
---
 
<br>

| ID: RF 3.4 | Nome: Deixar de seguir Evento | Tipo: Evento | Prioridade: Media
| --- | --- |  --- | --- |
 
**Descrição:** No caso do Participante não poder estar presente no evento deverá deixar de seguir o evento, deste modo o lugar do Participante ficará vago para outro que queira participar no mesmo evento
 
**Verificações:**
- Haver lotação no evento
- Data e Hora actual deverá ser anterior à Data e hora do Evento
 
**Restrições:**
- Participante estar autenticado
 
---
 
<br>

| ID: RF 3.5 | Nome: Eventos Guardados | Tipo: Evento | Prioridade: Media |
| --- | --- | --- | --- |
 
**Descrição:** Disponibilizar ao Participante todos os eventos aos quais já foi ou pretende ir.
 
**Verificações:**
- Haver eventos atendidos ou por atender do Participante
 
**Restrições:**
- Participante estar autenticado
 
---
 
<br>

| ID: RF 3.6 | Nome: Pesquisar Evento | Tipo: Evento | Prioridade: Media|
| --- | --- | --- | --- |
 
**Descrição:** Deve passar uma String e procurar nos campos:
- Nome
- Organizador
- Local
- Hora

Se existe alguma parte igual e se existir deve devolver os eventos.
 
**Verificações:**
- Existir eventos
 
**Restrições:**
- Administrador/Participante estar autenticado

---
 
<br>

| ID: RF 3.7 | Nome: Editar Evento | Tipo: Evento | Prioridade: Media|
| --- | --- | --- | --- |
 
**Descrição:** O programa deverá permitir ao utilizador (Admin ou Promotor), alterar algumas informações do evento, tal como: 
- Nome
- Organizador
- Local
- Descrição
- Foto
- Tipo

**Verificações:**
O sistema deverá verificar se:
- Os campos alterados estão no formato correto.
- O evento existe na base de dados.

No caso de algum dos pontos acima referidos não se verifique, o sistema deverá emitir um alerta e não permitir continuar.
 
**Restrições:**
O utilizador tem de estar registado e autenticado e ser o Admin ou Promotor.

---
 
<br>

| ID: RF 3.8 | Nome: Apagar Evento | Tipo: Evento | Prioridade: Media|
| --- | --- | --- | --- |
 
**Descrição:** O programa deverá permitir ao utilizador (Admin e Promotor), no caso do promotor apenas os eventos criados por si podem ser apagados com a devida antecedência, apagar eventos. O Admin pode apagar o evento a qualquer altura podendo o evento criado ir contra as regras estabelecidas e podendo sofrer alguma castigo.
 
**Verificações:**
O sistema deverá verificar se:
- O tempo para apagar o evento após a sua criação ainda não ocorreu, à exceção do Admin.
- O evento existe na base de dados.

No caso de algum dos pontos acima referidos não se verifique, o sistema deverá emitir um alerta e não permitir continuar.
 
**Restrições:**
O utilizador tem de estar registado e autenticado e ser o Admin ou Promotor.

---
 
<br>

| ID: RF 3.9 | Nome: Ocultar Evento | Tipo: Evento | Prioridade: Media|
| --- | --- | --- | --- |
 
**Descrição:** O programa deverá permitir ao utilizador (Admin), no caso do evento criado pelo promotor violar as regras estabelecidas, ser ocultado pelo Admin.
 
**Verificações:**
O sistema deverá verificar se:
- O evento existe na base de dados.

No caso de algum dos pontos acima referidos não se verifique, o sistema deverá emitir um alerta e não permitir continuar.
 
**Restrições:**
O utilizador tem de estar registado e autenticado e ser o Admin.
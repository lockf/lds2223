### **UC-3.1: Criar Eventos**

<br>
 
**Descrição:**
O programa deverá pedir Nome, Administrador, Local, Hora e Data, Descrição, Foto, Lotação, Estado do Evento e criar o mesmo na base de dados, deixando disponível para acesso aos diferentes Administrador mediante o estado escolhido.
 
**Prioridade:**
Alta
 
**Atores:**
Administrador autenticado
 
**Sequências:**
##### Administrador autenticado:
| # | Utilizador (Ações) | Sistema |
| --- | --- | --- |
| 1. | Selecionar Criar Evento | Formulário |
| 2. | Inserir Formulário | Validar Formulário e Enviar mensagem de confirmação|

**Requisitos Funcionais:**
- RF-3.1: Criar Eventos

**Formulário:**
| ID | Tipo | Restrição |
| --- | --- | --- |
| Nome | String | length < 25 |
| Organizador | String | length < 25 |
| Local | Local |  |
| Hora e Data | DateTime | 7 Dias de Antecedência |
| Descrição | String | length < 500 |
| Foto | jpeg | 312x820 px |
| Lotação | int | maior que 5 menor que 1800 |
| Estado | Type | Aberto ou Privado |

---

<br>
 
### **UC-3.2: Listar Eventos**

<br>
 
**Descrição:**
O Programa deverá aceder aos eventos na base de dados e retornar os as
suas informações como Nome, Organizador, Local, Hora e Data, Descrição, Foto, Lotação, Estado do Evento.
 
**Prioridade:**
Média
 
**Atores:**
Administrador/Participante estar autenticado
 
**Sequências:**
##### Administrador autenticado:
| # | Utilizador (Ações) | Sistema |
| --- | --- | --- |
| 1. | Selecionar Listar Eventos | Procurar e retornar Eventos existentes |
 
##### Participante autenticado:
| # | Utilizador (Ações) | Sistema |
| --- | --- | --- |
| 1. | Selecionar Listar Eventos | Procurar e retornar Eventos abertos existentes |
 
**Requisitos Funcionais:**
- RF-3.2: Listar Eventos

---

<br>
 
### **UC-3.3: Seguir Evento**

<br>
 
**Descrição:**
Esta funcionalidade permitirá aos Participantes informarem o programa que estarão presentes no evento
 
**Prioridade:**
Média
 
**Atores:**
Participante autenticado
 
**Sequências:**
##### Participante autenticado:
| # | Utilizador (Ações) | Sistema |
| --- | --- | --- |
| 1. | Selecionar um dos Eventos abertos listados | Mostrar pagina com mais informações do Evento |
| 2. | Clicar no botão "Seguir Evento" | Adicionar participante à lista de Participantes e retornar mensagem de sucesso |
 
##### Participante autenticado:
| # | Utilizador (Ações) | Sistema |
| --- | --- | --- |
| 1. | Selecionar Listar Eventos | Procurar e retornar Eventos abertos existentes |
 
 **Requisitos Funcionais:**
- RF-3.3: Seguir Evento
- RF-3.2: Listar Eventos

---

<br>

### **UC-3.4: Deixar de Seguir Evento**

<br>
 
**Descrição:**
No caso do Participante não poder estar presente no evento deverá deixar de seguir o evento, deste modo o lugar do Participante ficará vago para outro que queira participar no mesmo evento
 
**Prioridade:**
Média
 
**Atores:**
Participante autenticado
 
**Sequências:**
##### Participante autenticado:
| # | Utilizador (Ações) | Sistema |
| --- | --- | --- |
| 1. | Selecionar a opção de eventos Guardados | Enviar Eventos guardados pelo Participante |
| 2. | Selecionar o Evento ao qual já não pretende ir | Enviar informações detalhadas do Evento |
| 3. | Clicar no botão "Deixar de Seguir Evento" |  Remover Participante da lista de Participantes do Evento<br>Remover Evento da lista de Eventos do Participante<br> Enviar mensagem de confirmação |
 
**Requisitos Funcionais:**
- RF-3.4: Deixar de Seguir Evento
- RF-3.5: Eventos Guardados
 
---

<br>

### **UC-3.5: Eventos Guardados**

<br>
 
**Descrição:**
Disponibilizar ao Participante todos os eventos aos quais já foi ou pretende ir.
  
**Prioridade:**
Média
 
**Atores:**
Participante autenticado
 
**Sequências:**
##### Participante autenticado:
| # | Utilizador (Ações) | Sistema |
| --- | --- | --- |
| 1. | Selecionar Eventos Guardados | Enviar e listar Eventos guardados pelo Participante |
 
**Requisitos Funcionais:**
- RF-3.5: Eventos Guardados
- RF-3.2: Listar Eventos
 
---

<br>

### **UC-3.6: Pesquisar Evento**

<br>
 
**Descrição:**
Deve passar uma String e procurar nos campos:
- Nome
- Organizador
- Local
- Hora
- Tipo

Se existe alguma parte igual e se existir deve devolver os eventos.

**Prioridade:**
Média
 
**Atores:**
Participante/Administrador autenticado
 
**Sequências:**
##### Participante autenticado:
| # | Utilizador (Ações) | Sistema |
| --- | --- | --- |
| 1. | Selecionar opção de pesquisa | Mostrar interface de pesquisa |
| 2. | Escrever o que pretende procurar | Procurar informação na base de Dados (Nome, Organizador, Local, Hora) e listar os semelhantes |
 
**Requisitos Funcionais:**
- RF-3.6: Pesquisar Evento
- RF-3.2: Listar Eventos

---

<br>

### **UC-3.7: Apagar  Evento**

<br>
 
**Descrição:**
O utilizador (Administrador) elimina evento criado.

**Prioridade:**
Baixa
 
**Atores:**
Administrador autenticado
 
**Sequências:**
##### Participante autenticado:
| # | Utilizador (Ações) | Sistema |
| --- | --- | --- |
| 1. | O utilizador seleciona "Eventos" | Mostrar interface de Eventos |
| 2. | O utilizador seleciona "Apagar" do evento pretendido | O evento é eliminado da base de dados |
 
**Requisitos Funcionais:**
- RF-3.6: Pesquisar Evento
- RF-3.8: Eliminar Evento

---

<br>

### **UC-3.8: Editar Evento**

<br>
 
**Descrição:**
O utilizador (Administrador) edita evento criado.

**Prioridade:**
Baixa
 
**Atores:**
Administrador autenticado
 
**Sequências:**
##### Participante autenticado:
| # | Utilizador (Ações) | Sistema |
| --- | --- | --- |
| 1. | O utilizador seleciona "Eventos" | Mostrar interface de Eventos |
| 2. | O utilizador seleciona "Editar" no evento pretendido | O Sistema apresenta os campos com os dados associados ao evento |
| 4. | O utilizador altera os campos que pretende e confirma a alteração | O Sistema altera os dados do evento |
 
**Requisitos Funcionais:**
- RF-3.6: Pesquisar Evento
- RF-3.7: Editar Evento

---

<br>

### **UC-3.9: Ocultar  Evento**

<br>
 
**Descrição:**
O utilizardor (Administrador) oculta evento criado.

**Prioridade:**
Baixa
 
**Atores:**
Administrador autenticado
 
**Sequências:**
##### Participante autenticado:
| # | Utilizador (Ações) | Sistema |
| --- | --- | --- |
| 1. | O utilizador seleciona "Eventos" | Mostrar interface de Eventos |
| 3. | O utilizador altera a posição do botão para ocultar no evento pretendido  | O sistema altera o visibilidade do evento. O evento oculto deixa de aparecer para os participantes. Caso altere para visivel, acontece o oposto |
 
**Requisitos Funcionais:**
- RF-3.6: Pesquisar Evento
- RF-3.9: Ocultar  Evento
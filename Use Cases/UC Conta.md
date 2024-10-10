### **UC-1.1: Criar Conta**

<br>

**Descrição:**
Este use case descreve um utilizador a criar  conta.

**Prioridade:**
Alta

**Atores:**
Utilizador não autenticado.

**Sequências:**
| # | Utilizador (Ações) | Sistema |
| --- | --- | --- |
| 1 | O utilizador seleciona a opção de criar conta| O sistema apresenta o formulário de criação de conta com os campos:  email, password, confirmação de password e endereço da carteira Metamask |
| 2 | O utilizador preenche os campos do formulário | O sistema verifica se todos os campos estão preenchidos. Caso algum campo não esteja preenchido, é emitido um alerta ao utilizador indicando qual campo não está preenchido, o sistema continua no ponto #1 havendo persistência dos dados já introduzidos. |
| 3 | O utilizador seleciona a opção "Criar Conta" | O sistema verifica se: <br><br>- Todos os campos obrigatórios do formulário estão preenchidos. <br> - O email não existe na base de dados. <br> - O email termina como " @estg.ipp.pt ". <br> - A password e a password de confirmação coincidem. <br> - A carteira Metamask existe. <br><br> Caso algum campo não esteja preenchido é emitido um alerta ao utilizador indicando qual campo não está preenchido e o sistema continua no ponto #1 havendo persistência dos dados já introduzidos. <br> Se a criação da conta for bem sucedida o utilizador é encaminhado para a página inicial sem a sessão iniciada. |

**Requisitos Funcionais:**
- RF-1.1: Criar Conta

---

<br>

### **UC-1.2: Alterar Carteira**

<br>

**Descrição:**
Este use case descreve um utilizador autenticado a alterar a sua carteira.

**Prioridade:**
Média

**Atores:**
Utilizador autenticado

**Sequências:**
| # | Utilizador (Ações) | Sistema |
| --- | --- | --- |
| 1 | O utilizador autenticado seleciona a opção "Alterar Carteira" no menu | O sistema apresenta um campo para o novo endereço da carteira Metamask. |

**Requisitos Funcionais:**
- RF-1.2: Alterar Carteira
- RF-1.6: Ver menu de opções da Conta

---

<br>

### **UC-1.3: Iniciar Sessão**

<br>

**Descrição:**
Este use case descreve um utilizador a iniciar sessão na aplicação.

**Prioridade:**
Alta

**Atores:**
Utilizador não autenticado

**Sequências:**
| # | Utilizador (Ações) | Sistema |
| --- | --- | --- |
| 1 | O utilizador seleciona a opção "Iniciar  Sessão" | O sistema apresenta um formulário com os campos: email e password. |
| 2 | O utilizador preenche os campos do formulário | O sistema verifica se todos os campos estão preenchidos. <br> Caso algum campo não esteja preenchido é emitido um alerta ao utilizador indicando qual campo não está preenchido e o sistema continua no ponto #1. |
| 3 | O utilizador seleciona a opção "Iniciar  Sessão" | O sistema deverá verificar se: <br><br> - Todos os campos obrigatórios do formulário estão preenchidos. <br> - Todos os dados estão no formato esperado. <br> - O email existe na base de dados. <br> - A password corresponde ao email inserido. <br><br> No caso de algum dos pontos acima referidos não se verifique, o sistema deverá emitir um alerta e voltar ao ponto #1. |

**Requisitos Funcionais:**
- RF-1.3: Iniciar Sessão

---

<br>

### **UC-1.4: Terminar Sessão**

<br>

**Descrição:**
Este use case descreve um utilizador autenticado a terminar sessão.

**Prioridade:**
Alta

**Atores:**
Utilizador autenticado

**Sequências:**
| # | Utilizador (Ações) | Sistema |
| --- | --- | --- |
| 1 | O utilizador seleciona a opção "Terminar Sessão" no menu | O sistema reencaminha o utilizador para a página inicial com a sessão terminada. |

**Requisitos Funcionais:**
- RF-1.4: Terminar Sessão
- RF-1.5: Ver menu de opções da Conta

---

<br>

### **UC-1.5: Ver menu de opções da Conta**

<br>

**Descrição:**
Este use case descreve um utilizador autenticado a ver as ações que pode realizar relacionadas com a conta.

**Prioridade:**
Alta

**Atores:**
Utilizador autenticado

**Sequências:**
| # | Utilizador (Ações) | Sistema |
| --- | --- | --- |
| 1 | O utilizador autenticado seleciona a opção que deseja do menu | O sistema apresenta a página associada à opção escolhida. |

**Requisitos Funcionais:**
- RF-1.5: Ver menu de opções da Conta
- RF-1.2: Alterar Carteira
- RF-2.2: Redimir Poap
- RF-3.1: Criar Eventos
- RF-2.2: Listar Poaps redimidos
- RF-3.2: Listar Eventos
- RF-1.4: Terminar Sessão

---

<br>

### **UC-1.6: Alterar Password**

<br>

**Descrição:**
Este use case descreve um utilizador autenticado a alterar a password.

**Prioridade:**
Alta

**Atores:**
Utilizador autenticado

**Sequências:**
| # | Utilizador (Ações) | Sistema |
| --- | --- | --- |
| 1 | O utilizador autenticado seleciona a opção "Alterar Password" no menu | O sistema apresenta a página em que o utilizador deve preencher o formulário com os campos: password e confirmar password. |
| 2 | O utilizador seleciona a opção "Confirmar" no menu | O sistema apresenta a página inicial sem a sessão iniciada. |

**Requisitos Funcionais:**
- RF-1.6: Alterar Password

---

<br>

### **UC-1.7: Criar Regra para Whitelist**

<br>

**Descrição:**
Este use case descreve um utilizador a criar  a regra para Whitelist.

**Prioridade:**
Alta

**Atores:**
Utilizador autenticado Administrador

**Sequências:**
| # | Utilizador (Ações) | Sistema |
| --- | --- | --- |
| 1. | O utilizador Administrador seleciona a opção "Definições" no menu | O sistema reencaminha o utilizador para a página de Definições. |
| 2. | O utilizador Administrador na pagina Definições seleciona a opção "Whitelist" | O sistema verifica se o utilizador tem permissões (é Administrador) para aceder. Caso não tenha, apresenta mensagem de erro. Se sim, o sistema reencaminha o utilizador para a página de Whitelist. |
| 3. | O utilizador Administrador seleciona a opção "Criar Regra" na pagina de Whitelist |  Apresenta pagina para criação da regra para a Whitelist, contendo um campo com um ID criado automáticamente para identificar a regra e um campo para o utlizador preencher o dominio de email e/ou email que será adicionado à Whitelist. |
| 4. | O utilizador Administrador preenche do dominio de email que será adicionado à Whitelist e confirma a acção. | O sistema verifica se dominio é válido e /ou já foi criada uma regra igual. Caso passe a verificação, a regra é adicionada e ao utilizador é mostrada a página inicial, caso contrário, é apresentada uma mensagem de erro.   |

**Requisitos Funcionais:**
- RF-1.7: Criar Regra para Whitelist

---

<br>

### **UC-1.8: Listar Regras para Whitelist**

<br>

**Descrição:**
Este use case descreve um utilizador a visualizar as regras para Whitelist.

**Prioridade:**
Média

**Atores:**
Utilizador autenticado Administrador

**Sequências:**
| # | Utilizador (Ações) | Sistema |
| --- | --- | --- |
| 1. | O utilizador Administrador seleciona a opção "Definições" no menu | O sistema reencaminha o utilizador para a página de Definições. |
| 2. | O utilizador Administrador na pagina Definições seleciona a opção "Whitelist" | O sistema reencaminha o utilizador para a página de Whitelist. O sistema verifica se o utilizador tem permissões (é Administrador) para aceder. Caso não tenha, apresenta mensagem de erro. Se sim, apresenta pagina com lista de regras para selecionar e acções associadas.|
| 3. | O utilizador Administrador visualiza as regras. | --- |

**Requisitos Funcionais:**
- RF-1.8: Listar Regras para Whitelist

---

<br>

### **UC-1.9: Editar Regras para Whitelist**

<br>

**Descrição:**
Este use case descreve um utilizador a editar uma regra para Whitelist a usar.

**Prioridade:**
Média

**Atores:**
Utilizador autenticado Administrador

**Sequências:**
| # | Utilizador (Ações) | Sistema |
| --- | --- | --- |
| 1. | O utilizador Administrador seleciona a opção "Definições" no menu | O sistema reencaminha o utilizador para a página de Definições. |
| 2. | O utilizador Administrador seleciona a opção "Selecionar Regra" na pagina de Definições | O sistema verifica se o utilizador tem permissões (é Administrador) para aceder. Caso não tenha, apresenta mensagem de erro. Se sim, apresenta pagina com lista de regras para selecionar. |
| 3. | O utilizador Administrador seleciona a regra da lista e a opção "Editar Regra". | Apresenta um campo para o utlizador preencher o dominio de email e/ou email que será adicionado à Whitelist.   |
| 4. | O utilizador Administrador preenche do dominio de email e/ou email que será adicionado à regra e confirma a acção. | O sistema verifica se dominio e/ou email é válido e /ou já foi criada uma regra igual. Caso passe a verificação, a regra é editada e ao utilizador é mostrada a página inicial, caso contrário, é apresentada uma mensagem de erro.   |

**Requisitos Funcionais:**
- RF-1.9: Editar Regras para Whitelist

---

<br>

### **UC-1.10: Criar Promotor**

<br>

**Descrição:**
Este use case descreve um utilizador Administrador a criar um Promotor.

**Prioridade:**
Alta

**Atores:**
Utilizador autenticado Administrador

**Sequências:**
| # | Utilizador (Ações) | Sistema |
| --- | --- | --- |
| 1. | O utilizador Administrador seleciona a opção "Promotores"  | O sistema reencaminha o utilizador para a página "Promotores". |
| 2. | O utilizador Administrador seleciona "Criar" | O Sistema apresenta o campo para preencher com email do Promotor . |
| 3. | O utilizador Administrador preenche o email do Promotor | O Sistema verifica se o campo está preenchido. Estando preenchido, é gerada uma password para o Promotor e este é criado |

**Requisitos Funcionais:**
- RF-1.11: Criar Promotor
- RF-1.13: Listar Promotor

---

<br>

### **UC-1.11: Editar Promotor**

<br>

**Descrição:**
Este use case descreve um utilizador Administrador a editar um Promotor.

**Prioridade:**
Alta

**Atores:**
Utilizador autenticado Administrador

**Sequências:**
| # | Utilizador (Ações) | Sistema |
| --- | --- | --- |
| 1. | O utilizador Administrador seleciona a opção "Promotores"  | O sistema reencaminha o utilizador para a página "Promotores". |
| 2. | O utilizador Administrador altera a posição do botão de inativar do promotor em causa | O Sistema verifica se o Promotor já está inativo. Se sim, avisa o utilizador que o promotor já está inativo, se não, o promotor fica inativo, sem acesso ao sistema |

**Requisitos Funcionais:**
- RF-1.13: Listar Promotor
- RF-1.14: Gestão da conta dos Promotores

---

<br>

### **UC-1.12: Remover Promotor**

<br>

**Descrição:**
Este use case descreve um utilizador Administrador a gerir um Promotor.

**Prioridade:**
Alta

**Atores:**
Utilizador autenticado Administrador

**Sequências:**
| # | Utilizador (Ações) | Sistema |
| --- | --- | --- |
| 1. | O utilizador Administrador seleciona a opção "Promotores"  | O sistema reencaminha o utilizador para a página "Promotores". |
| 2. | O utilizador Administrador seleciona "Remover" o promotor em causa |O Sistema remove o promotor do sistema |

**Requisitos Funcionais:**
- RF-1.12: Remover Promotor
- RF-1.13: Listar Promotor
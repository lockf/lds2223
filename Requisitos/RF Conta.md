| ID: RF-1.1 | Nome: Criar Conta | Tipo: Conta | Prioridade: Alta|
| --- | --- | --- | --- |

**Descrição:** O programa deverá apresentar ao utilizador um formulário, com os campos: email, password, confirmação de password, conta Metamask, para este preencher possibilitando assim a criação da conta na aplicação. Email deverá ser único para cada utilizador e conta metamask não é obrigatório .

**Verificações:**
O sistema deverá verificar se:
- Todos os campos obrigatórios do formulário estão preenchidos.
- Todos os dados estão no formato esperado.
- O email não existe na base de dados.
- A password e a password de confirmação coincidem.
- A conta Metamask existe.

No caso de algum dos pontos acima referidos não se verifique, o sistema deverá emitir um alerta e não permitir a criação da conta.

**Restrições:** Sem restrições. 

---

<br>

| ID: RF-1.2 | Nome: Editar Carteira | Tipo: Conta | Prioridade: Média|
| --- | --- | --- | --- |

**Descrição:** O programa deverá apresentar o campo da carteira para o utilizador alterar

**Verificações:** 
O sistema deverá verificar se:
- Se carteira é válida

No caso de algum dos pontos acima referidos não se verifique, o sistema deverá emitir um alerta e não permitir a alteração da carteira.

**Restrições:** O utilizador necessita de estar autenticado.

---

<br>

| ID: RF-1.3 | Nome: Iniciar Sessão | Tipo: Conta | Prioridade: Alta|
| --- | --- | --- | --- |

**Descrição:** O programa deverá apresentar ao utilizador um formulário com os campos: email e a password ao utilizador, possibilitando a este iniciar sessão na aplicação.

**Verificações:** 
O sistema deverá verificar se:
- Todos os campos obrigatórios do formulário estão preenchidos.
- Todos os dados estão no formato esperado.
- O email existe na base de dados.
- A password corresponde ao email inserido.

No caso de algum dos pontos acima referidos não se verifique, o sistema deverá emitir um alerta e não permitir a alteração da conta.

**Restrições:** Sem restrições.

---

<br>

| ID: RF-1.4 | Nome: Terminar Sessão | Tipo: Conta | Prioridade: Alta|
| --- | --- | --- | --- |

**Descrição:** O programa deverá apresentar ao utilizador a opção de terminar sessão na aplicação

**Verificações:** Sem verificações.

**Restrições:** O utilizador necessita de estar autenticado.

---

<br>

| ID: RF-1.5 | Nome: Ver menu de opções da Conta | Tipo: Conta | Prioridade: Alta|
| --- | --- | --- | --- |

**Descrição:** O programa deverá apresentar ao utilizador aceder ao menu de opções da sua conta no qual encontra as seguintes opções: ver conta, editar carteira, listar grupos, listar convites, desbloquear poaps e eventos a seguir.

**Verificações:** Sem verificações.

**Restrições:** O utilizador necessita de estar autenticado.

---

<br>

| ID: RF-1.6 | Nome: Editar Password | Tipo: Conta | Prioridade: Média|
| --- | --- | --- | --- |

**Descrição:** O programa deverá permitir alterar a password do utilizador, apresentando um campo para preeencher a nova password e outro para repetir.

**Verificações:** 
O sistema deverá verificar se:
- A password repetida é igual

No caso de algum dos pontos acima referidos não se verifique, o sistema deverá emitir um alerta e não permitir a alteração da password.


**Restrições:** O utilizador necessita de estar autenticado.

---

<br>

| ID: RF-1.7 | Nome: Criar Regra para Whitelist | Tipo: Conta | Prioridade: Alta |
| --- | --- | --- | --- |


**Descrição:** O programa deverá permitir ao Utilizador com os devidos privilégios, de criar regras para adição de e-mails a Whitelist, seja tendo em conta o dominio dos emails ou adicionanda email a email

**Verificações:**
O sistema deverá verificar se:
- Regra duplicada
- Permissões do utilizador.

No caso de algum dos pontos acima referidos não se verifique, o sistema deverá emitir um alerta e não permitir a criação da regra.

**Restrições:** O utilizador registado e com devidas permissões. 

---

<br>

| ID: RF-1.8 | Nome: Listar Regras para Whitelist | Tipo: Conta | Prioridade: Média |
| --- | --- | --- | --- |

**Descrição:** O programa deverá permitir ao Utilizador com os devidos privilégios de visualizar as regras criadas. 

**Verificações:**
O sistema deverá verificar se:
- Existem regras
- Permissões do utilizador.

No caso de algum dos pontos acima referidos não se verifique, o sistema deverá emitir um alerta e não permitir a listagem da regra.

**Restrições:** O utilizador registado e com devidas permissões. 

---

<br>

| ID: RF-1.9 | Nome: Editar Regras para Whitelist | Tipo: Conta | Prioridade: Média |
| --- | --- | --- | --- |

**Descrição:** O programa deverá permitir ao Utilizador, com os devidos privilégios, de editar regra selecionada. 

**Verificações:**
O sistema deverá verificar se:
- Existem regra
- Regra duplicada
- Permissões do utilizador

No caso de algum dos pontos acima referidos não se verifique, o sistema deverá emitir um alerta e não permitir a edição da regra.

**Restrições:** O utilizador registado e com devidas permissões. 

---

<br>

| ID: RF-1.10 | Nome: Criar Promotor | Tipo: Conta | Prioridade: Alta |
| --- | --- | --- | --- |

**Descrição:** O programa deverá permitir ao Utilizador (Admin), criar um promotor, com o campo email e a password, que é gerada automaticamente.

**Verificações:**
O sistema deverá verificar se:
- Todos os campos obrigatórios do formulário estão preenchidos.
- Todos os dados estão no formato esperado.
- O email não existe na base de dados.

No caso de algum dos pontos acima referidos não se verifique, o sistema deverá emitir um alerta e não permitir a criação do promotor.

**Restrições:** O utilizador tem de estar registado e ser o Admin. 

---

<br>

| ID: RF-1.11 | Nome: Remover Promotor | Tipo: Conta | Prioridade: Alta |
| --- | --- | --- | --- |

**Descrição:** O programa deverá permitir ao Utilizador (Admin), apagar um promotor, assim que este seja eliminado também serão os dados do sistema, aconselhando-se a usar em caso de algum erro na criação do promotor (por exemplo: erro no email).

**Verificações:**
O sistema deverá verificar se:
- O promotor existe na base de dados.
- Tem alguns dados pertencentes a este e apagar da base de dados.

No caso de algum dos pontos acima referidos não se verifique, o sistema deverá emitir um alerta a avisar que a eliminação não foi bem sucedida.

**Restrições:** O utilizador tem de estar registado e ser o Admin.  

---

<br>

| ID: RF-1.12 | Nome: Listar Promotor | Tipo: Conta | Prioridade: Alta |
| --- | --- | --- | --- |

**Descrição:** O programa deverá permitir ao Utilizador (Admin) visualizar os promotores existentes na base de dados. 

**Verificações:**
O sistema deverá verificar se:
- Existem promotores.

No caso do ponto acima referido não se verifique, o sistema deverá emitir um alerta ou notificar se existe ou não promotor.

**Restrições:** O utilizador tem de estar registado e ser o Admin.

---

<br>

| ID: RF-1.13 | Nome: Gestão da conta dos Promotores | Tipo: Conta | Prioridade: Alta |
| --- | --- | --- | --- |

**Descrição:** O programa deverá permitir ao Utilizador (Admin) ligar/desligar a conta para bloquear/desbloquear o acesso do promotor e bloquear a acesso e outras funcionalidades. 

**Verificações:**
O sistema deverá verificar se:
- Existem promotores.

No caso do ponto acima referido não se verifique, o sistema deverá emitir um alerta ou notificar se existe ou não promotor.

**Restrições:** O utilizador tem de estar registado e ser o Admin.
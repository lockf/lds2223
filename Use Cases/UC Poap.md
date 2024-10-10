### **UC-2.1: Criar Poap**

<br>

**Descrição:**
Este use case descreve a criação de um Poap por um Administrador.

**Prioridade:**
Alta

**Atores:**
Utilizador Autenticado (Administrador)

**Sequências:**
| # | Utilizador (Ações) | Sistema |
| --- | --- | --- |
| 1 | O Administrador  seleciona a opção de criar Poap | O sistema, após a criação do evento, apresenta o campo para a adição da imagem para o Poap |
| 2 | O Administrador adiciona imagem do Poap ao sistema | ---  |
| 3 | O Administrador seleciona a opção "Criar Poap" | O sistema verifica se imagem tem o formato e dimensões correctos. Caso formato e/ou dimensões estejam incorrectos, é emitido um alerta ao utilizador indicando que deve adicionar uma outra imagem. Caso formato e/ou dimensões estejam correctos, o Poap é criado  |

**Requisitos Funcionais:**
- RF-2.1: Criar Poap

---

<br>

### **UC-2.2: Redimir Poap**

<br>

**Descrição:**
Este use case descreve como o Participante redime um Poap.

**Prioridade:**
Alta

**Atores:**
Utilizador Autenticado (Participante)
Utilizador Autenticado (Administrador)

**Sequências:**
| # | Utilizador (Ações) | Sistema |
| --- | --- | --- |
| 1 | O Administrador partilha com os participantes o código do Poap | ---  |
| 2 | O Participante acede à opção para redimir o Poap, selecionando "Redimir Poaps" | O sistema apresenta a lista de eventos a que o Participante irá atender   |
| 3 | O Participante seleciona o evento | O sistema apresenta o campo para inserção do código que permite redimir o Poap do evento selecionado   |
| 4 | O Participante insere o código no campo devido e seleciona "Redimir Poap" | O sistema verifica se o código é o correcto, se sim, o participante redime o Poap e o sistema adiciona o Poap redimido à carteira do Participante , se não, o sistema notifica o Participante que o código está errado e deve ser inserido novamente   |

**Requisitos Funcionais:**
- RF-2.2: Redimir Poap

---

<br>

### **UC-2.3: Ver Poaps Criados**

<br>

**Descrição:**
Este use case descreve como o Administrador visualiza os Poaps criados.

**Prioridade:**
Baixa

**Atores:**
Utilizador Autenticado (Administrador)


**Sequências:**
| # | Utilizador (Ações) | Sistema |
| --- | --- | --- |
| 1 | O Administrador acede à galeria de Poaps criados, selecionando "Poaps Criados - Galeria" no menu | O sistema filtra quais os Poaps criados pelo O Administrador e apresenta o resultado |
| 2 | O Administrador explora a galeria | O sistema apresenta os Poaps criados pelo Administrador|
| 3 | O Administrador escolhe o Poap, selecionando "Ver Poap" | O sistema mostra ao Administrador os detalhes do Poap selecionado  |
| 4 | O Administrador vê pagina do Poap selecionado | ---  |


**Requisitos Funcionais:**
- RF-2.3: Ver Poap

---

<br>

### **UC-2.4: Ver Poaps Redimidos**

<br>

**Descrição:**
Este use case descreve como o Participante visualiza os Poaps redimidos.

**Prioridade:**
Baixa

**Atores:**
Utilizador Autenticado (Participante)

**Sequências:**
| # | Utilizador (Ações) | Sistema |
| --- | --- | --- |
| 1 | O Participante acede à galeria de Poaps redimidos, selecionando "Poaps Redimidos - Galeria" no menu | O sistema filtra quais os Poaps redimidos pelo Participante na sua carteira e mostra o resultado |
| 2 | O Participante explora a galeria | O sistema mostra os Poaps na carteira |
| 3 | O Participante escolhe o Poap, selecionando "Ver Poap" | O sistema mostra ao Participante os detalhes do Poaps selecionado  |
| 4 | O Participante vê pagina com detalhes do Poap selecionado | --- |

**Requisitos Funcionais:**
- RF-2.4: Ver Poaps Redimidos

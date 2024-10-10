| ID: RF-2.1| Nome: Criar Poap| Tipo: Poap | Prioridade: Alta|
| --- | --- | --- | --- |

**Descrição:** O programa deverá permitir ao Administrador realizar o pedido à API para cunhar o Poap através de "smart contracts", preenchendo um formulário onde associa o evento criado ao Poap a criar. Após isto, é criado um código que será fornecido a quem atende o evento para redimir o Poap.|

**Verificações:**
O sistema deverá verificar se:
- A conta Metamask existe.
- Evento existe.

No caso de algum dos pontos acima referidos não se verifique, o sistema deverá emitir um alerta e não permitir a criação do Poap.

**Restrições:** O utilizador (Administrador) registado. 

---

<br>

| ID: RF-2.2 | Nome: Redimir Poap | Tipo: Poap | Prioridade: Alta|
| --- | --- | --- | --- |

**Descrição:** Após realizado o pedido de cunho do Poap, o utilizador que atendeu o evento pode redimir o Poap para a sua carteira. O utilizador recebe o código (o criador do evento escolhe como deve fornecer este código, por exemplo, apresentação do código no evento ou envio por email), que deve inserir na aplicação, para completar esta operação.

**Verificações:**
O sistema deverá verificar se:
- A conta do utilizador existe na base de dados.
- A conta Metamask existe.

No caso de algum dos pontos acima referidos não se verifique, o sistema deverá emitir um alerta e não permitir a criação do Poap.

**Restrições:** O utilizador (Participante) registado, atender a evento, preencher código correctamente. 

---

<br>

| ID: RF-2.3 | Nome: Ver Poaps Criados | Tipo: Poap  | Prioridade: Baixa |
| --- | --- | --- | --- |

**Descrição:** O utilizador (Administrador) pode visualizar no programa os seus Poaps criados.  É apresentada uma lista dos Poaps que o utilizador criou e este pode selecionar o Poap a vizualizar 

**Verificações:**
O sistema deverá verificar se:
- A conta do utilizador existe na base de dados.
- A conta Metamask existe.
- O Poap foi previamente criado.

No caso de algum dos pontos acima referidos não se verifique, o sistema deverá emitir um alerta e não serão mostrados os Poaps do utilizador.

**Restrições:** O utilizador (Administrador) registado. 

---

<br>

| ID: RF-2.4 | Nome: Ver Poaps Redimidos | Tipo: Poap  | Prioridade: Baixa |
| --- | --- | --- | --- |

**Descrição:** O utilizador (Participante) pode visualizar no programa os seus Poaps redimidos.  É apresentada uma lista dos Poaps que o utilizador possui e redimiu, e este pode selecionar o Poap a vizualizar.

**Verificações:**
O sistema deverá verificar se:
- A conta do utilizador existe na base de dados.
- A conta Metamask existe.

No caso de algum dos pontos acima referidos não se verifique, o sistema deverá emitir um alerta e não serão mostrados os Poaps do utilizador.

**Restrições:** O utilizador (Participante) registado, atender a eventos.

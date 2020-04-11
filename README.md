# LP1_P1 - Wolf & Sheep

## Autoria

### Grupo

Afonso Rosa - a21802169  
André Vitorino - a21902663  

### Distribuição

#### Afonso Rosa

O aluno, Afonso Rosa, foi o responsável pelas classes `Sheep.cs`, `Wolf.cs`,
`VictoryConditions.cs` e `IntroRules.cs`, tendo sido o responsável pela lógica,
estruturação e funcionamento das mesmas, embora isto não tenha sido obtido sem
o apoio direto do colega, André Vitorino, que otimizou o funcionamento das
classes.

O aluno também ajudou na estruturação lógica da class `Program.cs` embora não
tenha sido o principal responsável.

Tratou ainda da documentação das classes pelas quais foi o responsável,
tendo confirmado com o colega a credibilidade da mesma.

#### André Vitorino

O aluno, André Vitorino, foi o responsável pelas classes `Board.cs` e
`Program.cs`, tendo sido o responsável pela lógica, estruturação e funcionamento
das mesmas.

O aluno fez ainda pequenas otimizações e o algoritmo para ver os vizinhos de
uma peça no tabuleiro de jogo.

Tratou ainda da estruturação e lógica do programa como um todo e da documentação
das classes pelas quais foi o responsável. Também ajudou o colega, Afonso Rosa,
no funcionamento das suas classes e verificou a documentação das mesmas.

### Repositório

<https://github.com/AfonsoGR/LP1_Projeto_1>

## Arquitetura da solução

### Descrição da solução

O programa foi organizado em seis classes diferentes, cada uma responsável por
uma parte específica do programa. A base do programa é a `Board.cs` que serve
como meio de interação entre o `Wolf.cs` e as `Sheep.cs`.

O `Program.cs` contém as regras e o "setup" inicial do jogo, utilizando para
este a `Board.cs`, o `Wolf.cs` e a `Sheep.cs`. No decorrer do jogo o
`Program.cs` utiliza o `VictoryConditions.cs` para verificar se já há um
vencedor entre o `Wolf.cs` e as `Sheep.cs`.

Também contém o método `Render()` para mostrar o estado atual do tabuleiro aos
jogadores, o qual é atualizado sempre que é efetuada uma jogada.

### Fluxograma

![Fluxograma](Fluxograma.png)

## Referências

Foi usado um README.md de referência de um projeto do aluno, André Vitorino,
para ter exemplos concretos de "markdown".

[Projeto de referência](https://github.com/Xx-hugo-xX/LP2_P2/tree/master) do
"markdown".

O algoritmo usado para encontrar os vizinhos de uma peça no tabuleiro é baseado
num algoritmo presente no projeto de DJD3 destes dois elementos do grupo, sendo
o aluno André Vitorino o responsável pela realização do algoritmo.

[Projeto de referência](https://github.com/Freeze88-2/MedievalGhostbuster)
com o algoritmo em questão.

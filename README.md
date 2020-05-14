
# Felli - Quarantine edition  

Resolução do 2º projeto de LP1 2019/2020

## Sumário

Este [repositório] é composto pelos seguintes elementos:

* O código C# que compõe o nosso programa;
* A divisão do projeto pelos membros do grupo;
* A arquitetura do programa;
* Diagrama UML;
* Referências.
  
### Divisão de trabalho no projeto

|Afonso                 |André                  |Rui                    |
|:---------------------:|:---------------------:|:---------------------:|
|                       |Programa Base          |                       |
|Primeiros Turnos       |Fazer a board          |Backseat Coding        |
|Escolha de cor         |_Intro Screen_         |Backseat Coding        |
|Instruções             |Movimentação das peças |Validação das peças    |
|Condição de _winner_   |_Beautification_       |Tabela do vencedor     |
|README                 |README                 |README                 |
|Documentação XML       |Comentários para XML   |UML                    |

**Nota:** A tabela representada em cima não reflete na totalidade a divisão do
 trabalho, uma vez que na maior parte do tempo estávamos a trabalhar em
 colaboração através da partilha de ecrã no Discord.

## Arquitetura da solução

### Descrição da Solução

Este programa começa por mostrar uma mensagem de boas vindas aos jogadores
 seguida pelas instruções do jogo e pela confirmação para começar. De seguida
 pede ao player 1 para escolher a cor com que quer jogar e quem é que joga
 primeiro.

A partir deste momento, entra-se no game loop e é desenhado no ecrã o tabuleiro
 com as peças nas posições iniciais e uma tabela a dizer de quem é a vez e o
 numero de turnos. Debaixo disto, é pedido ao jogador que tem a vez para
 escolher a peça que quer levantar e depois pergunta onde este a quer
 colocar. Após esta ser colocada isto repete-se até alguém ficar sem peças.

As posições pedidas pelo programa são organizadas de acordo com a figura 1.

![Board](board.png "Posições no tabuleiro")  
__Figura 1__ - Repartição das posições no tabuleiro.

Se os jogadores tentarem fazer jogadas ilegais é mostrada uma mensagem a dizer
 que os seus inputs são inválidos.

Por fim, o game loop termina quando um jogador ficar sem peças, sendo dada a
 vitória ao outro e aparece um novo quadro juntamente com a tabuleiro final a
 felicitar quem ganhou e a dizer quantos turnos demorou.

### Diagrama UML

![UML](UML.png "UML")

### Referências

* [TictacToeV2 - Nuno Fachada]
  
### Metadados

* Autores: [Afonso Lage (a21901381)], [André Santos (a21901767)],
 [Rui Vilar (a21902960)]
  
* Professor: [Nuno Fachada]

* Curso: [Licenciatura em Videojogos]

* Universidade: [Universidade Lusófona de Humanidades e Tecnologias][ULHT]

[repositório]:https://github.com/andrepucas/lp1_felli
[TictacToeV2 - Nuno Fachada]:https://bit.ly/2T1KG8C
[Afonso Lage (a21901381)]:https://github.com/AfonsoLage-boop
[André Santos (a21901767)]:https://github.com/andrepucas
[Rui Vilar (a21902960)]:https://github.com/ruivilar
[Nuno Fachada]:https://github.com/fakenmc
[Licenciatura em Videojogos]:https://www.ulusofona.pt/licenciatura/videojogos
[ULHT]:https://www.ulusofona.pt/
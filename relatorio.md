Quando se inicia o programa aparecem 2 quadros, um deles com o nome do jogo e a 
autoria, e outro com as instruções. Em baixo pede ao jogador para escrever "S" para começar a jogar. Isto tudo acontece através do método ``Intro()``.

Neste momento entra-se no método ``Start()`` que é onde consta o _Game Loop_ do jogo.

Após o jogador introduzir a letra "S" no programa, este pede ao Player1 para escolher a cor com que este quer jogar. De seguida pergunta qual é o jogador que vai jogar primeiro. O método ``GetTurn()`` é o responsável por gerir este procedimento.

De seguida aparece o tabuleiro de jogo, juntamente com um mostrador a referir-se a quem é o próximo a jogar e em que turno se encontra o jogo.
Esta tabela inicial é gerada através do método ``ShowBoard()``. 

Juntamente com a tabela e o mostrador, em baixo apresenta-se uma frase que pede ao jogador para introduzir um número entre 1 a 13. Estes números representam as posições de cada espaço jogável no tabuleiro, através do método ``PlayerPicks()``.

Logo de seguida, pede ao jogador para introduzir a posição para a qual este quer mover a peça que escolheu anteriormente. Neste caso, como é o primeiro turno só existe uma posição livre - posição 7. Isto tudo acontece dentro do método ``PlayerMoves()``.

Após o jogador ter movido a peça, o programa volta ao método ``ShowBoard()`` onde este vai atualizar o tabuleiro, retirando a peça da posição anterior e posicionando-a na nova posição, anteriormente escolhida pelo jogador.
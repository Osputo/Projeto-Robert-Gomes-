


VAR conversa = true



{conversa:-> main|-> pergunta}

=== main ===

Você e o detetive né?

Pode me ajudar achando quem pegou a chave da 108?

Ela esta com um dos alunos que estão na biblioteca.

~ conversa = !conversa

->DONE

=== pergunta ===

Qual aluno pegou a chave?
    + [Camisa Verde]
        -> chosen("Você errou!")
    + [Camisa Branca]
        -> chosen("Acertou, aqui esta a chave!")
    + [Não sei]
        -> chosen("Então volte mais tarde.")
    + [Camisa Amarela]
        -> chosen("Você errou!")
    + [Camisa Vermelha]
        -> chosen("Você errou!")
    + [Camisa Preta]
        -> chosen("Você errou!")

    
    
=== chosen(pokemon) ===
{pokemon}
->END

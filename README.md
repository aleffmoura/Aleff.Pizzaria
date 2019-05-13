# Aleff.Pizzaria

# Existe um arquivo para o postman.

## Sobre o docker
Não consegui fazer funcionar o migration, onde criaria o banco automaticamente.
por esse motivo tem um script de banco na raiz do projeto.
inicie o projeto com o docker compose, apos subir as imagens dos containers, fazer conexão no banco por sql managment e executar o script de criação.
importante ressaltar, a maquina a qual esta rodando deve ter o sql server parado, tendo em vista que a porta esta a mesma.


## Importante
Importante falar, como o teste parecia mais ser um de full-stack, pelo menos do meu ponto de vista, eu fiz a api conforme eu achei que fosse melhor.
Então, talvez esteja bem fora dos requisitos, peço desculpa desde ja.

## Oque fazer antes.
Caso não for utilizar o docker, e sim o projeto normal:
primeiro de tudo, deve-se aplicar o Update-Database do migration para poder criar o banco de dados.
segundo, caso seja necessario alterar as connections string, uma localizada na classe: DesignTimeDbContextFactory
outra localizada na appsettings.json 

## Como fiz o sistema, tendo em vista os requisitos.
Primeiro deve-se adicionar uma pizza, escolhendo seu tamanho e seu sabor.
Tamanhos podem ser:"small","medium","large"
sabores podem ser: "Calabresa","Marguerita"."Portuguesa"

Ao criar uma pizza, caso queira colocar adicionais, deve ser realizada uma chamada Patch.
opções de adicionais são: "Bacon","EdgeStuffed","NoOnion". caso colocado uma opção diferente, retornara erro.

Após finaliza a pizza, adicionando e/ou depois editando, necessario realizar um post do Id da pizza na order para finalizar o pedido.
Após finalizar com a order pode ser dado um Get na order com seu Id, retornando detalhes.

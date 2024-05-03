# Rota de Viagem #
Escolha a rota de viagem mais barata independente da quantidade de conexões.
Para isso precisamos inserir as rotas.

# API
## CRUD de cadastro de ROTAS ##
* Deverá construir um endpoint de CRUD as rotas disponíveis:
```
Origem: GRU, Destino: BRC, Valor: 10
Origem: BRC, Destino: SCL, Valor: 5
Origem: GRU, Destino: CDG, Valor: 75
Origem: GRU, Destino: SCL, Valor: 20
Origem: GRU, Destino: ORL, Valor: 56
Origem: ORL, Destino: CDG, Valor: 5
Origem: SCL, Destino: ORL, Valor: 20
```

## Explicando ## 
Uma viajem de **GRU** para **CDG** existem as seguintes rotas:

1. GRU - BRC - SCL - ORL - CDG ao custo de $40
2. GRU - ORL - CDG ao custo de $61
3. GRU - CDG ao custo de $75
4. GRU - SCL - ORL - CDG ao custo de $45

O melhor preço é da rota **1**, apesar de mais conexões, seu valor final é menor.
O resultado da consulta deve ser: **GRU - BRC - SCL - ORL - CDG ao custo de $40**.

Sendo assim, o endpoint de consulta deverá efetuar o calculo de melhor rota.


# FRONT-END (Opcional)
Tela para consumir a API (incluir/alterar/excluir)
Tela para consultar melhor rota
* Pode ser apenas uma tela, ou mais, fica a critério do desenvolvedor


### Projeto ###
- Interface Front-End (opcional)
	Cadastro: CRUD de Rotas
	Consulta: Deverá ter 2 campos para consulta de rota: **Origem-Destino** e exibir o resultado da consulta chamando a API
	
- Interface Rest (Obrigatório)
    A interface Rest deverá suportar o CRUD de rotas:
    - Manipulação de rotas, dados podendo ser persistidos em arquivo, bd local, etc...
    - Consulta de melhor rota entre dois pontos.
	
  Exemplo:
  ```
  Consulte a rota: GRU-CGD
  Resposta: GRU - BRC - SCL - ORL - CDG ao custo de $40
  
  Consulte a rota: BRC-SCL
  Resposta: BRC - SCL ao custo de $5
  ```


## Entregáveis ##
* Envie apenas o código fonte
* Preferência no github ou no OneDrive (zipado)
* Priorize/Estruturar sua aplicação seguindo as boas práticas de desenvolvimento
* Evite o uso de frameworks ou bibliotecas externas à linguagem

# Calculadora API (Lei-me gerado por inteligência artifial)

A Calculadora API é uma aplicação que permite realizar operações matemáticas básicas (soma, subtração, multiplicação, divisão) via uma API RESTful. Ela também mantém um histórico de cálculos realizados, que pode ser consultado e excluído.

## Funcionalidades

1. **Realizar Operações Matemáticas**: Realize cálculos utilizando dois valores e uma operação (soma, subtração, multiplicação, divisão).
2. **Histórico de Cálculos**: Consulte o histórico das operações realizadas, com resultados e a data/hora de cada cálculo.
3. **Excluir Operações**: Exclua operações do histórico da API.

## Tecnologias

- **Backend**: ASP.NET Core (C#)
- **Frontend**: HTML, JavaScript, e jQuery para interatividade com a API

## Instruções de Uso

### 1. Realizar uma Operação

- Acesse o formulário na interface web e insira dois valores numéricos.
- Selecione a operação desejada (soma, subtração, multiplicação ou divisão).
- Clique no botão "Calcular" para realizar a operação.
- O resultado será exibido e o cálculo será armazenado no histórico.

### 2. Visualizar o Histórico de Cálculos

- O histórico de cálculos realizados será exibido em uma tabela abaixo do formulário de operação.
- Cada linha da tabela contém:
  - ID da operação
  - Valores A e B
  - Operação realizada (soma, subtração, etc.)
  - Resultado do cálculo
  - Data e hora em que a operação foi realizada
  - Botão para excluir a operação

### 3. Excluir uma Operação

- Clique no botão "Excluir" ao lado de uma operação no histórico para removê-la.

## Endpoints da API

A API tem os seguintes endpoints disponíveis:

### `POST /api/calculadora/calcular`

Realiza uma operação matemática e retorna o resultado.

**Corpo da requisição:**
```json
{
  "valorA": 10,
  "valorB": 20,
  "operacao": "+"
}

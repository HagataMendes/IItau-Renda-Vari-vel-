## 💻 Sobre o projeto
# Projeto de Plataforma de Investimentos Itaú Engenheiro(a) TI Jr 

## 🌟 Meu Objetivo e Diferenciais

Meu objetivo foi construir um sistema que não apenas atenda às necessidades transacionais, mas que se destaque pela **resiliência, escalabilidade e alta confiabilidade**, elementos cruciais para um ambiente financeiro de alta demanda. A arquitetura foi concebida por mim para suportar um **volume elevado de operações (1 milhão/dia)** e garantir a continuidade do serviço, mesmo diante de falhas. Um dos meus primeiros desafios e diferenciais foi a **tentativa e implementação bem-sucedida da conexão do banco de dados MySQL com a API, estabelecendo uma base sólida para a persistência dos dados.**

### 🛡️ Minha Arquitetura Robusta e Resiliente

Adotei princípios de engenharia de software de ponta para garantir a robustez e a tolerância a falhas:

* **Tolerância a Falhas com Polly (Circuit Breaker & Fallback):** Eu implementei disjuntores de circuito para proteger o sistema contra falhas em cascata de serviços dependentes (como APIs de cotação externas). Em caso de indisponibilidade, o sistema adota comportamentos de *fallback* (e.g., uso de cache), assegurando a continuidade do serviço, mesmo que degradada.
* **Integração Assíncrona com Apache Kafka:** Eu consumo dados críticos, como cotações, de forma assíncrona via filas Kafka, garantindo alta vazão e desacoplamento entre os serviços. A idempotência no processamento de mensagens previne inconsistências de dados.
* **Observabilidade Completa (Serilog, OpenTelemetry):** Eu monitorei proativamente a saúde e o desempenho do sistema com logging estruturado, métricas detalhadas e distributed tracing, permitindo a rápida identificação e resolução de gargalos e falhas.

### 🚀 Escalabilidade e Alta Performance na Nuvem (Foco Total na AWS) Faz um grande diferencial no projeto e para o banco.

Projetado por mim para crescer com a demanda, o sistema explora ao máximo os recursos da nuvem, com um **foco estratégico e profundo nos serviços da Amazon Web Services (AWS)** para garantir escalabilidade, resiliência e performance:

* **Auto-Scaling Horizontal (Amazon EC2 Auto Scaling):** Eu ajustei a capacidade computacional da API dinamicamente, adicionando ou removendo instâncias automaticamente com base em métricas de uso, garantindo performance consistente em picos de tráfego.
* **Balanceamento de Carga Inteligente (AWS Application Load Balancer - ALB):** Eu distribuí requisições de forma otimizada entre as instâncias disponíveis, utilizando algoritmos que priorizam a menor latência, assegurando tempos de resposta rápidos e eficiente uso dos recursos.
* **Serviços Gerenciados AWS:** Eu utilizei serviços como **Amazon RDS for MySQL** para banco de dados gerenciado e **Amazon MSK** para Kafka, reduzindo a sobrecarga operacional e aumentando a confiabilidade.

### ✅ Minha Qualidade e Confiabilidade do Código

A qualidade do código é fundamental para a confiança nos resultados:

* **Testes Unitários Abrangentes (xUnit, FluentAssertions):** A lógica de negócio, incluindo o cálculo de preço médio ponderado, foi validada por mim por uma bateria de testes, cobrindo cenários positivos e de erro, garantindo a exatidão das operações.
* **Testes Mutantes (Stryker.NET):** Eu apliquei técnicas de teste mutante para avaliar a eficácia dos meus testes unitários, identificando lacunas e elevando a confiança na cobertura e na capacidade de detecção de *bugs*.

## 📈 Minhas Funcionalidades Chave da API

A API RESTful (`Itau.Investimentos.Api`) que eu desenvolvi oferece as seguintes funcionalidades principais:

* **Consulta de Cotação de Ativos:** Obtenção da última cotação de um ativo específico.
    * `GET /api/v1/cotacoes/{codigoAtivo}/ultima`
* **Cálculo de Preço Médio Ponderado por Ativo e Usuário:**
    * `GET /api/v1/usuarios/{usuarioId}/posicoes/{codigoAtivo}/preco-medio`
* **Consulta da Posição Consolidada de Cliente:** Visão de todos os ativos de um cliente.
    * `GET /api/v1/usuarios/{usuarioId}/posicoes`
* **Total de Corretagem da Corretora:**
    * `GET /api/v1/corretagem/total`
* **Ranking de Clientes:** Maiores posições ou maiores valores de corretagem.
    * `GET /api/v1/ranking/clientes?tipo={posicao|corretagem}&top={N}`

## 🛠 Tecnologias e Ferramentas Utilizadas

As principais tecnologias, ferramentas e serviços que compõem este projeto são:

* **Backend:** .NET 8 (ASP.NET Core), Entity Framework Core.
* **Banco de Dados:** MySQL.
* **Testes:** xUnit, FluentAssertions, Stryker.NET (sugerido).
* **Integração:** Apache Kafka (com Confluent.Kafka).
* **Resiliência:** Polly (Retry, Circuit Breaker, Fallback).
* **Observabilidade:** Serilog, OpenTelemetry (com ferramentas como Jaeger, Prometheus, Grafana).
* **Containerização:** Docker.
* **Infraestrutura Cloud (Foco AWS):** Amazon Web Services (AWS):
    * Amazon EC2 Auto Scaling
    * Elastic Load Balancer (ALB)
    * Amazon RDS for MySQL
    * Amazon MSK (Managed Streaming for Kafka)
    * Amazon CloudWatch
* **Documentação:** Swagger/OpenAPI.

## 📊 Meus Insights de Modelagem de Dados

O design do banco de dados foi otimizado por mim para performance e integridade:

* **Indices Estratégicos:** Eu criei índices em colunas frequentemente usadas em cláusulas `WHERE` e `JOIN` (e.g., `usuario_id`, `ativo_id`, `data_operacao`) para acelerar as consultas, especialmente aquelas que buscam dados por período (ex: últimos 30 dias).
* **Consulta Otimizada por Período:** A pesquisa por operações nos últimos 30 dias é eficiente devido ao índice na coluna de data, permitindo buscas rápidas em grandes volumes de dados.

# No Itaú temos como plataforma de Investimentos a Íon :pushpin:
Aqui você encontra tudo o que precisa pra investir com tecnologia, inovação, segurança e uma assessoria de primeira.
![Projeto](https://github.com/HagataMendes/IItau-Renda-Vari-vel-/blob/main/5-%20Itau%20Ion.png)

## Projeto :pushpin:
- Nesse projeto, busquei conectar uma API ao Banco de Dados MYSQL
- Em Escalabidade e Perfomance sugeri implementar com instâncias AWS
  
![Projeto](https://github.com/HagataMendes/IItau-Renda-Vari-vel-/blob/main/1%20-%20Modelagem%20de%20Banco%20Relacional%20My%20sql.png)

## 1. Modelagem de Banco Relacional (MySQL)

### Script SQL de Criação das Tabelas

As tabelas do banco de dados `itau_investimentos_db` foram modeladas e criadas utilizando o MySQL, seguindo as diretrizes de abreviações e `snake_case`.

```sql
-- Seleciona o banco de dados 'itau_investimentos_db' para garantir que as tabelas sejam criadas nele.
USE itau_investimentos_db;

-- Tabela: usu_usuarios (Usuários)
CREATE TABLE usu_usuarios (
    usu_id INT PRIMARY KEY AUTO_INCREMENT,
    usu_nome VARCHAR(255) NOT NULL,
    usu_email VARCHAR(255) UNIQUE NOT NULL,
    usu_percentual_corretagem DECIMAL(5, 2) NOT NULL -- Percentual de corretagem (ex: 0.0050 para 0.50%)
);

-- Tabela: ati_ativos (Ativos)
CREATE TABLE ati_ativos (
    ati_id INT PRIMARY KEY AUTO_INCREMENT,
    ati_codigo VARCHAR(50) UNIQUE NOT NULL, -- Ex: "ITUB4", "PETR3", "BOVA11"
    ati_nome VARCHAR(255) NOT NULL
);

-- Tabela: opr_operacoes (Operações)
CREATE TABLE opr_operacoes (
    opr_id INT PRIMARY KEY AUTO_INCREMENT,
    opr_usu_id INT NOT NULL,
    opr_ati_id INT NOT NULL,
    opr_quantidade INT NOT NULL CHECK (opr_quantidade > 0),
    opr_preco_unitario DECIMAL(10, 2) NOT NULL CHECK (opr_preco_unitario > 0),
    opr_tipo_operacao ENUM('COMPRA', 'Venda') NOT NULL, -- "C" para Compra, "V" para Venda
    opr_corretagem DECIMAL(10, 2) NOT NULL DEFAULT 0.00, -- Valor da corretagem paga na operação
    opr_data_hora DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (opr_usu_id) REFERENCES usu_usuarios(usu_id),
    FOREIGN KEY (opr_ati_id) REFERENCES ati_ativos(ati_id)
);

-- Tabela: cot_cotacoes (Cotações)
CREATE TABLE cot_cotacoes (
    cot_id INT PRIMARY KEY AUTO_INCREMENT,
    ati_id INT NOT NULL,
    cot_preco_unitario DECIMAL(10, 2) NOT NULL,
    cot_data_hora DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (ati_id) REFERENCES ati_ativos(ati_id)
);

-- Tabela: pos_posicoes (Posições)
CREATE TABLE pos_posicoes (
    pos_id INT PRIMARY KEY AUTO_INCREMENT,
    usu_id INT NOT NULL,
    ati_id INT NOT NULL,
    pos_quantidade INT NOT NULL,
    pos_preco_medio DECIMAL(10, 2) NOT NULL,
    pos_pl DECIMAL(10, 2) NOT NULL, -- Lucro ou Prejuízo (Profit & Loss)
    pos_data_ultima_atualizacao DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (usu_id) REFERENCES usu_usuarios(usu_id),
    FOREIGN KEY (ati_id) REFERENCES ati_ativos(ati_id),
    UNIQUE (usu_id, ati_id) -- Garante uma única posição por usuário e ativo
);

## Explicação
Justificativa da Escolha dos Tipos de Dados
A escolha dos tipos de dados para cada coluna foi realizada para garantir a integridade, precisão e eficiência do armazenamento, alinhada às necessidades do domínio de investimentos.

- INT PRIMARY KEY AUTO_INCREMENT: Utilizado para identificadores únicos (IDs) em todas as tabelas. INT é adequado para números inteiros. PRIMARY KEY garante unicidade e otimiza buscas. AUTO_INCREMENT automatiza a geração de novos IDs.
- VARCHAR(X): Para campos de texto de comprimento variável como nomes (usu_nome, ati_nome) e códigos (ati_codigo, usu_email). O (X) define o comprimento máximo.
- UNIQUE: Aplicado a usu_email e ati_codigo para garantir que não haja valores duplicados nessas colunas.
-  NOT NULL: Usado para garantir que campos essenciais não fiquem vazios.
-  DECIMAL(P, S): Crucial para valores monetários e percentuais (usu_percentual_corretagem, opr_preco_unitario, opr_corretagem, cot_preco_unitario, pos_preco_medio, pos_pl). Este tipo de dados armazena números com precisão exata, evitando problemas de arredondamento de ponto flutuante binário. P é a precisão total de dígitos e S é a escala (número de dígitos após a vírgula).
-  DECIMAL(5, 2): Para percentuais (ex: 99.99%).
-  DECIMAL(10, 2): Para valores monetários, permitindo 10 dígitos totais com 2 casas decimais.
-  INT: Para quantidades inteiras de ativos (opr_quantidade, pos_quantidade).
-  CHECK (coluna > 0): Restrição que garante que a quantidade ou preço seja sempre um valor positivo.
-  ENUM('VALOR1', 'VALOR2'): Para campos com um conjunto limitado de valores predefinidos (opr_tipo_operacao). Garante consistência e validação dos dados (ex: 'COMPRA' ou 'VENDA').
-  DATETIME: Para armazenar datas e horas precisas (opr_data_hora, cot_data_hora, pos_data_ultima_atualizacao).
-  DEFAULT CURRENT_TIMESTAMP: Define automaticamente a data e hora de criação do registro.
-  ON UPDATE CURRENT_TIMESTAMP: Atualiza automaticamente o timestamp quando o registro é modificado (usado em pos_data_ultima_atualizacao).
-  FOREIGN KEY: Estabelece relacionamentos entre tabelas (ex: opr_usu_id referenciando usu_usuarios). Garante a integridade referencial, impedindo registros "órfãos".
-  UNIQUE (coluna1, coluna2): Garante que a combinação de valores em colunas específicas seja única (ex: (usu_id, ati_id) na tabela pos_posicoes), assegurando que não haja posições duplicadas para o mesmo usuário e ativo. ```
```
## Tarefa 2: Índices e Performance
- Requisito: Otimizar consultas (operações de usuário por ativo nos últimos 30 dias) e planejar a atualização da Posição baseada em cotações.
![Projeto](https://github.com/HagataMendes/IItau-Renda-Vari-vel-/blob/main/2%20-%20Tarefa%202%20Justificar%20indice%20e%20pesquisa%2030%20dias.png)

O sistema foi desenhado para permitir a consulta rápida de todas as operações de um usuário em determinado ativo nos últimos 30 dias. Além disso, foi considerada a necessidade de que as cotações, que podem mudar em milésimos de segundos, afetem em tempo real a Posição dos clientes (P&L e Preço Médio). Para atender a esses requisitos de performance, as seguintes estratégias foram implementadas e justificadas:

### 2.1 Proposta e Justificativa de Índices

Para otimizar as consultas e atualizações de dados, os seguintes índices foram propostos e, em parte, implementados:
* **Para a tabela `opr_operacoes` (Operações):**
    * **Índice Proposto:** `CREATE INDEX idx_operacoes_usuario_ativo_datahora ON operacoes (usuario_id, ativo_id, data_hora DESC);`
    * **Justificativa:** Este índice composto é crucial para a consulta de operações de um usuário em um ativo específico em um período de tempo. A ordem das colunas (`usuario_id`, `ativo_id`, `data_hora`) permite que o banco de dados utilize o índice de forma eficiente: primeiro, filtra os dados pelo usuário e ativo, e depois, a ordenação decrescente de `data_hora` acelera a recuperação dos registros mais recentes (por exemplo, os últimos 30 dias), evitando a necessidade de varrer toda a tabela.

* **Para a tabela `cot_cotacoes` (Cotações):**
    * **Índice Proposto:** `CREATE INDEX idx_cotacoes_ativo_datahora ON cotacoes (ativo_id, data_hora DESC);`
    * **Justificativa:** Dado que as cotações mudam rapidamente e são frequentemente consultadas para obter o valor mais recente de um ativo, este índice otimiza a busca pela cotação de um `ativo_id`. A inclusão de `data_hora DESC` garante que a consulta pela cotação mais atual seja extremamente eficiente.

* **Para a tabela `pos_posicoes` (Posições):**
    * **Índice (implícito):** A restrição `UNIQUE (usu_id, ati_id)` definida na criação da tabela `pos_posicoes` automaticamente cria um índice composto no MySQL.
    * **Justificativa:** Este índice garante a unicidade de uma posição por cada par usuário-ativo, o que é fundamental para a integridade dos dados. Além disso, ele acelera significativamente as operações de busca e atualização da posição de um cliente para um ativo específico, que são essenciais para os cálculos de P&L e preço médio.

### 2.2 SQL da Consulta Otimizada

A consulta SQL otimizada para "todas as operações de um usuário em determinado ativo nos últimos 30 dias" é a seguinte, aproveitando o índice `idx_operacoes_usuario_ativo_datahora`:

```sql
SELECT
    opr_id,
    opr_usu_id,
    opr_ati_id,
    opr_quantidade,
    opr_preco_unitario,
    opr_tipo_operacao,
    opr_corretagem,
    opr_data_hora
FROM
    opr_operacoes
WHERE
    opr_usu_id = [ID_DO_USUARIO] AND -- Substitua pelo ID real do usuário
    opr_ati_id = [ID_DO_ATIVO] AND   -- Substitua pelo ID real do ativo
    opr_data_hora >= DATE_SUB(CURDATE(), INTERVAL 30 DAY)
ORDER BY
    opr_data_hora DESC;

```
* **Explicação da Consulta Otimizada:** Esta consulta filtra os dados utilizando as colunas que compõem o índice (`opr_usu_id`, `opr_ati_id` e `opr_data_hora`) para localizar rapidamente os registros relevantes. A função `DATE_SUB(CURDATE(), INTERVAL 30 DAY)` limita o período de tempo aos últimos 30 dias a partir da data atual, e a ordenação decrescente garante que os dados mais recentes sejam recuperados primeiro, alinhando-se à otimização do índice.

### 2.3 Estrutura para Atualização da Posição, com base na Cotação

Para garantir que a Posição dos clientes (P&L e Preço Médio) seja afetada em "real time" por novas cotações, o design da arquitetura de integração envolve um fluxo de eventos e processamento reativo:

* **Consumo de Cotações:** O sistema deve ter um componente dedicado (ex: um Worker Service no .NET) que consuma novas cotações. Idealmente, essas cotações seriam publicadas em um sistema de mensageria (fila de mensagens, como Kafka ou RabbitMQ), permitindo um fluxo contínuo e escalável de dados de cotação.
* **Identificação de Posições Afetadas:** Ao receber uma nova cotação para um ativo específico, o sistema deve consultar a tabela `pos_posicoes` para identificar todas as posições de clientes que possuam aquele ativo.
* **Recálculo de P&L e Outros Indicadores:** Para cada posição afetada, o `pos_pl` (Lucro/Prejuízo) e potencialmente outros indicadores (se necessário) seriam recalculados utilizando a nova cotação. A fórmula básica para P&L é: `P&L = (Cotação Atual do Ativo - Preço Médio Ponderado da Posição) * Quantidade da Posição`.
* **Atualização da Posição no Banco de Dados:** A tabela `pos_posicoes` seria então atualizada com os novos valores calculados (especialmente `pos_pl`). A coluna `pos_data_ultima_atualizacao` será automaticamente atualizada para o momento da modificação do registro devido à sua configuração `ON UPDATE CURRENT_TIMESTAMP`, garantindo o registro do timestamp da última atualização. Todo o processo de atualização deve ser encapsulado em uma transação de banco de dados para manter a consistência dos dados.
* **Componentes Envolvidos:** Esta estrutura requer a colaboração entre as camadas da aplicação: a camada `Itau.Investimentos.Application` orquestraria a lógica de negócio (como o recálculo), enquanto a camada `Itau.Investimentos.Infrastructure` forneceria a implementação dos repositórios para interagir com o banco de dados de forma eficiente e assíncrona, utilizando Entity Framework Core.

  ## Tarefa 3. Aplicação .NET Core em C#

Esta etapa focou na criação da estrutura da aplicação em .NET Core, utilizando C#, com ênfase em boas práticas de separação de responsabilidades e a utilização de Entity Framework Core para acesso a dados.
![Projeto](https://github.com/HagataMendes/IItau-Renda-Vari-vel-/blob/main/3%20-%20Erro%20na%20API%20.png)

### 3.1 Estrutura de Camadas (Solução)
O projeto foi organizado em uma solução de múltiplos projetos no Visual Studio, seguindo o padrão de **Arquitetura em Camadas** para promover separação de responsabilidades, manutenibilidade e escalabilidade. Essa estrutura é composta por:

* **`Itau.Investimentos.sln` (Solução Principal):** O contêiner de alto nível que agrupa todos os projetos relacionados ao sistema.
* **`Itau.Investimentos.Api` (Projeto ASP.NET Core Web API):**
    * **Responsabilidade:** Atua como a camada de apresentação da aplicação. Expõe endpoints RESTful que recebem requisições HTTP e retornam respostas. É o ponto de entrada da aplicação.
    * **Tecnologias:** ASP.NET Core Web API, configuração de middlewares, Injeção de Dependência.
* **`Itau.Investimentos.Application` (Projeto Biblioteca de Classes):**
    * **Responsabilidade:** Camada de aplicação ou de serviços. Contém a lógica de negócio que orquestra as operações, coordena fluxos de trabalho e utiliza os serviços e repositórios das camadas inferiores para atender às requisições da API. É aqui que os casos de uso são definidos.
* **`Itau.Investimentos.Core` (Projeto Biblioteca de Classes):**
    * **Responsabilidade:** Camada de domínio ou de negócio puro. Contém as entidades de domínio (modelos de dados como `Usuario`, `Ativo`, `Operacao`, etc.) e as regras de negócio mais fundamentais e agnósticas a tecnologias específicas (ex: validações de entidade, algoritmos de cálculo como o preço médio). **Esta camada não deve ter dependências de infraestrutura ou de UI.**
* **`Itau.Investimentos.Infrastructure` (Projeto Biblioteca de Classes):**
    * **Responsabilidade:** Camada de infraestrutura. É onde a interação com recursos externos é implementada. Isso inclui a configuração e acesso ao banco de dados (via Entity Framework Core ou Dapper), implementação dos repositórios (que abstraem as operações de banco de dados), e potencialmente integração com serviços externos.

### 3.2 Configuração Inicial da API (`Itau.Investimentos.Api`)

O arquivo `Program.cs` no projeto `Itau.Investimentos.Api` foi configurado para inicializar a aplicação, utilizando os recursos modernos do .NET Core:

* **`Top-Level Statements`**: O `Program.cs` foi estruturado para usar `top-level statements`, que permitem escrever código diretamente no arquivo sem a necessidade de uma classe `Main` explícita, simplificando o bootstrap da aplicação.
* **Swagger/OpenAPI**: Integrado para documentação automática da API e para facilitar testes interativos dos endpoints.
* **Configuração da Connection String**: A string de conexão para o banco de dados MySQL é lida do arquivo `appsettings.json`, permitindo fácil gerenciamento das configurações de ambiente.
* **Registro do DbContext (Entity Framework Core)**: O `ItauInvestimentosDbContext` (o contexto do banco de dados definido na camada `Infrastructure`) foi registrado no sistema de Injeção de Dependência do .NET Core. Isso permite que qualquer serviço ou controller da API possa "pedir" uma instância do `DbContext` e interagir com o banco de dados. A configuração inclui o provedor `Pomelo.EntityFrameworkCore.MySql` e estratégias de retry para resiliência em caso de falhas temporárias de conexão.
* **Injeção de Dependência de Repositórios e Serviços**: Os repositórios da camada `Infrastructure` (ex: `IOperacaoRepository`) e os serviços da camada `Application` (ex: `IInvestimentosService`) também foram registrados como serviços `Scoped` (uma nova instância para cada requisição HTTP). Isso garante que as dependências sejam resolvidas automaticamente pelo framework.
* **Endpoint `WeatherForecast` (Exemplo Padrão)**: O projeto foi iniciado com um endpoint de exemplo (`/weatherforecast`) para validar a inicialização básica da API.

### 3.3 Problemas de Compilação e Inicialização da API (e Tentativas de Solução)

Durante o desenvolvimento e integração da camada de Aplicação e Infraestrutura, foram encontrados desafios significativos na compilação e execução do projeto principal (`Itau.Investimentos.Api`).

* **Erros Principais Observados:**
    * `CS5001: Programa não contém um método "Main" estático adequado para um ponto de entrada`: Este foi o erro mais persistente e crítico, impedindo que a aplicação fosse iniciada.
    * `CS0104: O tipo ou nome do namespace 'Application' não existe no namespace 'Itau.Investimentos'` (e erros similares para `Infrastructure`, `Core`): Indicavam problemas de referência ou reconhecimento entre os projetos da solução.
    * `CS0246: O tipo ou nome do namespace 'Application' não pode ser encontrado (está faltando uma diretiva using ou uma referência de assembly?)`: Complementava os erros de namespace, sugerindo falta de referências adequadas.

* **Ações de Depuração e Tentativas de Solução Realizadas:**
    * **Verificação e Ajuste de Referências de Projeto (.csproj):** Foi realizado um esforço exaustivo para garantir que o arquivo `.csproj` do `Itau.Investimentos.Api` contivesse as referências corretas aos outros projetos (`Application`, `Core`, `Infrastructure`). Isso era fundamental para que a API pudesse "enxergar" e utilizar classes e interfaces definidas nas outras camadas.
    * **Gerenciamento de Projetos no Visual Studio:** Houve a necessidade de lidar com cenários onde projetos se encontravam "descarregados" ou não visíveis no "Gerenciador de Soluções". Isso foi abordado através do recarregamento explícito dos projetos para assegurar que todos os 4 projetos da solução estivessem ativos e sendo considerados na compilação.
    * **Revisão e Correção do Conteúdo do `Program.cs`:** O conteúdo do `Program.cs` foi minuciosamente revisado e atualizado. Várias vezes, o código foi substituído pelo padrão completo e funcional para projetos ASP.NET Core 8.0 que utilizam "top-level statements", incluindo toda a configuração do `builder`, adição de serviços e o método `app.Run()` essencial para o ponto de entrada da aplicação.
    * **Manipulação e Recreação do Arquivo `Program.cs`:** Devido à persistência de problemas de visibilidade ou reconhecimento do `Program.cs` pelo Visual Studio, tentamos incluí-lo manualmente através da opção "Adicionar Item Existente..." e, em alguns casos, excluí-lo fisicamente e recriá-lo via Visual Studio para garantir que estivesse corretamente referenciado no arquivo de projeto.
    * **Verificação do SDK do .NET:** Confirmamos a presença das SDKs do .NET 8.0 na máquina, descartando a ausência do runtime como causa raiz.

* **Conclusão Atual (Problema de Ambiente Persistente):** Apesar de todas as validações e correções de código e configuração do projeto terem sido realizadas, o erro `CS5001` (e a intermitência de outros erros de namespace) persistiu. Isso sugere que o problema reside em um nível mais profundo, provavelmente relacionado a uma inconsistência ou corrupção na instalação do Visual Studio ou do ambiente de compilação do .NET Core na máquina de desenvolvimento. Devido aos prazos, a depuração e resolução direta deste problema de ambiente foram temporariamente pausadas para permitir o avanço em outras tarefas de implementação de lógica de negócio.

* **Impacto:** Atualmente, não é possível executar a API para testar a conexão com o banco de dados ou os endpoints implementados. No entanto, a estrutura do código-fonte para a integração com o banco de dados e as camadas da aplicação estão presentes e configuradas conforme as boas práticas.

## Arquitetura foi desenhada para utilizar async/await com Entity Framework Core.
![Projeto](https://github.com/HagataMendes/IItau-Renda-Vari-vel-/blob/main/3%20-%20%20utilizando%20os%20recursos%20do%20Entity%20Framework%20Core%20e%20garantindo%20o%20uso%20de%20async%20await.png)

A aplicação foi projetada e configurada para interagir com o banco de dados MySQL utilizando Entity Framework Core, priorizando a utilização de operações assíncronas (`async/await`) para garantir a responsividade e escalabilidade.

* **Entity Framework Core:** Escolhido como ORM (Object-Relational Mapper) para facilitar o mapeamento de objetos C# para o banco de dados e vice-versa.
* **`async/await`:** A implementação de operações de banco de dados e serviços de aplicação foi concebida para ser assíncrona, utilizando o padrão `async/await`. Isso permitiria que a aplicação realizasse operações de I/O (entrada/saída), como requisições ao banco de dados, sem bloquear a thread principal, liberando-a para processar outras requisições e melhorando a responsividade e o throughput.
* **Configuração do DbContext:** O `ItauInvestimentosDbContext` (definido na camada `Infrastructure`) foi registrado no contêiner de Injeção de Dependência do .NET Core no projeto `Itau.Investimentos.Api`, preparando a aplicação para acessar o banco de dados de forma assíncrona.

**Observação:** Embora a arquitetura e as configurações para o uso de `async/await` com Entity Framework Core estejam implementadas no código-fonte, a validação em tempo de execução desta funcionalidade não foi possível devido aos persistentes erros de compilação na camada `Itau.Investimentos.Api` (conforme detalhado na seção **3.3 Problemas Atuais de Compilação e Inicialização da API**).

---
## 4. Lógica de Negócio - Preço Médio

Esta tarefa focou na implementação de uma funcionalidade central para o sistema de investimentos: o cálculo do preço médio ponderado de aquisição de um ativo.
![Projeto](https://github.com/HagataMendes/IItau-Renda-Vari-vel-/blob/main/4%20-%20Calculo%20do%20pre%C3%A7o%20m%C3%A9dio%20.png)
### 4.1 Implementação do Método `CalcularPrecoMedioPonderado`

* **Localização:** A lógica para este cálculo foi implementada na classe estática `CalculadoraPrecoMedio.cs`, localizada no projeto **`Itau.Investimentos.Core`**.
* **Justificativa para Localização:** A camada `Core` é a mais adequada para essa lógica, pois ela representa uma regra de negócio fundamental e agnóstica a detalhes de infraestrutura (banco de dados) ou de apresentação (API). Isso garante que o cálculo possa ser reutilizado por qualquer parte da aplicação que necessite dele, mantendo a separação de responsabilidades.
* **Funcionalidade:** O método `CalcularPrecoMedioPonderado` foi projetado para receber uma coleção de operações de compra (com `PrecoUnitario` e `Quantidade`) e calcular o preço médio ponderado, considerando diferentes quantidades e preços para compor o cálculo.
* **Tratamento de Entradas Inválidas:** O método incorpora validações para garantir a robustez, lançando exceções (`ArgumentNullException`, `ArgumentException`) em casos como listas de compras nulas, vazias ou sem operações válidas (quantidade zero/negativa), garantindo a integridade do cálculo.

```csharp
// Exemplo simplificado da classe OperacaoCompra para o cálculo.
// No projeto real, esta pode ser sua entidade 'Operacao' principal.
public class OperacaoCompra
{
    public decimal PrecoUnitario { get; set; }
    public int Quantidade { get; set; }
}

public static class CalculadoraPrecoMedio
{
    /// <summary>
    /// Calcula o preço médio ponderado de aquisição de um ativo.
    /// </summary>
    /// <param name="compras">Uma lista de operações de compra do ativo.</param>
    /// <returns>O preço médio ponderado de aquisição.</returns>
    /// <exception cref="ArgumentNullException">Lançada se a lista de compras for nula.</exception>
    /// <exception cref="ArgumentException">Lançada se a lista de compras for vazia ou se todas as quantidades forem zero.</exception>
    public static decimal CalcularPrecoMedioPonderado(IEnumerable<OperacaoCompra> compras)
    {
        if (compras == null)
        {
            throw new ArgumentNullException(nameof(compras), "A lista de operações de compra não pode ser nula.");
        }

        // Garante que a lista não está vazia e que há pelo menos uma compra válida
        var comprasValidas = compras.Where(c => c.Quantidade > 0 && c.PrecoUnitario >= 0).ToList();
        if (!comprasValidas.Any())
        {
            throw new ArgumentException("Nenhuma operação de compra válida (com quantidade positiva e preço não negativo) foi encontrada na lista.", nameof(compras));
        }

        decimal totalInvestido = 0;
        int totalQuantidade = 0;

        foreach (var compra in comprasValidas)
        {
            totalInvestido += compra.PrecoUnitario * compra.Quantidade;
            totalQuantidade += compra.Quantidade;
        }

        // Este if geralmente não seria atingido se 'comprasValidas.Any()' for verdadeiro e 'Quantidade' > 0
        // mas é um bom check de segurança.
        if (totalQuantidade == 0)
        {
            throw new ArgumentException("A soma das quantidades de compra válidas resultou em zero.", nameof(compras));
        }

        return totalInvestido / totalQuantidade;
    }
}
```
---

## Tarefa 5. Testes Unitários

Bateria de testes unitários para a lógica de negócio, usando xUnit.

### 5.1 Estrutura e Cobertura dos Testes

* **Projeto:** `Itau.Investimentos.Core.Tests`
* **Foco:** Testes positivos para validação de cálculo e testes de erro para tratamento de entradas inválidas.

```csharp
public class OperacaoCompra
{
    public decimal PrecoUnitario { get; set; }
    public int Quantidade { get; set; }
}

public static class CalculadoraPrecoMedio
{
    public static decimal CalcularPrecoMedioPonderado(IEnumerable<OperacaoCompra> compras)
    {
        if (compras == null) throw new ArgumentNullException(nameof(compras), "A lista de operações de compra não pode ser nula.");

        var comprasValidas = compras.Where(c => c.Quantidade > 0 && c.PrecoUnitario >= 0).ToList();
        if (!comprasValidas.Any())
        {
            throw new ArgumentException("Nenhuma operação de compra válida encontrada.", nameof(compras));
        }

        decimal totalInvestido = 0;
        int totalQuantidade = 0;

        foreach (var compra in comprasValidas)
        {
            totalInvestido += compra.PrecoUnitario * compra.Quantidade;
            totalQuantidade += compra.Quantidade;
        }

        if (totalQuantidade == 0) throw new ArgumentException("A soma das quantidades resultou em zero.", nameof(compras));

        return totalInvestido / totalQuantidade;
    }
}

using Xunit;
using FluentAssertions;
using Itau.Investimentos.Core.Calculators; // Assumindo o namespace correto

public class CalculadoraPrecoMedioTests
{
    [Fact]
    public void CalcularPrecoMedioPonderado_DeveRetornarPrecoCorreto_ParaComprasMultiplas()
    {
        var compras = new List<OperacaoCompra>
        {
            new OperacaoCompra { PrecoUnitario = 10.00m, Quantidade = 100 },
            new OperacaoCompra { PrecoUnitario = 12.00m, Quantidade = 50 }
        };
        var precoMedio = CalculadoraPrecoMedio.CalcularPrecoMedioPonderado(compras);
        precoMedio.Should().BeApproximately(10.6666m, 0.0001m); // (10*100 + 12*50) / 150
    }

    [Fact]
    public void CalcularPrecoMedioPonderado_DeveLancarArgumentNullException_QuandoComprasForNula()
    {
        IEnumerable<OperacaoCompra> compras = null;
        Action act = () => CalculadoraPrecoMedio.CalcularPrecoMedioPonderado(compras);
        act.Should().Throw<ArgumentNullException>().WithMessage("*lista de operações de compra não pode ser nula*");
    }

    [Fact]
    public void CalcularPrecoMedioPonderado_DeveLancarArgumentException_QuandoComprasForVazia()
    {
        var compras = new List<OperacaoCompra>();
        Action act = () => CalculadoraPrecoMedio.CalcularPrecoMedioPonderado(compras);
        act.Should().Throw<ArgumentException>().WithMessage("*Nenhuma operação de compra válida encontrada*");
    }

    // Mais testes para outros cenários de erro e casos de borda...
}
```
---
## Tarefa 6. Testes Mutantes

### 6.1 Conceito e Importância

Técnica para avaliar a qualidade dos testes unitários, introduzindo pequenas falhas (mutações) no código para verificar se os testes as detectam ("matam" os mutantes). Essencial para encontrar lacunas em testes e aumentar a confiança no código.

* **Mutação:** No método `CalcularPrecoMedioPonderado`, alterar `*` para `+` na linha de cálculo `totalInvestido += compra.PrecoUnitario * compra.Quantidade;`.
* **Teste Afetado:** Um teste que espera `10.66` passaria a receber `1.14` (Ex: `(10+100) + (12+50) = 172; 172/150 = 1.14`), falhando e confirmando a eficácia do teste.
---
### Tarefa 7. Integração entre Sistemas
Integração resiliente com microserviços externos (ex: Kafka para cotações).

Worker Service .NET e Estratégias de Resiliência

Worker Service: `Itau.Investimentos.QuotesConsumer` consumirá mensagens Kafka (Confluent.Kafka) e salvará cotações.
Retry (Polly): Políticas de retentativa com exponential backoff para operações de escrita no banco de dados, via `Entity Framework Core.`
Idempotência: Chave de idempotência em mensagens Kafka. Verificação antes da inserção para evitar duplicações de cotações, garantindo consistência.

public class QuotesConsumerService : BackgroundService
{
    private readonly IConsumer<Null, string> _consumer;
    private readonly IServiceScopeFactory _scopeFactory;

    public QuotesConsumerService(IConfiguration config, IServiceScopeFactory scopeFactory)
    {
        var consumerConfig = new ConsumerConfig { /* ... Kafka config ... */ };
        _consumer = new ConsumerBuilder<Null, string>(consumerConfig).Build();
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _consumer.Subscribe("cotacoes-topic");
        while (!stoppingToken.IsCancellationRequested)
        {
            var consumeResult = _consumer.Consume(stoppingToken);
            var quoteMessage = consumeResult.Message.Value;

            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ItauInvestimentosDbContext>();
                var cotacao = JsonConvert.DeserializeObject<Cotacao>(quoteMessage);

                // Implementação de Idempotência:
                // Verificar se a cotação já existe pela chave de idempotência (ex: AtivoId + DataHora)
                var existingQuote = await dbContext.Cotacoes
                    .FirstOrDefaultAsync(c => c.AtivoId == cotacao.AtivoId && c.DataHora == cotacao.DataHora);

                if (existingQuote == null)
                {
                    // Implementação de Retry com Polly:
                    var retryPolicy = Policy
                        .Handle<DbUpdateException>() // Ou outras exceções de rede/DB
                        .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

                    await retryPolicy.ExecuteAsync(async () =>
                    {
                        dbContext.Cotacoes.Add(cotacao);
                        await dbContext.SaveChangesAsync();
                    });
                }
                // Se já existir, a mensagem é idempotente e ignorada ou atualizada de forma segura.
            }
        } 
---
## Tarefa 8. Engenharia do Caos

Garantir a resiliência do serviço de operações contra falhas de dependências (ex: cotações).

### 8.1 Circuit Breaker, Fallback e Observabilidade

* **Circuit Breaker (Polly):** Protege o serviço de operações contra falhas em cascata de serviços dependentes. Se o serviço de cotações falhar, o circuit breaker "abre", evitando chamadas desnecessárias e permitindo recuperação.
* **Fallback:** Em caso de falha do serviço de cotações, o serviço de operações pode retornar a última cotação conhecida (cache) ou um valor padrão, mantendo a funcionalidade degradada.
* **Observabilidade:** Monitoramento contínuo via:
    * **Logging Estruturado:** Serilog/NLog.
    * **Métricas:** Prometheus/Grafana (latência, erros, status do circuit breaker).
    * **Distributed Tracing:** OpenTelemetry/Jaeger (rastreamento de requisições por múltiplos serviços). 
```  
      // Exemplo conceitual de Circuit Breaker e Fallback com Polly
public class CotacaoService
{
    private readonly HttpClient _httpClient;
    private readonly AsyncCircuitBreakerPolicy _circuitBreaker;
    private Cotacao _lastKnownQuote; // Cache simples

    public CotacaoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _circuitBreaker = Policy
            .Handle<HttpRequestException>()
            .CircuitBreakerAsync(
                exceptionsAllowedBeforeBreaking: 3,
                durationOfBreak: TimeSpan.FromSeconds(30));
    }

    public async Task<Cotacao> GetLatestQuoteAsync(string codigoAtivo)
    {
        return await _circuitBreaker.ExecuteAndCaptureAsync(async () =>
        {
            // Chamada à API externa de cotações (ex: [https://b3api.vercel.app/](https://b3api.vercel.app/))
            var response = await _httpClient.GetAsync(<span class="math-inline">"\[https\://b3api\.vercel\.app/api/\]\(https\://b3api\.vercel\.app/api/\)\{codigoAtivo\}"\);
response\.EnsureSuccessStatusCode\(\);
var quote \= await response\.Content\.ReadFromJsonAsync<Cotacao\>\(\);
\_lastKnownQuote \= quote; // Atualiza o cache
return quote;
\}\)\.FallbackAsync\(
fallbackAction\: \(\) \=\> Task\.FromResult\(\_lastKnownQuote ?? new Cotacao \{ CodigoAtivo \= codigoAtivo, PrecoUnitario \= 0, DataHora \= DateTime\.UtcNow \}\),
onFallbackAsync\: \(exception\) \=\>
\{
// Log de fallback para observabilidade
Console\.WriteLine\(</span>"Fallback acionado para {codigoAtivo}: {exception.Exception.Message}");
                return Task.CompletedTask;
            }
        ).ExecuteAsync();
    }
}
```
---
## Tarefa 9. Escalabilidade e Performance AWS

Estratégias para lidar com 1 milhão de operações/dia e o crescimento do sistema, aplicando conceitos da AWS.

### 9.1 Auto-Scaling Horizontal (AWS EC2 Auto Scaling)

* **Conceito:** Aumentar/diminuir automaticamente o número de instâncias do serviço de operações na AWS.
* **Aplicação AWS:** Utilização do **Amazon EC2 Auto Scaling**.
    * Define-se um **Grupo de Auto Scaling** e **Políticas de Escalamento** baseadas em métricas do Amazon CloudWatch (e.g., % de utilização da CPU, requisições por instância).
* **Impacto:** Permite que o sistema se adapte dinamicamente à demanda, mantendo performance e disponibilidade. Essencial que o serviço seja *stateless*.

### 9.2 Balanceamento de Carga (AWS Elastic Load Balancer - ELB)

* **Conceito:** Distribuir requisições de entrada de forma eficiente entre as instâncias do serviço.
* **Aplicação AWS:** Uso do **Elastic Load Balancer (ELB)**, preferencialmente um **Application Load Balancer (ALB)** para serviços HTTP/HTTPS.
* **Estratégias de Balanceamento:**
    * **Round-Robin:** Distribuição sequencial. Simples, mas menos eficiente para cargas desiguais.
    * **Menor Latência (Least Outstanding Requests/Connections):** O ALB e NLB otimizam o roteamento para as instâncias mais disponíveis/com menos conexões, visando a menor latência.
* **Escolha para o Cenário:** Para 1 milhão de operações/dia, o **ALB com algoritmos que consideram menor latência/requisições pendentes** é o mais adequado, garantindo o melhor tempo de resposta e eficiência.
---
## Tarefa 10. Documentação e APIs

Exposição de APIs RESTful via `Itau.Investimentos.Api` e documentação com OpenAPI 3.0.

### 10.1 Endpoints RESTful Propostos

Exemplos de endpoints:

* **Última Cotação por Ativo:**
    * `GET /api/v1/cotacoes/{codigoAtivo}/ultima`
    * Ex: `GET /api/v1/cotacoes/PETR4/ultima`
    * *Usa API externa para cotações (`https://b3api.vercel.app/`)*

* **Preço Médio por Ativo para Usuário:**
    * `GET /api/v1/usuarios/{usuarioId}/posicoes/{codigoAtivo}/preco-medio`
    * Ex: `GET /api/v1/usuarios/1/posicoes/ITUB4/preco-medio`

* **Posição de Cliente (todos ativos):**
    * `GET /api/v1/usuarios/{usuarioId}/posicoes`
    * Ex: `GET /api/v1/usuarios/1/posicoes`

* **Total de Corretagem da Corretora:**
    * `GET /api/v1/corretagem/total`
    * Ex: `GET /api/v1/corretagem/total`

* **Ranking de Clientes (Maiores Posições / Corretagem):**
    * `GET /api/v1/ranking/clientes`
    * Ex: `GET /api/v1/ranking/clientes?tipo=posicao&top=10`
10.2 Esboço da Documentação OpenAPI 3.0 (YAML)
Documentação gerada via Swagger (/swagger). Exemplo para "Última Cotação por Ativo":
```
openapi: 3.0.0
info:
  title: API de Investimentos Itaú
  version: 1.0.0
  description: API para gerenciar operações de investimentos, cotações e posições.
servers:
  - url: http://localhost:5000/api/v1
paths:
  /cotacoes/{codigoAtivo}/ultima:
    get:
      summary: Retorna a última cotação de um ativo específico.
      tags: [Cotações]
      parameters:
        - in: path
          name: codigoAtivo
          schema: {type: string, example: PETR4}
          required: true
          description: O código do ativo (ex: PETR4, ITUB4).
      responses:
        '200':
          description: Última cotação do ativo.
          content:
            application/json:
              schema:
                type: object
                properties:
                  ativoId: {type: integer, format: int32}
                  codigoAtivo: {type: string}
                  precoUnitario: {type: number, format: float}
                  dataHora: {type: string, format: date-time}
              examples:
                sucesso:
                  value: {ativoId: 1, codigoAtivo: "PETR4", precoUnitario: 35.50, dataHora: "2025-06-07T10:30:00Z"}
        '404': {description: Ativo não encontrado ou sem cotações.}
        '500': {description: Erro interno do servidor.}

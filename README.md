## 💻 Sobre o projeto
Este projeto detalha a concepção e as soluções técnicas para um Sistema de Controle de Investimentos, com foco especial em Renda Variável. Desenvolvido para demonstrar conhecimento em modelagem de dados, otimização de performance, desenvolvimento .NET C# e integração de sistemas, ele aborda os desafios e as necessidades de um ambiente dinâmico

## O que é esperado no teste: 

- Esse teste visa conhecer o potencial de cada um dos concorrentes, encontrar pistas, prestar atenção, prestar atenção nas histórias de negócios e técnicas, em qualidade, logica, estudos extras (negócio), programação bem-feita, porém no nível de “dificuldade/performance” correto (não usar um canhão para matar uma formiga, nem um estilingue para enfrentar um leão), com bons testes e boa documentação, não restrinja a criatividade somente ao enredo, queremos ver a criatividade de cada um, é permitido o uso de IAs, para acelerar o desenvolvimento, no Itaú fazemos uso correto delas, todos os dias.

# No Itau temos como plataforma de Investimentos a Íon
Aqui você encontra tudo o que precisa pra investir com tecnologia, inovação, segurança e uma assessoria de primeira.
![Projeto](https://github.com/HagataMendes/IItau-Renda-Vari-vel-/blob/main/5-%20Itau%20Ion.png)

## Desafio Proposto :pushpin:
- Nesse projeto, busquei conectar uma API ao Banco de Dados MYSQL
  
- Modelagem de Banco Relacional (Recomendado MySQL) 
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

## 2. Índices e Performance

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

  ## 3. Aplicação .NET Core em C#

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

# Arquitetura foi desenhada para utilizar async/await com Entity Framework Core.
![Projeto](https://github.com/HagataMendes/IItau-Renda-Vari-vel-/blob/main/3%20-%20%20utilizando%20os%20recursos%20do%20Entity%20Framework%20Core%20e%20garantindo%20o%20uso%20de%20async%20await.png)
### 3.2 Configuração de Acesso a Dados e Assincronicidade

A aplicação foi projetada e configurada para interagir com o banco de dados MySQL utilizando Entity Framework Core, priorizando a utilização de operações assíncronas (`async/await`) para garantir a responsividade e escalabilidade.

* **Entity Framework Core:** Escolhido como ORM (Object-Relational Mapper) para facilitar o mapeamento de objetos C# para o banco de dados e vice-versa.
* **`async/await`:** A implementação de operações de banco de dados e serviços de aplicação foi concebida para ser assíncrona, utilizando o padrão `async/await`. Isso permitiria que a aplicação realizasse operações de I/O (entrada/saída), como requisições ao banco de dados, sem bloquear a thread principal, liberando-a para processar outras requisições e melhorando a responsividade e o throughput.
* **Configuração do DbContext:** O `ItauInvestimentosDbContext` (definido na camada `Infrastructure`) foi registrado no contêiner de Injeção de Dependência do .NET Core no projeto `Itau.Investimentos.Api`, preparando a aplicação para acessar o banco de dados de forma assíncrona.

**Observação:** Embora a arquitetura e as configurações para o uso de `async/await` com Entity Framework Core estejam implementadas no código-fonte, a validação em tempo de execução desta funcionalidade não foi possível devido aos persistentes erros de compilação na camada `Itau.Investimentos.Api` (conforme detalhado na seção **3.3 Problemas Atuais de Compilação e Inicialização da API**).

-- Teste 'itau_investimentos_db'.
USE itau_investimentos_db;

-- Tabela: usu_usuarios (Usuários)
CREATE TABLE usu_usuarios (
    usu_id INT AUTO_INCREMENT PRIMARY KEY,
    usu_nome VARCHAR(255) NOT NULL,
    usu_email VARCHAR(255) NOT NULL UNIQUE,
    usu_percentual_corretagem DECIMAL(5, 4) NOT NULL -- Percentual de corretagem (ex: 0.0050 para 0.50%)
);

-- Tabela: ati_ativos (Ativos)
CREATE TABLE ati_ativos (
    ati_id INT AUTO_INCREMENT PRIMARY KEY,
    ati_codigo VARCHAR(20) NOT NULL UNIQUE, -- Ex: "ITUB3", "PETR4", "BOVA11"
    ati_nome VARCHAR(255) NOT NULL
);

-- Tabela: opr_operacoes (Operações)
CREATE TABLE opr_operacoes (
    opr_id INT AUTO_INCREMENT PRIMARY KEY,
    opr_usu_id INT NOT NULL,
    opr_ati_id INT NOT NULL,
    opr_quantidade INT NOT NULL CHECK (opr_quantidade > 0),
    opr_preco_unitario DECIMAL(10, 2) NOT NULL CHECK (opr_preco_unitario > 0),
    opr_tipo_operacao ENUM('COMPRA', 'VENDA') NOT NULL, -- "C" para Compra, "V" para Venda
    opr_corretagem DECIMAL(10, 2) NOT NULL DEFAULT 0.00, -- Valor da corretagem paga na operação
    opr_data_hora DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (opr_usu_id) REFERENCES usu_usuarios(usu_id),
    FOREIGN KEY (opr_ati_id) REFERENCES ati_ativos(ati_id)
);

-- Tabela: cot_cotacoes (Cotação)
CREATE TABLE cot_cotacoes (
    cot_id INT AUTO_INCREMENT PRIMARY KEY,
    cot_ati_id INT NOT NULL,
    cot_preco_unitario DECIMAL(10, 2) NOT NULL CHECK (cot_preco_unitario > 0),
    cot_data_hora DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (cot_ati_id) REFERENCES ati_ativos(ati_id),
    UNIQUE (cot_ati_id, cot_data_hora) -- Garante uma cotação única por ativo por data/hora
);

-- Tabela: pos_posicoes (Posição)
CREATE TABLE pos_posicoes (
    pos_id INT AUTO_INCREMENT PRIMARY KEY,
    pos_usu_id INT NOT NULL,
    pos_ati_id INT NOT NULL,
    pos_quantidade INT NOT NULL CHECK (pos_quantidade >= 0),
    pos_preco_medio DECIMAL(10, 4) NOT NULL CHECK (pos_preco_medio >= 0), -- Preço médio de compra, 4 casas decimais para precisão
    pos_pl DECIMAL(15, 2), -- Lucro ou Prejuízo (Profit & Loss)
    FOREIGN KEY (pos_usu_id) REFERENCES usu_usuarios(usu_id),
    FOREIGN KEY (pos_ati_id) REFERENCES ati_ativos(ati_id),
    UNIQUE (pos_usu_id, pos_ati_id) -- Uma posição única por usuário e ativo
);

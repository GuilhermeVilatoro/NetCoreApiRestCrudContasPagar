CREATE TABLE [ContasPagar] (
    [Id] bigint NOT NULL IDENTITY,
    [Nome] nvarchar(200) NOT NULL,
    [ValorOriginal] decimal(18,2) NOT NULL,
    [DataVencimento] datetime2 NOT NULL,
    [DataPagamento] datetime2 NOT NULL,
    [QuantidadeDiasEmAtraso] int NOT NULL,
    [ValorCorrigido] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_ContasPagar] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [RegrasContaPagarJurosMulta] (
    [Id] bigint NOT NULL IDENTITY,
    [TipoRegra] tinyint NOT NULL,
    [Multa] decimal(18,2) NOT NULL,
    [JurosAoDia] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_RegrasContaPagarJurosMulta] PRIMARY KEY ([Id])
);
GO



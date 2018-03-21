CREATE DATABASE [conectt]
GO
CREATE TABLE [Cliente] (
          [Id] uniqueidentifier NOT NULL,
          [Celular] nvarchar(9) NULL,
          [CelularDdd] nvarchar(2) NULL,
          [Cpf] nvarchar(11) NOT NULL,
          [DataNascimento] datetime2 NOT NULL,
          [Email] nvarchar(150) NOT NULL,
          [Empresa] nvarchar(50) NOT NULL,
          [Idade] int NOT NULL,
          [Nome] nvarchar(250) NOT NULL,
          [TelefoneComercial] nvarchar(9) NULL,
          [TelefoneComercialDdd] nvarchar(2) NULL,
          CONSTRAINT [PK_Cliente] PRIMARY KEY ([Id])
      );
GO
CREATE INDEX [IX_Cliente_Id] ON [Cliente] ([Id])
GO

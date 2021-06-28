﻿--TABELAS

CREATE TABLE [dbo].[PESSOA] (
    [ID]         INT NOT NULL,
    [NM_NOME]       VARCHAR (50)  NOT NULL,
    [NM_SOBRENOME]      VARCHAR (50) NOT NULL,
    [DT_NASCIMENTO] DATETIME          NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);


--PROCEDURE

CREATE PROCEDURE dbo.GetAll
AS
    select * from PESSOA
RETURN

    
CREATE PROCEDURE dbo.DeletePessoa
(
@ID int
)
AS
DELETE
    FROM dbo.PESSOA
    WHERE 
    ID = @ID
RETURN


CREATE PROCEDURE dbo.InsertPessoa
(
@ID int,
@NOME varchar(50),
@SOBRENOME varchar(50),
@DATANASCIMENTO datetime
)
AS
Insert into PESSOA (ID,NM_NOME,NM_SOBRENOME,DT_NASCIMENTO) values
(@ID,@NOME,@SOBRENOME,@DATANASCIMENTO);
RETURN

CREATE PROCEDURE dbo.UpdatePessoa
(
@ID int,
@NOME varchar(50),
@SOBRENOME varchar(100),
@DATANASCIMENTO datetime
)
AS
update PESSOA SET NM_NOME = @NOME, NM_SOBRENOME = @SOBRENOME, DT_NASCIMENTO = @DATANASCIMENTO 
WHERE ID = @ID;
RETURN

CREATE PROCEDURE dbo.GetById
(
@ID int
)
AS
    select * from PESSOA
WHERE ID = @ID;
RETURN

CREATE PROCEDURE dbo.GetByName
(
@NOME varchar(50)
)
AS
    select * from PESSOA
WHERE NM_NOME LIKE @NOME;
RETURN
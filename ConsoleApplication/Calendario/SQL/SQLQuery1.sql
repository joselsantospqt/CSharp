--TABELAS

CREATE TABLE [dbo].[PESSOA] (
    [ID]         INT NOT NULL,
    [NM_NOME]       NCHAR (255)  NOT NULL,
    [NM_SOBRENOME]      VARCHAR (255) NOT NULL,
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
@id int
)
AS
DELETE
    FROM dbo.PESSOA
    WHERE 
    ID = @id
RETURN


CREATE PROCEDURE dbo.InsertPessoa
(
@id int,
@nome varchar(50),
@sobrenome varchar(100),
@datanascimento datetime
)
AS
Insert into PESSOA (ID,NM_NOME,NM_SOBRENOME,DT_NASCIMENTO) values
(@id,@nome,@sobrenome,@datanascimento)
RETURN

CREATE PROCEDURE dbo.UpdatePessoa
(
@id int,
@nome varchar(50),
@sobrenome varchar(100),
@datanascimento datetime
)
AS
update PESSOA SET NM_NOME = @nome, NM_SOBRENOME = @sobrenome, DT_NASCIMENTO = @datanascimento 
WHERE ID = @id;
RETURN
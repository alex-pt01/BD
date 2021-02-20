--ENTIDADE ALUNO ---------------------------------------------------------------------------------------------------------------------
--add aluno -- 
CREATE PROCEDURE SAA.addALUNO (@Nome VARCHAR(50), @Email VARCHAR(50), @RegimeEstudo VARCHAR(50), @ID_Horario INT, @ID_Biblioteca INT, @NMEC_TUTOR INT, @Idade INT, @ID_Curso INT)
AS
	DECLARE @NMECX INT;

	INSERT INTO SAA.ALUNO
	VALUES ( @Nome, @NMECX, @Email, @RegimeEstudo, @ID_Horario, @ID_Biblioteca, @NMEC_TUTOR, @Idade, @ID_Curso )
GO

--update ALUNO --
CREATE PROCEDURE SAA.updateALUNO (@Nome VARCHAR(50), @NMEC INT, @Email VARCHAR(50), @RegimeEstudo VARCHAR(50), @ID_Horario INT, @ID_Biblioteca INT, @NMEC_TUTOR INT, @Idade INT, @ID_Curso INT)
AS
    UPDATE SAA.ALUNO
    SET Nome = @Nome, NMEC = @NMEC, Email=@Email, RegimeEstudo=@RegimeEstudo, ID_Horario=@ID_Horario, ID_Biblioteca=@ID_Biblioteca, NMEC_TUTOR=@NMEC_TUTOR, Idade=@Idade, ID_Curso=@ID_Curso
    WHERE NMEC = @NMEC
GO

--Apagar aluno--
CREATE PROCEDURE SAA.del_Aluno (@NMEC int) 
AS
	DELETE FROM SAA.ALUNO WHERE NMEC = @NMEC
GO

--Numero de faltas Injustificadas de um aluno a uma uc
create proc SAA.num_falta_injustificadas ( @NMEC INT, @ID_UC INT )
AS
	select SAA.UC.ID_UC, count(tipo_Falta) as num_faltas
	from (( saa.registo join saa.uc on saa.registo.id_uc = saa.uc.id_uc ) JOIN SAA.FALTA ON SAA.REGISTO.ID_Registo = SAA.FALTA.ID_Registo ) JOIN SAA.TipoFalta ON SAA.FALTA.ID_Falta = SAA.TipoFalta.ID_Falta
	where saa.uc.id_uc = @ID_UC and saa.REGISTO.NMEC = @NMEC AND tipo_Falta = 'Injustificada'
	group by SAA.UC.ID_UC


--Numero de faltas justificadas de um aluno a uma uc
create proc SAA.num_falta_justificadas ( @NMEC INT, @ID_UC INT )
AS
	select SAA.UC.ID_UC, count(tipo_Falta) as num_faltas
	from (( saa.registo join saa.uc on saa.registo.id_uc = saa.uc.id_uc ) JOIN SAA.FALTA ON SAA.REGISTO.ID_Registo = SAA.FALTA.ID_Registo ) JOIN SAA.TipoFalta ON SAA.FALTA.ID_Falta = SAA.TipoFalta.ID_Falta
	where saa.uc.id_uc = @ID_UC and saa.REGISTO.NMEC = @NMEC AND tipo_Falta = 'justificada'
	group by SAA.UC.ID_UC




--ENTIDADE Horario ---------------------------------------------------------------------------------------------------------------------

-- add HORARIO
CREATE PROCEDURE SAA.addHorario
AS
	DECLARE @ID_HORARIOX INT;
	INSERT INTO SAA.HORARIO 
	VALUES (@ID_HORARIOX) 
GO

--PROC para apagar horarios
CREATE PROCEDURE SAA.deleteHorario (@ID_Horario INT)
AS
	DELETE SAA.HORARIO
	WHERE ID_Horario = @ID_Horario
GO

--Procedure para ter todos o ids do horário.
CREATE PROCEDURE SAA.IDS_HORARIO
AS
    SELECT ID_Horario
	FROM SAA.HORARIO
GO

--Procedure para saber a informação dos alunos com o horário selecionado
CREATE PROCEDURE SAA.ALUNOS_DO_HORARIO (@ID_Horario INT)
AS
    SELECT *
	FROM SAA.ALUNO
	WHERE ID_Horario = @ID_Horario
GO

--Procedure para saber a informação dos professores com o horário selecionado.
CREATE PROCEDURE SAA.PROFESSOR_DO_HORARIO (@ID_Horario INT)
AS
    SELECT *
	FROM SAA.PROFESSOR
	WHERE ID_Horario = @ID_HORARIO
GO

--Procedure para saber a informação das turmas com o horário selecionado.
CREATE PROCEDURE SAA.TURMAS_DO_HORARIO (@ID_Horario INT)
AS
    SELECT * 
	FROM saa.turma
	WHERE id_horario=@ID_HORARIO
GO

--Procedure para saber a informação das UCs com o horário selecionado.
CREATE PROCEDURE SAA.UCS_DO_HORARIO (@ID_Horario INT)
AS
    SELECT *
	FROM SAA.UC
	WHERE ID_Horario = @ID_Horario
GO




--ENTIDADE REGISTO
--------------------------------------------------------------------------------------------------------------------------------------------
--PROC ADD REGISTO
CREATE PROCEDURE SAA.addRegisto (@ID_Registo INT, @NMEC INT, @ID_UC INT, @ID_Aval INT)
AS
	INSERT INTO SAA.REGISTO
	VALUES (@ID_Registo INT, @NMEC INT, @ID_UC INT, @ID_Aval INT)
GO

--delete registo-
CREATE PROC SAA.delRegisto ( @ID_Registo INT )
AS
	DELETE SAA.REGISTO
	WHERE ID_Registo = @ID_Registo
GO

--VER INFO DO REGISTO--
CREATE PROC SAA.INFO_REGISTO ( @ID_Registo INT )
AS
	IF EXISTS ( SELECT * FROM SAA.NOTA WHERE ID_Registo = @ID_Registo )
		BEGIN 
			SELECT ID_Nota, Nota, SAA.NOTA.ID_Registo, NMEC, ID_UC, ID_Aval FROM SAA.NOTA JOIN SAA.REGISTO ON SAA.NOTA.ID_REGISTO=SAA.REGISTO.ID_REGISTO WHERE ID_Registo = @ID_Registo
		END
	IF EXISTS ( SELECT * FROM SAA.FALTA WHERE ID_Registo = @ID_Registo )
		BEGIN 
			SELECT * FROM SAA.FALTA WHERE ID_Registo = @ID_Registo JOIN SAA.TipoFalta ON SAA.FALTA.ID_FALTA = SAA.TipoFalta.ID_FALTA
		END
GO

--VER NOME DOS CURSOS
CREATE PROCEDURE [SAA].[NOME_CURSOS]
AS
	SELECT DISTINCT Nome_Curso FROM SAA.CURSO
GO

--Procedure para ver total de faltas a uma uc.
CREATE proc [SAA].[faltas_da_uc] (@ID_UC INT )
as
	select saa.uc.ID_UC, count(ID_Falta) as N_Faltas
	from ( saa.registo join saa.uc on saa.registo.id_uc = saa.uc.id_uc ) JOIN SAA.FALTA ON SAA.REGISTO.ID_Registo = SAA.FALTA.ID_Registo
	where saa.uc.id_uc = @ID_UC
	group by saa.uc.ID_UC
GO

--Procedure para ver media de notas a uma uc.
CREATE proc [SAA].[mediaNotas_ucs] ( @ID_UC INT )
AS
	SELECT SAA.REGISTO.NMEC, AVG(Nota) AS Media
	FROM SAA.REGISTO JOIN SAA.NOTA ON SAA.REGISTO.ID_REGISTO = SAA.NOTA.ID_REGISTO
	WHERE SAA.REGISTO.NMEC = @NMEC AND SAA.Registo.ID_UC = @ID_UC
	GROUP BY SAA.REGISTO.NMEC
GO

--Procedure para ver total de faltas justificadas a uma uc.
CREATE proc [SAA].[num_falta_justificadas_uc] (@ID_UC INT)
as
	select SAA.UC.ID_UC, count(tipo_Falta) as num_faltas
	from (( saa.registo join saa.uc on saa.registo.id_uc = saa.uc.id_uc ) JOIN SAA.FALTA ON SAA.REGISTO.ID_Registo = SAA.FALTA.ID_Registo ) JOIN SAA.TipoFalta ON SAA.FALTA.ID_Falta = SAA.TipoFalta.ID_Falta
	where saa.uc.id_uc = @ID_UC AND tipo_Falta = 'Justificada'
	group by SAA.UC.ID_UC
GO

--Procedure para ver total de faltas injustificadas a uma uc.
CREATE proc [SAA].[num_falta_injustificadas_uc] (@ID_UC INT)
as
	select SAA.UC.ID_UC, count(tipo_Falta) as num_faltas
	from (( saa.registo join saa.uc on saa.registo.id_uc = saa.uc.id_uc ) JOIN SAA.FALTA ON SAA.REGISTO.ID_Registo = SAA.FALTA.ID_Registo ) JOIN SAA.TipoFalta ON SAA.FALTA.ID_Falta = SAA.TipoFalta.ID_Falta
	where saa.uc.id_uc = @ID_UC AND tipo_Falta = 'Injustificada'
	group by SAA.UC.ID_UC
GO



--ENTIDADE NOTA-------------------------------------------------------------
--UPDATE NOTA 
CREATE PROC SAA.updateNota ( @ID_Nota INT, @Nota DECIMAL, @ID_Registo INT, @ID_UC INT, @ID_Aval INT)
AS
	UPDATE SAA.Registo
	SET ID_UC = @ID_UC,
		ID_Aval = @ID_Aval
	WHERE ID_Registo = @ID_Registo

	UPDATE SAA.Nota
	SET Nota = @Nota
	WHERE ID_Nota = @ID_Nota
GO  

--ADD NOTA
CREATE PROC SAA.addNOTA	(@NMEC INT, @ID_UC INT, @ID_AVAL INT, @Nota Decimal)
AS
	DECLARE @ID_NotaX INT;
	DECLARE @ID_Registo INT; 
	DECLARE @media_nota DECIMAL(4,2);

	INSERT INTO SAA.REGISTO (NMEC, ID_UC, ID_Aval)
	VALUES (@NMEC, @ID_UC, @ID_Aval)	

	SELECT TOP 1 @ID_Registo=ID_Registo FROM SAA.REGISTO ORDER BY ID_Registo DESC;
	PRINT @ID_Registo 

	INSERT INTO SAA.NOTA
	VALUES (@ID_NotaX, @Nota, @ID_Registo)

    --atualizar saa.avaliacao com a media das notas
	select @media_nota = avg(Nota)
	from saa.registo JOIN SAA.NOTA ON SAA.REGISTO.ID_Registo = SAA.NOTA.ID_Registo
	where id_uc = @ID_UC
	group by ID_UC

	UPDATE SAA.AVALIACAO
	SET notaDecimal = @media_nota
	WHERE ID_AVAL = @ID_AVAL
GO

--ENTIDADE FALTA-------------------------------------------------------------

--ADD FALTA
CREATE PROC SAA.addFalta (@NMEC INT, @ID_UC INT, @ID_AVAL INT, @TipoFalta VARCHAR(50))
AS
	DECLARE @ID_FaltaX INT;
	DECLARE @ID_Registo INT;

	INSERT INTO SAA.REGISTO (NMEC, ID_UC, ID_Aval)
	VALUES (@NMEC, @ID_UC, @ID_Aval)	

	SELECT TOP 1 @ID_Registo=ID_Registo FROM SAA.REGISTO ORDER BY ID_Registo DESC;

	INSERT INTO SAA.FALTA
	VALUES (@ID_Registo, @ID_FaltaX)

	INSERT INTO SAA.TipoFalta
	VALUES (@ID_FALTAX, @TipoFalta)

--UPDATE FALTAS
CREATE PROC SAA.updateFalta ( @ID_FALTA INT, @TipoFalta VARCHAR(50), @ID_Registo INT, @ID_UC INT, @ID_Aval INT)
AS
	UPDATE SAA.Registo
	SET ID_UC = @ID_UC,
		ID_Aval = @ID_Aval
	WHERE ID_Registo = @ID_Registo

	UPDATE SAA.TipoFalta
	SET tipo_Falta = @TipoFalta
	WHERE ID_Falta = @ID_Falta

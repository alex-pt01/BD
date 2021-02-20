--ENTIDADE ALUNO ---------------------------------------------------------------------------------------------------------------------
--Add aluno triggerr
CREATE TRIGGER SAA.addAlunoTrigger ON SAA.ALUNO
INSTEAD OF INSERT
AS
BEGIN
    IF(SELECT count(*) FROM inserted) = 1
    BEGIN
		DECLARE @NMECX INT;

		DECLARE @COUNT INT = 0;
		DECLARE @N_ROWS INT;
        DECLARE @Nome VARCHAR(50);
        DECLARE @Email VARCHAR(50);
        DECLARE @RegimeEstudo VARCHAR(50);
        DECLARE @ID_Horario INT;
        DECLARE @ID_Biblioteca INT;
        DECLARE @NMEC_TUTOR INT;
        DECLARE @Idade INT;
        DECLARE @ID_Curso INT;
        DECLARE @Nome1 VARCHAR(50);
        DECLARE @NMEC1 INT;
        DECLARE @Email1 VARCHAR(50);
        DECLARE @RegimeEstudo1 VARCHAR(50);
        DECLARE @ID_Horario1 INT;
        DECLARE @ID_Biblioteca1 INT;
        DECLARE @NMEC_TUTOR1 INT;
        DECLARE @Idade1 INT;
        DECLARE @ID_Curso1 INT;

		DECLARE @ERRO INT = 0;

        SELECT @Nome = Nome, @Email = Email, @RegimeEstudo = RegimeEstudo, @ID_Horario=ID_Horario, @ID_Biblioteca=ID_Biblioteca, @NMEC_TUTOR=NMEC_TUTOR, @Idade=Idade, @ID_Curso=ID_Curso FROM inserted 
		SELECT @N_ROWS=COUNT(*) FROM SAA.ALUNO;  
		DECLARE cursorX CURSOR
		FOR SELECT * FROM SAA.ALUNO;
        OPEN cursorX;
        FETCH cursorX INTO @Nome1, @NMEC1, @Email1, @RegimeEstudo1, @ID_Horario1, @ID_Biblioteca1, @NMEC_TUTOR1, @Idade1, @ID_Curso1;
		--SET @N_ROWS = @N_ROWS-1

		BEGIN TRAN 
			WHILE @@FETCH_STATUS = 0 AND @COUNT < @N_ROWS	
			BEGIN
				IF(@Email = @Email1)
					BEGIN
						RAISERROR('Email em uso', 16, 1)
						PRINT 'NOT OK'
						SET @ERRO = 1;
					END
				SET @NMECX = @NMEC1 
				FETCH cursorX INTO @Nome1, @NMEC1, @Email1, @RegimeEstudo1, @ID_Horario1, @ID_Biblioteca1, @NMEC_TUTOR1, @Idade1, @ID_Curso1
				SET @COUNT = @COUNT + 1;
				
			END;
			SET @NMECX = @NMECX + 1;
			INSERT INTO SAA.ALUNO
			VALUES ( @Nome, @NMECX, @Email, @RegimeEstudo, @ID_Horario, @ID_Biblioteca, @NMEC_TUTOR, @Idade, @ID_Curso )
			IF (@ERRO = 1)
				BEGIN
					ROLLBACK TRAN
				END
		COMMIT TRAN
        CLOSE cursorX;
        DEALLOCATE cursorX;		
    END
END


--APAGAR ALUNO TRIGGER --
CREATE TRIGGER SAA.delAlunoTrigger ON SAA.ALUNO
INSTEAD OF DELETE
AS
BEGIN
	BEGIN TRAN
		IF(SELECT count(*) FROM deleted) = 1
		BEGIN
			DECLARE @COUNT INT = 0;
			DECLARE @N_ROWS INT;
			DECLARE @NMEC INT;
			DECLARE @ID_FALTA INT;

			--CURSOR
			DECLARE @ID_Registo1 INT;
			DECLARE @NMEC1 INT;
			DECLARE @ID_UC1 INT;
			DECLARE @ID_Aval1 INT;

			SELECT @NMEC=NMEC FROM deleted
			SELECT @N_ROWS=COUNT(*) FROM SAA.REGISTO;  
			DECLARE cursorX CURSOR
			FOR SELECT * FROM SAA.REGISTO;
			OPEN cursorX;
			FETCH cursorX INTO @ID_Registo1, @NMEC1, @ID_UC1, @ID_Aval1;
			SET @N_ROWS = @N_ROWS-1
			WHILE @COUNT <= @N_ROWS
			BEGIN
				IF ( @NMEC = @NMEC1 )
				BEGIN
					IF EXISTS( SELECT * FROM SAA.FALTA WHERE ID_Registo = @ID_Registo1 )
					BEGIN
						SELECT @ID_FALTA=ID_FALTA FROM SAA.FALTA WHERE ID_Registo = @ID_Registo1
						DELETE SAA.TipoFalta WHERE ID_Falta = @ID_FALTA
						DELETE SAA.FALTA WHERE ID_Registo = @ID_Registo1
					END
					IF EXISTS( SELECT * FROM SAA.NOTA WHERE ID_Registo = @ID_Registo1 )
					BEGIN
						DELETE SAA.NOTA WHERE ID_Registo = @ID_Registo1
					END
				END

				FETCH cursorX INTO @ID_Registo1, @NMEC1, @ID_UC1, @ID_Aval1;
				SET @COUNT = @COUNT + 1;
			END;
			CLOSE cursorX;
			DEALLOCATE cursorX;

			DELETE FROM SAA.Registo WHERE NMEC = @NMEC
			DELETE FROM SAA.Relacao_ALUNO_TURMA WHERE NMEC = @NMEC
			DELETE FROM SAA.ALUNO WHERE NMEC = @NMEC
		END
	COMMIT TRAN
END

--ENTIDADE Horario ---------------------------------------------------------------------------------------------------------------------

-TRIGGER PARA ADD HORARIOS AUTOMATICAMENTE
CREATE TRIGGER SAA.addHorarioTrigger ON SAA.HORARIO
INSTEAD OF INSERT
AS
BEGIN
	BEGIN TRAN
		IF(SELECT count(*) FROM inserted) = 1
		BEGIN
			DECLARE @COUNT INT = 0;
			DECLARE @N_ROWS INT;
			DECLARE @ID_Horario INT;
			DECLARE @ID_HORARIOX INT;

			SELECT @N_ROWS=COUNT(*) FROM SAA.HORARIO;  
			DECLARE cursorX CURSOR
			FOR SELECT * FROM SAA.HORARIO;
			OPEN cursorX;
			FETCH cursorX INTO @ID_Horario;
			SET @N_ROWS = @N_ROWS-1
			WHILE @COUNT <= @N_ROWS
			BEGIN
				SET @ID_HorariOX = @ID_Horario

				FETCH cursorX INTO @ID_Horario
				SET @COUNT = @COUNT + 1;
			END;
			SET @ID_Horario = @ID_Horario + 1
			CLOSE cursorX;
			DEALLOCATE cursorX;

			INSERT INTO SAA.HORARIO VALUES (@ID_Horario)
		END
	COMMIT TRAN
END


--TRIGGER PARA APAGAR HORARIOS
CREATE TRIGGER SAA.deleteHorarioTrigger ON SAA.HORARIO
INSTEAD OF delete
AS
	BEGIN
		IF (SELECT count(*) FROM deleted) = 1
		DECLARE @ID_Horario INT;
		BEGIN
			SELECT @ID_Horario=ID_Horario FROM deleted;

			UPDATE SAA.TURMA
			SET ID_Horario = 0
			WHERE ID_Horario = @ID_Horario

			UPDATE SAA.UC
			SET ID_Horario = 0
			WHERE ID_Horario = @ID_Horario

			UPDATE SAA.PROFESSOR
			SET ID_Horario = 0
			WHERE ID_Horario = @ID_Horario

			UPDATE SAA.ALUNO
			SET ID_Horario = 0
			WHERE ID_Horario = @ID_Horario

			DELETE FROM SAA.HORARIO
			WHERE ID_Horario = @ID_Horario
		END
	END


--ENTIDADE REGISTO
--------------------------------------------------------------------------------------------------------------------------------------------
-- add Registo TRIGGER
CREATE TRIGGER SAA.addRegistoTrig ON SAA.REGISTO 
INSTEAD OF INSERT
AS
BEGIN
	BEGIN TRAN
		IF (SELECT count(*) FROM inserted) = 1
		BEGIN
			DECLARE @ID_Registo int;
			DECLARE @NMEC int;
			DECLARE @ID_UC int;
			DECLARE @ID_Aval int;
			SELECT  @ID_Registo = ID_Registo, @NMEC=NMEC, @ID_UC=ID_UC, @ID_Aval=ID_Aval FROM inserted
	
			IF (NOT EXISTS (SELECT NMEC FROM SAA.ALUNO WHERE NMEC=@NMEC))
				BEGIN
					ROLLBACK TRAN;
					RAISERROR('Nao existe esse aluno...', 16, 1);
				END
			IF (NOT EXISTS (SELECT ID_UC FROM SAA.UC WHERE ID_UC=@ID_UC))
				BEGIN
					ROLLBACK TRAN;
					RAISERROR('Nao existe essa uc...', 16, 1);
				END
			IF (NOT EXISTS (SELECT ID_Aval FROM SAA.AVALIACAO WHERE ID_Aval=@ID_Aval))
				BEGIN
					ROLLBACK TRAN;
					RAISERROR('Nao existe essa avaliacao...', 16, 1);
				END
			IF ( EXISTS (SELECT ID_Registo FROM SAA.REGISTO WHERE ID_Registo=@ID_Registo))
				BEGIN
					ROLLBACK TRAN;
					RAISERROR('PK ID_Registo duplicada...', 16, 1);
				END
            --VERIFICAR SE O NMEC EXISTE E SE O CURSO DO ALUNO TEM A UC DO REGISTO
			IF EXISTS ( SELECT ID_UC FROM SAA.X_UC_DO_ALUNO_X(@NMEC, @ID_UC) )
			BEGIN
				INSERT INTO SAA.REGISTO (NMEC, ID_UC, ID_Aval)
				VALUES (@NMEC, @ID_UC, @ID_Aval)
			END
			ELSE
			BEGIN
				RAISERROR('UC NAO PERTENCE AO CURSO DO ALUNO!',16,1)
			END

		END
	COMMIT TRAN
END


--trigger para apagar o registo--
CREATE TRIGGER SAA.deleteRegistoTrigger ON SAA.Registo
INSTEAD OF delete
AS
	BEGIN
		IF (SELECT count(*) FROM deleted) = 1
		DECLARE @ID_Registo INT;
		DECLARE @ID_Falta INT;

		BEGIN
			SELECT @ID_Registo=ID_Registo FROM deleted;

			IF EXISTS ( SELECT * FROM SAA.FALTA WHERE ID_Registo = @ID_Registo)
			BEGIN
				SELECT @ID_Falta = ID_Falta FROM SAA.FALTA WHERE ID_Registo = @ID_Registo
				DELETE SAA.TipoFalta WHERE ID_Falta = @ID_Falta
				DELETE SAA.FALTA WHERE ID_Registo = @ID_Registo
				--DELETE SAA.REGISTO WHERE ID_Registo = @ID_Registo
			END
			IF EXISTS ( SELECT * FROM SAA.Nota WHERE ID_Registo = @ID_Registo)
			BEGIN
				DELETE SAA.NOTA WHERE ID_Registo = @ID_Registo
				--DELETE SAA.REGISTO WHERE ID_Registo = @ID_Registo
			END

			DELETE SAA.REGISTO WHERE ID_Registo = @ID_Registo
		END
	END


--ENTIDADE NOTA-------------------------------------------------------------

--TRIGGER PARA ADD NOTA
CREATE TRIGGER SAA.addNotaTrigger ON SAA.Nota
INSTEAD OF INSERT
AS
BEGIN
    IF(SELECT count(*) FROM inserted) = 1
    BEGIN
		DECLARE @NMECX INT;

		DECLARE @COUNT INT = 0;
		DECLARE @N_ROWS INT;
       
		DECLARE @ID_NotaX INT = 0;
		DECLARE @Nota Decimal;
		DECLARE @ID_Registo INT;
		DECLARE @ID_NotaX1 INT;
		DECLARE @Nota1 Decimal;
		DECLARE @ID_Registo1 INT;

		DECLARE @ERRO INT = 0;

        SELECT @Nota = Nota, @ID_Registo = ID_Registo FROM inserted 
		SELECT @N_ROWS=COUNT(*) FROM SAA.Nota;  
		DECLARE cursorX CURSOR
		FOR SELECT * FROM SAA.Nota;
        OPEN cursorX;
        FETCH cursorX INTO @ID_NotaX1, @Nota1, @ID_Registo1 ;
		--SET @N_ROWS = @N_ROWS-1

		BEGIN TRAN 
			WHILE @@FETCH_STATUS = 0 AND @COUNT < @N_ROWS
			BEGIN
				IF(@ID_Registo = @ID_Registo1)
					BEGIN
						RAISERROR('Registo em uso', 16, 1)
						SET @ERRO = 1;
					END
				SET @ID_NotaX = @ID_NotaX1
				FETCH cursorX INTO @ID_NotaX1, @Nota1, @ID_Registo1
				SET @COUNT = @COUNT + 1;
				
			END;
			SET @ID_NotaX = @ID_NotaX + 1;
			INSERT INTO SAA.NOTA
			VALUES (@ID_NotaX, @Nota, @ID_Registo)
			
			IF (@ERRO = 1)
				BEGIN
					ROLLBACK TRAN
					Delete SAA.REGISTO WHERE ID_Registo = @ID_Registo
				END
		COMMIT TRAN
        CLOSE cursorX;
        DEALLOCATE cursorX;		
    END
END


--ENTIDADE FALTA -------------------------------------------------------------
--add tipo falta trigger
CREATE TRIGGER SAA.addTipoFaltaTrigger ON SAA.TipoFalta
INSTEAD OF INSERT
AS
BEGIN
	DECLARE @ID_FaltaX INT;
	DECLARE @TipoFalta VARCHAR(50);


    IF(SELECT count(*) FROM inserted) = 1
    BEGIN
		SELECT TOP 1 @ID_FaltaX=ID_Falta FROM SAA.FALTA ORDER BY ID_Falta DESC;
		SELECT @TipoFalta = tipo_Falta from inserted
	
		INSERT INTO SAA.TipoFalta
		VALUES (@ID_FALTAX, @TipoFalta)
    END
END
GO

--add falta trigger
CREATE TRIGGER SAA.addFaltaTrigger ON SAA.Falta
INSTEAD OF INSERT
AS
BEGIN
    IF(SELECT count(*) FROM inserted) = 1
    BEGIN
		DECLARE @NMECX INT;

		DECLARE @COUNT INT = 0;
		DECLARE @N_ROWS INT;
       
		DECLARE @ID_FaltaX INT = 0;
		DECLARE @TipoFalta VARCHAR(50);
		DECLARE @ID_Registo INT;
		DECLARE @ID_FaltaX1 INT;
		DECLARE @ID_Registo1 INT;

		DECLARE @ERRO INT = 0;

        SELECT @ID_Registo = ID_Registo FROM inserted 
		SELECT @N_ROWS=COUNT(*) FROM SAA.Falta;  
		DECLARE cursorX CURSOR
		FOR SELECT * FROM SAA.Falta;
        OPEN cursorX;
        FETCH cursorX INTO @ID_Registo1, @ID_FaltaX1 ;

		BEGIN TRAN 
			WHILE @@FETCH_STATUS = 0 AND @COUNT < @N_ROWS
			BEGIN
				IF(@ID_Registo = @ID_Registo1)
					BEGIN
						RAISERROR('Registo em uso', 16, 1)
						SET @ERRO = 1;
					END
				SET @ID_FaltaX = @ID_FaltaX1
				FETCH cursorX INTO @ID_Registo1, @ID_FaltaX1
				SET @COUNT = @COUNT + 1;
				
			END;
			SET @ID_FaltaX = @ID_FaltaX + 1;

			PRINT @ID_Registo

			INSERT INTO SAA.Falta
			VALUES (@ID_Registo, @ID_FaltaX)
			
			IF (@ERRO = 1)
				BEGIN
					ROLLBACK TRAN
					Delete SAA.REGISTO WHERE ID_Registo = @ID_Registo
				END
		COMMIT TRAN
        CLOSE cursorX;
        DEALLOCATE cursorX;		
    END
END
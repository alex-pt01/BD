USE SAA
go

--ENTIDADE PROFESSOR ---------------------------------------------------------------------------------------------------------------------
--updateProfessor
CREATE PROC SAA.update_Prof (@Nome_Prof varchar(30), @Num_Gabinete int, @Email varchar(40), @TMEC int, @ID_DEP int, @ID_Horario int)
AS 
BEGIN
	BEGIN TRAN 
		IF(NOT EXISTS(select * from SAA.DEPARTAMENTO WHERE ID_Dep=@ID_DEP))
		BEGIN
			ROLLBACK TRAN;
			RAISERROR('Departamento nao existe!',16,1);
		END
		IF(NOT EXISTS(select * from SAA.HORARIO WHERE ID_Horario=@ID_Horario))
		BEGIN
			ROLLBACK TRAN;
			RAISERROR('Departamento nao existe!',16,1);
		END
		UPDATE SAA.PROFESSOR
		SET Nome_Prof=@Nome_Prof, Num_Gabinete=@Num_Gabinete, Email=@Email, TMEC=@TMEC, ID_DEP=@ID_DEP, ID_Horario=@ID_Horario
		WHERE TMEC=@TMEC 
	COMMIT TRAN
END
go

--total prof por turmas
create proc SAA.totalTurmasProf @idstor int
AS
	SELECT COUNT(P.TMEC) as total_prof_turma
		FROM SAA.PROFESSOR AS P JOIN SAA.TURMA AS T ON P.TMEC=T.TNEMC
		WHERE T.TNEMC=@idstor

--UDF total de professores do departamento X
CREATE FUNCTION SAA.TOTAL_PROFESSORES_DEP_X (@Dep INT) RETURNS TABLE
AS
	RETURN (
	    SELECT COUNT(D.ID_Dep) AS TOTAL_PROF_DEP
		FROM SAA.PROFESSOR AS P JOIN SAA.DEPARTAMENTO AS D ON P.ID_DEP=D.ID_Dep
		WHERE D.ID_Dep=@Dep
	)
go
select * from SAA.TOTAL_PROFESSORES_DEP_X(2)
go

--select horarios 
create proc SAA.showHorario
AS
	select distinct ID_Horario from SAA.PROFESSOR order by ID_Horario ASC


--update PROF  PODE SAIR
CREATE PROCEDURE SAA.insertProf (@Nome_Prof VARCHAR(100), @TMEC int, @Email VARCHAR(100), @Num_Gabinete int, @ID_DEP int, @ID_Horario int)  
AS 
BEGIN
	BEGIN TRAN
	 UPDATE SAA.PROFESSOR
	 SET Nome_Prof = @Nome_Prof, Num_Gabinete = @Num_Gabinete, Email = @Email, TMEC = @TMEC,ID_DEP=@ID_DEP,ID_Horario=@ID_Horario
	 WHERE TMEC = @TMEC
	 COMMIT TRAN
END
GO

EXEC SAA.insertProf 'Alex',123,'112@as',1,2,3

--add proff trigger VERR
CREATE TRIGGER SAA.addProfTrigger ON SAA.PROFESSOR
INSTEAD OF INSERT
AS
BEGIN
	BEGIN TRAN
	IF(SELECT count(*) FROM inserted) = 1
	BEGIN
		DECLARE @nomeProf varchar(50);
		DECLARE @num_gab int;
		DECLARE @Email varchar(50);
		DECLARE @tnmec int;
		DECLARE @id_dep int;
		DECLARE @id_Hor int;
		DECLARE @nomeProf1 varchar(50);
		DECLARE @num_gab1 int;
		DECLARE @Email1 varchar(50);
		DECLARE @tnmec1 int;
		DECLARE @id_dep1 int;
		DECLARE @id_Hor1 int;
		DECLARE @TNMECX INT;
		SELECT  @nomeProf = Nome_Prof, @num_gab=Num_Gabinete, @Email=Email,@tnmec=TMEC,@id_dep=ID_DEP,@id_Hor=ID_Horario FROM inserted
		DECLARE cursorX CURSOR FOR SELECT * FROM SAA.PROFESSOR
		OPEN cursorX
		FETCH NEXT FROM cursorX INTO @nomeProf1,@num_gab1,@Email1,@tnmec1,@id_dep1,@id_Hor1
		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF(@Email1=@Email AND @num_gab1=@num_gab AND @tnmec1=@tnmec)
			BEGIN 
				RAISERROR('Professor já existe!',16,1)
				PRINT 'NOT OK'
			END
			SET @TNMECX = @TNMEC1
			FETCH NEXT FROM cursorX INTO @nomeProf1, @num_gab1, @Email1,@tnmec1,@id_dep1,@id_Hor1
		END
		SET @TNMECX = @TNMECX + 1
		CLOSE cursorX
		DEALLOCATE cursorX
		BEGIN
			INSERT INTO SAA.PROFESSOR VALUES (@nomeProf,@num_gab,@Email,@TNMECX,@id_dep,@id_Hor )
			PRINT 'Ok'
		END
	END
	COMMIT TRAN
END



--Apagar professor
CREATE PROCEDURE SAA.del_Professor (@ID int) 
AS
BEGIN
	BEGIN TRAN
		DELETE FROM SAA.PROFESSOR WHERE TMEC = @ID
		DELETE FROM SAA.Relacao_UC_PROFESSOR WHERE TMEC = @ID
		DELETE FROM SAA.TURMA WHERE TNEMC = @ID
	COMMIT TRAN
END
GO

--trigger caso se apague o professor
CREATE TRIGGER SAA.if_DeleteProfessor ON SAA.PROFESSOR
INSTEAD OF DELETE 
AS
	BEGIN
		BEGIN TRAN
			IF (SELECT count(*) FROM deleted) = 1
			BEGIN
				DECLARE @ID_Prof int
				SELECT @ID_Prof = TMEC FROM deleted
		
				DECLARE @ID_Turma INT
				DECLARE @TNEMC INT      -- relacina-se com o prof
				DECLARE @ID_Horario INT
				DECLARE @AnoLetivo INT
				
				-- para a turma   1:N -> problemas ...
				DECLARE @TableAUX_Turma TABLE (ID_Turma INT, TNEMC INT, ID_Horario INT,AnoLectivo INT );
				INSERT INTO @TableAUX_Turma SELECT ID_Turma, TNEMC, ID_Horario ,AnoLectivo  FROM SAA.TURMA
				
				
				WHILE (SELECT COUNT (*) FROM @TableAUX_Turma) > 0
				BEGIN
					
					SELECT TOP 1  @ID_Turma = ID_Turma, @TNEMC = TNEMC, @ID_Horario = ID_Horario, @AnoLetivo=AnoLectivo  FROM @TableAUX_Turma

					IF (SELECT COUNT(*) FROM SAA.TURMA WHERE @ID_Turma = ID_Turma AND @TNEMC = TNEMC AND @ID_Horario = ID_Horario AND @AnoLetivo=AnoLectivo ) > 0
					BEGIN
						UPDATE TURMA
						SET TNEMC = 0
						WHERE TNEMC = @TNEMC;
						
					END

					DELETE @TableAUX_Turma WHERE @ID_Turma = ID_Turma AND @TNEMC = TNEMC AND @ID_Horario = ID_Horario AND @AnoLetivo=AnoLectivo
				END
				------------------------------------

				DELETE FROM SAA.Relacao_UC_PROFESSOR WHERE TMEC = @ID_Prof
				DELETE FROM SAA.PROFESSOR WHERE TMEC = @ID_Prof
				

			END 
		COMMIT TRAN
	END
GO 

EXEC SAA.del_Professor 1

-- VER ISTO:
CREATE PROCEDURE SAA.addProf (@Nome_Prof VARCHAR(100), @TMEC int, @Email VARCHAR(100), @Num_Gabinete int, @ID_DEP int, @ID_Horario int)  	
AS
	 INSERT INTO SAA.PROFESSOR (Nome_Prof,Num_Gabinete,Email, TMEC,ID_DEP,ID_Horario)
	 VALUES (@Nome_Prof, @Num_Gabinete, @Email , @TMEC, @ID_DEP , @ID_Horario) 
GO

--turmas e horario cada professor
create function SAA.TurmasCadaStor(@id_stor int) RETURNS TABLE
AS
	RETURN(
		select ID_Turma, AnoLectivo from SAA.PROFESSOR AS P
		JOIN SAA.TURMA AS T ON P.TMEC=T.TNEMC
		WHERE T.TNEMC=@id_stor
	)



--UDF turmas por professor X
CREATE FUNCTION SAA.TURMAS_POR_PROFESSOR (@ProfName varchar(30)) RETURNS TABLE
AS
	RETURN (
		SELECT T.ID_Turma,P.TMEC,  P.Nome_Prof, P.Email
		FROM SAA.PROFESSOR AS P JOIN SAA.TURMA AS T ON P.TMEC=T.TNEMC
		WHERE P.Nome_Prof=@ProfName
	)
go
select * from SAA.TURMAS_POR_PROFESSOR('Carlos')
go 

--show Professores
create proc SAA.NomeProf
AS
	select Nome_Prof from SAA.PROFESSOR
										   




--ENTIDADE TURMA
--------------------------------------------------------------------------------------------------------------------------------------------
--ids horarios
create proc SAA.IDsHoraios
AS
	select ID_Horario from SAA.HORARIO

--ids tnmecs
create proc SAA.Tnmecs
AS
	select distinct TMEC from SAA.PROFESSOR order by TMEC ASC

-- turmas
CREATE PROC SAA.IDsTurmas
AS
	SELECT DISTINCT ID_Turma
	FROM SAA.Relacao_ALUNO_TURMA AS RAT JOIN SAA.ALUNO AS A ON RAT.NMEC = A.NMEC
	UNION
	SELECT DISTINCT ID_Turma
	FROM SAA.TURMA AS T JOIN SAA.PROFESSOR AS P ON T.TNEMC = P.TMEC


--if Delete Turma
CREATE TRIGGER ifDeleteTurma ON SAA.TURMA
INSTEAD OF DELETE
AS
BEGIN
	IF (SELECT count(*) FROM deleted) = 1
		BEGIN 
			PRINT 'Ok1'
			DECLARE @idTurma AS int;
			SELECT @idTurma = ID_Turma FROM deleted;

			IF (@idTurma) is null
				RAISERROR('turma inexistente.', 16, 1);
			ELSE
				BEGIN
					PRINT 'Ok2'
					DELETE FROM SAA.Relacao_Turma_Sala WHERE ID_Turma = @idTurma
					DELETE FROM SAA.Relacao_ALUNO_TURMA WHERE ID_Turma = @idTurma
					DELETE FROM SAA.TURMA WHERE ID_Turma = @idTurma
					PRINT 'Ok'
				END
		  END
	  ELSE
		PRINT 'NOPE'
END

-- addTurmaTrigger

CREATE TRIGGER SAA.addTurmaTrigger ON SAA.TURMA
INSTEAD OF INSERT
AS
BEGIN	
	IF(SELECT count(*) FROM inserted) = 1
	BEGIN
		DECLARE @id_turma int;
		DECLARE @Tnmec int;
		DECLARE @id_Horario int;
		DECLARE @AnoLectivo int;
		DECLARE @id_turma1 int;
		DECLARE @Tnmec1 int;
		DECLARE @id_Horario1 int;
		DECLARE @AnoLectivo1 int;
		SELECT  @id_turma = ID_TURMA, @Tnmec=TNEMC, @id_Horario=ID_Horario,@AnoLectivo=AnoLectivo FROM inserted
		DECLARE cursorX CURSOR FOR SELECT * FROM SAA.TURMA
		OPEN cursorX
		FETCH NEXT FROM cursorX INTO @id_turma1,@Tnmec1,@id_Horario1,@AnoLectivo1
		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF(@id_turma1=@id_turma)
			BEGIN 
				RAISERROR('Essa turma j� existe!',16,1)
			END

            Set @id_turmaX = @idturma1

			FETCH NEXT FROM cursorX INTO @id_turma1, @Tnmec1, @id_Horario1,@AnoLectivo1
		END
		CLOSE cursorX
		DEALLOCATE cursorX

        set @id_turmax = @id_turmaX + 1
		BEGIN
			INSERT INTO SAA.TURMA VALUES (@id_turma,@Tnmec,@id_Horario,@AnoLectivo)
			PRINT 'Ok'
		END
	END
END



-- add Turma
CREATE PROCEDURE SAA.addTurma (@ID int, @TNMEC int,  @ID_Horario int, @AnoLetivo int)  
AS
	 INSERT INTO SAA.TURMA (ID_Turma,TNEMC,ID_Horario,AnoLectivo)
	 VALUES (@ID, @TNMEC, @ID_Horario , @AnoLetivo ) 
GO

--  Alunos da turma Y

CREATE FUNCTION SAA.ALUNOS_TURMA_Y (@Turma INT) RETURNS TABLE
AS
	RETURN(
		SELECT ID_Turma, A.NMEC, Nome,Email, RegimeEstudo, Idade
		FROM SAA.Relacao_ALUNO_TURMA AS RAT JOIN SAA.ALUNO AS A ON RAT.NMEC = A.NMEC
		WHERE ID_Turma = @Turma
	)
go
SELECT * FROM SAA.ALUNOS_TURMA_Y(3)

--procedure show turmas
create proc SAA.loadTurmas
AS
	select DISTINCT ID_Turma from SAA.TURMA ORDER BY ID_Turma DESC

--  Professores da turma Y

CREATE FUNCTION SAA.PROFESSORES_TURMA_Y (@id_turma varchar(50)) RETURNS TABLE
AS
	RETURN(
		SELECT ID_Turma, T.TNEMC, Nome_Prof,Num_Gabinete, Email
		FROM SAA.TURMA AS T JOIN SAA.PROFESSOR AS P ON T.TNEMC = P.TMEC
		WHERE ID_Turma = @id_turma
	)



-- Turmas e alunos de h� x anos atr�s

CREATE FUNCTION SAA.ALUNOS_TURMA_DE_HA_X_ANOS (@anosAtras INT) RETURNS TABLE
AS
	RETURN(
	SELECT T.ID_Turma, A.NMEC, Nome,Email, RegimeEstudo, Idade,AnoLectivo
	FROM SAA.Relacao_ALUNO_TURMA AS RAT JOIN SAA.ALUNO AS A ON RAT.NMEC = A.NMEC
	JOIN SAA.TURMA AS T ON RAT.ID_Turma = T.ID_Turma 
WHERE YEAR(getdate())-AnoLectivo=@anosAtras )


--tipo Sala
CREATE PROC SAA.tipoSala1
AS
	select DISTINCT tipoSala from SAA.TipoSala 


-- Alunos_Turmas_Do_TipoSala X
CREATE FUNCTION SAA.Alunos_Turmas_Do_TipoSala (@tipoSala varchar(50)) RETURNS TABLE
AS
	RETURN(
	SELECT S.ID_Sala,AnoLectivo, T.ID_Turma, tipoSala,S.Limite_Alunos,DT.ID_Dep
	FROM SAA.TURMA AS T 
	JOIN SAA.Relacao_Turma_Sala AS RTS ON RTS.ID_Turma = T.ID_Turma
	JOIN SAA.SALA AS S ON RTS.ID_Sala = S.ID_Sala
	JOIN SAA.TipoSala AS TS ON TS.ID_Sala = S.ID_Sala
	JOIN SAA.DEPARTAMENTO AS DT ON S.ID_Dep=DT.ID_Dep
	WHERE tipoSala=@tipoSala
)


--update Turma
CREATE PROCEDURE SAA.updateTurma(@idTurma int,  @tnmec int, @id_Horario int, @anoLectivo int) 
AS
	IF (SELECT COUNT(*) FROM SAA.TURMA WHERE ID_Turma = @idTurma ) >0
		BEGIN
			 UPDATE SAA.TURMA
			 SET ID_Turma = @idTurma, TNEMC = @tnmec, ID_Horario =  @id_Horario, AnoLectivo =@anoLectivo
			 WHERE ID_Turma = @idTurma
		END
	ELSE
		BEGIN
			Print 'Nao existe nenhuma turma com esse ID';
		END


--varios joins VER
SELECT S.ID_Sala,AnoLectivo, T.ID_Turma, tipoSala,S.Limite_Alunos,DT.ID_Dep
FROM SAA.TURMA AS T 
JOIN SAA.Relacao_Turma_Sala AS RTS ON RTS.ID_Turma = T.ID_Turma
JOIN SAA.SALA AS S ON RTS.ID_Sala = S.ID_Sala
JOIN SAA.TipoSala AS TS ON TS.ID_Sala = S.ID_Sala
JOIN SAA.DEPARTAMENTO AS DT ON S.ID_Dep=DT.ID_Dep









--ENTIDADE CURSO
--------------------------------------------------------------------------------------------------------------------------------------------
-- Tri add curso

--add proff trigger VERR
CREATE TRIGGER SAA.addCursoTrig ON SAA.CURSO
INSTEAD OF INSERT
AS
BEGIN	--verifica se o curso j� existe
	IF(SELECT count(*) FROM inserted) = 1
	BEGIN 
		DECLARE @nomeCurso varchar(50);
		DECLARE @id_curso int;
		DECLARE @id_dep int;
		
		DECLARE @nomeCurso1 varchar(50);
		DECLARE @id_curso1 int;
		DECLARE @id_dep1 int;
		
		SELECT  @nomeCurso = Nome_Curso, @id_curso=ID_Curso, @id_dep=ID_Dep FROM inserted
		IF(@nomeCurso IS NULL OR  @id_curso IS NULL OR @id_dep IS NULL)
			RAISERROR('Curso j� existe!',16,1)
		
		DECLARE cursorX CURSOR FOR SELECT * FROM SAA.CURSO
		OPEN cursorX
		FETCH NEXT FROM cursorX INTO @nomeCurso1,@id_curso1,@id_dep1
		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF(@id_curso1=@id_curso)
			BEGIN 
				RAISERROR('Curso j� existe!',16,1)
				PRINT 'NOT OK'
			END
			FETCH NEXT FROM cursorX INTO @nomeCurso1, @id_curso1, @id_dep1
		END
		CLOSE cursorX
		DEALLOCATE cursorX
		BEGIN
			insert into SAA.CURSO values ( @nomeCurso,@id_curso,@id_dep)
	   END
	END
END

-- adicionar Curso
CREATE PROCEDURE SAA.addCurso(@nomeCurso varchar(50),  @id_curso int, @id_dep int)  
AS
	insert into SAA.CURSO values ( @nomeCurso,@id_curso,@id_dep)
GO


--update Curso
CREATE PROCEDURE SAA.updateCurso(@nomeCurso varchar(50),  @id_curso int, @id_dep int) 
AS
	IF (SELECT COUNT(*) FROM SAA.CURSO WHERE ID_Curso = @id_curso ) >0
		BEGIN
			 UPDATE SAA.CURSO
			 SET Nome_Curso = @nomeCurso, ID_Curso = @id_curso, ID_Dep = @id_dep
			 WHERE  ID_Curso=@id_curso
		END
	ELSE
		BEGIN
			Print 'Nao existe nenhum curso com esse ID';
		END



--eliminar curso
CREATE TRIGGER SAA.if_DeleteCursoTrig ON SAA.CURSO
INSTEAD OF DELETE 
AS
	BEGIN
		BEGIN TRAN
			IF (SELECT count(*) FROM deleted) = 1
			BEGIN
				DECLARE @ID_Curso int
				SELECT @ID_Curso = ID_Curso FROM deleted
				
				DECLARE @Nome varchar(50) -- relacina-se com o aluno
				DECLARE @NMEC INT
				DECLARE @Email varchar(50)      
				DECLARE @RegimeEstudo varchar(50)
				DECLARE @ID_C INT
				
				
				
				-- para a turma   1:N -> problemas ...
				DECLARE @TableAUX_Aluno TABLE (Nome varchar(50), NMEC INT, Email varchar(50),RegimeEstudo varchar(50), ID_Curso INT );
				INSERT INTO @TableAUX_Aluno SELECT Nome, NMEC, Email ,RegimeEstudo, ID_Curso FROM SAA.ALUNO
				
				PRINT 'X'
				WHILE (SELECT COUNT (*) FROM @TableAUX_Aluno) > 0
				BEGIN
					
					SELECT TOP 1  @Nome = Nome, @NMEC = NMEC, @Email = Email, @RegimeEstudo=RegimeEstudo, @ID_C=ID_Curso  FROM @TableAUX_Aluno

					IF (SELECT COUNT(*) FROM SAA.ALUNO WHERE @Nome = Nome AND @NMEC = NMEC AND  @Email = Email AND @RegimeEstudo=RegimeEstudo AND  @ID_C =ID_Curso  ) > 0
					BEGIN
						
						PRINT 'Y'
						UPDATE SAA.ALUNO
						SET ID_Curso = 0
						WHERE ID_Curso =@ID_Curso;
						print 'ok'
					END

					DELETE @TableAUX_Aluno WHERE @Nome = Nome AND @NMEC = NMEC AND  @Email = Email AND @RegimeEstudo=RegimeEstudo  AND  @ID_C =ID_Curso 
				END
				------------------------------------
				PRINT 'k'
				
				
				
				PRINT 'C'
				
				DELETE FROM SAA.Relacao_UC_Curso WHERE ID_Curso = @ID_Curso
				DELETE FROM SAA.CURSO WHERE  ID_Curso = @ID_Curso
			END 
		COMMIT TRAN
		
	END
GO 


--ESTE D� -> O DE CIMA J� DA!!!!
CREATE TRIGGER SAA.if_DeleteCursoTrig ON SAA.CURSO
INSTEAD OF DELETE
AS
	BEGIN
			
			IF (SELECT count(*) FROM deleted) = 1
			BEGIN
				DECLARE @ID_Curso int
				SELECT @ID_Curso = ID_Curso FROM deleted
					
				IF (EXISTS (SELECT * FROM SAA.ALUNO WHERE ID_Curso=@ID_Curso))
				BEGIN
						PRINT '--------------------------ok'
						UPDATE SAA.ALUNO
						SET ID_Curso = 0
						WHERE ID_Curso = @ID_Curso ;
						print 'ok'
				END
				PRINT 'k'
			
				
				PRINT 'C'
			END 
			DELETE FROM SAA.Relacao_UC_Curso WHERE ID_Curso = @ID_Curso
			DELETE FROM SAA.CURSO WHERE  ID_Curso = @ID_Curso
	
	END
GO 

--del curso
CREATE PROCEDURE SAA.delCurso (@ID_Curso int) 
AS
	DELETE FROM SAA.CURSO WHERE ID_Curso = @ID_Curso
GO

--load curso
create proc SAA.loadCurso 
AS
	select * from SAA.CURSO

--load IDs Dep
create proc SAA.loadDepID
AS
	select ID_Dep from SAA.DEPARTAMENTO

-- load ID UC
CREATE PROC SAA.loadUcs
AS
    select DISTINCT ID_UC from SAA.UC


--UC do curso X
CREATE FUNCTION SAA.UC_DO_CURSO_X (@id_uc int) RETURNS TABLE
AS
	RETURN(
		SELECT DISTINCT RUC.ID_UC,AnoFormacao, Nome_Curso
		FROM SAA.UC AS U 
		JOIN SAA.Relacao_UC_CURSO AS RUC ON U.ID_UC=RUC.ID_UC
		JOIN SAA.CURSO AS C ON C.ID_Curso = RUC.ID_UC
		WHERE C.ID_Curso=@id_uc
	)




-- os anos que cada UC tem em cada curso
CREATE PROC oldest_UC 
AS
BEGIN
	SELECT distinct DATEDIFF(year, AnoFormacao, CONVERT (date, SYSDATETIME())) AS Duracao_UC, RUC.ID_UC, Nome_Curso
	FROM SAA.UC AS U 
	JOIN SAA.Relacao_UC_CURSO AS RUC ON U.ID_UC=RUC.ID_UC
	JOIN SAA.CURSO AS C ON C.ID_Curso = RUC.ID_UC
	
END
go

--ENTIDADE UC
--------------------------------------------------------------------------------------------------------------------------------------------
--delete UC
CREATE PROCEDURE SAA.delUC (@ID_UC int) 
AS
	DELETE FROM SAA.UC WHERE ID_UC = @ID_UC
GO

--delete uc
CREATE TRIGGER SAA.if_DeleteUCTrig ON SAA.UC
INSTEAD OF DELETE 
AS
BEGIN
	
IF (SELECT count(*) FROM deleted) = 1
BEGIN
	DECLARE @ID_UC int
	SELECT @ID_UC = ID_UC FROM deleted
			
	DELETE FROM SAA.AVALIACAO  WHERE ID_UC = @ID_UC
			
	DELETE FROM SAA.REGISTO  WHERE ID_UC = @ID_UC
	DELETE FROM SAA.Relacao_UC_CURSO WHERE ID_UC = @ID_UC
	DELETE FROM SAA.Relacao_UC_PROFESSOR WHERE ID_UC = @ID_UC
	DELETE FROM SAA.UC WHERE ID_UC = @ID_UC
	END 
	
END

GO

--loas ID_Aval
CREATE PROC SAA.loadIDAval
AS
	select DISTINCT ID_Aval from SAA.AVALIACAO
go

--load ID_Horario
CREATE PROC SAA.loadIDHorario
AS
	select DISTINCT ID_Horario from SAA.HORARIO

--load UC
CREATE PROC SAA.loadUC
AS
	select * from SAA.UC

--ADD uc
CREATE TRIGGER SAA.addUCTrig ON SAA.UC
INSTEAD OF INSERT
AS
BEGIN	--verifica se o curso já existe
	IF(SELECT count(*) FROM inserted) = 1
	BEGIN 
		DECLARE @ID_UC INT;
		DECLARE @AnoFormacao date;
		DECLARE @id_horario int;
		DECLARE @id_aval int;
		
		DECLARE @ID_UC1 varchar(50);
		DECLARE @AnoFormacao1 date;
		DECLARE @id_horario1 int;
		DECLARE @id_aval1 int;
		
		DECLARE @ID_UCX INT;
		
		SELECT  @ID_UC = ID_UC, @AnoFormacao=AnoFormacao, @id_horario=ID_Horario,@id_aval=ID_Aval  FROM inserted
		IF(@ID_UC IS NULL OR  @AnoFormacao IS NULL OR @id_horario IS NULL OR @id_aval IS NULL)
			RAISERROR('Valores nao podem ser null!',16,1)
		
		DECLARE cursorX CURSOR FOR SELECT * FROM SAA.UC
		OPEN cursorX
		FETCH NEXT FROM cursorX INTO @ID_UC1,@AnoFormacao1,@id_horario1,@id_aval1
		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF(@ID_UC1=@ID_UC)
			BEGIN 
				RAISERROR('UC já existe!',16,1)
				PRINT 'NOT OK'
			END

			SET @ID_UCX = @ID_UC1

			FETCH NEXT FROM cursorX INTO @ID_UC1, @AnoFormacao1, @id_horario1,@id_aval1
		END
		CLOSE cursorX
		DEALLOCATE cursorX

		SET @ID_UCX = @ID_UCX + 1
		BEGIN
			insert into SAA.UC values ( @ID_UCX,@AnoFormacao,@id_horario,@id_aval )
	   END
	END
END


--add UC
CREATE PROCEDURE SAA.addUC(@ID_UC int,  @anoForm date, @id_horario int, @id_aval int)  
AS
	insert into SAA.UC values ( @ID_UC,@anoForm,@id_horario,@id_aval)
GO

--UPDATE UC
CREATE PROCEDURE SAA.updateUC(  @ID_UC int, @anoForm date, @id_hor int, @id_aval int) 
AS
	IF (SELECT COUNT(*) FROM SAA.UC WHERE ID_UC = @ID_UC ) >0
		BEGIN
			 UPDATE SAA.UC
			 SET ID_UC = @ID_UC, AnoFormacao = @anoForm, ID_Horario = @id_hor, ID_Aval=@id_aval
			 WHERE  ID_UC=@ID_UC
		END
	ELSE
		BEGIN
			Print 'Nao existe nenhuma uc com esse ID';
		END

--## TALVEZ NAO
--total de Cursos da UC X
CREATE FUNCTION SAA.CURSOS_DA_UC_X (@id_uc int) RETURNS TABLE
AS
	RETURN(
		SELECT U.ID_UC,AnoFormacao, Nome_Curso,C.ID_Curso
		FROM SAA.UC AS U
		JOIN SAA.Relacao_UC_CURSO AS RUC ON RUC.ID_UC= U.ID_UC
		JOIN SAA.CURSO AS C ON RUC.ID_UC=@id_uc
		)

-- total de registos da UC X
CREATE PROCEDURE SAA.TotalRegistos_UC (@id_uc int)  
AS
	select count(U.ID_UC)AS RegistosTotais FROM 
	SAA.REGISTO AS R JOIN SAA.UC AS U
	ON R.ID_UC=U.ID_UC
	WHERE R.ID_UC =@id_uc
GO

EXEC SAA.TotalRegistos_UC 4




--Funcao que da intervalo entre anos
CREATE FUNCTION intervalo_Anos (@start_year INT,@end_year INT)
RETURNS TABLE
AS
RETURN(
    SELECT  ID_UC FROM SAA.UC
    WHERE YEAR(AnoFormacao) BETWEEN YEAR(@start_year) AND YEAR(@end_year)
	)


CREATE FUNCTION SAA.REGISTOS_ALUNOS_UC_Y_BETWEENYEARS (@id_uc int,@star_year int, @end_year int) RETURNS TABLE
AS
	RETURN(
		select A.NMEC, U.ID_UC,ID_Curso,ID_Registo, Email, RegimeEstudo,Nome
		FROM
		intervalo_Anos (@star_year,@end_year) AS U JOIN SAA.REGISTO AS R ON U.ID_UC=R.ID_Registo
		JOIN SAA.ALUNO AS A ON A.NMEC=R.NMEC
		WHERE U.ID_UC = @id_uc
		
	)

CREATE FUNCTION SAA.AVALIACOES_UC_X (@id_uc int) RETURNS TABLE
AS
	RETURN(
		select UC.ID_UC,notaDecimal,AL.NMEC, AL.Nome, AL.Email, AL.RegimeEstudo from SAA.UC AS UC
		JOIN SAA.AVALIACAO AS A ON UC.ID_UC=A.ID_UC
		JOIN SAA.REGISTO AS R
		ON A.ID_UC=R.ID_UC
		JOIN SAA.ALUNO AS AL ON AL.NMEC =R.NMEC
		WHERE A.ID_UC=@id_uc
	)

--Tipo de faltas dos alunos
CREATE PROC SAA.tipo_faltas_alunos_cada_uc
AS
	SELECT ID_UC,ALUNO.NMEC,ALUNO.Email, Nome, Tipo_Falta
	FROM (SAA.TipoFalta AS TF JOIN SAA.FALTA AS F ON TF.ID_Falta= F.ID_Falta 
	JOIN SAA.REGISTO  ON SAA.REGISTO.ID_Registo = F.ID_Registo) JOIN SAA.ALUNO ON SAA.ALUNO.NMEC = SAA.REGISTO.NMEC
	











--ENTIDADE REGISTO
--------------------------------------------------------------------------------------------------------------------------------------------


-- info...
/*
CREATE PROC SAA.RegistoProc
AS
BEGIN
	BEGIN TRAN
		select R.ID_Registo, R.NMEC, R.ID_UC, R.ID_Aval, F.ID_Falta, tipo_Falta, ID_Nota, Nota from SAA.REGISTO AS R
		JOIN SAA.FALTA AS F ON R.ID_Registo=F.ID_Registo
		JOIN SAA.TipoFalta AS TF ON TF.ID_Falta=F.ID_Falta
		JOIN SAA.NOTA AS N ON N.ID_Registo=R.ID_Registo
	COMMIT TRAN
END
*/

-- add Registo--
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
            DECLARE @ID_Curso_Aluno INT; --
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

			--insert into SAA.REGISTO values (@ID_Registo, @NMEC, @ID_UC,@ID_Aval)
		END
	COMMIT TRAN
END

--PROC ADD REGISTO---
CREATE PROCEDURE SAA.addRegisto (@ID_Registo INT, @NMEC INT, @ID_UC INT, @ID_Aval INT)
AS
	INSERT INTO SAA.REGISTO
	VALUES (@ID_Registo INT, @NMEC INT, @ID_UC INT, @ID_Aval INT)
GO

--delete registo---
CREATE PROC SAA.delRegisto ( @ID_Registo INT )
AS
	DELETE SAA.REGISTO
	WHERE ID_Registo = @ID_Registo

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

--VERIFICAR SE ID_AVAL EXISTE
CREATE FUNCTION SAA.X_ID_AVAL_DA_UC_X (@ID_UC INT, @ID_Aval INT) RETURNS TABLE
AS
	RETURN(
		SELECT  ID_Aval , ID_UC
		FROM SAA.AVALIACAO
		WHERE ID_Aval = @ID_Aval AND ID_UC = @ID_UC

	)

select * from SAA.X_ID_AVAL_DA_UC_X (2, 1)


GO
--VERIFICAR SE EXISTE A UC PARA CURSO DO ALUNO (USADO NO TRIGGER SAA.addRegistoTrigger)------
CREATE FUNCTION SAA.X_UC_DO_ALUNO_X (@NMEC int, @ID_UC INT) RETURNS TABLE
AS
	RETURN(
		SELECT  NMEC , ID_UC
		FROM SAA.Relacao_UC_CURSO JOIN SAA.ALUNO ON SAA.Relacao_UC_CURSO.ID_Curso=SAA.ALUNO.ID_Curso
		WHERE NMEC = @NMEC AND ID_UC = @ID_UC

	)


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

--UC do do aluno x
CREATE FUNCTION SAA.UCS_DO_ALUNO (@NMEC int) RETURNS TABLE
AS
	RETURN(
		SELECT Nome, NMEC, Email, SAA.ALUNO.ID_CURSO
		FROM SAA.ALUNO JOIN SAA.Relacao_UC_CURSO ON SAA.ALUNO.ID_Curso = SAA.Relacao_UC_CURSO.ID_Curso
		WHERE NMEC = @NMEC
	)

--media das notas de uma uc para um aluno
CREATE PROC SAA.MediaAlunos ( @NMEC INT, @ID_UC INT )
AS
	SELECT SAA.ALUNO.NMEC, AVG(Nota) AS Media
	FROM ( SAA.ALUNO JOIN SAA.REGISTO ON SAA.ALUNO.NMEC = SAA.REGISTO.NMEC ) JOIN SAA.NOTA ON SAA.REGISTO.ID_REGISTO = SAA.NOTA.ID_REGISTO
	WHERE SAA.ALUNO.NMEC = @NMEC AND SAA.REGISTO.ID_UC = @ID_UC
	GROUP BY SAA.ALUNO.NMEC

--registos de um nmec------
CREATE FUNCTION SAA.REGISTOS_DO_NMEC (@NMEC INT) RETURNS TABLE
AS
	RETURN (
		SELECT *
		FROM SAA.REGISTO
		WHERE NMEC = @NMEC
		)

	
SELECT * FROM SAA.REGISTOS_DO_NMEC (1)

--faltas para um determinada uc
create proc saa.faltas_da_uc (@ID_UC INT )
as
	select saa.uc.ID_UC, count(ID_Falta) as N_Faltas
	from ( saa.registo join saa.uc on saa.registo.id_uc = saa.uc.id_uc ) JOIN SAA.FALTA ON SAA.REGISTO.ID_Registo = SAA.FALTA.ID_Registo
	where saa.uc.id_uc = @id_uc
	group by saa.uc.ID_UC


--media notas da uc
create proc saa.mediaNotas_ucs ( @ID_UC INT )
AS
	select saa.uc.ID_UC, avg(Nota) as Media_nota
	from ( saa.registo join saa.uc on saa.registo.id_uc = saa.uc.id_uc ) JOIN SAA.NOTA ON SAA.REGISTO.ID_Registo = SAA.NOTA.ID_Registo
	where saa.uc.id_uc = @ID_UC
	group by saa.uc.ID_UC

--numero de faltas justificadas para uma uc
create proc saa.num_falta_justificadas_uc (@ID_UC INT)
as
	select SAA.UC.ID_UC, count(tipo_Falta) as num_faltas
	from (( saa.registo join saa.uc on saa.registo.id_uc = saa.uc.id_uc ) JOIN SAA.FALTA ON SAA.REGISTO.ID_Registo = SAA.FALTA.ID_Registo ) JOIN SAA.TipoFalta ON SAA.FALTA.ID_Falta = SAA.TipoFalta.ID_Falta
	where saa.uc.id_uc = @ID_UC AND tipo_Falta = 'Justificada'
	group by SAA.UC.ID_UC


--numero de faltas injustificadas para uma uc
create proc saa.num_falta_injustificadas_uc (@ID_UC INT)
as
	select SAA.UC.ID_UC, count(tipo_Falta) as num_faltas
	from (( saa.registo join saa.uc on saa.registo.id_uc = saa.uc.id_uc ) JOIN SAA.FALTA ON SAA.REGISTO.ID_Registo = SAA.FALTA.ID_Registo ) JOIN SAA.TipoFalta ON SAA.FALTA.ID_Falta = SAA.TipoFalta.ID_Falta
	where saa.uc.id_uc = @ID_UC AND tipo_Falta = 'Injustificada'
	group by SAA.UC.ID_UC


--ENTIDADE FALTA --------------------------------------------------------------------------------------------------------------------------

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



--ENTIDADE NOTA------------
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


--proc para dar update à avalicao com a media das notas da uc



--ENTIDADE ALUNO ---------------------------------------------------------------------------------------------------------------------

--update ALUNO --
CREATE PROCEDURE SAA.updateALUNO (@Nome VARCHAR(50), @NMEC INT, @Email VARCHAR(50), @RegimeEstudo VARCHAR(50), @ID_Horario INT, @ID_Biblioteca INT, @NMEC_TUTOR INT, @Idade INT, @ID_Curso INT)
AS
    UPDATE SAA.ALUNO
    SET Nome = @Nome, NMEC = @NMEC, Email=@Email, RegimeEstudo=@RegimeEstudo, ID_Horario=@ID_Horario, ID_Biblioteca=@ID_Biblioteca, NMEC_TUTOR=@NMEC_TUTOR, Idade=@Idade, ID_Curso=@ID_Curso
    WHERE NMEC = @NMEC
GO


EXEC SAA.updateALUNO 'teste', 9999, 'teste123', 'Estudante', 10, 1,  9998, 19,'QWE', 5
--add aluno -- 
CREATE PROCEDURE SAA.addALUNO (@Nome VARCHAR(50), @Email VARCHAR(50), @RegimeEstudo VARCHAR(50), @ID_Horario INT, @ID_Biblioteca INT, @NMEC_TUTOR INT, @Idade INT, @ID_Curso INT)
AS
	DECLARE @NMECX INT;

	INSERT INTO SAA.ALUNO
	VALUES ( @Nome, @NMECX, @Email, @RegimeEstudo, @ID_Horario, @ID_Biblioteca, @NMEC_TUTOR, @Idade, @ID_Curso )
GO

--add aluno trigger opçao 2 --
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


--Apagar aluno--
CREATE PROCEDURE SAA.del_Aluno (@NMEC int) 
AS
	DELETE FROM SAA.ALUNO WHERE NMEC = @NMEC
GO

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




--ENTIDADE Horario
--------------------------------------------------------------------------------------------------------------------------------------------
-- add HORARIO
CREATE PROCEDURE SAA.addHorario
AS
	DECLARE @ID_HORARIOX INT;
	INSERT INTO SAA.HORARIO 
	VALUES (@ID_HORARIOX) 
GO

--TRIGGER PARA ADD HORARIOS AUTOMATICAMENTE
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

--PROC para apagar horarios
CREATE PROCEDURE SAA.deleteHorario (@ID_Horario INT)
AS
	DELETE SAA.HORARIO
	WHERE ID_Horario = @ID_Horario
GO

EXEC SAA.deleteHorario 2

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





--UDF ALUNO EM ERASMOS
CREATE FUNCTION SAA.ALUNO_EM_ERASMOS (@Erasmus varchar(50)) RETURNS TABLE
AS 
	RETURN(
		SELECT ALUNO.NMEC, ALUNO.Nome, ALUNO.RegimeEstudo,ID_Biblioteca, ALUNO.Email
		FROM SAA.ALUNO
		WHERE RegimeEstudo=@Erasmus
		)
go

SELECT * FROM SAA.ALUNO_EM_ERASMOS('Erasmus')
go

--Stored Procedure do numero de alunos em erasmos que frequentam a biblioteca
CREATE PROCEDURE SAA.TOTAL_ALUNOS_ERASMOS_BIBLOTECA
AS
	SELECT COUNT(A.ID_Biblioteca)
		FROM SAA.ALUNO AS A
		WHERE RegimeEstudo='Erasmus'
go
EXEC SAA.TOTAL_ALUNOS_ERASMOS_BIBLOTECA
go

-- UDF Alunos da turma X
CREATE FUNCTION SAA.ALUNOS_TURMA_X (@Turma INT) RETURNS TABLE
AS
	RETURN(
		SELECT A.NMEC, A.Nome, A.Email, T.ID_Turma
		FROM SAA.ALUNO AS A JOIN SAA.Relacao_ALUNO_TURMA AS RAT ON A.NMEC=RAT.NMEC
		JOIN SAA.TURMA AS T ON RAT.ID_Turma=T.ID_Turma
		WHERE T.ID_Turma=@Turma
	)
go
SELECT * FROM SAA.ALUNOS_TURMA_X(1)
go 


--Total_Alunos_Por_Curso
CREATE PROCEDURE SAA.Total_Alunos_Por_Curso
AS
	SELECT Nome_Curso, COUNT(NMEC) as Numero_Alunos
	FROM SAA.ALUNO JOIN SAA.CURSO ON SAA.ALUNO.ID_Curso = SAA.CURSO.ID_Curso
	GROUP BY Nome_Curso
go
EXEC SAA.Total_Alunos_Por_Curso


select * from SAA.




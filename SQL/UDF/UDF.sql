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
			FETCH NEXT FROM cursorX INTO @nomeProf1, @num_gab1, @Email1,@tnmec1,@id_dep1,@id_Hor1
		END
		CLOSE cursorX
		DEALLOCATE cursorX
		BEGIN
			INSERT INTO SAA.PROFESSOR VALUES (@nomeProf,@num_gab,@Email,@tnmec,@id_dep,@id_Hor )
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
				RAISERROR('Essa turma já existe!',16,1)
			END
			FETCH NEXT FROM cursorX INTO @id_turma1, @Tnmec1, @id_Horario1,@AnoLectivo1
		END
		CLOSE cursorX
		DEALLOCATE cursorX
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



-- Turmas e alunos de há x anos atrás

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
BEGIN	--verifica se o curso já existe
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
			RAISERROR('Curso já existe!',16,1)
		
		DECLARE cursorX CURSOR FOR SELECT * FROM SAA.CURSO
		OPEN cursorX
		FETCH NEXT FROM cursorX INTO @nomeCurso1,@id_curso1,@id_dep1
		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF(@id_curso1=@id_curso)
			BEGIN 
				RAISERROR('Curso já existe!',16,1)
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
--show curso
create proc SAA.showCurso
AS 
BEGIN
	BEGIN TRAN	
		select * from SAA.CURSO
	COMMIT TRAN
END


--ESTE DÁ -> O DE CIMA JÁ DA!!!!
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
		DECLARE @ID_UC varchar(50);
		DECLARE @AnoFormacao date;
		DECLARE @id_horario int;
		DECLARE @id_aval int;
		
		DECLARE @ID_UC1 varchar(50);
		DECLARE @AnoFormacao1 date;
		DECLARE @id_horario1 int;
		DECLARE @id_aval1 int;
		
		
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
			FETCH NEXT FROM cursorX INTO @ID_UC1, @AnoFormacao1, @id_horario1,@id_aval1
		END
		CLOSE cursorX
		DEALLOCATE cursorX
		BEGIN
			insert into SAA.UC values ( @ID_UC,@AnoFormacao,@id_horario,@id_aval )
	   END
	END
END


--add UC
CREATE PROCEDURE SAA.addUC(@ID_UC int,  @anoForm date, @id_horario int, @id_aval int)  
AS
	insert into SAA.UC values ( @ID_UC,@anoForm,@id_horario,@id_aval)
GO

----- SAA.addUC_and_Curso
CREATE PROCEDURE SAA.addUC_and_Curso(@ID_UC int,  @id_Curso int)  
AS
BEGIN
	BEGIN TRAN
		insert into SAA.Relacao_UC_CURSO values ( @ID_UC,@id_Curso )
	COMMIT TRAN
END
GO

--
CREATE PROCEDURE SAA.updateUC_and_Curso(@ID_UC int,  @id_Curso int)  
AS
BEGIN
	BEGIN TRAN
		update SAA.Relacao_UC_CURSO set ID_UC = @ID_UC, ID_Curso = @id_Curso where ID_UC=@ID_UC;
	COMMIT TRAN
END
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

-- add Registo
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

			insert into SAA.REGISTO values (@ID_Registo, @NMEC, @ID_UC,@ID_Aval)
		END
	COMMIT TRAN
END

--update Registo
CREATE PROCEDURE SAA.updateRegisto(@idReg int,  @nmec int, @id_uc int, @id_aval int) 
AS
BEGIN
	BEGIN TRAN
	IF (SELECT COUNT(*) FROM SAA.REGISTO WHERE ID_Registo = @idReg ) >0
		BEGIN
			 UPDATE SAA.REGISTO
			 SET ID_Registo = @idReg, NMEC = @nmec, ID_UC =  @id_uc, ID_Aval =@id_aval
			 WHERE ID_Registo = @idReg
		END
	ELSE
		BEGIN
			Print 'Nao existe nenhum Registo com esse ID';
		END
	COMMIT TRAN

END



































--ENTIDADE Horario
--------------------------------------------------------------------------------------------------------------------------------------------
CREATE FUNCTION SAA.DADOS_HOR_X (@id_hor int) RETURNS TABLE
AS
	RETURN(
	select H.ID_Horario,Nome,NMEC,AL.Email,PP.TMEC,Nome_Prof
	from SAA.ALUNO AS AL
	JOIN SAA.HORARIO AS H ON AL.ID_Horario =H.ID_Horario
	JOIN SAA.UC AS UC ON H.ID_Horario=UC.ID_Horario
	JOIN SAA.Relacao_UC_PROFESSOR AS RUP ON RUP.ID_UC=UC.ID_UC
	JOIN SAA.PROFESSOR AS PP ON PP.TMEC=RUP.TMEC
	WHERE H.ID_Horario=@id_hor
	)

--UDF Horario Aluno PorTurma X
CREATE FUNCTION SAA.Horario_Aluno_PorTurmaX (@turma INT) RETURNS TABLE
AS
	RETURN (
	    SELECT A.NMEC, A.Nome, T.ID_Turma
		FROM SAA.ALUNO AS A JOIN SAA.HORARIO AS H ON A.ID_Horario=H.ID_Horario
		JOIN SAA.TURMA AS T ON H.ID_Horario=T.ID_Horario
		WHERE ID_TURMA=@turma
	)
go
select * from SAA.Horario_Aluno_PorTurmaX(2)
go










































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





-- View de alunos em erasmus
CREATE VIEW ALUNO_EM_ERASMOS AS
	SELECT ALUNO.NMEC, ALUNO.Nome, ALUNO.RegimeEstudo,ID_Biblioteca, ALUNO.Email
	FROM SAA.ALUNO
	WHERE RegimeEstudo='Erasmus'

--View de numero de alunos em erasmos que frequentam a biblioteca
CREATE VIEW TOTAL_ALUNOS_ERASMOS_BIBLOTECA AS
	SELECT COUNT(ALUNO_EM_ERASMOS.ID_Biblioteca) AS TOTAL_ALUNOS_ERASMOS_BIBLIO
    FROM ALUNO_EM_ERASMOS JOIN SAA.BIBLIOTECA ON ALUNO_EM_ERASMOS.ID_Biblioteca = SAA.BIBLIOTECA.ID_Biblioteca


--View de uma lista com os alunos da turma 1
CREATE VIEW ALUNOS_TURMA_1 AS
	SELECT A.NMEC, A.Nome, A.Email, T.ID_Turma
	FROM SAA.ALUNO AS A JOIN SAA.Relacao_ALUNO_TURMA AS RAT ON A.NMEC=RAT.NMEC
	JOIN SAA.TURMA AS T ON RAT.ID_Turma=T.ID_Turma
	WHERE T.ID_Turma=1

--View de turmas e salas
CREATE VIEW TURMAS_E_SALAS AS
	SELECT AT1.NMEC, AT1.Nome,AT1.Email, AT1.ID_Turma
	FROM ALUNOS_TURMA_1 AS AT1 JOIN SAA.Relacao_Turma_Sala AS RTS ON AT1.ID_Turma=RTS.ID_Turma
	JOIN SAA.SALA AS S ON RTS.ID_Sala=S.ID_Sala


--View turmas professor Carlos
CREATE VIEW TURMAS_PROFESSOR_CARLOS AS
	SELECT T.ID_Turma,P.TMEC,  P.Nome_Prof, P.Email
	FROM SAA.PROFESSOR AS P JOIN SAA.TURMA AS T ON P.TMEC=T.TNEMC
	WHERE P.Nome_Prof='Carlos'

--View total de professores do departamento 1
CREATE VIEW Total_Prof_Dep1 AS
    SELECT COUNT(D.ID_Dep) AS TOTAL_PROF_DEP_1
	FROM SAA.PROFESSOR AS P JOIN SAA.DEPARTAMENTO AS D ON P.ID_DEP=D.ID_Dep
	WHERE D.ID_Dep=1

--View  dos alunos com horario da turma 1
CREATE VIEW ALUNOS_HORARIO_TURMA1 AS
	SELECT A.NMEC, A.Nome, T.ID_Turma
	FROM SAA.ALUNO AS A JOIN SAA.HORARIO AS H ON A.ID_Horario=H.ID_Horario
	JOIN SAA.TURMA AS T ON H.ID_Horario=T.ID_Horario
	WHERE ID_TURMA=1

--View Total de alunos com o horario da turma 1
CREATE VIEW Total_ALUNOS_HORARIO_TURMA1 AS
	SELECT COUNT(NMEC) AS TOTAL_ALUNOS_T1
	FROM ALUNOS_HORARIO_TURMA1 

--Ver as salas e o seu tipo para cada departamento
CREATE VIEW SALA_DEPARTAMENTO AS
	SELECT Nome_Dep, ID_Sala, tipoSala
	FROM SAA.DEPARTAMENTO JOIN SAA.SALA ON SAA.DEPARTAMENTO.ID_Dep = SAA.SALA.ID_Dep

--Ver de que departamento sao os professores
CREATE VIEW PROFESSOR_DEPARTAMENO AS
	SELECT Nome_Prof, TMEC, Nome_Dep
	FROM SAA.DEPARTAMENTO JOIN SAA.PROFESSOR ON SAA.DEPARTAMENTO.ID_Dep = SAA.PROFESSOR.ID_DEP

--Numero de faltas injustificadas dos alunos a cada uc
CREATE VIEW FALTA_INJUSTIFICADAS_ALUNOS AS
	SELECT Nome, ID_UC, Tipo_Falta, COUNT(ID_UC) AS NUM_FALTAS
	FROM (SAA.REGISTO JOIN SAA.FALTA ON SAA.REGISTO.ID_Registo = SAA.FALTA.ID_Registo) JOIN SAA.ALUNO ON SAA.ALUNO.NMEC = SAA.REGISTO.NMEC
	WHERE Tipo_Falta = 'Injustificada'
	GROUP BY Nome, ID_UC, Tipo_Falta

--Ver as uc's de cada curso
CREATE VIEW UC_CURSO AS
	SELECT Nome_Curso, ID_UC
	FROM SAA.Relacao_UC_CURSO JOIN SAA.CURSO ON SAA.Relacao_UC_CURSO.ID_Curso = SAA.CURSO.ID_Curso
	ORDER BY Nome_Curso OFFSET 0 ROWS;

--Ver alunos de um curso
CREATE VIEW NUM_ALUNOS_CURSO AS
	SELECT Nome_Curso, COUNT(NMEC) as Numero_Alunos
	FROM SAA.ALUNO JOIN SAA.CURSO ON SAA.ALUNO.ID_Curso = SAA.CURSO.ID_Curso
	GROUP BY Nome_Curso










SELECT * FROM ALUNOS_HORARIO_TURMA1
SELECT * FROM ALUNOS_TURMA_1
SELECT * FROM TURMAS_E_SALAS
SELECT * FROM SAA.ALUNO
SELECT * FROM SAA.HORARIO
SELECT * FROM SAA.TURMA
SELECT * FROM SAA.Relacao_ALUNO_TURMA
SELECT * FROM SAA.Relacao_Turma_Sala
SELECT * FROM SAA.TURMA;
SELECT * FROM SAA.HORARIO;
SELECT * FROM SAA.PROFESSOR
SELECT * FROM SAA.DEPARTAMENTO
SELECT * FROM SAA.SALA;
SELECT * FROM SAA.Relacao_Turma_Sala













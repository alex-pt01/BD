CREATE SCHEMA SAA;
GO

CREATE TABLE SAA.ALUNO(
Nome VARCHAR(50) NOT NULL,
NMEC INT NOT NULL,
Email VARCHAR(50) NOT NULL,
RegimeEstudo VARCHAR(50) CHECK (RegimeEstudo='Estudante' OR RegimeEstudo='Erasmus' OR  RegimeEstudo='TrabalhadorEstudante' OR  RegimeEstudo='EstudanteInternacional'), 
Idade INT NOT NULL,

UNIQUE(NMEC),
PRIMARY KEY(NMEC)
);


CREATE TABLE SAA.Relacao_ALUNO_TURMA(
ID_Turma INT NOT NULL,
NMEC INT NOT NULL,

PRIMARY KEY(ID_Turma, NMEC)
);



CREATE TABLE SAA.CURSO(
Nome_Curso VARCHAR(50) NOT NULL,
ID_Curso INT NOT NULL,

UNIQUE(ID_Curso),
PRIMARY KEY(ID_Curso)
);


CREATE TABLE SAA.UC(
ID_UC INT NOT NULL,
AnoFormacao DATE NOT NULL,

UNIQUE(ID_UC),
PRIMARY KEY(ID_UC)
);



CREATE TABLE SAA.Relacao_UC_CURSO(
ID_UC INT NOT NULL,
ID_Curso INT NOT NULL,


);

CREATE TABLE SAA.Relacao_UC_PROFESSOR(
ID_UC INT NOT NULL,
TMEC INT NOT NULL,

PRIMARY KEY(ID_UC, TMEC)
);

-- ---------------------------------                                            
CREATE TABLE SAA.AVALIACAO(
	ID_UC INT NOT NULL    DEFAULT(0), 
	ID_Aval INT NOT NULL,
	notaDecimal DECIMAL(4,2) NOT NULL      
 
	UNIQUE(ID_Aval),
	PRIMARY KEY(ID_Aval),

	CONSTRAINT AVAL_UC 
		FOREIGN KEY (ID_UC) REFERENCES SAA.UC(ID_UC) 
				ON DELETE SET DEFAULT ON UPDATE CASCADE
);


-- ---------------------------------


CREATE TABLE SAA.HORARIO(
ID_Horario INT NOT NULL,

UNIQUE(ID_Horario),
PRIMARY KEY(ID_Horario)
);


CREATE TABLE SAA.TURMA(
ID_Turma INT NOT NULL,
AnoLectico INT,

UNIQUE(ID_Turma),
PRIMARY KEY(ID_Turma)
);

-- ----------------------------------
CREATE TABLE SAA.PROFESSOR(
Nome_Prof VARCHAR(30) NOT NULL,
Num_Gabinete INT NOT NULL,
Email VARCHAR(40) NOT NULL,
TMEC INT NOT NULL,

UNIQUE(TMEC),
PRIMARY KEY(TMEC)
);

ALTER TABLE SAA.PROFESSOR
ADD CONSTRAINT EmailUnique UNIQUE (Email);
----------------------------------

CREATE TABLE SAA.DEPARTAMENTO(
Nome_Dep VARCHAR(30) NOT NULL,
ID_Dep INT NOT NULL,
Localizacao_Dep VARCHAR(30) NOT NULL,

UNIQUE(ID_Dep),
PRIMARY KEY(ID_Dep)
);

-- ---------------------------------
CREATE TABLE SAA.SALA(
ID_Sala INT NOT NULL,
Limite_Alunos INT NOT NULL,

UNIQUE(ID_Sala),         
PRIMARY KEY(ID_Sala)
);

CREATE TABLE SAA.TipoSala(
ID_Sala INT NOT NULL,

PRIMARY KEY (ID_Sala)
);

CREATE TABLE SAA.Relacao_Turma_Sala(
ID_Sala INT NOT NULL,
ID_Turma INT NOT NULL,

PRIMARY KEY(ID_Turma)
);

-- ---------------------------------

CREATE TABLE SAA.REGISTO(
ID_Registo INT NOT NULL,

UNIQUE(ID_Registo),
PRIMARY KEY(ID_Registo)
);

CREATE TABLE SAA.NOTA (
	ID						INT						NOT NULL										DEFAULT ('not found'),
	Id_Aval				INT						NOT NULL										DEFAULT ('not found'),
	nota DECIMAL(4,2) NOT NULL 

	PRIMARY KEY (ID, Id_Aval), 

	CONSTRAINT NOTA_ALUNO 
		FOREIGN KEY (ID) REFERENCES SAA.REGISTO(ID_Registo) 
				ON DELETE SET DEFAULT ON UPDATE CASCADE,
);

CREATE TABLE SAA.FALTA (
	ID						INT						NOT NULL										DEFAULT ('not found'),
	Id_Aval				INT						NOT NULL										DEFAULT ('not found'),

	PRIMARY KEY (ID, Id_Aval), 

	CONSTRAINT FALTA_ALUNO 
		FOREIGN KEY (ID) REFERENCES SAA.REGISTO(ID_Registo) 
				ON DELETE SET DEFAULT ON UPDATE CASCADE,
);

CREATE TABLE SAA.TipoFalta(
ID_Falta INT NOT NULL,

PRIMARY KEY(ID_Falta)
);

-- ------------------------------------------------------------------

CREATE TABLE SAA.BIBLIOTECA(
ID_Biblioteca INT NOT NULL,
Lot_Max_Biblio INT NOT NULL, 

UNIQUE(ID_Biblioteca),              
PRIMARY KEY(ID_Biblioteca)
);


/*Aluno a receber estrangeiras*/
ALTER TABLE SAA.ALUNO ADD ID_Horario INT NOT NULL;
ALTER TABLE SAA.ALUNO ADD ID_Biblioteca INT NOT NULL;
ALTER TABLE SAA.ALUNO ADD ID_Secretaria INT;
ALTER TABLE SAA.ALUNO ADD ID_Curso INT NOT NULL;
ALTER TABLE SAA.ALUNO ADD NMEC_Tutor INT;

ALTER TABLE SAA.ALUNO ADD CONSTRAINT FK_ID_Horario_Aluno FOREIGN KEY (ID_Horario) REFERENCES SAA.HORARIO (ID_Horario);
ALTER TABLE SAA.ALUNO ADD CONSTRAINT FK_ID_Biblioteca_Aluno FOREIGN KEY (ID_Biblioteca) REFERENCES SAA.BIBLIOTECA (ID_Biblioteca);
ALTER TABLE SAA.ALUNO ADD CONSTRAINT FK_ID_Secretaria_Aluno FOREIGN KEY (ID_Secretaria) REFERENCES SAA.SECRETARIA (ID_Secretaria);
ALTER TABLE SAA.ALUNO ADD CONSTRAINT FK_ID_Curso_Aluno FOREIGN KEY (ID_Curso) REFERENCES SAA.CURSO (ID_Curso);
ALTER TABLE SAA.ALUNO ADD CONSTRAINT FK_TUTOR_Aluno FOREIGN KEY (NMEC_Tutor) REFERENCES SAA.ALUNO (NMEC); 

/*Relacao_ALUNO_TURMA*/
ALTER TABLE SAA.Relacao_ALUNO_TURMA ADD CONSTRAINT FK_ID_Turma_Aluno_Turma FOREIGN KEY (ID_Turma) REFERENCES SAA.TURMA (ID_Turma);
ALTER TABLE SAA.Relacao_ALUNO_TURMA ADD CONSTRAINT FK_NMEC_Aluno_Turma FOREIGN KEY (NMEC) REFERENCES SAA.ALUNO (NMEC);


/*Relacao_Refeitorio_Aluno*/
ALTER TABLE SAA.Relacao_Refeitorio_Aluno ADD CONSTRAINT FK_ID_Refeitorio_Aluno_Refeitorio FOREIGN KEY (ID_Refeitorio) REFERENCES SAA.REFEITORIO (ID_Refeitorio);
ALTER TABLE SAA.Relacao_Refeitorio_Aluno ADD CONSTRAINT FK_NMEC_Aluno_Refeitorio FOREIGN KEY (NMEC) REFERENCES SAA.ALUNO (NMEC);

/*para UC*/
ALTER TABLE SAA.UC ADD ID_Horario INT NOT NULL;

ALTER TABLE SAA.UC ADD CONSTRAINT FK_ID_Horario_UC FOREIGN KEY (ID_Horario) REFERENCES SAA.HORARIO (ID_Horario);
ALTER TABLE SAA.UC ADD CONSTRAINT UC_AVAL FOREIGN KEY (ID_Aval) REFERENCES SAA.AVALIACAO (ID_Aval);

/*avaliacao*/
ALTER TABLE SAA.AVALIACAO ADD CONSTRAINT AVAL_UC FOREIGN KEY (ID_UC) REFERENCES SAA.AVALIACAO (ID_UC);

/*Relacao_UC_CURSO*/
ALTER TABLE SAA.Relacao_UC_CURSO ADD CONSTRAINT FK_ID_UC FOREIGN KEY (ID_UC) REFERENCES SAA.UC (ID_UC);
ALTER TABLE SAA.Relacao_UC_CURSO ADD CONSTRAINT FK_ID_Curso FOREIGN KEY (ID_Curso) REFERENCES SAA.CURSO (ID_Curso);

/*Relacao_UC_PROFESSOR*/
ALTER TABLE SAA.Relacao_UC_PROFESSOR ADD CONSTRAINT FK_ID_UC_UC_PROFESSOR FOREIGN KEY (ID_UC) REFERENCES SAA.UC (ID_UC);
ALTER TABLE SAA.Relacao_UC_PROFESSOR ADD CONSTRAINT FK_TMEC_UC_PROFESSOR FOREIGN KEY (TMEC) REFERENCES SAA.PROFESSOR (TMEC);

/*para PROFESSOR*/
ALTER TABLE SAA.PROFESSOR ADD ID_Dep INT NOT NULL;
ALTER TABLE SAA.PROFESSOR ADD ID_Horario INT NOT NULL;

ALTER TABLE SAA.PROFESSOR ADD CONSTRAINT FK_ID_Dep_PROFESSOR FOREIGN KEY (ID_Dep) REFERENCES SAA.DEPARTAMENTO (ID_Dep);
ALTER TABLE SAA.PROFESSOR ADD CONSTRAINT FK_ID_Horario_PROFESSOR FOREIGN KEY (ID_Horario) REFERENCES SAA.HORARIO (ID_Horario);

/*Para CURSO*/
ALTER TABLE SAA.CURSO ADD ID_Dep INT NOT NULL;

ALTER TABLE SAA.CURSO ADD CONSTRAINT FK_ID_Dep_CURSO FOREIGN KEY (ID_Dep) REFERENCES SAA.DEPARTAMENTO (ID_Dep);



/*Para o Registo*/
ALTER TABLE SAA.REGISTO ADD NMEC INT NOT NULL;
ALTER TABLE SAA.REGISTO ADD ID_Curso INT NOT NULL;

ALTER TABLE SAA.REGISTO ADD CONSTRAINT FK_NMEC_REGISTO FOREIGN KEY (NMEC) REFERENCES SAA.ALUNO (NMEC);
ALTER TABLE SAA.REGISTO ADD CONSTRAINT REGISTO_UC FOREIGN KEY (ID_UC) REFERENCES SAA.Curso (ID_UC);     
ALTER TABLE SAA.REGISTO ADD CONSTRAINT REGISTO_AVAL FOREIGN KEY (ID_Aval) REFERENCES SAA.AVALIACAO (ID_Aval);     


/*para FALTA DO REGISTO*/
ALTER TABLE SAA.FALTA ADD Tipo_Falta VARCHAR(30) CHECK( Tipo_Falta='Justificada' or Tipo_Falta='Injustificada' );






/*para multi-valor Tipo_Falta*/     
ALTER TABLE SAA.Tipo_Falta ADD ID_Registo INT NOT NULL;

ALTER TABLE SAA.Tipo_Falta ADD CONSTRAINT FK_ID_Registo_TIPO_FALTA FOREIGN KEY (ID_Registo) REFERENCES SAA.REGISTO (ID_Registo);


/*para Sala*/
ALTER TABLE SAA.SALA ADD ID_Dep INT NOT NULL;
ALTER TABLE SAA.SALA ADD tipoSala VARCHAR(20) CHECK (tipoSala = 'Normal' or tipoSala = 'Anfiteatro' or tipoSala = 'Computadores')

ALTER TABLE SAA.SALA ADD CONSTRAINT FK_Nome_Dep_SALA FOREIGN KEY (ID_Dep) REFERENCES SAA.DEPARTAMENTO (ID_Dep);


/*Relacao_Turma_Sala */
ALTER TABLE SAA.RELACAO_TURMA_SALA ADD CONSTRAINT FK_ID_Turma_SALA_TURMA FOREIGN KEY (ID_Turma) REFERENCES SAA.TURMA (ID_Turma);
ALTER TABLE SAA.RELACAO_TURMA_SALA ADD CONSTRAINT FK_ID_Sala_SALA_TURMA FOREIGN KEY (ID_Sala) REFERENCES SAA.SALA (ID_Sala);

/*para TURMA*/
ALTER TABLE SAA.TURMA ADD ID_Horario INT NOT NULL;
ALTER TABLE SAA.TURMA ADD TNEMC INT NOT NULL;

ALTER TABLE SAA.TURMA ADD CONSTRAINT FK_ID_Horario_TURMA FOREIGN KEY (ID_Horario) REFERENCES SAA.HORARIO (ID_Horario);
ALTER TABLE SAA.TURMA ADD CONSTRAINT FK_TNMEC_TURMA FOREIGN KEY (TNMEC) REFERENCES SAA.PROFESSOR (TNMEC);

/*para BOLSA_ESTUDO_ALUNO*/
ALTER TABLE SAA.BOLSA_ESTUDO_ALUNO ADD NMEC INT NOT NULL;
ALTER TABLE SAA.BOLSA_ESTUDO_ALUNO ADD Designac�o VARCHAR(40) NOT NULL;

ALTER TABLE SAA.BOLSA_ESTUDO_ALUNO ADD CONSTRAINT FK_NMEC_BOLSA_ESTUDO FOREIGN KEY (NMEC) REFERENCES SAA.ALUNO (NMEC);
ALTER TABLE SAA.BOLSA_ESTUDO_ALUNO ADD CONSTRAINT FK_Designacao_BOLSA FOREIGN KEY (Designac�o) REFERENCES SAA.TIPO_BOLSA_ESTUDO (Designac�o);


/* para multi-valor tipoSala*/
ALTER TABLE SAA.TipoSala ADD CONSTRAINT FK_ID_Sala FOREIGN KEY (ID_Sala) REFERENCES SAA.SALA (ID_Sala);




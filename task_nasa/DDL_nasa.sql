USE db_nasa;

DROP TABLE IF EXISTS Corpo_Sistema;
DROP TABLE IF EXISTS Sistema;
DROP TABLE IF EXISTS CorpoCeleste;

CREATE TABLE CorpoCeleste
(
	corpoID INT PRIMARY KEY IDENTITY (1,1),
	codice_corpo UNIQUEIDENTIFIER DEFAULT NEWID(),
	nome_corpo NVARCHAR(250) NOT NULL,
	tipo_corpo NVARCHAR(250) NOT NULL,
	scopritore NVARCHAR(250) DEFAULT 'Sconosciuto',
	data_scoperta DATE NOT NULL,
	distanza_da_terra DECIMAL (10,2) NOT NULL,
	coordinata_radiale DECIMAL (10,2) NOT NULL,
	coordinata_angolare DECIMAL (10,2) NOT NULL CHECK (coordinata_angolare >= 0 AND coordinata_angolare < 360),	
	deleted_corpo DATETIME DEFAULT NULL
);

CREATE TABLE Sistema(
	sistemaID INT PRIMARY KEY IDENTITY (1,1),
	codice_sistema UNIQUEIDENTIFIER DEFAULT NEWID(),
	nome_sistema NVARCHAR(250) NOT NULL,
	tipo_sistema NVARCHAR(250) NOT NULL,
	deleted_sistema DATETIME DEFAULT NULL
);


CREATE TABLE Corpo_Sistema(
	corpoRIF INT NOT NULL,
	sistemaRIF INT NOT NULL,
	FOREIGN KEY (corpoRIF) REFERENCES CorpoCeleste(corpoID),
	FOREIGN KEY (sistemaRIF) REFERENCES Sistema(sistemaID),
	PRIMARY KEY (corpoRIF, sistemaRIF)
);

INSERT INTO CorpoCeleste (nome_corpo, tipo_corpo, scopritore, data_scoperta, distanza_da_terra, coordinata_radiale, coordinata_angolare)
VALUES ('Marte', 'Pianeta', 'Antichi', '1800-01-01', 225.0, 1.52, 45.0),
       ('Giove', 'Pianeta', 'Galileo Galilei', '1610-01-07', 778.5, 5.20, 100.0),
       ('Encelado', 'Luna', 'William Herschel', '1789-08-28', 238.0, 1.37, 160.0);

INSERT INTO Sistema (nome_sistema, tipo_sistema)
VALUES ('Sistema Solare', 'Sistema Planetario'),
       ('Alpha Centauri', 'Sistema Stellare'),
       ('TRAPPIST-1', 'Sistema Planetario'),
       ('Kepler-90', 'Sistema Planetario'),
       ('Gliese 581', 'Sistema Planetario');

INSERT INTO Corpo_Sistema (corpoRIF, sistemaRIF) VALUES (1, 1);

INSERT INTO Corpo_Sistema (corpoRIF, sistemaRIF) VALUES (2, 1);

INSERT INTO Corpo_Sistema (corpoRIF, sistemaRIF) VALUES (3, 1);

SELECT	corpoID, 
		sistemaID, 
		corpoRIF, 
		sistemaRIF, 
		codice_corpo, 
		codice_sistema, 
		nome_corpo, 
		tipo_corpo, 
		nome_sistema,
		tipo_sistema,
		scopritore,
		data_scoperta,
		coordinata_radiale,
		coordinata_angolare,
		deleted_corpo,
		deleted_sistema
		FROM CorpoCeleste
			JOIN Corpo_Sistema ON CorpoCeleste.corpoID = Corpo_Sistema.corpoRIF
			JOIN Sistema ON Corpo_Sistema.sistemaRIF = Sistema.sistemaID;
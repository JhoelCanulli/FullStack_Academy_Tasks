USE db_impiegati;

DROP TABLE IF EXISTS Impiegato;
DROP TABLE IF EXISTS Reparto;
DROP TABLE IF EXISTS Residenza;

CREATE TABLE Residenza(
	residenzaID INT PRIMARY KEY IDENTITY(1,1),
	codice VARCHAR(250) DEFAULT NEWID(),
	citta VARCHAR(100) NOT NULL,
	provincia VARCHAR(100) NOT NULL,
	via VARCHAR(100) NOT NULL
)

CREATE TABLE Reparto(
	repartoID INT PRIMARY KEY IDENTITY(1,1),
	codice VARCHAR(100) DEFAULT NEWID(),
	nome VARCHAR(100) NOT NULL
)

CREATE TABLE Impiegato(
	impiegatoID INT PRIMARY KEY IDENTITY(1,1),
	matricola VARCHAR(100) DEFAULT NEWID(),
	nome VARCHAR(100) NOT NULL,
	cognome VARCHAR(100) NOT NULL,
	dnascita DATE NOT NULL,
	ruolo VARCHAR(100) NOT NULL,
	residenzaRIF INT NOT NULL,
	repartoRIF INT NOT NULL,
	FOREIGN KEY(residenzaRIF) REFERENCES Residenza(residenzaID),
	FOREIGN KEY(repartoRIF) REFERENCES Reparto(repartoID)
)

INSERT INTO Residenza(citta, provincia, via) VALUES ('Roma', 'RM','viale Marx');
INSERT INTO Residenza(citta, provincia, via) VALUES ('Roma', 'RM','"via del Basile');
INSERT INTO Residenza(citta, provincia, via) VALUES ('Roma', 'RM','via Mozart');

INSERT INTO Reparto(nome) VALUES ('salumi e formaggi');
INSERT INTO Reparto(nome) VALUES ('casalinghi');
INSERT INTO Reparto(nome) VALUES ('cosmetici');

INSERT INTO Impiegato(nome, cognome, dnascita, ruolo, residenzaRIF, repartoRIF) 
VALUES ('Alex', 'Rossi', '1990-1-2', 'capo reparto', 1, 3);
INSERT INTO Impiegato(nome, cognome, dnascita, ruolo, residenzaRIF, repartoRIF) 
VALUES ('Maria', 'Bianchi', '1995-10-8', 'addetta al magazzino', 2, 2);
INSERT INTO Impiegato(nome, cognome, dnascita, ruolo, residenzaRIF, repartoRIF) 
VALUES ('Sergio', 'Neri', '1980-11-11', 'banconista', 3, 1);

SELECT 
	residenzaID,
	repartoID,
	impiegatoID,
	Reparto.codice codiceReparto,
	Residenza.codice codiceResidenza,
	matricola,
	Impiegato.nome, 
	cognome, 
	dnascita 'data di nascita', 
	ruolo, 
	residenzaRIF, 
	repartoRIF
		FROM Residenza
			JOIN Impiegato ON Residenza.residenzaID = Impiegato.residenzaRIF
			JOIN Reparto ON Impiegato.repartoRIF = Reparto.repartoID;
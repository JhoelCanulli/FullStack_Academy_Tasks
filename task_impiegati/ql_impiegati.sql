USE impiegati;

DROP TABLE IF EXISTS Residenza;
DROP TABLE IF EXISTS Reparto;
DROP TABLE IF EXISTS Impiegato;

CREATE TABLE Residenza(
	residenzaID INT PRIMARY KEY IDENTITY(1,1),
	codice_residenza VARCHAR(250) DEFAULT NEWID(),
	citta VARCHAR(100),
	provincia VARCHAR(100),
	via VARCHAR(100)
)

CREATE TABLE Reparto(
	repartoID INT PRIMARY KEY IDENTITY(1,1),
	codice_reparto VARCHAR(100) DEFAULT NEWID(),
	nome_reparto VARCHAR(100) NOT NULL
)

CREATE TABLE Impiegato(
	impiegatoID INT PRIMARY KEY IDENTITY(1,1),
	matricola VARCHAR(100) DEFAULT NEWID(),
	nome_impiegato VARCHAR(100) NOT NULL,
	cognome VARCHAR(100) NOT NULL,
	data_nascita DATE NOT NULL,
	ruolo VARCHAR(100) NOT NULL,
	residenzaRIF INT NOT NULL,
	repartoRIF INT NOT NULL,
	FOREIGN KEY(residenzaRIF) REFERENCES Residenza(residenzaID),
	FOREIGN KEY(repartoRIF) REFERENCES Reparto(repartoID)
)

INSERT INTO Residenza(citta, provincia, via) VALUES ('Roma', 'RM','viale Marx');
INSERT INTO Residenza(citta, provincia, via) VALUES ('Roma', 'RM','"via del Basile');
INSERT INTO Residenza(citta, provincia, via) VALUES ('Roma', 'RM','via Mozart');

INSERT INTO Reparto(nome_reparto) VALUES ('salumi e formaggi');
INSERT INTO Reparto(nome_reparto) VALUES ('casalinghi');
INSERT INTO Reparto(nome_reparto) VALUES ('cosmetici');

INSERT INTO Impiegato(nome_impiegato, cognome, data_nascita, ruolo, residenzaRIF, repartoRIF) 
VALUES ('Alex', 'Rossi', '1990-1-2', 'capo reparto', 1, 3);
INSERT INTO Impiegato(nome_impiegato, cognome, data_nascita, ruolo, residenzaRIF, repartoRIF) 
VALUES ('Maria', 'Bianchi', '1995-10-8', 'addetta al magazzino', 2, 2);
INSERT INTO Impiegato(nome_impiegato, cognome, data_nascita, ruolo, residenzaRIF, repartoRIF) 
VALUES ('Sergio', 'Neri', '1980-11-11', 'banconista', 3, 1);

SELECT 
	residenzaID,
	repartoID,
	impiegatoID,
	codice_reparto,
	codice_reparto,
	matricola,
	nome_impiegato, 
	cognome, 
	data_nascita, 
	ruolo, 
	residenzaRIF, 
	repartoRIF
		FROM Residenza
			JOIN Impiegato ON Residenza.residenzaID = Impiegato.residenzaRIF
			JOIN Reparto ON Impiegato.repartoRIF = Reparto.repartoID;
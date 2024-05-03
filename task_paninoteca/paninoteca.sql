Use gestione_paninoteca;

DROP TABLE IF EXISTS Panino;
CREATE TABLE Panino (
	paninoID INT PRIMARY KEY IDENTITY(1,1),
	nome NVARCHAR(50) NOT NULL,
	descrizione NVARCHAR(50) NOT NULL,
	prezzo DECIMAL NOT NULL,
	vegan BIT NULL 
)

INSERT INTO Panino(nome, descrizione, prezzo, vegan) VALUES
	('Il rispettoso', 'Panino vegano', 5.54, 1),
	('Il nocciolino', 'Panino vegano', 3.41, 1);

SELECT * FROM Panino;
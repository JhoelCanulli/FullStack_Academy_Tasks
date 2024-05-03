USE ferramenta;

DROP TABLE IF EXISTS Prodotto;

CREATE TABLE Prodotto(
	prodottoID INT PRIMARY KEY IDENTITY(1,1),
	codice VARCHAR(250) DEFAULT NEWID(),
	nome VARCHAR(250) NOT NULL,
	descrizione VARCHAR(250),
	prezzo DECIMAL(10,2) NOT NULL,
	quantita INT CHECK(quantita>=0),
	categoria VARCHAR(250) NOT NULL CHECK (categoria IN ('Abrasivi','Accessori macchine utensili','Ancoraggi chimici', 'Ancoraggi meccanici', 'Arredo Industriale', 'Attrezzature professionali a batteria', 'Bulloneria e Fasteners', 'Elettroutensili e utensili a batteria', 'Ferramenta generica', 'Vernici')),
	data_creaz DATE,
);
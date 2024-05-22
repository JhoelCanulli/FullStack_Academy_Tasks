USE vendingMachine;

DROP TABLE IF EXISTS Maintenance;
DROP TABLE IF EXISTS Product_Supplier;
DROP TABLE IF EXISTS Supplier;
DROP TABLE IF EXISTS Transaction_;
DROP TABLE IF EXISTS VendingMachineProduct;
DROP TABLE IF EXISTS Product;
DROP TABLE IF EXISTS VendingMachine;

CREATE TABLE VendingMachine(
	vendingMachineID INT PRIMARY KEY IDENTITY(1,1),
	position VARCHAR(250) NOT NULL,
	model VARCHAR(250) NOT NULL
);

CREATE TABLE Product(
	productID INT PRIMARY KEY IDENTITY(1,1),
	nameP VARCHAR(250) NOT NULL,
	priceP VARCHAR(250) NOT NULL,
	quantityPStock VARCHAR(250) NOT NULL DEFAULT 0
);

CREATE TABLE VendingMachineProduct(
	vmProdID INT PRIMARY KEY IDENTITY(1,1),
	vmRIF INT NOT NULL,
	prodRIF INT NOT NULL,
	FOREIGN KEY(vmRIF) REFERENCES VendingMachine(vendingMachineID),
	FOREIGN KEY(prodRIF) REFERENCES Product(productID)
);

CREATE TABLE Transaction_(
	transactionID INT PRIMARY KEY IDENTITY (1,1),
	dateTme DATETIME NOT NULL,
	price FLOAT NOT NULL,
	vmProdRIF INT NOT NULL,
	FOREIGN KEY (vmProdRIF) REFERENCES VendingMachineProduct(vmProdID)
);

CREATE TABLE Supplier(
	supplierID INT PRIMARY KEY IDENTITY(1,1),
	nameS NVARCHAR(50) NOT NULL,
	us_dettails NVARCHAR(50) NOT NULL,
);

CREATE TABLE Product_Supplier(
	ProductRIF INT NOT NULL,
	SupplierRIF INT NOT NULL,
	FOREIGN KEY (ProductRIF) REFERENCES Product(productID),
	FOREIGN KEY (SupplierRIF) REFERENCES Supplier(supplierID)
);

CREATE TABLE Maintenance(
	maintenanceID INT PRIMARY KEY IDENTITY(1,1),
	dateTme DATETIME NOT NULL,
	descriptn NVARCHAR(50),
	VendingMachineRIF INT NOT NULL,
	FOREIGN KEY (VendingMachineRIF) REFERENCES VendingMachine(vendingMachineID)
);

INSERT INTO VendingMachine (position, model) VALUES 
('Entrance Hall', 'VM-123'),
('Cafeteria', 'VM-456'),
('Library', 'VM-789');

INSERT INTO Product (nameP, priceP, quantityPStock) VALUES 
('Chips', '1.50', '100'),
('Soda', '1.00', '200'),
('Candy Bar', '0.75', '150');

INSERT INTO VendingMachineProduct (vmRIF, prodRIF) VALUES 
(1, 1),
(1, 2),
(2, 2),
(2, 3),
(3, 1),
(3, 3);

INSERT INTO Transaction_ (dateTme, price, vmProdRIF) VALUES 
('2024-20-05 10:15:00', 1.50, 1),
('2024-20-05 11:30:00', 1.00, 2),
('2024-21-05 09:45:00', 0.75, 3),
('2024-21-05 12:00:00', 1.50, 4);

INSERT INTO Supplier (nameS, us_dettails) VALUES 
('Supplier A', 'Contact A'),
('Supplier B', 'Contact B'),
('Supplier C', 'Contact C');

INSERT INTO Product_Supplier (ProductRIF, SupplierRIF) VALUES 
(1, 1),
(2, 2),
(3, 3),
(1, 2),
(2, 3);

INSERT INTO Maintenance (dateTme, descriptn, VendingMachineRIF) VALUES 
('2024-22-05 08:00:00', 'Refilled snacks', 1),
('2024-22-05 09:00:00', 'Fixed coin slot', 2),
('2024-22-05 10:00:00', 'Cleaned machine', 3),
('2025-22-05 10:00:00', 'Cleaned machine', 1),
('2026-22-05 10:00:00', 'Cleaned machine', 2),
('2027-22-05 10:00:00', 'Cleaned machine', 3);

/*
	| ----------------------------------------------------------- |
	| ----------------------[ VIEWS ]---------------------------- |
	| ----------------------------------------------------------- |

-----------------------------------------------------------------------------------

 *
 * Creare una vista ProductsByVendingMachine che mostri tutti i prodotti disponibili in ciascun 
 * distributore, includendo l'ID e la posizione del distributore, il nome del prodotto, il prezzo e la
 * quantità disponibile
*/

DROP VIEW IF EXISTS ProductsByVendingMachine;
CREATE VIEW ProductsByVendingMachine AS
	SELECT  vendingMachineID AS 'vending machine ID', 
			position AS 'position vending machine', 
			nameP AS 'name product', 
			priceP AS 'price product', 
			quantityPStock AS 'quantity this product' 
	FROM VendingMachineProduct
	JOIN Product ON VendingMachineProduct.prodRIF = Product.productID
	JOIN VendingMachine ON VendingMachineProduct.vmRIF = VendingMachine.vendingMachineID

SELECT * FROM ProductsByVendingMachine;

-----------------------------------------------------------------------------------

/*
 * Generare una vista RecentTransactions che elenchi le ultime transazioni effettuate, 
 * mostrando l'ID della transazione, la data/ora, il distributore, il prodotto acquistato
 * e l'importo della transazione.
 */

DROP VIEW IF EXISTS RecentTransactions;
CREATE VIEW RecentTransactions AS 
	SELECT  transactionID AS 'transaction ID',
			dateTme AS 'date and time',
			vmRIF AS 'vending machine ID',
			prodRIF AS 'product ID',
			nameP AS 'product name',
			price AS 'price transaction'	
	FROM Transaction_ 
	JOIN VendingMachineProduct ON Transaction_.vmProdRIF = VendingMachineProduct.vmProdID
	JOIN Product ON VendingMachineProduct.prodRIF = Product.productID
	ORDER BY dateTme DESC
	OFFSET 0 ROWS
	FETCH NEXT 3 ROWS ONLY

SELECT * FROM RecentTransactions 

-----------------------------------------------------------------------------------

/*
 * Creare una vista ScheduleMaintenance che mostri tutti i distributori 
 * che hanno una manutenzione programmata, includendo l'ID e la posizione del distributore e la data
 * dell'ultima e della prossima manutenzione
 */

DROP VIEW IF EXISTS ScheduleMaintenance;
CREATE VIEW ScheduleMaintenance AS
	SELECT DISTINCT vendingMachineID AS 'vending machine ID',
					position,
					(SELECT MAX(Maintenance.dateTme)
					FROM Maintenance
					WHERE Maintenance.VendingMachineRIF = VendingMachine.vendingMachineID AND Maintenance.dateTme <= GETDATE()) AS 'date of last maintenance',
					(SELECT MIN(Maintenance.dateTme) 
					FROM Maintenance  
					WHERE Maintenance.VendingMachineRIF = VendingMachine.vendingMachineID AND Maintenance.dateTme > GETDATE()) AS 'date of next maintenance'
	FROM VendingMachine
	JOIN Maintenance ON VendingMachine.vendingMachineID = Maintenance.VendingMachineRIF

SELECT * FROM ScheduleMaintenance;

-----------------------------------------------------------------------------------

/*
	| ----------------------------------------------------------- |
	| ---------------- [ STORED PROCEDURES ] -------------------- |
	| ----------------------------------------------------------- |

-----------------------------------------------------------------------------------
 
 *
 * Implementare una stored procedure RefillProduct che consenta di aggiungere scorte 
 * di un prodotto specifico in un distributore, richiedendo l'ID del distributore, l'ID del prodotto
 * e la quantità da aggiungere
 */
 
DROP PROCEDURE IF EXISTS RefillProduct;
CREATE PROCEDURE RefillProduct
	@vendingMachineID INT,
	@productID INT,
	@quantity INT,
	@name VARCHAR(250),
	@price FLOAT
AS
BEGIN 
	IF EXISTS (SELECT 1 FROM VendingMachineProduct
						JOIN Product ON prodRIF = productID
						WHERE productID = @productID AND vmRIF = @vendingMachineID)
	BEGIN
		UPDATE Product
		SET quantityPStock = quantityPStock + @quantity
	END
	ELSE
	BEGIN
		INSERT INTO Product (nameP, priceP, quantityPStock) VALUES
		(@name, @price, @quantity);
		INSERT INTO VendingMachineProduct(prodRIF, vmRIF) VALUES
		(@productID, @vendingMachineID)
	END
END;

EXEC RefillProduct
	@vendingMachineID = 1,
	@productID = 4,
	@quantity = 5,
	@name = 'snak',
	@price = 1.70;

SELECT * FROM ProductsByVendingMachine;
SELECT * FROM Product;

-----------------------------------------------------------------------------------

/*
 * Sviluppare una stored procedure RecordTransaction che registri una nuova transazione, 
 * includento l'ID del distributore, l'ID del prodotto e l'importo pagato, aggiornando
 * contemporaneamente la quantità disponibile del prodotto
 */

DROP PROCEDURE IF EXISTS RecordTransaction;
CREATE PROCEDURE RecordTransaction
	@vendingMachineID INT,
	@productID INT,
	@price INT
AS
BEGIN TRY
	BEGIN TRANSACTION 
	IF EXISTS (SELECT 1 FROM VendingMachineProduct
						JOIN Product ON prodRIF = productID
						WHERE productID = @productID AND vmRIF = @vendingMachineID)
	BEGIN
		UPDATE Product
		SET quantityPStock = quantityPStock - 1
		
		UPDATE VendingMachineProduct
		SET prodRIF = @productID

		DECLARE @vmProdID INT;
		SELECT @vmProdID = vmProdID
		FROM VendingMachineProduct
		WHERE vmRIF = @vendingMachineID AND prodRIF = @productID;

		INSERT INTO Transaction_(dateTme, price, vmProdRIF) VALUES
		(GETDATE(), @price, @vmProdID);
	END
	ELSE
	BEGIN
		PRINT 'product: ' + CAST(@productID AS VARCHAR(250)) + ' out of stock or not existing';
	END
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
	-- Error message
	DECLARE @Err NVARCHAR(1000)
	SET @Err = ERROR_MESSAGE()
	RAISERROR (@Err,16,1)
END CATCH;

EXEC RecordTransaction
	@vendingMachineID = 1,
	@productID = 4,
	@price = 1.70;

SELECT * FROM RecentTransactions;
SELECT * FROM Product;

-----------------------------------------------------------------------------------

/*
 * Creare una stored procedure ScheduleMaintenance per programmare un intervento di
 * manutenzione su un distributore, specificando l'ID del distributore e la data della manutenzione.
 */

DROP PROCEDURE IF EXISTS ScheduleMaintenanceSP;
CREATE PROCEDURE ScheduleMaintenanceSP
    @vendingMachineID INT,
    @maintenanceDate DATETIME,
    @description NVARCHAR(50) = NULL
AS
BEGIN TRY
    BEGIN TRANSACTION;
    IF EXISTS (SELECT 1 FROM VendingMachine WHERE vendingMachineID = @vendingMachineID)
    BEGIN
        INSERT INTO Maintenance (dateTme, descriptn, VendingMachineRIF) 
        VALUES (@maintenanceDate, @description, @vendingMachineID);
    END
    ELSE
    BEGIN
        RAISERROR ('Vending Machine ID not found.', 16, 1);
    END
    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    DECLARE @ErrMsg NVARCHAR(4000), @ErrSeverity INT;
    SELECT @ErrMsg = ERROR_MESSAGE(), @ErrSeverity = ERROR_SEVERITY();
    RAISERROR (@ErrMsg, @ErrSeverity, 1);
END CATCH;

EXEC ScheduleMaintenanceSP
    @vendingMachineID = 1,
    @maintenanceDate = '2024-22-07 10:00:00',
    @description = 'Routine check-up';

SELECT * FROM ScheduleMaintenance;
SELECT * FROM Maintenance;

-----------------------------------------------------------------------------------

/*
 * Implementare una stored procedure UpdateProductPrice che permetta di aggiornare il prezzo 
 * di un prodotto specifico, richiedendo l'ID del prodotto e il nuovo prezzo
 */

DROP PROCEDURE IF EXISTS UpdateProductPrice;
CREATE PROCEDURE UpdateProductPrice 
	@productID INT,
	@newPrice FLOAT
AS
BEGIN
	IF EXISTS (SELECT 1 FROM Product	
						WHERE productID = @productID)
	BEGIN
		UPDATE Product
		SET priceP = @newPrice
		WHERE productID = @productID
	END
	ELSE
	BEGIN
		PRINT 'product: ' + CAST(@productID AS VARCHAR(250)) + ' out of stock or not existing';
	END
END;

EXEC UpdateProductPrice 
	@productID = 7,
	@newPrice = 1.30;

EXEC UpdateProductPrice 
	@productID = 2,
	@newPrice = 1.30;

SELECT * FROM Product;
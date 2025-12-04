-- База PmDb: простая схема для складов и партий

CREATE TABLE Warehouses (
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL
);

CREATE TABLE Parts (
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    IsBatchTracked BIT NOT NULL DEFAULT 0
);

CREATE TABLE PartBatches (
    Id INT IDENTITY PRIMARY KEY,
    PartId INT NOT NULL,
    BatchNumber NVARCHAR(50) NOT NULL,
    CONSTRAINT FK_PartBatches_Part FOREIGN KEY (PartId) REFERENCES Parts(Id)
);

CREATE TABLE InventoryTransactions (
    Id INT IDENTITY PRIMARY KEY,
    PartId INT NOT NULL,
    WarehouseId INT NOT NULL,
    BatchId INT NULL,
    TranDate DATE NOT NULL,
    Quantity DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_IT_Part FOREIGN KEY (PartId) REFERENCES Parts(Id),
    CONSTRAINT FK_IT_Warehouse FOREIGN KEY (WarehouseId) REFERENCES Warehouses(Id),
    CONSTRAINT FK_IT_Batch FOREIGN KEY (BatchId) REFERENCES PartBatches(Id)
);

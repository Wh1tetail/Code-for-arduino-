-- Basic schema for InventoryWin sample (PmDb database, SQL Server)

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

CREATE TABLE PurchaseOrders (
    Id INT IDENTITY PRIMARY KEY,
    WarehouseId INT NOT NULL,
    DocDate DATE NOT NULL,
    CONSTRAINT FK_PurchaseOrders_Warehouse FOREIGN KEY (WarehouseId) REFERENCES Warehouses(Id)
);

CREATE TABLE PurchaseOrderLines (
    Id INT IDENTITY PRIMARY KEY,
    PurchaseOrderId INT NOT NULL,
    PartId INT NOT NULL,
    BatchId INT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_POL_Order FOREIGN KEY (PurchaseOrderId) REFERENCES PurchaseOrders(Id),
    CONSTRAINT FK_POL_Part FOREIGN KEY (PartId) REFERENCES Parts(Id),
    CONSTRAINT FK_POL_Batch FOREIGN KEY (BatchId) REFERENCES PartBatches(Id)
);

CREATE TABLE WarehouseTransfers (
    Id INT IDENTITY PRIMARY KEY,
    SourceWarehouseId INT NOT NULL,
    DestinationWarehouseId INT NOT NULL,
    DocDate DATE NOT NULL,
    CONSTRAINT FK_WT_Source FOREIGN KEY (SourceWarehouseId) REFERENCES Warehouses(Id),
    CONSTRAINT FK_WT_Dest FOREIGN KEY (DestinationWarehouseId) REFERENCES Warehouses(Id)
);

CREATE TABLE WarehouseTransferLines (
    Id INT IDENTITY PRIMARY KEY,
    WarehouseTransferId INT NOT NULL,
    PartId INT NOT NULL,
    BatchId INT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_WTL_Transfer FOREIGN KEY (WarehouseTransferId) REFERENCES WarehouseTransfers(Id),
    CONSTRAINT FK_WTL_Part FOREIGN KEY (PartId) REFERENCES Parts(Id),
    CONSTRAINT FK_WTL_Batch FOREIGN KEY (BatchId) REFERENCES PartBatches(Id)
);

CREATE TABLE InventoryTransactions (
    Id INT IDENTITY PRIMARY KEY,
    PartId INT NOT NULL,
    WarehouseId INT NOT NULL,
    BatchId INT NULL,
    TranDate DATE NOT NULL,
    Quantity DECIMAL(18,2) NOT NULL,
    SourceType NVARCHAR(30) NOT NULL,
    SourceId INT NOT NULL,
    CONSTRAINT FK_IT_Part FOREIGN KEY (PartId) REFERENCES Parts(Id),
    CONSTRAINT FK_IT_Warehouse FOREIGN KEY (WarehouseId) REFERENCES Warehouses(Id),
    CONSTRAINT FK_IT_Batch FOREIGN KEY (BatchId) REFERENCES PartBatches(Id)
);

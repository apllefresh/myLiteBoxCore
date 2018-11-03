CREATE TABLE InventoryHead
(
    Id SERIAL PRIMARY KEY,
    CreatedOn DATE,
    CreatedBy INTEGER,
    Number SMALLINT,
	InventoryResultId INTEGER,
	FOREIGN KEY (InventoryResultId) REFERENCES InventoryDate (Id)
)
CREATE TABLE InventoryHead
(
    Id SERIAL PRIMARY KEY,
    CreatedOn DATE,
    CreatedBy INTEGER,
    Number SMALLINT,
	InventoryDateId INTEGER,
	FOREIGN KEY (InventoryDateId) REFERENCES InventoryDate (Id)
)
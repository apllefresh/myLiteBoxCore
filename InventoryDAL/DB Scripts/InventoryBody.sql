CREATE TABLE InventoryBody
(
    Id SERIAL PRIMARY KEY,
	RowNumber SMALLINT,
    GoodId INTEGER,
    Count DECIMAL,
	InventoryHeadId INTEGER,
	FOREIGN KEY (InventoryHeadId) REFERENCES InventoryHead (Id),
	FOREIGN KEY (GoodId) REFERENCES Good (Id)
)

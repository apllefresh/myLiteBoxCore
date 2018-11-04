CREATE TABLE InventoryBody
(
    Id SERIAL PRIMARY KEY,
	RowNumber SMALLINT,
    GoodId INTEGER,
    Count DECIMAL,
	InventoryBodyId INTEGER,
	FOREIGN KEY (InventoryBodyId) REFERENCES InventoryBody (Id),
	FOREIGN KEY (GoodId) REFERENCES Good (Id)
)

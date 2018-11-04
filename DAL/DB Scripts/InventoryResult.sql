CREATE TABLE InventoryResult
(
    Id SERIAL PRIMARY KEY,
	CountFact DECIMAL,
    SumFact MONEY,
    CountReal DECIMAL,
    SumReal MONEY,
    CountDiff DECIMAL,
    SumDiff MONEY,
 	GoodGroupId INTEGER,
	DepartmentId INTEGER,
	InventoryDateId INTEGER,
	FOREIGN KEY (GoodGroupId) REFERENCES GoodGroup (Id),
	FOREIGN KEY (DepartmentId) REFERENCES Department (Id),
	FOREIGN KEY (InventoryDateId) REFERENCES InventoryDate (Id)
)

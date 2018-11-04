CREATE TABLE Good
(
    Id SERIAL PRIMARY KEY,
	Ean VARCHAR(13),
	Name VARCHAR(50),
	Price MONEY,
    GoodGroupId INTEGER,
	DepartmentId INTEGER,
	FOREIGN KEY (GoodGroupId) REFERENCES GoodGroup (Id),
	FOREIGN KEY (DepartmentId) REFERENCES Department (Id)
)
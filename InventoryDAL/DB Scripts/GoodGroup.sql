CREATE TABLE GoodGroup
(
    Id SERIAL PRIMARY KEY,
	Name VARCHAR(50),
	DepartmentId INTEGER,
	FOREIGN KEY (DepartmentId) REFERENCES Department (Id)
)
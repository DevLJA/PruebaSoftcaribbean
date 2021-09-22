CREATE TABLE Pacientes
(
nmid INTEGER NOT NULL IDENTITY(1,1),
nmid_persona INTEGER NOT NULL,
nmid_medicotra INTEGER NOT NULL,
dseps VARCHAR(50) ,
dsarl VARCHAR(50) ,
feregistro DATETIME,
febaja DATETIME,
cdusuario VARCHAR(150) ,
dscondicion TEXT,
CONSTRAINT PK_Pacientes PRIMARY KEY (nmid),
CONSTRAINT FK01_Pacientes_Personas FOREIGN KEY (nmid_persona) REFERENCES Personas(nmid),
CONSTRAINT FK02_Pacientes_Personas FOREIGN KEY (nmid_medicotra) REFERENCES Personas(nmid),
)
CREATE TABLE Etats(
	Id BIGINT NOT NULL IDENTITY,
	Statut VARCHAR(20),
	PRIMARY KEY(id)
); 

CREATE TABLE RolesUtilisateurs(
	Nom VARCHAR(50) NOT NULL,
	DescriptionRole VARCHAR(500)
	PRIMARY KEY (nom)
);

CREATE TABLE Produits(
	Id BIGINT IDENTITY,
	QRCode VARCHAR(900) NOT NULL,
	Nom VARCHAR(100),
	Description VARCHAR(500),
	PRIMARY KEY(Id)
);

CREATE TABLE Posseder(
	ProductId BIGINT ,
	IdEtat BIGINT,
	DateAquisition DATE NOT NULL ,
	FOREIGN KEY (ProductId) REFERENCES Produits(Id),
	FOREIGN KEY (IdEtat) REFERENCES Etats(Id),
	PRIMARY KEY (DateAquisition)
);

CREATE TABLE Utilisateurs(
	Id BIGINT NOT NULL IDENTITY,
	Email VARCHAR(100),
	MotDePasse VARCHAR(30),
	Telephone VARCHAR (20),
	PRIMARY KEY (Id)
);

CREATE TABLE Endosser(
	IdUtilisateur BIGINT IDENTITY,
	NomRole VARCHAR(50),
	NoRole VARCHAR(50),
	FOREIGN KEY (NomRole) REFERENCES RolesUtilisateurs(Nom),
	FOREIGN KEY (IdUtilisateur) REFERENCES Utilisateurs(Id),
	PRIMARY KEY (NomRole,IdUtilisateur)
);

CREATE TABLE SousTraitants(
	Id BIGINT NOT NULL IDENTITY,
	Nom VARCHAR (100),
	PRIMARY KEY (Id)
);

CREATE TABLE Employer(
	IdSousTraitant BIGINT,
	IdUtilisateur BIGINT,
	FOREIGN KEY (IdSousTraitant) REFERENCES SousTraitants (Id),
	FOREIGN KEY (IdUtilisateur) REFERENCES Utilisateurs (Id),
	PRIMARY KEY (IdUtilisateur,IdSousTraitant)
);

CREATE TABLE Process(
	Id BIGINT NOT NULL IDENTITY,
	Nom VARCHAR (100),
	DescriptionProcess VARCHAR (1000),
	PRIMARY KEY (Id)
);

CREATE TABLE Organisations(
	Id BIGINT NOT NULL IDENTITY,
	Nom VARCHAR(100),
	Email VARCHAR (100),
	Telephone VARCHAR (20),
	PRIMARY KEY (Id)
);

CREATE TABLE Inclure(
	IdSousTraitant BIGINT,
	IdOrganisation BIGINT,
	FOREIGN KEY (IdOrganisation) REFERENCES Organisations (Id),
	FOREIGN KEY (IdSousTraitant) REFERENCES SousTraitants (Id),
	PRIMARY KEY (IdOrganisation,IdSousTraitant)
);

CREATE TABLE Etapes(
	Id BIGINT NOT NULL IDENTITY,
	Nom VARCHAR (100),
	DescriptionEtape VARCHAR (1000),
	Position INTEGER,
	IdSousTraitant BIGINT,
	IdProcess BIGINT,
	FOREIGN KEY (IdSousTraitant) REFERENCES SousTraitants (Id),
	FOREIGN KEY (IdProcess) REFERENCES Process (Id),
	PRIMARY KEY(Id)
);

CREATE TABLE Traitements(
	Id BIGINT NOT NULL IDENTITY,
	Nom VARCHAR (100),
	DescriptionTraitement VARCHAR (1000),
	Position INTEGER,
	IdEtape BIGINT,
	IdEtatSortant BIGINT REFERENCES Etats(Id)
	FOREIGN KEY (IdEtape) REFERENCES Etapes (Id),
	FOREIGN KEY (IdEtatSortant) REFERENCES Etats (Id),
	PRIMARY KEY (Id)
);

CREATE TABLE Scanner(
	DateValidation DATE NOT NULL,
	IdTraitement BIGINT,
	IdUtilisateur BIGINT,
	FOREIGN KEY (IdTraitement) REFERENCES Traitements(Id),
	FOREIGN KEY (IdUtilisateur) REFERENCES Utilisateurs(Id),
	PRIMARY KEY  (IdTraitement,IdUtilisateur)
);

CREATE TABLE Adresses(
	Numero VARCHAR(5),
	Rue VARCHAR(163),
	CodePostal VARCHAR(20),
	Ville  VARCHAR(163),
	Pays VARCHAR(163),
	IdUtilisateur BIGINT REFERENCES Utilisateurs(Id),
	IdSoustraitant BIGINT REFERENCES SousTraitants(Id),
	IdOrganisation BIGINT REFERENCES Organisations(Id)	
	PRIMARY KEY(Numero,Rue,CodePostal,Ville,Pays)
);








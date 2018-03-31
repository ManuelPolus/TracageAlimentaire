CREATE TABLE Etat(
	Id BIGINT NOT NULL,
	Statut VARCHAR(20),
	PRIMARY KEY(id)
); 

CREATE TABLE RoleUtilisateur(
	Nom VARCHAR(50) NOT NULL,
	DescriptionRole VARCHAR(500)
	PRIMARY KEY (nom)
);

CREATE TABLE Produit(
	QRCode VARCHAR(900) NOT NULL,
	Nom VARCHAR(100),
	Etat VARCHAR(100),
	Id BIGINT,
	PRIMARY KEY(QRCode)
);

CREATE TABLE Posseder(
	ProductQR VARCHAR(900),
	IdEtat BIGINT,
	DateAquisition DATE NOT NULL,
	FOREIGN KEY (ProductQR) REFERENCES Produit(QRCode),
	FOREIGN KEY (IdEtat) REFERENCES Etat(Id),
	PRIMARY KEY (DateAquisition)
);

CREATE TABLE Utilisateur(
	Id BIGINT NOT NULL,
	Email VARCHAR(100),
	MotDePasse VARCHAR(30),
	Telephone VARCHAR (20),
	PRIMARY KEY (Id)
);

CREATE TABLE Endosser(
	IdUtilisateur BIGINT,
	NomRole VARCHAR(50),
	NoRole VARCHAR(50),
	FOREIGN KEY (NomRole) REFERENCES RoleUtilisateur(Nom),
	FOREIGN KEY (IdUtilisateur) REFERENCES Utilisateur(Id),
	PRIMARY KEY (NomRole,IdUtilisateur)
);

CREATE TABLE SousTraitant(
	Id BIGINT NOT NULL,
	Nom VARCHAR (100),
	PRIMARY KEY (Id)
);

CREATE TABLE Employer(
	IdSousTraitant BIGINT,
	IdUtilisateur BIGINT,
	FOREIGN KEY (IdSousTraitant) REFERENCES SousTraitant (Id),
	FOREIGN KEY (IdUtilisateur) REFERENCES Utilisateur (Id),
	PRIMARY KEY (IdUtilisateur,IdSousTraitant)
);

CREATE TABLE Process(
	Id BIGINT NOT NULL,
	Nom VARCHAR (100),
	DescriptionProcess VARCHAR (1000),
	PRIMARY KEY (Id)
);

CREATE TABLE Organisation(
	Id BIGINT NOT NULL,
	Nom VARCHAR(100),
	Email VARCHAR (100),
	Telephone VARCHAR (20),
	PRIMARY KEY (Id)
);

CREATE TABLE Inclure(
	IdSousTraitant BIGINT,
	IdOrganisation BIGINT,
	FOREIGN KEY (IdOrganisation) REFERENCES Organisation (Id),
	FOREIGN KEY (IdSousTraitant) REFERENCES SousTraitant (Id),
	PRIMARY KEY (IdOrganisation,IdSousTraitant)
);

CREATE TABLE Etape(
	Id BIGINT NOT NULL,
	Nom VARCHAR (100),
	DescriptionEtape VARCHAR (1000),
	Position INTEGER,
	IdSousTraitant BIGINT,
	IdProcess BIGINT,
	FOREIGN KEY (IdSousTraitant) REFERENCES SousTraitant (Id),
	FOREIGN KEY (IdProcess) REFERENCES Process (Id),
	PRIMARY KEY(Id)
);

CREATE TABLE Traitement(
	Id BIGINT NOT NULL,
	Nom VARCHAR (100),
	DescriptionEtape VARCHAR (1000),
	Position INTEGER,
	IdEtape BIGINT,
	IdEtatSortant BIGINT,
	FOREIGN KEY (IdEtape) REFERENCES Etape (Id),
	FOREIGN KEY (IdEtatSortant) REFERENCES Etat (Id),
	PRIMARY KEY (Id)
);

CREATE TABLE Scanner(
	DateValidation DATE NOT NULL,
	IdTraitement BIGINT,
	IdUtilisateur BIGINT,
	FOREIGN KEY (IdTraitement) REFERENCES Traitement(Id),
	FOREIGN KEY (IdUtilisateur) REFERENCES Utilisateur(Id),
	PRIMARY KEY  (IdTraitement,IdUtilisateur)
);

CREATE TABLE Adresse(
	Numero VARCHAR(5),
	Rue VARCHAR(163),
	CodePostal VARCHAR(20),
	Ville  VARCHAR(163),
	Pays VARCHAR(163),
	IdUtilisateur BIGINT REFERENCES Utilisateur(Id),
	IdSoustraitant BIGINT REFERENCES SousTraitant(Id),
	IdOrganisation BIGINT REFERENCES Organisation(Id)	
	PRIMARY KEY(Numero,Rue,CodePostal,Ville,Pays)
);








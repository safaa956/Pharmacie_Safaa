create database Pharmacie
use Pharmacie
create table Vendeur (
	Id_V int primary key identity,
	Nom_V varchar (50),
	Prenom_V varchar (50),
	Genre_V varchar (50),
	Adress_V varchar (50),
	Tel_V int,
	DateNaissance_V date,
	Password_V varchar(50)
	)
----------------------------------------
create table Client(
	Id_C int primary key identity,
	Nom_C varchar (50),
	--Prenom_C varchar (50),
	Genre_C varchar (50),
	Adress_C varchar (50),
	Tel_C int,
	DateNaissance_C date,
	--CouvertureSocaile_C varchar(50)
	)
	select *from Client
	insert into Client  values('ss','f','fff',2222,'02/02/2002')
-----------------------
create table Fournisseur(
	Id_FO int primary key identity,
	Nom_FO varchar (50),
	Adress_FO varchar (50),
	Tel_FO int,
	JoinDate Date
)
	select * from Fournisseur

------------------------------------------
create table Medicament (
	Id_M int primary key identity,
	Nom_M varchar (50),
	Type_M  varchar (50),
	Qte_M int,
    Prix_M float,
    Id_FO int foreign key references  Fournisseur (Id_FO),
)
-----------------------------------------------
create table Facture (
	Id_F int primary key identity,
	ID_C int foreign key references Client(ID_C),
	Qte_F int,
	Prix_F float,
	Id_M int foreign key references  Medicament (Id_M)
)

	

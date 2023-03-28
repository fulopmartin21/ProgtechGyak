CREATE DATABASE IF NOT EXISTS Autoszalon;
USE Autoszalon;
CREATE TABLE IF NOT EXISTS Markak(ID int auto_increment,Nev varchar(255),primary key(ID));
INSERT INTO Markak(Nev) VALUES ("Suzuki");
INSERT INTO Markak(Nev) VALUES ("Daewoo");
INSERT INTO Markak(Nev) VALUES ("Audi");
INSERT INTO Markak(Nev) VALUES ("Mercedes");
CREATE TABLE IF NOT EXISTS Tipusok(ID int auto_increment,Nev varchar(255),primary key(ID));
INSERT INTO Tipusok(Nev) VALUES ("Sedan");
INSERT INTO Tipusok(Nev) VALUES ("SUV");
INSERT INTO Tipusok(Nev) VALUES ("Hibrid");
CREATE TABLE IF NOT EXISTS Extra(ID int auto_increment,ExtraNev varchar(255),Ar int,primary key(ID));
INSERT INTO Extra(ExtraNev,Ar) VALUES ("Klíma",200000);
INSERT INTO Extra(ExtraNev,Ar) VALUES ("Ülés fűtés",400000);
INSERT INTO Extra(ExtraNev,Ar) VALUES ("Tolatókamera",150000);
INSERT INTO Extra(ExtraNev,Ar) VALUES ("Vadriasztó",50000);
INSERT INTO Extra(ExtraNev,Ar) VALUES ("Holttér figyelő rendszer",1000000);


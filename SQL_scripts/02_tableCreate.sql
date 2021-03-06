USE [SuperheroesDb]

CREATE TABLE Assistant(
Id int IDENTITY(1,1),
Name nvarchar(50) NOT NULL,
PRIMARY KEY (Id)
)

CREATE TABLE Power(
Id int IDENTITY(1,1),
Name nvarchar(50) NOT NULL,
Description nvarchar(max) NOT NULL,
PRIMARY KEY (Id)
)

CREATE TABLE Superhero(
Id int IDENTITY(1,1),
Name nvarchar(50) NOT NULL,
Alias nvarchar(50) NOT NULL,
Origin nvarchar(max) NOT NULL
PRIMARY KEY (Id)
)

GO

USE [SuperheroesDb]

CREATE TABLE SuperheroPowerLinking(
SuperheroId int NOT NULL,
PowerId int NOT NULL
PRIMARY KEY (SuperheroId, PowerID)
)

GO

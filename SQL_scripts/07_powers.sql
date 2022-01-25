USE [SuperheroesDb]

INSERT INTO [dbo].[Power]
           ([Name],[Description])
     VALUES
           ('Fire Breath','Fire comes bursting forth from your mouth'),
		   ('Super Strength','You lift'),
		   ('Super Speed','U fast af'),
		   ('Shapeshift','You change your appearance')

INSERT INTO dbo.SuperheroPowerLinking 
			(PowerId, SuperheroId)
		VALUES
			(1,1),
			(1,2),
			(2,3),
			(2,2)
GO
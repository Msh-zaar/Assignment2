USE [SuperheroesDb]
GO
/****** Object:  Table [dbo].[SuperheroPowerLinking]    Script Date: 23/01/2022 17:00:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SuperheroPowerLinking](
	[PowerId] [int] NOT NULL,
	[SuperheroId] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SuperheroPowerLinking]  WITH CHECK ADD  CONSTRAINT [FK_SuperheroPowerLinking_Power] FOREIGN KEY([PowerId])
REFERENCES [dbo].[Power] ([Id])
GO
ALTER TABLE [dbo].[SuperheroPowerLinking] CHECK CONSTRAINT [FK_SuperheroPowerLinking_Power]
GO
ALTER TABLE [dbo].[SuperheroPowerLinking]  WITH CHECK ADD  CONSTRAINT [FK_SuperheroPowerLinking_Superhero] FOREIGN KEY([SuperheroId])
REFERENCES [dbo].[Superhero] ([Id])
GO
ALTER TABLE [dbo].[SuperheroPowerLinking] CHECK CONSTRAINT [FK_SuperheroPowerLinking_Superhero]
GO

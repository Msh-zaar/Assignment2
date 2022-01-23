USE [master]
GO

/****** Object:  Database [SuperheroesDb]    Script Date: 23/01/2022 16:18:33 ******/
CREATE DATABASE [SuperheroesDb]
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SuperheroesDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
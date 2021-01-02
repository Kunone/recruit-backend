CREATE DATABASE [Recruit-Backend]
GO

USE [Recruit-Backend]
GO

CREATE SCHEMA Customer
Go

CREATE TABLE Customer.Profile
(
    Id uniqueidentifier NOT NULL Default NEWID(),
    FirstName varchar(100) NOT NULL,
    LastName varchar(100) NOT NULL
);
Go

create TABLE Customer.Card
(
    Id uniqueidentifier NOT NULL Default NEWID(),
    UserId uniqueidentifier NOT NULL,
    Name varchar(50) NOT NULL,
    CardNumber varchar(100) NOT NULL,
    CVC varchar(50) NOT NULL,
    ExpiryDate DATE NOT NULL,
    CreatedAt DateTime not null default SYSUTCDATETIME()
);
Go
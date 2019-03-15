USE Gaming;

--made
CREATE TABLE Game(

gameID INT NOT NULL PRIMARY KEY,
gameType varchar(250)
);

--made
CREATE TABLE ConsoleGame(

consoleGameID INT NOT NULL PRIMARY KEY,
title varchar(250),
ESRB varchar(250),
genre varchar(250),
playType varchar(250),
releaseDate DateTime,
price decimal(5,2),
gameID INT FOREIGN KEY REFERENCES Game(gameID),
consoleID varchar(6) FOREIGN KEY REFERENCES Console(consoleID)
);

--made
CREATE TABLE ConsoleGameDevelopers(

consoleGameDeveloperID INT NOT NULL PRIMARY KEY,
stationaryname varchar(250),
price int,
supplier varchar(255),
gameID INT FOREIGN KEY REFERENCES Game(gameID)
);

--made
CREATE TABLE Console(

consoleID  varchar(6) NOT NULL PRIMARY KEY,
consoleName varchar(250),
consoleVersion varchar(250),
predecessor varchar(255),
successor varchar(255),
price decimal(5,2),
info varchar(255),
top3Titles varchar(255),
gameID INT FOREIGN KEY REFERENCES Game(gameID),
companyID INT FOREIGN KEY REFERENCES Company(companyID)
);

--made
CREATE TABLE Company(

companyID INT NOT NULL PRIMARY KEY,
companyName varchar(250),
established DateTime,
classlocation varchar(255),
gameID INT FOREIGN KEY REFERENCES Game(gameID)
);

--made
CREATE TABLE GamertagRegister(

gamertageRegisterID varchar(4) NOT NULL PRIMARY KEY,
firstName varchar(250),
lastName varchar(250),
dob DateTime,
email varchar(255),
confirmEmail varchar (255),
gamertag varchar (255),
companyID INT FOREIGN KEY REFERENCES Company(companyID)
);

--made
CREATE TABLE BoardGames(

boardGameID INT NOT NULL PRIMARY KEY,
title varchar(250),
forAges int,
typeOfGame varchar(255),
noOfPlayers int,
gameID INT FOREIGN KEY REFERENCES Game(gameID)
);

--made
CREATE TABLE DandDProfile(

dAndDProfileID varchar(4) NOT NULL PRIMARY KEY,
characterName varchar(250),
classAndLevel varchar(250),
race varchar(255),
alignment varchar(255),
playerName varchar(255),
gameID INT FOREIGN KEY REFERENCES Game(gameID)
);
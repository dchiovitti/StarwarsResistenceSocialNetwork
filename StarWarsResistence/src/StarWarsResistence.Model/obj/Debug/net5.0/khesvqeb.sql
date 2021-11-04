CREATE DATABASE IF NOT EXISTS `dbo`CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

CREATE DATABASE IF NOT EXISTS `dbo`
START TRANSACTION;

CREATE TABLE `MyEntity` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Col` text NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Rebeldes` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `nome` text NULL,
    `idade` int unsigned NOT NULL,
    `genero` int NOT NULL,
    `statusRebelde` int NOT NULL,
    PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20211003222632_CriandoTabelaDeRebeldes2', '5.0.4');

COMMIT;

START TRANSACTION;

ALTER TABLE Rebeldes RENAME Rebelde;

ALTER TABLE `Rebelde` ADD `nomeBase` text NULL;

CREATE TABLE `Inventario` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `idRebelde` int NOT NULL,
    `Item` text NULL,
    `Pontos` int NOT NULL,
    `Quantidade` int NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Localizacao` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `IdRebelde` int NOT NULL,
    `local` text NOT NULL,
    `Latitude` double NOT NULL,
    `Longitude` double NOT NULL,
    PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20211103221946_CriarTabelainventario', '5.0.4');

COMMIT;


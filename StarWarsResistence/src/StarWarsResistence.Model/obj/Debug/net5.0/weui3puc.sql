
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


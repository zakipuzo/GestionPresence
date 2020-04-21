-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  mar. 21 avr. 2020 à 06:49
-- Version du serveur :  5.7.24
-- Version de PHP :  5.6.40

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `projet_gestionpresencedb`
--

-- --------------------------------------------------------

--
-- Structure de la table `anneeuniversitaires`
--

DROP TABLE IF EXISTS `anneeuniversitaires`;
CREATE TABLE IF NOT EXISTS `anneeuniversitaires` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Annee` int(11) NOT NULL,
  `AnneeCourante` tinyint(1) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `anneeuniversitaires`
--

INSERT INTO `anneeuniversitaires` (`ID`, `Annee`, `AnneeCourante`) VALUES
(1, 2019, 1);

-- --------------------------------------------------------

--
-- Structure de la table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
CREATE TABLE IF NOT EXISTS `aspnetroleclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4,
  `ClaimValue` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
CREATE TABLE IF NOT EXISTS `aspnetroles` (
  `Id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `Name` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `NormalizedName` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `aspnetroles`
--

INSERT INTO `aspnetroles` (`Id`, `Name`, `NormalizedName`, `ConcurrencyStamp`) VALUES
('59282e36-deac-4aab-9c60-61f9e1ff1fb1', 'Etudiant', 'ETUDIANT', '36c1611b-f9a1-428d-b178-decf6db4ac88'),
('78b9bd0f-f150-4752-8d32-5b760e5f0da1', 'Admin', 'ADMIN', 'd61d1183-aa00-46f8-94b0-df3368ee3358'),
('962d840f-af1a-4eec-8127-7969464ac63a', 'Professeur', 'PROFESSEUR', '16a50fd9-2eca-46a7-a56f-184227845ec6');

-- --------------------------------------------------------

--
-- Structure de la table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
CREATE TABLE IF NOT EXISTS `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4,
  `ClaimValue` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
CREATE TABLE IF NOT EXISTS `aspnetuserlogins` (
  `LoginProvider` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `ProviderKey` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `ProviderDisplayName` longtext CHARACTER SET utf8mb4,
  `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
CREATE TABLE IF NOT EXISTS `aspnetuserroles` (
  `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `aspnetuserroles`
--

INSERT INTO `aspnetuserroles` (`UserId`, `RoleId`) VALUES
('010f42bb-5ea2-411c-88bc-144812143b5e', '59282e36-deac-4aab-9c60-61f9e1ff1fb1'),
('02923315-8b33-4dc9-8959-410d8e6c853d', '59282e36-deac-4aab-9c60-61f9e1ff1fb1'),
('15956ce2-6c46-4e3a-8e38-a179cd88fbaa', '59282e36-deac-4aab-9c60-61f9e1ff1fb1'),
('2b7a0751-cf58-49dd-9737-5390f905f5e5', '59282e36-deac-4aab-9c60-61f9e1ff1fb1'),
('2e26baf6-881e-470d-bd81-8a0938802030', '59282e36-deac-4aab-9c60-61f9e1ff1fb1'),
('8f04e4e5-683b-4252-97d9-2d10b0114c9d', '59282e36-deac-4aab-9c60-61f9e1ff1fb1'),
('990ef541-57f8-4dfb-a66f-3ed453f73e82', '59282e36-deac-4aab-9c60-61f9e1ff1fb1'),
('a32804b0-7766-4f98-bae2-362f4594f61c', '59282e36-deac-4aab-9c60-61f9e1ff1fb1'),
('adaf6962-e23d-4c39-b7d1-ae62567d2956', '59282e36-deac-4aab-9c60-61f9e1ff1fb1'),
('d20e12a7-6b07-4f5a-8b3e-9cb45f1a5748', '59282e36-deac-4aab-9c60-61f9e1ff1fb1'),
('e80b7274-0289-4905-90f0-f541b1956b3c', '59282e36-deac-4aab-9c60-61f9e1ff1fb1'),
('eb65f45a-972d-4e81-9835-31b4a41cd1d1', '59282e36-deac-4aab-9c60-61f9e1ff1fb1'),
('ebdc6552-4ee1-4dea-9547-b589e5eeaedb', '59282e36-deac-4aab-9c60-61f9e1ff1fb1'),
('fafbf041-781d-4ab8-96da-cd5eee1aaec3', '59282e36-deac-4aab-9c60-61f9e1ff1fb1'),
('7c36b01d-bae5-4c20-8d28-575f932be27e', '78b9bd0f-f150-4752-8d32-5b760e5f0da1'),
('0489e8a5-854a-4183-9687-07826e2be63c', '962d840f-af1a-4eec-8127-7969464ac63a'),
('17f8f135-883b-48f8-9b49-d1034160532b', '962d840f-af1a-4eec-8127-7969464ac63a'),
('4e7bc17b-72c0-4980-97b0-f4ece53b874c', '962d840f-af1a-4eec-8127-7969464ac63a'),
('b93aea3d-ef34-4885-99fa-8ca20bd1ab4b', '962d840f-af1a-4eec-8127-7969464ac63a');

-- --------------------------------------------------------

--
-- Structure de la table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
CREATE TABLE IF NOT EXISTS `aspnetusers` (
  `Id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `UserName` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `Email` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4,
  `SecurityStamp` longtext CHARACTER SET utf8mb4,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4,
  `PhoneNumber` longtext CHARACTER SET utf8mb4,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `Discriminator` longtext CHARACTER SET utf8mb4 NOT NULL,
  `Nom` longtext CHARACTER SET utf8mb4,
  `Prenom` longtext CHARACTER SET utf8mb4,
  `CodeRFID` varchar(255) CHARACTER SET utf8mb4 DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_AspNetUsers_CodeRFID` (`CodeRFID`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `aspnetusers`
--

INSERT INTO `aspnetusers` (`Id`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`, `Discriminator`, `Nom`, `Prenom`, `CodeRFID`) VALUES
('010f42bb-5ea2-411c-88bc-144812143b5e', 'h@h.h', 'H@H.H', 'h@h.h', 'H@H.H', 1, 'AQAAAAEAACcQAAAAEGg1pyQINYGHfHmHLXpSO27rraaWgJPRcr6AqyWs1kCHB5t6LVle2WCrLf1F55Dcww==', '33CLQPWTPC5YLKNO4AQYTEOVRR55QDBI', '378465df-af9e-4c8e-a64a-5621bffaaf49', NULL, 0, 0, NULL, 1, 0, 'AppUser', 'Hafidi', 'Hafid', 'hhh'),
('02923315-8b33-4dc9-8959-410d8e6c853d', 'b@b.b', 'B@B.B', 'b@b.b', 'B@B.B', 1, 'AQAAAAEAACcQAAAAEPwuMsY4d4wrPaX3BQIYTMx0GkIHiJgEwPrqKQcn4aHBsC1MZoxJGVe2l2nTrFLw9Q==', 'OBCQ7A4YTTY7WXYNT6QA4LN3GOHFOKTW', 'f22c6a82-e27c-4d0e-9147-a60cd118a85b', NULL, 0, 0, NULL, 1, 0, 'AppUser', 'b', 'b', 'bbb'),
('0489e8a5-854a-4183-9687-07826e2be63c', 'm@m.m', 'M@M.M', 'm@m.m', 'M@M.M', 1, 'AQAAAAEAACcQAAAAECt29MPmDftsRZ1S2mq1z2NBsprE2ue/qQLXAmPSLukZPU/j749Cmbx5Oe8brVWXUw==', '2MOYSAYJ574PAFKZN2L7GXSG443F6WGY', 'a8806fb9-f121-4cf7-8b14-08c882a49a30', NULL, 0, 0, NULL, 1, 0, 'AppUser', 'Belatar', 'Mohamed', 'mmm'),
('15956ce2-6c46-4e3a-8e38-a179cd88fbaa', 'c@c.c', 'C@C.C', 'c@c.c', 'C@C.C', 1, 'AQAAAAEAACcQAAAAEDALD591O+hz5Ev2S2BuHLncaYCwgHJYzESzOkLIx+6HKd1Wu97kN4gT4WQjKkGfkw==', 'SOGQEUK32R7UPTPJL2UA3RDZNUXORQEA', '04eeff30-01cb-4a80-b876-7e345d1d8d61', NULL, 0, 0, NULL, 1, 0, 'AppUser', 'c', 'c', 'ccc'),
('17f8f135-883b-48f8-9b49-d1034160532b', 'l@l.l', 'L@L.L', 'l@l.l', 'L@L.L', 1, 'AQAAAAEAACcQAAAAEAD1+l9s5OPKuVIAztlY6anPi3vOqPE6mwYwt7put/54KvrixeaS1/nb8RZkqo4LxA==', 'QFWACU55GRAOXN6RCJ5PWQDDJLHQGVJC', '2b0d6245-e485-4a20-8bf1-4750b1652c4f', NULL, 0, 0, NULL, 1, 0, 'AppUser', 'Lamiae', 'Lamiae', 'lll'),
('2b7a0751-cf58-49dd-9737-5390f905f5e5', 'g@g.g', 'G@G.G', 'g@g.g', 'G@G.G', 1, 'AQAAAAEAACcQAAAAEGnRHOyaefXRzmfdJLaK8K59+PPqXOGiAE6SXH19P+MkUNpQ4mezd7E/NOkRkt9aQg==', 'NURQSH3C5TPQK6M65SUHMRHHEC4JSMC7', 'f74e7467-ef95-4b00-a2a3-c7262db730db', NULL, 0, 0, NULL, 1, 0, 'AppUser', 'g', 'g', 'ggg'),
('2e26baf6-881e-470d-bd81-8a0938802030', 'n@n.n', 'N@N.N', 'n@n.n', 'N@N.N', 1, 'AQAAAAEAACcQAAAAEEp+KuIqjRVJeS/Sino3tDNaGogMBtCVMI97fQEMp65+Kfz8SUMpCe5ICM/+dfn8hA==', 'LC36XMQBG2MM43W7Z4HRIH7JI2AMXXR5', 'd8c4f29e-95d4-4d44-a7e0-45e3ef0d4b87', NULL, 0, 0, NULL, 1, 0, 'AppUser', 'Nabili', 'Nabil', 'nnn'),
('4e7bc17b-72c0-4980-97b0-f4ece53b874c', 'w@w.w', 'W@W.W', 'w@w.w', 'W@W.W', 1, 'AQAAAAEAACcQAAAAEIrOgxS39+qjXfsPOj2TsR/F7M+U12Oez3oUF/KlAK5zfDuPm/u5DEH7riZeS0XXnQ==', 'DZYOZ4ZNRYPYSNMHK7XMEYRL2ZWES5CH', '2c8f4fb9-3304-48dc-83f8-ee1f1635d5d2', NULL, 0, 0, NULL, 1, 0, 'AppUser', 'w', 'w', 'www'),
('7c36b01d-bae5-4c20-8d28-575f932be27e', 'admin@admin.com', 'ADMIN@ADMIN.COM', 'admin@admin.com', 'ADMIN@ADMIN.COM', 1, 'AQAAAAEAACcQAAAAEJvOMOTkpVl1ZRFxC0YWHQT4M6qZpTAHZ60DrhVxA2Sx8KiH4ONFt5V8qt5QC0M3MQ==', 'QPWOSGYORLYQ4RZ45LRQFUZERQHKX6IU', '53d09c01-8e96-490a-b8db-950ecc7426ee', NULL, 0, 0, NULL, 1, 0, 'AppUser', 'Aarab', 'Zakaria', 'nocode'),
('8f04e4e5-683b-4252-97d9-2d10b0114c9d', 'v@v.v', 'V@V.V', 'v@v.v', 'V@V.V', 1, 'AQAAAAEAACcQAAAAEHwuM8rpHR3l7QuS6hCNdNRfR792WJjiRdq1IMuW+fzZnFP5e/SuGIBrGsB6rBw7Aw==', 'LL7BODFCO7BXQHWZYRAVV6367TYCA2GS', '88435e01-d05e-4e15-9f40-49c0dc6417f1', NULL, 0, 0, NULL, 1, 0, 'AppUser', 'v', 'v', 'vvv'),
('990ef541-57f8-4dfb-a66f-3ed453f73e82', 'a@a.a', 'A@A.A', 'a@a.a', 'A@A.A', 1, 'AQAAAAEAACcQAAAAEIOzJMQOxg0K8+Dm3Gv5iUbPzF62DzTcjhAJ2i9XvH7hMniPJXZ8EzlGpcYl0Ey2Zg==', 'PKQ5ORPB5SM4IRJEC7C4TWBCP44VI7AJ', '8f60e484-738c-4572-a597-299911c35478', NULL, 0, 0, NULL, 1, 0, 'AppUser', 'Essordi', 'Abdelbasset', 'aaa'),
('a32804b0-7766-4f98-bae2-362f4594f61c', 'j@j.j', 'J@J.J', 'j@j.j', 'J@J.J', 1, 'AQAAAAEAACcQAAAAEMfvud/6MhYAaA8kVISNzhAv+fOPUxd4Tp+XdNGdg17tbRdkP0oNxrLmO7iylucouA==', 'RNIOJVA7JJIFSCCWRGLSHNJ7KYBYMB54', '4fce40b2-9543-4603-ae50-6828a341bbeb', NULL, 0, 0, NULL, 1, 0, 'AppUser', 'Jouaiti', 'Youssef', 'jjj'),
('adaf6962-e23d-4c39-b7d1-ae62567d2956', 's@s.s', 'S@S.S', 's@s.s', 'S@S.S', 1, 'AQAAAAEAACcQAAAAEF6XAAmKN66vCTnnX1vpcj6ygIYGriM9Ia3S6uLgLdDGSKdnKdjN7H5CqRTazXcenA==', 'UXWDQ3VMDUU5JNV7TVO3UIDQJBRYYXIR', '29480053-d34e-4c35-838d-7ce162c46a18', NULL, 0, 0, NULL, 1, 0, 'AppUser', 'Saidi', 'Said', 'sss'),
('b93aea3d-ef34-4885-99fa-8ca20bd1ab4b', 'y@y.y', 'Y@Y.Y', 'y@y.y', 'Y@Y.Y', 1, 'AQAAAAEAACcQAAAAEJrkBpERmIYsrcEs3SsMOgxnvs5Izs+mNycZvtOcALgbgF661M0Z3Xr35R/mDTj1JA==', 'Z22DZXE5E3VQK6QUB4GBMKECGWWBAWSO', '7a8ed358-2711-4acc-b206-8003a5f3614e', NULL, 0, 0, NULL, 1, 0, 'AppUser', 'Tiamaz', 'Younes', 'yyy'),
('d20e12a7-6b07-4f5a-8b3e-9cb45f1a5748', 'k@k.k', 'K@K.K', 'k@k.k', 'K@K.K', 1, 'AQAAAAEAACcQAAAAEBwDqc25XILX1CJ70fMYtpgO1XlCj6PkE+mQ7q7ZcmV8cU3iRbt8Fsw4IiCOIWpnMw==', 'BVTPZM5TJXJX5H6HMKS764POSMDQZOY6', '7fb1f856-1c95-4697-8f22-8cbb67e24cf2', NULL, 0, 0, NULL, 1, 0, 'AppUser', 'Karimi', 'Karim', 'kkk'),
('e80b7274-0289-4905-90f0-f541b1956b3c', 'x@x.x', 'X@X.X', 'x@x.x', 'X@X.X', 1, 'AQAAAAEAACcQAAAAEBZwVsY4FEKeh9OldILx14wj91WTRhb3aeo9ppLlH8/Ki/PXHxs7PR4VeoINFGLOeQ==', 'JHM7WCAW5SAORHN6WGE7L3VEXMJZLUOV', 'b40e9583-5302-46a1-a637-522eb7b4fd71', NULL, 0, 0, NULL, 1, 0, 'AppUser', 'x', 'x', 'xxx'),
('eb65f45a-972d-4e81-9835-31b4a41cd1d1', 'o@o.o', 'O@O.O', 'o@o.o', 'O@O.O', 1, 'AQAAAAEAACcQAAAAEC06U/cyNG62538zFRcLZ7X8UuhNYrzJ6EFMWKqc04rq2z+zaYiHHdluRaS/CyfB0Q==', 'NHKPTJ7WDJEDTO4XBCNKVLIEWW3ULOL2', 'cea793e5-0d7c-4ecb-94a9-90ebae6022bd', NULL, 0, 0, NULL, 1, 0, 'AppUser', 'Idrissi', 'Oussama', 'ooo'),
('ebdc6552-4ee1-4dea-9547-b589e5eeaedb', 't@t.t', 'T@T.T', 't@t.t', 'T@T.T', 1, 'AQAAAAEAACcQAAAAEBa/G3rWFrEdmnLU76lnPnd1ONpo7KE5t/6ZYFGTdzRbAALIybxgwy6NhTSuj+SbkQ==', 'OFPHH27ZNGINHSSELNS65AOB37M632OY', 'd33b09ca-db12-4bac-a4cf-96ad14c6b604', NULL, 0, 0, NULL, 1, 0, 'AppUser', 'Tarik', 'Tarik', 'ttt'),
('fafbf041-781d-4ab8-96da-cd5eee1aaec3', 'r@r.r', 'R@R.R', 'r@r.r', 'R@R.R', 1, 'AQAAAAEAACcQAAAAEB4FXOXtzlpYO0CBwOspD3dhTlydX3eskh5MhQ1zqTi2VJQ3zymKpykNR2nYXwxSDg==', '4F6VJJ4DVMM7ELQU2VOPBOOVJXUJ6ZHL', '48748eb4-5d35-452b-a6cc-ec494ada20d7', NULL, 0, 0, NULL, 1, 0, 'AppUser', 'Rachidi', 'Rachid', 'rrr');

-- --------------------------------------------------------

--
-- Structure de la table `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
CREATE TABLE IF NOT EXISTS `aspnetusertokens` (
  `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `LoginProvider` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `Value` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `ecolesites`
--

DROP TABLE IF EXISTS `ecolesites`;
CREATE TABLE IF NOT EXISTS `ecolesites` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Libelle` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `IX_EcoleSites_Libelle` (`Libelle`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `ecolesites`
--

INSERT INTO `ecolesites` (`ID`, `Libelle`) VALUES
(1, 'EMSI 1'),
(2, 'EMSI 2'),
(3, 'EMSI 3'),
(4, 'EMSI AGDAL');

-- --------------------------------------------------------

--
-- Structure de la table `filierematieres`
--

DROP TABLE IF EXISTS `filierematieres`;
CREATE TABLE IF NOT EXISTS `filierematieres` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `FiliereId` int(11) NOT NULL,
  `MatiereId` int(11) NOT NULL,
  `ProfId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `IX_FiliereMatieres_FiliereId_MatiereId` (`FiliereId`,`MatiereId`),
  KEY `IX_FiliereMatieres_MatiereId` (`MatiereId`),
  KEY `IX_FiliereMatieres_ProfId` (`ProfId`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `filierematieres`
--

INSERT INTO `filierematieres` (`ID`, `FiliereId`, `MatiereId`, `ProfId`) VALUES
(1, 1, 1, 'b93aea3d-ef34-4885-99fa-8ca20bd1ab4b'),
(2, 1, 3, '0489e8a5-854a-4183-9687-07826e2be63c'),
(4, 2, 4, '17f8f135-883b-48f8-9b49-d1034160532b'),
(5, 5, 1, 'b93aea3d-ef34-4885-99fa-8ca20bd1ab4b');

-- --------------------------------------------------------

--
-- Structure de la table `filieres`
--

DROP TABLE IF EXISTS `filieres`;
CREATE TABLE IF NOT EXISTS `filieres` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Libelle` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `NiveauId` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `IX_Filieres_Libelle_NiveauId` (`Libelle`,`NiveauId`),
  KEY `IX_Filieres_NiveauId` (`NiveauId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `filieres`
--

INSERT INTO `filieres` (`ID`, `Libelle`, `NiveauId`) VALUES
(2, 'IFA', 8),
(5, 'IGC', 9),
(1, 'IIR', 8);

-- --------------------------------------------------------

--
-- Structure de la table `groupes`
--

DROP TABLE IF EXISTS `groupes`;
CREATE TABLE IF NOT EXISTS `groupes` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Numero` int(11) NOT NULL,
  `FiliereId` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `IX_Groupes_FiliereId_Numero` (`FiliereId`,`Numero`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `groupes`
--

INSERT INTO `groupes` (`ID`, `Numero`, `FiliereId`) VALUES
(1, 1, 1),
(3, 2, 1),
(5, 1, 2),
(8, 1, 5);

-- --------------------------------------------------------

--
-- Structure de la table `inscriptions`
--

DROP TABLE IF EXISTS `inscriptions`;
CREATE TABLE IF NOT EXISTS `inscriptions` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `GroupeId` int(11) NOT NULL,
  `EtudiantId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `AnneeUniversitaireId` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `IX_Inscriptions_AnneeUniversitaireId_EtudiantId` (`AnneeUniversitaireId`,`EtudiantId`),
  KEY `IX_Inscriptions_EtudiantId` (`EtudiantId`),
  KEY `IX_Inscriptions_GroupeId` (`GroupeId`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `inscriptions`
--

INSERT INTO `inscriptions` (`ID`, `GroupeId`, `EtudiantId`, `AnneeUniversitaireId`) VALUES
(1, 1, '990ef541-57f8-4dfb-a66f-3ed453f73e82', 1),
(2, 1, 'a32804b0-7766-4f98-bae2-362f4594f61c', 1),
(3, 1, 'd20e12a7-6b07-4f5a-8b3e-9cb45f1a5748', 1),
(4, 1, 'eb65f45a-972d-4e81-9835-31b4a41cd1d1', 1),
(5, 3, '010f42bb-5ea2-411c-88bc-144812143b5e', 1),
(6, 3, '2e26baf6-881e-470d-bd81-8a0938802030', 1),
(7, 3, 'ebdc6552-4ee1-4dea-9547-b589e5eeaedb', 1),
(8, 3, 'fafbf041-781d-4ab8-96da-cd5eee1aaec3', 1),
(10, 8, '15956ce2-6c46-4e3a-8e38-a179cd88fbaa', 1),
(11, 8, '8f04e4e5-683b-4252-97d9-2d10b0114c9d', 1),
(12, 8, 'e80b7274-0289-4905-90f0-f541b1956b3c', 1),
(13, 8, 'adaf6962-e23d-4c39-b7d1-ae62567d2956', 1),
(17, 5, '02923315-8b33-4dc9-8959-410d8e6c853d', 1),
(18, 5, '2b7a0751-cf58-49dd-9737-5390f905f5e5', 1);

-- --------------------------------------------------------

--
-- Structure de la table `matieres`
--

DROP TABLE IF EXISTS `matieres`;
CREATE TABLE IF NOT EXISTS `matieres` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Libelle` longtext CHARACTER SET utf8mb4 NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `matieres`
--

INSERT INTO `matieres` (`ID`, `Libelle`) VALUES
(1, 'ASP'),
(3, 'Android'),
(4, 'Francais');

-- --------------------------------------------------------

--
-- Structure de la table `niveaux`
--

DROP TABLE IF EXISTS `niveaux`;
CREATE TABLE IF NOT EXISTS `niveaux` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Numero` int(11) NOT NULL,
  `AnneeUniversitaireId` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `IX_Niveaux_Numero_AnneeUniversitaireId` (`Numero`,`AnneeUniversitaireId`),
  KEY `IX_Niveaux_AnneeUniversitaireId` (`AnneeUniversitaireId`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `niveaux`
--

INSERT INTO `niveaux` (`ID`, `Numero`, `AnneeUniversitaireId`) VALUES
(9, 3, 1),
(8, 4, 1);

-- --------------------------------------------------------

--
-- Structure de la table `presences`
--

DROP TABLE IF EXISTS `presences`;
CREATE TABLE IF NOT EXISTS `presences` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `InscriptionId` int(11) NOT NULL,
  `SeanceId` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `IX_Presences_InscriptionId_SeanceId` (`InscriptionId`,`SeanceId`),
  KEY `IX_Presences_SeanceId` (`SeanceId`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `presences`
--

INSERT INTO `presences` (`ID`, `InscriptionId`, `SeanceId`) VALUES
(1, 1, 1),
(11, 1, 2),
(3, 2, 1),
(2, 4, 1),
(7, 10, 1),
(6, 13, 1);

-- --------------------------------------------------------

--
-- Structure de la table `salles`
--

DROP TABLE IF EXISTS `salles`;
CREATE TABLE IF NOT EXISTS `salles` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Libelle` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `CodePointeur` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `EcoleSiteId` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `IX_Salles_CodePointeur` (`CodePointeur`),
  UNIQUE KEY `IX_Salles_EcoleSiteId_Libelle` (`EcoleSiteId`,`Libelle`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `salles`
--

INSERT INTO `salles` (`ID`, `Libelle`, `CodePointeur`, `EcoleSiteId`) VALUES
(1, 'Amphie 1', 'A1', 3),
(2, 'Amphie 2', 'A2', 3),
(3, 'CC1', 'C1', 1),
(4, 'CC2', 'C2', 1),
(5, 'CC3', 'C3', 1);

-- --------------------------------------------------------

--
-- Structure de la table `seances`
--

DROP TABLE IF EXISTS `seances`;
CREATE TABLE IF NOT EXISTS `seances` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `DateSeance` datetime(6) NOT NULL,
  `durree` longtext CHARACTER SET utf8mb4 NOT NULL,
  `GroupeId` int(11) NOT NULL,
  `SalleId` int(11) NOT NULL,
  `FiliereMatiereId` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `IX_Seances_FiliereMatiereId` (`FiliereMatiereId`),
  KEY `IX_Seances_GroupeId` (`GroupeId`),
  KEY `IX_Seances_SalleId` (`SalleId`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `seances`
--

INSERT INTO `seances` (`ID`, `DateSeance`, `durree`, `GroupeId`, `SalleId`, `FiliereMatiereId`) VALUES
(1, '2020-04-21 06:00:00.000000', '60', 1, 3, 1),
(2, '2020-04-21 06:00:00.000000', '90', 1, 4, 2),
(7, '2020-04-21 06:00:00.000000', '60', 8, 3, 5),
(9, '2020-04-21 06:40:00.000000', '120', 5, 2, 4);

-- --------------------------------------------------------

--
-- Structure de la table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20200421052557_createdb', '3.1.3');

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `filierematieres`
--
ALTER TABLE `filierematieres`
  ADD CONSTRAINT `FK_FiliereMatieres_AspNetUsers_ProfId` FOREIGN KEY (`ProfId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_FiliereMatieres_Filieres_FiliereId` FOREIGN KEY (`FiliereId`) REFERENCES `filieres` (`ID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_FiliereMatieres_Matieres_MatiereId` FOREIGN KEY (`MatiereId`) REFERENCES `matieres` (`ID`) ON DELETE CASCADE;

--
-- Contraintes pour la table `filieres`
--
ALTER TABLE `filieres`
  ADD CONSTRAINT `FK_Filieres_Niveaux_NiveauId` FOREIGN KEY (`NiveauId`) REFERENCES `niveaux` (`ID`) ON DELETE CASCADE;

--
-- Contraintes pour la table `groupes`
--
ALTER TABLE `groupes`
  ADD CONSTRAINT `FK_Groupes_Filieres_FiliereId` FOREIGN KEY (`FiliereId`) REFERENCES `filieres` (`ID`) ON DELETE CASCADE;

--
-- Contraintes pour la table `inscriptions`
--
ALTER TABLE `inscriptions`
  ADD CONSTRAINT `FK_Inscriptions_AnneeUniversitaires_AnneeUniversitaireId` FOREIGN KEY (`AnneeUniversitaireId`) REFERENCES `anneeuniversitaires` (`ID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Inscriptions_AspNetUsers_EtudiantId` FOREIGN KEY (`EtudiantId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Inscriptions_Groupes_GroupeId` FOREIGN KEY (`GroupeId`) REFERENCES `groupes` (`ID`) ON DELETE CASCADE;

--
-- Contraintes pour la table `niveaux`
--
ALTER TABLE `niveaux`
  ADD CONSTRAINT `FK_Niveaux_AnneeUniversitaires_AnneeUniversitaireId` FOREIGN KEY (`AnneeUniversitaireId`) REFERENCES `anneeuniversitaires` (`ID`) ON DELETE CASCADE;

--
-- Contraintes pour la table `presences`
--
ALTER TABLE `presences`
  ADD CONSTRAINT `FK_Presences_Inscriptions_InscriptionId` FOREIGN KEY (`InscriptionId`) REFERENCES `inscriptions` (`ID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Presences_Seances_SeanceId` FOREIGN KEY (`SeanceId`) REFERENCES `seances` (`ID`) ON DELETE CASCADE;

--
-- Contraintes pour la table `salles`
--
ALTER TABLE `salles`
  ADD CONSTRAINT `FK_Salles_EcoleSites_EcoleSiteId` FOREIGN KEY (`EcoleSiteId`) REFERENCES `ecolesites` (`ID`) ON DELETE CASCADE;

--
-- Contraintes pour la table `seances`
--
ALTER TABLE `seances`
  ADD CONSTRAINT `FK_Seances_FiliereMatieres_FiliereMatiereId` FOREIGN KEY (`FiliereMatiereId`) REFERENCES `filierematieres` (`ID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Seances_Groupes_GroupeId` FOREIGN KEY (`GroupeId`) REFERENCES `groupes` (`ID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Seances_Salles_SalleId` FOREIGN KEY (`SalleId`) REFERENCES `salles` (`ID`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

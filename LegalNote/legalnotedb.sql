-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: localhost    Database: legalnote2
-- ------------------------------------------------------
-- Server version	8.0.26

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `anagrafica`
--

DROP TABLE IF EXISTS `anagrafica`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `anagrafica` (
  `id` int NOT NULL AUTO_INCREMENT,
  `ragionesociale` varchar(255) DEFAULT NULL,
  `nome` varchar(255) DEFAULT NULL,
  `cognome` varchar(255) DEFAULT NULL,
  `indirizzo` varchar(255) DEFAULT NULL,
  `Cap` varchar(20) DEFAULT NULL,
  `citta` varchar(100) DEFAULT NULL,
  `provincia` varchar(6) DEFAULT NULL,
  `Telefono` varchar(50) DEFAULT NULL,
  `Cellulare` varchar(50) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `idUtente` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=950 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `anagrafica`
--

LOCK TABLES `anagrafica` WRITE;
/*!40000 ALTER TABLE `anagrafica` DISABLE KEYS */;
INSERT INTO `anagrafica` VALUES (2,'Cliente prova di Milano che sta a Bergamo','Gino','Latino','P.zza Rossa',NULL,NULL,NULL,NULL,NULL,NULL,1),(3,'Silvio Berlusconi','Silvio','Nazionale','Villa Certosa','37100','Milano','MI','3660444000','2360030030','silvio@nazionale.it',1),(4,'Wanna Marchi',NULL,NULL,'Via vai','37500','Modena','MO','221','3662354789','wanna@marchi.it',1),(5,'Wanna Marchi',NULL,NULL,'Via vai','37501','Modena','MO','221','3662354789','wanna@marchi.it',2),(6,'Wanna Marchi',NULL,NULL,'Via vai','37502','Modena','MO','221','3662354789','wanna@marchi.it',3),(7,'Wanna Marchi',NULL,NULL,'Via vai','37503','Modena','MO','221','3662354789','wanna@marchi.it',4);
/*!40000 ALTER TABLE `anagrafica` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cause`
--

DROP TABLE IF EXISTS `cause`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cause` (
  `idcause` int NOT NULL AUTO_INCREMENT,
  `idcliente` int NOT NULL,
  `nomecausa` varchar(256) NOT NULL,
  `datainiziocausa` datetime NOT NULL,
  `datafinecausa` datetime DEFAULT NULL,
  `descrizione` varchar(512) DEFAULT NULL,
  `idUtente` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`idcause`)
) ENGINE=InnoDB AUTO_INCREMENT=511 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cause`
--

LOCK TABLES `cause` WRITE;
/*!40000 ALTER TABLE `cause` DISABLE KEYS */;
INSERT INTO `cause` VALUES (9,2,'Bunga 2','2023-03-22 00:00:00',NULL,NULL,1),(12,3,'Bunga Bunga','2023-03-22 00:00:00',NULL,NULL,1),(13,3,'CAUSA MOSCHETTA','2023-03-22 00:00:00',NULL,'Persa malissimo',1),(14,3,'CAUSA MIAAA','2023-03-22 00:00:00',NULL,'Causa per cliente mio che vuole denunciarmi per avergli fatto causa.',1),(15,3,'Bunga Bunga','2023-03-22 00:00:00',NULL,NULL,1),(20,2,'CAUSA MIAAA','2023-03-22 00:00:00',NULL,'Causa per cliente mio che vuole denunciarmi per avergli fatto causa.',1),(31,3,'CAUSA MOSCHETTA','2023-03-22 00:00:00',NULL,'Persa malissimo',1),(32,3,'CAUSA MIAAA','2023-03-22 00:00:00',NULL,'Causa per cliente mio che vuole denunciarmi per avergli fatto causa.',1),(34,3,'CAUSA MOSCHETTA','2023-03-22 00:00:00',NULL,'Persa malissimo',1),(35,3,'CAUSA MIAAA','2023-03-22 00:00:00',NULL,'Causa per cliente mio che vuole denunciarmi per avergli fatto causa.',1),(39,3,'Bunga Bunga','2023-03-22 00:00:00',NULL,NULL,1);
/*!40000 ALTER TABLE `cause` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cause_doc`
--

DROP TABLE IF EXISTS `cause_doc`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cause_doc` (
  `idcause_doc` int NOT NULL AUTO_INCREMENT,
  `idcausa` int NOT NULL,
  `filename` varchar(128) NOT NULL,
  `filetype` varchar(50) NOT NULL,
  PRIMARY KEY (`idcause_doc`),
  KEY `secondary` (`idcausa`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cause_doc`
--

LOCK TABLES `cause_doc` WRITE;
/*!40000 ALTER TABLE `cause_doc` DISABLE KEYS */;
INSERT INTO `cause_doc` VALUES (7,12,'D:\\BRAVISSIMO.pdf','.pdf');
/*!40000 ALTER TABLE `cause_doc` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `utenti`
--

DROP TABLE IF EXISTS `utenti`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `utenti` (
  `id` int NOT NULL DEFAULT '1',
  `username` varchar(30) NOT NULL,
  `email` varchar(50) NOT NULL,
  `password` varchar(128) NOT NULL,
  `admin` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `username` (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `utenti`
--

LOCK TABLES `utenti` WRITE;
/*!40000 ALTER TABLE `utenti` DISABLE KEYS */;
INSERT INTO `utenti` VALUES (1,'pippo','pippo@pluto.com','pippone',1),(2,'mario','mario@rossi.it','mario',0);
/*!40000 ALTER TABLE `utenti` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-03-24 19:44:53

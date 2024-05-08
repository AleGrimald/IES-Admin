-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: localhost    Database: ies_admin
-- ------------------------------------------------------
-- Server version	8.0.33

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
-- Table structure for table `alumno`
--

DROP TABLE IF EXISTS `alumno`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `alumno` (
  `Nombre` varchar(60) NOT NULL,
  `Dni` varchar(10) NOT NULL,
  `Edad` varchar(3) NOT NULL,
  `Direccion` varchar(60) NOT NULL,
  `Telefono` varchar(15) NOT NULL,
  `Legajo` varchar(5) NOT NULL,
  `Carrera` varchar(30) NOT NULL,
  `Fecha` date NOT NULL,
  `Anio` varchar(10) NOT NULL,
  `idalumno` int NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`idalumno`)
) ENGINE=InnoDB AUTO_INCREMENT=57 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alumno`
--

LOCK TABLES `alumno` WRITE;
/*!40000 ALTER TABLE `alumno` DISABLE KEYS */;
INSERT INTO `alumno` VALUES ('Grimaldi Oscar Alejandro','36420807','32','Lomas de Tafi Sec8 Lt6 M6 C5','3816699521','50890','Tecnicatura en Programacion','2023-03-15','2° Año',1),('Vazquez Juan Jose','34589698','33','Yerba Buena','3815847253','50896','Tecnicatura en Programacion','2024-05-02','1° Año',2),('Gomez Basualdo Alberto','32456899','35','Tafi Viejo','3815698895','49985','Tecnicatura en Programacion','2022-03-16','2° Año',3),('Palacio Bruno','41568977','26','Tafi Viejo','3815216456','50901','Desarrollo de Software','2023-03-14','2° Año',4),('Arroyo Maria Fernanda','34764652','33','Pj Bequert 2272','3810006598','50891','Tecnicatura en Programacion','2023-03-16','1° Año',5),('Grimaldi Arroyo Mia Francesca','70182431','20','Lomas de Tafi','3816699521','60235','Desarrollo de Software','2025-03-19','1° Año',6),('Gimenez Camilo','354458968','28','Yerba Buena','3815588785','58200','Desarrollo de Software','2023-03-13','1° Año',7);
/*!40000 ALTER TABLE `alumno` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-05-05 16:10:11

-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: resturant
-- ------------------------------------------------------
-- Server version	5.7.18-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `category` (
  `Category_id` int(11) NOT NULL AUTO_INCREMENT,
  `Category_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Category_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES (1,'Desserts'),(2,'Sandwitches'),(3,'Pasta'),(4,'SeaFood'),(5,'Meals'),(6,'Drinks'),(7,'Pizza'),(8,'Additions');
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `customer` (
  `Customer_id` int(11) NOT NULL AUTO_INCREMENT,
  `Customer_name` varchar(45) DEFAULT NULL,
  `Customer_phone` int(11) DEFAULT NULL,
  `Customer_address` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Customer_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` VALUES (1,'Mohamed',1011538534,'Elnamees'),(2,'Ahmed',128253825,'elsadat');
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `employee` (
  `Employee_id` int(11) NOT NULL AUTO_INCREMENT,
  `Employee_name` varchar(45) DEFAULT NULL,
  `Job` varchar(45) DEFAULT NULL,
  `Phone` int(11) DEFAULT NULL,
  `Address` varchar(45) DEFAULT NULL,
  `user` varchar(45) NOT NULL,
  `pass` varchar(45) DEFAULT NULL,
  `salary` int(11) DEFAULT NULL,
  `shift` int(11) DEFAULT NULL,
  PRIMARY KEY (`Employee_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES (1,'Abdo','Casher',1052852832,'Elnamees','abdo','123',1000,1),(2,'Fathi','Admin',1550304121,'Elnamees','ahmed','1234',1000,1),(3,'khalaf','Casher',1013636283,'Elhamraa','mohamed','12345',1000,2),(5,'Nour','Admin',1550304181,'10 elsalam','nndiaaa','nn12345',3500,1);
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `items`
--

DROP TABLE IF EXISTS `items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `items` (
  `Item_id` int(11) NOT NULL AUTO_INCREMENT,
  `Item_name` varchar(45) DEFAULT NULL,
  `Price` int(11) DEFAULT NULL,
  `Quantity` int(11) DEFAULT NULL,
  `Category_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Item_id`)
) ENGINE=InnoDB AUTO_INCREMENT=116 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `items`
--

LOCK TABLES `items` WRITE;
/*!40000 ALTER TABLE `items` DISABLE KEYS */;
INSERT INTO `items` VALUES (1,'Jelly',8,20,1),(2,'Jelly Fruit',11,30,1),(3,'Pudding',15,15,1),(4,'Pudding Nuts',14,13,1),(5,'Cupcake',13,17,1),(6,'Chocolate Cake',15,40,1),(7,'Moose Chocolate',15,33,1),(8,'Cheese Cake',17,45,1),(9,'Waffle Choclet',20,13,1),(10,'Waffle Cream',20,17,1),(11,'Waffle Fruit',25,20,1),(12,'Double Waffle',30,30,1),(13,'Waffle Mix',35,40,1),(14,'Waffle Mix Chocolate',30,39,1),(15,'IceCream2Pula',11,30,1),(16,'IceCream4Pula',16,23,1),(17,'IceCreamSoda',16,11,1),(19,'Tea',6,50,6),(20,'Ashab',8,24,6),(21,'Chaptsheno',16,14,6),(22,'Coffee Frinch',10,27,6),(23,'Coffee Turkey',8,44,6),(24,'Esperesso',10,12,6),(25,'Coffee',11,35,6),(26,'Nescafe',13,22,6),(27,'borio',20,45,6),(28,'Kit Kat',25,33,6),(29,'Flots',2,23,6),(30,'Mix Chocolate',30,13,6),(31,'Hohooz',22,22,6),(32,'Ice Coffee',17,14,6),(33,'Mocha',25,32,6),(34,'Frapee',25,10,6),(35,'Strawberry',25,11,6),(36,'Mooz',15,12,6),(37,'Mango',15,23,6),(38,'Kewy',20,22,6),(39,'Smozy',15,11,6),(40,'Lemon',12,1,6),(41,'Margerita',22,2,7),(42,'Vegatable',21,9,7),(43,'Shwarema Meat',25,22,7),(44,'Chicken',28,1,7),(45,'Hot Dug',28,0,7),(46,'Pasterma',23,30,7),(47,'Turiky Modkhn',25,20,7),(48,'Tona',26,4,7),(49,'Gambary',27,1,7),(50,'Four Chesse',25,8,7),(51,'Mix',29,33,7),(52,'Steak Meat',65,10,5),(53,'Orange Chicken',57,22,5),(54,'Mashroum Chicken',45,31,5),(55,'Light Chicken ',40,2,5),(56,'Sogoa Balady',60,24,5),(57,'Fattaah',30,11,5),(58,'Chicken Nagets',30,0,5),(59,'Mini Burger',30,33,5),(60,'Local Meal',13,12,5),(61,'Omlat Cheese',15,9,5),(62,'Foll and Taiaa',10,0,5),(63,'Vegatable Mashrom',23,12,3),(64,'Meats lazanya',26,22,3),(65,'Chicken lazanya',28,43,3),(66,'Hot Dog lazanya',25,12,3),(67,'Four Cheese lazanya',32,34,3),(68,'Gambary',35,22,3),(69,'Mexicano',33,15,3),(70,'Meats bash',19,34,3),(71,'Chicken bash',22,22,3),(72,'Hot Dog bash',20,17,3),(73,'four Chesse bash',25,16,3),(74,'Alferido',27,14,3),(75,'Parbecio',15,12,3),(76,'Naboletan',13,22,3),(77,'Poloneas',20,24,3),(78,'Esbakety Meat',24,25,3),(79,'Negrisco',27,23,3),(80,'Caponar',27,11,3),(81,'Potaneska',20,23,3),(82,'Crispy',21,3,2),(83,'Chicken',22,2,2),(84,'Faheta',19,10,2),(85,'Chicken Roll',23,11,2),(86,'Corden Plu',24,23,2),(87,'Shawerma',27,21,2),(88,'Chicken Mexican',15,5,2),(89,'Polo',23,44,2),(90,'Capelou',24,2,2),(91,'Hot dug',22,2,2),(92,'Kofta Grill',26,4,2),(93,'Picata',23,33,2),(94,'Faheta Sosses',22,22,2),(95,'shawerma',25,34,2),(96,'Burger',22,12,2),(97,'Steak Meat',26,22,2),(98,'Hawawshy',15,23,2),(99,'Boory',45,20,4),(100,'Cilamon',30,12,4),(101,'Bulty',50,16,4),(102,'Sarden',55,13,4),(103,'Abu Seif',35,24,4),(104,'Tona',45,34,4),(105,'Gambary',50,35,4),(106,'Sobad',45,15,4),(107,'Kaborya',39,4,4),(108,'Risa',20,12,8),(109,'Tehena Salad',12,13,8),(110,'Vegatable Salad',14,14,8),(111,'Zabady Salad',15,15,8),(112,'Croslou',15,16,8),(113,'Tomaia',14,17,8),(114,'Pickled',14,0,8),(115,'Potato',13,0,8);
/*!40000 ALTER TABLE `items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `purshased_bill`
--

DROP TABLE IF EXISTS `purshased_bill`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `purshased_bill` (
  `IdPurshased_bill_id` int(11) NOT NULL AUTO_INCREMENT,
  `Category_id` int(11) NOT NULL,
  `Toltal_Purshased` varchar(45) NOT NULL,
  PRIMARY KEY (`IdPurshased_bill_id`),
  KEY `Category_id_idx` (`Category_id`),
  CONSTRAINT `categor` FOREIGN KEY (`Category_id`) REFERENCES `category` (`Category_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purshased_bill`
--

LOCK TABLES `purshased_bill` WRITE;
/*!40000 ALTER TABLE `purshased_bill` DISABLE KEYS */;
/*!40000 ALTER TABLE `purshased_bill` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sells_bill`
--

DROP TABLE IF EXISTS `sells_bill`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sells_bill` (
  `Sells_bill_id` int(11) NOT NULL AUTO_INCREMENT,
  `Total_price` int(11) DEFAULT NULL,
  `Customer_id` varchar(45) DEFAULT NULL,
  `bill_Date` varchar(30) DEFAULT NULL,
  `bill_Time` varchar(30) DEFAULT NULL,
  `shift` int(11) DEFAULT NULL,
  `cashier_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Sells_bill_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sells_bill`
--

LOCK TABLES `sells_bill` WRITE;
/*!40000 ALTER TABLE `sells_bill` DISABLE KEYS */;
INSERT INTO `sells_bill` VALUES (3,264,'','5/2/2018','2:34 AM',1,''),(4,145,'1','5/2/2018','5:14 AM',1,''),(5,169,'2','5/2/2018','1:17 PM',1,''),(6,257,'2','5/2/2018','1:19 PM',1,''),(7,138,'1','5/2/2018','3:18 PM',1,''),(8,223,'1','5/2/2018','5:48 PM',1,''),(9,169,'1','5/3/2018','3:09 AM',1,''),(10,162,'','8/4/2018','6:55 PM',1,NULL);
/*!40000 ALTER TABLE `sells_bill` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tables`
--

DROP TABLE IF EXISTS `tables`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tables` (
  `idTables` int(11) NOT NULL AUTO_INCREMENT,
  `Tables_statue` varchar(45) DEFAULT NULL,
  `Customer_id` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idTables`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tables`
--

LOCK TABLES `tables` WRITE;
/*!40000 ALTER TABLE `tables` DISABLE KEYS */;
/*!40000 ALTER TABLE `tables` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'resturant'
--
/*!50003 DROP PROCEDURE IF EXISTS `employee` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `employee`(k varchar(45),Id_par1 int(11),Name_par2 varchar(45),
Job_par3 varchar(45),Phone_par4 int(11),Address_par5 varchar(45),User_par6 varchar(45),
Pass_par7 varchar(45),Salary_par8 int(11),Shift_par9 int(11))
BEGIN

if k="login"
then select user,pass,Job from employee where user = user_par6 and pass = pass_par7;

elseif k="insert"
then insert into employee (Employee_name,Job,Phone,Address,user,pass,salary,shift) values (Name_par2, Job_par3, Phone_par4, Address_par5, User_par6, Pass_par7, Salary_par8, Shift_par9);

elseif k="update"
then UPDATE employee SET Phone =Phone_par4, Address=Address_par5, user=User_par6, pass=Pass_par7, salary=Salary_par8, shift=Shift_par9 WHERE Employee_id=Id_par1;

elseif k="delete"
then delete from employee where Employee_id = Id_par1 ;

end if ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-08-05 21:26:24

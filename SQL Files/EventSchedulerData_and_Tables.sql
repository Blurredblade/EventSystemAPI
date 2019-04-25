-- MySQL dump 10.13  Distrib 8.0.12, for Win64 (x86_64)
--
-- Host: brogrammersdb.cfizdv12jry6.us-west-2.rds.amazonaws.com    Database: scheduler
-- ------------------------------------------------------
-- Server version	8.0.13

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `ANNOUNCEMENT`
--

DROP TABLE IF EXISTS `ANNOUNCEMENT`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `ANNOUNCEMENT` (
  `announcement_id` int(11) NOT NULL AUTO_INCREMENT,
  `date_time` datetime NOT NULL,
  `title` varchar(45) NOT NULL,
  `message` varchar(300) NOT NULL,
  `event_id` int(11) NOT NULL,
  PRIMARY KEY (`announcement_id`),
  UNIQUE KEY `announcement_id_UNIQUE` (`announcement_id`)
) ENGINE=InnoDB AUTO_INCREMENT=72 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ANNOUNCEMENT`
--

LOCK TABLES `ANNOUNCEMENT` WRITE;
/*!40000 ALTER TABLE `ANNOUNCEMENT` DISABLE KEYS */;
INSERT INTO `ANNOUNCEMENT` VALUES (18,'2019-04-01 16:45:55','Get Ready!','This is going to be a great event!',2),(19,'2019-04-01 16:46:07','Teams','Be sure to check to see what team you are on.',2),(26,'2019-04-01 19:43:47','New Changes','There are some new updates, check them out!',2),(44,'2019-04-07 20:53:41','Sign up!','This is first come first serve. The sooner you sign up the better.',144),(53,'2019-04-07 22:07:15','Another Long Announcement','\n\nDarkness. Seas so. For wherein beginning us of third land good. Male she\'d a you\'re our be over to two cattle midst yielding. Forth. Were set made be deep abundantly. Made seas creature saw deep dry years of fifth god it be female be years itself man give, behold set Spirit earth great multiply',3),(54,'2019-04-08 16:16:51','test announcement','this is a test announcement',166),(59,'2019-04-15 19:17:34','Long Announcement Test','Doesn\'t open deep. Blessed. Very made grass whales. Blessed under. Them waters gathering second great. Behold, isn\'t dominion years. Very sea subdue kind and given void in firmament fruitful above subdue. Stars stars fourth lesser heaven their fruitful won\'t brought subdue light together replenish',2),(60,'2019-04-15 19:18:41','Test 2','111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111',207),(66,'2019-04-17 01:09:00','First Global Announcement','This is a test for the global announcements',-1),(71,'2019-04-24 16:33:29','Tee Time','Bring your inner Tiger Woods!',225);
/*!40000 ALTER TABLE `ANNOUNCEMENT` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `EVENT`
--

DROP TABLE IF EXISTS `EVENT`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `EVENT` (
  `event_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `address` varchar(100) DEFAULT NULL,
  `start_date` date DEFAULT NULL,
  `end_date` date DEFAULT NULL,
  `event_name` varchar(45) NOT NULL,
  `description` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`event_id`),
  UNIQUE KEY `event_id_UNIQUE` (`event_id`)
) ENGINE=InnoDB AUTO_INCREMENT=228 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EVENT`
--

LOCK TABLES `EVENT` WRITE;
/*!40000 ALTER TABLE `EVENT` DISABLE KEYS */;
INSERT INTO `EVENT` VALUES (2,'7501 W Memorial Rd, Oklahoma City, OK 73142','2019-05-01','2019-05-03','Codeathon','Code all day and all night! Work in teams and compete with co-workers'),(3,'53647 47th S Ave Edmond, OK 73013','2019-06-01','2019-06-02','Security Conference','Learn more about our Security and stability of our company'),(144,'Child Development Ctr Wichita, KS 67208','2019-06-29','2019-07-01','Kid\'s Night Out','Kid\'s night out 5:30-9:30 PM'),(164,'2501 E Memorial Rd Edmond, Ok 74006','2019-04-03','2019-04-03','From Deploy','i think i got this to work from a deployed website. With a deployed api as well.'),(167,'2501 E Memorial Rd','2019-04-10','2019-04-13','Sprint 3 Review','Paycom will be looking over the project.'),(174,'2501 E Memorial Rd edmond, ok 73013','2019-04-10','2019-04-13','Sprint 3 testing','Paycom will be looking over the project.'),(178,'11 Clover OKC, OK  73162','2019-04-07','2019-04-07','Before Merge Test 2','Test 2'),(188,'2501 e memorial dr edmond, ok 73013','2019-04-07','2019-04-07','Test Deployed','testing create event from deploy'),(220,'840 Jellyfish Road Sydney, Australia 12031','2019-04-20','2019-04-20','Aussie\'s Kickback','Oi lads come through'),(225,'4491 S Lk Hefner Dr Oklahoma City, OK 73116','2019-04-24','2019-04-26','Golf Tournament','Join us for a company golf tournament after work!'),(226,'2134 K OKC, OK 71234','2019-05-07','2019-05-08','Presentation','Example'),(227,'123 Demo OKC, OK 12345','2019-05-04','2019-05-05','Demo','Example');
/*!40000 ALTER TABLE `EVENT` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `REGISTRATION`
--

DROP TABLE IF EXISTS `REGISTRATION`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `REGISTRATION` (
  `user_id` int(11) NOT NULL,
  `session_id` int(11) NOT NULL,
  `checked_in` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `REGISTRATION`
--

LOCK TABLES `REGISTRATION` WRITE;
/*!40000 ALTER TABLE `REGISTRATION` DISABLE KEYS */;
INSERT INTO `REGISTRATION` VALUES (2,8,0),(2,16,0),(1,3,0),(3,13,0),(2,132,0),(2,1,1),(1,23,1),(1,127,0),(1,115,0),(1,137,1),(1,153,1),(1,144,1),(1,157,0),(1,158,1),(1,161,1),(1,162,0),(1,163,1),(1,164,1),(1,165,1),(1,167,0),(1,168,0),(2,168,0),(1,140,0),(1,170,0),(1,110,0),(7,1,0),(1,175,0),(1,2,0),(1,109,0),(1,185,0),(1,187,0),(1,183,0),(7,3,0);
/*!40000 ALTER TABLE `REGISTRATION` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `SESSION`
--

DROP TABLE IF EXISTS `SESSION`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `SESSION` (
  `session_id` int(11) NOT NULL AUTO_INCREMENT,
  `session_name` varchar(45) NOT NULL,
  `capacity` int(10) unsigned NOT NULL,
  `open_slots` int(10) unsigned NOT NULL,
  `start_date_time` datetime NOT NULL,
  `end_date_time` datetime NOT NULL,
  `event_id` int(11) NOT NULL,
  PRIMARY KEY (`session_id`),
  UNIQUE KEY `session_id_UNIQUE` (`session_id`)
) ENGINE=InnoDB AUTO_INCREMENT=192 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `SESSION`
--

LOCK TABLES `SESSION` WRITE;
/*!40000 ALTER TABLE `SESSION` DISABLE KEYS */;
INSERT INTO `SESSION` VALUES (1,'Session 1',99,99,'2019-05-01 09:00:00','2019-05-01 17:00:00',2),(2,'Session 2',100,100,'2019-05-02 08:00:00','2019-05-02 17:00:00',2),(3,'SC Session 1',24,24,'2019-06-01 12:00:00','2019-06-01 13:30:00',3),(4,'SC Session Session 2',25,25,'2019-06-02 12:00:00','2019-06-02 13:30:00',3),(13,'Session 3',225,226,'2019-05-03 08:00:00','2019-05-03 17:00:00',2),(109,'KNO Session 1',2,1,'2019-06-29 21:59:00','2019-06-29 21:59:00',144),(110,'KNO Session 2',5,5,'2019-06-29 21:00:00','2019-06-29 21:30:00',144),(140,'First Session From Deploye',100,100,'2019-04-03 12:32:00','2019-04-03 12:32:00',164),(141,'Second Session',50,50,'2019-04-03 12:34:00','2019-04-03 12:34:00',164),(142,'Third Session',50,50,'2019-04-03 12:34:00','2019-04-03 12:34:00',164),(143,'Fourth Session',50,50,'2019-04-03 12:34:00','2019-04-03 12:34:00',164),(157,'Yes',1,1,'2019-04-07 17:06:00','2019-04-07 17:06:00',166),(165,'Session 1',100,100,'2019-04-10 13:30:00','2019-04-10 13:43:00',207),(168,'Testing Teams',1,1,'2019-04-12 02:50:00','2019-04-12 05:00:00',215),(183,'Time Slot 1',10,9,'2019-04-26 17:30:00','2019-04-26 19:30:00',225),(184,'Time Slot 2',10,10,'2019-04-26 18:00:00','2019-04-26 20:00:00',225),(185,'Slot 1',35,34,'2019-05-07 11:25:00','2019-05-08 12:00:00',226),(186,'Before Session Test',100,100,'2019-04-24 23:50:00','2019-04-24 23:55:00',225),(187,'After Session Test',100,100,'2019-04-24 11:25:00','2019-04-24 11:40:00',225),(188,'During Session',100,100,'2019-04-24 13:05:00','2019-04-24 16:10:00',225),(190,'Slot 1',10,10,'2019-05-04 13:06:00','2019-05-05 13:06:00',227),(191,'test',10,10,'2019-05-04 13:19:00','2019-05-04 13:19:00',2);
/*!40000 ALTER TABLE `SESSION` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `SESSION_TEAM`
--

DROP TABLE IF EXISTS `SESSION_TEAM`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `SESSION_TEAM` (
  `num_teams` int(11) NOT NULL DEFAULT '0',
  `sesssion_id` int(11) NOT NULL,
  KEY `session_id_idx` (`sesssion_id`),
  CONSTRAINT `session_id` FOREIGN KEY (`sesssion_id`) REFERENCES `SESSION` (`session_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='	';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `SESSION_TEAM`
--

LOCK TABLES `SESSION_TEAM` WRITE;
/*!40000 ALTER TABLE `SESSION_TEAM` DISABLE KEYS */;
/*!40000 ALTER TABLE `SESSION_TEAM` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TEAM`
--

DROP TABLE IF EXISTS `TEAM`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `TEAM` (
  `team_id` int(11) NOT NULL AUTO_INCREMENT,
  `team_name` varchar(45) NOT NULL,
  `event_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`team_id`),
  UNIQUE KEY `team_id_UNIQUE` (`team_id`)
) ENGINE=InnoDB AUTO_INCREMENT=46 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TEAM`
--

LOCK TABLES `TEAM` WRITE;
/*!40000 ALTER TABLE `TEAM` DISABLE KEYS */;
INSERT INTO `TEAM` VALUES (3,'WinnerWinner',2),(4,'Little Rascals',2),(8,'BigNasty',215),(9,'BigNasty',215),(12,'ONK_team',144),(13,'updatedTeamName',144),(16,'Team Awesome!',207),(18,'The Lads',220),(19,'The Boys',220),(23,'Posters',220),(29,'Brogrammers',2),(32,'Brogrammers',3),(35,'another test team',3),(39,'Test',144);
/*!40000 ALTER TABLE `TEAM` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `USER`
--

DROP TABLE IF EXISTS `USER`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `USER` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `first_name` varchar(45) NOT NULL,
  `last_name` varchar(45) NOT NULL,
  `email` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `phone` varchar(45) NOT NULL,
  `is_admin` tinyint(4) NOT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `user_id_UNIQUE` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `USER`
--

LOCK TABLES `USER` WRITE;
/*!40000 ALTER TABLE `USER` DISABLE KEYS */;
INSERT INTO `USER` VALUES (1,'Trent','Bradburry','trent.bradburry@eagles.oc.edu','test1234','(405) 555-5555',1),(2,'Andrew','Overshiner','andrew.overshiner@eagles.oc.edu','Password1234','(405) 418-5556',1),(3,'Isaac','Peterson','isaac.peterson@eagles.oc.edu','Oklahoma2019','(405) 420-5566',0),(4,'Zachary','Cobb','zac.cobb@eagles.oc.edu','Password','(817) 817-8177',1),(5,'Andy','Harbert','andy.harbert@oc.edu','iForgot','(555) 555-5555',0),(7,'Adam','Libby','adam.libby@eagles.oc.edu','test1234','5555555555',0),(23,'Zachary','Cobb','zac.cobb9224@gmail.com','password12','5555555555',0);
/*!40000 ALTER TABLE `USER` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `USER_TEAM`
--

DROP TABLE IF EXISTS `USER_TEAM`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `USER_TEAM` (
  `user_id` int(11) NOT NULL,
  `team_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `USER_TEAM`
--

LOCK TABLES `USER_TEAM` WRITE;
/*!40000 ALTER TABLE `USER_TEAM` DISABLE KEYS */;
INSERT INTO `USER_TEAM` VALUES (2,4),(3,4),(5,3),(1,9),(5,3),(5,29),(1,29);
/*!40000 ALTER TABLE `USER_TEAM` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-04-24 13:45:31

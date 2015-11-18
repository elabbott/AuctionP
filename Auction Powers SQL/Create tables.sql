    CREATE TABLE `User` (
  `Username` varchar(16) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `Password` varchar(32) NOT NULL,
  `Create_Time` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `User_Id` int(11) NOT NULL AUTO_INCREMENT,
  `Address` varchar(45) DEFAULT NULL,
  `City` varchar(45) DEFAULT NULL,
  `State` varchar(45) DEFAULT NULL,
  `Zipcode` varchar(45) DEFAULT NULL,
  `First_Name` varchar(45) DEFAULT NULL,
  `Last_Name` varchar(45) DEFAULT NULL,
  `Last_Login` datetime DEFAULT NULL,
  `Last_Modified` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`User_Id`),
  UNIQUE KEY `Username_UNIQUE` (`Username`),
  UNIQUE KEY `Email_UNIQUE` (`Email`),
  UNIQUE KEY `User_Id_UNIQUE` (`User_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8;
CREATE TABLE `User_Activation` (
  `User_Id` int(11) NOT NULL,
  `Activation_Code` char(38) NOT NULL,
  PRIMARY KEY (`User_Id`),
  UNIQUE KEY `User_Id_UNIQUE` (`User_Id`),
  CONSTRAINT `User_Id_Activation` FOREIGN KEY (`User_Id`) REFERENCES `User` (`User_Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='for activating users';


CREATE TABLE `Account` (
  `Account_Id` int(11) NOT NULL AUTO_INCREMENT,
  `User_Id` int(11) NOT NULL,
  `Balance` double NOT NULL DEFAULT '0',
  `Available_Balance` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`Account_Id`),
  CONSTRAINT `User_Id_Account` FOREIGN KEY (`User_Id`) REFERENCES `User` (`User_Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='money accounts for user';

CREATE TABLE `Auction` (
  `Auction_Id` int(11) NOT NULL AUTO_INCREMENT,
  `User_Id_Owner` int(11) NOT NULL,
  `User_Id_High_Bid` int(11),
  `Current_High_Bid` double,
  `Min_Bid` double NOT NULL DEFAULT '0.01',
  `Buyout` double,
  `Open` boolean not null default true,
  `Create_Date` datetime not null default current_timestamp,
  `End_Date` datetime not null,
  `Description` text not null,
  `Image_URL` varchar(255) not null,
  PRIMARY KEY (`Auction_Id`),
  CONSTRAINT `User_Id_Auction_Owner` FOREIGN KEY (`User_Id_Owner`) REFERENCES `User` (`User_Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Auction Class';

CREATE TABLE `CreditCard` (
  `Card_Id` int(11) NOT NULL AUTO_INCREMENT,
  `User_Id` int(11) NOT NULL,
  `Card_Number` varchar(16) not null,
  `Owner_Name` varchar(42) not null,
  `CCV_Number` varchar(4) not null,
  `Expiration_Date` date not null,
  PRIMARY KEY (`Card_Id`),
  CONSTRAINT `User_Id_CreditCard` FOREIGN KEY (`User_Id`) REFERENCES `User` (`User_Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Credit card information';

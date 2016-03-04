/*
Navicat MySQL Data Transfer

Source Server         : 西部数码
Source Server Version : 50546
Source Host           : 211.149.242.82:3306
Source Database       : pavilion

Target Server Type    : MYSQL
Target Server Version : 50546
File Encoding         : 65001

Date: 2015-12-28 21:41:19
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for deviceinfo
-- ----------------------------
DROP TABLE IF EXISTS `deviceinfo`;
CREATE TABLE `deviceinfo` (
  `Id` int(11) NOT NULL,
  `Type` varchar(30) NOT NULL,
  `Location` varchar(50) DEFAULT NULL,
  `Ip` varchar(45) NOT NULL,
  `Port` varchar(45) NOT NULL,
  `HighThreshold` float DEFAULT NULL,
  `LowThreshold` float DEFAULT NULL,
  `CorrectFactor` float DEFAULT NULL,
  `DataUnit` varchar(20) DEFAULT NULL,
  `RainValueUnit` varchar(20) DEFAULT NULL,
  `ErrorThreshold` float DEFAULT NULL,
  `ScanTime` int(11) DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of deviceinfo
-- ----------------------------
INSERT INTO `deviceinfo` VALUES ('1', 'RSS131', '运输部亭子', '127.0.0.1', '4003', '1000', '100', '0.9', 'R', null, null, '30', 'invalid');
INSERT INTO `deviceinfo` VALUES ('2', 'JL900', '运输部亭子', '127.0.0.1', '4001', '1000', '100', '0.9', 'J', null, null, '5', 'valid');
INSERT INTO `deviceinfo` VALUES ('3', 'H3R7000', '运输部亭子', '127.0.0.1', '4002', '1000', '100', '0.9', 'H', '', null, '20', 'invalid');
INSERT INTO `deviceinfo` VALUES ('4', 'ASM02', '运输部亭子', '127.0.0.1', '5000', '1000', '100', '0.9', 'A', '', null, '5', 'valid');
INSERT INTO `deviceinfo` VALUES ('5', 'DryWet', '运输部亭子', '127.0.0.1', '4005', '1000', '100', '0.9', 'D', '', null, '4', 'valid');

-- ----------------------------
-- Table structure for exceptionhistorydata
-- ----------------------------
DROP TABLE IF EXISTS `exceptionhistorydata`;
CREATE TABLE `exceptionhistorydata` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `DevId` int(11) NOT NULL,
  `val1` double DEFAULT NULL,
  `val2` double DEFAULT NULL,
  `val3` double DEFAULT NULL,
  `val4` double DEFAULT NULL,
  `str_val5` varchar(1000) DEFAULT NULL,
  `DataTime` datetime NOT NULL,
  `State` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of exceptionhistorydata
-- ----------------------------

-- ----------------------------
-- Table structure for historydata
-- ----------------------------
DROP TABLE IF EXISTS `historydata`;
CREATE TABLE `historydata` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `DevId` int(11) NOT NULL,
  `val1` double DEFAULT NULL,
  `val2` double DEFAULT NULL,
  `val3` double DEFAULT NULL,
  `val4` double DEFAULT NULL,
  `str_val5` varchar(1000) DEFAULT NULL,
  `DataTime` datetime NOT NULL,
  `State` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of historydata
-- ----------------------------
INSERT INTO `historydata` VALUES ('1', '2', '970', '669.3', '441.2', '0', '0:39:40', '2015-12-28 20:05:00', '');
INSERT INTO `historydata` VALUES ('2', '2', '970', '669.3', '441.2', '0', '0:39:40', '2015-12-28 20:08:31', ' ');
INSERT INTO `historydata` VALUES ('3', '2', '970', '669.3', '441.2', '0', '0:39:40', '2015-12-28 20:08:36', ' ');
INSERT INTO `historydata` VALUES ('4', '5', '10012', '0', '0', '0', '关盖_无雨', '2015-12-28 20:08:51', ' ');
INSERT INTO `historydata` VALUES ('5', '5', '10012', '0', '0', '0', '关盖_无雨', '2015-12-28 20:08:55', ' ');
INSERT INTO `historydata` VALUES ('6', '4', '0', '0', '0', '0', 'Ab:,,,3.13E-003,,,,1.85E-002;Ec:,,,,,,,;Fl:01200,002.8,27.0,35.0,000.0,31.7,16.1,01.2,3,401;Ga:,,,,3.60E-001,,;Gi:,,,,1.98E-002,,;Me:0.00e+000,0.0,0,,+0.0,0.0,000,,,;Oi:,,,,,,;Rn:4.82E+000,2.12E-001,,1.31E-001,2.15E-001,', '2015-12-28 20:09:14', ' ');
INSERT INTO `historydata` VALUES ('7', '4', '0', '0', '0', '0', 'Ab:,,,3.13E-003,,,,1.85E-002;Ec:,,,,,,,;Fl:01200,002.8,27.0,35.0,000.0,31.7,16.1,01.2,3,401;Ga:,,,,3.60E-001,,;Gi:,,,,1.98E-002,,;Me:0.00e+000,0.0,0,,+0.0,0.0,000,,,;Oi:,,,,,,;Rn:4.82E+000,2.12E-001,,1.31E-001,2.15E-002,', '2015-12-28 20:09:28', ' ');
INSERT INTO `historydata` VALUES ('8', '2', '970', '669.3', '441.2', '0', '0:39:40', '2015-12-28 20:12:40', ' ');
INSERT INTO `historydata` VALUES ('9', '2', '953', '669.3', '441.2', '0', '0:42:40', '2015-12-28 20:12:53', ' ');
INSERT INTO `historydata` VALUES ('10', '2', '953', '669.3', '441.2', '0', '0:42:40', '2015-12-28 20:12:58', ' ');
INSERT INTO `historydata` VALUES ('11', '2', '953', '669.3', '441.2', '0', '0:42:40', '2015-12-28 20:13:22', ' ');
INSERT INTO `historydata` VALUES ('12', '2', '953', '669.3', '441.2', '0', '0:42:40', '2015-12-28 20:13:36', ' ');
INSERT INTO `historydata` VALUES ('13', '2', '953', '669.3', '441.2', '0', '0:42:40', '2015-12-28 20:24:34', ' ');
INSERT INTO `historydata` VALUES ('14', '2', '953', '669.3', '441.2', '0', '0:42:40', '2015-12-28 20:24:41', ' ');
INSERT INTO `historydata` VALUES ('15', '2', '970', '669.3', '441.2', '0', '0:39:40', '2015-12-28 20:24:55', ' ');
INSERT INTO `historydata` VALUES ('16', '2', '435', '799.3', '741.2', '0', '0:42:40', '2015-12-28 20:26:09', ' ');
INSERT INTO `historydata` VALUES ('17', '5', '10012', '0', '0', '0', '开盖_降雨', '2015-12-28 20:27:47', ' ');
INSERT INTO `historydata` VALUES ('18', '5', '10012', '0', '0', '0', '开盖_降雨', '2015-12-28 20:27:51', ' ');
INSERT INTO `historydata` VALUES ('19', '4', '0', '0', '0', '0', 'Ab:,,,3.13E-003,,,,1.85E-002;Ec:,,,,,,,;Fl:01200,002.8,27.0,35.0,000.0,31.7,16.1,01.2,3,401;Ga:,,,,3.60E-001,,;Gi:,,,,1.98E-002,,;Me:0.00e+000,0.0,0,,+0.0,0.0,000,,,;Oi:,,,,,,;Rn:4.82E+000,2.12E-001,,1.31E-001,2.15E-001,', '2015-12-28 20:28:18', ' ');
INSERT INTO `historydata` VALUES ('20', '5', '10012', '0', '0', '0', '关盖_无雨', '2015-12-28 21:19:09', ' ');

-- ----------------------------
-- Table structure for monthhistorydata
-- ----------------------------
DROP TABLE IF EXISTS `monthhistorydata`;
CREATE TABLE `monthhistorydata` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `DevId` int(11) NOT NULL,
  `val1` double DEFAULT NULL,
  `val2` double DEFAULT NULL,
  `val3` double DEFAULT NULL,
  `val4` double DEFAULT NULL,
  `str_val5` varchar(1000) DEFAULT NULL,
  `DataTime` datetime NOT NULL,
  `State` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=59 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of monthhistorydata
-- ----------------------------
INSERT INTO `monthhistorydata` VALUES ('4', '5', '12', '0', '0', '0', '关盖_无雨', '2015-12-24 22:01:39', '');
INSERT INTO `monthhistorydata` VALUES ('5', '5', '12', '0', '0', '0', '关盖_无雨', '2015-12-24 22:01:51', '');
INSERT INTO `monthhistorydata` VALUES ('6', '2', '970', '669.3', '441.2', '0', '0:39:44\0', '2015-12-24 22:08:41', '');
INSERT INTO `monthhistorydata` VALUES ('7', '2', '970', '669.3', '441.2', '0', '0:39:44', '2015-12-24 22:15:55', '');
INSERT INTO `monthhistorydata` VALUES ('8', '5', '12', '0', '0', '0', '关盖_无雨', '2015-12-24 22:16:14', '');
INSERT INTO `monthhistorydata` VALUES ('9', '2', '970', '669.3', '441.2', '0', '0:39:44', '2015-12-24 22:24:16', '');
INSERT INTO `monthhistorydata` VALUES ('10', '2', '970', '669.3', '441.2', '0', '0:39:44', '2015-12-24 22:24:30', '');
INSERT INTO `monthhistorydata` VALUES ('11', '5', '10012', '0', '0', '0', '开盖_降雨', '2015-12-24 22:24:39', '');
INSERT INTO `monthhistorydata` VALUES ('12', '5', '10012', '0', '0', '0', '开盖_降雨', '2015-12-24 22:24:44', '');
INSERT INTO `monthhistorydata` VALUES ('13', '5', '10012', '0', '0', '0', '关盖_无雨', '2015-12-24 22:25:03', '');
INSERT INTO `monthhistorydata` VALUES ('14', '5', '10012', '0', '0', '0', '关盖_无雨', '2015-12-24 22:25:09', '');
INSERT INTO `monthhistorydata` VALUES ('15', '2', '970', '669.3', '441.2', '0', '0:39:40', '2015-12-24 22:25:43', '');
INSERT INTO `monthhistorydata` VALUES ('16', '2', '970', '669.3', '441.2', '0', '0:39:40', '2015-12-24 22:25:48', '');
INSERT INTO `monthhistorydata` VALUES ('17', '2', '953', '669.3', '441.2', '0', '0:42:40', '2015-12-24 22:26:35', '');
INSERT INTO `monthhistorydata` VALUES ('18', '2', '970', '669.3', '441.2', '0', '0:39:44', '2015-12-24 22:38:24', '');
INSERT INTO `monthhistorydata` VALUES ('19', '2', '970', '669.3', '441.2', '0', '0:39:44', '2015-12-24 22:38:29', '');
INSERT INTO `monthhistorydata` VALUES ('20', '5', '10012', '0', '0', '0', '开盖_降雨', '2015-12-24 22:38:47', '');
INSERT INTO `monthhistorydata` VALUES ('21', '5', '10012', '0', '0', '0', '开盖_降雨', '2015-12-24 22:38:51', '');
INSERT INTO `monthhistorydata` VALUES ('22', '5', '10012', '0', '0', '0', '开盖_降雨', '2015-12-24 22:39:02', '');
INSERT INTO `monthhistorydata` VALUES ('23', '2', '953', '669.3', '441.2', '0', '0:42:40', '2015-12-25 15:49:26', '');
INSERT INTO `monthhistorydata` VALUES ('24', '5', '10012', '0', '0', '0', '开盖_降雨', '2015-12-25 15:49:48', '');
INSERT INTO `monthhistorydata` VALUES ('25', '2', '970', '669.3', '441.2', '0', '0:39:40', '2015-12-25 17:45:41', '');
INSERT INTO `monthhistorydata` VALUES ('26', '5', '10012', '0', '0', '0', '开盖_降雨', '2015-12-25 17:45:59', '');
INSERT INTO `monthhistorydata` VALUES ('27', '5', '10012', '0', '0', '0', '开盖_降雨', '2015-12-25 17:46:04', ' ');
INSERT INTO `monthhistorydata` VALUES ('28', '4', '0', '0', '0', '0', 'Ab:,,,3.13E-003,,,,1.85E-002;Ec:,,,,,,,;Fl:01200,002.8,27.0,35.0,000.0,31.7,16.1,01.2,3,401;Ga:,,,,3.60E-001,,;Gi:,,,,1.98E-002,,;Me:0.00e+000,0.0,0,,+0.0,0.0,000,,,;Oi:,,,,,,;Rn:4.82E+000,2.12E-001,,1.31E-001,2.15E-001,', '2015-12-25 17:46:30', '');
INSERT INTO `monthhistorydata` VALUES ('29', '4', '0', '0', '0', '0', 'Ab:,,,3.13E-003,,,,1.85E-002;Ec:,,,,,,,;Fl:01200,002.8,27.0,35.0,000.0,31.7,16.1,01.2,3,401;Ga:,,,,3.60E-001,,;Gi:,,,,1.98E-002,,;Me:0.00e+000,0.0,0,,+0.0,0.0,000,,,;Oi:,,,,,,;Rn:4.82E+000,2.12E-001,,1.31E-001,2.15E-001,', '2015-12-25 17:50:59', '');
INSERT INTO `monthhistorydata` VALUES ('30', '2', '953', '669.3', '441.2', '0', '0:42:40', '2015-12-25 17:51:07', '');
INSERT INTO `monthhistorydata` VALUES ('31', '2', '953', '669.3', '441.2', '0', '0:42:40', '2015-12-25 17:51:13', ' ');
INSERT INTO `monthhistorydata` VALUES ('32', '4', '0', '0', '0', '0', 'Ab:,,,3.13E-003,,,,1.85E-002;Ec:,,,,,,,;Fl:01200,002.8,27.0,35.0,000.0,31.7,16.1,01.2,3,401;Ga:,,,,3.60E-001,,;Gi:,,,,1.98E-002,,;Me:0.00e+000,0.0,0,,+0.0,0.0,000,,;Oi:,,,,,,;Rn:4.82E+000,2.12E-001,,1.31E-001,2.15E-001,', '2015-12-25 18:00:55', '');
INSERT INTO `monthhistorydata` VALUES ('33', '4', '0', '0', '0', '0', 'Ab:,,,3.13E-003,,,,1.85E-002;Ec:,,,,,,,;Fl:01200,002.8,27.0,35.0,000.0,31.7,16.1,01.2,3,401;Ga:,,,,3.60E-001,,;Gi:,,,,1.98E-002,,;Me:0.00e+000,0.0,0,,+0.0,0.0,000,,,;Oi:,,,,,,;Rn:4.82E+000,2.12E-001,,1.31E-001,2.15E-001,', '2015-12-25 19:13:04', '');
INSERT INTO `monthhistorydata` VALUES ('34', '2', '953', '669.3', '441.2', '0', '0:42:40', '2015-12-25 19:13:21', '');
INSERT INTO `monthhistorydata` VALUES ('35', '5', '10012', '0', '0', '0', '关盖_无雨', '2015-12-25 19:13:46', '');
INSERT INTO `monthhistorydata` VALUES ('36', '4', '0', '0', '0', '0', 'Ab:,,,3.13E-003,,,,1.85E-002;Ec:,,,,,,,;Fl:01200,002.8,27.0,35.0,000.0,31.7,16.1,01.2,3,401;Ga:,,,,3.60E-001,,;Gi:,,,,1.98E-002,,;Me:0.00e+000,0.0,0,,+0.0,0.0,000,,,;Oi:,,,,,,;Rn:4.82E+000,2.12E-001,,1.31E-001,2.15E-001,', '2015-12-25 19:15:06', '');
INSERT INTO `monthhistorydata` VALUES ('37', '2', '953', '669.3', '441.2', '0', '0:42:40', '2015-12-25 19:15:24', '');
INSERT INTO `monthhistorydata` VALUES ('38', '5', '10012', '0', '0', '0', '关盖_无雨', '2015-12-25 19:15:49', '');
INSERT INTO `monthhistorydata` VALUES ('39', '2', '970', '669.3', '441.2', '0', '0:39:40', '2015-12-28 20:05:00', '');
INSERT INTO `monthhistorydata` VALUES ('40', '2', '970', '669.3', '441.2', '0', '0:39:40', '2015-12-28 20:08:31', ' ');
INSERT INTO `monthhistorydata` VALUES ('41', '2', '970', '669.3', '441.2', '0', '0:39:40', '2015-12-28 20:08:36', ' ');
INSERT INTO `monthhistorydata` VALUES ('42', '5', '10012', '0', '0', '0', '关盖_无雨', '2015-12-28 20:08:51', ' ');
INSERT INTO `monthhistorydata` VALUES ('43', '5', '10012', '0', '0', '0', '关盖_无雨', '2015-12-28 20:08:55', ' ');
INSERT INTO `monthhistorydata` VALUES ('44', '4', '0', '0', '0', '0', 'Ab:,,,3.13E-003,,,,1.85E-002;Ec:,,,,,,,;Fl:01200,002.8,27.0,35.0,000.0,31.7,16.1,01.2,3,401;Ga:,,,,3.60E-001,,;Gi:,,,,1.98E-002,,;Me:0.00e+000,0.0,0,,+0.0,0.0,000,,,;Oi:,,,,,,;Rn:4.82E+000,2.12E-001,,1.31E-001,2.15E-001,', '2015-12-28 20:09:14', ' ');
INSERT INTO `monthhistorydata` VALUES ('45', '4', '0', '0', '0', '0', 'Ab:,,,3.13E-003,,,,1.85E-002;Ec:,,,,,,,;Fl:01200,002.8,27.0,35.0,000.0,31.7,16.1,01.2,3,401;Ga:,,,,3.60E-001,,;Gi:,,,,1.98E-002,,;Me:0.00e+000,0.0,0,,+0.0,0.0,000,,,;Oi:,,,,,,;Rn:4.82E+000,2.12E-001,,1.31E-001,2.15E-002,', '2015-12-28 20:09:28', ' ');
INSERT INTO `monthhistorydata` VALUES ('46', '2', '970', '669.3', '441.2', '0', '0:39:40', '2015-12-28 20:12:40', ' ');
INSERT INTO `monthhistorydata` VALUES ('47', '2', '953', '669.3', '441.2', '0', '0:42:40', '2015-12-28 20:12:53', ' ');
INSERT INTO `monthhistorydata` VALUES ('48', '2', '953', '669.3', '441.2', '0', '0:42:40', '2015-12-28 20:12:58', ' ');
INSERT INTO `monthhistorydata` VALUES ('49', '2', '953', '669.3', '441.2', '0', '0:42:40', '2015-12-28 20:13:22', ' ');
INSERT INTO `monthhistorydata` VALUES ('50', '2', '953', '669.3', '441.2', '0', '0:42:40', '2015-12-28 20:13:36', ' ');
INSERT INTO `monthhistorydata` VALUES ('51', '2', '953', '669.3', '441.2', '0', '0:42:40', '2015-12-28 20:24:34', ' ');
INSERT INTO `monthhistorydata` VALUES ('52', '2', '953', '669.3', '441.2', '0', '0:42:40', '2015-12-28 20:24:41', ' ');
INSERT INTO `monthhistorydata` VALUES ('53', '2', '970', '669.3', '441.2', '0', '0:39:40', '2015-12-28 20:24:55', ' ');
INSERT INTO `monthhistorydata` VALUES ('54', '2', '435', '799.3', '741.2', '0', '0:42:40', '2015-12-28 20:26:09', ' ');
INSERT INTO `monthhistorydata` VALUES ('55', '5', '10012', '0', '0', '0', '开盖_降雨', '2015-12-28 20:27:47', ' ');
INSERT INTO `monthhistorydata` VALUES ('56', '5', '10012', '0', '0', '0', '开盖_降雨', '2015-12-28 20:27:51', ' ');
INSERT INTO `monthhistorydata` VALUES ('57', '4', '0', '0', '0', '0', 'Ab:,,,3.13E-003,,,,1.85E-002;Ec:,,,,,,,;Fl:01200,002.8,27.0,35.0,000.0,31.7,16.1,01.2,3,401;Ga:,,,,3.60E-001,,;Gi:,,,,1.98E-002,,;Me:0.00e+000,0.0,0,,+0.0,0.0,000,,,;Oi:,,,,,,;Rn:4.82E+000,2.12E-001,,1.31E-001,2.15E-001,', '2015-12-28 20:28:18', ' ');
INSERT INTO `monthhistorydata` VALUES ('58', '5', '10012', '0', '0', '0', '关盖_无雨', '2015-12-28 21:19:09', ' ');

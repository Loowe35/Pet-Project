-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3307
-- Время создания: Июл 03 2024 г., 20:03
-- Версия сервера: 8.0.30
-- Версия PHP: 7.2.34

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `Econom`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Cargoes`
--

CREATE TABLE `Cargoes` (
  `Cargo_ID` int NOT NULL,
  `Cargo_Name` varchar(255) DEFAULT NULL,
  `Volume` decimal(10,2) DEFAULT NULL,
  `Weight` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Cargoes`
--

INSERT INTO `Cargoes` (`Cargo_ID`, `Cargo_Name`, `Volume`, `Weight`) VALUES
(1, 'Молоко', '3.00', '132.00'),
(2, 'Вода', '123.00', '123.00'),
(3, 'Кефир', '12.00', '234.00'),
(4, 'Масло', '1324.00', '1432.00'),
(5, 'Сыворотка', '2.50', '234.00');

-- --------------------------------------------------------

--
-- Структура таблицы `Drivers`
--

CREATE TABLE `Drivers` (
  `Driver_ID` int NOT NULL,
  `Last_Name` varchar(255) DEFAULT NULL,
  `First_Name` varchar(255) DEFAULT NULL,
  `Patronymic` varchar(255) DEFAULT NULL,
  `Passport_Series_and_Number` varchar(255) DEFAULT NULL,
  `Phone_Number` varchar(20) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `Driving_License_Expiry_Date` date DEFAULT NULL,
  `Login` varchar(255) DEFAULT NULL,
  `Password` varchar(255) DEFAULT NULL,
  `Photo` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Drivers`
--

INSERT INTO `Drivers` (`Driver_ID`, `Last_Name`, `First_Name`, `Patronymic`, `Passport_Series_and_Number`, `Phone_Number`, `Email`, `Driving_License_Expiry_Date`, `Login`, `Password`, `Photo`) VALUES
(1, 'Кокшаров', 'Максим', 'Викторович', '8017564213', '89451784223', 'Loowe228@yandex.ru', '2032-03-10', '1', '1234', 'кок.jpg'),
(2, 'Букреев', 'Артем', 'Иванович', '8945612451', '91984949498', 'Artem@yandex.ru', '2029-07-11', '123', '123', ''),
(7, 'Пыталев', 'Олег', 'Максимович', '2564562562', '56376573754', 'oleg.pytalev@gmail.com', '2024-03-30', '534', 'sadf', ''),
(11, 'Корнеев', 'Игнат', 'Римович', '3245432645', '56346354764', 'Ignat@yandex.ru', '2032-03-10', '54312', '1234', ''),
(12, 'Парадеевич', 'Александр', 'Алексеевич', '8014854126', '89145263174', 'Parad@yandex.ru', '2033-04-21', '342', '542', ''),
(13, 'Чернов', 'Вадим', 'Витальевьч', '8015426513', '89195264711', 'Vadim@yandex.ru', '2029-11-23', '987', '4567', NULL);

--
-- Триггеры `Drivers`
--
DELIMITER $$
CREATE TRIGGER `Check_Email_Unique_ForDriver` BEFORE INSERT ON `Drivers` FOR EACH ROW BEGIN
    DECLARE email_count INT;
    SELECT COUNT(*) INTO email_count FROM Drivers WHERE Email = NEW.Email;
    IF email_count > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Email уже используется';
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `Check_Email_Unique_Update_ForDriver` BEFORE UPDATE ON `Drivers` FOR EACH ROW BEGIN
    DECLARE email_count INT;
    SELECT COUNT(*) INTO email_count FROM Drivers WHERE Email = NEW.Email AND Driver_ID != NEW.Driver_ID;
    IF email_count > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Email уже используется';
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `Check_Passport_Unique_ForDriver` BEFORE INSERT ON `Drivers` FOR EACH ROW BEGIN
    DECLARE passport_count INT;
    SELECT COUNT(*) INTO passport_count FROM Drivers WHERE Passport_Series_and_Number = NEW.Passport_Series_and_Number;
    IF passport_count > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Паспортные данные уже используются';
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `Check_Passport_Unique_Update_ForDriver` BEFORE UPDATE ON `Drivers` FOR EACH ROW BEGIN
    DECLARE passport_count INT;
    SELECT COUNT(*) INTO passport_count FROM Drivers WHERE Passport_Series_and_Number = NEW.Passport_Series_and_Number AND Driver_ID != NEW.Driver_ID;
    IF passport_count > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Паспортные данные уже используются';
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `Check_Phone_Number_Unique_ForDriver` BEFORE INSERT ON `Drivers` FOR EACH ROW BEGIN
    DECLARE phone_count INT;
    SELECT COUNT(*) INTO phone_count FROM Drivers WHERE Phone_Number = NEW.Phone_Number;
    IF phone_count > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Номер телефона уже используется';
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `Check_Phone_Number_Unique_Update_ForDriver` BEFORE UPDATE ON `Drivers` FOR EACH ROW BEGIN
    DECLARE phone_count INT;
    SELECT COUNT(*) INTO phone_count FROM Drivers WHERE Phone_Number = NEW.Phone_Number AND Driver_ID != NEW.Driver_ID;
    IF phone_count > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Номер телефона уже используется';
    END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Структура таблицы `Roads`
--

CREATE TABLE `Roads` (
  `Road_ID` int NOT NULL,
  `Road_Name` varchar(255) DEFAULT NULL,
  `Road_Length` decimal(10,2) DEFAULT NULL,
  `Arrival_Point` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Roads`
--

INSERT INTO `Roads` (`Road_ID`, `Road_Name`, `Road_Length`, `Arrival_Point`) VALUES
(1, 'е30', '20.00', 'Аксаково'),
(2, 'е143', '30.00', 'Раевка'),
(36, 'м5', '178.00', 'Уфа'),
(37, 'м7', '123.00', 'Кандры'),
(38, 'м5', '3425.00', 'Казань'),
(39, 'ывпы', '345.00', 'ывпа'),
(40, 'ваып', '324.00', 'выа'),
(41, 'ыфва', '234.00', 'ыфа'),
(42, 'выаф', '234.00', 'фыав'),
(43, 'sadf', '324.00', 'dsaf'),
(44, 'adsf', '324.00', 'sfdg'),
(45, 'asdf', '234.00', 'dfsa'),
(46, 'sdfg', '345.00', 'fdsg'),
(47, 'вап', '35.00', 'авр'),
(48, 'ыва', '243.00', 'ывп'),
(49, 'фвы', '324.00', 'ывфа'),
(50, 'ывфа', '324.00', 'ывфа'),
(51, 'Заюрать молоко', '231.00', 'Кармаскалы'),
(52, 'Забрать молоко', '360.00', 'Уфа'),
(53, 'Забрать молоко', '360.00', 'Уфа'),
(54, 'авыф', '234.00', 'ваыф'),
(55, 'авыф', '234.00', 'ваыф'),
(56, 'аыва', '43.00', 'выап'),
(57, 'Забрать молоко', '360.00', 'Уфа'),
(58, 'пвыа', '43.00', 'вапы'),
(59, 'Забрать молоко', '80.00', 'Раевка'),
(60, 'Забрать молоко', '180.00', 'Уфа'),
(61, 'Забрать воду', '180.00', 'Уфа'),
(62, 'забрать', '124.00', 'фпав'),
(63, 'рапр', '45.00', 'апрв'),
(64, 'Забрать молоко', '78.00', 'Раевка'),
(65, 'Забрать молоко', '78.00', 'Новосепяшево'),
(66, 'Забрать молоко', '60.00', 'Баймурзино'),
(67, 'Забрать молоко', '70.00', 'Алексеевка'),
(68, 'Забрать молоко', '45.00', 'Тукай');

-- --------------------------------------------------------

--
-- Структура таблицы `Routes`
--

CREATE TABLE `Routes` (
  `Route_ID` int NOT NULL,
  `Route_Name` varchar(255) DEFAULT NULL,
  `Starting_Point` varchar(255) DEFAULT NULL,
  `Ending_Point` varchar(255) DEFAULT NULL,
  `Route_Length` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Routes`
--

INSERT INTO `Routes` (`Route_ID`, `Route_Name`, `Starting_Point`, `Ending_Point`, `Route_Length`) VALUES
(16, 'Забрать молоко', 'Приютово', 'Белебей', '40.00'),
(17, 'sdfs', 'adsf', 'sadf', '123123.00'),
(34, 'Отвести молоко', 'Белебей', 'Уфа', '178.00'),
(35, 'Забрать сыворотку', 'Белебей', 'Октябрьский', '98.00'),
(36, 'Отвести кефир', 'Белебей', 'Раевка', '80.00'),
(37, 'Отвести воду', 'Белебей', 'Надеждино', '20.00'),
(38, 'ваып', 'вап', 'выап', '423.00'),
(39, 'ыфва', 'фыва', 'фыва', '2131.00'),
(40, 'выаф', 'фыва', 'фыва', '213.00'),
(41, 'sadf', 'asdf', 'adsf', '3241.00'),
(42, 'adsf', 'sadf', 'adsf', '342.00'),
(43, 'asdf', 'adsf', 'asdf', '324.00'),
(44, 'Забрать молоко', 'Уфа', 'Белебей', '234.00'),
(45, 'вап', 'ваыпы', 'ВАПЫ', '234.00'),
(46, 'ыва', 'фвыа', 'фвыа', '1234.00'),
(47, 'фвы', 'ыфва', 'ывфа', '4213.00'),
(48, 'ывфа', 'ыавф', 'фвыа', '324.00'),
(49, 'Заюрать молоко', 'Белебей', 'Кармаскалы', '432.00'),
(50, 'Забрать молоко', 'Белебей', 'Белебей', '360.00'),
(51, 'Забрать молоко', 'Белебей', 'Белебей', '360.00'),
(52, 'авыф', 'ывфа', 'ыва', '234.00'),
(53, 'м5', 'ыва', 'выа', '23.00'),
(54, 'Забрать молоко', 'Белебей', 'Белебей', '360.00'),
(55, 'пвыа', 'выап', 'выап', '43.00'),
(56, 'Забрать молоко', 'Белебей', 'Раевка', '80.00'),
(57, 'Забрать молоко', 'Белебей', 'Уфа', '180.00'),
(58, 'Забрать воду', 'Белебей', 'Уфа', '180.00'),
(59, 'забрать', '123', 'фыа', '231.00'),
(60, 'рапр', 'павр', 'варп', '345.00'),
(61, 'Забрать молоко', 'Белебей', 'Балкан', '50.00'),
(62, 'Забрать молоко', 'Белебей', 'Раевка', '70.00'),
(63, 'Забрать молоко', 'Белебей', 'Раевка', '78.00'),
(64, 'Забрать молоко', 'Белебей', 'Новосепяшево', '78.00'),
(65, 'Забрать молоко', 'Белебей', 'Баймурзино', '59.00'),
(66, 'Забрать молоко', 'Белебей', 'Алексеевка', '70.00'),
(67, 'Забрать молоко', 'Белебей', 'Тукай', '45.00');

-- --------------------------------------------------------

--
-- Структура таблицы `Route_Section`
--

CREATE TABLE `Route_Section` (
  `Route_Section_ID` int NOT NULL,
  `Route_Number` int DEFAULT NULL,
  `Road_Number` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Route_Section`
--

INSERT INTO `Route_Section` (`Route_Section_ID`, `Route_Number`, `Road_Number`) VALUES
(1, 16, 1),
(2, 17, 2),
(35, 34, 36),
(36, 35, 37),
(37, 36, 38),
(38, 37, 39),
(39, 38, 40),
(40, 39, 41),
(41, 40, 42),
(42, 41, 43),
(43, 42, 44),
(44, 43, 45),
(45, 44, 46),
(46, 45, 47),
(47, 46, 48),
(48, 47, 49),
(49, 48, 50),
(50, 49, 51),
(51, 50, 52),
(52, 51, 53),
(53, 52, 54),
(54, 52, 55),
(55, 53, 56),
(56, 54, 57),
(57, 55, 58),
(58, 56, 59),
(59, 57, 60),
(60, 58, 61),
(61, 59, 62),
(62, 60, 63),
(63, 63, 64),
(64, 64, 65),
(65, 65, 66),
(66, 66, 67),
(67, 67, 68);

-- --------------------------------------------------------

--
-- Структура таблицы `Transport`
--

CREATE TABLE `Transport` (
  `Transport_ID` int NOT NULL,
  `Brand` varchar(255) DEFAULT NULL,
  `Model` varchar(255) DEFAULT NULL,
  `year_of_release` date DEFAULT NULL,
  `License_Plate` varchar(255) DEFAULT NULL,
  `body_volume` decimal(10,2) DEFAULT NULL,
  `Average_Fuel_Consumption` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Transport`
--

INSERT INTO `Transport` (`Transport_ID`, `Brand`, `Model`, `year_of_release`, `License_Plate`, `body_volume`, `Average_Fuel_Consumption`) VALUES
(1, 'Hino 30', 'Dutro', '2015-03-11', 'О171ТА', '4.15', '18.60'),
(2, 'УАЗ', '3303', '1992-07-17', 'А111АА', '1.50', '13.80'),
(3, 'Isuzu', 'NQR 90', '2023-06-16', 'Е111КХ', '4.45', '14.70'),
(6, 'ISUZU', 'GIGA', '2024-03-21', 'А000АА', '2.00', '15.70'),
(7, 'Isuzu', 'NQR 110', '2024-03-14', 'А213АА', '4.50', '15.70'),
(8, 'Hino 35', 'Dutro', '2020-07-17', 'Е121КХ', '4.20', '14.00');

--
-- Триггеры `Transport`
--
DELIMITER $$
CREATE TRIGGER `Check_Brand_Model_Unique` BEFORE INSERT ON `Transport` FOR EACH ROW BEGIN
    DECLARE brand_model_count INT;
    SELECT COUNT(*) INTO brand_model_count FROM Transport WHERE Brand = NEW.Brand AND Model = NEW.Model;
    IF brand_model_count > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Транспорт с такой маркой и моделью уже существует';
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `Check_Brand_Model_Unique_Update` BEFORE UPDATE ON `Transport` FOR EACH ROW BEGIN
    DECLARE brand_model_count INT;
    SELECT COUNT(*) INTO brand_model_count FROM Transport WHERE Brand = NEW.Brand AND Model = NEW.Model AND Transport_ID != NEW.Transport_ID;
    IF brand_model_count > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Транспорт с такой маркой и моделью уже существует';
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `Check_Plate_Unique` BEFORE INSERT ON `Transport` FOR EACH ROW BEGIN
    DECLARE plate_count INT;
    SELECT COUNT(*) INTO plate_count FROM Transport WHERE License_Plate = NEW.License_Plate;
    IF plate_count > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Гос. номер уже используется!';
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `Check_Plate_Unique_Update` BEFORE UPDATE ON `Transport` FOR EACH ROW BEGIN
    DECLARE plate_count INT;
    SELECT COUNT(*) INTO plate_count FROM Transport WHERE License_Plate = NEW.License_Plate AND Transport_ID != NEW.Transport_ID;
    IF plate_count > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Гос. номер уже используется!';
    END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Структура таблицы `Transport_Expenses`
--

CREATE TABLE `Transport_Expenses` (
  `Expense_ID` int NOT NULL,
  `Waybill_ID` int DEFAULT NULL,
  `Fuel` decimal(10,2) DEFAULT NULL,
  `Maintenance_and_Repair` decimal(10,2) DEFAULT NULL,
  `Forced_Downtime` decimal(10,2) DEFAULT NULL,
  `Losses_due_to_Downtime` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Transport_Expenses`
--

INSERT INTO `Transport_Expenses` (`Expense_ID`, `Waybill_ID`, `Fuel`, `Maintenance_and_Repair`, `Forced_Downtime`, `Losses_due_to_Downtime`) VALUES
(1, 1, '34.40', '234.00', '2.00', '200.00'),
(2, 2, '34.40', '123.00', '2.00', '234.00'),
(3, 19, '34.40', '123.00', '32.00', '2341.00'),
(4, 20, '34.40', '123.00', '1243.00', '21341.00'),
(5, 21, '34.40', '123.00', '4132.00', '43124.00'),
(6, 22, '34.40', '2134.00', '1243.00', '1432.00'),
(7, 23, '34.40', '1234.00', '3142.00', '4312.00'),
(26, 23, '34.40', '43213.00', '23.00', '234.00'),
(27, 23, '34.40', '6200.00', '3.00', '300.00'),
(28, 23, '34.40', '6200.00', '3.00', '300.00'),
(29, 23, '34.40', '4200.00', '1.00', '100.00'),
(30, 23, '34.40', '4132.00', '32.00', '2332.00'),
(31, 23, '34.40', '234.00', '23.00', '1234.00'),
(32, 31, '8.00', '34345.00', '32.00', '3245.00'),
(33, 23, '34.40', '500.00', '1.00', '100.00'),
(34, 23, '34.40', '2150.00', '3.00', '300.00'),
(35, 23, '34.40', '2450.00', '5.00', '500.00');

-- --------------------------------------------------------

--
-- Структура таблицы `Users`
--

CREATE TABLE `Users` (
  `User_ID` int NOT NULL,
  `Last_Name` varchar(255) DEFAULT NULL,
  `First_Name` varchar(255) DEFAULT NULL,
  `Patronymic` varchar(255) DEFAULT NULL,
  `date_of_birth` date DEFAULT NULL,
  `Passport_Series_and_Number` varchar(255) DEFAULT NULL,
  `Place_of_Residence` varchar(255) DEFAULT NULL,
  `Actual_Residential_Address` varchar(255) DEFAULT NULL,
  `Phone_Number` varchar(20) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `Login` varchar(255) DEFAULT NULL,
  `Password` varchar(255) DEFAULT NULL,
  `Position` varchar(255) DEFAULT NULL,
  `Status` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Users`
--

INSERT INTO `Users` (`User_ID`, `Last_Name`, `First_Name`, `Patronymic`, `date_of_birth`, `Passport_Series_and_Number`, `Place_of_Residence`, `Actual_Residential_Address`, `Phone_Number`, `Email`, `Login`, `Password`, `Position`, `Status`) VALUES
(1, 'Шакиров', 'Марсель', 'Маратович', '1992-07-09', '2543243525', 'Хадии 30', 'Революционеров 1', '89374509535', 'Shakirov.mmm@yandex.ru', '1', '12', 'Логист', 'Работает'),
(2, 'Гордеев', 'Иван', 'Олегович', '2004-05-21', '2014541287', 'Красная 34', 'Грозненская 12', '84512036415', 'Shakirov.mmmm@yandex.ru', '2', '123', 'Логист', 'Уволен'),
(4, 'Алексеева', 'Ксения', 'Олеговна', '2004-02-26', '8017663541', 'Красноармейская 32', 'Ленина 45', '89374509582', 'Ksenia@mail.ru', '4', '4', 'Экономист', 'Работает'),
(8, 'Пермякова ', 'Мария', 'Сергеевна', '2000-02-10', '3542637586', 'Красная 12', 'Красная 12', '65431527686', 'MAria@yandex.ru', '123', '123', 'Экономист', 'Работает'),
(9, 'Магадеев', 'Богдан', 'Ринатович', '2001-07-13', '1352436542', 'революционная 21', 'Хадии 23', '26546345634', 'Shakirrdov.mmm@yandex.ru', '13', '1', 'Логист', 'Уволен'),
(10, 'Ахметзянова', 'Элина', 'Ринатовна', '2004-07-21', '8017666315', 'Аургазинская 23', 'Аургазинская 23', '89174518762', 'Elina.22@yandex.ru', 'Elina', '12qwer', 'Экономист', 'Работает'),
(11, 'Красный', 'Белый', 'Олег', '1991-03-08', '8898898484', 'ываы', 'впавы', '89492849849', 'Loowe228@yandex.ru', '321', '1', 'Логист', 'Работает'),
(12, 'Костромин', 'Данил', 'Олегович', '1990-02-15', '1231231231', 'Красная 54', 'Красная 54', '89656145201', 'Danil.koster@yandex.ru', '514', '1234', 'Экономист', 'Работает'),
(13, 'ывфа', 'выаф', 'чмяс', '2000-02-02', '8945168799', 'впаы', 'авыыв', '86468846864', 'shakirom.mmm@yandex.ru', '1ыв', 'ацу', 'Проводник', 'Работает');

--
-- Триггеры `Users`
--
DELIMITER $$
CREATE TRIGGER `Check_Passport_Unique` BEFORE INSERT ON `Users` FOR EACH ROW BEGIN
    DECLARE passport_count INT;
    SELECT COUNT(*) INTO passport_count FROM Users WHERE Passport_Series_and_Number = NEW.Passport_Series_and_Number;
    IF passport_count > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Номер паспорта уже существует, выберите другой!';
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `Check_Passport_Unique_Update` BEFORE UPDATE ON `Users` FOR EACH ROW BEGIN
    DECLARE passport_count INT;
    SELECT COUNT(*) INTO passport_count FROM Users WHERE Passport_Series_and_Number = NEW.Passport_Series_and_Number AND User_ID != NEW.User_ID;
    IF passport_count > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Номер паспорта уже существует, выберите другой!';
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `Check_Phone_Unique` BEFORE INSERT ON `Users` FOR EACH ROW BEGIN
    DECLARE phone_count INT;
    SELECT COUNT(*) INTO phone_count FROM Users WHERE Phone_Number = NEW.Phone_Number;
    IF phone_count > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Телефон уже существует!';
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `Check_Phone_Unique_Update` BEFORE UPDATE ON `Users` FOR EACH ROW BEGIN
    DECLARE phone_count INT;
    SELECT COUNT(*) INTO phone_count FROM Users WHERE Phone_Number = NEW.Phone_Number AND User_ID != NEW.User_ID;
    IF phone_count > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Телефон уже существует!';
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `Chek_Email_unique` BEFORE INSERT ON `Users` FOR EACH ROW BEGIN
    DECLARE email_count INT;
    SELECT COUNT(*) INTO email_count FROM Users WHERE Email = NEW.Email;
    IF email_count > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Почта уже существует!';
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `Chek_Email_unique_Update` BEFORE UPDATE ON `Users` FOR EACH ROW BEGIN
    DECLARE email_count INT;
    SELECT COUNT(*) INTO email_count FROM Users WHERE Email = NEW.Email AND User_ID != NEW.User_ID;
    IF email_count > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Почта уже существует!';
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `check_login_unique` BEFORE INSERT ON `Users` FOR EACH ROW BEGIN
    DECLARE username_count INT;
    SELECT COUNT(*) INTO username_count FROM Users WHERE Login = NEW.Login;
    IF username_count > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Логины не могут повторяться!';
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `check_login_unique_uppdate` BEFORE UPDATE ON `Users` FOR EACH ROW BEGIN
    DECLARE username_count INT;
    SELECT COUNT(*) INTO username_count FROM Users WHERE Login = NEW.Login AND User_ID != NEW.User_ID;
    IF username_count > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Логин уже существует!';
    END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Структура таблицы `Waybill`
--

CREATE TABLE `Waybill` (
  `Waybill_ID` int NOT NULL,
  `Driver_Number` int DEFAULT NULL,
  `Transport_Number` int DEFAULT NULL,
  `Route_Number` int DEFAULT NULL,
  `Cargo_Number` int DEFAULT NULL,
  `User_Number` int DEFAULT NULL,
  `Departure_Date` date DEFAULT NULL,
  `Arrival_Date` datetime DEFAULT NULL,
  `Photo` blob,
  `Comment` text,
  `Status` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Waybill`
--

INSERT INTO `Waybill` (`Waybill_ID`, `Driver_Number`, `Transport_Number`, `Route_Number`, `Cargo_Number`, `User_Number`, `Departure_Date`, `Arrival_Date`, `Photo`, `Comment`, `Status`) VALUES
(1, 1, 1, 16, 2, 1, '2024-06-17', '2024-06-18 00:00:00', NULL, NULL, 'Отправлено водителю'),
(2, 2, 2, 17, 1, 1, '2024-03-26', '2024-03-27 00:00:00', NULL, NULL, ''),
(19, 7, 2, 17, 1, 1, '2024-04-07', '2024-04-08 00:00:00', NULL, NULL, ''),
(20, 2, 1, 36, 1, 1, '2024-03-28', '2024-03-29 00:00:00', NULL, NULL, ''),
(21, 1, 1, 37, 1, 1, '2024-04-07', '2024-04-08 00:00:00', NULL, NULL, ''),
(22, 1, 2, 38, 1, 1, '2024-03-28', '2024-03-29 00:00:00', NULL, NULL, ''),
(23, 1, 3, 44, 2, 1, '2024-03-30', '2024-03-31 00:00:00', NULL, NULL, 'Обновленный статус'),
(24, 2, 2, 48, 2, 1, '2024-03-29', '2024-03-30 00:00:00', NULL, NULL, NULL),
(25, 7, 6, 49, 4, 1, '2024-04-10', '2024-04-17 00:00:00', NULL, NULL, NULL),
(26, 12, NULL, 50, 1, 1, '2024-04-18', '2024-04-20 00:00:00', NULL, NULL, NULL),
(27, 11, NULL, 51, 1, 1, '2024-04-18', '2024-04-20 00:00:00', NULL, NULL, NULL),
(28, NULL, NULL, 52, 1, 1, '2024-04-17', '2024-04-18 00:00:00', NULL, NULL, NULL),
(29, 1, 3, 53, 1, 1, '2024-05-29', '2024-05-31 00:00:00', NULL, NULL, 'Отправлено водителю'),
(30, 12, 1, 54, 1, 1, '2024-04-23', '2024-04-24 00:00:00', NULL, NULL, 'Отправлено водителю'),
(31, 1, 1, 55, 1, 1, '2024-06-18', '2024-06-19 00:00:00', NULL, NULL, 'Принято'),
(32, 2, 2, 56, 1, 1, '2024-04-25', '2024-04-27 00:00:00', NULL, NULL, 'Отправлено водителю'),
(33, 11, 2, 57, 1, 1, '2024-04-16', '2024-04-17 00:00:00', NULL, NULL, NULL),
(34, 7, 1, 58, 1, 1, '2024-04-17', '2024-04-18 00:00:00', NULL, NULL, NULL),
(35, 1, 2, 59, 2, 1, '2024-05-10', '2024-05-11 00:00:00', NULL, NULL, NULL),
(36, 1, 1, 60, 1, 1, '2024-05-18', '2024-05-20 00:00:00', NULL, NULL, NULL),
(37, 7, 1, 63, 1, 1, '2024-05-29', '2024-05-31 00:00:00', NULL, NULL, NULL),
(38, 1, 1, 64, 1, 1, '2024-06-01', '2024-06-03 00:00:00', NULL, NULL, NULL),
(39, 1, 6, 65, 1, 1, '2024-06-10', '2024-06-11 00:00:00', NULL, NULL, NULL),
(40, 7, 6, 66, 1, 1, '2024-06-06', '2024-06-07 00:00:00', NULL, NULL, NULL),
(41, 7, 7, 67, 1, 1, '2024-06-17', '2024-06-18 00:00:00', NULL, NULL, NULL);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Cargoes`
--
ALTER TABLE `Cargoes`
  ADD PRIMARY KEY (`Cargo_ID`);

--
-- Индексы таблицы `Drivers`
--
ALTER TABLE `Drivers`
  ADD PRIMARY KEY (`Driver_ID`);

--
-- Индексы таблицы `Roads`
--
ALTER TABLE `Roads`
  ADD PRIMARY KEY (`Road_ID`);

--
-- Индексы таблицы `Routes`
--
ALTER TABLE `Routes`
  ADD PRIMARY KEY (`Route_ID`);

--
-- Индексы таблицы `Route_Section`
--
ALTER TABLE `Route_Section`
  ADD PRIMARY KEY (`Route_Section_ID`),
  ADD KEY `Route_Number` (`Route_Number`),
  ADD KEY `Road_Number` (`Road_Number`);

--
-- Индексы таблицы `Transport`
--
ALTER TABLE `Transport`
  ADD PRIMARY KEY (`Transport_ID`);

--
-- Индексы таблицы `Transport_Expenses`
--
ALTER TABLE `Transport_Expenses`
  ADD PRIMARY KEY (`Expense_ID`),
  ADD KEY `Waybill_ID` (`Waybill_ID`);

--
-- Индексы таблицы `Users`
--
ALTER TABLE `Users`
  ADD PRIMARY KEY (`User_ID`);

--
-- Индексы таблицы `Waybill`
--
ALTER TABLE `Waybill`
  ADD PRIMARY KEY (`Waybill_ID`),
  ADD KEY `Driver_Number` (`Driver_Number`),
  ADD KEY `Transport_Number` (`Transport_Number`),
  ADD KEY `Route_Number` (`Route_Number`),
  ADD KEY `Cargo_Number` (`Cargo_Number`),
  ADD KEY `User_Number` (`User_Number`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `Cargoes`
--
ALTER TABLE `Cargoes`
  MODIFY `Cargo_ID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `Drivers`
--
ALTER TABLE `Drivers`
  MODIFY `Driver_ID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT для таблицы `Roads`
--
ALTER TABLE `Roads`
  MODIFY `Road_ID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=69;

--
-- AUTO_INCREMENT для таблицы `Routes`
--
ALTER TABLE `Routes`
  MODIFY `Route_ID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=68;

--
-- AUTO_INCREMENT для таблицы `Route_Section`
--
ALTER TABLE `Route_Section`
  MODIFY `Route_Section_ID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=68;

--
-- AUTO_INCREMENT для таблицы `Transport`
--
ALTER TABLE `Transport`
  MODIFY `Transport_ID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT для таблицы `Transport_Expenses`
--
ALTER TABLE `Transport_Expenses`
  MODIFY `Expense_ID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

--
-- AUTO_INCREMENT для таблицы `Users`
--
ALTER TABLE `Users`
  MODIFY `User_ID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT для таблицы `Waybill`
--
ALTER TABLE `Waybill`
  MODIFY `Waybill_ID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=42;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `Route_Section`
--
ALTER TABLE `Route_Section`
  ADD CONSTRAINT `route_section_ibfk_1` FOREIGN KEY (`Route_Number`) REFERENCES `Routes` (`Route_ID`),
  ADD CONSTRAINT `route_section_ibfk_2` FOREIGN KEY (`Road_Number`) REFERENCES `Roads` (`Road_ID`);

--
-- Ограничения внешнего ключа таблицы `Transport_Expenses`
--
ALTER TABLE `Transport_Expenses`
  ADD CONSTRAINT `fk_transport_expenses_waybill` FOREIGN KEY (`Waybill_ID`) REFERENCES `Waybill` (`Waybill_ID`);

--
-- Ограничения внешнего ключа таблицы `Waybill`
--
ALTER TABLE `Waybill`
  ADD CONSTRAINT `waybill_ibfk_1` FOREIGN KEY (`Driver_Number`) REFERENCES `Drivers` (`Driver_ID`),
  ADD CONSTRAINT `waybill_ibfk_2` FOREIGN KEY (`Transport_Number`) REFERENCES `Transport` (`Transport_ID`),
  ADD CONSTRAINT `waybill_ibfk_3` FOREIGN KEY (`Route_Number`) REFERENCES `Routes` (`Route_ID`),
  ADD CONSTRAINT `waybill_ibfk_4` FOREIGN KEY (`Cargo_Number`) REFERENCES `Cargoes` (`Cargo_ID`),
  ADD CONSTRAINT `waybill_ibfk_5` FOREIGN KEY (`User_Number`) REFERENCES `Users` (`User_ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

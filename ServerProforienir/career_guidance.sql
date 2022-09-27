-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Июн 07 2020 г., 19:40
-- Версия сервера: 5.7.24
-- Версия PHP: 7.2.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `career_guidance`
--

-- --------------------------------------------------------

--
-- Структура таблицы `account`
--

DROP TABLE IF EXISTS `account`;
CREATE TABLE IF NOT EXISTS `account` (
  `id_account` int(11) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Индекс пользователя в системе',
  `id_account_type` int(11) UNSIGNED NOT NULL COMMENT 'Индекс уровня доступа',
  `FIO` varchar(70) NOT NULL COMMENT 'ФИО пользователя',
  `login` varchar(30) NOT NULL COMMENT 'Логин',
  `password` varchar(32) NOT NULL COMMENT 'Пароль',
  `status` tinyint(1) NOT NULL DEFAULT '0' COMMENT 'Пометка на удаление',
  `mail` varchar(80) NOT NULL COMMENT 'Почта',
  `activation` varchar(6) NOT NULL COMMENT 'Статус активации аккаунта (0 - не актив., пусто - актив.)',
  PRIMARY KEY (`id_account`),
  UNIQUE KEY `id_account` (`id_account`),
  KEY `id_account_type` (`id_account_type`)
) ENGINE=InnoDB AUTO_INCREMENT=171 DEFAULT CHARSET=utf8 COMMENT='Пользователь';

--
-- Дамп данных таблицы `account`
--

INSERT INTO `account` (`id_account`, `id_account_type`, `FIO`, `login`, `password`, `status`, `mail`, `activation`) VALUES
(1, 1, 'Сапунова Евгения Сергеевна', 'admin', 'd8bfe09dcc7b59e9f9331ab804d30ac4', 0, 'sapunova12-7@mail.ru', '8'),
(5, 2, 'Берников Анатолий Петрович', 'bern3', 'd8bfe09dcc7b59e9f9331ab804d30ac4', 0, 'sapunova12-7@mail.ru', ''),
(6, 2, 'Вывантов Михаил Денисович', 'vivaverona', 'd8bfe09dcc7b59e9f9331ab804d30ac4', 1, 'sapunova12-7@mail.ru', ''),
(7, 3, 'Сапунова Евгения Сергеевна', 'evg1', 'd8bfe09dcc7b59e9f9331ab804d30ac4', 0, 'sapunova12-7@mail.ru', ''),
(8, 3, 'Камков Алексей Сергеевич', '', '', 0, '', '0'),
(9, 3, 'Камков Владимир Андреевич', '', '', 0, '', '0'),
(10, 3, 'Комаров Александр Алексеевич', '', '', 0, '', '0'),
(11, 3, 'Политкин Александр Александрович', '', '', 0, '', '0'),
(12, 3, 'Морозов Александр Владимирович', '', '', 0, '', '0'),
(13, 3, 'Овчинников Тимур Андреевич', '', '', 0, '', '0'),
(14, 3, 'Олейник Александр Геннадьевич', '', '', 0, '', '0'),
(15, 3, 'Хлопков Павел Павлович', '', '', 0, '', '0'),
(16, 3, 'Кучерявенко Дмитрий Романович', '', '', 0, '', '0'),
(17, 3, 'Максутов Ильяс Алексеевич', '', '', 0, '', '0'),
(18, 3, 'Сафонов Александр Антонович', '', '', 0, '', '0'),
(19, 3, 'Васина Наталья Сергеевна', '', '', 0, '', '0'),
(20, 3, 'Борт Людмила Вячеславовна', '', '', 0, '', '0'),
(21, 3, 'Антипова Полина Николаевна', '', '', 0, '', '0'),
(22, 3, 'Архангельский Николай Сергеевич', '', '', 0, '', '0'),
(23, 3, 'Баракатова Анастасия Дмитриевна', '', '', 0, '', '0'),
(24, 3, 'Букреев Дмитрий Юрьевич', '', '', 0, '', '0'),
(25, 3, 'Каленюк Анна Анатольевна', '', '', 0, '', '0'),
(26, 3, 'Осипова Ольга Евгеньевна', '', '', 0, '', '0'),
(27, 3, 'Уварова Анастасия Андреевна', '', '', 0, '', '0'),
(28, 3, 'Хадиева Альбина Ильсурова', '', '', 0, '', '0'),
(29, 3, 'Храпов Никита Витальевич', '', '', 0, '', '0'),
(30, 3, 'Варганов Артем Вадимович', '', '', 0, '', '0'),
(31, 3, 'Черняков Иван Владимирович', '', '', 0, '', '0'),
(32, 3, 'Деревянкин Денис Сергеевич', '', '', 0, '', '0'),
(33, 3, 'Диденко Полина Андреевна', '', '', 0, '', '0'),
(34, 3, 'Кириллов Сергей Игоревич', '', '', 0, '', '0'),
(35, 3, 'Колесникова Ольга Вячеславовна', '', '', 0, '', '0'),
(36, 3, 'Теняков Алексей Сергеевич', '', '', 0, '', '0'),
(37, 3, 'Хохлов Антон Викторович', '', '', 0, '', '0'),
(38, 3, 'Максутов Ильяс Алексеевич', '', '', 0, '', '0'),
(39, 3, 'Авраменко Николай Игоревич', '', '', 0, '', '0'),
(40, 3, 'Аверина Анастасия Русланова', '', '', 0, '', '0'),
(41, 3, 'Батюшкова Юлия Андреевна', '', '', 0, '', '0'),
(42, 3, 'Ерюкин Кирилл Дмитриевич', '', '', 0, '', '0'),
(43, 3, 'Фомин Дмитрий Иванович', '', '', 0, '', '0'),
(44, 3, 'Артюхин Михаил Владимирович', '', '', 0, '', '0'),
(45, 3, 'Борейко Елизавета Александровна', '', '', 0, '', '0'),
(46, 3, 'Бутузов Павел Вячеславович', '', '', 0, '', '0'),
(47, 3, 'Денисов Михаил Олегович', '', '', 0, '', '0'),
(48, 3, 'Жиров Андрей Викторович', '', '', 0, '', '0'),
(49, 3, 'Константинова Любовь Александровна', '', '', 0, '', '0'),
(50, 3, 'Кремешная Мария Игоревна', '', '', 0, '', '0'),
(51, 3, 'Кундин Дмитрий Сергеевич', '', '', 0, '', '0'),
(52, 3, 'Петрова Полина Владиславовна', '', '', 0, '', '0'),
(53, 3, 'Стасюк Дмитрий Викторович', '', '', 0, '', '0'),
(54, 3, 'Оверчук Никита Викторович', '', '', 0, '', '0'),
(55, 3, 'Чистов Михаил Игоревич', '', '', 0, '', '0'),
(56, 3, 'Абдульбаров Рустам Тахирович', 'rrrust', 'd8bfe09dcc7b59e9f9331ab804d30ac4', 0, 'sapunova12-7@mail.ru', ''),
(57, 3, 'Умаров Сино Махмаднодирович', '', '', 0, '', '0'),
(58, 3, 'Адамова Оксана Николаевна', '', '', 0, '', '0'),
(59, 3, 'Брынчик Валерия Игоревна', '', '', 0, '', '0'),
(60, 3, 'Горбачев Илья Вячеславович', '', '', 0, '', '0'),
(61, 3, 'Зуйков Денис Михайлович', '', '', 0, '', '0'),
(62, 3, 'Куренных Алексей Евгеньевич', '', '', 0, '', '0'),
(63, 3, 'Пахомов Евгений Валерьевич', '', '', 0, '', '0'),
(64, 3, 'Першин Алексей Вячеславович', '', '', 0, '', '0'),
(65, 3, 'Андреев Илья Владимирович', '', '', 0, '', '0'),
(67, 3, 'Алисин Алексей Климович', '', '', 0, '', '0'),
(68, 3, 'Гамаюнов Дмитрий Михайлович', '', '', 0, '', '0'),
(69, 3, 'Пюра Виктория Сергеевна', '', '', 0, '', '0'),
(70, 3, 'Басова Александра Николаевна', '', '', 0, '', '0'),
(71, 3, 'Зайцев Михаил Николаевич', '', '', 0, '', '0'),
(72, 3, 'Рославлев Павел Сергеевич', '', '', 0, '', '0'),
(73, 3, 'Яблоков Олег Алексеевич', '', '', 0, '', '0'),
(74, 3, 'Цапро Артем Владимирович', '', '', 0, '', '0'),
(75, 3, 'Меньков Андрей Александрович', '', '', 0, '', '0'),
(76, 3, 'Ахмадуллин Алмаз Газинурович', '', '', 0, '', '0'),
(77, 3, 'Свищев Алексей Константинович', '', '', 0, '', '0'),
(78, 3, 'Максимов Семен Викторович', '', '', 0, '', '0'),
(79, 3, 'Рубцов Антон Евгеньевич', '', '', 0, '', '0'),
(80, 3, 'Савина Анастасия Дмитриевна', '', '', 0, '', '0'),
(81, 3, 'Винников Андрей Юрьевич', '', '', 0, '', '0'),
(82, 3, 'Лобанов Никита Алексеевич', '', '', 0, '', '0'),
(83, 3, 'Козырев Никита Владимирович', '', '', 0, '', '0'),
(84, 3, 'Лысов Глеб Викторович', '', '', 0, '', '0'),
(85, 3, 'Сидякин Даниил Геннадьевич', '', '', 0, '', '0'),
(86, 3, 'Пчелкин Игорь Витальевич', '', '', 0, '', '0'),
(87, 3, 'Липкин Илья Антонович', '', '', 0, '', '0'),
(88, 3, 'Мартышенский Богдан Анатольевич', '', '', 0, '', '0'),
(89, 3, 'Балалаев Максим Сергеевич', '', '', 0, '', '0'),
(90, 3, 'Новикова Анна Евгеньевна', '', '', 0, '', '0'),
(91, 3, 'Цветков Никита Алексеевич', '', '', 0, '', '0'),
(92, 3, 'Баранова Алена Михайловна', '', '', 0, '', '0'),
(93, 3, 'Федотикова Мария Владимировна', '', '', 0, '', '0'),
(94, 3, 'Самсонов Олег Васильевич', '', '', 0, '', '0'),
(95, 3, 'Кольцова Алина Викторовна', '', '', 0, '', '0'),
(96, 3, 'Сорокин Вадим Алексеевич', '', '', 0, '', '0'),
(97, 3, 'Троян Саргис Арамович', '', '', 0, '', '0'),
(98, 3, 'Киселев Дмитрий Андреевич', '', '', 0, '', '0'),
(99, 3, 'Кутузова Евгения Игоревна', '', '', 0, '', '0'),
(100, 3, 'Давыдова Дарья Андреевна', '', '', 0, '', '0'),
(101, 3, 'Букреев Артем Александрович', '', '', 0, '', '0'),
(102, 3, 'Королев Павел Владиславович', '', '', 0, '', '0'),
(103, 3, 'Каменев Георгий Александрович', '', '', 0, '', '0'),
(104, 3, 'Шошин Дмитрий Дмитриевич', '', '', 0, '', '0'),
(105, 3, 'Кулинич Даниил Сергеевич', '', '', 0, '', '0'),
(106, 3, 'Амирова Татьяна Феликсовна', '', '', 0, '', '0'),
(107, 3, 'Дедюлин Андрей Дмитриевич', '', '', 0, '', '0'),
(108, 3, 'Сенченков Андрей Викторович', '', '', 0, '', '0'),
(109, 3, 'Золотухин Дмитрий Александрович', '', '', 0, '', '0'),
(110, 3, 'Ломанов Данислав Олегович', '', '', 0, '', '0'),
(111, 3, 'Моисеев Владислав Андреевич', '', '', 0, '', '0'),
(112, 3, 'Мамарина Евгения Андреевна', '', '', 0, '', '0'),
(113, 3, 'Шехматов Дмирий Сергеевич', '', '', 0, '', '0'),
(114, 3, 'Миляев Денис Владиславович', '', '', 0, '', '0'),
(115, 3, 'Ашутов Игорь Алексеевич', '', '', 0, '', '0'),
(116, 3, 'Ржевский Артемий Дмитриевич', '', '', 0, '', '0'),
(117, 3, 'Смирнов Артем Сергеевич', '', '', 0, '', '0'),
(118, 3, 'Каргин Кирилл Сергеевич', '', '', 0, '', '0'),
(119, 3, 'Буевич Павел Игоревич', '', '', 0, '', '0'),
(120, 3, 'Касаткин Александр Сергеевич', '', '', 0, '', '0'),
(121, 3, 'Куличин Даниил Сергеевич', '', '', 0, '', '0'),
(122, 3, 'Кузнецов Кирилл Евгеньевич', '', '', 0, '', '0'),
(123, 3, 'Попов Александр Михайлович', '', '', 0, '', '0'),
(124, 3, 'Солнцев Кирилл Владимирович', '', '', 0, '', '0'),
(125, 3, 'Божков Кирилл Евгеньевич', '', '', 0, '', '0'),
(126, 3, 'Гордеева Мария Евгеньевна', '', '', 0, '', '0'),
(127, 3, 'Зайцев Дмитрий Николаевич', '', '', 0, '', '0'),
(128, 3, 'Вяткин Павел Михайлович', '', '', 0, '', '0'),
(129, 3, 'Баранов Денис Игоревич', '', '', 0, '', '0'),
(130, 3, 'Кашкин Вадим Сергеевич', '', '', 0, '', '0'),
(131, 3, 'Бисерова Катрина Алексеевна', '', '', 0, '', '0'),
(132, 3, 'Окунев Никита Юрьевич', '', '', 0, '', '0'),
(133, 3, 'Жданова Виктория Андреевна', '', '', 0, '', '0'),
(134, 3, 'Корольков Максим Дмитриевич', '', '', 0, '', '0'),
(135, 3, 'Власов Валерий Игоревич', '', '', 0, '', '0'),
(136, 3, 'Пенькова Алина Олеговна', '', '', 0, '', '0'),
(137, 3, 'Лукашин Кирилл Дмитриевич', '', '', 0, '', '0'),
(138, 3, 'Ибрагимов Родион Рустамович', '', '', 0, '', '0'),
(139, 3, 'Кондратенко Юрий Юрьевич', '', '', 0, '', '0'),
(140, 3, 'Козлов Степан Романович', '', '', 0, '', '0'),
(141, 3, 'Оськин Иван Дмитриевич', '', '', 0, '', '0'),
(142, 3, 'Имамиева Диана Эльмировна', '', '', 0, '', '0'),
(143, 3, 'Ляпин Георий Алексеевич', '', '', 0, '', '0'),
(144, 3, 'Сычев Максим Игоревич', '', '', 0, '', '0'),
(145, 3, 'Крылов Иван Романович', '', '', 0, '', '0'),
(146, 3, 'Ситникова Александра Николаевна', '', '', 0, '', '0'),
(147, 3, 'Пузырев Леонид Дмитриевич', '', '', 0, '', '0'),
(148, 3, 'Смирнов Алексей Юрьевич', '', '', 0, '', '0'),
(149, 3, 'Гораев Григорий Евгеньевич', '', '', 0, '', '0'),
(150, 3, 'Ханов Дамир Уралович', '', '', 0, '', '0'),
(151, 3, 'Рубан Петр Олегович', '', '', 0, '', '0'),
(152, 3, 'Лавров Илья Владимирович', '', '', 0, '', '0'),
(153, 3, 'Кравченко Дмитрий Сергеевич', '', '', 0, '', '0'),
(154, 3, 'Зимаков Данила Юрьевич', '', '', 0, '', '0'),
(155, 3, 'Глухова Дарья Алексеевна', '', '', 0, '', '0'),
(156, 3, 'Тимошин Данила Юрьевич', '', '', 0, '', '0'),
(157, 3, 'Казаков Владислав Сергеевич', '', '', 0, '', '0'),
(158, 3, 'Решетник Андрей Владимирович', '', '', 0, '', '0'),
(159, 3, 'Санакина Софья Андреевна', '', '', 0, '', '0'),
(160, 3, 'Павлов Олег Владимирович', '', '', 0, '', '0'),
(161, 3, 'Калинкин Павел Антонович', '', '', 0, '', '0'),
(162, 3, 'Шибин Владислав Геннадьевич', '', '', 0, '', '0'),
(163, 3, 'Роженко Евгения Владиславовна', '', '', 0, '', '0'),
(164, 3, 'Горбик Николай Игоревич', '', '', 0, '', '0'),
(165, 3, 'Еремеев Георгий Андреевич', '', '', 0, '', '0'),
(166, 3, 'Скворцова Екатерина Геннадьевна', '', '', 0, '', '0'),
(167, 3, 'Пенькова Полина Алексеевна', '', '', 0, '', '0'),
(168, 3, 'Новиков Роман Алексеевич', '', '', 0, '', '0'),
(169, 2, 'Крупенко Алжир Викторович', 'ggg33', 'd8bfe09dcc7b59e9f9331ab804d30ac4', 0, 'sapunova12-7@mail.ru', ''),
(170, 3, 'Иванов Иван Иванович', '', '', 0, '', '0');

-- --------------------------------------------------------

--
-- Структура таблицы `account_type`
--

DROP TABLE IF EXISTS `account_type`;
CREATE TABLE IF NOT EXISTS `account_type` (
  `id_account_type` int(11) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Индекс уровня доступа',
  `name_account_type` varchar(20) NOT NULL COMMENT 'Название уровня доступа',
  PRIMARY KEY (`id_account_type`),
  UNIQUE KEY `id_account_type` (`id_account_type`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='Уровень доступа пользователя';

--
-- Дамп данных таблицы `account_type`
--

INSERT INTO `account_type` (`id_account_type`, `name_account_type`) VALUES
(1, 'администратор'),
(2, 'сотрудник'),
(3, 'студент');

-- --------------------------------------------------------

--
-- Структура таблицы `action_plan`
--

DROP TABLE IF EXISTS `action_plan`;
CREATE TABLE IF NOT EXISTS `action_plan` (
  `id_action_plan` int(11) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Индекс записи в плане проведения мероприятий',
  `id_event` int(11) UNSIGNED NOT NULL COMMENT 'Индекс мероприятия',
  `date_event` date NOT NULL COMMENT 'Дата проведения мероприятия',
  `time_event` varchar(5) NOT NULL COMMENT 'Время проведения',
  PRIMARY KEY (`id_action_plan`),
  UNIQUE KEY `id_action_plan` (`id_action_plan`),
  KEY `id_event` (`id_event`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8 COMMENT='План проведения мероприятий';

--
-- Дамп данных таблицы `action_plan`
--

INSERT INTO `action_plan` (`id_action_plan`, `id_event`, `date_event`, `time_event`) VALUES
(1, 1, '2020-06-03', '12:00'),
(2, 2, '2019-06-03', '15:00'),
(3, 1, '2021-04-01', '12:00'),
(4, 1, '2015-12-17', '12:00'),
(9, 2, '2020-07-12', '16:15'),
(10, 2, '2020-07-17', '13:00'),
(11, 6, '2020-04-12', '12:00'),
(12, 1, '2021-04-11', '12:00'),
(13, 6, '2021-04-12', '12:00'),
(14, 3, '2016-07-15', '11:20'),
(15, 1, '2016-12-17', '14:25'),
(16, 5, '2017-03-18', '15:25'),
(17, 1, '2017-11-17', '14:30'),
(18, 1, '2018-03-16', '13:00'),
(19, 6, '2018-04-12', '11:00'),
(20, 6, '2019-08-17', '11:20'),
(21, 6, '2019-07-13', '12:35'),
(22, 2, '2019-06-14', '10:05');

-- --------------------------------------------------------

--
-- Структура таблицы `activity`
--

DROP TABLE IF EXISTS `activity`;
CREATE TABLE IF NOT EXISTS `activity` (
  `id_activity` int(11) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Индекс записи в перечне участников мероприятий',
  `id_action_plan` int(11) UNSIGNED NOT NULL COMMENT 'Индекс записи из плана проведения мероприятий',
  `id_role` int(11) UNSIGNED NOT NULL COMMENT 'Индекс роли студента в мероприятии',
  `id_account` int(11) UNSIGNED NOT NULL COMMENT 'Индекс пользователя',
  PRIMARY KEY (`id_activity`),
  UNIQUE KEY `id_activity` (`id_activity`),
  KEY `id_action_plan` (`id_action_plan`,`id_role`,`id_account`),
  KEY `id_role` (`id_role`),
  KEY `activity_ibfk_3` (`id_account`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8 COMMENT='Деятельность в течение учебы';

--
-- Дамп данных таблицы `activity`
--

INSERT INTO `activity` (`id_activity`, `id_action_plan`, `id_role`, `id_account`) VALUES
(1, 1, 1, 6),
(32, 2, 2, 136),
(31, 2, 3, 69),
(6, 3, 2, 7),
(7, 3, 3, 7),
(8, 4, 3, 7),
(17, 4, 3, 9),
(16, 4, 3, 10),
(9, 9, 1, 5),
(12, 9, 2, 7),
(34, 9, 2, 9),
(10, 9, 2, 132),
(15, 13, 2, 7),
(35, 13, 3, 13),
(18, 14, 2, 11),
(22, 15, 3, 46),
(21, 15, 3, 52),
(19, 16, 2, 43),
(20, 16, 2, 47),
(26, 17, 3, 73),
(27, 17, 3, 86),
(25, 18, 2, 52),
(24, 18, 2, 81),
(33, 18, 3, 35),
(23, 19, 3, 57),
(30, 20, 2, 105),
(29, 20, 3, 71),
(28, 21, 3, 118);

-- --------------------------------------------------------

--
-- Структура таблицы `category`
--

DROP TABLE IF EXISTS `category`;
CREATE TABLE IF NOT EXISTS `category` (
  `id_category` int(11) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Индекс категории',
  `name_category` varchar(20) NOT NULL COMMENT 'Название категории',
  PRIMARY KEY (`id_category`),
  UNIQUE KEY `id_category` (`id_category`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='Категория мероприятия';

--
-- Дамп данных таблицы `category`
--

INSERT INTO `category` (`id_category`, `name_category`) VALUES
(1, 'конкурс'),
(2, 'олимпиада'),
(3, 'выезд в школу'),
(4, 'конференция');

-- --------------------------------------------------------

--
-- Структура таблицы `degree`
--

DROP TABLE IF EXISTS `degree`;
CREATE TABLE IF NOT EXISTS `degree` (
  `id_degree` int(11) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Индекс ученой степени',
  `name_degree` varchar(20) NOT NULL COMMENT 'Название ученой степени',
  `direction` varchar(10) NOT NULL COMMENT 'Направление подготовки',
  PRIMARY KEY (`id_degree`),
  UNIQUE KEY `id_degree` (`id_degree`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='Ученая степень';

--
-- Дамп данных таблицы `degree`
--

INSERT INTO `degree` (`id_degree`, `name_degree`, `direction`) VALUES
(1, 'бакалавриат', '09.03.01'),
(2, 'магистратура', '09.03.01'),
(3, 'аспирантура', '09.03.01');

-- --------------------------------------------------------

--
-- Структура таблицы `event`
--

DROP TABLE IF EXISTS `event`;
CREATE TABLE IF NOT EXISTS `event` (
  `id_event` int(11) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Индекс мероприятия',
  `id_organizer` int(11) UNSIGNED NOT NULL COMMENT 'Индекс организатора',
  `id_category` int(11) UNSIGNED NOT NULL COMMENT 'Индекс категории',
  `name_event` varchar(80) NOT NULL COMMENT 'Название мероприятия',
  PRIMARY KEY (`id_event`),
  UNIQUE KEY `id_event` (`id_event`),
  KEY `id_organizer` (`id_organizer`,`id_category`),
  KEY `id_category` (`id_category`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COMMENT='Мароприятие';

--
-- Дамп данных таблицы `event`
--

INSERT INTO `event` (`id_event`, `id_organizer`, `id_category`, `name_event`) VALUES
(1, 1, 1, 'Конкурс интеллекта, красоты и грации «Мисс МАИ»'),
(2, 1, 1, 'IT-прорыв'),
(3, 1, 1, 'Новые таланты'),
(5, 1, 3, 'IT-технологии - это будущее'),
(6, 1, 4, 'Гагаринские чтения');

-- --------------------------------------------------------

--
-- Структура таблицы `field`
--

DROP TABLE IF EXISTS `field`;
CREATE TABLE IF NOT EXISTS `field` (
  `id_field` int(11) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Индекс сферы деятельности',
  `name_field` varchar(40) NOT NULL COMMENT 'Название сферы деятельности',
  PRIMARY KEY (`id_field`),
  UNIQUE KEY `id_field` (`id_field`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='Сфера деятельности';

--
-- Дамп данных таблицы `field`
--

INSERT INTO `field` (`id_field`, `name_field`) VALUES
(1, 'IT'),
(2, 'Менеджмент'),
(3, 'Медицина'),
(4, 'Строительство');

-- --------------------------------------------------------

--
-- Структура таблицы `graduate`
--

DROP TABLE IF EXISTS `graduate`;
CREATE TABLE IF NOT EXISTS `graduate` (
  `id_graduate` int(11) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Индекс выпускника',
  `id_student` int(11) UNSIGNED NOT NULL COMMENT 'Индекс студента',
  `job` int(2) NOT NULL COMMENT 'Пометка, работает ли выпускник по специальности',
  PRIMARY KEY (`id_graduate`),
  UNIQUE KEY `id_graduate` (`id_graduate`),
  KEY `id_student` (`id_student`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8 COMMENT='Выпускник';

--
-- Дамп данных таблицы `graduate`
--

INSERT INTO `graduate` (`id_graduate`, `id_student`, `job`) VALUES
(1, 2, 0),
(2, 3, 1),
(3, 4, 2),
(4, 5, 0),
(5, 6, 2),
(6, 7, 2),
(7, 8, 2),
(8, 9, 1),
(9, 10, 1),
(10, 11, 2),
(11, 12, 0),
(13, 121, 0),
(14, 59, 2),
(15, 45, 2),
(16, 32, 2);

-- --------------------------------------------------------

--
-- Структура таблицы `interest`
--

DROP TABLE IF EXISTS `interest`;
CREATE TABLE IF NOT EXISTS `interest` (
  `id_interest` int(11) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Индекс анкеты',
  `id_degree` int(11) UNSIGNED NOT NULL COMMENT 'Индекс ученой степени',
  `course` int(2) UNSIGNED NOT NULL COMMENT 'Курс обучения',
  `level_interest` int(4) UNSIGNED NOT NULL COMMENT 'Уровень заинтересованности в специальности',
  `contined_study` int(2) NOT NULL COMMENT 'В планах продолжить обучение',
  `job_now` int(2) NOT NULL COMMENT 'Работает сейчас',
  `job_plan` int(2) NOT NULL COMMENT 'Планирует работать по специальности',
  `year` int(12) NOT NULL COMMENT 'Год проведения анкетирования',
  PRIMARY KEY (`id_interest`),
  UNIQUE KEY `id_interest` (`id_interest`),
  KEY `id_degree` (`id_degree`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Заинтересованность студентов';

-- --------------------------------------------------------

--
-- Структура таблицы `labor_market`
--

DROP TABLE IF EXISTS `labor_market`;
CREATE TABLE IF NOT EXISTS `labor_market` (
  `id_labor_market` int(11) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Индекс объявления на сайте',
  `id_website` int(11) UNSIGNED NOT NULL COMMENT 'Индекс сайта ',
  `id_field` int(11) UNSIGNED NOT NULL COMMENT 'Индекс сферы работы',
  `count` int(40) NOT NULL COMMENT 'Количество вакансий',
  PRIMARY KEY (`id_labor_market`),
  UNIQUE KEY `id_labor_market` (`id_labor_market`),
  KEY `id_website` (`id_website`,`id_field`),
  KEY `id_field` (`id_field`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8 COMMENT='Рынок труда';

--
-- Дамп данных таблицы `labor_market`
--

INSERT INTO `labor_market` (`id_labor_market`, `id_website`, `id_field`, `count`) VALUES
(1, 1, 1, 678),
(2, 1, 2, 2667),
(3, 1, 3, 799),
(4, 1, 4, 1549),
(5, 3, 4, 125),
(6, 2, 1, 861),
(7, 2, 3, 2268),
(8, 2, 2, 423),
(9, 2, 4, 2319),
(10, 3, 1, 75),
(11, 3, 2, 125),
(12, 3, 3, 75),
(13, 5, 1, 4884),
(14, 5, 3, 851),
(15, 5, 2, 19464),
(16, 5, 4, 5988);

-- --------------------------------------------------------

--
-- Структура таблицы `material`
--

DROP TABLE IF EXISTS `material`;
CREATE TABLE IF NOT EXISTS `material` (
  `id_material` int(11) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Индекс материала к мероприятию',
  `id_action_plan` int(11) UNSIGNED NOT NULL COMMENT 'Индекс записи в плане проведения мероприятий',
  `path` varchar(255) NOT NULL COMMENT 'Индекс файла на диске',
  PRIMARY KEY (`id_material`),
  UNIQUE KEY `id_material` (`id_material`),
  KEY `id_action_plan` (`id_action_plan`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='Материал к мероприятиям';

--
-- Дамп данных таблицы `material`
--

INSERT INTO `material` (`id_material`, `id_action_plan`, `path`) VALUES
(3, 3, '1MvW9aTnd5zPfXPSLQ0icdOKvnhUsclqj'),
(4, 3, '1b8AiViT42uRbbAgQC5sAvpmB31PrkteT');

-- --------------------------------------------------------

--
-- Структура таблицы `organization_type`
--

DROP TABLE IF EXISTS `organization_type`;
CREATE TABLE IF NOT EXISTS `organization_type` (
  `id_organization_type` int(11) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Индекс типа организации',
  `name_organization_type` varchar(40) NOT NULL COMMENT 'Название типа организации',
  PRIMARY KEY (`id_organization_type`),
  UNIQUE KEY `id_organization_type` (`id_organization_type`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='Тип организации';

--
-- Дамп данных таблицы `organization_type`
--

INSERT INTO `organization_type` (`id_organization_type`, `name_organization_type`) VALUES
(1, 'ВУЗ'),
(3, 'школа');

-- --------------------------------------------------------

--
-- Структура таблицы `organizer`
--

DROP TABLE IF EXISTS `organizer`;
CREATE TABLE IF NOT EXISTS `organizer` (
  `id_organizer` int(11) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Индекс организации, проводящей мероприятие',
  `id_organization_type` int(11) UNSIGNED NOT NULL COMMENT 'Индекс типа организации',
  `name_organizer` varchar(40) NOT NULL COMMENT 'Название организации',
  PRIMARY KEY (`id_organizer`),
  UNIQUE KEY `id_organizer` (`id_organizer`),
  KEY `id_organization_type` (`id_organization_type`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COMMENT='Организатор мероприятия';

--
-- Дамп данных таблицы `organizer`
--

INSERT INTO `organizer` (`id_organizer`, `id_organization_type`, `name_organizer`) VALUES
(1, 1, 'МАИ'),
(2, 1, 'МЭИ'),
(5, 1, 'МИРЭА');

-- --------------------------------------------------------

--
-- Структура таблицы `person`
--

DROP TABLE IF EXISTS `person`;
CREATE TABLE IF NOT EXISTS `person` (
  `idPerson` int(11) NOT NULL AUTO_INCREMENT COMMENT 'Индекс абитуриента',
  `Birthday` date DEFAULT NULL,
  `BirthPlace` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `PersonSexID` int(11) DEFAULT NULL,
  `FirstName` varchar(100) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'Имя абитуриента',
  `MiddleName` varchar(100) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'Отчество абитуриента',
  `LastName` varchar(100) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'Фамилия абитуриента',
  `KOATUUCodeL1ID` int(11) DEFAULT NULL,
  `KOATUUCodeL2ID` int(11) DEFAULT NULL,
  `KOATUUCodeL3ID` int(11) DEFAULT NULL,
  `IsResident` tinyint(4) DEFAULT NULL,
  `PersonEducationTypeID` int(11) DEFAULT NULL,
  `StreetTypeID` int(11) DEFAULT NULL,
  `Address` varchar(250) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `HomeNumber` char(10) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `PostIndex` char(10) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `SchoolID` int(11) DEFAULT NULL,
  `FirstNameR` varchar(100) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `MiddleNameR` varchar(100) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `LastNameR` varchar(100) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `LanguageID` int(11) NOT NULL,
  `CountryID` int(11) NOT NULL,
  `PhotoName` varchar(250) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `isCampus` tinyint(4) DEFAULT NULL COMMENT '0 - нет необходимости в общежитии,\n1 - есть необходимость в общежитии.',
  `Modified` datetime DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL COMMENT 'Дата подачи заявления на поступление',
  `SysUserID` int(11) DEFAULT NULL,
  `codeU` char(40) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'Код персоны в базе данных ЕДБО',
  `edboID` int(11) DEFAULT NULL COMMENT 'Идентификатор персоны в базе данных ЕДБО',
  `isSamaSchoolAddr` tinyint(4) NOT NULL,
  PRIMARY KEY (`idPerson`),
  KEY `fk_person_5` (`SchoolID`),
  KEY `fk_Person_1` (`PersonSexID`),
  KEY `fk_person_3` (`PersonEducationTypeID`),
  KEY `fk_person_4` (`StreetTypeID`),
  KEY `fk_Person_2` (`KOATUUCodeL3ID`),
  KEY `fk_person_6` (`KOATUUCodeL2ID`),
  KEY `fk_person_7` (`KOATUUCodeL1ID`),
  KEY `fk_person_8` (`LanguageID`),
  KEY `fk_person_9` (`SysUserID`),
  KEY `idPerson` (`idPerson`),
  KEY `idPerson_2` (`idPerson`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `person`
--

INSERT INTO `person` (`idPerson`, `Birthday`, `BirthPlace`, `PersonSexID`, `FirstName`, `MiddleName`, `LastName`, `KOATUUCodeL1ID`, `KOATUUCodeL2ID`, `KOATUUCodeL3ID`, `IsResident`, `PersonEducationTypeID`, `StreetTypeID`, `Address`, `HomeNumber`, `PostIndex`, `SchoolID`, `FirstNameR`, `MiddleNameR`, `LastNameR`, `LanguageID`, `CountryID`, `PhotoName`, `isCampus`, `Modified`, `CreateDate`, `SysUserID`, `codeU`, `edboID`, `isSamaSchoolAddr`) VALUES
(7, '2000-02-06', 'Москва', 2, 'Лолита', 'Сергеевна', 'Третьяк', 1, 1, 2, 1, NULL, 0, '13', '56', '109462', NULL, 'Лолита', 'Сергеевна', 'Третьяк', 2, 643, '180x240.gif', NULL, NULL, '2020-05-21 19:59:28', 3, '', NULL, 1),
(8, '1998-09-28', 'г. Москва', 1, 'Андрей', 'Драгишаевич', 'Мицич', 1, 1, 3, 1, NULL, 0, '90', '24', '109461', NULL, 'Андрей', 'Драгишаевич', 'Мицич', 2, 643, '180x240.gif', NULL, NULL, '2020-05-22 20:14:59', 3, '', NULL, 1),
(9, '2001-07-04', 'г. Москва', 1, 'Виталий ', 'Александрович', 'Терещенко', 1, 1, 1, 1, NULL, 0, '23', '76', '123124', 1, 'Виталий ', 'Александрович', 'Терещенко', 4, 643, '180x240.gif', NULL, NULL, '2020-05-22 20:29:33', 3, '', NULL, 1),
(10, '2001-12-05', 'г. Москва', 1, 'Иван', 'Иванович', 'Иванов', 1, 1, 1, 1, NULL, 1, '213123', '1231', '165421', 1, 'Иван', 'Иванович', 'Иванов', 2, 643, '180x240.gif', NULL, NULL, '2020-05-20 17:20:11', 3, '', NULL, 1),
(11, '2002-01-01', 'г. Москва', 1, 'Алексей', 'Аркадьевич', 'Пермяков', 1, 1, 1, 1, NULL, 0, '25', '94', '123124', NULL, 'Алексей', 'Аркадьевич', 'Пермяков', 3, 643, '180x240.gif', NULL, NULL, '2020-05-20 17:20:15', 3, '', NULL, 0),
(12, '2001-03-04', 'г. Москва', 1, 'Константин', 'Викторович', 'Зародов', 1, 1, 3, 1, NULL, 3, '213123', '123123', '123124', NULL, 'Константин', 'Викторович', 'Зародов', 2, 643, '180x240.gif', NULL, NULL, '2020-05-20 17:20:19', 3, '', NULL, 1),
(13, '2001-01-01', 'г. Москва', 1, 'Виктор', 'Викторович', 'Колюшкин', 1, 1, NULL, 1, NULL, 1, '213123', '94', '123124', NULL, 'Виктор', 'Викторович', 'Колюшкин', 2, 643, '180x240.gif', NULL, NULL, '2020-05-20 17:20:21', 3, '', NULL, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `personcontacts`
--

DROP TABLE IF EXISTS `personcontacts`;
CREATE TABLE IF NOT EXISTS `personcontacts` (
  `idPersonContacts` int(11) NOT NULL AUTO_INCREMENT,
  `PersonID` int(11) DEFAULT NULL,
  `PersonContactTypeID` int(11) DEFAULT NULL,
  `Value` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `Value2` varchar(100) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `Modified` datetime DEFAULT NULL COMMENT 'Дата последней модификации',
  `SysUserID` int(11) DEFAULT NULL COMMENT 'Пользователь, внесший последнюю модификацию',
  PRIMARY KEY (`idPersonContacts`),
  KEY `fk_PersonContacts_1` (`PersonID`),
  KEY `fk_PersonContacts_2` (`PersonContactTypeID`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `personcontacts`
--

INSERT INTO `personcontacts` (`idPersonContacts`, `PersonID`, `PersonContactTypeID`, `Value`, `Value2`, `Modified`, `SysUserID`) VALUES
(13, 7, 1, '84995005472', 'nul@mail.ru', NULL, NULL),
(14, 7, 2, '89263260498', 'mic@yandex.ru', NULL, NULL),
(15, 8, 1, '1232133333', NULL, NULL, NULL),
(16, 8, 2, '12345312345', NULL, NULL, NULL),
(17, 9, 1, '1232133333', NULL, NULL, NULL),
(18, 9, 2, '12345312345', NULL, NULL, NULL),
(19, 10, 1, '1232133333', NULL, NULL, NULL),
(20, 10, 2, '12345312345', NULL, NULL, NULL),
(21, 11, 1, '1232133333', 'cas@gmail.com', NULL, NULL),
(22, 11, 2, '12345312345', NULL, NULL, NULL),
(23, 12, 1, '1232133333', NULL, NULL, NULL),
(24, 12, 2, '12345312345', NULL, NULL, NULL),
(25, 13, 1, '1232133333', NULL, NULL, NULL),
(26, 13, 2, '12345312345', NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Структура таблицы `personcontacttypes`
--

DROP TABLE IF EXISTS `personcontacttypes`;
CREATE TABLE IF NOT EXISTS `personcontacttypes` (
  `idPersonContactType` int(11) NOT NULL COMMENT 'Индекс типа личных контактов',
  `PersonContactTypeName` char(10) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'Название типа',
  PRIMARY KEY (`idPersonContactType`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `personcontacttypes`
--

INSERT INTO `personcontacttypes` (`idPersonContactType`, `PersonContactTypeName`) VALUES
(1, 'Телефон'),
(2, 'Мобильный'),
(3, 'e-mail'),
(4, 'VK'),
(5, 'Skype');

-- --------------------------------------------------------

--
-- Структура таблицы `personolympiad`
--

DROP TABLE IF EXISTS `personolympiad`;
CREATE TABLE IF NOT EXISTS `personolympiad` (
  `idPersonOlympiad` int(11) NOT NULL AUTO_INCREMENT COMMENT 'Индекс перечня заслуг абитуриентов',
  `PersonID` int(11) DEFAULT NULL COMMENT 'Индекс абитуриента',
  `OlympiadAwarID` int(11) DEFAULT NULL COMMENT 'Индекс олимпиады',
  `edboID` int(11) DEFAULT NULL,
  PRIMARY KEY (`idPersonOlympiad`),
  KEY `fk_PersonOlympiad_1` (`OlympiadAwarID`),
  KEY `fk_PersonOlympiad_2` (`PersonID`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8 COMMENT='Список олимпиад персоны';

--
-- Дамп данных таблицы `personolympiad`
--

INSERT INTO `personolympiad` (`idPersonOlympiad`, `PersonID`, `OlympiadAwarID`, `edboID`) VALUES
(1, 10, 220, NULL),
(2, 10, 221, NULL),
(3, 11, 235, NULL),
(4, 11, 236, NULL),
(5, 11, 237, NULL),
(6, 11, 238, NULL),
(7, 7, 235, NULL),
(8, 13, 235, NULL),
(9, 13, 239, NULL);

-- --------------------------------------------------------

--
-- Структура таблицы `role`
--

DROP TABLE IF EXISTS `role`;
CREATE TABLE IF NOT EXISTS `role` (
  `id_role` int(11) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Индекс роли в мероприятии',
  `name_role` varchar(20) NOT NULL COMMENT 'Название роли',
  PRIMARY KEY (`id_role`),
  UNIQUE KEY `id_role` (`id_role`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='Роль в мероприятии';

--
-- Дамп данных таблицы `role`
--

INSERT INTO `role` (`id_role`, `name_role`) VALUES
(1, 'организатор'),
(2, 'выступающий'),
(3, 'зритель');

-- --------------------------------------------------------

--
-- Структура таблицы `student`
--

DROP TABLE IF EXISTS `student`;
CREATE TABLE IF NOT EXISTS `student` (
  `id_student` int(11) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Индекс студента',
  `id_account` int(11) UNSIGNED NOT NULL COMMENT 'Индекс учетной записи',
  `id_degree` int(11) UNSIGNED NOT NULL COMMENT 'Индекс ученой степени',
  `exam_score` int(9) UNSIGNED NOT NULL COMMENT 'Средний балл ЕГЭ',
  `entrance` int(12) UNSIGNED NOT NULL COMMENT 'Год поступления',
  `expulsion` int(12) UNSIGNED NOT NULL COMMENT 'Год отчисления',
  `ending` int(12) UNSIGNED NOT NULL COMMENT 'Год окончания',
  PRIMARY KEY (`id_student`),
  UNIQUE KEY `id_student` (`id_student`),
  KEY `id_account` (`id_account`,`id_degree`),
  KEY `id_degree` (`id_degree`)
) ENGINE=InnoDB AUTO_INCREMENT=164 DEFAULT CHARSET=utf8 COMMENT='Студент';

--
-- Дамп данных таблицы `student`
--

INSERT INTO `student` (`id_student`, `id_account`, `id_degree`, `exam_score`, `entrance`, `expulsion`, `ending`) VALUES
(1, 7, 1, 211, 2016, 0, 2020),
(2, 8, 1, 161, 2015, 0, 2019),
(3, 9, 1, 150, 2015, 0, 2019),
(4, 10, 1, 147, 2015, 0, 2019),
(5, 11, 1, 131, 2015, 0, 2019),
(6, 12, 1, 171, 2015, 0, 2019),
(7, 13, 1, 168, 2015, 0, 2019),
(8, 14, 1, 149, 2015, 0, 2019),
(9, 15, 1, 155, 2015, 0, 2019),
(10, 16, 1, 127, 2015, 0, 2019),
(11, 17, 1, 177, 2015, 0, 2019),
(12, 18, 1, 201, 2015, 0, 2019),
(13, 19, 1, 162, 2015, 0, 2019),
(14, 20, 1, 142, 2015, 0, 2019),
(15, 21, 1, 238, 2015, 0, 2019),
(16, 22, 1, 240, 2015, 0, 2019),
(17, 23, 1, 236, 2015, 0, 2019),
(18, 24, 1, 246, 2015, 0, 2019),
(19, 25, 1, 248, 2015, 0, 2019),
(20, 26, 1, 246, 2015, 0, 2019),
(21, 27, 1, 259, 2015, 0, 2019),
(22, 28, 1, 260, 2015, 0, 2019),
(23, 29, 1, 239, 2015, 0, 2019),
(24, 30, 1, 230, 2015, 0, 2019),
(25, 31, 2, 85, 2015, 0, 2017),
(26, 32, 2, 82, 2015, 0, 2017),
(27, 33, 2, 71, 2015, 0, 2017),
(28, 34, 2, 72, 2015, 0, 2017),
(29, 35, 2, 67, 2015, 0, 2017),
(30, 36, 2, 68, 2015, 0, 2017),
(31, 37, 2, 83, 2015, 0, 2017),
(32, 17, 1, 177, 2016, 0, 2020),
(33, 39, 1, 191, 2016, 0, 2020),
(34, 40, 1, 223, 2016, 0, 2020),
(35, 41, 1, 233, 2016, 0, 2020),
(36, 42, 1, 219, 2016, 0, 2020),
(37, 43, 1, 218, 2016, 0, 2020),
(38, 44, 1, 222, 2016, 0, 2020),
(39, 45, 1, 211, 2016, 0, 2020),
(40, 46, 1, 215, 2016, 0, 2020),
(41, 47, 1, 212, 2016, 0, 2020),
(42, 48, 1, 214, 2016, 0, 2020),
(43, 49, 1, 208, 2016, 0, 2020),
(44, 50, 1, 210, 2016, 0, 2020),
(45, 51, 1, 202, 2016, 0, 2020),
(46, 52, 1, 218, 2016, 0, 2020),
(47, 53, 1, 215, 2016, 0, 2020),
(48, 54, 1, 207, 2016, 0, 2020),
(49, 55, 1, 221, 2016, 0, 2020),
(50, 56, 1, 225, 2016, 0, 2020),
(51, 57, 1, 200, 2016, 0, 2020),
(52, 58, 2, 84, 2016, 0, 2018),
(53, 59, 2, 94, 2016, 0, 2018),
(54, 60, 2, 76, 2016, 0, 2018),
(55, 61, 2, 105, 2016, 0, 2018),
(56, 62, 2, 103, 2016, 0, 2018),
(57, 63, 2, 72, 2016, 0, 2018),
(58, 64, 2, 76, 2016, 0, 2018),
(59, 65, 2, 66, 2016, 0, 2018),
(61, 67, 1, 273, 2017, 0, 2021),
(62, 68, 1, 241, 2017, 0, 2021),
(63, 69, 1, 239, 2017, 0, 2021),
(64, 70, 1, 231, 2017, 0, 2021),
(65, 71, 1, 228, 2017, 0, 2021),
(66, 72, 1, 235, 2017, 0, 2021),
(67, 73, 1, 226, 2017, 0, 2021),
(68, 74, 1, 225, 2017, 0, 2021),
(69, 75, 1, 219, 2017, 0, 2021),
(70, 76, 1, 218, 2017, 0, 2021),
(71, 77, 1, 216, 2017, 0, 2021),
(72, 78, 1, 215, 2017, 0, 2021),
(73, 79, 1, 261, 2017, 0, 2021),
(74, 80, 1, 243, 2017, 0, 2021),
(75, 81, 1, 230, 2017, 0, 2021),
(76, 82, 1, 221, 2017, 0, 2021),
(77, 83, 1, 220, 2017, 0, 2021),
(78, 84, 1, 220, 2017, 0, 2021),
(79, 85, 1, 210, 2017, 0, 2021),
(80, 86, 1, 212, 2017, 0, 2021),
(81, 87, 1, 216, 2017, 0, 2021),
(82, 88, 1, 217, 2017, 0, 2021),
(83, 89, 1, 218, 2017, 0, 2021),
(84, 90, 1, 226, 2017, 0, 2021),
(85, 91, 1, 250, 2017, 0, 2021),
(86, 92, 1, 249, 2017, 0, 2021),
(87, 93, 2, 99, 2017, 0, 2019),
(88, 94, 2, 61, 2017, 0, 2019),
(89, 95, 2, 100, 2017, 0, 2019),
(90, 96, 2, 62, 2017, 0, 2019),
(91, 97, 2, 65, 2017, 0, 2019),
(92, 98, 2, 76, 2017, 0, 2019),
(93, 99, 2, 86, 2017, 0, 2019),
(94, 100, 2, 90, 2017, 0, 2019),
(95, 101, 2, 67, 2017, 0, 2019),
(96, 102, 1, 257, 2018, 0, 2022),
(97, 103, 1, 247, 2018, 0, 2022),
(98, 104, 1, 235, 2018, 0, 2022),
(99, 105, 1, 231, 2018, 0, 2022),
(100, 106, 1, 228, 2018, 0, 2022),
(101, 107, 1, 227, 2018, 0, 2022),
(102, 108, 1, 224, 2018, 0, 2022),
(103, 109, 1, 222, 2018, 0, 2022),
(104, 110, 1, 220, 2018, 0, 2022),
(105, 111, 1, 250, 2018, 0, 2022),
(106, 112, 1, 240, 2018, 0, 2022),
(107, 113, 1, 236, 2018, 0, 2022),
(108, 114, 1, 232, 2018, 0, 2022),
(109, 115, 1, 230, 2018, 0, 2022),
(110, 116, 1, 229, 2018, 0, 2022),
(111, 117, 1, 227, 2018, 0, 2022),
(112, 118, 1, 229, 2018, 0, 2022),
(113, 119, 1, 230, 2018, 0, 2022),
(114, 120, 1, 221, 2018, 0, 2022),
(115, 121, 1, 231, 2018, 0, 2022),
(116, 122, 1, 235, 2018, 0, 2022),
(117, 123, 1, 245, 2018, 0, 2022),
(118, 124, 1, 230, 2018, 0, 2022),
(119, 125, 1, 227, 2018, 0, 2022),
(120, 126, 2, 97, 2018, 0, 2020),
(121, 127, 2, 93, 2018, 0, 2020),
(122, 128, 2, 82, 2018, 0, 2020),
(123, 129, 2, 75, 2018, 0, 2020),
(124, 130, 2, 70, 2018, 0, 2020),
(125, 131, 2, 65, 2018, 0, 2020),
(126, 132, 2, 52, 2018, 0, 2020),
(127, 133, 2, 101, 2018, 0, 2020),
(128, 134, 1, 274, 2019, 0, 2023),
(129, 135, 1, 250, 2019, 0, 2023),
(130, 136, 1, 246, 2019, 0, 2023),
(131, 137, 1, 239, 2019, 0, 2023),
(132, 138, 1, 237, 2019, 0, 2023),
(133, 139, 1, 229, 2019, 0, 2023),
(134, 140, 1, 228, 2019, 0, 2023),
(135, 141, 1, 227, 2019, 0, 2023),
(136, 142, 1, 276, 2019, 0, 2023),
(137, 143, 1, 268, 2019, 0, 2023),
(138, 144, 1, 265, 2019, 0, 2023),
(139, 145, 1, 246, 2019, 0, 2023),
(140, 146, 1, 243, 2019, 0, 2023),
(141, 147, 1, 243, 2019, 0, 2023),
(142, 148, 1, 246, 2019, 0, 2023),
(143, 149, 1, 260, 2019, 0, 2023),
(144, 150, 1, 227, 2019, 0, 2023),
(145, 151, 1, 230, 2019, 0, 2023),
(146, 152, 1, 231, 2019, 0, 2023),
(147, 153, 1, 232, 2019, 0, 2023),
(148, 154, 1, 238, 2019, 0, 2023),
(149, 155, 1, 242, 2019, 0, 2023),
(150, 156, 1, 241, 2019, 0, 2023),
(151, 157, 1, 231, 2019, 0, 2023),
(152, 158, 1, 227, 2019, 0, 2023),
(153, 159, 2, 101, 2019, 0, 2021),
(154, 160, 2, 93, 2019, 0, 2021),
(155, 161, 2, 88, 2019, 0, 2021),
(156, 162, 2, 82, 2019, 0, 2021),
(157, 163, 2, 78, 2019, 0, 2021),
(158, 164, 2, 58, 2019, 0, 2021),
(159, 165, 2, 52, 2019, 0, 2021),
(160, 166, 2, 103, 2019, 0, 2021),
(161, 167, 2, 65, 2019, 0, 2021),
(162, 168, 2, 80, 2019, 0, 2021),
(163, 170, 1, 200, 2020, 0, 2024);

-- --------------------------------------------------------

--
-- Структура таблицы `stud_enroll`
--

DROP TABLE IF EXISTS `stud_enroll`;
CREATE TABLE IF NOT EXISTS `stud_enroll` (
  `id_stud_enroll` int(11) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Индекс записи в списке поступивших студентов',
  `id_student` int(11) UNSIGNED NOT NULL COMMENT 'Индекс студента',
  `idPerson` int(11) NOT NULL COMMENT 'Индекс абитуриента',
  PRIMARY KEY (`id_stud_enroll`),
  KEY `id_stud_enroll` (`id_stud_enroll`,`id_student`,`idPerson`),
  KEY `id_student` (`id_student`),
  KEY `idPerson` (`idPerson`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8 COMMENT='Поступившие студенты';

--
-- Дамп данных таблицы `stud_enroll`
--

INSERT INTO `stud_enroll` (`id_stud_enroll`, `id_student`, `idPerson`) VALUES
(1, 3, 7),
(2, 1, 10),
(3, 16, 11),
(4, 3, 10),
(5, 14, 11),
(6, 18, 10),
(7, 25, 11),
(8, 36, 7),
(9, 44, 13),
(10, 50, 10),
(11, 54, 13),
(12, 65, 13),
(13, 59, 7),
(14, 80, 11),
(15, 88, 13),
(16, 90, 13),
(17, 96, 11),
(18, 99, 7),
(19, 111, 10),
(20, 123, 13),
(21, 122, 13),
(22, 130, 13),
(23, 143, 11),
(24, 154, 7),
(25, 154, 10),
(26, 163, 10);

-- --------------------------------------------------------

--
-- Структура таблицы `website`
--

DROP TABLE IF EXISTS `website`;
CREATE TABLE IF NOT EXISTS `website` (
  `id_website` int(11) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Индекс сайта',
  `link` varchar(70) NOT NULL COMMENT 'Ссылка',
  PRIMARY KEY (`id_website`),
  UNIQUE KEY `id_website` (`id_website`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COMMENT='Сайт';

--
-- Дамп данных таблицы `website`
--

INSERT INTO `website` (`id_website`, `link`) VALUES
(1, 'https://www.rabota.ru/'),
(2, 'https://www.superjob.ru/'),
(3, 'https://www.zarplata.ru/'),
(5, 'https://gorodrabot.ru');

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `account`
--
ALTER TABLE `account`
  ADD CONSTRAINT `account_ibfk_1` FOREIGN KEY (`id_account_type`) REFERENCES `account_type` (`id_account_type`);

--
-- Ограничения внешнего ключа таблицы `action_plan`
--
ALTER TABLE `action_plan`
  ADD CONSTRAINT `action_plan_ibfk_2` FOREIGN KEY (`id_event`) REFERENCES `event` (`id_event`);

--
-- Ограничения внешнего ключа таблицы `activity`
--
ALTER TABLE `activity`
  ADD CONSTRAINT `activity_ibfk_1` FOREIGN KEY (`id_action_plan`) REFERENCES `action_plan` (`id_action_plan`),
  ADD CONSTRAINT `activity_ibfk_2` FOREIGN KEY (`id_role`) REFERENCES `role` (`id_role`),
  ADD CONSTRAINT `activity_ibfk_3` FOREIGN KEY (`id_account`) REFERENCES `account` (`id_account`);

--
-- Ограничения внешнего ключа таблицы `event`
--
ALTER TABLE `event`
  ADD CONSTRAINT `event_ibfk_1` FOREIGN KEY (`id_organizer`) REFERENCES `organizer` (`id_organizer`),
  ADD CONSTRAINT `event_ibfk_2` FOREIGN KEY (`id_category`) REFERENCES `category` (`id_category`);

--
-- Ограничения внешнего ключа таблицы `graduate`
--
ALTER TABLE `graduate`
  ADD CONSTRAINT `graduate_ibfk_1` FOREIGN KEY (`id_student`) REFERENCES `student` (`id_student`);

--
-- Ограничения внешнего ключа таблицы `interest`
--
ALTER TABLE `interest`
  ADD CONSTRAINT `interest_ibfk_1` FOREIGN KEY (`id_degree`) REFERENCES `degree` (`id_degree`);

--
-- Ограничения внешнего ключа таблицы `labor_market`
--
ALTER TABLE `labor_market`
  ADD CONSTRAINT `labor_market_ibfk_1` FOREIGN KEY (`id_field`) REFERENCES `field` (`id_field`),
  ADD CONSTRAINT `labor_market_ibfk_2` FOREIGN KEY (`id_website`) REFERENCES `website` (`id_website`);

--
-- Ограничения внешнего ключа таблицы `material`
--
ALTER TABLE `material`
  ADD CONSTRAINT `material_ibfk_1` FOREIGN KEY (`id_action_plan`) REFERENCES `action_plan` (`id_action_plan`);

--
-- Ограничения внешнего ключа таблицы `organizer`
--
ALTER TABLE `organizer`
  ADD CONSTRAINT `organizer_ibfk_1` FOREIGN KEY (`id_organization_type`) REFERENCES `organization_type` (`id_organization_type`);

--
-- Ограничения внешнего ключа таблицы `personcontacts`
--
ALTER TABLE `personcontacts`
  ADD CONSTRAINT `personcontacts_ibfk_1` FOREIGN KEY (`PersonID`) REFERENCES `person` (`idPerson`),
  ADD CONSTRAINT `personcontacts_ibfk_2` FOREIGN KEY (`PersonContactTypeID`) REFERENCES `personcontacttypes` (`idPersonContactType`);

--
-- Ограничения внешнего ключа таблицы `personolympiad`
--
ALTER TABLE `personolympiad`
  ADD CONSTRAINT `personolympiad_ibfk_1` FOREIGN KEY (`PersonID`) REFERENCES `person` (`idPerson`);

--
-- Ограничения внешнего ключа таблицы `student`
--
ALTER TABLE `student`
  ADD CONSTRAINT `student_ibfk_1` FOREIGN KEY (`id_account`) REFERENCES `account` (`id_account`),
  ADD CONSTRAINT `student_ibfk_2` FOREIGN KEY (`id_degree`) REFERENCES `degree` (`id_degree`);

--
-- Ограничения внешнего ключа таблицы `stud_enroll`
--
ALTER TABLE `stud_enroll`
  ADD CONSTRAINT `stud_enroll_ibfk_1` FOREIGN KEY (`id_student`) REFERENCES `student` (`id_student`),
  ADD CONSTRAINT `stud_enroll_ibfk_2` FOREIGN KEY (`idPerson`) REFERENCES `person` (`idPerson`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

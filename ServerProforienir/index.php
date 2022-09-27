<?php 
$user = 'root';
$password ='';
$db = 'career_guidance';
$host = 'localhost';

$dsn = 'mysql:host='.$host.';dbname='.$db;
$dsn_Option = [PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION]; //вывод ошибок с бд
$pdo = new PDO($dsn, $user, $password, array(PDO::MYSQL_ATTR_INIT_COMMAND => "SET NAMES utf8"));
	
$sql1 = 'CREATE USER `root`@`%`';
$query1 = $pdo->prepare($sql1);
$query1->execute();

$sql2 = 'GRANT ALL PRIVILEGES ON * . * TO `root`@`%` WITH GRANT OPTION';
$query2 = $pdo->prepare($sql2);
$query2->execute();

$sql4 = "GRANT ALL PRIVILEGES ON * . * TO `admin`@`%` IDENTIFIED BY '1234' WITH GRANT OPTION";
$query4 = $pdo->prepare($sql4);
$query4->execute();


?>
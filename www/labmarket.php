--открытые сайты с вакансиями
--https://www.rabota.ru/
--https://www.superjob.ru/
--https://www.zarplata.ru/
--https://freelance.ru/ не подходит
--https://gorodrabot.ru

--будем искать в следующих сферах:
--IT, Интернет, связь, разработка 1
--менеджмент, управление персоналом 2
--медицина, фармацевтика 3 
--строительство 4
<?php
require_once("phpQuery.php");
//require_once 'mySQLconnect.php';


//САЙТ 1
$html = file_get_contents("https://www.rabota.ru/");

//медицина
$part1 = stristr(stristr($html, '"Рестораны \u002F Питание"},{total:'), ',value:274,url:a,name:"Медицина \u002F Фармация \u002F Ветеринария"', true);
$part2= substr($part1, stripos($part1, ":")+1);
//var_dump( (integer)$part2);
SQLquer(1, 3, (integer)$part2);

//it
$part3 = stristr(stristr($html, '"Медицина \u002F Фармация \u002F Ветеринария"},{total:'), ',value:b,url:a,name:"IT \u002F Интернет \u002F Телеком"', true);
$part4= substr($part3, stripos($part3, ":")+1);
//var_dump( (integer)$part4);
SQLquer(1, 1, (integer)$part4);

//строительство
$p = stristr($html, '"Логистика \u002F Склад \u002F ВЭД"},{total:');
$p1 = stristr($p, ',value', true);
$part6 = substr($p1, stripos($p1, ":")+1);
//var_dump( (integer)$part6);
SQLquer(1, 4, (integer)$part6);

//менеджмент
$q = stristr($html, 'Кадры \u002F Подбор персонала"},{total:');
$q1 = stristr($q, ',value', true);
$part8 = substr($q1, stripos($q1, ":")+1);
//var_dump( $q);
SQLquer(1, 2, (integer)$part8);


//САЙТ 2
/*
$pages[]= "https://www.superjob.ru/vakansii/it-internet-svyaz-telekom/?page="; //1-23 IT
$pages[]= "https://www.superjob.ru/vakansii/medicina-farmacevtika-veterinariya/?page="; //1-59 medicin
$pages[]= "https://www.superjob.ru/vakansii/marketing-reklama-pr/?page="; //1-11 menegm
$pages[]= "https://www.superjob.ru/vakansii/stroitelstvo-proektirovanie-nedvizhimost/?page="; //1-61 build
*/
parser("https://www.superjob.ru/vakansii/it-internet-svyaz-telekom/?page=", 1); //1-23 IT
parser("https://www.superjob.ru/vakansii/medicina-farmacevtika-veterinariya/?page=", 3); //1-59 medicin
parser("https://www.superjob.ru/vakansii/marketing-reklama-pr/?page=", 2); //1-11 menegm
parser("https://www.superjob.ru/vakansii/stroitelstvo-proektirovanie-nedvizhimost/?page=", 4); //1-61 build

function parser($page, $k)
{
  ini_set('max_execution_time', 600);
  $i =1;
  $count = 0;

  while(($i <= 23 && $k==1) || ($i <= 59 && $k==3) ||($i <= 11 && $k==2) || ($i <= 61 && $k==4))
  {
    $html = file_get_contents($page.$i);

    //var_dump($page.$i);
    $dom = phpQuery::newDocument($html);

      $links = $dom ->find('a');

      	foreach ($links as $link) {

      		$pqLink = pq($link); //pq делает объект phpQuery

      	//	$text[] = $pqLink->html();
          if($pqLink->attr('target') == "_blank"){
        	//	$buff = $pqLink->attr('href');
            $count++;
          }
      	}
        //var_dump($buff);
      $i++;
  }
  SQLquer(2, $k, $count);
  //var_dump($count);
  //  $count=0;
}

//САЙТ 3

//it
$siteP = "https://www.zarplata.ru/vacancy/it-i-internet?track=rubrics";
$s1 = "https://www.zarplata.ru/vacancy/it-i-internet?offset=25&track=rubrics";
$s3 = "https://www.zarplata.ru/vacancy/it-i-internet?offset=50&track=rubrics"; //1-3
parserZP("", "", 1);
//medicin
$siteP2 = "https://www.zarplata.ru/vacancy/medicina-i-farmaciya?track=rubrics";
$s2 ="https://www.zarplata.ru/vacancy/medicina-i-farmaciya?offset=25&track=rubrics"; //1-5
parserZP("", "", 2);
//meneg
$siteP3 = "https://www.zarplata.ru/vacancy/vysshij-menedzhment-rukovoditeli?track=rubrics";
$s4 ="https://www.zarplata.ru/vacancy/vysshij-menedzhment-rukovoditeli?offset=25&track=rubrics"; //1-3
parserZP("", "", 3);
//build
$siteP4 = "https://www.zarplata.ru/vacancy/stroitelstvo-nedvizhimost?track=rubrics"; //1-5
parserZP("", "", 4);

function parserZP($pageF, $pageL, $k)
{
  ini_set('max_execution_time', 300);
  $str1 = "offset=";
  $i =25;
  $count = 0;

  if($k==1 ||$k==3){
    $count = 25*3;
	SQLquer(3, $k, $count);
    //var_dump($count);
  }
  if($k==2 || $k==4){
    $count = 25*5;
	SQLquer(3, $k, $count);
   // var_dump($count);
  }
}

//САЙТ 4
//it
$siteR ="https://moskva.gorodrabot.ru/?q=IT";
parserGR($siteR, 1);

//medicin
$siteR2 = "https://moskva.gorodrabot.ru/?q=%D0%BC%D0%B5%D0%B4%D0%B8%D1%86%D0%B8%D0%BD%D0%B0";
parserGR($siteR2, 3);

//meneg
$siteR3 = "https://moskva.gorodrabot.ru/%D0%BC%D0%B5%D0%BD%D0%B5%D0%B4%D0%B6%D0%B5%D1%80";
parserGR($siteR3, 2);

//build
$siteR4 = "https://moskva.gorodrabot.ru/%D1%81%D1%82%D1%80%D0%BE%D0%B8%D1%82%D0%B5%D0%BB%D1%8C%D1%81%D1%82%D0%B2%D0%BE"; //1-5
parserGR($siteR4, 4);

function parserGR($page, $k)
{
    $html = file_get_contents($page);

    $part1 = stristr(stristr($html, 'У нас Вы найдете  более '), ' свежих вакансий от прямых работодателей, с зарплатой', true);
    $part2= substr($part1, strrpos($part1, " "));
    //var_dump((integer)$part2);
	SQLquer(5, $k, (integer)$part2);
}

function SQLquer($idSite, $idField, $count)
{
	//require_once 'mySQLconnect.php';
	$user = 'root';
$password ='';
$db = 'career_guidance';
$host = 'localhost';

$dsn = 'mysql:host='.$host.';dbname='.$db;
//$dsn_Option = [PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION]; //вывод ошибок с бд
$pdo = new PDO($dsn, $user, $password, array(PDO::MYSQL_ATTR_INIT_COMMAND => "SET NAMES utf8"));
	
$sql = 'SELECT `id_labor_market`  
 FROM `labor_market`  
 WHERE `id_website` = :id1 AND `id_field` = :id2';
$query = $pdo->prepare($sql);
$query->execute(['id1' => $idSite, 'id2' => $idField]);

$entry = $query->fetch(PDO::FETCH_OBJ); //массив, объекты которого - записи одного мероприятия на одну дату, но на разное время

$id_labM = 0;
if(isset($entry->id_labor_market))
{
	$id_labM = $entry->id_labor_market;
	//echo $id_labM;
	
	$sql = 'UPDATE `labor_market` SET `count` = :kol WHERE `id_labor_market` = :id';

  $query = $pdo->prepare($sql);
  $query->execute(['kol'=> $count, 'id' => $id_labM]);
}
else
{
	//echo $id_labM;
	$sql = 'INSERT INTO labor_market(id_website, id_field, count) VALUES( :id_w, :id_f, :kol)';
  $query = $pdo->prepare($sql); //возвращает объект

  $query->execute([':id_w'=> $idSite, 'id_f' => $idField, 'kol'=> $count]);

}	
		
		
}

phpQuery::unloadDocuments();
?>

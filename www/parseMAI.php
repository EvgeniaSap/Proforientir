<?php
//composer require smalot/pdfparser
//mb_internal_encoding("UTF-8");
header('Content-Type: text/html; charset=utf-8');
// header('Content-Transfer-Encoding: utf-8'); //changed to chunked
include 'pdftoolbox-standalone-client-master/vendor/autoload.php';
require_once("phpQuery.php");
//require_once("print/print.tpl.php");
//require_once("dompdf");
$site = "https://priem.mai.ru/results/orders/";
$html = file_get_contents($site);

//$html = file_get_contents("https://yandex.ru/");
$dom = phpQuery::newDocument($html);
//var_dump($html);

$pagesName = $dom ->find('.subnav__text')->text(); //страницы приказов
$pagesLink = $dom ->find('.subnav__link'); //->attr('href');
//var_dump($pages2);
//$pages = $dom ->find('a');
//var_dump($pages);
$fp = fopen('C:\Users\PC\Documents\Visual Studio 2015\Projects\Proforientir\WebParse\pdfstud.txt', 'w');
if ($fp)
{
foreach ($pagesLink as $pagel) {
  $pqPage = pq($pagel); //pq делает объект phpQuery
  $hrefP = $pqPage->attr('href');
  $hrefPN = $pqPage->text();
  $test = fwrite($fp, $hrefPN ."\r\n"); // Запись в файл
  //$test = fwrite($fp, "\n"); // Запись в файл
 if ($test){

   //var_dump($hrefPN);

   $siteord = substr($site, 0, 20) . $hrefP;
   $html1 = file_get_contents($siteord);
   $dom1 = phpQuery::newDocument($html1);

   $ords = $dom1 ->find('a');
   foreach ($ords as $ord) {

     $pqOrd = pq($ord); //pq делает объект phpQuery

     if($pqOrd->attr('target') == "_blank" && stristr($pqOrd->text(), 'Приказ') != null){
       $hrefO = $pqOrd->attr('href');
       $hrefName = $pqOrd->text();

       $test = fwrite($fp, $hrefName ."\r\n"); // Запись в файл
    //   $test = fwrite($fp, "\n"); // Запись в файл
       $test = fwrite($fp, $hrefO ."\r\n"); // Запись в файл
    //   $test = fwrite($fp, "\n"); // Запись в файл
       if ($test){
         echo 'Запись прошла успешно.';
       }
       else echo 'Ошибка при записи в файл.';
     }
   }

 }
   else echo 'Ошибка при записи в файл.';
 }
}
else echo "Ошибка при открытии файла";

fclose($fp); //Закрытие файла



/*foreach ($hrefP as $href) {
$siteord = substr($site, 0, 20) . $href;
$html1 = file_get_contents($siteord);
$dom1 = phpQuery::newDocument($html1);

$ords = $dom1 ->find('a');
foreach ($ords as $ord) {

  $pqOrd = pq($ord); //pq делает объект phpQuery

  if($pqOrd->attr('target') == "_blank" && stristr($pqOrd->text(), 'Приказ') != null){
    $hrefO[] = $pqOrd->attr('href');
  }
}
}*/

//запись в файл стр html
/*$html2 = file_get_contents($hrefO[0]);

$fp = fopen('C:\Users\PC\Documents\Visual Studio 2015\Projects\Proforientir\WebParse\pdfstud.txt', 'w');

if ($fp)
{
$var = pdf2text($html2);
 $test = fwrite($fp, $var); // Запись в файл
if ($test) echo 'Данные в файл успешно занесены.';
  else echo 'Ошибка при записи в файл.';
}
else echo "Ошибка при открытии файла";

fclose($fp); //Закрытие файла*/

/*foreach ($hrefO as $href) {

//$html2 = file_get_contents($href);
//$var = iconv('utf-8', 'windows-1251', $html2); //для переменной $var
//var_dump($html2);
//echo $html2;

//drupal
/*if (function_exists('utf8_decode')) {
    $html2 = utf8_decode($html2);
    var_dump('1');
  }
// iconv fails silently when it encounters something that it doesn't know, so don't use it
//  else if (function_exists('iconv')) {
//    $html = iconv('UTF-8', 'ISO-8859-1', $html);
//  }
  elseif (function_exists('mb_convert_encoding')) {
    $html2 = mb_convert_encoding($html2, 'ISO-8859-1', 'UTF-8');
    var_dump('2');
  }
  elseif (function_exists('recode_string')) {
    $html2 = recode_string('UTF-8..ISO_8859-1', $html2);
    var_dump('3');
  }
  $html2 = htmlspecialchars_decode(htmlentities($html2, ENT_NOQUOTES, 'ISO-8859-1'), ENT_NOQUOTES);*/
//var_dump($href);

//исп класс
/*$a = new PDF2Text();
$a->setFilename($html2); //grab the test file at http://www.newyorklivearts.org/Videographer_RFP.pdf
$a->decodePDF();
echo $a->output();*/



//echo $html2;
  // Parse pdf file and build necessary objects. выв числами
/*  $server_file = $href;

  $parser = new \Smalot\PdfParser\Parser();
  $pdf = $parser->parseFile($href);
  if ($pdf != "") {
    $original_text = $pdf->getText();
 if ($original_text != "") {
     $text = nl2br($original_text); // Paragraphs and line break formatting
     $text = clean_ascii_characters($text); // Check special characters
     $text = str_replace(array("<br /> <br /> <br />", "<br> <br> <br>"), "<br /> <br />", $text); // Optional
     $text = addslashes($text); // Backslashes for single quotes
     $text = stripslashes($text);
     $text = strip_tags($text);

     /**********************************************/
     /* Additional step to check formatting issues */
     // There may be some PDF formatting issues. I'm trying to check if the words are:
     // (a) Join. E.g., HelloWorld!Thereisnospacingbetweenwords
     // (b) splitted. E.g., H e l l o W o r l d ! E x c e s s i v e s p a c i n g
  /*   $check_text = preg_split('/\s+/', $text, -1, PREG_SPLIT_NO_EMPTY);

     $no_spacing_error = 0;
     $excessive_spacing_error = 0;
     foreach($check_text as $word_key => $word) {
         if (strlen($word) >= 30) { // 30 is a limit that I set for a word length, assuming that no word would be 30 length long
             $no_spacing_error++;
         } else if (strlen($word) == 1) { // To check if the word is 1 word length
             if (preg_match('/^[A-Za-z]+$/', $word)) { // Only consider alphabetical words and ignore numbers.
                 $excessive_spacing_error++;
             }
         }
     }

     // Set the boundaries of errors you can accept
     // E.g., we reject the change if there are 30 or more $no_spacing_error or 150 or more $excessive_spacing_error issues
     if ($no_spacing_error >= 30 || $excessive_spacing_error >= 150) {
         echo "Too many formatting issues<br />";
         echo $text;
     } else {
         echo "Success!<br />";
         echo $text;
     }
     /* End of additional step */
     /**************************/

 /*} else {
     echo "No text extracted from PDF.";
 }
} else {
 echo "parseFile fns failed. Not a PDF.";
}*/



//}


phpQuery::unloadDocuments();

// Common function выв числами
/*function clean_ascii_characters($string) {
    $string = str_replace(array('-', '–'), '-', $string);
    $string = preg_replace('/[\x00-\x1F\x80-\xFF]/', '', $string);
    return $string;
}*/

/*function pdf2text($filename) {
    // Читаем данные из pdf-файла в строку, учитываем, что файл может содержать
    // бинарные потоки.
    $infile = @file_get_contents($filename, FILE_BINARY);
    if (empty($infile))
        return "";

    // Проход первый. Нам требуется получить все текстовые данные из файла.
    // В 1ом проходе мы получаем лишь "грязные" данные, с позиционированием,
    // с вставками hex и так далее.
    $transformations = array();
    $texts = array();

    // Для начала получим список всех объектов из pdf-файла.
    preg_match_all("#obj(.*)endobj#ismU", $infile, $objects);
    $objects = @$objects[1];

    // Начнём обходить, то что нашли - помимо текста, нам может попасться
    // много всего интересного и не всегда "вкусного", например, те же шрифты.
    for ($i = 0; $i < count($objects); $i++) {
        $currentObject = $objects[$i];

        // Проверяем, есть ли в текущем объекте поток данных, почти всегда он
        // сжат с помощью gzip.
        if (preg_match("#stream(.*)endstream#ismU", $currentObject, $stream)) {
            $stream = ltrim($stream[1]);

            // Читаем параметры данного объекта, нас интересует только текстовые
            // данные, поэтому делаем минимальные отсечения, чтобы ускорить
            // выполнения
            $options = getObjectOptions($currentObject);
            if (!(empty($options["Length1"]) && empty($options["Type"]) && empty($options["Subtype"])))
                continue;

            // Итак, перед нами "возможно" текст, расшифровываем его из бинарного
            // представления. После этого действия мы имеем дело только с plain text.
            $data = getDecodedStream($stream, $options);
            if (strlen($data)) {
                // Итак, нам нужно найти контейнер текста в текущем потоке.
                // В случае успеха найденный "грязный" текст отправится к остальным
                // найденным до этого
                if (preg_match_all("#BT(.*)ET#ismU", $data, $textContainers)) {
                    $textContainers = @$textContainers[1];
                    getDirtyTexts($texts, $textContainers);
                // В противном случае, пытаемся найти символьные трансформации,
                // которые будем использовать во втором шаге.
                } else
                    getCharTransformations($transformations, $data);
            }
        }
    }

    // По окончанию первичного парсинга pdf-документа, начинаем разбор полученных
    // текстовых блоков с учётом символьных трансформаций. По окончанию, возвращаем
    // полученный результат.
    return getTextUsingTransformations($texts, $transformations);
}

class PDF2Text {
        // Some settings
        var $multibyte = 4; // Use setUnicode(TRUE|FALSE)
        var $convertquotes = ENT_QUOTES; // ENT_COMPAT (double-quotes), ENT_QUOTES (Both), ENT_NOQUOTES (None)
        var $showprogress = true; // TRUE if you have problems with time-out

        // Variables
        var $filename = '';
        var $decodedtext = '';

        function setFilename($filename) {
                // Reset
                $this->decodedtext = '';
                $this->filename = $filename;
        }

        function output($echo = false) {
                if($echo) echo $this->decodedtext;
                else return $this->decodedtext;
        }

        function setUnicode($input) {
                // 4 for unicode. But 2 should work in most cases just fine
                if($input == true) $this->multibyte = 4;
                else $this->multibyte = 2;
        }

        function decodePDF() {
                // Read the data from pdf file
                $infile = @file_get_contents($this->filename, FILE_BINARY);
                if (empty($infile))
                        return "";

                // Get all text data.
                $transformations = array();
                $texts = array();

                // Get the list of all objects.
                preg_match_all("#obj[\n|\r](.*)endobj[\n|\r]#ismU", $infile . "endobj\r", $objects);
                $objects = @$objects[1];

                // Select objects with streams.
                for ($i = 0; $i < count($objects); $i++) {
                        $currentObject = $objects[$i];

                        // Prevent time-out
                        @set_time_limit ();
                        if($this->showprogress) {
//                              echo ". ";
                                flush(); ob_flush();
                        }

                        // Check if an object includes data stream.
                        if (preg_match("#stream[\n|\r](.*)endstream[\n|\r]#ismU", $currentObject . "endstream\r", $stream )) {
                                $stream = ltrim($stream[1]);
                                // Check object parameters and look for text data.
                                $options = $this->getObjectOptions($currentObject);

                                if (!(empty($options["Length1"]) && empty($options["Type"]) && empty($options["Subtype"])) )
//                              if ( $options["Image"] && $options["Subtype"] )
//                              if (!(empty($options["Length1"]) &&  empty($options["Subtype"])) )
                                        continue;

                                // Hack, length doesnt always seem to be correct
                                unset($options["Length"]);

                                // So, we have text data. Decode it.
                                $data = $this->getDecodedStream($stream, $options);

                                if (strlen($data)) {
                        if (preg_match_all("#BT[\n|\r](.*)ET[\n|\r]#ismU", $data . "ET\r", $textContainers)) {
                                                $textContainers = @$textContainers[1];
                                                $this->getDirtyTexts($texts, $textContainers);
                                        } else
                                                $this->getCharTransformations($transformations, $data);
                                }
                        }
                }

                // Analyze text blocks taking into account character transformations and return results.
                $this->decodedtext = $this->getTextUsingTransformations($texts, $transformations);
        }


        function decodeAsciiHex($input) {
                $output = "";

                $isOdd = true;
                $isComment = false;

                for($i = 0, $codeHigh = -1; $i < strlen($input) && $input[$i] != '>'; $i++) {
                        $c = $input[$i];

                        if($isComment) {
                                if ($c == '\r' || $c == '\n')
                                        $isComment = false;
                                continue;
                        }

                        switch($c) {
                                case '\0': case '\t': case '\r': case '\f': case '\n': case ' ': break;
                                case '%':
                                        $isComment = true;
                                break;

                                default:
                                        $code = hexdec($c);
                                        if($code === 0 && $c != '0')
                                                return "";

                                        if($isOdd)
                                                $codeHigh = $code;
                                        else
                                                $output .= chr($codeHigh * 16 + $code);

                                        $isOdd = !$isOdd;
                                break;
                        }
                }

                if($input[$i] != '>')
                        return "";

                if($isOdd)
                        $output .= chr($codeHigh * 16);

                return $output;
        }

        function decodeAscii85($input) {
                $output = "";

                $isComment = false;
                $ords = array();

                for($i = 0, $state = 0; $i < strlen($input) && $input[$i] != '~'; $i++) {
                        $c = $input[$i];

                        if($isComment) {
                                if ($c == '\r' || $c == '\n')
                                        $isComment = false;
                                continue;
                        }

                        if ($c == '\0' || $c == '\t' || $c == '\r' || $c == '\f' || $c == '\n' || $c == ' ')
                                continue;
                        if ($c == '%') {
                                $isComment = true;
                                continue;
                        }
                        if ($c == 'z' && $state === 0) {
                                $output .= str_repeat(chr(0), 4);
                                continue;
                        }
                        if ($c < '!' || $c > 'u')
                                return "";

                        $code = ord($input[$i]) & 0xff;
                        $ords[$state++] = $code - ord('!');

                        if ($state == 5) {
                                $state = 0;
                                for ($sum = 0, $j = 0; $j < 5; $j++)
                                        $sum = $sum * 85 + $ords[$j];
                                for ($j = 3; $j >= 0; $j--)
                                        $output .= chr($sum >> ($j * 8));
                        }
                }
                if ($state === 1)
                        return "";
                elseif ($state > 1) {
                        for ($i = 0, $sum = 0; $i < $state; $i++)
                                $sum += ($ords[$i] + ($i == $state - 1)) * pow(85, 4 - $i);
                        for ($i = 0; $i < $state - 1; $i++) {
                                try {
                                        if(false == ($o = chr($sum >> ((3 - $i) * 8)))) {
                                                throw new Exception('Error');
                                        }
                                        $output .= $o;
                                } catch (Exception $e) { /*Dont do anything*//* }
                        }
                }

                return $output;
        }

        function decodeFlate($data) {
                return @gzuncompress($data);
        }

        function getObjectOptions($object) {
                $options = array();

                if (preg_match("#<<(.*)>>#ismU", $object, $options)) {
                        $options = explode("/", $options[1]);
                        @array_shift($options);

                        $o = array();
                        for ($j = 0; $j < @count($options); $j++) {
                                $options[$j] = preg_replace("#\s+#", " ", trim($options[$j]));
                                if (strpos($options[$j], " ") !== false) {
                                        $parts = explode(" ", $options[$j]);
                                        $o[$parts[0]] = $parts[1];
                                } else
                                        $o[$options[$j]] = true;
                        }
                        $options = $o;
                        unset($o);
                }

                return $options;
        }

        function getDecodedStream($stream, $options) {
                $data = "";
                if (empty($options["Filter"]))
                        $data = $stream;
                else {
                        $length = !empty($options["Length"]) ? $options["Length"] : strlen($stream);
                        $_stream = substr($stream, 0, $length);

                        foreach ($options as $key => $value) {
                                if ($key == "ASCIIHexDecode")
                                        $_stream = $this->decodeAsciiHex($_stream);
                                elseif ($key == "ASCII85Decode")
                                        $_stream = $this->decodeAscii85($_stream);
                                elseif ($key == "FlateDecode")
                                        $_stream = $this->decodeFlate($_stream);
                                elseif ($key == "Crypt") { // TO DO
                                }
                        }
                        $data = $_stream;
                }
                return $data;
        }

        function getDirtyTexts(&$texts, $textContainers) {
                for ($j = 0; $j < count($textContainers); $j++) {
                        if (preg_match_all("#\[(.*)\]\s*TJ[\n|\r]#ismU", $textContainers[$j], $parts))
                                $texts = array_merge($texts, array(@implode('', $parts[1])));
                        elseif (preg_match_all("#T[d|w|m|f]\s*(\(.*\))\s*Tj[\n|\r]#ismU", $textContainers[$j], $parts))
                                $texts = array_merge($texts, array(@implode('', $parts[1])));
                        elseif (preg_match_all("#T[d|w|m|f]\s*(\[.*\])\s*Tj[\n|\r]#ismU", $textContainers[$j], $parts))
                                $texts = array_merge($texts, array(@implode('', $parts[1])));
                }

        }

        function getCharTransformations(&$transformations, $stream) {
                preg_match_all("#([0-9]+)\s+beginbfchar(.*)endbfchar#ismU", $stream, $chars, PREG_SET_ORDER);
                preg_match_all("#([0-9]+)\s+beginbfrange(.*)endbfrange#ismU", $stream, $ranges, PREG_SET_ORDER);

                for ($j = 0; $j < count($chars); $j++) {
                        $count = $chars[$j][1];
                        $current = explode("\n", trim($chars[$j][2]));
                        for ($k = 0; $k < $count && $k < count($current); $k++) {
                                if (preg_match("#<([0-9a-f]{2,4})>\s+<([0-9a-f]{4,512})>#is", trim($current[$k]), $map))
                                        $transformations[str_pad($map[1], 4, "0")] = $map[2];
                        }
                }
                for ($j = 0; $j < count($ranges); $j++) {
                        $count = $ranges[$j][1];
                        $current = explode("\n", trim($ranges[$j][2]));
                        for ($k = 0; $k < $count && $k < count($current); $k++) {
                                if (preg_match("#<([0-9a-f]{4})>\s+<([0-9a-f]{4})>\s+<([0-9a-f]{4})>#is", trim($current[$k]), $map)) {
                                        $from = hexdec($map[1]);
                                        $to = hexdec($map[2]);
                                        $_from = hexdec($map[3]);

                                        for ($m = $from, $n = 0; $m <= $to; $m++, $n++)
                                                $transformations[sprintf("%04X", $m)] = sprintf("%04X", $_from + $n);
                                } elseif (preg_match("#<([0-9a-f]{4})>\s+<([0-9a-f]{4})>\s+\[(.*)\]#ismU", trim($current[$k]), $map)) {
                                        $from = hexdec($map[1]);
                                        $to = hexdec($map[2]);
                                        $parts = preg_split("#\s+#", trim($map[3]));

                                        for ($m = $from, $n = 0; $m <= $to && $n < count($parts); $m++, $n++)
                                                $transformations[sprintf("%04X", $m)] = sprintf("%04X", hexdec($parts[$n]));
                                }
                        }
                }
        }
        function getTextUsingTransformations($texts, $transformations) {
                $document = "";
                for ($i = 0; $i < count($texts); $i++) {
                        $isHex = false;
                        $isPlain = false;

                        $hex = "";
                        $plain = "";
                        for ($j = 0; $j < strlen($texts[$i]); $j++) {
                                $c = $texts[$i][$j];
                                switch($c) {
                                        case "<":
                                                $hex = "";
                                                $isHex = true;
                        $isPlain = false;
                                        break;
                                        case ">":
                                                $hexs = str_split($hex, $this->multibyte); // 2 or 4 (UTF8 or ISO)
                                                for ($k = 0; $k < count($hexs); $k++) {

                                                        $chex = str_pad($hexs[$k], 4, "0"); // Add tailing zero
                                                        if (isset($transformations[$chex]))
                                                                $chex = $transformations[$chex];
                                                        $document .= html_entity_decode("&#x".$chex.";");
                                                }
                                                $isHex = false;
                                        break;
                                        case "(":
                                                $plain = "";
                                                $isPlain = true;
                        $isHex = false;
                                        break;
                                        case ")":
                                                $document .= $plain;
                                                $isPlain = false;
                                        break;
                                        case "\\":
                                                $c2 = $texts[$i][$j + 1];
                                                if (in_array($c2, array("\\", "(", ")"))) $plain .= $c2;
                                                elseif ($c2 == "n") $plain .= '\n';
                                                elseif ($c2 == "r") $plain .= '\r';
                                                elseif ($c2 == "t") $plain .= '\t';
                                                elseif ($c2 == "b") $plain .= '\b';
                                                elseif ($c2 == "f") $plain .= '\f';
                                                elseif ($c2 >= '0' && $c2 <= '9') {
                                                        $oct = preg_replace("#[^0-9]#", "", substr($texts[$i], $j + 1, 3));
                                                        $j += strlen($oct) - 1;
                                                        $plain .= html_entity_decode("&#".octdec($oct).";", $this->convertquotes);
                                                }
                                                $j++;
                                        break;

                                        default:
                                                if ($isHex)
                                                        $hex .= $c;
                                                elseif ($isPlain)
                                                        $plain .= $c;
                                        break;
                                }
                        }
                        $document .= "\n";
                }

                return $document;
        }
}*/

//https://myrusakov.ru/php-text-from-pdf.html
// скачать https://stackoverflow.com/questions/15076323/how-to-download-this-pdf-file-using-php/15076511
//откуда качала библ https://gitlab.it.helloprint.com/suard.damme/pdftoolbox-standalone-client/tree/master/vendor
//https://habr.com/ru/post/69568/
?>

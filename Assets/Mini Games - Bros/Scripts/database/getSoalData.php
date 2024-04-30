<?php
require "connectDB.php";

$id_materi = $_POST['materi_id'];

$querySoal = "SELECT * FROM soal, bab_materi where soal.id_materi=$id_materi";

// $getDataSoal = mysqli_query($con, $querySoal);
// $row = exe_query($getDataSoal);
$row = exe_query($querySoal);

// print $row['1'];
// while ($row = mysqli_fetch_assoc($getDataSoal)) {
foreach ($row as $rowSoal) :
    // get materi berapakah soal tersebut
    ${'a' . $rowSoal['id_materi']} = $rowSoal['materi'];
    echo ${'a' . $rowSoal['id_materi']} . "<br>";

    // get soalnya
    echo "Materi: " . $rowSoal["materi"] . " | Soal: " . $rowSoal["pertanyaan"];
    // echo $rowSoal['pertanyaan'];
    echo "<p>";


endforeach;

// if ($row != null) {
//     ${'a' . $row['id_materi']} = '1';
//     echo "$a1";
//     // }
// }

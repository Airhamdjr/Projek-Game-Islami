<?php
include_once "connectDB.php";

$sql = "SELECT * FROM id_player";
$sql_execution = mysqli_query($con, $sql);
$data = array();
while ($sql_exeresult = mysqli_fetch_assoc($sql_execution)) {
    $data[] = $sql_exeresult;
}
print_r($data);

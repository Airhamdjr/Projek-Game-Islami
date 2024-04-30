<?php
$con = mysqli_connect('localhost', 'root', 'miftahs', 'game_themahad');

if (mysqli_connect_errno()) {
    echo "1";
    exit();
}

function exe_query($sql)
{
    global $con;
    $sql_execution = mysqli_query($con, $sql);
    $data = array();
    while ($sql_exeresult = mysqli_fetch_assoc($sql_execution)) {
        $data[] = $sql_exeresult;
    }
    return $data;
}

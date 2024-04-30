<?php
include_once 'connectDB.php';

$usn_player = 'miftahsmdra';
$pw_player = '123';

// if username player login = username player database
$query = "SELECT * FROM id_player where username = '$usn_player' AND password = '$pw_player'";

$sql_execution = mysqli_query($con, $query);

// print_r($sql_execution);
$data = array();
if ($sql_execution->num_rows > 0) {
    while ($sql_exeresult = mysqli_fetch_assoc($sql_execution)) {
        $data[] = $sql_exeresult;
    }
    echo json_encode($data);
} else {
    echo "tidak ada";
}
$con->close();

// get player status data
// if ($row > 0) {
//     echo "berhasil masuk";
//     // echo $row[0]['username'];
// } else {
//     echo "silahkan mendaftar";
// }

// foreach ($row as $index => $key) :
//     if (is_array($key)) {
//         foreach ($key as $subkey => $rowuser) :
//             echo $subkey . " => " . $rowuser;
//         endforeach;
//     }
// endforeach;
// else (username player login tidak ketemu)
// alert to register

// $query = "SELECT * FROM id_player where username = $usn_player AND password = $pw_player";

// $query = "SELECT * FROM id_player where id_player = $usn_player";
// $getData = mysqli_query($con, $query);
// $row = mysqli_fetch_assoc($getData);

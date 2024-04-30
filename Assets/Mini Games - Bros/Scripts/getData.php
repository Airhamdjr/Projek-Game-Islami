<?php
include_once "koneksi.php";

$query = mysqli_query($koneksi, "SELECT * FROM id_player");
$tampil = mysqli_fetch_assoc($query);

echo $tampil['id'] . " | " . $tampil['username'] . " | ";

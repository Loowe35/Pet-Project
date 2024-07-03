<?php
session_start();
require_once 'connectdb.php';

$idwayb = $_POST['idway'];

$updatestat = "UPDATE `Waybill` SET `Status`='Принято' WHERE `Waybill_ID`='$idwayb'";
if (mysqli_query($conn, $updatestat)) {
    $_SESSION['success_message'] = "Вы успешно приняли путевой лист";
} else {
    echo "Ошибка при обновлении данных: " . mysqli_error($conn);
}

header("Location: ../waybill.php?status=accepted");
exit;

?>
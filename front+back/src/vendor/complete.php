<?php
session_start();
require_once 'connectdb.php';

$idwayb = $_POST['idway'];

// Преобразование текущей даты в формат без времени
$currentDate = date("Y-m-d", strtotime("now"));

// Получение даты прибытия из базы данных
$query = "SELECT Arrival_Date FROM Waybill WHERE Waybill_ID='$idwayb'";
$result = mysqli_query($conn, $query);

if ($result && mysqli_num_rows($result) > 0) {
    $row = mysqli_fetch_assoc($result);
    
    // Преобразование даты прибытия из базы данных в формат без времени
    $arrivalDate = date("Y-m-d", strtotime($row['Arrival_Date']));
    
    // Сравнение дат
    if ($arrivalDate == $currentDate) {
        // Если даты совпадают, обновить статус
        $updatestat = "UPDATE `Waybill` SET `Status`='Выполнен' WHERE `Waybill_ID`='$idwayb'";
        if (mysqli_query($conn, $updatestat)) {
            $_SESSION['success_message'] = "Статус путевого листа успешно обновлен.";
        } else {
            $_SESSION['error_message'] = "Ошибка при обновлении данных: " . mysqli_error($conn);
        }
    } else {
        // Если даты не совпадают, выдать ошибку
        $_SESSION['error_message'] = "Ошибка: дата прибытия не совпадает с текущей датой";
    }
} else {
    $_SESSION['error_message'] = "Путевой лист не найден";
}

// Перенаправляем обратно на предыдущую страницу
header("Location: ../waybill.php?status=accepted");
exit;
?>

<?php
require "connectdb.php";
$id =  $_COOKIE["user_id"];
// Путь для сохранения загруженных фотографий
$login = filter_var(trim($_POST['login']));
$pass = filter_var(trim($_POST['pas']));
$surname = filter_var(trim($_POST['surname']));
$name = filter_var(trim($_POST['name']));
$patr = filter_var(trim($_POST['patronymic']));
$num = filter_var(trim($_POST['phone_number']));
$mail = filter_var(trim($_POST['email']));

$query = "UPDATE `Drivers` SET `Last_Name`='$surname',`First_Name`='$name',`Patronymic`='$patr',`Phone_Number`='$num',`Email`='$mail',`Login`='$login',`Password`='$pass' WHERE `Driver_ID` = '$id'";

if (mysqli_query($conn, $query)) {
    echo "Данные успешно обновлены .";
    header("Location: ../personal_profile.php");
} else {
    echo "Ошибка при обновлении данных: " . mysqli_error($conn);
}

?>
<?php
require_once 'connectdb.php';
$login = $_POST['login'];
$password = $_POST['pass'];

$sql = "SELECT Driver_ID FROM Drivers WHERE Login='$login' AND Password='$password'";
$result = $conn->query($sql);
$user = $result->fetch_assoc();
    // Проверьте, что ровно одна строка соответствует заданным логину и паролю
    if ($result && $result->num_rows == 1) {
        // Успешная авторизация
        setcookie('user_id', $user['Driver_ID'], time() + 3600, "/");
        header('Location: ../waybill.php?status=not_accepted'); 
    } 
    else { 
        
        echo "<script>
        location.href='../index.php';
        alert(\"Данный пользователь не найден!\");</script>"; 
    }    
?>

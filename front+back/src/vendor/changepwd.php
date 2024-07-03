<?php
session_start();
require_once 'connectdb.php';
require 'autoload.php'; // Подключаем автозагрузчик Composer

use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\Exception;

$login = $_POST['login'];
$email = $_POST['email'];
$password = $_POST['pass'];

// Проверяем, существует ли пользователь с указанным логином и электронной почтой
$sql = "SELECT * FROM drivers WHERE login = '$login' AND email = '$email'";
$result = $conn->query($sql);

if ($result && $result->num_rows > 0) {
    // Пользователь найден, обновляем его пароль
    $updateSql = "UPDATE drivers SET password = '$password' WHERE login = '$login' AND email = '$email'";
    
    if ($conn->query($updateSql) === TRUE) {
        $_SESSION['success_message'] = "Пароль успешно изменен";

        // Создаем экземпляр класса PHPMailer
        $mail = new PHPMailer(true);

        try {
            // Настройки сервера SMTP
            $mail->isSMTP();
            $mail->Host = 'smtp.yandex.ru';
            $mail->SMTPAuth = true;
            $mail->Username = 'Shakirov.mmm@yandex.ru'; // ваш почтовый ящик
            $mail->Password = 'lcbkynxvzfyuhimx';     // ваш пароль
            $mail->SMTPSecure = PHPMailer::ENCRYPTION_STARTTLS;
            $mail->Port = 587; // порт SMTP

            // Устанавливаем параметры письма
            $mail->setFrom('Shakirov.mmm@yandex.ru', 'EconSense');
            $mail->addAddress($email); // адрес получателя
            $mail->Subject = 'Изменение пароля';
            $mail->isHTML(true); // Устанавливаем тип содержимого письма как HTML
$mail->Body = "
<html>
<head>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f0f0;
        }
        .container {
            max-width: 600px;
            margin: 0 auto;
            padding: 20px;
            background-color: #ffffff;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h1 {
            color: #333333;
        }
        p {
            color: #666666;
        }
        img {
            width: 600px;
        }
        .footer {
            margin-top: 20px;
            text-align: center;
            color: #999999;
            font-size: 12px;
        }
    </style>
</head>
<body>
    <div class='container'>
        <img src='https://роско68.рф/images/15739fba5ff957936938c7fdf05f163f.webp' alt=''>
        <h1>Добро пожаловать!</h1>
        <p>Ваш новый пароль: 1231123</p>
    </div>
    <div class='footer'>
        <p>С уважением, Администрация EconSense</p>
    </div>
</body>
</html>";

            // Отправка письма
            $mail->send();
            $_SESSION['success_message'] = ' Письмо успешно отправлено';
        } catch (Exception $e) {
            $_SESSION['error_message'] = "Ошибка отправки письма: {$mail->ErrorInfo}";
        }
    } else {
        $_SESSION['error_message'] = "Ошибка при изменении пароля: " . $conn->error;
    }
} else {
    $_SESSION['error_message'] = "Пользователь с указанным логином и почтой не найден";
}

header("Location: ../index.php");
exit;
?>

<?php 
require "vendor/connectdb.php";
$id =  $_COOKIE["user_id"];

$query = mysqli_query($conn,"SELECT Last_Name, First_Name, Patronymic, Phone_Number, Email, Login, Password, Photo FROM `Drivers` WHERE Driver_ID = '$id'");

$FullInfo = mysqli_fetch_all($query);
$imageData = $FullInfo['Photo'];

// Преобразуем данные изображения в base64 для вставки в тег img
$imageBase64 = base64_encode($imageData);

// Формируем строку src для тега img
$imageSrc = 'data:image/jpeg;base64,' . $imageBase64;
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <link rel="stylesheet" href="css/index.css">
    <link rel="stylesheet" href="css/normalize.css">
    <link rel="stylesheet" href="css/reset.css">
    <link rel="shortcut icon" href="icons/лого.ico" type="image/x-icon">
    <title>Путевые листы</title>
</head>
<body>


    <header>
        <div class="nav-board_wayb">
            <div class="container nav-board__view">
                <div class="nav-board__logo">
                    <a href="#" class="nav-board__transition">
                        <img class="logo" src="img/logo.png" alt="Белебеевский молочный комбинат">
                    </a>
                </div>
                <div class="nav-board__button">
                    <ul class="nav-board__anchor-wayb">
                        <li><a href="waybill.php?status=not_accepted" class="<?= ($status == 'not_accepted') ? 'active' : ''; ?>">Путевые листы</a></li>
                        <li><a href="history.php">История</a></li>
                        <li><a href="">Профиль</a></li>
                    </ul>
                </div>
                <div class="nav-board__exit">
                <a href="vendor/exit.php"><button class="section__button-wayb" >Выйти</button></a>
                </div>
            </div>
        </div>
    </header>

    <section class="waybill">
        <div class="container_info">

        <div class="info-photo">
            <label for="photoInput">
                <?php
                if (isset($FullInfo[0][7]) && !empty($FullInfo[0][7])) {
                    // Если фотография есть, выводим ее
                    echo '<img class="photo" src="Photo/' . $FullInfo[0][7] . '" alt="">';
                } else {
                    // Если фотографии нет, выводим заглушку или другую фотографию по вашему выбору
                    echo '<img class="photo" src="Photo/заглушка.png" alt="Заглушка">';
                }
                ?>
            </label>
            <input type="file" id="photoInput" name="photo" style="display: none;">
        </div>
            <form action="vendor/update.php" method="post" class="for1">
                <input type="text" name="surname" class="form-update" id="surname" value="<?= $FullInfo[0][0] ?>" placeholder="Фамилия" required>
                <input type="text" name="name" class="form-update" id="name" value="<?= $FullInfo[0][1] ?>" placeholder="Имя" required>
                <input type="text" name="patronymic" class="form-update" id="patronymic" value="<?= $FullInfo[0][2] ?>" placeholder="Отчетсво" required>
                <input type="text" name="phone_number" class="form-update" id="phone" value="<?= $FullInfo[0][3] ?>" placeholder="Номер телефона" required>
                <input type="email" pattern="[^@\s]+@[^@\s]+\.[^@\s]+" name="email" class="form-update" id="email" value="<?= $FullInfo[0][4] ?>" placeholder="Почта" required>
                <input type="text" name="login" class="form-update" id="login" value="<?= $FullInfo[0][5] ?>" placeholder="Логин" required>
                <div class="password-field-container">
                    <input type="password" name="pas" class="form-update" id="pas" value="<?= $FullInfo[0][6] ?>" placeholder="Пароль" required>
                    <button type="button" id="showPasswordBtn">
                        <img src="img/show_eye_icon_183818.png" alt="Показать пароль" id="showPasswordIcon">
                    </button>
                </div>
                <div class="but_center">
                    <button class="Update">Обновить данные </button><br>
                </div>
            </form>
            
        </div>
    </section>
    <script>
    const passwordField = document.getElementById('pas');
    const showPasswordIcon = document.getElementById('showPasswordIcon');

    showPasswordIcon.addEventListener('click', function() {
        if (passwordField.type === 'password') {
            passwordField.type = 'text';
            showPasswordIcon.src = 'img/eye_hide_solid_icon_235792.png'; // Изменяем на изображение скрытого пароля
        } else {
            passwordField.type = 'password';
            showPasswordIcon.src = 'img/show_eye_icon_183818.png'; // Изменяем на изображение показанного пароля
        }
    });
</script>
</body>
</html>

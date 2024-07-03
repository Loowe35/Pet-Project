<?php 
session_start();

require "vendor/connectdb.php";
$id =  $_COOKIE["user_id"];

$status = isset($_GET['status']) ? $_GET['status'] : 'not_accepted'; 
$search_query = isset($_GET['search']) ? $_GET['search'] : ''; 

$query = "SELECT w.Waybill_ID, CONCAT(d.Last_Name, ' ', d.First_Name, ' ', d.Patronymic) AS DriverFullName, CONCAT(t.Brand, ' ', t.Model) AS Transport, r.Route_Name, r.Starting_Point, r.Ending_Point, r.Route_Length, c.Cargo_Name, DATE_FORMAT(w.Departure_Date, '%d %M %Y') AS Departure_Date, DATE_FORMAT(w.Arrival_Date, '%d %M %Y') AS Arrival_Date, DATE_FORMAT(w.Departure_Date, '%e %b %Y') AS Russian_Departure_Date FROM Waybill w JOIN Drivers d ON w.Driver_Number = d.Driver_ID JOIN Transport t ON w.Transport_Number = t.Transport_ID JOIN Routes r ON w.Route_Number = r.Route_ID JOIN Cargoes c ON w.Cargo_Number = c.Cargo_ID WHERE d.Driver_ID = '$id' AND w.Arrival_Date >= CURDATE()";

if ($status == 'accepted') {
    $query .= " AND w.Status = 'Принято'";
} elseif ($status == 'not_accepted') {
    $query .= " AND w.Status = 'Отправлено водителю'";
}

if (!empty($search_query)) {
    $query .= " AND (d.Last_Name LIKE '%$search_query%' OR d.First_Name LIKE '%$search_query%' OR d.Patronymic LIKE '%$search_query%' OR t.Brand LIKE '%$search_query%' OR t.Model LIKE '%$search_query%' OR r.Route_Name LIKE '%$search_query%' OR r.Starting_Point LIKE '%$search_query%' OR r.Ending_Point LIKE '%$search_query%' OR c.Cargo_Name LIKE '%$search_query%' OR DATE_FORMAT(w.Departure_Date, '%d %M %Y') LIKE '%$search_query%' OR DATE_FORMAT(w.Arrival_Date, '%d %M %Y') LIKE '%$search_query%')";
}

$FullWaybill = mysqli_query($conn, $query);
$ViewFull = mysqli_fetch_all($FullWaybill);
$hasWaybills = mysqli_num_rows($FullWaybill) > 0;

$isSearchResultEmpty = false;
if (!empty($search_query) && $status == 'not_accepted' && !$hasWaybills) {
    $isSearchResultEmpty = true;
}
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
                        <li><a href="personal_profile.php">Профиль</a></li>
                    </ul>
                </div>
                <div class="nav-board__exit">
                <a href="vendor/exit.php"><button class="section__button-wayb" >Выйти</button></a>
                </div>
            </div>
        </div>
    </header>

    <section class="waybill">
    <div class="container_card">
        <div class="search-form">
            <form action="waybill.php" method="get">
                <div class="input-group">
                    <input type="hidden" name="status" value="<?= isset($_GET['status']) ? $_GET['status'] : 'accepted'; ?>">
                    <input type="text" name="search" value="<?= $search_query ?>" placeholder="Введите ключевое слово для поиска" class="form-control">
                    <button type="submit" class="btn btn-primary">Поиск</button>
                    <?php if (!empty($search_query)) : ?>
                        <a href="waybill.php<?= isset($_GET['status']) ? '?status=' . $_GET['status'] : ''; ?>" class="btn btn-secondary">Отмена</a>
                    <?php endif; ?>
                </div>
            </form>
        </div>
        <div class="chois_status">
            <a href="waybill.php?status=not_accepted">Путевые листы</a>
            <a href="waybill.php?status=accepted">Активные путевые листы</a>
        </div>
        <?php if ($hasWaybills) : ?>
            <p class="waybill-Title">
                <?php if(isset($_GET['status']) && $_GET['status'] == 'accepted') : ?>
                    Активные путевые листы
                <?php else : ?>
                    Путевые листы
                <?php endif; ?>
            </p>
            <?php foreach ($ViewFull as $View) : ?>
                <div class="waybill-card">
                    <div class="border">
                        <div class="waybill-card__Title"><?= $View[3] ?></div>
                        <div class="waybill-card__Info">
                            <div class="waybill-card__Info-1">
                                <ul>
                                    <li>Транспорт: <?= $View[2] ?></li>
                                    <li>Начальная точка: <?= $View[4] ?></li>
                                    <li>Конечная точка: <?= $View[5] ?></li>
                                </ul>
                            </div>
                            <div class="waybill-card__Info-2">
                                <ul>
                                    <li>Длина: <?= $View[6] ?> км.</li>
                                    <li>Дата отправления: <?= $View[8] ?></li>
                                    <li>Дата прибытия: <?= $View[9] ?></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="waybill-card__button">
                        <?php if(isset($_GET['status']) && $_GET['status'] == 'accepted') : ?>
                            <form action="vendor/complete.php" method="post">
                                <button class="btn-ok"  value="<?= $View[0] ?>" name="idway">Завершить</button>
                            </form>
                        <?php else : ?>
                            <form action="vendor/accept.php" method="post">
                                <button class="btn-ok"  value="<?= $View[0] ?>" name="idway">Принять</button>
                            </form>
                        <?php endif; ?>
                    </div>
                </div>
            <?php endforeach; ?>
        <?php else : ?>
            <?php if ($isSearchResultEmpty) : ?>
                <p class="waybill-Title">По вашему запросу ничего не найдено</p>
            <?php else : ?>
                <p class="waybill-Title">В данный момент нету путевых листов</p>
            <?php endif; ?>
        <?php endif; ?>
    </div>
</section>

</body>
</html>

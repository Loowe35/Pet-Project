
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="css/index.css">
    <link rel="stylesheet" href="css/normalize.css">
    <link rel="stylesheet" href="css/reset.css">
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.8.1/slick.min.css">
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.8.1/slick-theme.min.css">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.8.1/slick.min.js"></script>
    <link rel="shortcut icon" href="icons/лого.ico" type="image/x-icon">

    <title>Белебеевский молочный комбинат</title>
</head>

<body>
<div class="modal" id="my-modal">
    <div class="modal__box">
        <button class="modal__close-btn" id="close-my-modal-btn">
            <svg width="23" height="25" viewBox="0 0 23 25" fill="none" xmlns="http://www.w3.org/2000/svg">
                <path d="M2.09082 0.03125L22.9999 22.0294L20.909 24.2292L-8.73579e-05 2.23106L2.09082 0.03125Z"
                    fill="white" />
                <path d="M0 22.0295L20.9091 0.0314368L23 2.23125L2.09091 24.2294L0 22.0295Z" fill="white" />
            </svg>
        </button>
        <h2>Авторизация</h2>
        
        <form class="for" action="vendor/authorization-db.php" method="post">
            <input type="text" name="login" class="form-control" id="login" placeholder="Логин" required><br>
            <input type="password" name="pass" class="form-control" id="pass" placeholder="Пароль" required><br>
            <button class="btn btn-success">Войти</button><br>
        </form>
        <button class="change-btn">Забыли пароль?</button><br>
    </div>
</div>
<div class="modal-change" id="my-modal-change">
    <div class="modal__box">
        <button class="modal__close-btn-change" id="close-my-modal-btn-change">
            <svg width="23" height="25" viewBox="0 0 23 25" fill="none" xmlns="http://www.w3.org/2000/svg">
                <path d="M2.09082 0.03125L22.9999 22.0294L20.909 24.2292L-8.73579e-05 2.23106L2.09082 0.03125Z"
                    fill="white" />
                <path d="M0 22.0295L20.9091 0.0314368L23 2.23125L2.09091 24.2294L0 22.0295Z" fill="white" />
            </svg>
        </button>
        
        <h2>Смена пароля</h2>
        
        <form class="for-change" action="vendor/changepwd.php" method="post">
            <input type="text" name="login" class="form-control" id="login" placeholder="Логин" required><br>
            <input type="email" name="email" class="form-control" id="email" placeholder="Почта" required><br>
            <input type="password" name="pass" class="form-control" id="pass" placeholder="Пароль" required><br>
            <button class="btn btn-success">Сменить пароль</button><br>
        </form>
    </div>
</div>
    <!-- навигационное меню -->
    <header>
        <div class="nav-board" id="navMenu">
            <div class="container nav-board__view">
                <div class="nav-board__logo">
                    <a href="#" class="nav-board__transition">
                        <img class="logo" src="img/logo.png" alt="Белебеевский молочный комбинат">
                    </a>
                </div>
                <div class="nav-board__button">
                    <ul class="nav-board__anchor">
                        <li><a href="#prod">Продукция</a></li>
                        <li><a href="#about-block">О компании</a></li>
                        <li><a href="#news-block">Новости</a></li>
                        <li><a href="#iso">Сертификаты ISO</a></li>
                        <li><a href="#contacts">Контакты</a></li>
                        <li><button class="section__button" id="open-modal-btn">Войти</button></li>
                    </ul>
                </div>
            </div>
        </div>
    </header>
    <nav class="secondary-nav" id="bottomNavMenu">
        <ul class="nav-board__anchor2">
            <li><a href="#prod">Продукция</a></li>
            <li><a href="#about-block">О компании</a></li>
            <li><a href="#news-block">Новости</a></li>
            <li><a href="#iso">Сертификаты ISO</a></li>
            <li><a href="#contacts">Контакты</a></li>
            <li><button class="section__button" id="open-modal-btn2">Войти</button></li>
        </ul>
    </nav>

    <!-- карусель главная -->
    <div class="carousel-container">
        <div class="carousel">
            <div><img src="img/first_Slide.png" alt="Slide 1"></div>
            <div><img src="img/second_Slide.png" alt="Slide 2"></div>
            <div><img src="img/third_Slide.png" alt="Slide 3"></div>
            <div><img src="img/fourth_Slide.png" alt="Slide 4"></div>
        </div>
        <div class="custom-button prev-button"><</div>
        <div class="custom-button next-button">></div>
    </div>
    <div id="prod"></div>
        <section class="Product">
            <div class="container ">
                <h2 class="Product-Title">Продукция</h2>
                <hr>
                <div class="carousel2">
                    <div class="prod-slider-owl-item" id="blago" onmouseover="showInfo(1); highlightCard(1)">
                        <div class="prod-slider-item active card-1">
                            <div class="prod-slider-title">Благородный Дуэт</div>
                            <div class="prod-slider-thumb">
                                <img class="alignnone size-full wp-image-44" src="img/blagorodniy2024.png" alt="" width="120" height="157">
                            </div>
                        </div>
                    </div>

                    <div class="prod-slider-owl-item" id="maasdam" onmouseover="showInfo(2); highlightCard(2)">
                        <div class="prod-slider-item active card-2">
                            <div class="prod-slider-title">Традиционный Маасдам</div>
                            <div class="prod-slider-thumb">
                                <img class="alignnone size-full wp-image-44" src="img/maasdam2024.png" alt="" width="120" height="157">
                            </div>
                        </div>
                    </div>

                    <div class="prod-slider-owl-item" onmouseover="showInfo(3); highlightCard(3)">
                        <div class="prod-slider-item active card-3">
                            <div class="prod-slider-title">Белебеевский</div>
                            <div class="prod-slider-thumb">
                                <img class="alignnone size-full wp-image-44" src="img/belebeevskiy2024.png" alt="" width="120" height="157">
                            </div>
                        </div>
                    </div>

                    <div class="prod-slider-owl-item" onmouseover="showInfo(4); highlightCard(4)">
                        <div class="prod-slider-item active card-4">
                            <div class="prod-slider-title">Башкирский медовый</div>
                            <div class="prod-slider-thumb">
                                <img class="alignnone size-full wp-image-44" src="img/honey2024.png" alt="" width="120" height="157">
                            </div>
                        </div>
                    </div>

                    <div class="prod-slider-owl-item" onmouseover="showInfo(5); highlightCard(5)">
                        <div class="prod-slider-item active card-5">
                            <div class="prod-slider-title">Российский</div>
                            <div class="prod-slider-thumb">
                                <img class="alignnone size-full wp-image-44" src="img/russian2024.png" alt="" width="120" height="157">
                            </div>
                        </div>
                    </div>

                    <div class="prod-slider-owl-item" onmouseover="showInfo(6); highlightCard(6)">
                        <div class="prod-slider-item active card-6">
                            <div class="prod-slider-title">Купеческий</div>
                            <div class="prod-slider-thumb">
                                <img class="alignnone size-full wp-image-44" src="img/kupechesky2024.png" alt="" width="120" height="157">
                            </div>
                        </div>
                    </div>

                    <div class="prod-slider-owl-item" onmouseover="showInfo(7); highlightCard(7)">
                        <div class="prod-slider-item active card-7">
                            <div class="prod-slider-title">Йогуртовый легкий</div>
                            <div class="prod-slider-thumb">
                                <img class="alignnone size-full wp-image-44" src="img/yogurt2024.png" alt="" width="120" height="157">
                            </div>
                        </div>
                    </div>

                    <div class="prod-slider-owl-item" onmouseover="showInfo(8); highlightCard(8)">
                        <div class="prod-slider-item active card-8">
                            <div class="prod-slider-title">Голландский</div>
                            <div class="prod-slider-thumb">
                                <img class="alignnone size-full wp-image-44" src="img/holland2024.png" alt="" width="120" height="157">
                            </div>
                        </div>
                    </div>

                    <div class="prod-slider-owl-item" onmouseover="showInfo(9); highlightCard(9)">
                        <div class="prod-slider-item active card-9">
                            <div class="prod-slider-title">Гауда экстра</div>
                            <div class="prod-slider-thumb">
                                <img class="alignnone size-full wp-image-44" src="img/gouda2024.png" alt="" width="120" height="157">
                            </div>
                        </div>
                    </div>

                    <div class="prod-slider-owl-item" onmouseover="showInfo(10); highlightCard(10)">
                        <div class="prod-slider-item active card-10">
                            <div class="prod-slider-title">Belster Parmesan</div>
                            <div class="prod-slider-thumb">
                                <img class="alignnone size-full wp-image-44" src="img/parmesanbelster.png" alt="" width="120" height="157">
                            </div>
                        </div>
                    </div>

                    <div class="prod-slider-owl-item" onmouseover="showInfo(11); highlightCard(11)">
                        <div class="prod-slider-item active card-11">
                            <div class="prod-slider-title">Supreme</div>
                            <div class="prod-slider-thumb">
                                <img class="alignnone size-full wp-image-44" src="img/supreme.png" alt="" width="120" height="157">
                            </div>
                        </div>
                    </div>

                    <div class="prod-slider-owl-item" onmouseover="showInfo(12); highlightCard(12)">
                        <div class="prod-slider-item active card-12">
                            <div class="prod-slider-title">Масло «Крестьянское»</div>
                            <div class="prod-slider-thumb">
                                <img class="alignnone size-full wp-image-44" src="img/kr2024.png" alt="" width="120" height="157">
                            </div>
                        </div>
                    </div>

                    <div class="prod-slider-owl-item" onmouseover="showInfo(13); highlightCard(13)">
                        <div class="prod-slider-item active card-13">
                            <div class="prod-slider-title">Масло «Традиционное»</div>
                            <div class="prod-slider-thumb">
                                <img class="alignnone size-full wp-image-44" src="img/trad2024.png" alt="" width="120" height="157">
                            </div>
                        </div>
                    </div>

                    <div class="prod-slider-owl-item" onmouseover="showInfo(14); highlightCard(14)">
                        <div class="prod-slider-item active card-14">
                            <div class="prod-slider-title">Масло «Бутербродное»</div>
                            <div class="prod-slider-thumb">
                                <img class="alignnone size-full wp-image-44" src="img/butter2024.png" alt="" width="120" height="157">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    
            <div class="carousel2-buttons">
                <button class="carousel2-prev-button"><</button>
                <button class="carousel2-next-button">></button>
            </div>
        
    </div>
    


    <div class="product-info container" id="product-info-1">
        <div class="product-info__wrapper">
            <div class="product-info__img">
                <img src="img/blagorodniy2024.png" alt="Благородный Дуэт">
            </div>
            <div class="product-info__text">
                <div class="product-info-item-title">Благородный Дуэт</div>
                <div class="product-info-item-text">
                    <p>Дуэт нежной кружевной текстуры и благородного вкуса со сладковато-фруктовыми нотками. Гармоничное сочетание легендарных рецептов Тильзитера и Маасдама в одном сыре.</p>
                    <p>Массовая доля жира в сухом веществе — 50%</p>
                    <p>
                        <strong>Состав:</strong> молоко нормализованное пастеризованное, соль пищевая, закваска на основе мезофильных , термофильных и пропионовокислых молочнокислых микроорганизмов, консервант нитрат натрия, молокосвертывающий ферментный препарат микробного происхождения, (аннато, регулятор кислотности Е 525)
                    </p>
                    <p>
                        <strong>Хранить (в том числе после вскрытия упаковки):</strong> при температуре от 0°С до плюс 4°С и относительной влажности воздуха от 80% до 85%
                    </p>
                    <p>
                        <strong>Дата изготовления, годен до:</strong> смотреть на упаковке
                    </p>

                    <table>
                        <tbody>
                            <tr>
                                <td rowspan="2">Средние значения пищевой ценности сыра</td>
                                <td colspan="2">Из расчета</td>
                                <td width="243">Из расчета условной рекомендованной порции</td>
                            </tr>
                            <tr>
                                <td>100 г</td>
                                <td colspan="2">20 г</td>
                            </tr>
                            <tr>
                                <td>Жир, г</td>
                                <td>30,0</td>
                                <td colspan="2">6</td>
                            </tr>
                            <tr>
                                <td>Белок, г</td>
                                <td>24,0</td>
                                <td colspan="2">4,8</td>
                            </tr>
                            <tr>
                                <td>Кальций, мг</td>
                                <td>909</td>
                                <td colspan="2">182</td>
                            </tr>
                            <tr>
                                <td>Энергетическая ценность, кДж</td>
                                <td>1518</td>
                                <td colspan="2">304</td>
                            </tr>
                            <tr>
                                <td>Калорийность, ккал</td>
                                <td>366</td>
                                <td colspan="2">73</td>
                            </tr>
                        </tbody>
                    </table>
                </div>


            </div>
        </div>
        <div class="product-info__bac">
            <img src="img/bg-6.png" alt="">
        </div>
    </div>

    <div class="product-info container" id="product-info-2">
        <div class="product-info__wrapper">
            <div class="product-info__img">
                <img src="img/maasdam2024.png" alt="Традиционный Маасдам">
            </div>
            <div class="product-info__text">
                <div class="product-info-item-title">Традиционный Маасдам</div>
                <div class="product-info-item-text">
                    <p>Традиционный Маасдам— аппетитный и ароматный сыр с тонкими фруктовыми нотками во вкусе и крупными глазками в текстуре сыра.</p>
                    <p>Массовая доля жира в сухом веществе — 45%</p>
                    <p>
                        <strong>Состав:</strong> молоко нормализованное пастеризованное, соль пищевая, закваска на основе мезофильных, термофильных и пропионовокислых молочнокислых микроорганизмов, консервант нитрат натрия, молокосвертывающий ферментный препарат микробного происхождения, краситель аннато (аннато, регулятор кислотности Е525)
                    </p>
                    <p>
                        <strong>Хранить (в том числе после вскрытия упаковки):</strong> при температуре от 0°С до плюс 4°С и относительной влажности воздуха от 80% до 85% включительно
                    </p>
                    <p>
                        <strong>Дата изготовления, годен до:</strong> смотреть на упаковке
                    </p>

                    <table>
                        <tbody>
                            <tr>
                                <td rowspan="2">Средние значения пищевой ценности сыра</td>
                                <td colspan="2">Из расчета</td>
                                <td width="243">Из расчета условной рекомендованной порции</td>
                            </tr>
                            <tr>
                                <td>100 г</td>
                                <td colspan="2">20 г</td>
                            </tr>
                            <tr>
                                <td>Жир, г</td>
                                <td>27,0</td>
                                <td colspan="2">5,4</td>
                            </tr>
                            <tr>
                                <td>Белок, г</td>
                                <td>24,0</td>
                                <td colspan="2">4,8</td>
                            </tr>
                            <tr>
                                <td>Кальций, мг</td>
                                <td>1180</td>
                                <td colspan="2">236</td>
                            </tr>
                            <tr>
                                <td>Энергетическая ценность, кДж</td>
                                <td>1407</td>
                                <td colspan="2">281</td>
                            </tr>
                            <tr>
                                <td>Калорийность, ккал</td>
                                <td>339</td>
                                <td colspan="2">68</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                    <div class="product-info__bac">
                        <img src="img/bg-6.png" alt="">
                    </div>
            </div>
        </div>
    </div>

        <div class="product-info container" id="product-info-3">
            <div class="product-info__wrapper">
                <div class="product-info__img">
                    <img src="img/belebeevskiy2024.png" alt="Белебеевский">
                </div>
                <div class="product-info__text">
                    <div class="product-info-item-title">Белебеевский</div>
                    <div class="product-info-item-text">
                        <p>Белебеевский – классический сыр, сваренный по оригинальному рецепту башкирских сыроваров. Обладает сливочным вкусом и эластичной текстурой.</p>
                        <p>Массовая доля жира в сухом веществе — 45% <br>
                        СТО 00431728-001-2009
                        </p>
                        <p>
                            <strong>Состав:</strong> молоко нормализованное пастеризованное, соль пищевая, закваска на основе мезофильных , термофильных и пропионовокислых молочнокислых микроорганизмов, консервант нитрат натрия, молокосвертывающий ферментный препарат микробного происхождения, (аннато, регулятор кислотности Е 525)
                        </p>
                        <p>
                            <strong>Хранить (в том числе после вскрытия упаковки):</strong> при температуре от 0°С до плюс 4°С и относительной влажности воздуха от 80% до 85%
                        </p>
                        <p>
                            <strong>Дата изготовления, годен до:</strong> смотреть на упаковке
                        </p>

                        <table>
                            <tbody>
                                <tr>
                                    <td rowspan="2">Средние значения пищевой ценности сыра</td>
                                    <td colspan="2">Из расчета</td>
                                    <td width="243">Из расчета условной рекомендованной порции</td>
                                </tr>
                                <tr>
                                    <td>100 г</td>
                                    <td colspan="2">20 г</td>
                                </tr>
                                <tr>
                                    <td>Жир, г</td>
                                    <td>30,0</td>
                                    <td colspan="2">6</td>
                                </tr>
                                <tr>
                                    <td>Белок, г</td>
                                    <td>24,0</td>
                                    <td colspan="2">4,8</td>
                                </tr>
                                <tr>
                                    <td>Кальций, мг</td>
                                    <td>909</td>
                                    <td colspan="2">182</td>
                                </tr>
                                <tr>
                                    <td>Энергетическая ценность, кДж</td>
                                    <td>1518</td>
                                    <td colspan="2">304</td>
                                </tr>
                                <tr>
                                    <td>Калорийность, ккал</td>
                                    <td>366</td>
                                    <td colspan="2">73</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>

                    <div class="product-info__bac">
                        <img src="img/bg-6.png" alt="">
                    </div>
                </div>
            </div>
        </div>

        <div class="product-info container" id="product-info-4">
            <div class="product-info__wrapper">
                <div class="product-info__img">
                    <img src="img/honey2024.png" alt="Башкирский медовый">
                </div>
                <div class="product-info__text">
                    <div class="product-info-item-title">Башкирский медовый</div>
                    <div class="product-info-item-text">
                        <p>Башкирский медовый сыр обладает нежным вкусом и медовым ароматом. Сыр содержит 100% натуральный башкирский мед, известный во всей России своими вкусовыми качествами.</p>
                        <p>Массовая доля жира в сухом веществе — 50% <br>
                        СТО 00431728-001-2009
                        </p>
                        <p>
                            <strong>Состав:</strong> молоко нормализованное пастеризованное, соль пищевая, закваска на основе мезофильных и термофильных молочнокислых микроорганизмов, мед натуральный, консервант нитрат натрия, молокосвертывающий ферментный препарат микробного происхождения, краситель аннато (аннато, регулятор кислотности Е525), ароматизатор
                        </p>
                        <p>
                            <strong>Хранить (в том числе после вскрытия упаковки):</strong> при температуре от 0°С до плюс 4°С и относительной влажности воздуха от 80% до 85%
                        </p>
                        <p>
                            <strong>Дата изготовления, годен до:</strong> смотреть на упаковке
                        </p>

                        <table>
                            <tbody>
                                <tr>
                                    <td rowspan="2">Средние значения пищевой ценности сыра</td>
                                    <td colspan="2">Из расчета</td>
                                    <td width="243">Из расчета условной рекомендованной порции</td>
                                </tr>
                                <tr>
                                    <td>100 г</td>
                                    <td colspan="2">20 г</td>
                                </tr>
                                <tr>
                                    <td>Жир, г</td>
                                    <td>29,0</td>
                                    <td colspan="2">5,8</td>
                                </tr>
                                <tr>
                                    <td>Белок, г</td>
                                    <td>23,0</td>
                                    <td colspan="2">4,6</td>
                                </tr>
                                <tr>
                                    <td>Кальций, мг</td>
                                    <td>1262</td>
                                    <td colspan="2">252</td>
                                </tr>
                                <tr>
                                    <td>Энергетическая ценность, кДж</td>
                                    <td>1463</td>
                                    <td colspan="2">293</td>
                                </tr>
                                <tr>
                                    <td>Калорийность, ккал</td>
                                    <td>353</td>
                                    <td colspan="2">71</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>

                    <div class="product-info__bac">
                        <img src="img/bg-6.png" alt="">
                    </div>
                </div>
            </div>
        </div>

        <div class="product-info container" id="product-info-5">
            <div class="product-info__wrapper">
                <div class="product-info__img">
                    <img src="img/russian2024.png" alt="Российский">
                </div>
                <div class="product-info__text">
                    <div class="product-info-item-title">Российский</div>
                    <div class="product-info-item-text">
                        <p>Российский сыр обладает сливочным вкусом с легкой кислинкой и нежной текстурой. Рецепт подтвержден стандартами ГОСТ.</p>
                        <p>Массовая доля жира в сухом веществе — 50% <br>
                        ГОСТ 32260-2013
                        </p>
                        <p>
                            <strong>Состав:</strong> молоко нормализованное пастеризованное, соль пищевая, закваска на основе мезофильных и термофильных молочнокислых микроорганизмов, консервант нитрат натрия, молокосвертывающий ферментный препарат микробного происхождения, краситель аннато (аннато, регулятор кислотности Е 525)
                        </p>
                        <p>
                            <strong>Хранить (в том числе после вскрытия упаковки):</strong> при температуре от 0°С до плюс 4°С и относительной влажности воздуха от 80% до 85%
                        </p>
                        <p>
                            <strong>Дата изготовления, годен до:</strong> смотреть на упаковке
                        </p>
                        <table>
                            <tbody>
                                <tr>
                                    <td rowspan="2">Средние значения пищевой ценности сыра</td>
                                    <td colspan="2">Из расчета</td>
                                    <td width="243">Из расчета условной рекомендованной порции</td>
                                </tr>
                                <tr>
                                    <td>100 г</td>
                                    <td colspan="2">20 г</td>
                                </tr>
                                <tr>
                                    <td>Жир, г</td>
                                    <td>29,7</td>
                                    <td colspan="2">5,9</td>
                                </tr>
                                <tr>
                                    <td>Белок, г</td>
                                    <td>23,2</td>
                                    <td colspan="2">4,6</td>
                                </tr>
                                <tr>
                                    <td>Кальций, мг</td>
                                    <td>1286</td>
                                    <td colspan="2">257</td>
                                </tr>
                                <tr>
                                    <td>Энергетическая ценность, кДж</td>
                                    <td>1463</td>
                                    <td colspan="2">293</td>
                                </tr>
                                <tr>
                                    <td>Калорийность, ккал</td>
                                    <td>360</td>
                                    <td colspan="2">72</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="product-info__bac">
                        <img src="img/bg-6.png" alt="">
                    </div>
                </div>
            </div>
        </div>

        <div class="product-info container" id="product-info-6">
            <div class="product-info__wrapper">
                <div class="product-info__img">
                    <img src="img/kupechesky2024.png" alt="Купеческий">
                </div>
                <div class="product-info__text">
                    <div class="product-info-item-title">Купеческий</div>
                    <div class="product-info-item-text">
                        <p>Купеческий — сыр с насыщенным сладковато-пряным вкусом и тающей текстурой. Сыр легко плавится и становится еще вкуснее в горячем виде.</p>
                        <p>Массовая доля жира в сухом веществе — 52%<br>
                        СТО 00431728-001-2009
                        </p>
                        <p>
                            <strong>Состав:</strong> молоко нормализованное пастеризованное, соль пищевая, закваска на основе мезофильных и термофильных молочнокислых микроорганизмов, консервант нитрат натрия, молокосвертывающий ферментный препарат микробного происхождения, краситель аннато (аннато, регулятор кислотности Е 525)
                        </p>
                        <p>
                            <strong>Хранить (в том числе после вскрытия упаковки):</strong> при температуре от 0°С до плюс 4°С и относительной влажности воздуха от 80% до 85%
                        </p>
                        <p>
                            <strong>Дата изготовления, годен до:</strong> смотреть на упаковке
                        </p>
                        <table>
                            <tbody>
                                <tr>
                                    <td rowspan="2">Средние значения пищевой ценности сыра</td>
                                    <td colspan="2">Из расчета</td>
                                    <td width="243">Из расчета условной рекомендованной порции</td>
                                </tr>
                                <tr>
                                    <td>100 г</td>
                                    <td colspan="2">20 г</td>
                                </tr>
                                <tr>
                                    <td>Жир, г</td>
                                    <td>30,0</td>
                                    <td colspan="2">6</td>
                                </tr>
                                <tr>
                                    <td>Белок, г</td>
                                    <td>22,0</td>
                                    <td colspan="2">4,4</td>
                                </tr>
                                <tr>
                                    <td>Кальций, мг</td>
                                    <td>1203</td>
                                    <td colspan="2">240</td>
                                </tr>
                                <tr>
                                    <td>Энергетическая ценность, кДж</td>
                                    <td>1484</td>
                                    <td colspan="2">297</td>
                                </tr>
                                <tr>
                                    <td>Калорийность, ккал</td>
                                    <td>358</td>
                                    <td colspan="2">72</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="product-info__bac">
                        <img src="img/bg-6.png" alt="">
                    </div>
                </div>
            </div>
        </div>

        <div class="product-info container" id="product-info-7">
            <div class="product-info__wrapper">
                <div class="product-info__img">
                    <img src="img/yogurt2024.png" alt="Йогуртовый легкий">
                </div>
                <div class="product-info__text">
                    <div class="product-info-item-title">Йогуртовый легкий</div>
                    <div class="product-info-item-text">
                        <p>Особенный сыр, приготовленный на свежем молоке и йогуртовых заквасках. Он обладает мягким кисломолочным вкусом и нежной текстурой.</p>
                        <p>Массовая доля жира в сухом веществе — 35%<br>
                        СТО 00431728-001-2009
                        </p>
                        <p>
                            <strong>Состав:</strong> молоко нормализованное пастеризованное, соль пищевая, закваска на основе мезофильных, термофильных молочнокислых микроорганизмов и болгарской молочнокислой палочки, консервант нитрат натрия, молокосвертывающий ферментный препарат микробного происхождения
                        </p>
                        <p>
                            <strong>Хранить (в том числе после вскрытия упаковки):</strong> при температуре от 0°С до плюс 4°С и относительной влажности воздуха от 80% до 85%
                        </p>
                        <p>
                            <strong>Дата изготовления, годен до:</strong> смотреть на упаковке
                        </p>
                        <table>
                            <tbody>
                                <tr>
                                    <td rowspan="2">Средние значения пищевой ценности сыра</td>
                                    <td colspan="2">Из расчета</td>
                                    <td width="243">Из расчета условной рекомендованной порции</td>
                                </tr>
                                <tr>
                                    <td>100 г</td>
                                    <td colspan="2">20 г</td>
                                </tr>
                                <tr>
                                    <td>Жир, г</td>
                                    <td>19</td>
                                    <td colspan="2">3,8</td>
                                </tr>
                                <tr>
                                    <td>Белок, г</td>
                                    <td>25</td>
                                    <td colspan="2">5</td>
                                </tr>
                                <tr>
                                    <td>Кальций, мг</td>
                                    <td>831</td>
                                    <td colspan="2">166</td>
                                </tr>
                                <tr>
                                    <td>Энергетическая ценность, кДж</td>
                                    <td>1128</td>
                                    <td colspan="2">226</td>
                                </tr>
                                <tr>
                                    <td>Калорийность, ккал</td>
                                    <td>271</td>
                                    <td colspan="2">54</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="product-info__bac">
                        <img src="img/bg-6.png" alt="">
                    </div>
                </div>
            </div>
        </div>

        <div class="product-info container" id="product-info-8">
            <div class="product-info__wrapper">
                <div class="product-info__img">
                    <img src="img/holland2024.png" alt="Голландский">
                </div>
                <div class="product-info__text">
                    <div class="product-info-item-title">Голландский</div>
                    <div class="product-info-item-text">
                        <p>Голландский сыр приготовлен по традиционному рецепту, подтвержден стандартом ГОСТ. Обладает выраженным сливочным вкусом и легко плавится.</p>
                        <p>Массовая доля жира в сухом веществе — 45%<br>
                        ГОСТ 32260-2013
                        </p>
                        <p>
                            <strong>Состав:</strong> молоко нормализованное пастеризованное, соль пищевая, закваска на основе мезофильных и термофильных молочнокислых микроорганизмов, консервант нитрат натрия, молокосвертывающий ферментный препарат микробного происхождения, краситель аннато (аннато, регулятор кислотности Е525)
                        </p>
                        <p>
                            <strong>Хранить (в том числе после вскрытия упаковки):</strong> при температуре от 0°С до плюс 4°С и относительной влажности воздуха от 80% до 85%
                        </p>
                        <p>
                            <strong>Дата изготовления, годен до:</strong> смотреть на упаковке
                        </p>
                        <table>
                            <tbody>
                                <tr>
                                    <td rowspan="2">Средние значения пищевой ценности сыра</td>
                                    <td colspan="2">Из расчета</td>
                                    <td width="243">Из расчета условной рекомендованной порции</td>
                                </tr>
                                <tr>
                                    <td>100 г</td>
                                    <td colspan="2">20 г</td>
                                </tr>
                                <tr>
                                    <td>Жир, г</td>
                                    <td>25,2</td>
                                    <td colspan="2">5,0</td>
                                </tr>
                                <tr>
                                    <td>Белок, г</td>
                                    <td>26,8</td>
                                    <td colspan="2">5,4</td>
                                </tr>
                                <tr>
                                    <td>Кальций, мг</td>
                                    <td>1101</td>
                                    <td colspan="2">220</td>
                                </tr>
                                <tr>
                                    <td>Энергетическая ценность, кДж</td>
                                    <td>1396</td>
                                    <td colspan="2">279</td>
                                </tr>
                                <tr>
                                    <td>Калорийность, ккал</td>
                                    <td>334</td>
                                    <td colspan="2">67</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="product-info__bac">
                        <img src="img/bg-6.png" alt="">
                    </div>
                </div>
            </div>
        </div>

        <div class="product-info container" id="product-info-9">
            <div class="product-info__wrapper">
                <div class="product-info__img">
                    <img src="img/gouda2024.png" alt="Гауда экстра">
                </div>
                <div class="product-info__text">
                    <div class="product-info-item-title">Гауда экстра</div>
                    <div class="product-info-item-text">
                        <p>Гауда экстра — сыр со сливочный вкусом с пикантными нотками, обладает эластичной текстурой.</p>
                        <p>Массовая доля жира в сухом веществе — 45%<br>
                        СТО 00431728-001-2009
                        </p>
                        <p>
                            <strong>Состав:</strong> молоко нормализованное пастеризованное, соль пищевая, закваска на основе мезофильных и термофильных молочнокислых микроорганизмов, консервант нитрат натрия, молокосвертывающий ферментный препарат микробного происхождения, краситель аннато (аннато, регулятор кислотности Е525)
                        </p>
                        <p>
                            <strong>Хранить (в том числе после вскрытия упаковки):</strong> при температуре от 0°С до плюс 4°С и относительной влажности воздуха от 80% до 85%
                        </p>
                        <p>
                            <strong>Дата изготовления, годен до:</strong> смотреть на упаковке
                        </p>
                        <table>
                            <tbody>
                                <tr>
                                    <td rowspan="2">Средние значения пищевой ценности сыра</td>
                                    <td colspan="2">Из расчета</td>
                                    <td width="243">Из расчета условной рекомендованной порции</td>
                                </tr>
                                <tr>
                                    <td>100 г</td>
                                    <td colspan="2">20 г</td>
                                </tr>
                                <tr>
                                    <td>Жир, г</td>
                                    <td>26,5</td>
                                    <td colspan="2">5,3</td>
                                </tr>
                                <tr>
                                    <td>Белок, г</td>
                                    <td>27,0</td>
                                    <td colspan="2">5,4</td>
                                </tr>
                                <tr>
                                    <td>Кальций, мг</td>
                                    <td>1501</td>
                                    <td colspan="2">300</td>
                                </tr>
                                <tr>
                                    <td>Энергетическая ценность, кДж</td>
                                    <td>1440</td>
                                    <td colspan="2">288</td>
                                </tr>
                                <tr>
                                    <td>Калорийность, ккал</td>
                                    <td>347</td>
                                    <td colspan="2">69</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="product-info__bac">
                        <img src="img/bg-6.png" alt="">
                    </div>
                </div>
            </div>
        </div>

        <div class="product-info container" id="product-info-10">
            <div class="product-info__wrapper">
                <div class="product-info__img">
                    <img src="img/parmesanbelster.png" alt="Belster Parmesan">
                </div>
                <div class="product-info__text">
                    <div class="product-info-item-title">Belster Parmesan</div>
                    <div class="product-info-item-text">
                        <p>Массовая доля жира в сухом веществе — 40%<br>
                        СТО 00431728-005-2014
                        </p>
                        <p>
                            <strong>Состав:</strong> молоко нормализированное пастеризованное, соль пищевая, закваска на основе мезофильных и термофильных молочнокислых микроорганизмов, консервант нитрат натрия, молокосвертывающий ферментный препарат животного происхождения
                        </p>
                        <p>
                            <strong>Хранить:</strong> при температуре от 0°С до плюс 4°С и относительной влажности воздуха от 80% до 85%
                        </p>
                        <p>
                            <strong>Срок годности:</strong> 6 месяцев
                        </p>
                        <p>
                            <strong>Средние значения пищевой ценности на 100 г продукта:</strong> белок-30 г, жир — 28 г, энергетическая ценность (калорийность) 1546 кДж (372 ккал)
                        </p>
                    </div>
                    <div class="product-info__bac">
                        <img src="img/bg-6.png" alt="">
                    </div>
                </div>
            </div>
        </div>

        <div class="product-info container" id="product-info-11">
            <div class="product-info__wrapper">
                <div class="product-info__img">
                    <img src="img/supreme.png" alt="Supreme">
                </div>
                <div class="product-info__text">
                    <div class="product-info-item-title">Supreme</div>
                    <div class="product-info-item-text">
                        <p>Нежнейший сливочный мягкий сыр с белой бархатистой корочкой, произведенный по уникальной французской рецептуре.
                        </p>
                        <p>
                        Непревзойденный вкус мягкого сыра Supreme надолго запомнится благодаря сбалансированному сочетанию сливочного тающего «сердца», нежной бархатистой корочки и едва уловимого свежего грибного аромата.
                        </p>
                        <p>
                            <strong>Насладитесь уровнем удовольствия Supreme!</strong> 
                        </p>
                    </div>
                    <div class="product-info__bac">
                        <img src="img/bg-6.png" alt="">
                    </div>
                </div>
            </div>
        </div>

        <div class="product-info container" id="product-info-12">
            <div class="product-info__wrapper">
                <div class="product-info__img">
                    <img src="img/kr2024.png" alt="Масло «Крестьянское», 72,5%">
                </div>
                <div class="product-info__text">
                    <div class="product-info-item-title">Масло «Крестьянское», 72,5%</div>
                    <div class="product-info-item-text">
                        <p>Масло с мягким сладко-сливочным вкусом. Сделано из 100% свежих сливок. Подходит как для бутербродов, так и для приготовления блюд. Высокое качество по стандартам ГОСТ.</p>
                        <p>Массовая доля жира — 72,5%<br>Сорт высший <br>
                        ГОСТ 32261-2013
                        </p>
                        <p>
                            <strong>Состав:</strong> пастеризованные сливки
                        </p>
                        <p>
                            <strong>Срок годности:</strong> при температуре минус (16±2)°С-120 сут, в том числе при температуре  (3±2)ºС и относительной влажности воздуха не более 90% – 60 сут.
                        </p>
                        <table>
                            <tbody>
                                <tr>
                                    <td rowspan="2"> <strong>Средние значения пищевой ценности сыра</strong></td>
                                    <td colspan="2">Из расчета</td>
                                    <td width="243">Из расчета условной рекомендованной порции</td>
                                </tr>
                                <tr>
                                    <td>100 г</td>
                                    <td colspan="2">10 г</td>
                                </tr>
                                <tr>
                                    <td>Жир, г</td>
                                    <td>72,5</td>
                                    <td colspan="2">7,2</td>
                                </tr>
                                <tr>
                                    <td>Углеводы, г</td>
                                    <td>1,4</td>
                                    <td colspan="2">0,1</td>
                                </tr>
                                <tr>
                                    <td>Белок, г</td>
                                    <td>1,0</td>
                                    <td colspan="2">0,1</td>
                                </tr>
                                <tr>
                                    <td>Энергетическая ценность, кДж</td>
                                    <td>2772</td>
                                    <td colspan="2">277</td>
                                </tr>
                                <tr>
                                    <td>Калорийность, ккал</td>
                                    <td>662</td>
                                    <td colspan="2">66</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="product-info__bac">
                        <img src="img/bg-6.png" alt="">
                    </div>
                </div>
            </div>
        </div>

        <div class="product-info container" id="product-info-13">
            <div class="product-info__wrapper">
                <div class="product-info__img">
                    <img src="img/trad2024.png" alt="Масло «Традиционное», 82,5%">
                </div>
                <div class="product-info__text">
                    <div class="product-info-item-title">Масло «Традиционное», 82,5%</div>
                    <div class="product-info-item-text">
                        <p>Масло с мягким сладко-сливочным вкусом. Сделано из 100% свежих сливок. Подходит как для бутербродов, так и для приготовления блюд. Высокое качество по стандартам ГОСТ.</p>
                        <p>Массовая доля жира — 82,5%<br>Сорт высший <br>
                        ГОСТ 32261-2013
                        </p>
                        <p>
                            <strong>Состав:</strong> пастеризованные сливки
                        </p>
                        <p>
                            <strong>Срок годности:</strong> при температуре минус (16±2)°С-120 сут, в том числе при температуре  (3±2)ºС и относительной влажности воздуха не более 90% – 60 сут.
                        </p>
                        <table>
                            <tbody>
                                <tr>
                                    <td rowspan="2"> <strong>Средние значения пищевой ценности сыра</strong></td>
                                    <td colspan="2">Из расчета</td>
                                    <td width="243">Из расчета условной рекомендованной порции</td>
                                </tr>
                                <tr>
                                    <td>100 г</td>
                                    <td colspan="2">10 г</td>
                                </tr>
                                <tr>
                                    <td>Жир, г</td>
                                    <td>82,5</td>
                                    <td colspan="2">8,2</td>
                                </tr>
                                <tr>
                                    <td>Углеводы, г</td>
                                    <td>0,8</td>
                                    <td colspan="2">0,1</td>
                                </tr>
                                <tr>
                                    <td>Белок, г</td>
                                    <td>0,6</td>
                                    <td colspan="2">0,1</td>
                                </tr>
                                <tr>
                                    <td>Энергетическая ценность, кДж</td>
                                    <td>3132</td>
                                    <td colspan="2">313</td>
                                </tr>
                                <tr>
                                    <td>Калорийность, ккал</td>
                                    <td>748</td>
                                    <td colspan="2">75</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="product-info__bac">
                        <img src="img/bg-6.png" alt="">
                    </div>
                </div>
            </div>
        </div>

        <div class="product-info container" id="product-info-14">
            <div class="product-info__wrapper">
                <div class="product-info__img">
                    <img src="img/butter2024.png" alt="Масло «Бутербродное», 61,5%">
                </div>
                <div class="product-info__text">
                    <div class="product-info-item-title">Масло «Бутербродное», 61,5%</div>
                    <div class="product-info-item-text">
                        <p>Масло с мягким сладко-сливочным вкусом. Сделано из 100% свежих сливок. Подходит как для бутербродов, так и для приготовления блюд. Высокое качество по стандартам ГОСТ.</p>
                        <p>Массовая доля жира — 61,5%<br>
                        ГОСТ Р 52253-2004
                        </p>
                        <p>
                            <strong>Состав:</strong> пастеризованные сливки
                        </p>
                        <p>
                            <strong>Срок годности:</strong> при температуре минус (16±2)°С-120 сут, в том числе при температуре  (3±2)ºС и относительной влажности воздуха не более 90% – 60 сут.
                        </p>
                        <table>
                            <tbody>
                                <tr>
                                    <td rowspan="2"> <strong>Средние значения пищевой ценности сыра</strong></td>
                                    <td colspan="2">Из расчета</td>
                                    <td width="243">Из расчета условной рекомендованной порции</td>
                                </tr>
                                <tr>
                                    <td>100 г</td>
                                    <td colspan="2">10 г</td>
                                </tr>
                                <tr>
                                    <td>Жир, г</td>
                                    <td>61,5</td>
                                    <td colspan="2">6,1</td>
                                </tr>
                                <tr>
                                    <td>Углеводы, г</td>
                                    <td>1,9</td>
                                    <td colspan="2">0,2</td>
                                </tr>
                                <tr>
                                    <td>Белок, г</td>
                                    <td>1,4</td>
                                    <td colspan="2">0,1</td>
                                </tr>
                                <tr>
                                    <td>Энергетическая ценность, кДж</td>
                                    <td>2332</td>
                                    <td colspan="2">233</td>
                                </tr>
                                <tr>
                                    <td>Калорийность, ккал</td>
                                    <td>567</td>
                                    <td colspan="2">57</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="product-info__bac">
                        <img src="img/bg-6.png" alt="">
                    </div>
                </div>
            </div>
        </div>
        </section>

        <section class="Serum">
            <div class="about-assort-item-content container">
                <div class="about-assort-item-title">Сыворотка молочная сухая подсырная</div>
                <p>Сыворотка изготавливается из несоленой сухой подсырной сыворотки, получаемой при производстве сыров. Сухой продукт производится путем частичной деминерализации (до 50%) с последующим сгущением, кристаллизацией и распылительной сушкой.</p>
                <p>С помощью современного мембранного оборудования (нанофильтрации) содержание золы в нашей сыворотке снижается до 4,6-5%.</p>
                <p>
                    <strong>Применение на производстве:</strong> пищевые продукты, кондитерские изделия, спортивное питание, сухой заменитель цельного молока и многое другое
                </p>
                <hr>
                <div class="sivorotka_cloud">
                    <p><strong>Жиры:</strong> до 1,5 гр</p>
                    <p><strong>Белки:</strong> 11-12%</p>
                    <p><strong>Лактоза:</strong> от 75%</p>
                    <p><strong>Зольность:</strong> 4,6-5%</p>
                    <p><strong>Срок годности:</strong> 12 месяцев</p>
                </div>
                <hr>
                <p>Сертификат на соответствие стандарту Халяль в международном сертификационном центре.</p>
                <hr>
                <p><strong>Телефон:</strong>  +7 (34786) 4-47-90
                <br>
                <strong>E-mail:</strong> <a href="mailto:Fake@belmol.ru">Fake@belmol.ru</a> 
                </p>
            </div>
        </section>

        <section class="about-block" id="about-block">
            <div class="container">
                <div class="about-block-inner">
                    <h2 class="article-title">8 фактов о Белебеевском молочном комбинате</h2>
                    <div class="about-block-list">
                        <div class="about-block-item">
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <div class="about-block-item-title about-block-item-title-1">
                                    С 1932 года
                                    </div>
                                    <p>Один из <b>крупнейших российских производителей</b> твердых сычужных сыров, основан в 1932 году.</p>
                                </div>
                            
                                <div class="col-lg-6 col-md-6 col-sm-6">
                                        <div class="about-block-item-title about-block-item-title-2">
                                        По всей России и СНГ
                                        </div>
                                        <p>Обладает широкой дистрибьюторской сетью в Центральном и Северо-западном регионе, в том числе <b>Москве и Санкт-Петербурге, Сибири, Поволжье, Южном федеральном округе и на Урале</b> , осуществляет экспорт в <b>Казахстан.</b></p>
                                    </div>
                                </div>
                            </div>


                            <div class="about-block-item">
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-6">
                                        <div class="about-block-item-title about-block-item-title-3">
                                        В 250 городах
                                        </div>
                                        <p>Качественные сыр, масло и спред более чем в 250 крупных городах и населенных пунктах от  <b>Краснодара до Хабаровска.</b></p>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6">
                                        <div class="about-block-item-title about-block-item-title-4">
                                        Натуральные продукты
                                        </div>
                                        <p>В Башкирии еще сохранились луга с уникальным разнотравием в экологически чистой зоне. Это позволяет получать высококачественное молоко, содержащее в себе все полезные вещества, необходимые  для организма человека.  Именно из этого молока вырабатывается наша продукция.</p>
                                    </div>
                                </div>
                            </div>

                            <div class="about-block-item">
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-6">
                                        <div class="about-block-item-title about-block-item-title-5">
                                        Разнообразие ассортимента
                                        </div>
                                        <p>Выпускает множество видов вкусных полутвердых сыров и сливочных масел Белебеевский, твёрдый сыр Belster Parmesan, а также мягкий сыр Supreme</p>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6">
                                        <div class="about-block-item-title about-block-item-title-6">
                                        550 тонн/сутки
                                        </div>
                                        <p>Пропускная способность крупнейшей в России сыродельной линии — 550 тонн молока в сутки</p>
                                    </div>
                                </div>
                            </div>

                            <div class="about-block-item">
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-6">
                                        <div class="about-block-item-title about-block-item-title-7">
                                        1000 тонн/месяц
                                        </div>
                                        <p>Ежемесячно Белебеевский молочный комбинат производит и продает более 1000 тонн сыра.</p>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6">
                                        <div class="about-block-item-title about-block-item-title-8">
                                        70 брикетов/минуту
                                        </div>
                                        <p>Производительность автоматизированной линии по фасовке масла и спреда — 70 брикетов в минуту</p>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </section>

        <section class="fabric-slider-wrap">
        <div class="caption-carousel">
                <div>Цех по производству и упаковке масла</div>
                <div>Пульт управления сыроизготовителями</div>
                <div>Производители молока</div>
                <div>Линия упаковки масла</div>
                <div>Конвейер новой линии</div>
                <div>Сырохранилище</div>
                <div>Новая автоматизированная линия по производству сыров</div>
            </div>
            <div class="carousel3">
                <div><img src="img/11.jpg" alt="Slide 1"></div>
                <div><img src="img/21.jpg" alt="Slide 2"></div>
                <div><img src="img/31.jpg" alt="Slide 3"></div>
                <div><img src="img/4.jpg" alt="Slide 4"></div>
                <div><img src="img/5.jpg" alt="Slide 4"></div>
                <div><img src="img/6.jpg" alt="Slide 4"></div>
                <div><img src="img/7.jpg" alt="Slide 4"></div>
            </div>
            
            <div class="carousel3-buttons">
                <button class="carousel3-prev-button"><</button>
                <button class="carousel3-next-button">></button>
            </div>
        </section>

        <section class="history-block container">
            <div class="history-block-inner">
                <h2 class="article-title">Высокие технологии — высокое качество</h2>
                <div class="history-block-list">
                    <div class="history-block-item">
                        <div class="history-block-item-year">
                            <b>2015 год</b>
                        </div>
                        <div class="history-block-item-info">
                        На предприятии запустили новую фасовочную линию масла, позволяющую выпускать масло в 200-граммовых брикетах. Упаковка продукта стала более яркой и технологичной, что позволило обеспечить сохранность товарного вида и гарантию неизменно высокого качества продукта.
                        </div>
                    </div>
                    
                    <div class="history-block-item">
                        <div class="history-block-item-year">
                            <b>2013 год</b>
                        </div>
                        <div class="history-block-item-info">
                        На комбинате установлена современная фасовочная линия, которая позволяет нарезать кусками и слайсами сыр фиксированного веса от 150 до 500 грамм и упаковывать их в полимерные пленки типа флоу-пак и термоформаж в среде защитных газов. Линия оснащена самым современным оборудованием ведущих мировых производителей, в т.ч. ALPMA (Германия) , ILAPAK (Швейцария).
                        </div>
                    </div>

                    <div class="history-block-item">
                        <div class="history-block-item-year">
                            <b>2010 год</b>
                        </div>
                        <div class="history-block-item-info">
                        На предприятии запущена линия по производству сухой деминерализованной молочной сыворотки по технологии нанофильтрации, которая сегодня является самым эффективным способом утилизации побочного продукта сырного производства. Мощность линии – 40 тонн в сутки.
                        </div>
                    </div>

                    <div class="history-block-item">
                        <div class="history-block-item-year">
                            <b>2008 год</b>
                        </div>
                        <div class="history-block-item-info">
                        На комбинате завершена комплексная модернизация производства. Это дало возможность увеличить производство сыра в два раза. Производственная мощность новой сыродельной линии составляет 550 тонн молока в сутки и на настоящий момент она является крупнейшей на территории России.
                        </div>
                    </div>

                    <div class="history-block-item">
                        <div class="history-block-item-year">
                            <b>2007 год</b>
                        </div>
                        <div class="history-block-item-info">
                        Введен в действие новый аппаратный цех по подготовке и комплексной очистке молока.
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <section class="news-block" id="news-block">
            <div class="container">
                <div class="news-block-inner">
                    <div class="news-block-inner-row">
                        <div class="col-lg-8 col-md-8 col-sm-8">
                            <h2 class="article-title">Новости</h2>
                            
                            <div class="news-list">
                                <div class="news-list-item-title">
                                    <span>Белебеевский – выбор чемпионов!</span>
                                </div>
                                <div class="news-list-item-excerpt">
                                    <p>Белебеевский – выбор чемпионов!
                                    Натуральные сыры Белебеевского молочного комбината являются одним из элементов здорового образа жизни. Все знают, как важна роль правильных молочных продуктов в сбалансированном питании. 
                                    </p>
                                </div>
                            </div>

                            <div class="news-list">
                                <div class="news-list-item-title">
                                    <span>Глава Республики наградил работников Белебеевского молочного комбината</span>
                                </div>
                                <div class="news-list-item-excerpt">
                                    <p>Рустэм Хамитов лично вручил государственные награды республики работникам агропромышленного комплекса и пищевой промышленности. Среди награждённых – начальник сырохранилища АО «Белебеевский ордена «Знак Почета» молочный комбинат» Ольга Петровна Подгорная. Само предприятие удостоилось высокой правительственной награды как лучшее предприятие по переработке сельскохозяйственной продукции.
                                    </p>
                                </div>
                            </div>

                            <div class="news-list">
                                <div class="news-list-item-title">
                                    <span>Белебеевский сыр признали лучшим в России</span>
                                </div>
                                <div class="news-list-item-excerpt">
                                    <p>Продукция Белебеевского молочного комбината получила заслуженные награды за производство высококачественных продовольственных товаров. По итогам общероссийского смотра дипломантами конкурса стали сыры «Белебеевский», «Купеческий» и «Башкирский медовый», лауретом – спред «Уральские просторы» и «Уральские просторы шоколадные», а выдержанный сыр «Бельстер Янг» вошел в первую сотню лучших товаров и, по итогам 2017 года, попал в рейтинг «Золотая сотня».
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <section class="docs-iso" id="iso">
            <div class="container">
                <h2 class="article-title">Сертификаты ISO</h2>
                <div class="attachments">
                    <a class="documents pdf cboxElement" target="_blank" href="https://belmol.ru/wp-content/uploads/2015/12/FSSC-22-000-v4.1.pdf">
                        <div>FSSC 22 000 (v4.1)</div>
                        <div>638 kB</div>
                    </a>
                    <a class="documents pdf cboxElement" target="_blank" href="https://belmol.ru/wp-content/uploads/2015/12/ISO-9001-2015.pdf">
                        <div>ISO 9001-2015</div>
                        <div>903 kB</div>
                    </a>
                    <a class="documents pdf cboxElement" target="_blank" href="https://belmol.ru/wp-content/uploads/2015/12/FSSC-V5-31100726-FSSC-V5-RU.pdf">
                        <div>FSSC V5 31100726 FSSC V5 RU</div>
                        <div>87 kB</div>
                    </a>
                    <a class="documents pdf cboxElement" target="_blank" href="https://belmol.ru/wp-content/uploads/2015/12/FSSC-V5-31100726-FSSC-V5-EN.pdf">
                        <div>FSSC V5 31100726 FSSC V5 EN</div>
                        <div>464 kB</div>
                    </a>
                </div>
            </div>
        </section>

        <section class="docs">
            <div class="container">
                <h2 class="article-title">
                Документы в соответствии с Федеральным законом № 426-ФЗ «О специальной оценке условий труда»
                </h2>
                <div class="attachments">
                    <a class="documents pdf cboxElement" target="_blank" href="https://belmol.ru/wp-content/uploads/2015/11/1.-Perechen-rekomenduemyh-meropriyatij-po-uluchsheniyu-uslovij-truda-maj-2022.pdf">
                        <div>1. Перечень рекомендуемых мероприятий по улучшению условий труда май 2022</div>
                        <div>2 MB</div>
                    </a>
                    <a class="documents pdf cboxElement" target="_blank" href="https://belmol.ru/wp-content/uploads/2015/11/2.-Svodnaya-vedomost-rezultatov-provedeniya-spetsotsenki-uslovij-truda-maj-2022.pdf">
                        <div>2. Сводная ведомость результатов проведения спецоценки условий труда май 2022</div>
                        <div>2 MB</div>
                    </a>
                    <a class="documents pdf cboxElement" target="_blank" href="https://belmol.ru/wp-content/uploads/2015/11/3.-Perechen-rekomenduemyh-meropriyatij-po-uluchsheniyu-uslovij-truda-iyul-2022.pdf">
                        <div>3. Перечень рекомендуемых мероприятий по улучшению условий труда июль 2022</div>
                        <div>901 kB</div>
                    </a>
                    <a class="documents pdf cboxElement" target="_blank" href="https://belmol.ru/wp-content/uploads/2015/11/4.-Svodnaya-vedomost-rezultatov-provedeniya-spetsotsenki-uslovij-truda-iyul-2022.pdf">
                        <div>4. Сводная ведомость результатов проведения спецоценки условий труда июль 2022</div>
                        <div>2 MB</div>
                    </a>
                    <a class="documents pdf cboxElement" target="_blank" href="https://belmol.ru/wp-content/uploads/2015/11/5.-Perechen-rekomenduemyh-meropriyatij-po-uluchsheniyu-uslovij-truda-Narezka-noyabr-2023.pdf">
                        <div>5. Перечень рекомендуемых мероприятий по улучшению условий труда Нарезка ноябрь 2023</div>
                        <div>2 MB</div>
                    </a>
                    <a class="documents pdf cboxElement" target="_blank" href="https://belmol.ru/wp-content/uploads/2015/11/6.-Svodnaya-vedomost-rezultatov-provedeniya-spetsotsenki-uslovij-truda-noyabr-2023.pdf">
                        <div>6. Сводная ведомость результатов проведения спецоценки условий труда ноябрь 2023</div>
                        <div>1 MB</div>
                    </a>
                </div>
            </div>
        </section>
        <section class="video">
            <video controls="controls" src="video/Реклама сыров «Белебеевский» 2020.mp4"></video>
        </section>

        <section class="map-block container">
            <h2 class="article-title">По всей стране</h2>
            <div class="col-lg-12">
                <img src="img/Karta-1.png" alt="">
            </div>
        </section>
        <section class="contacts container" id="contacts">
            <h2 class="article-title">Контакты</h2>
            <div class="contacts-block-list">
                <div class="contacts-block-item">
                    <strong>Москва</strong>
                    <br>
                    ул. Кожевническая, д. 14, стр. 5
                    <br>
                    +7 (495) 159-60-37
                    <br>
                    По общим вопросам: <a href="mailto:infoFake@belmol.ru">infoFake@belmol.ru</a>
                    <br>
                    По вопросам качества: <a href="mailto:ClaimFake@belmol.ru">ClaimFake@belmol.ru</a>
                </div>
                <div class="contacts-block-item">
                    <strong>Уфа</strong>
                    <br>
                    ул. Цветочная, 3/3
                    <br>
                    +7 (347) 216 16 33
                </div>
                <div class="contacts-block-item">
                    <strong>Белебей</strong>
                    <br>
                    ул. Восточная, 78
                    <br>
                    +7 (34786) 5-90-29
                </div>
            </div>
        </section>
        <div class="container">
        <script type="text/javascript" charset="utf-8" async src="https://api-maps.yandex.ru/services/constructor/1.0/js/?um=constructor%3A089e39e6009badeee7454c634edb60cc4bd8f9e2deec4622618aa4f0011922d3&amp;width=975&amp;height=545&amp;lang=ru_RU&amp;scroll=true"></script>
        </div>
        

        <div class="footer">
            <div class="container">
                <div class="textwidget">Белебеевский молочный комбинат</div>
            </div>
        </div>

        <script>
            
            window.addEventListener('DOMContentLoaded', function() {
                var navMenu = document.getElementById('navMenu');
                var bottomNavMenu = document.getElementById('bottomNavMenu');
                bottomNavMenu.style.opacity = '0';
            });
            window.addEventListener('scroll', function() {
                var navMenu = document.getElementById('navMenu');
                var bottomNavMenu = document.getElementById('bottomNavMenu');
                if (window.scrollY > navMenu.offsetHeight) {
                    navMenu.style.transition = 'opacity 0.3s ease';
                    bottomNavMenu.style.transition = 'opacity 0.3s ease';
                    navMenu.style.opacity = '0';
                    bottomNavMenu.style.opacity = '1';
                } else {
                    navMenu.style.transition = 'opacity 0.3s ease';
                    bottomNavMenu.style.transition = 'opacity 0.3s ease';
                    navMenu.style.opacity = '1';
                    bottomNavMenu.style.opacity = '0';
                }
            });

            function highlightCard(cardNumber) {
                // Получаем все карточки
                var cards = document.querySelectorAll(".prod-slider-item");

                // Убираем класс "active" у всех карточек
                cards.forEach(function(card) {
                    card.classList.remove("active");
                });

                // Добавляем класс "active" к выбранной карточке
                var selectedCard = document.querySelector(".card-" + cardNumber);
                if (selectedCard) {
                    selectedCard.classList.add("active");
                }
            }

            function showInfo(blockNumber) {
                // Получаем все блоки с информацией о продукте
                var infoBlocks = document.querySelectorAll(".product-info");

                // Скрываем все блоки с информацией о продукте
                infoBlocks.forEach(function(block) {
                    block.style.display = "none";
                });

                // Показываем информацию только для выбранного блока
                var infoBlockToShow = document.getElementById("product-info-" + blockNumber);
                if (infoBlockToShow) {
                    infoBlockToShow.style.display = "block";
                }
            }

            // Выполняем при загрузке страницы
            window.onload = function() {
                // Показываем информацию для первого блока
                showInfo(1);
                // Подсвечиваем первую карточку в карусели
                highlightCard(1);
            };
            
        </script>
        <script src="vendor/index.js"></script>
</body>
</html>
# CookingCraze
<b>Тестовое задание для Matryoshka Games</b>

<b>Задание состоит из следующих этапов:</b><ul>
<li> Реализовать недостающие методы (CustomersController.ServeOrder и
FoodTrasher.TryTrashFood).</li>
<li> На основе имеющегося кода реализовать второе блюдо (хот-доги с добавкой в виде
горчицы). Все необходимые спрайты уже есть в проекте в папке Resources/Images.</li>
<li> Добавить отсутствующее окно, которое должно показываться на старте игры (его
описание есть ниже, в разделе, описывающем механику прототипа).</li></ul>

<b>Механика игры</b>

На уровне ожидается 15 посетителей с заказом из 1-3 случайно сгенерированных блюд.
Каждые 3 секунды должен появляться покупатель (максимум 4 одновременно). Заказы
отображаются в UI-окошках слева от покупателя. Также в окошке есть таймер ожидания (18
секунд) в виде вертикальной полоски.
При выполнении заказа или по истечению таймера ожидания посетитель со своим окошком
исчезает и, если еще остались свободные заказы (из списка, сгенерированного на старте
уровня), через 3 секунды на этом месте появляется новый посетитель с новым заказом. Если
свободных заказов не осталось, место остается пустым.
Игровая сессия длится до тех пор, пока не будут обслужены все гости. Отдать гостю можно
только то блюдо, которое есть в окошке-заказе. Каждое отданное блюдо прибавляет к
оставшемуся времени ожидания обслуженного гостя 6 секунд, если блюдо в заказе не
последнее. Время ожидания не может быть больше 18 секунд. Цель игры – отдать
определенное количество блюд. Количество блюд для выигрыша вычисляется по формуле:
общее количество блюд у всех гостей на уровне минус два.
После того как игрок приготовил блюдо, он может отдать его посетителю тапом по блюду.
Если одно и то же блюдо есть в заказе больше, чем у одного гостя, блюдо автоматически
отдаётся гостю с наименьшим оставшимся временем ожидания.
После того, как последнее блюдо на уровне отдано или у последнего гостя закончилось
время ожидания и он ушёл, производится подсчет отданных блюд. Если количество блюд
достаточное – игрок побеждает, если меньше – проигрывает.

<b>Меню</b>

Перед началом игры поверх ресторана должно быть окошко с указанием необходимого
количества блюд для выигрыша и кнопкой “Играть”.
По завершению уровня показывается окно победы/поражения.

Окно выигрыша содержит:<ul>
<li> Кнопку “продолжить”, которая заканчивает игровую сессию.</li>
<li> Количество отданных блюд и необходимых в формате: отдал/необходимо.</li></ul>
Окно проигрыша содержит:<ul>
<li> Кнопку “повторить”, которая перезапускает уровень.</li>
<li> Количество отданных блюд и количество необходимых в формате: отдал/необходимо.</li></ul>

<b>Описание механик</b>

<b>Хот-дог</b>

Тап по Булочкам для хот-догов, выкладывает одну булочку на дощечку для хот-догов:<ul>
<li> Дощечки заполняются снизу вверх, булочка появляется на первой свободной.</li>
<li> Пока есть свободные дощечки, тап по булочкам заполняет дощечки.</li>
<li> Если свободных дощечек нет, тап по булочкам ничего не даёт.</li>
<li> В готовые хот-доги можно добавить горчицу тапом по баночке с горчицей.</li></ul>
Жарка сосисок начинается тапом по сырым Сосискам:<ul>
<li> После тапа на сковородке или сырой сосиске появляется сырая сосиска.</li>
<li> Сковородки заполняются снизу вверх, сосиска отправляется на первую свободную.</li>
<li> Пока есть свободные сковородки, тап по сырым сосискам заполняет сковородки.</li>
<li> Если свободных сковородок нет, тап по сырым сосискам ничего не даёт.</li></ul>
Сосиска жарится на сковородке 5 секунд:<ul>
<li> Во время жарки над сосиской появляется элемент UI, зелёный круг, который
заполняется по часовой стрелке, начиная с нижней точки. Круг заполняется столько,
сколько времени жарится сосиска.</li>
<li> После истечения времени жарки, а, соответственно, и после заполнения круга, сосиски
начинают сгорать. Внешний вид сосиски меняется на готовый. Круг перекрашивается в
красный цвет и заново начинает заполняться.</li>
<li> У игрока есть 7 секунд на то, чтобы тапнуть по готовой сосиске, иначе она сгорит.</li>
<li> Тап возможен лишь в том случае, если на любой дощечке для хот-догов есть булочка
для хот-догов, в которой еще нет сосиски.</li>
<li> После истечения 7 секунд сосиска сгорает, внешний вид меняется на сгоревшую
сосиску.</li>
<li> Сгоревшая сосиска будет лежать на сковородке до тех пор, пока игрок не
произведет по ней двойной тап. После двойного тапа сосиска исчезает со
сковородки. Сковорода со сгоревшей сосиской считается занятой, на ней нельзя
жарить новое блюдо, пока она не освобождена.</li>
<li> Если игрок успевает нажать на готовую сосиску и на дощечке для хот-догов есть
булочка для хот-догов, то сосиска исчезает со сковородки, а булочка на дощечке
заменяется приготовленным хот-догом.</li>
<li> Сосиски добавляются на занятые пустыми булочками дощечки снизу вверх.</li></ul>
Тап по готовому хот-догу убирает его с тарелки, заказ выполнен (если блюдо есть в заказе
любого гостя). Если блюда нет - ничего не происходит.

<b>Бургер</b>

Приготовление бургера идентично приготовлению хот-дога. У бургера есть две опциональные
добавки - сыр и томаты. Они добавляются аналогично горчице, в блюдо можно добавить
одновременно обе добавки.

<b>Кола</b>

Кока-кола готовится автоматически и не требует вмешательства игрока:<ul>
<li> Если хотя бы один стакан в диспенсере пуст, то над стаканом появляется элемент UI,
зелёный круг, который заполняется по часовой стрелке, начиная с нижней точки. Круг
заполняется в течении пяти секунд. По прошествии этого времени пустой стакан
заменяется полным, блюдо готово.</li>
<li> Наполненные стаканы можно по тапу отдавать гостям, если они есть в их заказе,
стакан становится пустым.</li></ul>
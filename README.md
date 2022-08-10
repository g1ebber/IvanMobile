# Ivan

## Короткое описание
Игра про сотрудника государственной таможенной службы некоторой "коммунистической" страны с пиксельной графикой.
![Без имени](https://user-images.githubusercontent.com/57444845/183237588-f8a9cf78-9662-49e0-861b-8422114d2aba.png)

## Основная механика
Осмотрт посылок вручную, в результате которого посылка либо задерживается, либо идёт дальше.

## Реализуемость
"Симулятор" таможенника идеально бы игрался в 3Д, но на это потребовалось бы в несколько раз больше ресурсов. Подход к разработке: лучше сделать что-то не идеально, но сделать это до конца. Поэтому нацеливаемся на рабочий минимум, что-то сверх этого добавляем только если будет возможность.

## Платформа - PC
## Игровой движок - Unity 2D

## Особенности: 
- Симулятор
- Казуальная
- Головоломка
- Time Management
- Point & Click
- Для одного игрока
- 2D пиксельная графика
- Антиутопия
- Несколько концовок
- Реиграбельность
- Ретро
- Глубокий сюжет
- Приключение

## Целевая аудитория - игроки:
- Инди игр
- Пиксельных игр
- Любители коммунистического/тоталитарного/СССР-России сеттинга
- Заинтересовавшиеся механикой осмотра посылок
- Заинтригованные сюжетной завязкой

## Уникальность
Проработанная, но при этом не излишне сложная, механика осмотра посылок в 2D перспективе. Игровые уровни ограничены по времени и постепенно усложняются. Пиксельная графика в сочетании с атмосферным сеттингом, изменчивость окружения. Сюжет, на который можно повлиять как прямыми выборами, так и интерактивно с множеством концовками. Каждая игра уникальна, так как правила, которые необходимо соблюдать игроку, выбираются из огромного перечня и образуют почти неповторимые условия игры для каждого игрока.

## User Story
Игрок, запуская игру в первый раз, видит только начало игры, настройки и выход. Игра начинается с вводной катсцены или слайдов. 

Описание управления содержится на внутриигровом PC. Когда появляются новые функции или правила, об этом также сообщается именно на этом PC. Функционал PC также ограничен и не позволяет совершить действий, которые что-то сломают.

Когда игрок запускает игру не в первый раз - он видит кнопку продолжить. За нажатием этой кнопки следует годовой календарь с фокусом на месяц, который соответствует месяцу следующего непройденного уровня. Игровые уровни (например 1-15) не соответствуют числам к календаре (например июнь 1-15) и разбросаны в определенном порядке, в том числе с большими интервалами. Месяцы календаря можно переключать, а пройденные дни переигрывать (но тогда прогресс после этого самого дня будет утерян). Можно также просмотреть календарь в формате целого года. Каждый день календаря сохраняет ресурсы, которыми обладал игрок. При переигрывании дня новое правило может не соответствовать тому, что выпадало ранее, тоже самое и со всеми следующими днями и их новыми привилами.

Когда завершается день подводится итог, отображаются ресурсы, которыми владеет Иван + магазин, в котором он может что-то купить на эти ресурсы. При необходимости после или до этого показываются сюжетные вставки.

![image](https://user-images.githubusercontent.com/57444845/183241128-416fd8f3-d904-4080-8b28-65232473221d.png)
↑ Менюшки и 

## Завязка
Вы живете в населенном пункте на границе с недружественной страной. Ваше правительство, ввиду затяжного экономического кризиса, приняло решение разрешить торговлю и товарооборот с этой самой страной. Ваш отец - работяга, с огромной выслугой и уважением, поэтому он смог устроить вас в абсолютно новое для вашей страны подразделение. Теперь вы, обычный рабочий Иван, трудитесь на первом в стране таможенном посту.

## Общие очертания сюжета
Иван получил контракт на год. Он станет свидетелем развития таможенного дела в стране и, не по своей воле, будет находиться в центре множества крупных дел. Какую роль сыграет в этом Иван решит он сам. 

Иван - обычный мужик, он не герой и не амбициозный гений, но есть то, что для него действительно важно - автомобиль. Машина - опора для счастливой семьи, достоинство настоящего мужчины и почти недостижимая вещь для простого рабочего Северной Народной Республики. Возможно Ивану больше никогда не представится возможность трудиться так, чтобы заработать, может и не всегда честным путём, на автомобиль. Иван полон решимости не упустить эту возможность и исполнить свою мечту.
![image](https://user-images.githubusercontent.com/57444845/183042245-4b00a50c-6ec2-43dd-91d2-841fc70502c1.png)

## Общие черты интерфейса
![интерфейс с пометками](https://user-images.githubusercontent.com/57444845/183043032-8442f3fc-b3b9-4127-b341-2dcca47cf80c.png)
Игра представляет собой 3 окна:
1. Помещение:
- Можно сказать что это главное окно
- Вид сверху вниз
- Здесь можно видеть ГГ, его рабочее место
- Будет стол, на который можно положить вещи или коробки, с которыми сейчас не взаимодействуешь
- Все инструменты будут размещаться у стены, ГГ как бы перемещается между ними на стуле с колесиками
- С помощью перетаскивания можно взаимодействовать с посылкой и инструментами
- Посылки, которые надо обработать будут находиться в самом левом углу. Принятые и отклоненные посылки будут размещаться на полу в зелёной/красной зоне.
- Рабочее место ГГ будет при необходимости развиваться: будут появляться новые инструменты
- В помещении также будут находиться другие люди и стоять объекты, с которыми ГГ не может взаимодействовать
- Другие люди, да и ГГ, могут что-то говорить
- Когда игрок будет действовать ГГ будет "выполнять" это действие
- Помещение освящается: свет из окна, настенные лампы. Изменение освящения будет показывать время дня.
- В разные дни интерьер может быть разным, особенно в пред праздничные дни

2. Осмотр посылок:
- Это главное окно при проверки содержимого посылки
- Вид сверху вниз
- Представляет собой стол с инструментами на нём
- На этом столе "приклеена" огромная линейка угольник
- Посылку можно крутить при нажатии кнопок
- Инструменты взаимодействуют с посылкой с помощью клика/перетаскивания
- Можно вскрывать под посылки
- Можно будет своровать содержимое посылки
- После осмотра посылки её нужно упаковать и нанести опознавательный знак

3. ПК:
- Это окно содержит правила осмотра
- С помощью ПК можно будет взаимодействовать с некоторыми инструментами
- Кнопка лупы (или вопросика) будет отмечать несоответствия. Это будет предлогом отклонить посылку.
- В этом окне будет счетчик посылок на текущем уровне + в общем
- Здесь можно увидеть время

## 

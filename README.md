# SOLID принципы на примере игры "Угадай число"

##
## 1. S - Single Responsibility Proncipal - принцип единой ответственности
#### Реализация данного принципа отражается в любых классах этой игры - существует единственная причина их сущестовования. 
##### GuessNumber/GuessNumber/Config/AppConfig.cs - конфигурация игры;
##### GuessNumber/GuessNumber/Logic/GuessNumberGame.cs - логика игры;
##### GuessNumber/GuessNumber/Logic/Players/AIMachine.cs - игрок искуственный интеллект - находит число методом деления отрезка пополам;
##### GuessNumber/GuessNumber/Logic/Players/Human.cs - игрок человек - вручную угадывающий числа;
##### GuessNumber/GuessNumber/Verify/CheckNumber.cs - модуль проверки чисел.

##
## 2. O - Opened/Closed Principal - принцип открытости/закрытости 
#### Данный принцип отражён в модуле проверке чисел GuessNumber/GuessNumber/Verify/CheckNumber.cs
##### В данном классе, есть закрытый метод PrivateCompare в которое передается загаданное число и проводится сравнение, но для других программ передается только свойство Compare, чтобы можно было реализовать логику.

## 3. Liskov Substitution principal - При подстановки Барбары Лисков
####  Данный принцип отражён при создание объекта типа IPlayer, который реализует логику внутри классов AIMachine, Human , но не влияет на игровой процесс.

##
## 4. Interface Segregation Principal - принцип разделения интерфейсов
####  Данный принцип отражён в интерфейсах. Ни один из интерфейсов не перегружен и отвечает только за те действия, которые он определяет
####  GuessNumber/GuessNumber/Interfaces

## 5. Dependancy Inversion Principal - При инверсии зависимости
####  Данный принцип отражён в использование штатных механизмов внедрения зависимостей (Dependancy Injection), которые Microsoft поставляет из "коробки"
####  GuessNumber/GuessNumber/Program.cs (метод SetupDIContainer)

﻿/*Разработать игру "Автомобильные гонки" с использованием делегатов.
1. В игре использовать несколько типов автомобилей:  спортивные, легковые, грузовые и автобусы.

2. Реализовать игру «Гонки». Принцип игры: Автомобили двигаются от старта к финишу со скоростями,
которые изменяются в установленных пределах случайным образом. Победителем считается автомобиль, 
пришедший к финишу первым.

 Рекомендации по выполнению работы
1. Разработать абстрактный класс «автомобиль»  (класс Car). Собрать в нем все общие поля, свойства
(например, скорость) методы (например, ехать).

2. Разработать классы автомобилей с конкретной реализацией конструкторов и методов, свойств.
В классы автомобилей добавить необходимые события

 3. Класс игры должен производить запуск соревнований автомобилей, выводить сообщения о текущем
положении автомобилей, выводить сообщение об автомобиле, победившем в гонках. Создать делегаты, обеспечивающие вызов методов из классов
автомобилей (например, выйти на старт, начать гонку).

4. Игра заканчивается, когда какой-то из автомобилей проехал определенное расстояние 
Уведомление об окончании гонки (прибытии какого-либо автомобиля на финиш) реализовать с помощью событий.*/

using task_2.Classes_Car;

namespace task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Racing.StartRacing(); //вибір авто + починає гонку 
        }
    }
}

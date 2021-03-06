﻿using System;
using System.Globalization;
using System.Linq;

namespace TriangleAreaLib
{
    /// <summary>
    /// Помощник для работы с треугольниками (расчет площади прямоугольных треугольников)
    /// </summary>
    public class TriangleHelper
    {
        /// <summary>
        /// Расчет площади прямоугольных треугольников из длин 3х его сторон
        /// </summary>
        /// <param name="first">Длина первой стороны</param>
        /// <param name="second">Длина второй стороны</param>
        /// <param name="third">Длина третьей стороны</param>
        /// <returns>Площадь треугольника</returns>
        public static double Area(double first, double second, double third) //Можно использовать params double[], но тогда мы переводим ошибку неверного кол-ва сторон из компиляционной в исполнительную(нужно доп. условие)
        {//Конечная функция по заданию
            return AreaWithAccuracy(first, second, third);
        }

        /// <summary>
        /// Расчет площади прямоугольных треугольников из длин 3х его сторон с возможностью указания точности для определения прямоугольности треугольника
        /// </summary>
        /// <param name="first">Длина первой стороны</param>
        /// <param name="second">Длина второй стороны</param>
        /// <param name="third">Длина третьей стороны</param>
        /// <param name="accuracy">Точность(кол-во знаков после запятой, -1 для максимального значения)</param>
        /// <returns>Площадь треугольника</returns>
        public static double AreaWithAccuracy(double first, double second, double third, int accuracy = -1)
        {
            double[] sides = { first, second, third };//Преобразуем стороны в массив для более удобной дальнейшей работы с ними

            if (sides.Any(e => e <= 0))
                throw new ArgumentException("В треугольнике должны быть стороны с положительной длинной!");

            if (accuracy == -1)//Если -1 то автоматическая точность, иначе ручная
                accuracy = sides.Max(e => e.ToString(CultureInfo.InvariantCulture).Split('.').Length != 2 ? 0//Получаем максимальную точность после запятой(количество знаков после запятой)
                                : e.ToString(CultureInfo.InvariantCulture).Split('.')[1].Length);

            double calculatedAccuracy = accuracy == 0 ? 0d : Math.Pow(10, -accuracy);//Точность сравнения(прямоугольный ли треугольник)

            int hypotenuse = -1;//Индекс гипотенузы в массиве или -1 если она еще/вообще не найдена

            double sum = sides.Aggregate(0d, (e, a) => e + a * a);//Сумма квадратов всех сторон a^2 + b^2 + c^2

            for (int i = 0; i < sides.Length; i++)
            {
                //Применяем теорему Пифагора для определения прямоугольный это треугольник или нет

                if (Math.Abs(Math.Sqrt(sum - sides[i] * sides[i]) - sides[i]) <= calculatedAccuracy)//Сравнение с учетом заранее посчитанной точности
                    hypotenuse = i;
            }

            if (hypotenuse == -1) throw new RightTriangleException("Треугольник не прямоугольный!");

            return sides.Aggregate(0.5d, (e, a) => e * a) / sides[hypotenuse];//Расчитываем половину произведения сторон треугольника затем делим на длину гипотенузы
        }
    }
}

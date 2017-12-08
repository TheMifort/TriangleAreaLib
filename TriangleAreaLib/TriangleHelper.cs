using System;
using System.Linq;

namespace TriangleAreaLib
{
    /// <summary>
    /// Помощник для работы с треугольниками (расчет площади прямоугольных треугольников)
    /// </summary>
    public class TriangleHelper
    {
        /// <summary>
        /// Расчет площади прямоугольных треугольников из 3х сторон
        /// </summary>
        /// <param name="first">Длина первой стороны</param>
        /// <param name="second">Длина второй стороны</param>
        /// <param name="third">Длина третьей стороны</param>
        /// <returns>Площадь треугольника</returns>
        public static double Area(double first, double second, double third)//Можно использовать params double[], но тогда мы переводим ошибку неверного кол-ва сторон из компиляционной в исполнительную(нужно доп. условие)
        {
            double[] sides = {first, second, third};//Преобразуем стороны в массив для более удобной дальнейшей работы с ними

            if (sides.Any(e => e <= 0))
                throw new ArgumentException("В треугольнике должно быть стороны с положительной длинной!");

            int hypotenuse = -1;//Индекс гипотенузы в массиве или -1 если она еще/вообще не найдена

            double sum = sides.Aggregate(0d, (e, a) => e + a * a);//Сумма квадратов всех сторон a^2 + b^2 + c^3

            for (int i = 0; i < sides.Length; i++)
            {
                //Применяем теорему Пифагора для определения прямоугольный это треугольник или нет
                if (Math.Abs(Math.Sqrt(sum - sides[i] * sides[i]) - sides[i]) <= 0)//TODO Настройка точности
                    hypotenuse = i;
            }

            if (hypotenuse == -1) throw new RightTriangleException("Треугольник не прямоугольный!");

            return sides.Aggregate(0.5d, (e, a) => e * a) / sides[hypotenuse];//Расчитываем половину произведения сторон треугольника затем делим на длину гипотенузы
        }
    }
}

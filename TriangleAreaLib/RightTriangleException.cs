using System;

namespace TriangleAreaLib
{
    /// <summary>
    /// Исключение, выбрасываемое, когда треугольник не является прямоугольным
    /// </summary>
    public class RightTriangleException : Exception
    {
        public RightTriangleException(string message)
            : base(message)
        {

        }
    }
}
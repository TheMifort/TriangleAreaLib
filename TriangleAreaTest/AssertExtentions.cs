using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TriangleAreaTest
{
    /// <summary>
    /// Дополнительный функционал для юнит тестированиея
    /// </summary>
    public class AssertExtentions
    {
        /// <summary>
        /// Проверка на то чтобы метод не выбросил исключение типа T
        /// </summary>
        /// <typeparam name="T">Тип исключения</typeparam>
        /// <param name="action">Тестируемый метод</param>
        public static void NoExceptionThrown<T>(Action action) where T : Exception
        {
            try
            {
                action();
            }
            catch (T)
            {
                Assert.Fail($"Ожидалось что исключение {typeof(T).Name} не будет выброшено!");
            }
            catch
            {
                //Success
            }
        }
    }
}
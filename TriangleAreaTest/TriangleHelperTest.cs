using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleAreaLib;

namespace TriangleAreaTest
{
    [TestClass]
    public class TriangleHelperTest
    {
        [TestMethod]
        public void IsTriangleRight()//Является ли треугольник прямоугольным
        {
            AssertExtentions.NoExceptionThrown<RightTriangleException>(() => TriangleHelper.Area(9, 12, 15));
            AssertExtentions.NoExceptionThrown<RightTriangleException>(() => TriangleHelper.Area(39, 80, 89));
            AssertExtentions.NoExceptionThrown<RightTriangleException>(() => TriangleHelper.Area(68, 285, 293));
            AssertExtentions.NoExceptionThrown<RightTriangleException>(() => TriangleHelper.Area(23, 264, 265));

            AssertExtentions.NoExceptionThrown<RightTriangleException>(() => TriangleHelper.Area(3, 4, 5));
            Assert.ThrowsException<RightTriangleException>(() => TriangleHelper.Area(4, 4, 5));
            AssertExtentions.NoExceptionThrown<RightTriangleException>(() => TriangleHelper.Area(5, 3, 4));
            Assert.ThrowsException<RightTriangleException>(() => TriangleHelper.Area(5, 4, 4));
            AssertExtentions.NoExceptionThrown<RightTriangleException>(() => TriangleHelper.Area(30, 40, 50));
            Assert.ThrowsException<RightTriangleException>(() => TriangleHelper.Area(32, 41, 53));
            AssertExtentions.NoExceptionThrown<RightTriangleException>(() => TriangleHelper.Area(120, 160, 200));
            Assert.ThrowsException<RightTriangleException>(() => TriangleHelper.Area(127, 154, 203));
            AssertExtentions.NoExceptionThrown<RightTriangleException>(() => TriangleHelper.Area(12, 13, 5));
            Assert.ThrowsException<RightTriangleException>(() => TriangleHelper.Area(13, 13, 6));
            AssertExtentions.NoExceptionThrown<RightTriangleException>(() => TriangleHelper.Area(24, 26, 10));
            Assert.ThrowsException<RightTriangleException>(() => TriangleHelper.Area(25, 27, 12));
            AssertExtentions.NoExceptionThrown<RightTriangleException>(() => TriangleHelper.Area(120, 130, 50));
            Assert.ThrowsException<RightTriangleException>(() => TriangleHelper.Area(121, 130, 50));
        }

        [TestMethod]
        public void IsTriangleSides()//Являются ли стороны треугольником
        {
            AssertExtentions.NoExceptionThrown<ArgumentException>(() => TriangleHelper.Area(1, 2, 3));
            Assert.ThrowsException<ArgumentException>(() => TriangleHelper.Area(0, -1, 5));
            AssertExtentions.NoExceptionThrown<ArgumentException>(() => TriangleHelper.Area(1, 1, 1));
            Assert.ThrowsException<ArgumentException>(() => TriangleHelper.Area(-1, 1, 3));
            AssertExtentions.NoExceptionThrown<ArgumentException>(() => TriangleHelper.Area(1, 41, 521111));
            Assert.ThrowsException<ArgumentException>(() => TriangleHelper.Area(0, 0, 0));
        }

        [TestMethod]
        public void IsAreaCorrect()//Проверка площади
        {
            Assert.AreEqual(TriangleHelper.Area(30, 40, 50), 600);
            Assert.AreEqual(TriangleHelper.Area(12, 13, 5), 30);

            Assert.AreEqual(TriangleHelper.Area(4, 4, 5.60), 8);

            Assert.AreEqual(TriangleHelper.Area(12, 13, 5), 30);

            Assert.AreEqual(TriangleHelper.Area(9, 12, 15), 54);
            Assert.AreEqual(TriangleHelper.Area(39, 80, 89), 1560);
            Assert.AreEqual(TriangleHelper.Area(68, 285, 293), 9690);
            Assert.AreEqual(TriangleHelper.Area(23, 264, 265), 3036);

            //Тестируем перемены сторон местами
            Assert.AreEqual(TriangleHelper.Area(3, 4, 5), 6);
            Assert.AreEqual(TriangleHelper.Area(5, 3, 4), 6);
            Assert.AreEqual(TriangleHelper.Area(5, 4, 3), 6);
            Assert.AreEqual(TriangleHelper.Area(3, 5, 4), 6);
            Assert.AreEqual(TriangleHelper.Area(4, 5, 3), 6);
            Assert.AreEqual(TriangleHelper.Area(4, 3, 5), 6);
        }

        [TestMethod]
        public void IsAccuracyCorrect()//Тестирование точности
        {
            Assert.AreEqual(TriangleHelper.AreaWithAccuracy(4, 4, 5.60), 8);
            Assert.ThrowsException<RightTriangleException>(() => TriangleHelper.AreaWithAccuracy(4, 4, 5.60, 3));

            Assert.AreEqual(TriangleHelper.AreaWithAccuracy(41, 41, 57.98), 840.5);
            Assert.AreEqual(TriangleHelper.AreaWithAccuracy(41, 41, 58, 1), 840.5);
            Assert.AreEqual(TriangleHelper.AreaWithAccuracy(41, 41, 57.982757057296896, 3), 840.5);//Настоящая гипотенуза примерна равна 57.982756057296896
            Assert.ThrowsException<RightTriangleException>(() => TriangleHelper.AreaWithAccuracy(41, 41, 57.982757057296896));

            Assert.AreEqual(TriangleHelper.AreaWithAccuracy(3151.21, 28, 3151.334394205096), 44116.94);
        }
    }
}

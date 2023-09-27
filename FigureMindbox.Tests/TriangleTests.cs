using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureMindbox.Tests
{
    public class TriangleTests
    {
        // Проверка корректности рассчета площади треугольника
        [Theory]
        [InlineData(5d, 5d, 8d, 12d)]
        [InlineData(4d, 6d, 3d, 5.332d)]
        [InlineData(3d, 7d, 7d, 10.256d)]
        public void Triangle_AreaCorrectly(double a, double b, double c, double expected)
        {
            Figure triangle = new Triangle(a, b, c);
            double actual = triangle.CalculateArea();

            Assert.Equal(expected, actual, 0.001d);
        }

        // Проверка некорректной инициализации 
        [Theory]
        [InlineData(1d, 3d, 7d)]
        [InlineData(-1d, 6d, 3d)]
        [InlineData(3d, 0d, 7d)]
        [InlineData(1d, 3d, 4d)]
        public void Triangle_CheckParams(double a, double b, double c)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Figure triangle = new Triangle(a, b, c);
            });
        }

        // Проверка некорректных значений свойств
        [Theory]
        [InlineData(-1d, -3d, -7d)]
        [InlineData(0d, 0d, 0d)]
        [InlineData(11d, 11d, 11d)]
        public void Triangle_CheckPropsFails(double a, double b, double c)
        {
            Triangle triangle = new(3,4,5);

            Assert.Throws<ArgumentException>(() => triangle.A = a);
            Assert.Throws<ArgumentException>(() => triangle.B = b);
            Assert.Throws<ArgumentException>(() => triangle.C = c);
        }

        // Проверка корректности присваивания значений у свойств
        [Fact]
        public void Triangle_CheckProps()
        {
            double a = 17d;
            double b = 12d;
            double c = 20d;

            Triangle triangle = new(a, b, c);

            triangle.A = a;
            triangle.B = b;
            triangle.C = c;
        }

        // Проверка корректности метода IsRight()
        [Theory]
        [InlineData(4d, 3d, 5d)]
        [InlineData(16d, 12d, 20d)]
        public void Triangle_IsRightCorrectly(double a, double b, double c)
        {
            Triangle triangle = new Triangle(a, b, c);
            bool actual = triangle.IsRight();

            Assert.True(actual);
        }

        [Theory]
        [InlineData(6d, 3d, 5d)]
        [InlineData(17d, 12d, 20d)]
        public void Triangle_IsRightFalseCorrectly(double a, double b, double c)
        {
            Triangle triangle = new Triangle(a, b, c);
            bool actual = triangle.IsRight();

            Assert.False(actual);
        }


    }

}

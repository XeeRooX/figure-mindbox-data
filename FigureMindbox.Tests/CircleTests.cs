namespace FigureMindbox.Tests
{
    public class CircleTests
    {
        // Проверка корректного вычисления площади круга
        [Fact]
        public void Circle_AreaCorrectly()
        {
            double r = 4d;
            double s = 50.265d;

            Figure c = new Circle(r);
            double actual = c.CalculateArea();

            Assert.Equal(s, actual, 0.001d);
        }

        // Проверка вввода некорректных данных
        [Theory]
        [InlineData(-1d)]
        [InlineData(-123d)]
        [InlineData(0d)]
        public void Circle_CheckParam(double r)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Figure c = new Circle(r);
            });
        }

        // Установка корректного значения радиуса через свойство
        [Fact]
        public void Circle_RadiusPropSet()
        {
            double r = 4d;;
            Circle c = new Circle(r);
            c.Radius = r;
        }

        // Установка НЕкорректного значения радиуса через свойство
        [Theory]
        [InlineData(-1d)]
        [InlineData(-123d)]
        [InlineData(0d)]
        public void Circle_PropSetFail(double r)
        {
            Circle c = new Circle(4d);
            Assert.Throws<ArgumentException>(() =>
            {
                c.Radius = r;
            });
        }
    }
}
namespace FigureMindbox
{
    public class Triangle : Figure
    {
        private double _a;
        private double _b;
        private double _c;

        // Свойства сторон a,b,c
        public Triangle(double a, double b, double c)
        {

            if (!CheckSides(a, b, c))
                throw new ArgumentException(message: "Ошибка: неверно введены стороны треугольника");

            _a = a;
            _b = b;
            _c = c;
        }

        public double A
        {
            get { return _a; }
            set 
            {
                if (!CheckSides(value, _b, _c))
                    throw new ArgumentException(message: "Ошибка: тругольника с таким значением стороны 'a' не может существовать");     
                _a = value; 
            }
        }

        public double B
        {
            get { return _b; }
            set
            {
                if (!CheckSides(_a, value, _c))
                    throw new ArgumentException(message: "Ошибка: тругольника с таким значением стороны 'b' не может существовать");
                _b = value;
            }
        }

        public double C
        {
            get { return _c; }
            set
            {
                if (!CheckSides(_a, _b, value))
                    throw new ArgumentException(message: "Ошибка: тругольника с таким значением стороны 'c' не может существовать");
                _c = value;
            }
        }

        // Прямоугольный ли треугольник?
        public bool IsRight()
        {
            if (_a > _b && _a > _c)
                return PythagoreanIsTrue(_b, _c, _a);
            else if (_b > _a && _b > _c)
                return PythagoreanIsTrue(_a, _c, _b);
            else if(_c > _a && _c > _b)
                return PythagoreanIsTrue(_a, _b, _c);

            return false;
        }

        // Площадь треугольника
        public override double CalculateArea()
        {
            double p = (_a + _b + _c) / 2d;
            return Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
        }

        // Выполняется ли теорема Пифагора
        private bool PythagoreanIsTrue(double a, double b, double c)
        {
            return (c * c) == (a * a + b * b);
        }

        // Проверка корректности сторон
        private static bool CheckSides(double a, double b, double c)
        {
            if (a + b <= c || a + c <= b || b + c <= a ||
                 a <= 0 || b <= 0 || c <= 0)
            {
                return false;
            }
            return true;
        }
    }
}

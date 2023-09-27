namespace FigureMindbox
{
    public class Circle : Figure
    {
        private double _radius;

        public double Radius
        {
            get { return _radius; }
            set 
            {
                if (value <= 0)
                    throw new ArgumentException("Ошибка: радиус не может быть меньше 0");
                _radius = value; 
            }
        }

        
        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Ошибка: радиус не может быть меньше 0");

            Radius = radius;
        }

        // Площадь круга
        public override double CalculateArea()
        {
            return Math.PI * _radius * _radius;
        }
    }
}

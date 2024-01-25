namespace ShapeLibrary
{
    public class Circle : Shape
    {
        protected override decimal AreaCalc()
        {
            if (Sides == null)
            {
                throw new ArgumentNullException(nameof(Sides));
            }
            return (decimal)Math.PI * Sides[0] * Sides[0];
        }

        public Circle(decimal radius)
        {
            if (radius <= 0) 
            {
                throw new ArgumentException("Radius should be > 0");
            }
            Sides = new decimal[1] { radius };
            Area = AreaCalc();
        }
    }
}

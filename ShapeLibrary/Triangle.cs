namespace ShapeLibrary
{
    public class Triangle : Shape
    {
        public bool IsRight { get; private set; }

        protected override decimal AreaCalc()
        {
            if (Sides == null)
            {
                throw new ArgumentNullException(nameof(Sides));
            }
            if (IsRight)
            {
                return Sides[0] * Sides[1] / 2;
            }
            else
            {
                decimal halfPerimetr = PerimetrCalc() / 2;
                return (decimal)Math.Sqrt((double)(halfPerimetr * (halfPerimetr - Sides[0]) * (halfPerimetr - Sides[1]) * (halfPerimetr - Sides[2])));
            }
        }
        public Triangle(decimal[]? sides)
        {

            if (sides == null)
            {
                throw new ArgumentNullException(nameof(sides));
            }
            else if ((sides.Length < 3) || (sides.Length > 3))
            {
                throw new ArgumentException("Triangle must have 3 sides");
            }
            foreach (var side in sides) 
            {
                if (side <= 0)
                {
                    throw new ArgumentException("Side size should be > 0");
                }
            }
            Sides = sides.OrderBy(item => item).ToArray();
            if (Sides[2] > (Sides[0] + Sides[1]))
            {
                Sides = null;
                throw new ArgumentException("The longest side should be shorter then the summ of the other sides");
            }
            if (Sides[2] * Sides[2] == Sides[0] * Sides[0] + Sides[1] * Sides[1])
            {
                IsRight = true;
                Area = AreaCalc();
            }
            else
            { 
                IsRight = false;
                Area = AreaCalc();
            }
        }

        private decimal PerimetrCalc()
        {
            decimal result = 0;
            if (Sides == null)
            {
                throw new ArgumentNullException(nameof(Sides));
            }
            foreach (var item in Sides)
            {
                result += item;
            }
            return result;
        }
    }
}

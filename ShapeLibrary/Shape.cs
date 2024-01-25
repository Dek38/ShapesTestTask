namespace ShapeLibrary
{
    public abstract class Shape
    {
        protected decimal[]? Sides { get; set; }
        public decimal Area { get; protected set; }
        protected abstract decimal AreaCalc();
        protected Shape() 
        {
            Sides = null;
            Area = 0;
        }
    }
}

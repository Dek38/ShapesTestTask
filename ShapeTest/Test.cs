using Newtonsoft.Json.Linq;
using ShapeLibrary;

namespace ShapeTest
{
    public class Test
    {
        [Fact]
        public void TestCircleArgumentException_WithNegativeArgument()
        {
            Assert.Throws<ArgumentException>(() => new Circle(-5));
        }

        [Fact]
        public void TestCircleArgumentException_WithZero()
        {
            Assert.Throws<ArgumentException>(() => new Circle(0));
        }

        [Theory]
        [InlineData(1, Math.PI)]
        [InlineData(3, Math.PI * 9)]
        [InlineData(5.2, Math.PI * 5.2 * 5.2)]
        public void TestCircleArea(decimal value, decimal result)
        {
            Circle circle = new Circle(value);
            Assert.Equal(circle.Area.ToString("0.00000"), result.ToString("0.00000"));
        }

        [Fact]
        public void TestTriangleArgumentException_WithNullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => new Triangle(null));
        }
        [Fact]
        public void TestTriangleArgumentException_WithLessThenThreeArgument()
        {
            Assert.Throws<ArgumentException>(() => new Triangle([1]));
        }
        [Fact]
        public void TestTriangleArgumentException_WithMoreThenThreeArgument()
        {
            Assert.Throws<ArgumentException>(() => new Triangle([1, 2, 3, 4]));
        }

        [Fact]
        public void TestTriangleArgumentException_WithNegativeArgument()
        {
            Assert.Throws<ArgumentException>(() => new Triangle([1, -2, 3]));
        }

        [Fact]
        public void TestTriangleArgumentException_WithWrongSideSize()
        {
            Assert.Throws<ArgumentException>(() => new Triangle([1, 2, 4]));
        }

        [Fact]
        public void TestTriangleArgumentException_IsRight()
        {
            Triangle triangle = new Triangle([3, 4, 5]);
            Assert.True(triangle.IsRight);
        }

        [Fact]
        public void TestTriangleArgumentException_IsNotRight()
        {
            Triangle triangle = new Triangle([3, 4, 3]);
            Assert.False(triangle.IsRight);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void TestTriangleArea(decimal result, decimal[] value)
        {
            Triangle triangle = new Triangle(value);
            Assert.Equal(triangle.Area.ToString("0.00000"), result.ToString("0.00000"));
        }

        public static TheoryData<decimal, decimal[]> Data =>
        new ()
        {
            {6m, [3m, 4m, 5m]},
            {0.43301m, [1m, 1m, 1m]}
        };
    }
}
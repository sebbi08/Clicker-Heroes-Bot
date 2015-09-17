using System.Drawing;

namespace MyClickerHeroesBot.Extensions
{
    public static class MyRectangleExtensions
    {
        public static Point Center(this Rectangle rectangle)
        {
            return rectangle.IsEmpty ? Point.Empty : new Point(rectangle.Left + rectangle.Width / 2, rectangle.Top + rectangle.Height / 2);
        }
    }
}

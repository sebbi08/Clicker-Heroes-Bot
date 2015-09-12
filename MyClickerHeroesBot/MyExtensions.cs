using System.Drawing;

namespace MyClickerHeroesBot
{
    public static class MyExtensions
    {
        public static Point Center(this Rectangle rectangle)
        {
            return new Point(rectangle.Left + rectangle.Width / 2, rectangle.Top + rectangle.Height / 2);
        }
    }
}

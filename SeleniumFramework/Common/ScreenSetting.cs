using System;
using System.Drawing;
using System.Windows.Forms;

namespace SeleniumFramework.Common
{
    public class ScreenSetting
    {
        private static Object mutex = new object();
        private static int _width = Screen.PrimaryScreen.Bounds.Width;
        private static int _height = Screen.PrimaryScreen.Bounds.Height;
        public static Size _size;
        public Size Size
        {
            get
            {
                return _size;
            }
        }
        public Point Point
        {
            get; private set;
        }
        private static int[] _xPositions;
        private static int[] _yPositions;
        private static int count = 0;

        static ScreenSetting()
        {
            _size = new Size(_width / 2, _height / 2);
            _xPositions = new int[4] { 0, 0, _size.Width, _size.Width };
            _yPositions = new int[4] { 0, _size.Height, 0, _size.Height };
        }

        public ScreenSetting Next()
        {
            lock (mutex)
            {
                Point = new Point(_xPositions[count % 4], _yPositions[count % 4]);
                count++;
                return this;
            }
        }
    }
}

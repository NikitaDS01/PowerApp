using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerApp.Function
{
    public class CoordinatePlane
    {
        private SKPath _path;
        private int _steps;
        private int _scale;
        public CoordinatePlane(int scale, int steps = 100)
        {
            _path = new SKPath();
            _steps = steps;
            _scale = scale;
        }
        public int MinSteps => -_steps / 2;
        public int MaxSteps => _steps / 2;
        public SKPoint NormalizationPoint(SKPoint point, SKPoint centerWindow)
        {
            return new SKPoint(
                (point.X * _scale) + centerWindow.X,
                -(point.Y * _scale) + centerWindow.Y);
        }
        public SKPoint NormalizationPoint(SKPoint point, SKImageInfo info)
        {
            return new SKPoint(
                (point.X * _scale) + info.Width / 2,
                -(point.Y * _scale) + info.Height / 2);
        }

        public SKPoint CreatePoint(float x, float y)
        {
            return new SKPoint(x, y);
        }

        public void AddPoint(SKPoint point)
        {
            if (_path.Points.Length == 0)
                _path.MoveTo(point);
            else
                _path.LineTo(point);
        }
        public SKPath GetPath() 
            => _path;
    }
}

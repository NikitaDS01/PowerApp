using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerApp.Function
{
    public class Plane
    {
        private SKPath _path;
        private SKPoint _center;
        public Plane(SKPoint center)
        {
            _path = new SKPath();
            _center = center;
        }
        
        public void AddPoint(SKPoint point)
        {
            point.X += _center.X;
            point.Y += _center.Y;
            if (_path.Points.Length == 0)
                _path.MoveTo(point);
            else
                _path.LineTo(point);
        }
        public SKPath GetPath() => _path;
    }
}

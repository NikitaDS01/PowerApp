using PowerApp.Function;
using PowerApplication.Function;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PowerApplication.Page
{
    public class GraphPage : ContentPage
    {
        private PowerFunctionData _data;
        public GraphPage(PowerFunctionData data)
        {
            _data = data;
            Title = "Вывод графика";

            Init();
        }

        private void Init()
        {
            StackLayout stack = new StackLayout();

            SKCanvasView canvasView = new SKCanvasView()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.Fill
            };
            canvasView.PaintSurface += OnCanvasDrawGraph;
            

            var lbl = CreateObject.Label($"Формула y = {_data.ValueK} * x^{_data.ValueA}");

            stack.Children.Add(CreateObject.Heading());
            stack.Children.Add(lbl);
            stack.Children.Add(canvasView);
            Content = stack;
        }
        private void DrawCoordinatePlane(SKCanvas canvas, SKImageInfo info)
        {
            var paintLine = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Black,
                StrokeWidth = 5
            };
            var paintText = new SKPaint
            {
                Color = SKColors.Black,
                IsAntialias = true,
                TextSize = 18
            };

            canvas.DrawLine(
                new SKPoint(0, info.Height / 2),
                new SKPoint(info.Width, info.Height / 2),
                paintLine
                );
            canvas.DrawLine(
                new SKPoint(info.Width / 2, 0),
                new SKPoint(info.Width / 2, info.Height),
                paintLine
                );
        }
        private void OnCanvasDrawGraph(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            var plane = new CoordinatePlane(_data.Scale);
            for(int x = plane.MinSteps; x < plane.MaxSteps; x++)
            {
                float? y;
                if (IsFloat(_data.ValueA))
                    y = (float?)_data.GetYFloat(x);
                else
                    y = (float?)_data.GetYInt(x);

                if (y == null || y == float.PositiveInfinity)
                    continue;

                SKPoint point = plane.CreatePoint(x, (float)y);
                plane.AddPoint(plane.NormalizationPoint(point, info));
            }

            var paintPath = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Green,
                StrokeWidth = 7
            };

            this.DrawCoordinatePlane(canvas, info);
            canvas.DrawPath(plane.GetPath(), paintPath);
        }
        private bool IsFloat(float value)
        {
            int whole = (int)Math.Floor(Math.Abs(value));
            float fractional = Math.Abs(value) - whole;
            return fractional > 0 && fractional < 1;
        }
    }
}
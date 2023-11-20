using PowerApp.Function;
using PowerApplication.Function;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

using Xamarin.Forms;

namespace PowerApplication.Page
{
    public class GraphPage : ContentPage
    {
        private const int SCALE = 100;
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
            

            var lbl = CreateObject.Label($"y = {_data.ValueK} * x^{_data.ValueA}");

            stack.Children.Add(CreateObject.Heading());
            stack.Children.Add(lbl);
            stack.Children.Add(canvasView);
            Content = stack;
        }
        private void DrawCoordinatePlane(SKCanvas canvas, CoordinatePlane plane, SKImageInfo info)
        {
            var paintMainLine = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Black,
                StrokeWidth = 5
            };
            var paintLine = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = SKColors.DarkGray,
                StrokeWidth = 3
            };
            var paintPath = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Green,
                StrokeWidth = 7
            };

            for (float x = info.Height/2; x < info.Height; x+= SCALE)
            {
                canvas.DrawLine(
                    new SKPoint(0, x),
                    new SKPoint(info.Width, x),
                    paintLine
                );
            }
            for(float y = info.Width/2; y < info.Width; y+= SCALE)
            {
                canvas.DrawLine(
                    new SKPoint(y, 0),
                    new SKPoint(y, info.Height),
                    paintLine
                );
            }
            for (float x = info.Height / 2; x >0 ; x -= SCALE)
            {
                canvas.DrawLine(
                    new SKPoint(0, x),
                    new SKPoint(info.Width, x),
                    paintLine
                );
            }
            for (float y = info.Width / 2; y > 0; y -= SCALE)
            {
                canvas.DrawLine(
                    new SKPoint(y, 0),
                    new SKPoint(y, info.Height),
                    paintLine
                );
            }

            canvas.DrawPath(plane.GetPath(), paintPath);

            canvas.DrawLine(
                new SKPoint(0, info.Height / 2),
                new SKPoint(info.Width, info.Height / 2),
                paintMainLine
                );
            canvas.DrawLine(
                new SKPoint(info.Width / 2, 0),
                new SKPoint(info.Width / 2, info.Height),
                paintMainLine
                );
        }
        private void OnCanvasDrawGraph(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            var plane = new CoordinatePlane(_data.Scale, info.Width);
            for(float x = plane.MinSteps; x < plane.MaxSteps; x+=plane.Step)
            {
                ValueY y = _data.GetY(x);

                if (y.IsEmpty)
                    continue;

                SKPoint point = plane.CreatePoint(x, y.Value);
                plane.AddPoint(plane.NormalizationPoint(point, info));
            }

            this.DrawCoordinatePlane(canvas, plane, info);
        }
    }
}
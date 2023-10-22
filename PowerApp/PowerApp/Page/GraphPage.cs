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
        public GraphPage()
        {
            _data = new PowerFunctionData(0, 0);
            Title = "Вывод графика";
            Init();
        }
        public GraphPage(PowerFunctionData data)
        {
            _data = data;
            Title = "Вывод графика";

            Init();
        }

        private void Init()
        {
            StackLayout stack = new StackLayout();

            SKCanvasView canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            

            var lbl = CreateObject.Label($"Формула y = {_data.ValueK} * x^{_data.ValueA}");

            stack.Children.Add(CreateObject.Heading());
            stack.Children.Add(lbl);
            stack.Children.Add(canvasView);
            Content = stack;
        }

        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();
            //SKPoint center = new SKPoint(info.Width / 2, info.Height / 2);

        }
    }
}
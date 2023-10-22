using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PowerApplication.Function
{
    public static class CreateObject
    {
        public static Label Label(string text)
        {
            return new Label
            {
                Text = text,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };
        }
        public static Frame Heading()
        {
            return new Frame
            {
                Content = CreateObject.Label("Степенная функция"),
                BorderColor = Color.Gray,
                BackgroundColor = Color.Aqua,
                CornerRadius = 8
            };
        }
        public static EntryCell EntryCellNumeric(string text)
        {
            return new EntryCell
            {
                Label = text,
                Keyboard = Keyboard.Numeric,
                Placeholder = "Введите число"
            };
        }
        public static Button Button(string text)
        {
            return new Button
            {
                Text = text,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center
            };
        }
    }
}

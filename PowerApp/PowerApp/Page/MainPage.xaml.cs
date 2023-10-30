using PowerApp.Function;
using PowerApplication.Function;
using System;
using Xamarin.Forms;

namespace PowerApplication.Page
{
    public partial class MainPage : ContentPage
    {
        private EntryCell _parameterA;
        private EntryCell _parameterB;
        private EntryCell _parameterK;
        private EntryCell _parameterScale;

        public MainPage()
        {
            Title = "Ввод данных";

            Init();
        }
        private void Init()
        {
            StackLayout stack = new StackLayout();
            _parameterK = CreateObject.EntryCellNumeric("Перем. k", 1);
            _parameterA = CreateObject.EntryCellNumeric("Перем. a", 2);
            _parameterB = CreateObject.EntryCellNumeric("Перем. b", 0);
            _parameterScale = CreateObject.EntryCellNumeric("Масштаб", 10);

            var table = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("Input data")
                {
                    new TableSection("Данные")
                    {
                        _parameterA,
                        _parameterB,
                        _parameterK,
                        _parameterScale
                    }
                }
            };

            var lbl = CreateObject.Label("Формула y = k * x^a + b");

            var btn = CreateObject.Button("Построить график!");
            btn.Clicked += OnButtonClicked;

            stack.Children.Add(CreateObject.Heading());
            stack.Children.Add(lbl);
            stack.Children.Add(table);
            stack.Children.Add(btn);

            Content = stack;
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_parameterA.Text))
            {
                DisplayAlert("Предупреждение", "Вы не ввели параметр A", "Ок");
                return;
            }
            if (string.IsNullOrEmpty(_parameterK.Text))
            {
                DisplayAlert("Предупреждение", "Вы не ввели параметр K", "Ок");
                return;
            }
            if (string.IsNullOrEmpty(_parameterScale.Text))
            {
                DisplayAlert("Предупреждение", "Вы не ввели масштаб", "Ок");
                return;
            }
            if (string.IsNullOrEmpty(_parameterB.Text))
            {
                DisplayAlert("Предупреждение", "Вы не ввели параметр b", "Ок");
                return;
            }

            float valueA = Convert.ToSingle(_parameterA.Text);
            float valueB = Convert.ToSingle(_parameterB.Text);
            float valueK = Convert.ToSingle(_parameterK.Text);
            int scale = (int)Convert.ToSingle(_parameterScale.Text);

            var function = new PowerFunctionData(valueA, valueB, valueK, scale);
            await Navigation.PushAsync(new GraphPage(function));
        }

    }
}

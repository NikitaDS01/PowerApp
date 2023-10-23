using PowerApp.Function;
using PowerApplication.Function;
using System;
using Xamarin.Forms;

namespace PowerApplication.Page
{
    public partial class MainPage : ContentPage
    {
        private EntryCell _parameterA;
        private EntryCell _parameterK;

        public MainPage()
        {
            Title = "Ввод данных";

            Init();
        }
        private void Init()
        {
            StackLayout stack = new StackLayout();
            _parameterK = CreateObject.EntryCellNumeric("Перем. k", 1);
            _parameterA = CreateObject.EntryCellNumeric("Перем. a");

            var table = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("Input data")
                {
                    new TableSection("Данные")
                    {
                        _parameterA,
                        _parameterK
                    }
                }
            };

            var lbl = CreateObject.Label("Формула y = k * xᵃ");

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
                DisplayAlert("Предупреждение", "Вы не ввели параметр а", "Ок");
                return;
            }

            float valueA = Convert.ToSingle(_parameterA.Text);
            float valueK = Convert.ToSingle(_parameterK.Text);

            var function = new PowerFunctionData(valueA, valueK);
            await Navigation.PushAsync(new GraphPage(function));
        }

    }
}

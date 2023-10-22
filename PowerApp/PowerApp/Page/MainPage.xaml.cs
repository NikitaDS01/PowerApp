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
            _parameterK = CreateObject.EntryCellNumeric("Перем. k");
            _parameterA = CreateObject.EntryCellNumeric("Перем. a");

            var table = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("Input data")
                {
                    new TableSection("Данные")
                    {
                        _parameterK,
                        _parameterA
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
            float valueA = 0;
            if (!string.IsNullOrEmpty(_parameterA.Text))
                valueA = Convert.ToSingle(_parameterA.Text);

            float valueK = 0;
            if (!string.IsNullOrEmpty(_parameterK.Text))
                valueK = Convert.ToSingle(_parameterK.Text);

            var function = new PowerFunctionData(valueA, valueK);
            await Navigation.PushAsync(new GraphPage(function));
        }

    }
}

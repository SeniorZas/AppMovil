using System.Diagnostics;
using CommunityToolkit.Maui.Alerts;

namespace ColorMaker
{
    public partial class MainPage : ContentPage
    {
        bool RandomValue;
        string valorHex ="";
        public MainPage()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (!RandomValue)
            {
                var red = sliderR.Value;
                var green = sliderG.Value;
                var blue = sliderB.Value;

                Color color = Color.FromRgb(red, green, blue);

                SetColor(color);
            }

        }
        private void SetColor(Color color)
        {
            RantomButton.BackgroundColor = color;
            Container.BackgroundColor = color;
            valorHex = color.ToHex();
            lblHex.Text = valorHex;


        }

        private void RantomButton_Clicked(object sender, EventArgs e)
        {
            RandomValue = true;
            var random = new Random();

            var color = Color.FromRgb(
                random.Next(0, 265),
                random.Next(0, 265),
                random.Next(0, 265)
                );
            SetColor(color);

            sliderR.Value = color.Red;
            sliderG.Value = color.Green;
            sliderB.Value = color.Blue;

            RandomValue=false;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(valorHex);
            var toast = Toast.Make("Color copied",
                CommunityToolkit.Maui.Core.ToastDuration.Short,
                12);
            await toast.Show();
        }
    }

}

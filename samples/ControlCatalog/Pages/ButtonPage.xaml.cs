using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ControlCatalog.Pages
{
    public class ButtonPage : UserControl
    {
        int regClickCount = 0;
        int tmnaClickCount = 0;
        public ButtonPage()
        {
            InitializeComponent();

            var regRepeatButton = this.FindControl<RepeatButton>("RepeatButton");
            regRepeatButton.Click += (s, e) =>
            {
                regClickCount++;
                regRepeatButton.Content = $"RepeatButton ({regClickCount} clicks)";
            };
            
            var tmnaRepeatButton = this.FindControl<RepeatButton>("ToolsMenuAreaRepeatButton");
            tmnaRepeatButton.Click += (s, e) =>
            {
                tmnaClickCount++;
                tmnaRepeatButton.Content = $"RepeatButton ({tmnaClickCount} clicks)";
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void OnRepeatButtonClick(object sender, object args)
        {
            int clickCount = 1;
            if ((sender as RepeatButton).Tag is int clCount)
                clickCount = clCount++;
            
            (sender as RepeatButton).Content = $"RepeatButton ({clickCount} clicks)";
            (sender as RepeatButton).Tag = clickCount;
        }
    }
}

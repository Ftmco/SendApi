using System;
using System.Xml.Linq;
using TestApi.Pages;
using Windows.App.Pages;
using Windows.UI;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btn_Account_Click(object sender, RoutedEventArgs e)
        {
            frm_Main.Navigate(typeof(Login));
        }

        private void btn_Home_Click(Object sender, RoutedEventArgs e)
        {
            frm_Main.Navigate(typeof(Home));
        }

        private void btn_Setting_Click(Object sender, RoutedEventArgs e)
        {
            frm_Main.Navigate(typeof(Setting));
        }

        private async void btn_Clear_Click(Object sender, RoutedEventArgs e)
        {
            //frm_Main.Navigate(typeof(Home));
            ContentDialog dialog = new ContentDialog()
            {
                Title = "Warning",
                Content =
                "Do You want To Delete All Tabs?",
                CloseButtonText = "No",
                PrimaryButtonText = "Yes",
                DefaultButton = ContentDialogButton.Primary,
                Background = new SolidColorBrush() { Color = new Color() { A = 50,B = 63,G = 228,R = 223} }
            };
            var res = await dialog.ShowAsync(ContentDialogPlacement.Popup);
            if (res == ContentDialogResult.Primary)
            {
                frm_Main.Navigate(typeof(Home));
            }
        }

        private void btn_newCollection_Click(Object sender, RoutedEventArgs e)
        {

        }


    }
}

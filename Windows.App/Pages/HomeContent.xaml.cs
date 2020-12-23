using services.cross.Repository;
using services.cross.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows.App.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomeContent : Page
    {
        public DateTime date = DateTime.Now;
        IButifyRepository butify = new ButifyServices();

        public HomeContent()
        {
            this.InitializeComponent();
        }


        private void btn_ChoseMethod(Object sender, RoutedEventArgs e)
        {
            var option = (MenuFlyoutItem)sender;
            drp_Type.Content = option.Tag;
        }

        private void RadioButton_Checked(Object sender, RoutedEventArgs e)
        {
            var checkBox = (RadioButton)sender;
            if (checkBox.Name == "raw")
            {
                if (checkBox.IsChecked.Value)
                {
                    drp_dataType.IsEnabled = true;
                }
                else
                {
                    drp_dataType.IsEnabled = false;
                }
            }
        }

        private void dataTypeChange(Object sender, RoutedEventArgs e)
        {
            var option = (MenuFlyoutItem)sender;
            drp_dataType.Content = option.Tag;
        }

        private async void btn_SendRequest_Click(Object sender, RoutedEventArgs e)
        {
            {
                HttpResponseMessage result = new HttpResponseMessage();
                try
                {
                    HttpClient client = new HttpClient();
                    txt_result.Document.SetText(TextSetOptions.None, "Sending Reuest Please Wait");
                    result = await client.GetAsync(txt_url.Text);
                    string buitifyReponse = await butify.GetButifyAsync(result.Content.ReadAsStringAsync().Result);
                    txt_result.Document.SetText(TextSetOptions.None, buitifyReponse);
                    lblStatus.Text = result.StatusCode.ToString();

                    lblStatus.Foreground = new SolidColorBrush()
                    {
                        Color = new Color()
                        {
                            A = 200,
                            B = 2,
                            R = 11,
                            G = 166
                        }
                    };
                    txt_result.IsReadOnly = true;

                }
                catch (Exception ex)
                {
                    txt_result.Document.SetText(TextSetOptions.None, ex.Message);
                   
                    txt_result.Foreground = new SolidColorBrush()
                    {
                        Color = new Color()
                        {
                            A = 200,
                            B = 1,
                            R = 203,
                            G = 1
                        }
                    };
                    txt_result.IsReadOnly = true;
                }
            }
        }
    }
}

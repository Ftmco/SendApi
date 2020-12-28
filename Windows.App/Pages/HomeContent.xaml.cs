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

            HttpResponseMessage result = new HttpResponseMessage();
            try
            {
                pgr_waitSend.Visibility = Visibility.Visible;
                pgr_waitSend.IsActive = true;
                HttpClient client = new HttpClient();
                txt_result.Document.SetText(TextSetOptions.None, "Sending Reuest Please Wait");

                result = await client.GetAsync(txt_url.Text);
                string buitifyReponse = await butify.GetButifyAsync(result.Content.ReadAsStringAsync().Result);

                pgr_waitSend.IsActive = false;
                pgr_waitSend.Visibility = Visibility.Collapsed;

                txt_result.Document.SetText(TextSetOptions.None, buitifyReponse);
                SetResultStatus(result);
                txt_result.IsReadOnly = true;

            }
            catch (Exception ex)
            {
                pgr_waitSend.IsActive = false;
                pgr_waitSend.Visibility = Visibility.Collapsed;
                txt_result.Document.SetText(TextSetOptions.None, ex.Message);
                SetColor(200, 203, 1, 1);

                txt_result.IsReadOnly = true;
            }

        }

        private static void SetResultStatus(HttpResponseMessage reslut)
        {
            switch (result.StatusCode)
            {
                case global::System.Net.HttpStatusCode.Accepted:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 202";
                        SetColor(200, 5, 36, 248);
                        break;
                    }
                case global::System.Net.HttpStatusCode.Ambiguous:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 300";
                        SetColor(200, 11, 166, 2);
                        break;
                    }
                case global::System.Net.HttpStatusCode.BadGateway:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 502";
                        SetColor(200, 253, 0, 6);
                        break;
                    }

                case global::System.Net.HttpStatusCode.BadRequest:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 400";
                        SetColor(200, 253, 0, 6);
                        break;
                    }
                case global::System.Net.HttpStatusCode.Conflict:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 409";
                        SetColor(200, 253, 0, 6);
                        break;
                    }
                case global::System.Net.HttpStatusCode.Continue:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 100";
                        SetColor(200, 253, 0, 6);
                        break;
                    }
                case global::System.Net.HttpStatusCode.Created:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 201";
                        SetColor(200, 5, 36, 248);
                        break;
                    }
                case global::System.Net.HttpStatusCode.ExpectationFailed:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 417";
                        SetColor(200, 253, 0, 6);
                        break;
                    }
                case global::System.Net.HttpStatusCode.Forbidden:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 403";
                        SetColor(200, 253, 0, 6);
                        break;
                    }
                case global::System.Net.HttpStatusCode.Found:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 302";
                        SetColor(200, 11, 166, 2);
                        break;
                    }
                case global::System.Net.HttpStatusCode.GatewayTimeout:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 504";
                        SetColor(200, 253, 0, 6);
                        break;
                    }
                case global::System.Net.HttpStatusCode.Gone:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 410";
                        SetColor(200, 253, 0, 6);
                        break;
                    }
                case global::System.Net.HttpStatusCode.HttpVersionNotSupported:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 505";
                        SetColor(200, 253, 0, 6);
                        break;
                    }
                case global::System.Net.HttpStatusCode.InternalServerError:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 500";
                        SetColor(200, 253, 0, 6);
                        break;
                    }
                case global::System.Net.HttpStatusCode.LengthRequired:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 411";
                        SetColor(200, 253, 0, 6);
                        break;
                    }
                case global::System.Net.HttpStatusCode.MethodNotAllowed:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 405";
                        SetColor(200, 253, 0, 6);
                        break;
                    }
                case global::System.Net.HttpStatusCode.Moved:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 301";
                        SetColor(200, 11, 166, 2);
                        break;
                    }


                case global::System.Net.HttpStatusCode.NoContent:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 204";
                        SetColor(200, 5, 36, 248);
                        break;
                    }
                case global::System.Net.HttpStatusCode.NonAuthoritativeInformation:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 203";
                        SetColor(200, 5, 36, 248);
                        break;
                    }
                case global::System.Net.HttpStatusCode.NotAcceptable:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 406";
                        SetColor(200, 253, 0, 6);
                        break;
                    }
                case global::System.Net.HttpStatusCode.NotFound:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 404";
                        SetColor(200, 253, 0, 6);
                        break;
                    }
                case global::System.Net.HttpStatusCode.NotImplemented:
                    break;
                case global::System.Net.HttpStatusCode.NotModified:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 304";
                        SetColor(200, 11, 166, 2);
                        break;
                    }
                case global::System.Net.HttpStatusCode.OK:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 200";
                        SetColor(200, 5, 36, 248);
                        break;
                    }
                case global::System.Net.HttpStatusCode.PartialContent:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 206";
                        SetColor(200, 5, 36, 248);
                        break;
                    }
                case global::System.Net.HttpStatusCode.PaymentRequired:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 402";
                        SetColor(200, 253, 0, 6);
                        break;
                    }
                case global::System.Net.HttpStatusCode.PreconditionFailed:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 412";
                        SetColor(200, 253, 0, 6);
                        break;
                    }
                case global::System.Net.HttpStatusCode.ProxyAuthenticationRequired:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 407";
                        SetColor(200, 253, 0, 6);
                        break;
                    }

                case global::System.Net.HttpStatusCode.RedirectKeepVerb:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 307";
                        SetColor(200, 11, 166, 2);
                        break;
                    }
                case global::System.Net.HttpStatusCode.RedirectMethod:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 303";
                        SetColor(200, 11, 166, 2);
                        break;
                    }
                case global::System.Net.HttpStatusCode.RequestedRangeNotSatisfiable:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 416";
                        SetColor(200, 253, 0, 6);
                        break;
                    }
                case global::System.Net.HttpStatusCode.RequestEntityTooLarge:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 413";
                        SetColor(200, 253, 0, 6);
                        break;
                    }
                case global::System.Net.HttpStatusCode.RequestTimeout:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 408";
                        SetColor(200, 253, 0, 6);
                        break;
                    }
                case global::System.Net.HttpStatusCode.RequestUriTooLong:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 414";
                        SetColor(200, 253, 0, 6);
                        break;
                    }
                case global::System.Net.HttpStatusCode.ResetContent:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 205";
                        SetColor(200, 5, 36, 248);
                        break;
                    }

                case global::System.Net.HttpStatusCode.ServiceUnavailable:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 503";
                        SetColor(200, 253, 0, 6);
                        break;
                    }
                case global::System.Net.HttpStatusCode.SwitchingProtocols:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 101";
                        SetColor(200, 85, 255, 55);
                        break;
                    }

                case global::System.Net.HttpStatusCode.Unauthorized:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 401";
                        SetColor(200, 253, 0, 6);
                        break;
                    }
                case global::System.Net.HttpStatusCode.UnsupportedMediaType:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 415";
                        SetColor(200, 253, 0, 6);
                        break;
                    }
                case global::System.Net.HttpStatusCode.Unused:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 306";
                        SetColor(200, 11, 166, 2);
                        break;
                    }
                case global::System.Net.HttpStatusCode.UpgradeRequired:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 426";
                        SetColor(200, 253, 0, 6);
                        break;
                    }
                case global::System.Net.HttpStatusCode.UseProxy:
                    {
                        lblStatus.Text = result.StatusCode.ToString() + " 305";
                        SetColor(200, 11, 166, 2);
                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// Set Color for Set Result Status Function 
        /// </summary>
        /// <param name="a">Alpha</param>
        /// <param name="r">Red</param>
        /// <param name="g">Green</param>
        /// <param name="b">blue</param>
        private static void SetColor(byte a = 200, byte r = 190, byte g = 255, byte b = 179)
        {
            lblStatus.Foreground = new SolidColorBrush()
            {
                Color = new Color()
                {
                    A = a,
                    R = r,
                    G = g,
                    B = b
                }
            };
        }
    }
}

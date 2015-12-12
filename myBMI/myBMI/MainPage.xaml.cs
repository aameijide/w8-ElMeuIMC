using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace myBMI
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

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        private void boto_Click(object sender, RoutedEventArgs e)
        {
            string u = pes.Text;
            u = u.Replace(".", ",");
            string dos = alcada.Text;
            dos = dos.Replace(".", ",");

            double pes2 = -1;
            double alcada2 = -1;
            try
            {
                pes2 = Convert.ToDouble(u);
                alcada2 = Convert.ToDouble(dos);

            }
            catch (FormatException i)
            {
                IMC2.Text = "Please, write only numbers";
            }
            catch (OverflowException i)
            {
                IMC2.Text = "Error. Numbers are too big";
            }
            if (alcada2 == 0 || pes2 == 0)
                IMC2.Text = "Neither Height nor Weight can be 0";
            else
            {
                if (alcada2 > 10)
                {
                    alcada2 = alcada2 / 100;
                }

                double IMCN = pes2 / (alcada2 * alcada2);

                int calcul = Convert.ToInt32(IMCN);

                if (IMCN != -1)
                {

                    IMC.Text = "Your body mass index is " + calcul;
                    if (IMCN < 16)
                    {
                        IMC2.Text = "You're very severely underweight";
                        IMC2.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                    }
                    if (IMCN >= 16 && IMCN < 17)
                    {
                        IMC2.Text = "You're severely underweight";
                        IMC2.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                    }
                    if (IMCN >= 17 && IMCN < 19)
                    {
                        IMC2.Text = "You're underweight";
                        IMC2.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                    }
                    if (IMCN >= 19 && IMCN < 25)
                    {
                        if (IMCN >= 22 && IMCN < 23)
                            IMC2.Text = "You've a ideal weight";
                        else
                            IMC2.Text = "You've a normal weight";

                        IMC2.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                    }
                    if (IMCN >= 25 && IMCN < 30)
                    {
                        IMC2.Text = "You're overweight";
                        IMC2.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                    }
                    if (IMCN >= 35 && IMCN < 40)
                    {
                        IMC2.Text = "You're severely overweight";
                        IMC2.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                    }
                    if (IMCN >= 40)
                    {
                        IMC2.Text = "You're very severely overweight";
                        IMC2.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                    }
                }
                else
                {
                    IMC2.Text = "Error reading data. Please check you write numbers and you use comma (,) or dot (.) only.";
                }
            }
        }
    }
}

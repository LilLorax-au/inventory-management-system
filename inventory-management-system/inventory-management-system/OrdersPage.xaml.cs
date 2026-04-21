using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace inventory_management_system
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrdersPage : Page
    {
        SolidColorBrush colorSetBrush;
        SolidColorBrush colorUnsetBrush;
        public OrdersPage()
        {
            this.InitializeComponent();
            ARGBUnpacker();
            ClearAll();
            UpdateOutput("Input your desiered fields, each order can only have three Products");
        }

        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ProductPage), null, new SuppressNavigationTransitionInfo());
        }

        private void CustomersButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CustomersPage), null, new SuppressNavigationTransitionInfo());
        }



        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddButton.Background = colorSetBrush;
            UpdateButton.Background = colorUnsetBrush;
            ShowButton.Background = colorUnsetBrush;
            DeleteButton.Background = colorUnsetBrush;

            OrderIdTextBox.IsEnabled = false;
            CustomerIdTextBox.IsEnabled = true;
            ProductIdOneTextBox.IsEnabled = true;
            ProductIdTwoTextBox.IsEnabled = true;
            ProductIdThreeTextBox.IsEnabled = true;
            QuantityOneTextBox.IsEnabled = true;
            QuantityTwoTextBox.IsEnabled = true;
            QuantityThreeTextBox.IsEnabled = true;

            UpdateOutput("Input your desiered fields, each order can only have three Products");
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            AddButton.Background = colorUnsetBrush;
            UpdateButton.Background = colorSetBrush;
            ShowButton.Background = colorUnsetBrush;
            DeleteButton.Background = colorUnsetBrush;

            OrderIdTextBox.IsEnabled = true;
            CustomerIdTextBox.IsEnabled = true;
            ProductIdOneTextBox.IsEnabled = true;
            ProductIdTwoTextBox.IsEnabled = true;
            ProductIdThreeTextBox.IsEnabled = true;
            QuantityOneTextBox.IsEnabled = true;
            QuantityTwoTextBox.IsEnabled = true;
            QuantityThreeTextBox.IsEnabled = true;

            UpdateOutput("Input all fields, Products you want removed; set the quanity to 0");
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            AddButton.Background = colorUnsetBrush;
            UpdateButton.Background = colorUnsetBrush;
            ShowButton.Background = colorSetBrush;
            DeleteButton.Background = colorUnsetBrush;

            OrderIdTextBox.IsEnabled = true;
            CustomerIdTextBox.IsEnabled = false;
            ProductIdOneTextBox.IsEnabled = false;
            ProductIdTwoTextBox.IsEnabled = false;
            ProductIdThreeTextBox.IsEnabled = false;
            QuantityOneTextBox.IsEnabled = false;
            QuantityTwoTextBox.IsEnabled = false;
            QuantityThreeTextBox.IsEnabled = false;

            UpdateOutput("Input Order ID for a display the order details.");
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            AddButton.Background = colorUnsetBrush;
            UpdateButton.Background = colorUnsetBrush;
            ShowButton.Background = colorUnsetBrush;
            DeleteButton.Background = colorSetBrush;

            OrderIdTextBox.IsEnabled = true;
            CustomerIdTextBox.IsEnabled = true;
            ProductIdOneTextBox.IsEnabled = true;
            ProductIdTwoTextBox.IsEnabled = true;
            ProductIdThreeTextBox.IsEnabled = true;
            QuantityOneTextBox.IsEnabled = true;
            QuantityTwoTextBox.IsEnabled = true;
            QuantityThreeTextBox.IsEnabled = true;

            UpdateOutput("Input Order ID to delete Order, this cannot be undone.");
        }
        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            OrderIdTextBox.Text = "";
            CustomerIdTextBox.Text = "";
            ProductIdOneTextBox.Text = "";
            ProductIdTwoTextBox.Text = "";
            ProductIdThreeTextBox.Text = "";
            QuantityOneTextBox.Text = "";
            QuantityTwoTextBox.Text = "";

            OutputTextBox.Text = "";
        }

        private void UpdateOutput(String textToOutput)
        {
            OutputTextBox.Text = textToOutput;
        }
        private void ARGBUnpacker()
        {
            this.colorSetBrush = new SolidColorBrush(Color.FromArgb(App.buttonSet.A, App.buttonSet.R, App.buttonSet.G, App.buttonSet.B));
            this.colorUnsetBrush = new SolidColorBrush(Color.FromArgb(App.buttonUnset.A, App.buttonUnset.R, App.buttonUnset.G, App.buttonUnset.B));
        }


    }
}

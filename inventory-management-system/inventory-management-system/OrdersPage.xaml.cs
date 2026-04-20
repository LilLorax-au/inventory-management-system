using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace inventory_management_system
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrdersPage : Page
    {
        public OrdersPage()
        {
            this.InitializeComponent();
        }

        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ProductPage));
        }

        private void CustomersButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CustomersPage));
        }



        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            OrderIdTextBox.IsEnabled = true;
            CustomerIdTextBox.IsEnabled = true;
            ProductIdOneTextBox.IsEnabled = true;
            ProductIdTwoTextBox.IsEnabled = true;
            ProductIdThreeTextBox.IsEnabled = true;
            QuantityOneTextBox.IsEnabled = true;
            QuantityTwoTextBox.IsEnabled = true;


        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

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
        }


    }
}

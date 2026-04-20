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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace inventory_management_system
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProductPage : Page
    {
        public ProductPage()
        {
            this.InitializeComponent();
            ClearAll();
        }


        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OrdersPage), null, new SuppressNavigationTransitionInfo());
        }

        private void CustomersButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CustomersPage), null, new SuppressNavigationTransitionInfo());
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

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

        }

        private void ClearAll()
        {
            ProductIdTextBox.Text = "";   
            ProductNameTextBox.Text = "";   
            ProductCostTextBox.Text = "";   
            ProductQuantityTextBox.Text = "";

            OutputTextBox.Text = "";
        }
    }
}

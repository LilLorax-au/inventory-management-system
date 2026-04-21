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
    public sealed partial class ProductPage : Page
    {
        SolidColorBrush colorSetBrush;
        SolidColorBrush colorUnsetBrush;
        public ProductPage()
        {
            this.InitializeComponent();
            ARGBUnpacker();
            ClearAll();
            UpdateOutput("Input all fields to create new Product, Product ID will be auto set.");
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
            AddButton.Background = colorSetBrush;
            UpdateButton.Background = colorUnsetBrush;
            ShowButton.Background = colorUnsetBrush;
            DeleteButton.Background = colorUnsetBrush;

            ProductIdTextBox.IsEnabled = false;
            ProductNameTextBox.IsEnabled = true;
            ProductCostTextBox.IsEnabled = true;
            ProductQuantityTextBox.IsEnabled = true;

            UpdateOutput("Input all fields to create new Product, Product ID will be auto set.");

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            AddButton.Background = colorUnsetBrush;
            UpdateButton.Background = colorSetBrush;
            ShowButton.Background = colorUnsetBrush;
            DeleteButton.Background = colorUnsetBrush;

            ProductIdTextBox.IsEnabled = true;
            ProductNameTextBox.IsEnabled = true;
            ProductCostTextBox.IsEnabled = true;
            ProductQuantityTextBox.IsEnabled = true;

            UpdateOutput("Input all fields to update Product. For what you want to keep the same, assure the field matches existing data.");
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            AddButton.Background = colorUnsetBrush;
            UpdateButton.Background = colorUnsetBrush;
            ShowButton.Background = colorSetBrush;
            DeleteButton.Background = colorUnsetBrush;

            ProductIdTextBox.IsEnabled = true;
            ProductNameTextBox.IsEnabled = false;
            ProductCostTextBox.IsEnabled = false;
            ProductQuantityTextBox.IsEnabled = false;

            UpdateOutput("Input Product ID for a display of Product.");
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            AddButton.Background = colorUnsetBrush;
            UpdateButton.Background = colorUnsetBrush;
            ShowButton.Background = colorUnsetBrush;
            DeleteButton.Background = colorSetBrush;

            ProductIdTextBox.IsEnabled = true;
            ProductNameTextBox.IsEnabled = false;
            ProductCostTextBox.IsEnabled = false;
            ProductQuantityTextBox.IsEnabled = false;

            UpdateOutput("Input Product ID to delete product, this cannot be undone.");

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
            ProductIdTextBox.Text = "";   
            ProductNameTextBox.Text = "";   
            ProductCostTextBox.Text = "";   
            ProductQuantityTextBox.Text = "";

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

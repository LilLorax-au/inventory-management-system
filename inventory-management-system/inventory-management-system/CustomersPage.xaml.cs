using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

    public sealed partial class CustomersPage : Page
    {
            SolidColorBrush colorSetBrush;
            SolidColorBrush colorUnsetBrush;

        public CustomersPage()
        {
            this.InitializeComponent();
            ARGBUnpacker();
            ClearAll();
        }

        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ProductPage), null, new SuppressNavigationTransitionInfo());
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OrdersPage), null, new SuppressNavigationTransitionInfo());
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            AddButton.Background = colorSetBrush;
            UpdateButton.Background = colorUnsetBrush;
            ShowButton.Background = colorUnsetBrush;
            DeleteButton.Background = colorUnsetBrush;
            CustomerIdTextBox.IsEnabled = false;
            FirstNameTextBox.IsEnabled = true;
            LastNameTextBox.IsEnabled = true;
            EmailTextBox.IsEnabled = true;
            PhoneTextBox.IsEnabled = true;

            OutputTextBox.Text = "Fill all inputs to create a new user";

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            AddButton.Background = colorUnsetBrush;
            UpdateButton.Background = colorSetBrush;
            ShowButton.Background = colorUnsetBrush;
            DeleteButton.Background = colorUnsetBrush;
            
            CustomerIdTextBox.IsEnabled = true;
            FirstNameTextBox.IsEnabled = true;
            LastNameTextBox.IsEnabled = true;
            EmailTextBox.IsEnabled = true;
            PhoneTextBox.IsEnabled = true;

            OutputTextBox.Text = "Fill all inputs to update customers";
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            AddButton.Background = colorUnsetBrush;
            UpdateButton.Background = colorUnsetBrush;
            ShowButton.Background = colorSetBrush;
            DeleteButton.Background = colorUnsetBrush;

            CustomerIdTextBox.IsEnabled = true;
            FirstNameTextBox.IsEnabled = true;
            LastNameTextBox.IsEnabled = true;
            EmailTextBox.IsEnabled = true;
            PhoneTextBox.IsEnabled = true;


            OutputTextBox.Text = "Fill all inputs to display customer";
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            AddButton.Background = colorUnsetBrush;
            UpdateButton.Background = colorUnsetBrush;
            ShowButton.Background = colorUnsetBrush;
            DeleteButton.Background = colorSetBrush;

            CustomerIdTextBox.IsEnabled = true;
            FirstNameTextBox.IsEnabled = false;
            LastNameTextBox.IsEnabled = false;
            EmailTextBox.IsEnabled = false;
            PhoneTextBox.IsEnabled = false;

            OutputTextBox.Text = "Input Customers Id to delete, this cannot be undone";
        }
        private void ClearAll()
        {
            CustomerIdTextBox.Text = "";
            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";
            EmailTextBox.Text = "";
            PhoneTextBox.Text = "";

            OutputTextBox.Text = "";

            FirstNameTextBox.Focus(FocusState.Programmatic);
        }
        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }

        private void ARGBUnpacker()
        {
            this.colorSetBrush = new SolidColorBrush(Color.FromArgb(App.buttonSet.A, App.buttonSet.R, App.buttonSet.G, App.buttonSet.B));
            this.colorUnsetBrush = new SolidColorBrush(Color.FromArgb(App.buttonUnset.A, App.buttonUnset.R, App.buttonUnset.G, App.buttonUnset.B));
        }
    }
}

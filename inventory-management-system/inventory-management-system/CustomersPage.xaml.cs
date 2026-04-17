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
    public sealed partial class CustomersPage : Page
    {
        public CustomersPage()
        {
            this.InitializeComponent();
        }

        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {

        }



        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            CustomerIdTextBox.IsEnabled = false;
            FirstNameTextBox.IsEnabled = true;
            LastNameTextBox.IsEnabled = true;
            EmailTextBox.IsEnabled = true;
            PhoneTextBox.IsEnabled = true;

            OutputTextBox.Text = "Fill all inputs to create a new user";

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            CustomerIdTextBox.IsEnabled = true;
            FirstNameTextBox.IsEnabled = true;
            LastNameTextBox.IsEnabled = true;
            EmailTextBox.IsEnabled = true;
            PhoneTextBox.IsEnabled = true;

            OutputTextBox.Text = "Fill all inputs to update user";
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            CustomerIdTextBox.IsEnabled = true;
            FirstNameTextBox.IsEnabled = true;
            LastNameTextBox.IsEnabled = true;
            EmailTextBox.IsEnabled = true;
            PhoneTextBox.IsEnabled = true;


            OutputTextBox.Text = "Fill all inputs to update user";
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            CustomerIdTextBox.IsEnabled = true;
            FirstNameTextBox.IsEnabled = false;
            LastNameTextBox.IsEnabled = false;
            EmailTextBox.IsEnabled = false;
            PhoneTextBox.IsEnabled = false;
        }
    }
}

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
        public CustomersPage()
        {
            this.InitializeComponent();
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
            App.ARGBBuilder tempColorSet = App.buttonSet;
            App.ARGBBuilder tempColorUnset = App.buttonUnset;

            AddButton.Background = new SolidColorBrush(Color.FromArgb(tempColorSet.A,tempColorSet.R,tempColorSet.G,tempColorSet.B));
            UpdateButton.Background = new SolidColorBrush(Color.FromArgb(tempColorUnset.A,tempColorUnset.R,tempColorUnset.G,tempColorUnset.B));
            ShowButton.Background = new SolidColorBrush(Color.FromArgb(tempColorUnset.A,tempColorUnset.R,tempColorUnset.G,tempColorUnset.B));
            DeleteButton.Background = new SolidColorBrush(Color.FromArgb(tempColorUnset.A,tempColorUnset.R,tempColorUnset.G,tempColorUnset.B));
            CustomerIdTextBox.IsEnabled = false;
            FirstNameTextBox.IsEnabled = true;
            LastNameTextBox.IsEnabled = true;
            EmailTextBox.IsEnabled = true;
            PhoneTextBox.IsEnabled = true;

            OutputTextBox.Text = "Fill all inputs to create a new user";

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            App.ARGBBuilder tempColorSet = App.buttonSet;
            App.ARGBBuilder tempColorUnset = App.buttonUnset;

            AddButton.Background = new SolidColorBrush(Color.FromArgb(tempColorUnset.A, tempColorUnset.R, tempColorUnset.G, tempColorUnset.B));
            UpdateButton.Background = new SolidColorBrush(Color.FromArgb(tempColorSet.A, tempColorSet.R, tempColorSet.G, tempColorSet.B));
            ShowButton.Background = new SolidColorBrush(Color.FromArgb(tempColorUnset.A,tempColorUnset.R,tempColorUnset.G,tempColorUnset.B));
            DeleteButton.Background = new SolidColorBrush(Color.FromArgb(tempColorUnset.A,tempColorUnset.R,tempColorUnset.G,tempColorUnset.B));
            
            CustomerIdTextBox.IsEnabled = true;
            FirstNameTextBox.IsEnabled = true;
            LastNameTextBox.IsEnabled = true;
            EmailTextBox.IsEnabled = true;
            PhoneTextBox.IsEnabled = true;

            OutputTextBox.Text = "Fill all inputs to update customers";
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            App.ARGBBuilder tempColorSet = App.buttonSet;
            App.ARGBBuilder tempColorUnset = App.buttonUnset;

            AddButton.Background = new SolidColorBrush(Color.FromArgb(tempColorUnset.A, tempColorUnset.R, tempColorUnset.G, tempColorUnset.B));
            UpdateButton.Background = new SolidColorBrush(Color.FromArgb(tempColorUnset.A, tempColorUnset.R, tempColorUnset.G, tempColorUnset.B));
            ShowButton.Background = new SolidColorBrush(Color.FromArgb(tempColorSet.A, tempColorSet.R, tempColorSet.G, tempColorSet.B));
            DeleteButton.Background = new SolidColorBrush(Color.FromArgb(tempColorUnset.A,tempColorUnset.R,tempColorUnset.G,tempColorUnset.B));

            CustomerIdTextBox.IsEnabled = true;
            FirstNameTextBox.IsEnabled = true;
            LastNameTextBox.IsEnabled = true;
            EmailTextBox.IsEnabled = true;
            PhoneTextBox.IsEnabled = true;


            OutputTextBox.Text = "Fill all inputs to display customer";
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            App.ARGBBuilder tempColorSet = App.buttonSet;
            App.ARGBBuilder tempColorUnset = App.buttonUnset;

            AddButton.Background = new SolidColorBrush(Color.FromArgb(tempColorUnset.A, tempColorUnset.R, tempColorUnset.G, tempColorUnset.B));
            UpdateButton.Background = new SolidColorBrush(Color.FromArgb(tempColorUnset.A, tempColorUnset.R, tempColorUnset.G, tempColorUnset.B));
            ShowButton.Background = new SolidColorBrush(Color.FromArgb(tempColorUnset.A,tempColorUnset.R,tempColorUnset.G,tempColorUnset.B));
            DeleteButton.Background = new SolidColorBrush(Color.FromArgb(tempColorSet.A, tempColorSet.R, tempColorSet.G, tempColorSet.B));

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
    }
}

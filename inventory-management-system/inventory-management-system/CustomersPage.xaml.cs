using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
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
        DatabaseService database;
        String buttonState;

        private struct inputBlock
        {
            public String id;
            public String name;
            public String email;
            public String phone;
        }

        public CustomersPage()
        {
            this.InitializeComponent();
            ARGBUnpacker();
            ClearAll();
            UpdateOutput("Input all inputs to create a new user, Customer ID will be auto created.");
            database = App.database;
            buttonState = "add";
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

            buttonState = "add";

            UpdateOutput("Input all inputs to create a new user, Customer ID will be auto created.");
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

            buttonState = "update";

            UpdateOutput("Input all inputs to update customers, for values you want to keep the same, assure the field matches existing data.");
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            AddButton.Background = colorUnsetBrush;
            UpdateButton.Background = colorUnsetBrush;
            ShowButton.Background = colorSetBrush;
            DeleteButton.Background = colorUnsetBrush;

            CustomerIdTextBox.IsEnabled = true;
            FirstNameTextBox.IsEnabled = false;
            LastNameTextBox.IsEnabled = false;
            EmailTextBox.IsEnabled = false;
            PhoneTextBox.IsEnabled = false;

            buttonState = "show";

            UpdateOutput("Input customer ID to display customer details.");
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

            buttonState = "del";

            UpdateOutput("Input Customers Id to delete, this cannot be undone.");
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
        private async void EnterButton_Click(object sender, RoutedEventArgs e)
        {

            String statment = "";
            String statmentType = "";

            inputBlock input;
            input.id = Stripper(CustomerIdTextBox.Text);
            input.name = Stripper(FirstNameTextBox.Text) + " " + Stripper(LastNameTextBox.Text);
            input.email = Stripper(EmailTextBox.Text);
            input.phone = Stripper(PhoneTextBox.Text);

            switch (buttonState)
            {
                case "add":
                    statment = $"INSERT INTO customers (customer_name, customer_email, customer_phone) VALUES ('{input.name}','{input.email}',{input.phone});";
                    statmentType = "insert";
                    break;

                case "update":
                    statment = $"UPDATE customers SET customer_name = '{input.name}', customer_email = '{input.email}', customer_phone = '{input.phone}' WHERE customer_id = '{input.id}' ";
                    statmentType = "update";
                    if (!(database.CheckId(input.id, "customers"))) { await new MessageDialog("ID not found").ShowAsync(); return; }
                    break;

                case "show":
                    statment = $"SELECT * FROM customers WHERE customer_id = '{input.id}'";
                    statmentType = "select";
                    break;

                case "del":
                    statment = $"DELETE FROM customers WHERE customer_id = '{input.id}'";
                    statmentType = "delete";
                    if (!(database.CheckId(input.id, "customers"))) {await new MessageDialog("ID not found").ShowAsync(); return; }
                    break;
            }

            if (statmentType != "select")
            {
                var popUp = database.PassStatment(App.localUser, statment, statmentType);
                await popUp.ShowAsync();
            }
            else
            { 
                database.connection.Open();
                var command = new SqliteCommand(statment, database.connection);
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var name = reader.GetString(1);
                    var email = reader.GetString(2);
                    var phone = reader.GetInt32(3);

                    var popUp = new MessageDialog($"ID: {id}\nName: {name}\nEmail: {email}\nPhone: {phone}");
                    await popUp.ShowAsync();
                }
                else
                {
                    var popUp = new MessageDialog("Nothing found");
                    await popUp.ShowAsync();

                }

                database.connection.Close();

            }
        }
            

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
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

        private String Stripper(String input)
        {
            if (input == "") return input;

            char[] filter = {'\'',' ','"','/',':','*','#','%','_','\\','-' };
            foreach (char c in filter) 
            {
                input = input.Replace(c.ToString(), "");
            }

            return input;
        }
    }
}


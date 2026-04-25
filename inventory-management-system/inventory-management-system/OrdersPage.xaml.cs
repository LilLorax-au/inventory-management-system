using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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
    public sealed partial class OrdersPage : Page
    {
        SolidColorBrush colorSetBrush;
        SolidColorBrush colorUnsetBrush;
        DatabaseService database;
        String buttonState;

        private struct inputBlock
        {
            public String order_id;
            public String customer_id;
            public String product_id_1;
            public String product_id_2;
            public String product_id_3;
            public String product_count_1;
            public String product_count_2;
            public String product_count_3;
        }
        public OrdersPage()
        {
            this.InitializeComponent();
            ARGBUnpacker();
            ClearAll();
            UpdateOutput("Input your desiered fields, each order can only have three Products");
            database = App.database;
            buttonState = "add";
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

            buttonState = "add";

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

            buttonState = "update";

            UpdateOutput("Input all fields");
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

            buttonState = "show";

            UpdateOutput("Input Order ID for a display the order details.");
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            AddButton.Background = colorUnsetBrush;
            UpdateButton.Background = colorUnsetBrush;
            ShowButton.Background = colorUnsetBrush;
            DeleteButton.Background = colorSetBrush;

            OrderIdTextBox.IsEnabled = true;
            CustomerIdTextBox.IsEnabled = false;
            ProductIdOneTextBox.IsEnabled = false;
            ProductIdTwoTextBox.IsEnabled = false;
            ProductIdThreeTextBox.IsEnabled = false;
            QuantityOneTextBox.IsEnabled = false;
            QuantityTwoTextBox.IsEnabled = false;
            QuantityThreeTextBox.IsEnabled = false;

            buttonState = "del";

            UpdateOutput("Input Order ID to delete Order, this cannot be undone.");
        }
        private async void EnterButton_Click(object sender, RoutedEventArgs e)
        {

            String statment = "";
            String statmentType = "";
            int orderIdValidator;

            inputBlock input;
            input.order_id = OrderIdTextBox.Text;
            input.customer_id = CustomerIdTextBox.Text;
            input.product_id_1 = ProductIdOneTextBox.Text;
            input.product_id_2 = ProductIdTwoTextBox.Text;
            input.product_id_3 = ProductIdThreeTextBox.Text;
            input.product_count_1 = QuantityOneTextBox.Text;
            input.product_count_2 = QuantityTwoTextBox.Text;
            input.product_count_3 = QuantityThreeTextBox.Text;

            switch (buttonState)
            {
                case "add":
                    statment = $"INSERT INTO orders (customer_id, order_cost) VALUES ('{input.customer_id}','{0}');";
                    statmentType = "insert";
                    database.PassStatment(App.localUser, statment, statmentType);
                    orderIdValidator = database.GetLastID();
                    statment = $@"INSERT INTO products_orders (order_id, product_id, product_order_quantity) VALUES ('{orderIdValidator}','{input.product_id_1}','{input.product_count_1}');";
                    statment += $@"INSERT INTO products_orders (order_id, product_id, product_order_quantity) VALUES ('{orderIdValidator}','{input.product_id_2}','{input.product_count_2}');";
                    statment += $@"INSERT INTO products_orders (order_id, product_id, product_order_quantity) VALUES ('{orderIdValidator}','{input.product_id_3}','{input.product_count_3}');";
                    statment += $"UPDATE orders SET order_cost"
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
                    if (!(database.CheckId(input.id, "customers"))) { await new MessageDialog("ID not found").ShowAsync(); return; }
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

        private String Stripper(String input)
        {
            if (input == "") return input;

            char[] filter = { '\'', ' ', '"', '/', ':', '*', '#', '%', '_', '\\', '-' };
            foreach (char c in filter)
            {
                input = input.Replace(c.ToString(), "");
            }

            return input;
        }
    }
}

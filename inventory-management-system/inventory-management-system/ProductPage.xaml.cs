using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class ProductPage : Page
    {
        SolidColorBrush colorSetBrush;
        SolidColorBrush colorUnsetBrush;
        DatabaseService database;
        String buttonState;

        private struct inputBlock
        {
            public String id;
            public String name;
            public String cost;
            public String count;
        }
        public ProductPage()
        {
            this.InitializeComponent();
            ARGBUnpacker();
            ClearAll();
            UpdateOutput("Input all fields to create new Product, Product ID will be auto set.");
            database = App.database;
            buttonState = "add";
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

            buttonState = "add";

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

            buttonState = "update";

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

            buttonState = "show";

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

            buttonState = "del";

            UpdateOutput("Input Product ID to delete product, this cannot be undone.");
        }
        private async void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            String statment = "";
            String statmentType = "";

            inputBlock input;
            input.id = Stripper(ProductIdTextBox.Text);
            input.name = Stripper(ProductNameTextBox.Text);
            input.cost = Stripper(ProductCostTextBox.Text);
            input.count = Stripper(ProductQuantityTextBox.Text);

            switch (buttonState)
            {
                case "add":
                    statment = $"INSERT INTO products (product_name, product_cost, product_quantity) VALUES ('{input.name}','{input.cost}',{input.count});";
                    statmentType = "insert";
                    break;

                case "update":
                    statment = $"UPDATE products SET product_name = '{input.name}', product_cost = '{input.cost}', product_quantity = '{input.count}' WHERE customer_id = '{input.id}' ";
                    statmentType = "update";
                    if (!(database.CheckId(input.id, "products"))) { await new MessageDialog("ID not found").ShowAsync(); return; }
                    break;

                case "show":
                    statment = $"SELECT * FROM products WHERE product_id = '{input.id}'";
                    statmentType = "select";
                    break;

                case "del":
                    statment = $"DELETE FROM products WHERE product_id = '{input.id}'";
                    statmentType = "delete";
                    if (!(database.CheckId(input.id, "products"))) { await new MessageDialog("ID not found").ShowAsync(); return; }
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
                    var cost = reader.GetFloat(2);
                    var quantity = reader.GetInt32(3);

                    var popUp = new MessageDialog($"ID: {id}\nName: {name}\nCost: {cost}\nQuantity: {quantity}");
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
        private void ARGBUnpacker()
        {
            this.colorSetBrush = new SolidColorBrush(Color.FromArgb(App.buttonSet.A, App.buttonSet.R, App.buttonSet.G, App.buttonSet.B));
            this.colorUnsetBrush = new SolidColorBrush(Color.FromArgb(App.buttonUnset.A, App.buttonUnset.R, App.buttonUnset.G, App.buttonUnset.B));
        }
    }
}

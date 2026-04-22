using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace inventory_management_system
{
    public class DatabaseService
    {
        private const String DATABASE_PATH = "Data Source = cme_inventory.db";

        private static DatabaseService instance;
        private SqliteConnection connection;
        private String sqlSchema;
        public String testString;

        public static DatabaseService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseService();
                }
                return instance;
            }
        }

        private DatabaseService()
        {
            Initialize();
        }

        private void Initialize() 
        {
            connection = new SqliteConnection(DATABASE_PATH);
            sqlSchema = SchemeBuilder();

            connection.Open();

            String[] commands = SchemeBuilder().Split(";");
            foreach (String cmd in commands)
            {
                var command = new SqliteCommand(cmd,connection);
                command.ExecuteNonQuery();
            }

            testString = "This is working";

        }

        private String SchemeBuilder()
        {
            String schema;

            schema = @"

                PRAGMA foreign_keys = ON;

                DROP TABLE IF EXISTS products;
                DROP TABLE IF EXISTS customers;
                DROP TABLE IF EXISTS orders;
                DROP TABLE IF EXISTS products_orders;
                        
                CREATE TABLE IF NOT EXISTS products(
                product_id INTEGER PRIMARY KEY NOT NULL,
                product_name TEXT NOT NULL,
                product_cost REAL NOT NULL,
                product_quantity INT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS customers(
                customer_id INTEGER PRIMARY KEY NOT NULL,
                customer_name TEXT NOT NULL,
                customer_email TEXT NOT NULL,
                customer_phone TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS orders(
                order_id INTEGER PRIMARY KEY NOT NULL,
                order_cost REAL NOT NULL,
                customer_id INT NOT NULL,
                FOREIGN KEY (customer_id) REFERENCES customers (customer_id)
                );

                CREATE TABLE IF NOT EXISTS products_orders(
                product_order_id INTEGER PRIMARY KEY NOT NULL,
                order_id INT NOT NULL,
                product_id INT NOT NULL,
                product_order_quantity INT NOT NULL,
                FOREIGN KEY (order_id) REFERENCES orders (order_id),
                FOREIGN KEY (product_id) REFERENCES products (product_id)
                );";
            
            return schema;
        }

        public bool insertStatment(User user, String[] statments)
        {

            String permissonRequiered = User.PERMISSONS_POSSIBLE[1];
            
            if (user.checkPermisson(permissonRequiered))
            {
                try
                {

                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

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

            var command = connection.CreateCommand();
            command.CommandText = sqlSchema;
            command.ExecuteNonQuery();
            

        }

        private String SchemeBuilder()
        {
            String schema;

            schema = @"

PRAGMA foreign_keys = ON;

DROP TABLE IF NOT EXSITS products;
DROP TABLE IF NOT EXSITS products_orders;
DROP TABLE IF NOT EXSITS orders;
DROP TABLE IF NOT EXSITS customers;
                        
CREATE TABLE IF NOT EXSITS products(
product_id INT PRIMARY KEY NOT NULL,
product_name TEXT NOT NULL,
product_cost FLOAT NOT NULL,
product_quantity INT NOT NULL
);

CREATE TABLE IF NOT EXSITS customers(
customer_id INT PRIMARY KEY NOT NULL,
customer_name TEXT NOT NULL,
customer_email TEXT NOT NULL,
customer_phone TEXT NOT NULL
);

CREATE TABLE IF NOT EXSITS orders(
order_id INT PRIMARY KEY NOT NULL,
order_cost FLOAT NOT NULL,
customer_id INT NOT NULL,
FOREIGN KEY (customer_id) REFERENCES customers (customer_id)
);

CREATE TABLE IF NOT EXSITS products_orders(
product_order_id INT PRIMARY KEY NOT NULL,
order_id INT NOT NULL,
product_id INT NOT NULL,
product_order_quantity INT NOT NULL,
FOREIGN KEY (order_id) REFERENCES orders (order_id),
FORGIGN KEY (product_id) REFERENCES products (product_id)
);";

                    


            return schema;
        }
    }
}

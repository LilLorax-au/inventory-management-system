using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Core;
using Windows.UI.Popups;


namespace inventory_management_system
{
    public class DatabaseService
    {
        private const String DATABASE_PATH = "Data Source = cme_inventory.db";

        private static DatabaseService instance;
        public SqliteConnection connection;
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

            connection.Close();

        }

        private String SchemeBuilder()
        {
            String schema;
                //DROP TABLE IF EXISTS products_orders;
                //DROP TABLE IF EXISTS orders;
                //DROP TABLE IF EXISTS products;
                //DROP TABLE IF EXISTS customers;

            schema = @"

                PRAGMA foreign_keys = ON;

                        
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

        public MessageDialog PassStatment(User user , String statments, String statmentType)
        {

            if (user.checkPermisson(statmentType))
            {
                try
                {
                    connection.Open();
                    String[] commands = statments.Split(";");
                    foreach (String cmd in commands)
                    {
                        var command = new SqliteCommand(cmd, connection);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                catch (Exception e)
                {
                    connection.Close();
                    return new MessageDialog("Input failed, Did you input all required fields?" + e);
                }
                return new MessageDialog("Input Successful");
            }
            else
            {
                return new MessageDialog("You dont have the permisson for that");
            }

        }
        public bool CheckId(String id, String table)
        {
            String statment = $"SELECT * FROM {table} WHERE {table.Substring(0, table.Length-1)}_id = '{id}';";
            int? checkValue = null;
            bool found;

            connection.Open();

            var command = new SqliteCommand(statment, connection);
            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                checkValue = reader.GetInt32(0);
            }
            if (checkValue != null)
            {
                found = true;
            }
            else
            {
                found = false;
            }

            connection.Close();
            return found;
        }

        public int GetLastID()
        {
            String statment = "SELECT last_insert_rowid();";
            connection.Open();

            var commad = new SqliteCommand(statment, connection);
            var reader = commad.ExecuteReader();


            var readerValue =  (reader.Read()) ? reader.GetInt32(0) : 0;

            connection.Close();

            return readerValue;
        }

    }
}

using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace inventory_management_system
{
    internal class DatabaseService
    {
        private const String DATABASE_PATH = "cme_inventory.db";

        private static DatabaseService instance;
        private SqliteConnection connection;



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
        }

        private void SchemeBuilder()
        {

        }
    }
}

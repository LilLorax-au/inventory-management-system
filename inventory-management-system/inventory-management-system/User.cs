using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.UI.Popups;

namespace inventory_management_system
{
    public class User
    {
        // Emulating cont for the array: is the only users
        private static readonly String[] USERS = {"root","isaac","taliah","kehlani","flora"};
        // This Needs to be changed
        private const String MASTER_PASSWORD = "password123";

        // Part of TODO
        private const String FILEPATH = "passwd.txt"; 

        public bool isLogedIn;
        public String userName;
        private String hashedPassword;

        private User(String userName)
        {
            this.isLogedIn = false;
            this.userName = userName;
        }

        public bool Check_Password(String password)
        {
           bool isPasswordRight;

           if (password == MASTER_PASSWORD)
           {
               isPasswordRight = true;
           }
           else
           {
               isPasswordRight = false;
           }
           return isPasswordRight;

        }

        public static object TryCreateUser(String userName)
        {
            if (USERS.Contains(userName.ToLower()))
            {
                return new User(userName);
            }
            return null;
        }

        // TODO create encypt for psswrds
        public static void WriteToFile()
        {


        }



    }
}

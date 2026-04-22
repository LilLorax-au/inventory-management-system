using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.UI.Popups;
using System.Text.RegularExpressions;
using Windows.Media.Playback;

namespace inventory_management_system
{
    public class User
    {
        // Emulating cont for the array: is the only users
        private static readonly String[] USERS = {"root","isaac","taliah","kehlani","flora"};
        // This Needs to be changed
        private const String MASTER_PASSWORD = "password123";
        public static readonly String[] PERMISSONS_POSSIBLE = {"select","insert","update","delete" };

        // Part of TODO
        private const String FILEPATH = "passwd.txt";

        private String[] permissons;
        public String userName;
        private String hashedPassword;


        private User(String userName)
        {
            this.userName = userName;
            this.permissons = PermissonSetter(this.userName);

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

        private String[] PermissonSetter(String userName)
        {
            String[] localPermissons;
            switch (userName)
            {
                case ("root"):
                    localPermissons = new String[4];
                    Array.Copy(PERMISSONS_POSSIBLE,localPermissons,PERMISSONS_POSSIBLE.Length);
                    break;
                case "isaac":
                    localPermissons = new String[4];
                    Array.Copy(PERMISSONS_POSSIBLE,localPermissons,PERMISSONS_POSSIBLE.Length);
                    break;
                case "taliah":
                    localPermissons = new String[2] {"select","update" };
                    break;
                case "kehlani":
                    localPermissons = new String[1] {"select" };
                    break;
                case "flora":
                    localPermissons = new string[3] { "select", "insert", "update" };
                    break;
                default:
                    localPermissons = null;
                    break;
            }

            return localPermissons;
        }

        public bool checkPermisson(String permisson)
        {
            if (this.permissons.Contains(permisson))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // TODO create encypt for psswrds
        public static void WriteToFile()
        {


        }



    }
}

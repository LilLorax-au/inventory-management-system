using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace inventory_management_system
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    
    public sealed partial class LogInPage : Page
    {
        public LogInPage()
        {
            this.InitializeComponent();
        }

        private async void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            App.localUser = (User.TryCreateUser(UserNameTextBox.Text) != null ) ? (User) User.TryCreateUser(UserNameTextBox.Text) : null;
            if (App.localUser == null)
            {
                var popUp = new MessageDialog("UserName: " + UserNameTextBox.Text + " Does not exsit");
                await popUp.ShowAsync();
                ClearAll();
            }
            else
            {
                if (App.localUser.Check_Password(PasswordTextBox.Text))
                {
                    Frame.Navigate(typeof(ProductPage));
                }
                else
                {
                    var popUp = new MessageDialog("Password Incorrect");
                    await popUp.ShowAsync();
                    PasswordTextBox.Text = "";
                    PasswordTextBox.Focus(FocusState.Programmatic);

                }

            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            UserNameTextBox.Text = "";
            PasswordTextBox.Text = "";

            UserNameTextBox.Focus(FocusState.Programmatic);
        }
    }
}

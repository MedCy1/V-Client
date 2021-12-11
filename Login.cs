using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyAuth
{
    public partial class Login : Form
    {

        /*
        * 
        * WATCH THIS VIDEO TO SETUP APPLICATION: https://youtube.com/watch?v=RfDTdiBq4_o
        * 
        */

        static string name = "VCheat"; // application name. right above the blurred text aka the secret on the licenses tab among other tabs
        static string ownerid = "YINChhxEn4"; // ownerid, found in account settings. click your profile picture on top right of dashboard and then account settings.
        static string secret = "17034aaa86e67978ea3a7a8f08f6d86554b2f17099035c5d3360a1567d9cdab4"; // app secret, the blurred text on licenses tab and other tabs
        static string version = "1.0"; // leave alone unless you've changed version on website

        /*
Optional Functions:

KeyAuthApp.webhook("lfvbBrbFhIr", "?sellerkey=CUqDqlCIgl&type=resethash");
// send secure request to webhook which is impossible to crack into. the base link set on the website is https://keyauth.com/api/seller/, which nobody except you can see, so the final request is https://keyauth.com/api/seller/?sellerkey=CUqDqlCIgl&type=resethash

// byte[] result = KeyAuthApp.download("902901"); // downloads application file
// File.WriteAllBytes("C:\\Users\\mak\\Downloads\\KeyAuth-CSHARP-Example-main (5)\\KeyAuth-CSHARP-Example-main\\ConsoleExample\\bin\\Debug\\countkeys.txt", result);

MessageBox.Show(KeyAuthApp.var("123456")); // retrieve application variable
*/

        // KeyAuthApp.register("username", "password", "key");
        //KeyAuthApp.login("username", "password"); 

        public static api KeyAuthApp = new api(name, ownerid, secret, version);

        public Login()
        {
            InitializeComponent();
        }

        private void siticoneControlBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            KeyAuthApp.init();
            if(KeyAuthApp.checkblack()) // check if hwid is blacklisted
            {
                Environment.Exit(0);
            }
        }

        private void UpgradeBtn_Click(object sender, EventArgs e)
        {
            KeyAuthApp.upgrade(username.Text, key.Text);
            MessageBox.Show("Successfully upgraded account !");
            // don't login, because they haven't authenticated. this is just to extend expiry with new key.
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            KeyAuthApp.login(username.Text,password.Text);
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void RgstrBtn_Click(object sender, EventArgs e)
        {
            KeyAuthApp.register(username.Text, password.Text, key.Text);
             Main main = new Main();
             main.Show();
             this.Hide();   
        }


        private void UsernameText_Enter(object sender, EventArgs e)
        {
            if (username.Text == "Username")
            {
                username.Text = "";
            }
        }

        private void UsernameText_Leave(object sender, EventArgs e)
        {
            if (username.Text == "")
            {
                username.Text = "Username";
            }
        }

        private void PasswordText_Enter(object sender, EventArgs e)
        {
            if (password.Text == "Password")
            {
                password.Text = "";
            }
        }

        private void PasswordText_Leave(object sender, EventArgs e)
        {
            if (password.Text == "")
            {
                password.Text = "Password";
            }
        }

        private void KeyText_Enter(object sender, EventArgs e)
        {
            if (key.Text == "Key")
            {
                key.Text = "";
            }
        }

        private void KeyText_Leave(object sender, EventArgs e)
        {
            if (key.Text == "")
            {
                key.Text = "Key";
            }
        }

        private void sendmsg_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/EqVZHkpUzM");
        }

        private void key_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

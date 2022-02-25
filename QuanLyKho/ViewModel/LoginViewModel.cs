using QuanLyKho.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public bool isLogin { get; set; }

        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }

        public string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        private string password;
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public LoginViewModel()
        {
            Password = "";
            Username = "";

            isLogin = false;
            LoginCommand = new RelayCommand<Window>(p => true, (p) =>
            {
                Login(p);
            });
            CloseCommand = new RelayCommand<Window>(p => true, (p) =>
            {
                p.Close();
            });
            PasswordChangedCommand = new RelayCommand<PasswordBox>(p => true, (p) =>
            {
                Password = p.Password;
            });
        }

        public void Login(Window p)
        {

            if (p == null)
                return;

            string encodedPass = CreateMD5(Base64Encode(Password));
            int num = DataProvider.Instance.DB.Users
                .Where(x => x.Username == Username && x.Password == encodedPass)
                .Count();
            
            if(num > 0)
            {
                isLogin = true;
                p.Close();
            }
            else
            {
                isLogin = false;
                MessageBox.Show("Username or password not correct");
            }
            
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

    }
}

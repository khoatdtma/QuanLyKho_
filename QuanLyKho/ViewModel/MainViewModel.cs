using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        // mọi thứ xử lý sẽ nằm trong này

        public ICommand LoadedWindowCommand { get; set; }
        public bool IsLoaded { get; set; } = false;
        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<object>((p) => true, (p) => { 
                IsLoaded = true;
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
            });
        }
    }
}

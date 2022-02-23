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

        public bool IsLoaded { get; set; } = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand UnitCommand { get; set; }
        public ICommand SupplierCommand { get; set; }
        public ICommand CustomerCommand { get; set; }
        public ICommand ProductCommand { get; set; }
        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                IsLoaded = true;
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
            });

            UnitCommand = new RelayCommand<object>(
                (p) => true,
                (p) =>
                {
                    UnitWindow wd = new UnitWindow();
                    wd.ShowDialog();
                });
            SupplierCommand = new RelayCommand<object>(
                (p) => true,
                (p) =>
                {
                    SupplierWindow wd = new SupplierWindow();
                    wd.ShowDialog();
                });
            CustomerCommand = new RelayCommand<object>(
            (p) => true,
            (p) =>
            {
                CustomerWindow wd = new CustomerWindow();
                wd.ShowDialog();
            });
            ProductCommand = new RelayCommand<object>(
            (p) => true,
            (p) =>
            {
                CustomerWindow wd = new CustomerWindow();
                wd.ShowDialog();
            });
        }
    }
}

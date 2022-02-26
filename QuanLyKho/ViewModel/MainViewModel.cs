using QuanLyKho.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<TonKho> _TonKhoList;
        public ObservableCollection<TonKho> TonKhoList { 
            get { return _TonKhoList; } 
            set { _TonKhoList = value;OnPropertyChanged(); } 
        }

        public bool IsLoaded { get; set; } = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand UnitCommand { get; set; }
        public ICommand SupplierCommand { get; set; }
        public ICommand CustomerCommand { get; set; }
        public ICommand ProductCommand { get; set; }
        public ICommand UserCommand { get; set; }
        public ICommand InputCommand { get; set; }
        public ICommand OutputCommand { get; set; }
        public MainViewModel()
        {
            //when window is loading
            LoadedWindowCommand = new RelayCommand<Window>((p) => true, (p) =>
            {
                IsLoaded = true;

                if (p == null)
                    return;
                p.Hide();
                
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
                var loginVM = loginWindow.DataContext as LoginViewModel;
                if (loginVM.isLogin)
                {
                    p.Show();
                    GetTonKhoList();
                }
                else
                {
                    p.Hide();
                }
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

            ProductCommand = new RelayCommand<object>((p) => true,(p) =>
            {
                ProductWindow wd = new ProductWindow();
                wd.ShowDialog();
            });

            UserCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                UserWindow wd = new UserWindow();
                wd.ShowDialog();
            });

            InputCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                InputWindow wd = new InputWindow();
                wd.ShowDialog();
            });

            OutputCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                OutputWindow wd = new OutputWindow();
                wd.ShowDialog();
            });

            int x = DataProvider.Instance.DB.Users.ToList().Count();

        }
        void GetTonKhoList()
        {
            TonKhoList = new ObservableCollection<TonKho>();

            //get all products in product table
            var products = DataProvider.Instance.DB.Products;
            int i = 1;
            foreach(var product in products)
            {
                int inputAmount = 0;
                int outputAmount = 0;

                //get input amount
                var inputList = DataProvider.Instance.DB.InputInfoes.Where((p) => p.IdProduct == product.Id);
                if (inputList != null)
                    inputAmount = (int)inputList.Sum(p=> p.Count);


                //get output amout
                var outputList = DataProvider.Instance.DB.OutputInfoes.Where((p) => p.IdProduct == product.Id);
                if (outputList != null)
                    outputAmount = (int)outputList.Sum(p => p.Count);

                //create and set Tonkho object
                TonKho tonkho = new TonKho();
                tonkho.STT = i++;
                tonkho.product = product;
                tonkho.SoLuongTon = inputAmount - outputAmount;

                //add Tonkho to TonkhoList
                TonKhoList.Add(tonkho);
            }
        }
    }
}

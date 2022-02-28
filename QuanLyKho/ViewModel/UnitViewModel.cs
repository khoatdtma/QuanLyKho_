using QuanLyKho.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    public class UnitViewModel : BaseViewModel
    {
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }

        private ObservableCollection<Unit> _List;
        public ObservableCollection<Unit> List
        {
            get { return _List; }
            set { _List = value; OnPropertyChanged(); }
        }

        private Unit _SelectedItem;
        public Unit SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.DisplayName;
                }
            }
        }

        private string _DisplayName;
        public string DisplayName
        {
            get { return _DisplayName; }
            set { _DisplayName = value; OnPropertyChanged(); }
        }

        //Constructor
        public UnitViewModel()
        {
            List = new ObservableCollection<Unit>(DataProvider.Instance.DB.Units);

            AddCommand = new RelayCommand<object>(
                //condition for adding 
                p => {
                    if (string.IsNullOrEmpty(DisplayName))
                    {
                        return false;
                    }

                    var listUnits = DataProvider.Instance.DB.Units.Where(x => x.DisplayName == DisplayName);
                    if (listUnits == null || listUnits.Count()>0)
                        return false;

                    return true;
                },

                //adding operation
                p => { 
                    Unit unit = new Unit();
                    unit.DisplayName = DisplayName;
                    
                     //save to database
                    DataProvider.Instance.DB.Units.Add(unit);
                    DataProvider.Instance.DB.SaveChanges();

                    //show in the list
                    List.Add(unit);
                });

            EditCommand = new RelayCommand<object>(
                //condition for Edit 
                p => {
                    if (string.IsNullOrEmpty(DisplayName))
                    {
                        return false;
                    }

                    var listUnits = DataProvider.Instance.DB.Units.Where(x => x.DisplayName == DisplayName);
                    if (listUnits == null || listUnits.Count() > 0)
                        return false;

                    return true;
                },

                //edit operation
                p => {
                    Unit unit = DataProvider.Instance.DB.Units.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                    unit.DisplayName = DisplayName;

                    //save to database
                    DataProvider.Instance.DB.SaveChanges();
                    SelectedItem.DisplayName = DisplayName;
                });

        }
    }
}

using MVVM_project.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM_project.MVVM.ViewModel
{
    internal class MainWindowViewModel:Notificator
    {
        public string Address {  get; set; }
        private string _name;
        public string Name
        {
            get
            {
                if (_name == null) _name = "";
                return _name;
            }
            set
            {
                if (value != null)
                    _name = value;
                OnPropertyChanged();
            }
        }
        private int _textValue;
        public int TextValue
        {
            get { return _textValue; }
            set
            {
                _textValue = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Inputdan ma'lumot kelganda ishlashi uchun hosil qilindi.
        /// </summary>
        private string _inputTextValue;

        public string InputTextValue
        {
            get { return _inputTextValue??""; }
            set
            {
                _inputTextValue = value;
                OnPropertyChanged();
                Debug.WriteLine(value);
            }
        }

        private ICommand _inputCommand;

        public ICommand InputCommand
        {
            get { return _inputCommand??new RelayCommand(param =>
            {
                MessageBox.Show(InputTextValue);
            }); }
            set { _inputCommand = value; }
        }

        public MainWindowViewModel()
        {
            TextValue = 1;
            int i = 0;
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    TextValue = i++;
                    Task.Delay(1000).Wait();
                    //Debug.WriteLine();
                }
            });
        }
    }
}

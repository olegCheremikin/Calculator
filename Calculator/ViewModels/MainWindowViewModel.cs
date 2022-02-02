using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Calculator.Models;

namespace Calculator.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private Calculators calculation;
        private string lastOperation;
        private bool newDisplayRequired = false;
        private string display;

        public string FirstNumber
        {
            get { return calculation.FirstNumber; }
            set { calculation.FirstNumber = value; }
        }

        public string SecondNumber
        {
            get { return calculation.SecondNumber; }
            set { calculation.SecondNumber = value; }
        }

        public string Operation
        {
            get { return calculation.Operation; }
            set { calculation.Operation = value; }
        }

        public string LastOperation
        {
            get { return lastOperation; }
            set { lastOperation = value; }
        }

        public string Result
        {
            get { return calculation.Result; }
        }

        public string Display
        {
            get { return display; }
            set
            {
                display = value;
                OnPropertyChanged();
            }
        }

        public ICommand NumberCommand { get; }
        private void OnNumberCommandExecute(object button)
        {
            switch (button)
            {
                case "C":
                    Display = "0";
                    FirstNumber = string.Empty;
                    SecondNumber = string.Empty;
                    Operation = string.Empty;
                    LastOperation = string.Empty;
                    break;
                case "⇐":
                    if (display.Length > 1)
                        Display = display.Substring(0, display.Length - 1);
                    else Display = "0";
                    break;

                case "+/-":
                    if (display.Contains("-") || display == "0")
                    {
                        Display = display.Remove(display.IndexOf("-"), 1);
                    }
                    else Display = "-" + display;
                    break;

                case ",":
                    if (newDisplayRequired)
                    {
                        Display = "0,";
                    }
                    else
                    {
                        if (!display.Contains(","))
                        {
                            Display = display + ",";
                        }
                    }
                    break;
                default:
                    if (display == "0" || newDisplayRequired)
                        Display = (string)button;
                    else
                        Display = display + button;
                    break;
            }
            newDisplayRequired = false; ;
        }
        private bool CanNumberCommandExecute(object button)
        {
            return true;
        }
        public ICommand OperationCommand { get; }
        private void OnOperationCommandExecute(object p)
        {
            if (FirstNumber == string.Empty || LastOperation == "=")
            {
                FirstNumber = display;
                LastOperation = (string)p;
            }
            else
            {
                SecondNumber = display;
                Operation = lastOperation;
                calculation.CalculateResult();
                LastOperation = (string)p;
                Display = Result;
                FirstNumber = display;
            }
            newDisplayRequired = true;
        }
        private bool CanOperationCommandExecute(object p)
        {
            return true;
        }
        public MainWindowViewModel()
        {
            NumberCommand = new RelayCommand(OnNumberCommandExecute, CanNumberCommandExecute);
            OperationCommand = new RelayCommand(OnOperationCommandExecute, CanOperationCommandExecute);
            calculation = new Calculators();
            display = "0";
            FirstNumber = string.Empty;
            SecondNumber = string.Empty;
            Operation = string.Empty;
            lastOperation = string.Empty;
        }
    }
}

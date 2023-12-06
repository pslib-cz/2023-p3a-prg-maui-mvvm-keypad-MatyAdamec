using MauiKeypad.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace MauiKeypad.ViewModels
{
    internal class ViewModel : INotifyPropertyChanged
    {

        private string _code;
        private EntryState _state;
        public ICommand DigitCommand { get; }
        public ICommand BackSpaceCommand { get; }
        public ICommand SubmitCommand { get; }
        public ICommand ResetCommand { get; }

        public ViewModel()
        {
            _code = string.Empty;
            DigitCommand = new Command<string>(AddDigit);
            BackSpaceCommand = new Command(RemoveLastNumber, CanRemoveNumber);
            SubmitCommand = new Command(SubmitCode, CanSubmitCode);
            ResetCommand = new Command(Reset);
        }

        public string Code
        {
            get => _code;
            set
            {
                if (_code != value)
                {
                    _code = value;
                    OnPropertyChanged(nameof(Code));
                    ((Command)BackSpaceCommand).ChangeCanExecute();
                    ((Command)SubmitCommand).ChangeCanExecute();
                }
            }
        }

        public EntryState State
        {
            get => _state;
            set
            {
                if (_state != value)
                {
                    _state = value;
                    OnPropertyChanged(nameof(State));
                }
            }
        }



        private void AddDigit(string number)
        {
            if (Code.Length < 6)
            {
                Code += number;
            }
        }
        private void RemoveLastNumber()
        {
            if (Code.Length > 0)
            {
                Code = Code.Substring(0, Code.Length - 1);
            }
        }
        private bool CanRemoveNumber()
        {
            return Code.Length > 0;
        }
        private void SubmitCode()
        {
            if (Code.Length >= 2)
            {
                State = IsValidCode(Code) ? EntryState.Success : EntryState.Denied;
            }
        }
        private bool CanSubmitCode()
        {
            return Code.Length > 2;
        }
        private void Reset()
        {
            Code = string.Empty;
            State = EntryState.InProgress;
        }
        private bool IsValidCode(string code)
        {
            if (code == "123456")
            {
                return true;
            }
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

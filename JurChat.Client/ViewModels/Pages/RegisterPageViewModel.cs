using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using DevExpress.Mvvm;
using HandyControl.Tools.Command;
using JurChat.Client.Services.Interfaces;

namespace JurChat.Client.ViewModels.Pages
{
    public class RegisterPageViewModel : BindableBase, INotifyDataErrorInfo
    {
        private readonly IUserDialogService _userDialogService;

        #region Fields

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;

                ClearAllErrors(nameof(LastName));

                if (ValidText(_lastName)) AddError(nameof(LastName), "Используйте только латиницу или киррилицу!");

                SetValue(ref _lastName, value);
            }
        }


        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;

                ClearAllErrors(nameof(FirstName));

                if (ValidText(_firstName)) AddError(nameof(FirstName), "Используйте только латиницу или киррилицу!");

                SetValue(ref _firstName, value);
            }
        }


        private string _fatherName;
        public string FatherName
        {
            get => _fatherName;
            set
            {
                _fatherName = value;

                ClearAllErrors(nameof(FatherName));

                if (ValidText(_fatherName)) AddError(nameof(FatherName), "Используйте только латиницу или киррилицу!");

                SetValue(ref _fatherName, value);
            }
        }


        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;

                ClearAllErrors(nameof(Email));

                if (ValidText(_email)) AddError(nameof(Email), "Используйте только латиницу или киррилицу!");

                SetValue(ref _email, value);
            }
        }


        private string _login;
        public string Login
        {
            get => _login;
            set
            {
                _login = value;

                ClearAllErrors(nameof(Login));

                if (ValidText(_login)) AddError(nameof(Login), "Используйте только латиницу или киррилицу!");

                SetValue(ref _login, value);
            }
        }


        private string _firstPassword;
        public string FirstPassword
        {
            get => _firstPassword;
            set
            {
                _firstPassword = value;

                if (_firstPassword == _secondPassword)
                {
                    ClearAllErrors(nameof(SecondPassword));
                    ClearAllErrors(nameof(FirstPassword));
                }
                else
                {
                    AddError(nameof(FirstPassword), "Пароли не совпадают!");
                    AddError(nameof(SecondPassword), "Пароли не совпадают!");
                }

                SetValue(ref _firstPassword, value);
            }
        }


        private string _secondPassword;
        public string SecondPassword
        {
            get => _secondPassword;
            set
            {
                _secondPassword = value;

                ClearAllErrors(nameof(SecondPassword));

                if (string.IsNullOrEmpty(_firstPassword)) AddError(nameof(SecondPassword), "Первый пароль пуст!");
                else ClearAllErrors(nameof(FirstPassword));
                
                if (_secondPassword != _firstPassword)
                {
                    AddError(nameof(SecondPassword), "Пароли не совпадают!");
                    AddError(nameof(FirstPassword), "Пароли не совпадают!");
                }

                SetValue(ref _secondPassword, value);
            }
        }

        private string _nickName;
        public string NickName
        {
            get => _nickName;
            set
            {
                _nickName = value;

                ClearAllErrors(nameof(NickName));

                if (ValidText(_nickName)) AddError(nameof(NickName), "Используйте только латиницу или киррилицу!");

                SetValue(ref _nickName, value);
            }
        }

        public string UserPhotoFilePath { get; set; }

        public string Info { get; set; }

        #endregion

        #region ERROR LOGIC

        private readonly Dictionary<string, List<string>> _propertyErrors = new();
        public IEnumerable GetErrors(string? propertyName) => _propertyErrors.GetValueOrDefault(propertyName, null);
        public bool HasErrors => _propertyErrors.Any();
        public void AddError(string propertyName, string errorMessage)
        {
            if (!_propertyErrors.ContainsKey(propertyName)) _propertyErrors.Add(propertyName, new());
            _propertyErrors[propertyName].Add(errorMessage);
            OnErrorsChanged(propertyName);
        }
        private void ClearAllErrors(string propertyName)
        {
            if (_propertyErrors.Remove(propertyName)) OnErrorsChanged(propertyName);
        }
        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new(propertyName));
        }
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        #endregion

        #region Commands

        public RelayCommand ComeToLoginPageCommand => new(delegate { _userDialogService.ShowLoginPage(); });
        public RelayCommand ChangeUserImageCommand => new(delegate { _userDialogService.ShowLoginPage(); });
        public RelayCommand RegistrationCommand => new (delegate { }, CanRegistration);

        #endregion

        public bool CanRegistration(object p)
        {
            return (!string.IsNullOrEmpty(LastName) && !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(Login) 
                    && !string.IsNullOrEmpty(FirstPassword) && !string.IsNullOrEmpty(SecondPassword) && !string.IsNullOrEmpty(NickName)) && !HasErrors;
        }
        
        private bool ValidText(string str)
        {
           return !string.IsNullOrEmpty(str) && !Regex.IsMatch(str, @"^[a-zA-Z0-9а-яА-Я ]*$");
        }

        public RegisterPageViewModel(IUserDialogService userDialogService)
        {
            _userDialogService = userDialogService;
        }
    }
}

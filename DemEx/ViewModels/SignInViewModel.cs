using DemEx.Data;
using DemEx.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DemEx.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {
        public ApplicationDbContext _db = new();

		private string _login = null!;
		private string _password = null!;

        public string Login
        {
            get { return _login; }
            set => Set(ref _login, value, nameof(Login));
        }

        public string Password
		{
			get { return _password; }
			set => Set(ref _password, value, nameof(Password));
		}

        private void SignIn()
        {
            if (Login == null || Login == string.Empty
                || Password == null || Password == string.Empty)
            {
                MessageBox.Show("Все поля должны быть заполнyы!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var user = _db.Users
                    .Include(x => x.Role)
                    .SingleOrDefault(x => x.Login == Login && x.Password == Password);
                if (user == null)
                {
                    MessageBox.Show("Неверные данные", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    var mainWindow = new MainWindow(_db, user);
                    var currentWindow = Application.Current.MainWindow;
                    mainWindow.Show();
                    Application.Current.MainWindow = mainWindow;
                    currentWindow.Close();
                }
            }
        }

        private void SignInGuest() 
        {
            var mainWindow = new MainWindow(_db, null);
            var currentWindow = Application.Current.MainWindow;
            mainWindow.Show();
            Application.Current.MainWindow = mainWindow;
            currentWindow.Close();
        }
        public ICommand SignInGuestButton => new Command(x => SignInGuest());
        public ICommand SignInButton => new Command(x => SignIn());
	}
}

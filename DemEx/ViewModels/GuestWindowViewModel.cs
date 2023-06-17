using DemEx.Data;
using DemEx.Models;
using DemEx.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DemEx.ViewModels
{
    public class GuestWindowViewModel : ViewModelBase
    {
        private List<Product> _products;

        public List<Product> Products
        {
            get { return _products; }
            set => Set(ref _products, value, nameof(Products));
        }

        public GuestWindowViewModel(ApplicationDbContext db)
        {
            Products = db.Products
                .Include(x=>x.Manufacturer)
                .ToList();
        }

        public void Back()
        {
            var signWindow = new SignIn();
            var currentWindow = Application.Current.MainWindow;
            signWindow.Show();
            Application.Current.MainWindow = signWindow;
            currentWindow.Close();
        }
        public ICommand BackButton => new Command(x => Back());
    }
}

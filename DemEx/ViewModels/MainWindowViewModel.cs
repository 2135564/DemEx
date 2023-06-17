using DemEx.Data;
using DemEx.Models;
using DemEx.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemEx.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(ApplicationDbContext db, User? user, MainWindow mainWindow) 
        {
            if (user==null)
            {
                mainWindow.FramePage.Content = new GuestPage(db);
            }
            else if (user.RoleId == 3)
            {
                mainWindow.FramePage.Content = new ClientPage();
            }
        }
    }
}

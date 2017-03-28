using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//This namespace is needed
//So that the .NET engine can recognize UserControl
using System.Windows.Controls;

namespace BookingSystem
{
    public static class Switcher
    {
        public static MainWindow pageSwitcher;

    public static void Switch(UserControl newPage)
    {
        pageSwitcher.Navigate(newPage);
    }//end of Switch (newPage)

    public static void Switch(UserControl newPage, object state)
    {
        pageSwitcher.Navigate(newPage, state);
    }//end of Switch (newPage,state)


    }//end of class
}//end of namespace



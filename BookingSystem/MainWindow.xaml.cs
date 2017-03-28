using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BookingSystem.Screens;
using System.IO;
using BookingSystem.Data;
using BookingSystem.Models;

namespace BookingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BookingSystemManager _bookingManager; //data variable is used to represent the entire file content
        public Order _currentOrder;
        public MainWindow()
        {
            InitializeComponent();
			_bookingManager = new BookingSystemManager();
            Switcher.pageSwitcher = this;
            Loaded += MainWindow_Loaded;
            Switcher.Switch(new ChooseCategoryScreen());
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = this;
        }//end of MainWindow_loaded
        public void Navigate(UserControl nextPage)
        {
            this.screenContentControl.Content = nextPage;
        }

        public void Navigate(UserControl nextPage, object state)
        {
            this.screenContentControl.Content = nextPage;
            ISwitchable s = nextPage as ISwitchable;

            if (s != null)
                s.UtilizeState(state);
            else
                throw new ArgumentException("NextPage is not ISwitchable! "
                  + nextPage.Name.ToString());
        }

        private void shoppingCartButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new ShoppingCartScreen());
        }//End of shoppingCartButton_Click
        private void chooseItemButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new ChooseItemScreen(1));
        }//End of chooseItemButton_Click

        private void chooseCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new ChooseCategoryScreen());
        }
    }
}

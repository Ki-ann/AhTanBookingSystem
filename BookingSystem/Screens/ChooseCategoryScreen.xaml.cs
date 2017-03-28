using BookingSystem.Data;
using BookingSystem.Models;
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

namespace BookingSystem.Screens
{
    /// <summary>
    /// Interaction logic for ChooseCategoryScreen.xaml
    /// </summary>
    public partial class ChooseCategoryScreen : UserControl
    {
        public ChooseCategoryScreen()
        {
            InitializeComponent();
            this.Loaded += UserControl_Loaded;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //(MainWindow) this.Parent = Means I telling the .NET engine that
            //this.Parent is actually a MainWindow class instance.
            //So that I can use with the MainWindow instance's bookingManager object.
            // The following code works to get the MainWindow instance. The following code
            // was used when I quickily whip out the code during lesson without any thoughts of refining it.
            // var bookingManager = ((MainWindow)((Grid)((ContentControl)this.Parent).Parent).Parent).bookingManager;
            //http://stackoverflow.com/questions/22856745/wpf-get-parent-window
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            BookingSystemManager bookingManager = mainWindow._bookingManager;
            foreach (Category oneCategory in bookingManager.Categories)
            {
                Button button = new Button()
                {
                    Tag = oneCategory.CategoryId
                };//end of button creation
                button.Click += new RoutedEventHandler(button_Click);
                StackPanel stackPanel = new StackPanel();
                //http://stackoverflow.com/questions/350027/setting-wpf-image-source-in-code

                TextBlock textBlock = new TextBlock()
                {
                    Text = string.Format("{0}", oneCategory.CategoryName),
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                stackPanel.Children.Add(textBlock);
                button.Content = stackPanel;
                //I anyhow trial and error. Mouse hover the Margin property gave me a lot of hints on how to set
                //margin.
                button.Margin = new System.Windows.Thickness { Top = 3, Bottom = 3, Left = 3, Right = 3 };
                this.itemButtonsUniformGrid.Children.Add(button);
            }//end of for loop
        }

        void button_Click(object sender, RoutedEventArgs e)
        {
            int collectedCategoryId = Int32.Parse(((Button)sender).Tag.ToString());
            Switcher.Switch(new ChooseItemScreen(collectedCategoryId));
        }//end of button_Click
    }
}


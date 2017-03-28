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
    /// Interaction logic for ChooseItemScreen.xaml
    /// </summary>
    public partial class ChooseItemScreen : UserControl
    {
        private int _categoryId = 0;

        public ChooseItemScreen(int inCategoryId)
        {
            InitializeComponent();
            this.Loaded += UserControl_Loaded;
            _categoryId = inCategoryId;
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
            foreach (Item oneItem in bookingManager.Items)
            {
                if (oneItem.CategoryId == _categoryId)
                {
                    Button button = new Button()
                    {
                        Tag = oneItem.ItemId
                    };//end of button creation
                    button.Click += new RoutedEventHandler(button_Click);
                    StackPanel stackPanel = new StackPanel();
                    //http://stackoverflow.com/questions/350027/setting-wpf-image-source-in-code

                    // var uriSource = new Uri("/BookingSystemCA1;component/" + data.ItemTypes[itemTypeIndex].ItemTypeImageFileName, UriKind.Relative);
                    Image image = new Image()
                    {
                        Width = 200,
                        Height = 100,
                        //http://stackoverflow.com/questions/14337071/convert-array-of-bytes-to-bitmapimage
                        Source = (BitmapSource)new ImageSourceConverter().ConvertFrom(oneItem.Photo),
                        Stretch = Stretch.UniformToFill
                    };

                    TextBlock textBlock = new TextBlock()
                    {
                        Text = string.Format("{0}", oneItem.ItemName),
                        HorizontalAlignment = HorizontalAlignment.Center
                    };
                    stackPanel.Children.Add(image);
                    stackPanel.Children.Add(textBlock);
                    button.Content = stackPanel;
                    //I anyhow trial and error. Mouse hover the Margin property gave me a lot of hints on how to set
                    //margin.
                    button.Margin = new System.Windows.Thickness { Top = 3, Bottom = 3, Left = 3, Right = 3 };
                    this.itemButtonsUniformGrid.Children.Add(button);
                }//end of for loop
            }
                
       
        }
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        void button_Click(object sender, RoutedEventArgs e)
        {
            int collectedItemId = Int32.Parse(((Button)sender).Tag.ToString());
            Button button = (Button)sender;
            Switcher.Switch(new ReserveScreen(collectedItemId));
        }//end of button_Click
    }
}

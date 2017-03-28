using BookingSystem.Models;
using BookingSystem.Data;
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
    /// Interaction logic for ShoppingCartScreen.xaml
    /// </summary>
    public partial class ShoppingCartScreen : UserControl
    {
        public ShoppingCartScreen()
        {
            //Set reference to the MainWindow instance
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            //Set reference to the _currentOrder which belongs to the MainWindow instance
            Order order = mainWindow._currentOrder;
            BookingSystemManager bookingManager = mainWindow._bookingManager;
            InitializeComponent();

            if (order == null)
            {
                TextBlock messageTextBlock = new TextBlock();
                messageTextBlock.Text = "You have not selected any bikes yet.";
                this.contentStackPanel.Children.Add(messageTextBlock);
            }else
            {

                foreach (var orderDetail in order.OrderDetails)
                {
                    string itemName = bookingManager.Items
                                   .Where(input => input.ItemId == orderDetail.ItemId)
                                   .Single()
                                   .ItemName;
                    Rental rental = bookingManager.Rentals
                        .Where(input => input.RentalId == orderDetail.RentalId)
                        .Single();
                    TextBlock itemReservationDescriptionTextBlock = new TextBlock();
                   string description = "Bike : " + itemName + "\n";
                    description += "Rental Option : " + rental.RentalType + "\n";
                    description += "Pikcup Time : " + orderDetail.PickupTimeSlot + "\n";
                    itemReservationDescriptionTextBlock.Text = description;
                    itemReservationDescriptionTextBlock.Margin = new Thickness(4, 4, 4, 4);
                    this.contentStackPanel.Children.Add(itemReservationDescriptionTextBlock);
                }//End of foreach
            }

        }
        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            //Set reference to the MainWindow instance
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            //Set reference to the _currentOrder which belongs to the MainWindow instance
            Order order = mainWindow._currentOrder;
            BookingSystemManager bookingManager = mainWindow._bookingManager;
            bookingManager.SaveOrderAndOrderDetails(order);
            MessageBox.Show("You have successfully reserved your bikes. Have a great time.");
        }//End of submitButton_Click
    }
}

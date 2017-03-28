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
    /// Interaction logic for ReserveScreen.xaml
    /// </summary>
    public partial class ReserveScreen : UserControl
    {
        int _itemId = 0;
        string _itemName = "";
        public ReserveScreen(int inItemId)
        {
            _itemId = inItemId;
            //Set reference to the MainWindow instance
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            //Set reference to the _currentOrder which belongs to the MainWindow instance
            Order order = mainWindow._currentOrder;
            InitializeComponent();

            //Set reference to the MainWindow instance's _bookingManager variable for cleaner code
            BookingSystemManager bookingManager = mainWindow._bookingManager;
            List<Rental> rentalOptionListForComboBox = bookingManager.Rentals.Where(input => input.ItemId == _itemId).ToList();
            List<object> timeSlotListForComboBox = bookingManager.TimeSlots;
            this.rentalOptionComboBoxInput.ItemsSource = rentalOptionListForComboBox;
            this.pickUpTimeComboBoxInput.ItemsSource = timeSlotListForComboBox;
            _itemName = bookingManager.Items
                .Where(input => input.ItemId == _itemId)
                .Single()
                .ItemName;
            this.itemNameTextBlock.Text = _itemName;
            
        }
     
        private void reserveDatePicker_SelectedDateChanged(object sender,
    SelectionChangedEventArgs e)
        {
            // ... Get DatePicker reference.
            var picker = sender as DatePicker;

            // ... Get nullable DateTime from SelectedDate.
            DateTime? date = picker.SelectedDate;
            if (date == null)
            {

            }
            else
            {
                
            }
        }
        private void submitButton_Click(object sender, RoutedEventArgs e)
        {

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            Order order = mainWindow._currentOrder;
            BookingSystemManager bookingManager = mainWindow._bookingManager;
            Boolean isAllUserEntryOkay = true;
            if (this.reserveDatePickerInput.SelectedDate == null)
            {
                MessageBox.Show("You need to specify the reserve date.");
                isAllUserEntryOkay = false;
            }
            if (this.pickUpTimeComboBoxInput.SelectedValue == null)
            {
                MessageBox.Show("You need to specify the pick up time slot.");
                isAllUserEntryOkay = false;
            }
            if (this.rentalOptionComboBoxInput.SelectedItem == null)
            {
                MessageBox.Show("You need to specify the rental option.");
                isAllUserEntryOkay = false;
            }

            if (isAllUserEntryOkay == true)
            {
                if (order == null)
                {
                    order = new Order();
                    order.OrderedBy = 2; //Assume that CINDY logon to place this order.
                }
                OrderDetail orderDetail = new OrderDetail();


                orderDetail.RentalId = ((Rental)this.rentalOptionComboBoxInput.SelectedItem).RentalId;
                orderDetail.PickupTimeSlot = this.pickUpTimeComboBoxInput.SelectedValue.ToString();
                orderDetail.ReserveDate = this.reserveDatePickerInput.SelectedDate;
                orderDetail.ItemId = _itemId;
                order.OrderDetails.Add(orderDetail);

                mainWindow._currentOrder = order;
                MessageBox.Show("You have added one reservation into your cart");
        }//if isAllUserEntryOkay is true
    }//End of submitButton_Click
    }//End of class

}//End of namespace

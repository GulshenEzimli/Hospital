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

namespace HospitalManagement.Views.Components
{
    /// <summary>
    /// Interaction logic for CustomDatePicker.xaml
    /// </summary>
    public partial class CustomDatePicker : UserControl
    {
        public CustomDatePicker()
        {
            InitializeComponent();
        }
        private void CalendarSelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DataContext = ((Calendar)sender).SelectedDate;
            pop.IsOpen = false;

        }

        private void WindowDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            txt.Text = DataContext != null ? ((DateTime)DataContext).ToString("dd.MM.yyyy") : "";
        }

        private void txtGotFocus(object sender, RoutedEventArgs e)
        {
            pop.IsOpen = true;
        }

        private void UserControlLostFocus(object sender, RoutedEventArgs e)
        {
            pop.IsOpen = false;
        }

        private void txtMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            pop.IsOpen = !pop.IsOpen;
        }

        private void txtTextChanged(object sender, TextChangedEventArgs e)
        {
            if (DateTime.TryParseExact(txt.Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime tempDate))
            {
                calendar.SelectedDate = tempDate;
            }
        }
    }
}

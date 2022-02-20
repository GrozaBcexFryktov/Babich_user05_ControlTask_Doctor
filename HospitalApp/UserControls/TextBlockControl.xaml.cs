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

namespace HospitalApp.UserControls
{
    /// <summary>
    /// Логика взаимодействия для TextBlockControl.xaml
    /// </summary>
    public partial class TextBlockControl : UserControl
    {
        public TextBlockControl()
        {
            InitializeComponent();
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is Entities.ScheduleAppointment scheduleAppointment)
            {
                TxtBlockPeriod.Text = $"{scheduleAppointment.StartTime.ToString(@"hh\:mm")} - " +
                   $"{scheduleAppointment.EndTime.ToString(@"hh\:mm")}";
                switch (scheduleAppointment.AppointmentType)
                {
                    case Entities.AppointmentType.Free:
                        {
                            TxtBlockPeriod.Visibility = Visibility.Visible;
                        }
                        break;
                    case Entities.AppointmentType.Busy:
                        {
                            TxtBlockPeriod.Visibility = Visibility.Hidden;
                        }
                        break;
                    case Entities.AppointmentType.DayOff:
                        {
                            TxtBlockPeriod.Visibility = Visibility.Hidden;
                        }
                        break;
                }
            }
        }
    }
}

using HospitalApp.Utils;
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

namespace HospitalAdmin.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Entities.Doctor currentDoctor;
        public MainWindow()
        {
            InitializeComponent();
            ComboSpecialization.ItemsSource = App.DataBase.Specialization.ToList();
            ComboSpecialization.SelectedIndex = 0;

        }

        private void ComboSpecialization_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = ComboSpecialization.SelectedItem as Entities.Specialization;
            if (item != null)
            {
                ComboDoctor.ItemsSource = App.DataBase.Doctor.ToList().Where(p => p.Specialization == item).ToList();
                ComboDoctor.SelectedIndex = 0;
            }
        }

        private void ComboDoctor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedDoctor = ComboDoctor.SelectedItem as Entities.Doctor;
            if (selectedDoctor != null)
            {
                currentDoctor = selectedDoctor;
                DGridShedule.ItemsSource = App.DataBase.DoctorSchedule.ToList().Where(p => p.Doctor == selectedDoctor).ToList();
            }
        }

       

        private void ComboSpecialization_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TextBox search = sender as TextBox;
            if (search != null)
            {
                ComboSpecialization.ItemsSource = App.DataBase.Specialization.Where(p => p.Name.Contains(search.Text)).ToList();
            }

        }

        private void ComboDoctor_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TextBox search = sender as TextBox;
            if (search != null)
            {
                ComboSpecialization.ItemsSource = App.DataBase.Doctor.Where(p => p.LastName.Contains(search.Text) || p.FirstName.Contains(search.Text) || p.Patronymic.Contains(search.Text)).ToList();
                ComboDoctor_SelectionChanged(sender, null);
            }
        }

      

        

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            DGridShedule.ItemsSource = App.DataBase.DoctorSchedule.ToList().Where(p => p.Doctor == currentDoctor).ToList();
        }

        
    }
}

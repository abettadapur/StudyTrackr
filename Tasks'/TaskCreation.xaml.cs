using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Collections.ObjectModel;

namespace Grades
{
    public partial class TaskCreation : PhoneApplicationPage
    {
        ObservableCollection<Type> types = new ObservableCollection<Type>();
        ObservableCollection<Priority> priorities = new ObservableCollection<Priority>();

        public TaskCreation()
        {
            InitializeComponent();
            types.Add(Type.Homework);
            types.Add(Type.Project);
            types.Add(Type.Study);
            types.Add(Type.Test);

            priorities.Add(Priority.None);
            priorities.Add(Priority.Low);
            priorities.Add(Priority.Medium);
            priorities.Add(Priority.High);
            priorities.Add(Priority.Must);
        }
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            typePicker.ItemsSource = types;
            priorityPicker.ItemsSource = priorities;
        }

        private void alarmToggle_Checked(object sender, RoutedEventArgs e)
        {
            alarmToggle.Content = "Notifications are On";
        }

        private void alarmToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            alarmToggle.Content = "Notifications are Off";
        }

       

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            DateTime time = new DateTime();
            DateTime date = new DateTime();
            time=(DateTime)timePicker.Value;
            date = (DateTime)datePicker.Value;


            Task task = new Task()
            {
                Name = nameBox.Text,
                DueDateTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0),
                TaskType = (Type)typePicker.SelectedItem,
                TaskPriority = (Priority)priorityPicker.SelectedItem,
                AssociatedClass = (Class)classPicker.SelectedItem,
                Completed = false,
                Notification = (bool)alarmToggle.IsChecked
            };

        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {

        }
        bool isListPickerClosed = true;
        private void listPicker_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ListPicker lp = (ListPicker)sender;
            lp.Open();
           

        }

    }
}
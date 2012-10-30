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
using System.IO.IsolatedStorage;
using System.IO;
using System.Collections.ObjectModel;

namespace Grades
{
    public partial class PanoramaPage1 : PhoneApplicationPage
    {
        
        public PanoramaPage1()
        {
            InitializeComponent();
        }



        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

            var settings = IsolatedStorageSettings.ApplicationSettings;

            var classes = new ObservableCollection<Class>();
            var classlist = new ObservableCollection<string>();
            if (settings.TryGetValue<ObservableCollection<Class>>("classCollection", out classes))
            {
                foreach (Class temp in classes)
                {
                    classlist.Add(temp.Name);
                }
            }
                 classlist.Add("Add A Class");
                classBox.ItemsSource = classlist;

                //ObservableCollection<Task> tasks;
                //ObservableCollection<string> tasklist = new ObservableCollection<string>();
                //if (settings.TryGetValue<ObservableCollection<Task>>("taskCollection", out tasks))
                //{
                //    foreach (Task temp in tasks)
                //    {
                //        tasklist.Add(temp.Name);
                //    }
                //}
                //tasklist.Add("See All");
                //assignmentBox.ItemsSource = tasklist;
                    

          
            
            
        }

        private void classHLButton_Click(object sender, RoutedEventArgs e)
        {
            string clickedButton = (string)((Button)sender).Content;
            if (clickedButton == "Add A Class")
            {
                
               
                
                    NavigationService.Navigate(new Uri("/ClassCreation.xaml", UriKind.Relative));
                
            }
            else
            {
                NavigationService.Navigate(new Uri("/ClassDetail.xaml?name=" + clickedButton, UriKind.Relative));
            }
        }

        private void aboutButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        //private void assignmentHLButton_Click(object sender, RoutedEventArgs e)
        //{
        //    string clickedButton = (string)((Button)sender).Content;
        //    if (clickedButton == "See All")
        //    {
        //        NavigationService.Navigate(new Uri("/TaskList.xaml", UriKind.Relative));
        //    }
        //    else
        //    {
        //        NavigationService.Navigate(new Uri("/TaskDetail.xaml?name=" + clickedButton, UriKind.Relative));
        //    }

        //}

        //private void settingsButton_Click(object sender, RoutedEventArgs e)
        //{
        //    NavigationService.Navigate(new Uri("/Grades;component/SettingsPage.xaml", UriKind.Relative));
        //}
    }
}
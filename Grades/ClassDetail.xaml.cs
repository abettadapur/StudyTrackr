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
    public partial class ClassDetail : PhoneApplicationPage
    {
        Class currentClass;
        ObservableCollection<Class> classes;

        public ClassDetail()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            string navigationFrom;
            NavigationContext.QueryString.TryGetValue("from", out navigationFrom);
            if (navigationFrom == "true")
            {
                NavigationService.RemoveBackEntry();
                NavigationService.RemoveBackEntry();
            }
            var settings = IsolatedStorageSettings.ApplicationSettings;
            
            string name = "";
            if (NavigationContext.QueryString.TryGetValue("name", out name))
            {
                PageTitle.Text = name;
            }
           
            if(settings.TryGetValue<ObservableCollection<Class>>("classCollection",out classes))
            {
                foreach(Class temp in classes)
                {
                    if(temp.Name==name)
                    {
                        currentClass=temp;
                    }
                }
          
                teacherBlock.Text = "Taught By: "+currentClass.Teacher;
               
                ObservableCollection<Category> categories = currentClass.Categories;
                pageBox.ItemsSource = categories;
                
                int totalWeight=0;
                double average=0;
                foreach (Category temp in categories)
                {
                    if (temp.Assignments.Count > 0)
                    {
                        totalWeight += temp.Weight;
                        average += temp.Average * (temp.Weight / 100.0);
                    }
                }
                if (totalWeight > 0)
                {
                    average *= (100.0 / totalWeight);
                    averageBlock.Text = "You have a " + (int)Math.Round(average) + "% in this class";
                }
                else
                {
                    averageBlock.Text = "There is no average";
                }



            }
            App ap = (App)Application.Current;
            if (ap.isTrial)
            {
                adControl1.Visibility = Visibility.Visible;
            }
            else
            {
                adControl1.Visibility = Visibility.Collapsed;
            }
            
        }

        private void categoryButton_Click(object sender, RoutedEventArgs e)
        {
            Button temp = (Button)sender;
            string clicked = temp.Content.ToString();
            string[] clickedarr = clicked.Split('-');
            NavigationService.Navigate(new Uri("/Grades;component/CategoryDetail.xaml?name="+currentClass.Name+"&category="+clickedarr[1], UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Grades;component/ClassEdit.xaml?name=" + currentClass.Name, UriKind.Relative));
        }
    
        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show("All data associated with this class, including categories and assignments, will be deleted. Continue?", "Are You Sure?", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                var settings = IsolatedStorageSettings.ApplicationSettings;
                classes.Remove(currentClass);
                

                
                NavigationService.GoBack();
            }
                
        }

       

        private void pageBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pageBox.SelectedItem = null;

        }
        }
           


        }

    

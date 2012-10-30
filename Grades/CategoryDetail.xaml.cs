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
    public partial class CategoryDetail : PhoneApplicationPage
    {
        Class currentClass;
        Category currentCategory;

        ObservableCollection<Assignments> grades = new ObservableCollection<Assignments>();


        public CategoryDetail()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            string navigationFrom;
            if (NavigationContext.QueryString.TryGetValue("navigationFrom", out navigationFrom))
            {
                NavigationService.RemoveBackEntry();
                NavigationService.RemoveBackEntry();
            }
            string name;

            string category;
            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (NavigationContext.QueryString.TryGetValue("name", out name))
            {
                ObservableCollection<Class> classes;
                if (settings.TryGetValue<ObservableCollection<Class>>("classCollection", out classes))
                {
                    foreach (Class temp in classes)
                    {
                        if (temp.Name == name)
                        {
                            currentClass = temp;
                        }
                    }
                    ObservableCollection<Category> categories = new ObservableCollection<Category>();
                    categories = currentClass.Categories;
                    if (NavigationContext.QueryString.TryGetValue("category", out category))
                        foreach (Category temp in categories)
                        {
                            if (temp.Name == category)
                            {
                                currentCategory = temp;
                                break;
                            }
                        }
                }
            }
            PageTitle.Text = currentCategory.Name;
            grades = currentCategory.Assignments;
            recomputeAverage();

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

        }
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ClassDetail.xaml?from=true&name=" + currentClass.Name, UriKind.Relative));
        }


        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Grades;component/AssignmentCreation.xaml?name=" + currentClass.Name + "&category=" + currentCategory.Name, UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            if (gradeBox.SelectedItem == null)
            {
                MessageBox.Show("Please tap on an assignment to select it first");
            }
            else
            {
                Assignments assignment = (Assignments)gradeBox.SelectedItem;

                NavigationService.Navigate(new Uri("/Grades;component/AssignmentEdit.xaml?name=" + currentClass.Name + "&category=" + currentCategory.Name + "&assignment=" + assignment.Name, UriKind.Relative));
            }
        }

        private void ApplicationBarIconButton_Click_2(object sender, EventArgs e)
        {
            if (gradeBox.SelectedItem == null)
            {
                MessageBox.Show("Please tap on an assignment to select it first");
            }
            else
            {
                var result = MessageBox.Show("This will delete the assignment. Continue?", "Are you sure?", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    Assignments temp = (Assignments)gradeBox.SelectedItem;
                    currentCategory.TotalEarned -= temp.EarnedPoints;
                    currentCategory.TotalMax -= temp.MaxPoints;
                    grades.Remove(temp);
                    recomputeAverage();
                }
            }



        }
        private void recomputeAverage()
        {
            if (grades.Count > 0)
            {

                currentCategory.Average = 100 * currentCategory.TotalEarned / currentCategory.TotalMax;
                currentCategory.AverageString = "" + (int)Math.Round(currentCategory.Average);
                averageBlock.Text = "Total Average: " + (int)Math.Round(currentCategory.Average);
                gradeBox.ItemsSource = grades;
            }
            else
            {
                currentCategory.Average = 0;
                currentCategory.AverageString = "N/A";
                averageBlock.Text = "There are no grades. Tap plus to add a grade";
            }
        }
    }
}

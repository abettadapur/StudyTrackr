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
using System.Collections.ObjectModel;

namespace Grades
{
    public partial class AssignmentEdit : PhoneApplicationPage
    {
        Class currentClass;
        Category currentCategory;
        Assignments currentAssignment;
        ObservableCollection<Class> classes;
        ObservableCollection<Assignments> grades;

        public AssignmentEdit()
        {
            InitializeComponent();
        }
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            string name;
            string category;
            string assignment;
            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (NavigationContext.QueryString.TryGetValue("name", out name))
            {
                if (settings.TryGetValue<ObservableCollection<Class>>("classCollection", out classes))
                {
                    foreach (Class temp in classes)
                    {
                        if (temp.Name == name)
                            currentClass = temp;
                    }
                    ObservableCollection<Category> categories = new ObservableCollection<Category>();
                    categories = currentClass.Categories;
                    if (NavigationContext.QueryString.TryGetValue("category", out category))
                    {
                        foreach (Category temp in categories)
                        {
                            if (temp.Name == category)
                            {
                                currentCategory = temp;
                                break;
                            }
                        }
                        if (NavigationContext.QueryString.TryGetValue("assignment", out assignment))
                        {
                            grades = currentCategory.Assignments;
                            foreach (Assignments temp in grades)
                            {
                                if (temp.Name == assignment)
                                {
                                    currentAssignment = temp;

                                    break;
                                }
                            }
                        }


                    }
                }
            }
            PageTitle.Text = currentAssignment.Name;
            nameBox.Text = currentAssignment.Name;
            dateBox.Value = currentAssignment.Date;
            earnedBox.Text = currentAssignment.EarnedPoints.ToString();
            maxBox.Text = currentAssignment.MaxPoints.ToString();
            weightBox.Text = currentAssignment.Weight.ToString();



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

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            currentCategory.TotalEarned -= currentAssignment.EarnedPoints * currentAssignment.Weight;
            currentCategory.TotalMax -= currentAssignment.MaxPoints * currentAssignment.Weight;
            try
            {
                string assgnname = nameBox.Text;
                string earned = earnedBox.Text;
                string max = maxBox.Text;
                string weight = weightBox.Text;
                if (assgnname == "" || earned == "" || earned == "" || max == "" | weight == "")
                {
                    throw new System.ArgumentNullException();
                }
                foreach (Assignments temp in grades)
                {
                    if (temp.Name == assgnname && temp.Name != currentAssignment.Name)
                    {
                        throw new System.ArgumentException();
                    }
                }

                currentAssignment.Name = assgnname;
                currentAssignment.Date = (DateTime)dateBox.Value;
                currentAssignment.DateString = currentAssignment.Date.ToShortDateString();
                currentAssignment.EarnedPoints = int.Parse(earnedBox.Text);
                currentAssignment.MaxPoints = int.Parse(maxBox.Text);
                currentAssignment.Weight = int.Parse(weightBox.Text);

                currentCategory.TotalEarned += currentAssignment.EarnedPoints * currentAssignment.Weight;
                currentCategory.TotalMax += currentAssignment.MaxPoints * currentAssignment.Weight;


                currentCategory.Assignments = grades;
                NavigationService.Navigate(new Uri("/CategoryDetail.xaml?navigationFrom=true&category=" + currentCategory.Name + "&name=" + currentClass.Name, UriKind.Relative));
            }

            catch (System.ArgumentNullException argnex)
            {
                MessageBox.Show("Every box must have a value");
            }
            catch (System.ArgumentException argex)
            {
                MessageBox.Show("There is already an assignment called " + nameBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Your data is improperly entered. Points and weights can only be whole numbers");
            }
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }


    }
}
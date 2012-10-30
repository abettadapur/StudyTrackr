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
using System.IO.IsolatedStorage;

namespace Grades
{
    public partial class AssignmentCreation : PhoneApplicationPage
    {
        Class currentClass;
        Category currentCategory;
        ObservableCollection<Assignments> grades = new ObservableCollection<Assignments>();
        public AssignmentCreation()
        {
            InitializeComponent();
        }
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
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
            try
            {
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
                grades = currentCategory.Assignments;
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
                    if (temp.Name == assgnname)
                    {
                        throw new System.ArgumentException();
                    }
                }

                Assignments newAssignment = new Assignments()
                {
                    Name = nameBox.Text,
                    Date = (DateTime)dateBox.Value,
                    EarnedPoints = int.Parse(earnedBox.Text),
                    MaxPoints = int.Parse(maxBox.Text),
                    Weight = int.Parse(weightBox.Text)
                };
                newAssignment.DateString = newAssignment.Date.ToShortDateString();
                currentCategory.TotalEarned += newAssignment.EarnedPoints*newAssignment.Weight;
                currentCategory.TotalMax += newAssignment.MaxPoints*newAssignment.Weight;
                
                grades.Add(newAssignment);
                currentCategory.Assignments = grades;
                NavigationService.GoBack();
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
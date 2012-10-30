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
    public partial class ClassCreation : PhoneApplicationPage
    {
        int totalWeight = 0;
        ObservableCollection<string> categoryStrings = new ObservableCollection<string>();
        ObservableCollection<Category> categories = new ObservableCollection<Category>();
        ObservableCollection<Class> classes = new ObservableCollection<Class>();
        public ClassCreation()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (categories.Count > 0)
                {
                    foreach (Category temp in categories)
                    {
                        if (catNameBox.Text == temp.Name)
                        {
                            throw new System.ArgumentException();
                        }
                    }
                }

                Category newCategory = new Category()
                {
                    Name = catNameBox.Text,
                    Weight = int.Parse(catPercBox.Text),
                    Assignments = new ObservableCollection<Assignments>(),
                    TotalEarned = 0,
                    TotalMax = 0,
                    Average = 0,
                    AverageString="N/A"
                };
                categories.Add(newCategory);
                categoryStrings.Add("" + newCategory.Name + "-" + newCategory.Weight + "%");
                catBox.ItemsSource = categoryStrings;
                catNameBox.Text = "";
                catPercBox.Text = "";
            }
            catch (System.ArgumentException argex)
            {
                MessageBox.Show("There is already a category named " + catNameBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Category Data. Is your percentage a whole number?");
            }

        }
        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
           
            
                string input = catBox.SelectedItem.ToString();
                categoryStrings.Remove(input);
                string[] inputarr = input.Split('-');
                Category toRemove = new Category();
                foreach (Category temp in categories)
                {
                    if (temp.Name == inputarr[0])
                    {
                        toRemove = temp;
                    }
                }
                categories.Remove(toRemove);


                catBox.ItemsSource = categoryStrings;
            
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            try
            {
                var settings = IsolatedStorageSettings.ApplicationSettings;

                //var keys = settings.Keys;
           
                if (settings.TryGetValue<ObservableCollection<Class>>("classCollection", out classes))
                {


                    foreach (Class temp1 in classes)
                    {
                        if (temp1.Name == nameBox.Text)
                        {
                            throw new System.ArgumentException();
                        }
                    }
                    if (categories.Count == 0)
                    {
                        throw new System.ArgumentNullException();
                    }
                    int totalWeight = 0;
                    foreach (Category temp in categories)
                    {
                        totalWeight += temp.Weight;
                    }
                    if (totalWeight > 100 || totalWeight < 100)
                    {
                        throw new System.ArgumentOutOfRangeException();
                    }





                    string name = nameBox.Text;
                    string teacher = teacherBox.Text;
                    if (name == "" || teacher == "")
                    {
                        throw new System.Exception();
                    }


                    Class class1 = new Class()
                    {
                        Name = nameBox.Text,
                        Teacher = teacherBox.Text,
                       
                        Categories = categories
                    };
                    classes.Add(class1);
                  

                }

                NavigationService.GoBack();

            }
            catch (ArgumentNullException argnex)
            {
                MessageBox.Show("You must have at least one category");
            }
            catch (ArgumentOutOfRangeException argoorex)
            {
                MessageBox.Show("Your weights MUST add up to 100.");
            }
            catch (ArgumentException argex)
            {
                MessageBox.Show("The name " + nameBox.Text + " cannot be used");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check your data. Make sure name and teacher have values");
            }
           

            

            


        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }

        private void catNameBox_GotFocus(object sender, RoutedEventArgs e)
        {
            catNameBox.SelectAll();
        }

        private void catPercBox_GotFocus(object sender, RoutedEventArgs e)
        {
            catPercBox.SelectAll();
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
    }
}


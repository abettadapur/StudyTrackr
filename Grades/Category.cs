using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Grades
{
    public class Category
    {
        public string NameString { get { return Weight.ToString() + "% -" + Name; }}
        public string Name { get; set; }
        public int Weight { get; set; }
        public ObservableCollection<Assignments> Assignments { get; set; }
        public double Average { get; set; }
        public string AverageString { get; set; }
        public double TotalEarned { get; set; }
        public double TotalMax { get; set; }


    }
}

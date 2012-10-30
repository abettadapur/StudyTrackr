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

namespace Grades
{
    public class Assignments
    {
        public DateTime Date { get; set; }
        public string DateString { get; set; }
        public string Name { get; set; }
        public int EarnedPoints { get; set; }
        public int MaxPoints{get; set;}
        public int Weight { get; set; }
    }
}

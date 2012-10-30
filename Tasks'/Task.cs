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
    public enum Priority { None, Low, Medium, High, Must };
    public enum Type { Homework, Study, Test, Project };
    public class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Class AssociatedClass { get; set; }
        public Priority TaskPriority { get; set; }
        public DateTime DueDateTime { get; set; }
        public bool Completed { get; set; }
        public Type TaskType { get; set; }
        public bool Notification { get; set; }
 
       
    }
}

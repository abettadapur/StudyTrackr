﻿#pragma checksum "C:\Users\Alex\Documents\Visual Studio 2010\Projects\Grades\Grades\AssignmentEdit.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "319D2A8CACA4A99BDBB3AA75F4AED431"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Advertising.Mobile.UI;
using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Grades {
    
    
    public partial class AssignmentEdit : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.TextBlock PageTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Grid infoGrid;
        
        internal System.Windows.Controls.TextBlock nameTitle;
        
        internal System.Windows.Controls.TextBox nameBox;
        
        internal System.Windows.Controls.TextBlock dateTitle;
        
        internal Microsoft.Phone.Controls.DatePicker dateBox;
        
        internal System.Windows.Controls.TextBlock gradeTitle;
        
        internal System.Windows.Controls.TextBox earnedBox;
        
        internal System.Windows.Controls.TextBlock slashBox;
        
        internal System.Windows.Controls.TextBox maxBox;
        
        internal System.Windows.Controls.TextBlock weightTitle;
        
        internal System.Windows.Controls.TextBox weightBox;
        
        internal Microsoft.Advertising.Mobile.UI.AdControl adControl1;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Grades;component/AssignmentEdit.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.PageTitle = ((System.Windows.Controls.TextBlock)(this.FindName("PageTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.infoGrid = ((System.Windows.Controls.Grid)(this.FindName("infoGrid")));
            this.nameTitle = ((System.Windows.Controls.TextBlock)(this.FindName("nameTitle")));
            this.nameBox = ((System.Windows.Controls.TextBox)(this.FindName("nameBox")));
            this.dateTitle = ((System.Windows.Controls.TextBlock)(this.FindName("dateTitle")));
            this.dateBox = ((Microsoft.Phone.Controls.DatePicker)(this.FindName("dateBox")));
            this.gradeTitle = ((System.Windows.Controls.TextBlock)(this.FindName("gradeTitle")));
            this.earnedBox = ((System.Windows.Controls.TextBox)(this.FindName("earnedBox")));
            this.slashBox = ((System.Windows.Controls.TextBlock)(this.FindName("slashBox")));
            this.maxBox = ((System.Windows.Controls.TextBox)(this.FindName("maxBox")));
            this.weightTitle = ((System.Windows.Controls.TextBlock)(this.FindName("weightTitle")));
            this.weightBox = ((System.Windows.Controls.TextBox)(this.FindName("weightBox")));
            this.adControl1 = ((Microsoft.Advertising.Mobile.UI.AdControl)(this.FindName("adControl1")));
        }
    }
}


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
using System.Collections.ObjectModel;
using System.Windows.Printing;

namespace StackOverflowSl.Answers
{
    public partial class Q9549149 : UserControl
    {
        
        public Q9549149()
        {
            InitializeComponent();
            //AddRows();
            //dataGrid1.ItemsSource = data;
        }
        
        #region Event Handlers
       
        
        private void buttonShowChildWindow_Click(object sender, RoutedEventArgs e)
        {
            ChildWindowBase cw = new ChildWindowBase();
            cw.Content = new Button() { Content = "Hello one" };
            cw.IsBusy = true;
            cw.Show();
        }

        #endregion

    }
}

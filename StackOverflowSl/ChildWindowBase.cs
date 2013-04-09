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

namespace StackOverflowSl
{
    public class ChildWindowBase : ChildWindow
    {
        public ChildWindowBase()
        {
            this.DefaultStyleKey = typeof(ChildWindowBase);
        }

        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { SetValue(IsBusyProperty, value); }
        }


        public static readonly DependencyProperty IsBusyProperty =
            DependencyProperty.Register("IsBusy", typeof(bool), typeof(ChildWindowBase), new PropertyMetadata(false));



        public string BusyContent
        {
            get { return (string)GetValue(BusyContentProperty); }
            set { SetValue(BusyContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BusyContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BusyContentProperty =
            DependencyProperty.Register("BusyContent", typeof(string), typeof(ChildWindowBase), new PropertyMetadata("Busy..."));

      
    }
}

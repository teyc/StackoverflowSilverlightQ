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
using System.ComponentModel;
using System.Windows.Data;
using System.Collections.ObjectModel;

namespace StackOverflowSl.Answers
{
    public partial class Q10858229 : UserControl
    {
        public Q10858229()
        {
            InitializeComponent();

            Test();
            this.DataContext = this;
        }

        public PagedCollectionView MyItems { get; set; }

        ObservableCollection<TestClass> items = new ObservableCollection<TestClass>();
        public void Test()
        {
            items.Add(new TestClass { Category = "A", Name = "Item 1" });
            items.Add(new TestClass { Category = "A", Name = "Item 2" });
            items.Add(new TestClass { Category = "B", Name = "Item 3" });
            items.Add(new TestClass { Category = "B", Name = "Item 4" });
            items.Add(new TestClass { Category = "C", Name = "Item 5" });
            items.Add(new TestClass { Category = "C", Name = "Item 6" });
            items.Add(new TestClass { Category = "C", Name = "Item 7" });

            MyItems = new PagedCollectionView(items);
            MyItems.GroupDescriptions.Add(new PropertyGroupDescription("Category"));

        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // The following will fail to regroup            
            //(MyItems[3] as TestClass).Category = "D";
            
            // The following works
            //MyItems.EditItem(MyItems[3]);
            //(MyItems[3] as TestClass).Category = "D";
            //MyItems.CommitEdit();

            // fails
            //(MyItems[3] as TestClass).Category = "D";
            //TestClass tmp = items[3];
            //items.RemoveAt(3);
            //items.Insert(3, tmp);
        }
    }
    
    public class TestClass : INotifyPropertyChanged
    {
        private string _category;
        public string Category
        {
            get { return _category; }
            set { _category = value; NotifyPropertyChanged("Category"); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged("Name"); }
        }

        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

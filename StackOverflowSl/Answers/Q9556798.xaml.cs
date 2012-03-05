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
using System.Windows.Markup;

namespace StackOverflowSl.Answers
{
    public partial class Q9556798 : UserControl
    {
        public Q9556798()
        {
            InitializeComponent();

            InitMyListBox();
        }

        public void InitMyListBox()
        {
            MyListBox.ItemsSource = new List<Foo>() {
                new Foo() { propertyLabel = "Bobby Brown"},
                new Foo() { propertyLabel = "Whitney Houston"},
                new Foo() { propertyLabel = "Kanye West"},
                new Foo() { propertyLabel = "Lady Gaga"},
            };
        }

        public void SetDataTemplate()
        {
            string str = @"<DataTemplate xmlns=""http://schemas.microsoft.com/client/2007"" 
                 xmlns:local=""clr-namespace:StackOverflowSl;assembly=StackOverflowSl"">
               <StackPanel>
                 <TextBlock Text=""{Binding propertyLabel}"" />
                 <TextBox Text=""{Binding RelativeSource={RelativeSource FindAncestor, AncestorType=local:MainPage}, 
                          Path=Title}"" />
               </StackPanel>
            </DataTemplate>";
            DataTemplate dt = (DataTemplate) XamlReader.Load(str);
            MyListBox.ItemTemplate = dt;
        }

        public class Foo
        {
            public string propertyLabel { get; set; }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SetDataTemplate();
        }
    }
}

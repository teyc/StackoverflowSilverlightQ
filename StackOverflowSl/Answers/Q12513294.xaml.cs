using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Collections;

namespace StackOverflowSl.Answers
{
    public partial class Q12513294 : UserControl
    {
        public Q12513294()
        {
            // Required to initialize variables
            InitializeComponent();

            InitializeMyCombo(
                Enumerable.Range(1, 99).Select(x => "Beer " + x.ToString() + " on the wall"),
                (object item, string filter) => (item as String).Contains(filter)
            );
        }

    private void InitializeMyCombo(IEnumerable items, Func<object, string, bool> filter)
    {
        MyComboBox.Loaded += (s, e) =>
        {
            // PagedCollectionView implements a filterable collection
            PagedCollectionView list = new PagedCollectionView(items);
            MyComboBox.ItemsSource = list;

            // Set the filter based on the contents of the textbox
            TextBox filterTextBox = MyComboBox.GetTemplateChild<TextBox>("FilterTextBox");
            list.Filter = new Predicate<object>(
                item => filter(item, filterTextBox.Text)
                );

            // Refresh the filter each time
            filterTextBox.TextChanged += (s2, e2) =>
            {
                list.Refresh();
                filterTextBox.Focus();
            };
        };

    }

    }

    public static class Helper
    {
        public static T GetTemplateChild<T>(this DependencyObject parent, string partName)
        {
            return (T)(VisualTreeHelper.GetChild(parent, 0) as Panel).FindName(partName);
        }
    }
}
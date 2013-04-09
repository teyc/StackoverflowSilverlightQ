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
using System.Windows.Data;
using System.Windows.Markup;

namespace StackOverflowSl.Answers
{
    public partial class Q11781859 : UserControl
    {
        public Q11781859()
        {
            InitializeComponent();
            InitGrid();
        }

        public void InitGrid()
        {
            List<RepeatedItem> items = new List<RepeatedItem>();
            for (int i = 0; i < 1500; i++)
                items.Add(new RepeatedItem());
            dataGrid1.ItemsSource = items;

            string dataTemplate = @"<sdk:DataGridTemplateColumn IsReadOnly=""False""
                       xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                       xmlns:sdk=""http://schemas.microsoft.com/winfx/2006/xaml/presentation/sdk"">
                    <sdk:DataGridTemplateColumn.CellEditingTemplate>
                        <DataTemplate>
                            <CheckBox Name=""MyCheckBox"" IsChecked=""IsSelected[{Binding .}]"" />
                        </DataTemplate>
                    </sdk:DataGridTemplateColumn.CellEditingTemplate>
                </sdk:DataGridTemplateColumn>";
            dataGrid1.Columns.Insert(0, (DataGridTemplateColumn) XamlReader.Load(dataTemplate));
            dataGrid1.LoadingRow += new EventHandler<DataGridRowEventArgs>(dataGrid1_LoadingRow);
        }

        void dataGrid1_UnloadingRow(object sender, DataGridRowEventArgs e)
        {
            throw new NotImplementedException();
        }

        void dataGrid1_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            CheckBox element = dataGrid1.Columns[0].GetCellContent(e.Row) as CheckBox;
            //element.DataContext = new SelectionWrapper();
        }

        public class SelectionWrapper
        {

        }
        public class RepeatedItem
        {
            public RepeatedItem() { this.Description = randomString(); }
            public string Description { get; set; }

            static Random rnd = new Random();
            private string randomString()
            {
                string tmp = "";
                for (int i = 0; i < 20; i++)
                {
                    tmp += "ab def ghilmnopqrst uv w xyz 01234"[rnd.Next(25)];
                }
                return tmp;
            }
        }


    }

    public class CheckboxConverter : IValueConverter
    {
        public CheckboxConverter() { }

        public CheckboxConverter(DataGrid grid)
        {
            _grid = grid;
        }

        private DataGrid _grid;

        public DataGrid DataGrid
        {
            get { return _grid; }
            set {
                if (_grid != null) _grid.LoadingRow -= LoadingRow;
                _grid = value;
                if (_grid != null) _grid.LoadingRow += LoadingRow; 
            }
        }

        public void LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.DataContext = e.Row.DataContext;
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (_grid == null) return false;
            return _grid.SelectedItems.Contains(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //_isSelected[value] = true;
            return true;
        }
    }
}

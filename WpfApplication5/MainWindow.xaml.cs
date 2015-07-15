using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;


namespace WpfApplication5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            SourceList = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                SourceList.Add(i);
            }
        }

        public int SelectedItem
        {
            get { return (int)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(int), typeof(MainWindow));

        public List<int> SourceList
        {
            get { return (List<int>)GetValue(SourceListProperty); }
            set { SetValue(SourceListProperty, value); }
        }

        public static readonly DependencyProperty SourceListProperty =
            DependencyProperty.Register("SourceList", typeof(List<int>), typeof(MainWindow));


        private void ListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            Debug.Print("ListBox_OnSelectionChanged item is : {0}", listBox.SelectedItem);
        }

        private void ListBox_OnLoaded(object sender, RoutedEventArgs e)
        {
            ListBox.SelectedItem = null;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ListBox.SelectedItem = null;
        }

    }
}

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApplication5
{
    public class ListBoxScroll : ListBox
    {
        public ListBoxScroll()
            : base()
        {
            SelectionChanged += ListBoxScroll_SelectionChanged;
            PreviewMouseDown += ListBox_OnPreviewMouseDown;
            MouseUp += ListBox_OnMouseUp;
        }

        void ListBoxScroll_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ScrollIntoView(SelectedIndex);
        }
       
        void ListBox_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                e.Handled = true;
            }
        }

        void ListBox_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                var obj = ContainerFromElement((Visual)e.OriginalSource);
                if (obj != null)
                {
                    var element = obj as FrameworkElement;
                    if (element != null)
                    {
                        var item = element as ListBoxItem;
                        if (item != null && Items.Contains(item.Content))
                        {
                            SelectedItem = item.Content;
                        }
                    }
                }
            }
        }
    }
}
using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace Fateblade.Alexandria.UI.WPF.Base.UiBehaviour
{
    public static class ListBoxBehaviours
    {
        public static IList GetCopySelectedItemsInto(DependencyObject target)
        {
            return (IList)target.GetValue(CopySelectedItemsIntoProperty);
        }

        public static void SetCopySelectedItemsInto(DependencyObject target, IList value)
        {
            target.SetValue(CopySelectedItemsIntoProperty, value);
        }

        public static readonly DependencyProperty CopySelectedItemsIntoProperty =
            DependencyProperty.RegisterAttached(
                "CopySelectedItemsInto",
                typeof(IList),
                typeof(ListBoxBehaviours),
                new PropertyMetadata(default(IList), OnCopySelectedItemsIntoChanged));


        private static void OnCopySelectedItemsIntoChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ListBox selector = (ListBox)d;
            IList listToUpdate = (IList)e.NewValue;

            listToUpdate.Clear();
            foreach (object toAdd in selector.SelectedItems)
            {
                listToUpdate.Add(toAdd);
            }

            selector.SelectionChanged += (_, args) =>
            {
                foreach (var removed in args.RemovedItems)
                {
                    listToUpdate.Remove(removed);
                }

                foreach (var added in args.AddedItems)
                {
                    listToUpdate.Add(added);
                }
            };
        }
    }
}

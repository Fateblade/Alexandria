using System.Collections;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Fateblade.Alexandria.UI.WPF.Base.UiBehaviour
{
    public static class MultiSelectorBehaviours
    {
        public static IList GetReadOnlyBindableSelectedItems(DependencyObject target)
        {
            return (IList)target.GetValue(ReadOnlyBindableSelectedItemsProperty);
        }

        public static void SetReadOnlyBindableSelectedItems(DependencyObject target, IList value)
        {
            target.SetValue(ReadOnlyBindableSelectedItemsProperty, value);
        }

        public static readonly DependencyProperty ReadOnlyBindableSelectedItemsProperty =
            DependencyProperty.RegisterAttached(
                "ReadOnlyBindableSelectedItems",
                typeof(IList),
                typeof(MultiSelectorBehaviours),
                new PropertyMetadata(default(IList), OnReadOnlyBindableSelectedItems));


        private static void OnReadOnlyBindableSelectedItems(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MultiSelector selector = (MultiSelector)d;
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

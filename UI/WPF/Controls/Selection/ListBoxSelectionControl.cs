using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Fateblade.Alexandria.UI.WPF.Controls.Selection
{
    public class ListBoxSelectionControl : Control
    {
        public bool IsSearchEnabled
        {
            get => (bool)GetValue(IsSearchEnabledProperty);
            set => SetValue(IsSearchEnabledProperty, value);
        }
        public static readonly DependencyProperty IsSearchEnabledProperty =
            DependencyProperty.Register(nameof(IsSearchEnabled), typeof(bool), typeof(ListBoxSelectionControl), new PropertyMetadata(default));

        public string SearchText
        {
            get => (string)GetValue(SearchTextProperty);
            set => SetValue(SearchTextProperty, value);
        }
        public static readonly DependencyProperty SearchTextProperty =
            DependencyProperty.Register(nameof(SearchText), typeof(string), typeof(ListBoxSelectionControl), new PropertyMetadata(default));

        public IList FilteredItemsSource
        {
            get => (IList)GetValue(FilteredItemsSourceProperty);
            set => SetValue(FilteredItemsSourceProperty, value);
        }
        public static readonly DependencyProperty FilteredItemsSourceProperty =
            DependencyProperty.Register(nameof(FilteredItemsSource), typeof(IList), typeof(ListBoxSelectionControl), new PropertyMetadata(default));

        public object SelectedItem
        {
            get => (object)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(nameof(SelectedItem), typeof(object), typeof(ListBoxSelectionControl), new PropertyMetadata(default));

        public string DisplayMemberPath
        {
            get => (string)GetValue(DisplayMemberPathProperty);
            set => SetValue(DisplayMemberPathProperty, value);
        }
        public static readonly DependencyProperty DisplayMemberPathProperty =
            DependencyProperty.Register(nameof(DisplayMemberPath), typeof(string), typeof(ListBoxSelectionControl), new PropertyMetadata(default));

        public bool CanCreateNewItem
        {
            get => (bool)GetValue(CanCreateNewItemProperty);
            set => SetValue(CanCreateNewItemProperty, value);
        }
        public static readonly DependencyProperty CanCreateNewItemProperty =
            DependencyProperty.Register(nameof(CanCreateNewItem), typeof(bool), typeof(ListBoxSelectionControl), new PropertyMetadata(default));

        public ICommand CreateNewItemCommand
        {
            get => (ICommand)GetValue(CreateNewItemCommandProperty);
            set => SetValue(CreateNewItemCommandProperty, value);
        }
        public static readonly DependencyProperty CreateNewItemCommandProperty =
            DependencyProperty.Register(nameof(CreateNewItemCommand), typeof(ICommand), typeof(ListBoxSelectionControl), new PropertyMetadata(default));

        public bool CanEditSelectedItem
        {
            get => (bool)GetValue(CanEditSelectedItemProperty);
            set => SetValue(CanEditSelectedItemProperty, value);
        }
        public static readonly DependencyProperty CanEditSelectedItemProperty =
            DependencyProperty.Register(nameof(CanEditSelectedItem), typeof(bool), typeof(ListBoxSelectionControl), new PropertyMetadata(default));

        public ICommand EditSelectedItemCommand
        {
            get => (ICommand)GetValue(EditSelectedItemCommandProperty);
            set => SetValue(EditSelectedItemCommandProperty, value);
        }
        public static readonly DependencyProperty EditSelectedItemCommandProperty =
            DependencyProperty.Register(nameof(EditSelectedItemCommand), typeof(ICommand), typeof(ListBoxSelectionControl), new PropertyMetadata(default));

        public bool CanDeleteSelectedItem
        {
            get => (bool)GetValue(CanDeleteSelectedItemProperty);
            set => SetValue(CanDeleteSelectedItemProperty, value);
        }
        public static readonly DependencyProperty CanDeleteSelectedItemProperty =
            DependencyProperty.Register(nameof(CanDeleteSelectedItem), typeof(bool), typeof(ListBoxSelectionControl), new PropertyMetadata(default));

        public ICommand DeleteSelectedItemCommand
        {
            get => (ICommand)GetValue(DeleteSelectedItemCommandProperty);
            set => SetValue(DeleteSelectedItemCommandProperty, value);
        }
        public static readonly DependencyProperty DeleteSelectedItemCommandProperty =
            DependencyProperty.Register(nameof(DeleteSelectedItemCommand), typeof(ICommand), typeof(ListBoxSelectionControl), new PropertyMetadata(default));

    }
}

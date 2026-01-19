using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Fateblade.Alexandria.UI.WPF.Controls.Selection
{
    /// <summary>
    /// Interaction logic for CharacterSelectionControl.xaml
    /// </summary>
    public partial class ComboBoxSelectionControl : UserControl
    {
        public static readonly DependencyProperty SelectableElementsProperty = DependencyProperty.Register(
            nameof(SelectableElements), typeof(IEnumerable), typeof(ComboBoxSelectionControl), new PropertyMetadata(default(ICollection)));
        public IEnumerable SelectableElements
        {
            get => (IEnumerable)GetValue(SelectableElementsProperty);
            set => SetValue(SelectableElementsProperty, value);
        }

        public static readonly DependencyProperty SelectedElementProperty = DependencyProperty.Register(
            nameof(SelectedElement), typeof(object), typeof(ComboBoxSelectionControl), new PropertyMetadata(default));
        public object SelectedElement
        {
            get => (object)GetValue(SelectedElementProperty);
            set => SetValue(SelectedElementProperty, value);
        }

        public static readonly DependencyProperty AllowCreationProperty = DependencyProperty.Register(
            nameof(AllowCreation), typeof(bool), typeof(ComboBoxSelectionControl), new PropertyMetadata(default(bool)));
        public bool AllowCreation
        {
            get => (bool)GetValue(AllowCreationProperty);
            set => SetValue(AllowCreationProperty, value);
        }

        public static readonly DependencyProperty AllowDeletionProperty = DependencyProperty.Register(
            nameof(AllowDeletion), typeof(bool), typeof(ComboBoxSelectionControl), new PropertyMetadata(default(bool)));
        public bool AllowDeletion
        {
            get => (bool)GetValue(AllowDeletionProperty);
            set => SetValue(AllowDeletionProperty, value);
        }

        public static readonly DependencyProperty CreateNewElementCommandProperty = DependencyProperty.Register(
            nameof(CreateNewElementCommand), typeof(ICommand), typeof(ComboBoxSelectionControl), new PropertyMetadata(default(ICommand)));
        public ICommand CreateNewElementCommand
        {
            get => (ICommand)GetValue(CreateNewElementCommandProperty);
            set => SetValue(CreateNewElementCommandProperty, value);
        }

        public static readonly DependencyProperty DeleteCurrentElementCommandProperty = DependencyProperty.Register(
            nameof(DeleteCurrentElementCommand), typeof(ICommand), typeof(ComboBoxSelectionControl), new PropertyMetadata(default(ICommand)));

        public ICommand DeleteCurrentElementCommand
        {
            get => (ICommand)GetValue(DeleteCurrentElementCommandProperty);
            set => SetValue(DeleteCurrentElementCommandProperty, value);
        }

        public ComboBoxSelectionControl()
        {
            InitializeComponent();
        }
    }
}

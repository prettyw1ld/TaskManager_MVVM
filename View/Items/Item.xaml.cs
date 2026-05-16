using System.Windows;
using System.Windows.Controls;
using TaskManager_Khodzhiev.Models;
using TaskManager_Khodzhiev.ViewModels;

namespace TaskManager_Khodzhiev.View.Items
{
    /// <summary>
    /// Interaction logic for Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        public Item()
        {
            InitializeComponent();
            Loaded += Item_Loaded;
        }

        private void Item_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            if (window?.DataContext is VM_Pages vm)
            {
                cbPriority.ItemsSource = vm.vm_tasks.Priorities;
            }
        }
    }
}

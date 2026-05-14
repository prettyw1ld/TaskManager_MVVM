using System.Windows.Controls;
using TaskManager_Khodzhiev.Classes;

namespace TaskManager_Khodzhiev.ViewModels
{
    class VM_Pages : Notification
    {
	    public VM_Tasks vm_tasks { get; } = new();
        public VM_Pages()
        {
            MainWindow.init.frame.Navigate(new View.Main(vm_tasks));
        }
        public RelayCommand OnClose
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    MainWindow.init.Close();
                });
            }
        }
    }
}

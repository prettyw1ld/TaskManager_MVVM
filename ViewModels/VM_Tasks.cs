using System.Collections.ObjectModel;
using TaskManager_Khodzhiev.Classes;
using TaskManager_Khodzhiev.Models;

namespace TaskManager_Khodzhiev.ViewModels
{
    class VM_Tasks : Notification
    {
        public TasksContext tasksContext = new();
        public ObservableCollection<Tasks> Tasks { get; set; }
        public VM_Tasks() => Tasks = new ObservableCollection<Tasks>(tasksContext.Tasks.OrderBy(x => x.Done));

        public RelayCommand OnAddTask
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Tasks newTask = new()
                    {
                        DateExecute = DateTime.Now
                    };
                    Tasks.Add(newTask);
                    tasksContext.Tasks.Add(newTask);
                    tasksContext.SaveChanges();
                });
            }
        }
    }
}

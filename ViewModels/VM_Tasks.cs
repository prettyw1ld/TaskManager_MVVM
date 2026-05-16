using System.Collections.ObjectModel;
using TaskManager_Khodzhiev.Classes;
using TaskManager_Khodzhiev.Context;
using TaskManager_Khodzhiev.Models;
using TaskManager_Khodzhiev.View;

namespace TaskManager_Khodzhiev.ViewModels
{
    class VM_Tasks : Notification
    {
        public TasksContext tasksContext = new();

        public PrioritiesContext prioritiesContext = new();

        private ObservableCollection<Priorities> priorities;
        public ObservableCollection<Priorities> Priorities
        {
            get { return priorities; }
            set { priorities = value; }
        }


        private ObservableCollection<Tasks> tasks;
        public ObservableCollection<Tasks> Tasks 
        {
            get
            {
                if (string.IsNullOrEmpty(SearchText))
                {
                    return tasks;
                }
                else
                {
                    return new ObservableCollection<Tasks>(tasks.Where(x => x.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase)));
                }
            }

            set => tasks = value;
        }
        public VM_Tasks()
        {
            if (tasksContext.Tasks != null)
            {
                Tasks = new ObservableCollection<Tasks>(tasksContext.Tasks.OrderBy(x => x.Done));
            }
            if (prioritiesContext.Priorities != null)
            {
                Priorities = new ObservableCollection<Priorities>(prioritiesContext.Priorities);
            }
        }

        bool sorting = false;
        private RelayCommand? sort;
        public RelayCommand Sort
        {
            get
            {
                return sort ??= new RelayCommand(obj =>
                {
                    sorting = !sorting;
                    if (sorting == false)
                    {
                        Tasks = new ObservableCollection<Tasks>(tasksContext.Tasks.OrderByDescending(x => x.Priority));
                        OnPropertyChanged("Tasks");
                    }
                    else
                        Tasks = new ObservableCollection<Tasks>(tasksContext.Tasks.OrderBy(x => x.Priority));
                        OnPropertyChanged("Tasks");
                });
            }
        }


        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged("Tasks");
            }
        }

        public RelayCommand OnAddTask
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Tasks newTask = new()
                    {
                        Id = tasksContext.Tasks.Any() ? tasksContext.Tasks.Max(x => x.Id) + 1 : 1,
                        Name = "Change me",
                        Priority = 3,
                        Comment = "Change me",
                        Done = false,
                        IsEnable = false,
                        DateExecute = DateTime.Now + TimeSpan.FromDays(1),
                    };
                    Tasks.Add(newTask);
                    tasksContext.Tasks.Add(newTask);
                    tasksContext.SaveChanges();
                });
            }
        }
    }
}

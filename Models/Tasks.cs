using System.Text.RegularExpressions;
using System.Windows;
using TaskManager_Khodzhiev.Classes;
using Schema = System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager_Khodzhiev.Models
{
	public class Tasks : Notification
	{
		public int Id { get; set; }

		private string name;
		public string Name
		{
			get { return name; }
			set
			{
				Match match = Regex.Match(value, "^.{1,50}$");
				if (!match.Success)
				{
					MessageBox.Show("Name must be between 1 and 50 characters long.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
				}
				else
				{
					name = value;
					OnPropertyChanged("Name");
				}
			}
		}

		private string priority;
		public string Priority
		{
			get { return priority; }
			set
			{
				Match match = Regex.Match(value, "^.{1,30}$");
				if (!match.Success)
				{
					MessageBox.Show("Priority must be between 1 and 30 characters long.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
				}
				else
				{
					priority = value;
					OnPropertyChanged("Priority");
				}
			}
		}

		private DateTime dateExecute;

		public DateTime DateExecute
		{
			get { return dateExecute; }
			set
			{
				if (value < DateTime.Now)
				{
					MessageBox.Show("Execution date cannot be in the past.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
				}
				else
					dateExecute = value; OnPropertyChanged("DateExecute");
			}
		}

		private string comment;
		public string Comment
		{
			get { return comment; }
			set
			{
				Match match = Regex.Match(value, "^.{1,1000}$");
				if (!match.Success)
				{
					MessageBox.Show("Comment must be between 1 and 1000 characters long.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
				}
				else
				{
					comment = value;
					OnPropertyChanged("Comment");
				}
			}
		}

		public bool done;
		public bool Done
		{
			get { return done; }
			set
			{
				done = value;
				OnPropertyChanged("Done"); OnPropertyChanged("IsDoneText");
            }
		}

		[Schema.NotMapped]
		private bool isEnable;
		[Schema.NotMapped]
		public bool IsEnable
		{
            get { return isEnable; }
			set
			{
				isEnable = value;
				OnPropertyChanged("IsEnable"); OnPropertyChanged("IsEnableText");
            }
        }

		[Schema.NotMapped]
		public string IsEnableText
		{
			get
			{
				if (IsEnable) return "Сохранить";
				else return "Изменить";
			}
		}

        [Schema.NotMapped]
		public string IsDoneText
        {
            get
            {
                if (Done) return "Выполнено";
                else return "Не выполнено";
            }
        }

		[Schema.NotMapped]
		public RelayCommand OnEdit
		{
			get
			{
				return new RelayCommand(obj =>
				{
					IsEnable = !IsEnable;
					if (!IsEnable)
						(MainWindow.init.DataContext as ViewModels.VM_Pages).SaveChanges();
				});
			}
		}

        [Schema.NotMapped]
        public RelayCommand OnDelete
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if(MessageBox.Show("Are you sure you want to delete this task?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_tasks.Tasks.Remove(this);
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_tasks.tasksContext.Remove(this);
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_tasks.tasksContext.SaveChanges();
                    }
                });
            }
        }

        [Schema.NotMapped]
        public RelayCommand OnDone
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Done = !Done;
                });
            }
        }
    }
}

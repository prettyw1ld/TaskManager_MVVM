using System.Text.RegularExpressions;
using System.Windows;
using TaskManager_Khodzhiev.Classes;

namespace TaskManager_Khodzhiev.Models
{
    public class Priorities : Notification
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

    }
}

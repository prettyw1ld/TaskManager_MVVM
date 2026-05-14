using System.Collections.Specialized;
using System.ComponentModel;

namespace TaskManager_Khodzhiev.Classes
{
    public class Notification : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using System.Windows.Controls;

namespace TaskManager_Khodzhiev.View
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main(object Context)
        {
            InitializeComponent();
            DataContext = Context;
        }
    }
}

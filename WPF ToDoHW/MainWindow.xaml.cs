using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf_5.src;
using System.ComponentModel;

namespace Wpf_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        public List<ToDo> todoList;
        public List<ToDo> TodoList
        {
            get { return todoList; }
            set
            {
                todoList = value;
                OnPropertyChanged();
            }
        }
        public int CountDone { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
            TodoList = new List<ToDo>();

            TodoList = new List<ToDo>();
            TodoList.Add(new ToDo("Дело 1", "Описание", new DateTime(2024, 01, 10)));
            TodoList.Add(new ToDo("Дело 2", "Описание2", new DateTime(2024, 02, 10)));
            TodoList.Add(new ToDo("Дело 3", "Описание3", new DateTime(2024, 03, 10)));

            ListToDo.ItemsSource = TodoList;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged()
        {
            CountDone = TodoList.Where(e => e.Done == true).ToList().Count;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TodoList"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CountDone"));
        }

        private void DeleteJob(object sender, RoutedEventArgs e)
        {
            TodoList.Remove(ListToDo.SelectedItem as ToDo);
            ListToDo.ItemsSource = null;
            ListToDo.ItemsSource = TodoList;
            OnPropertyChanged();
        }
        private void OpenWindow(object sender, RoutedEventArgs e)
        {
            NewToDo newToDo = new NewToDo();
            newToDo.Owner = this;
            newToDo.Show();
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (ListToDo.SelectedItem != null)
            {
                (ListToDo.SelectedItem as ToDo).Done = true;
            }
            OnPropertyChanged();
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (ListToDo.SelectedItem != null)
            {
                (ListToDo.SelectedItem as ToDo).Done = false;
            }
            OnPropertyChanged();
        }
       
    }
}
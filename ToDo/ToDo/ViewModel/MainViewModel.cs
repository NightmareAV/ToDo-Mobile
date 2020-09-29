using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ToDo.ViewModel
{
    class MainViewModel : BindableObject
    {
        public ObservableCollection<Task> Tasks { get; set; }

        public MainViewModel()
        {
            Tasks = new ObservableCollection<Task>()
            {   
                new Task { Text = "privet", Check = true},
                new Task { Text = "123sad", Check = true},
                new Task { Text = "dasd", Check = false},
                new Task { Text = "pri4141vet", Check = false},
                new Task { Text = "priasdascvet", Check = false},
                new Task { Text = "asdasdasdasdasdasdasdasdasdas", Check = true}
            };
        }
        private Task _selectedTask;
        private string _text;
        public Task SelectedTask
        {
            get { return _selectedTask; }
            set { _selectedTask = value; OnPropertyChanged(nameof(SelectedTask)); }
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; OnPropertyChanged(nameof(Text)); }
        }
        private ICommand _addTask;
        private ICommand _deleteTask;
        public ICommand AddTask
        {
            get { return _addTask ?? (_addTask = new Command<string>(AddTaskExecute, AddTaskCanExecute)); }
        }
        private void AddTaskExecute(string str)
        {
            Task task = new Task();
            task.Text = str;
            task.Check = false;
            Tasks.Add(task);
            Text = "";
        }
        private bool AddTaskCanExecute(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            else
                return true;
        }

        public ICommand DeleteTask
        {
            get { return _deleteTask ?? (_deleteTask = new Command<Task>(DeleteTaskExecute, DeleteTaskCanExecute)); }
        }
        private void DeleteTaskExecute(Task task)
        {
            Tasks.Remove(task);
        }
        private bool DeleteTaskCanExecute(Task task)
        {
            if (task == null)
                return false;
            else
                return true;
        }

    }
}

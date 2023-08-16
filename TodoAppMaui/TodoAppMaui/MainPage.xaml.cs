using System.Collections.ObjectModel;
using TodoAppMaui.Services;
using TodoAppMaui.Shared;

namespace TodoAppMaui
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            UpdateListViews();
        }

        private void UpdateListViews()
        {
            TasksListView.ItemsSource = Repository.GetAllTasks();
        }
        private void OnAddTaskClicked(object sender, EventArgs e)
        {
            string newTaskTitle = TaskEntry.Text;
            if (!string.IsNullOrWhiteSpace(newTaskTitle))
            {
                Repository.CreateTask(new TaskItem { TaskName = newTaskTitle });
                TaskEntry.Text = string.Empty;
                UpdateListViews();
            }
        }
        
        //Update method to update task
        private async void OnUpdateClicked(object sender, EventArgs e)
        {
            var task = (TaskItem)((Button)sender).CommandParameter;

            var updatedValue = await DisplayPromptAsync("Update Task", "Enter the updated task value:", initialValue: task.TaskName);

            if (!string.IsNullOrEmpty(updatedValue))
            {
                Repository.UpdateTask(new TaskItem { Id = task.Id, TaskName = updatedValue });
                UpdateListViews();
            }
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            var task = (TaskItem)((Button)sender).CommandParameter;
            if (task != null)
            {
                Repository.DeleteTask(task);
                UpdateListViews();
            }
        }

    }
}

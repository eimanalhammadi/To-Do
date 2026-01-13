using MauiTodoSqlite.Data;
using MauiTodoSqlite.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiTodoSqlite.ViewModels
{
    public class MainViewModel
    {
        private readonly TaskRepository _repo;
        public ObservableCollection<TodoTask> Tasks { get; } = new();
        public ICommand NewTaskCommand { get;}
        public MainViewModel(TaskRepository repo)
        {
            _repo = repo;
            NewTaskCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync(nameof(Pages.NewTaskPage));
            });

        }
        public async Task LoadAsync()
        {
            Tasks.Clear();
            var items= await _repo.GetAllAsync();
            foreach (var item in items)
                Tasks.Add(item);
        }
        public async Task DeleteWithConfirmAsync(TodoTask task)
        {
            bool confirm = await Shell.Current.DisplayAlert(
               "Delete",
               $"Are you sure you want to delete '{task.Title}'?",
               "Yes",
               "Cancel");
            if (!confirm) return;
            await _repo.DeleteAsync(task);
            Tasks.Remove(task);
        }
    }


}

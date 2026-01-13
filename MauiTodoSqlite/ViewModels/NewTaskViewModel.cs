using MauiTodoSqlite.Data;
using MauiTodoSqlite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiTodoSqlite.ViewModels
{
    public class NewTaskViewModel
    {
        private readonly TaskRepository _repo;

        public string Title { get; set; } = "";
        public StatusTask Status { get; set; } =StatusTask.Pending;

        public ICommand SaveCommand { get;}

        public NewTaskViewModel(TaskRepository repo)
        {
            _repo = repo;
            SaveCommand = new Command(async () =>
            {
                if (string.IsNullOrWhiteSpace(Title))
                {
                    await Shell.Current.DisplayAlert(
                        "Error", 
                        "Title is required",
                        "OK");
                    return;
                }
                await _repo.AddAsync(new TodoTask
                {
                    Title = Title,
                    Status = Status,

                });
                await Shell.Current.GoToAsync("..");


            });
        }
    }
}

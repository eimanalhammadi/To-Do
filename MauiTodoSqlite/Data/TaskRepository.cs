using MauiTodoSqlite.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTodoSqlite.Data
{
    public class TaskRepository
    {
        private SQLiteAsyncConnection? _db;
        private async Task EnsureDbAsync()
        {
            if (_db == null) return;
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "task.db3");
            _db = new SQLiteAsyncConnection(dbPath);
            await _db.CreateTableAsync<TodoTask>();
        }
        public async Task<List<TodoTask>> GetAllAsync()
        {
            await EnsureDbAsync();
            return await _db.Table<TodoTask>()
                .OrderByDescending(t => t.Id)
                .ToListAsync();
        }
        public async Task AddAsync(TodoTask task)
        {
            await EnsureDbAsync();
            await _db.InsertAsync(task);
        }
        public async Task DeleteAsync(TodoTask task)
        {
            await EnsureDbAsync();
            await _db.DeleteAsync(task);
        }
    }
}

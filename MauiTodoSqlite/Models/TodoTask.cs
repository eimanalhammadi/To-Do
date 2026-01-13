using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTodoSqlite.Models
{
    public class TodoTask
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }= string.Empty;
        public StatusTask Status { get; set; } = StatusTask.Pending;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}

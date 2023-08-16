using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMaui.Database;
using TodoAppMaui.Shared;

namespace TodoAppMaui.Services
{
    public class Repository
    {
        public static void CreateTask(TaskItem taskItem)
        {
            using var db = new AppDbContext();
            db.TaskItems.Add(taskItem);
            db.SaveChanges();
        }

        public static ObservableCollection<TaskItem> GetAllTasks()
        {
            using var db = new AppDbContext();
            //fix the below line
            return new ObservableCollection<TaskItem>(db.TaskItems.ToList());
        }

        public static void UpdateTask(TaskItem taskItem)
        {
            using var db = new AppDbContext();
            db.TaskItems.Update(taskItem);
            db.SaveChanges();
        }

        public static void DeleteTask(TaskItem taskItem)
        {
            using var db = new AppDbContext();
            db.TaskItems.Remove(taskItem);
            db.SaveChanges();
        }
    }
}

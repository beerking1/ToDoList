using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ToDoList2
{
    internal class Program
    {
        public static class ToDoListProgram
        {
            static void Main(string[] args)
            {
                ToDoList();
                Console.ReadKey();
            }
        }
        public static void ToDoList()
        {
            Console.WriteLine("Pro zobrazení nápovědy stiskni H, pro ukončení napiš exit");
            List<TaskItem> tasks = new List<TaskItem>();
            string choice = string.Empty;
            bool run = true;

            while (run)
            {
                Console.WriteLine("Zadej úkol, který chceš udělat: ");
                string taskDescription = Console.ReadLine();

                Console.WriteLine("Je úkol již splněný? (ANO/NE)");
                string isCompletedInput = Console.ReadLine();
                bool isCompleted = isCompletedInput.Equals("ANO", StringComparison.OrdinalIgnoreCase);

                TaskItem newTask = new TaskItem(taskDescription, isCompleted);
                tasks.Add(newTask);

                Console.WriteLine("Chceš zadat další úkol? (ANO/NE)");
                choice = Console.ReadLine();
                if (!choice.Equals("ANO", StringComparison.OrdinalIgnoreCase))
                {
                    run = false;
                    ShowTasksAndCompletedTasks(tasks);
                }
            }
        }

        public static void ShowTasksAndCompletedTasks(List<TaskItem> tasks)
        {
            Console.WriteLine("Všechny úkoly:");
            foreach (TaskItem task in tasks)
            {
                Console.WriteLine($"{(task.IsCompleted ? "[SPLNĚNÝ] " : "[NESPLNĚNÝ] ")}{task.Description}");
            }
        }
    }

    public class TaskItem
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public TaskItem(string description, bool isCompleted)
        {
            Description = description;
            IsCompleted = isCompleted;
        }
    }

}

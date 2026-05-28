// Program.cs
namespace TaskManagerCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();

                Console.WriteLine("========================================");
                Console.WriteLine("    WELCOME TO DATABASE TASK MANAGER    ");
                Console.WriteLine("========================================");

                while (true)
                {
                    ShowMenu();
                    string choice = Console.ReadLine()?.Trim() ?? "";

                    switch (choice)
                    {
                        case "1":
                            AddTask(context);
                            break;

                        case "2":
                            ListTasks(context, "all");
                            break;

                        case "3":
                            ListTasks(context, "pending");
                            break;

                        case "4":
                            ListTasks(context, "completed");
                            break;

                        case "5":
                            MarkTaskAsDone(context);
                            break;

                        case "6":
                            DeleteTask(context);
                            break;

                        case "0":
                            Console.WriteLine("\nGoodbye! Have a productive day!");
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please enter 0-6.");
                            break;
                    }
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("\n--- Main Menu ---");
            Console.WriteLine("1. Add New Task");
            Console.WriteLine("2. View All Tasks");
            Console.WriteLine("3. View Pending Tasks Only (LINQ)");
            Console.WriteLine("4. View Completed Tasks Only (LINQ)");
            Console.WriteLine("5. Mark Task as Completed");
            Console.WriteLine("6. Delete a Task");
            Console.WriteLine("0. Exit Application");
            Console.Write("Enter choice: ");
        }

        static void AddTask(AppDbContext context)
        {
            Console.Write("\nEnter task title: ");
            string title = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrEmpty(title))
            {
                Console.WriteLine("Task title cannot be empty!");
                return;
            }

            var task = new TodoTask { Title = title };
            context.TodoTasks.Add(task);
            context.SaveChanges();

            Console.WriteLine("Task added successfully to database!");
        }

        static void ListTasks(AppDbContext context, string filter = "all")
        {
            var query = context.TodoTasks.AsQueryable();

            if (filter == "pending")
            {
                query = query.Where(t => !t.IsCompleted);
            }
            else if (filter == "completed")
            {
                query = query.Where(t => t.IsCompleted);
            }

            var tasks = query.ToList();

            if (!tasks.Any())
            {
                Console.WriteLine("\nNo tasks found.");
                return;
            }

            if (filter == "all")
                Console.WriteLine("\n--- All Tasks ---");
            else if (filter == "pending")
                Console.WriteLine("\n--- Pending Tasks ---");
            else if (filter == "completed")
                Console.WriteLine("\n--- Completed Tasks ---");

            foreach (var task in tasks)
            {
                string status = task.IsCompleted ? "[X] Done" : "[ ] Pending";

                Console.WriteLine(
                    $"ID: {task.Id} | {status} | Title: {task.Title} ({task.CreatedAt:yyyy-MM-dd HH:mm:ss})"
                );
            }
        }

        static void MarkTaskAsDone(AppDbContext context)
        {
            Console.Write("\nEnter the Task ID to mark as completed: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var task = context.TodoTasks.FirstOrDefault(t => t.Id == id);

                if (task != null)
                {
                    task.IsCompleted = true;
                    context.SaveChanges();
                    Console.WriteLine($"Task '{task.Title}' marked as completed!");
                }
                else
                {
                    Console.WriteLine("Task ID not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID input.");
            }
        }

        static void DeleteTask(AppDbContext context)
        {
            Console.Write("\nEnter the Task ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var task = context.TodoTasks.FirstOrDefault(t => t.Id == id);

                if (task != null)
                {
                    context.TodoTasks.Remove(task);
                    context.SaveChanges();
                    Console.WriteLine("Task deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Task ID not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID input.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SimpleScanning
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskClass taskClass = new TaskClass();
            Navigation nav = new Navigation();

            //taskClass.SaveTasks();
            taskClass.OpenTasks();
            taskClass.PrintTasks();
            //nav.PrintTasks(0, taskClass.TaskList);
            //MessagesClass.DisplayMenu();
            nav.Arrow(taskClass.TaskList);




        }
    }
    [XmlRoot("ArrayOfMyTask")]
    class TaskClass
    {
        List<MyTask> taskList = new List<MyTask>();

        [XmlElement("MyTask")]
        public List<MyTask> TaskList
        {
            get { return taskList; }
            set { taskList = value; }
        }

        public void PrintTasks()
        {
            for (int i = 0; i < taskList.Count; i++)
            {
                if (taskList[i].Status == 1)
                {
                    Console.SetCursorPosition(0, i);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    //Console.Write("\r" + new string(' ', Convert.ToString(taskList[i].TaskName).Length) + "\r"); // Clear current line
                    Console.Write(taskList[i].TaskName);
                }
                else
                {
                    Console.SetCursorPosition(0, i);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    //Console.Write("\r" + new string(' ', Convert.ToString(taskList[i].TaskName).Length) + "\r"); // Clear current line
                    Console.Write(taskList[i].TaskName);
                }

            }

        }

        public void SaveTasks()
        {
            XmlSerializer serializer = new XmlSerializer(taskList.GetType());
            using (StreamWriter writer = new StreamWriter(@"tasks.xml"))
            {
                serializer.Serialize(writer, taskList);
                //Console.WriteLine("Объект был сериализирован");
            }
        }

        public void OpenTasks()
        {
            XmlSerializer serializer = new XmlSerializer(taskList.GetType());
            using (StreamReader reader = new StreamReader(@"tasks.xml"))
            {
                TaskList = (List<MyTask>)serializer.Deserialize(reader);
            }
        }

    }

    class MessagesClass
    {


    }

    class Navigation
    {
        public void Arrow(List<MyTask> taskList)
        {
            ConsoleKeyInfo consoleKeyInfo;
            Console.SetCursorPosition(0, 0);
            int index = 0;

            //DisplayMenu();

            if (index <= taskList.Count) // When the arrow down key is pressed first time
            {
                if (taskList[index].Status == 1) Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write(taskList[index].TaskName.PadRight(120, ' ')); // Rewrite it with matching index array item
            }

            while ((consoleKeyInfo = Console.ReadKey()).Key != ConsoleKey.F12)
            {
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.F1://skip
                        index++;
                        //index = (index >= taskList.Count ? 0 : ++index);
                        SkipTask(ref index, taskList);
                        break;
                    case ConsoleKey.F2://done
                        done(index, taskList);
                        //index = (index >= taskList.Count ? 0 : ++index);
                        index++;
                        SkipTask(ref index, taskList);
                        break;
                    case ConsoleKey.F3://Re-write
                        if (taskList[index].Status != 1)
                        {
                            done(index, taskList);
                            RewriteTask(index, taskList);
                            PrintTasks(index, taskList);
                        }

                        //index = (index >= taskList.Count ? 0 : ++index);
                        index++;
                        SkipTask(ref index, taskList);
                        break;
                    case ConsoleKey.F4://add a new task
                        AddTask(taskList);
                        PrintTasks(index, taskList);
                        Console.SetCursorPosition(0, index);
                        if (taskList[index].Status == 1) Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(taskList[index].TaskName.PadRight(120, ' '));
                        break;
                    default:
                        break;
                }
            }
        }

        public void SkipTask(ref int index, List<MyTask> taskList)
        {
            if (index >= 0 && index < taskList.Count)
            {
                Console.SetCursorPosition(0, index - 1);
                Console.ResetColor();
                if (taskList[index - 1].Status == 1) Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(taskList[index - 1].TaskName.PadRight(120, ' ')); // Rewrite it

                Console.SetCursorPosition(0, index);
                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.Green;
                if (taskList[index].Status == 1) Console.ForegroundColor = ConsoleColor.Red;

                Console.Write(taskList[index].TaskName.PadRight(120, ' ')); // Rewrite it
            }
            // When the index is same/greater than intArray length, keep it with the same value
            // So the index doesn't increment
            else if (index >= taskList.Count)
            {
                //index = taskList.Count - 1;
                //Console.SetCursorPosition(119, index);
                //Console.Write("\b \b");
                Console.SetCursorPosition(0, index - 1);
                Console.ResetColor();
                if (taskList[index - 1].Status == 1) Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(taskList[index - 1].TaskName.PadRight(120, ' ')); // Rewrite it
                index = 0;
                Console.SetCursorPosition(0, 0);
                if (taskList[index].Status == 1) Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Green;
                //Console.Write("\r" + new string(' ', Convert.ToString(taskList[index].TaskName).Length) + "\r"); // Clear current line
                Console.Write(taskList[index].TaskName.PadRight(120, ' '));

            }
        }

        public void done(int index, List<MyTask> taskList)
        {
            taskList[index].Status = 1;
        }

        public void RewriteTask(int index, List<MyTask> taskList)
        {
            taskList.Add(new MyTask(0, taskList[index].TaskName, DateTime.Now));
        }

        public void PrintTasks(int index, List<MyTask> taskList)
        {
            for (int i = 0; i < taskList.Count; i++)
            {
                if (taskList[i].Status == 1)
                {
                    Console.SetCursorPosition(0, i);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    //Console.Write("\r" + new string(' ', Convert.ToString(taskList[i].TaskName).Length) + "\r"); // Clear current line
                    Console.Write(taskList[i].TaskName);
                }
                else
                {
                    Console.SetCursorPosition(0, i);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    //Console.Write("\r" + new string(' ', Convert.ToString(taskList[i].TaskName).Length) + "\r"); // Clear current line
                    Console.Write(taskList[i].TaskName);
                }
                DisplayMenu();
                //if (taskList[index].Status == 1) Console.ForegroundColor = ConsoleColor.Red;
                //Console.BackgroundColor = ConsoleColor.Green;
                //Console.Write(taskList[index].TaskName.PadRight(120, ' '));
            }


        }
        public void AddTask(List<MyTask> taskList)
        {
            Console.SetCursorPosition(0, 0);
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("Enter a new task > ");
            taskList.Add(new MyTask(0, Console.ReadLine(), DateTime.Now));
            Console.SetCursorPosition(0, 0);
            Console.ResetColor();
            Console.Clear();

        }

        public static void DisplayMenu() //Menu
        {
            Console.WriteLine(new string('*', 120));
            Console.Write(" 1. Add Task");
            Console.Write(" || 2. Cross out");
            Console.Write(" || 3. Re-enter");
            Console.Write(" || 4. Skip");
            Console.WriteLine(" || 5. Exit");
            Console.WriteLine(new string('*', 120));
        }


    }


}



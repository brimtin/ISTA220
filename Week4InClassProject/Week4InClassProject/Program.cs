using System;
using System.Collections.Generic;
using System.Drawing;
namespace Week4InClassProject
{
    class Program
    {
    
        static List<string> LongList = new List<string>();
        

        static void Main(string[] args)
        {
            //List<string> item1 = new List<string>();
            // MenuItems(1);
            // Menu();
            //AddToList(1);
            //RetrieveItems(1);
            try
            {

                int.Parse("17");
            }
            catch (System.FormatException)
            {
                Console.WriteLine("\"Done!\"");
            }
            finally
            {
                Console.WriteLine("\"Done!\"");
            }
            
            






                Console.ReadLine();

        }

        //static void CreateList()
        //{

        //}

            static void Menu()
        {
            Console.WriteLine("Welcome To Brim's Long List Simple Scanning System!\n");
            Console.WriteLine("________________________________________________________________________");
            Console.WriteLine("1. Press 1 to view the list of Tasks");
            Console.WriteLine("2. Press 2 to create a new list of Taks");
            Console.WriteLine("3. Press 3 to exit the application");
            var input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    {
                        Console.Clear();
                        Console.WriteLine("List 1");
                        Console.WriteLine("List 2");
                        Console.WriteLine("List 3");
                        break;
                    }



            }
        }
        static void MenuItems(int itemNumber)
        {
            
            string[] menuItems = { "Next Item", "Skip Item", "Add Item", "Delete Item"};
            var selection = 0;

            do
            {
                Console.WriteLine($"1. {menuItems[0]}\t||\t2. {menuItems[1]}\t||\t3. {menuItems[2]}\t||\t4. {menuItems[3]}");
                int.TryParse(Console.ReadLine(), out selection);

                switch (selection)
                {
                    case 0:
                        {
                            Console.Clear();
                            break;
                          
                        }
                    case 1:
                        {
                            RetrieveItemsFromList(itemNumber);
                            Console.Clear();
                            break;
                        }
                    case 2:
                        {
                            RetrieveItemsFromList(itemNumber+1);
                            Console.Clear();

                            break;
                        }
                    case 3:
                        {
                            AddToList(itemNumber);
                            Console.Clear();
                            break;
                        }
                    case 4:
                        {
                            RemoveItemsFromList();
                            Console.Clear();
                            break;
                        }

                    default:
                        {
                            Console.Clear();
                            break;
                        }
                }
            } while (selection != 0);
            
        }

        static void ListSelected(int listNumer)
        {
           var input =  Console.ReadLine();
        }
        static void AddToList(int x)
        {
           
            var input = "";
            do
            {
                Console.Write("\nPlease input items to be added to the list");
                Console.Write("\nEnter save to save items to the list or x to delete last entry.........");
                input = Console.ReadLine();
                if (input.ToUpper() == "X")
                {
                    LongList.RemoveAt(LongList.Count - 1);
                }
                else
                {
                    LongList.Add(input);
                }
                
            } while (input.ToUpper() !="SAVE" );

            LongList.RemoveAt(LongList.Count-1);
            System.IO.File.WriteAllLines($@"C:\\Users\\brimt\\OneDrive\\Desktop\\MSSA\\ITSA220\\CodeFiles\\Week4InClassProject\\Week4InClassProject\\Items{x}.txt", LongList);

        }

        static void RetrieveItemsFromList(int x)
        {
            string [] item = System.IO.File.ReadAllLines($@"C:\\Users\\brimt\\OneDrive\\Desktop\\MSSA\\ITSA220\\CodeFiles\\Week4InClassProject\\Week4InClassProject\\Items{x}.txt");
            foreach (string line in item)
            { 
                Console.WriteLine(line);
            }

        }
        static void RemoveItemsFromList()
        {
            string itemToBeRemoved = "";
            do
            {
                Console.WriteLine("Enter exit when you are done deleting");
                Console.Write("\nWhich Item do you want to remove?.......");
                itemToBeRemoved = Console.ReadLine().ToUpper();

                for (int i = 0; i <= LongList.Count; i++)
                {
                    //var item = whichList(i);
                    if (LongList.Contains(itemToBeRemoved))
                    {
                        LongList.RemoveAt(i);
                    }
                }
            } while (itemToBeRemoved.ToUpper() != "EXIT");
        }
        

              
        
    }
}

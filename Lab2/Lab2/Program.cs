using System;
using System.Collections.Generic;
using System.IO;
using PG2Input;
using Newtonsoft.Json;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] SortingOptions = { "1. Bubble Sort", "2. Merge Sort", "3. Binary Search", "4. Save", "5. Exit" };

            List<string> list1 = new List<string>();
            list1 = GetCSVData();
                        
            List<string> BublbeStortedList = new List<string>();
            foreach (string s in list1)
                BublbeStortedList.Add(s);
            BublbeStortedList = PG2Sorting.bubblesort(BublbeStortedList);

            List<string> MergeSotedList = new List<string>();
            foreach (string s in list1)
                MergeSotedList.Add(s);
            MergeSotedList = PG2Sorting.mergsort(MergeSotedList);


            List<string> BinarySearchdList = new List<string>();
            foreach (string s in list1)
                BinarySearchdList.Add(s);
            BinarySearchdList.Sort();


            bool bHasExit = false;
            while (!bHasExit)
            {
                int input = 0;
                Input.ReadChoice("Please select an option below. \n", SortingOptions, out input);

                switch (input)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Bubble Sort");
                        PrintSortedLists(list1, BublbeStortedList);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Merge Sort");
                        PrintSortedLists(list1, MergeSotedList);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Binary Search");
                        PrintSearch(BinarySearchdList);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Save a search to JSON");
                        Console.WriteLine("Which search do you want to save?");
                        int savechoice;
                        Input.ReadChoice("1. Bubble \n 2. Merged \n", SortingOptions, out savechoice);
                        bool bHasSaved = false;
                        while (!bHasSaved)
                        {
                            switch (savechoice)
                            {
                                case 1:
                                    SaveList(MergeSotedList);
                                    bHasSaved = true;
                                    break;
                                case 2:
                                    SaveList(BublbeStortedList);
                                    bHasSaved = true;
                                    break;
                                default:
                                    Console.WriteLine("That is not a valid input, please enter a number shown");
                                    break;

                            }
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        bHasExit = true;
                        break;
                    default:
                        Console.WriteLine("That is not a valid input, please enter a number shown");
                        break;
                }

            }
            Console.WriteLine("You have exited the program. \n -- press any key to close this window --");
            Console.ReadKey();
        }
        
        public static List<string> GetCSVData()
        {
            string path = "@../../../../../../inputFile.csv";
            StreamReader Reader = new StreamReader(File.OpenRead(path));

            string TextInput = Reader.ReadToEnd();
            string[] Titles = TextInput.Split(',');
            List<string> data = new List<string>();
            foreach (string Title in Titles)
                data.Add(Title);
            Reader.Close();
            return data;

        }

        static void PrintSortedLists(List<string> input1, List<string>input2)
        {
            Console.WriteLine("---------------------------------------------");
            for (int i = 0; i < input1.Count; i++)
            {
                Console.Write(input1[i]);
                Console.CursorLeft = 50;
                Console.Write(input2[i]);
                Console.Write("\n");
            }
        }

        static void PrintSearch(List<string> searchlist)
        {
            for (int i = 0; i < searchlist.Count - 1; i++)
            {
                Console.Write(searchlist[i]);
                Console.CursorLeft = 45;
                Console.Write("Index: {0}", i);
                Console.CursorLeft = 60;
                Console.Write("Indexed At: {0}", PG2Sorting.BinarySearch(searchlist, searchlist[i], 0, searchlist.Count -1));
                Console.Write("\n");
            }
        }

        static void SaveList(List<string> input)
        {
            List<string> SaveList = new List<string>();
            foreach (string s in input)
                SaveList.Add(s);
            var tags = new { tags = SaveList };
            var json = JsonConvert.SerializeObject(tags);

            Console.WriteLine("Please name the save file");
            string FileName = Console.ReadLine();
            if (!FileName.Contains(".json"))
                FileName += ".json";

            string path = Path.Combine("@../../../../../../", FileName);
            StreamWriter sw = new StreamWriter(path);
            sw.Write(json);
            sw.Close();
            Console.WriteLine(FileName + " has been saved");
        }
    }
}

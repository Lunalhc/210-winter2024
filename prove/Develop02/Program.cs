using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        Console. WriteLine("Please select a number to continue");
        Console. WriteLine("1.start writing \n2.load history \n3.diplay the journal");

        int choice = int.Parse(Console.ReadLine());

        Prompt RandomPrompt = new Prompt();

        Journal journal = new Journal(); 
        string filePath = @"C:\Users\10759\Desktop\Programming with classes\CSE210-WINTER2024\210-winter2024\prove\Develop02\myjournal.csv"; 
        
        if (choice == 1)
        {

            Console.WriteLine("what's your name?");
            string name = Console.ReadLine();

            RandomPrompt.DisplayRandomPrompt();
            string response = Console.ReadLine();
            Entry entry = new Entry();
            entry._date = DateTime.Now.ToShortDateString();
            entry._name = name;
            entry._prompt = ""; 
            entry._response = response;
            journal.list_of_entries.Add(entry);
            journal.Save(filePath);

        }

        else if(choice == 2)
        {

            Console.WriteLine("What day do you want to see?");
            string select_date = Console.ReadLine();
            journal.Load(filePath);
    
    
            var entriesForDate = journal.list_of_entries.Where(entry => entry._date == select_date).ToList();
    
    
            if (entriesForDate.Count > 0)
            {
                foreach (var entry in entriesForDate)
                {
                    Console.WriteLine($"Date: {entry._date}, Name: {entry._name}, Prompt: {entry._prompt}, Response: {entry._response}");
                }
            }
            else
            {
                Console.WriteLine($"No entries found for date: {select_date}");
            }

        }


        else
        {
            journal.Load(filePath);
            journal.Display();

        }



    }

    
}
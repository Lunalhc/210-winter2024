using System;

class MainProgram
{
    static void Main(string[] args)
    {   
        // create an object of the scripture class
        Scripture scripture = new Scripture();
        // load the file from local folder
        scripture.LoadRandomVersesFromFile("Gospel of Matthew1.txt");
        
        // while loop to iterate until the user want to quit
        while (true)
        {
            scripture.DisplayCurrentVerse();

            Console.WriteLine("Press Enter to reveal more scripture, or type 'quit' to exit.");

            string input = Console.ReadLine().ToLower();  // read the user input and convert capitals to lowercase
            
            // end the program if user type quit
            if (input == "quit") 
                break;

            Console.Clear(); // clear the console

            scripture.HideWords();   // keep hiding words
        }
    }
}
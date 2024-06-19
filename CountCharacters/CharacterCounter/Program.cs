using System;

namespace CharacterCounter

{
    class Program
    {
        static void Main(string[] args)
        {
            char userCharacterToCount;

            //ask for user to input their sentence
            Console.WriteLine("Enter a sentence or phrase.");
            string userInput = Console.ReadLine();

            //initialize dictionary to store characters and counts
            Dictionary<char, int> characterCounts = new Dictionary<char, int>();

            foreach (char c in userInput)
            {
                //filter non alphabetical characters
                if (char.IsLetter(c))
                    //adds to count if character is already in dictionary
                    //creates new character in dictionary if not already existing
                    if (characterCounts.ContainsKey(c))
                    {
                        characterCounts[c]++;
                    }

                    else
                    {
                        characterCounts.Add(c,1);
                    }
            }

            //print results
            Console.WriteLine("Character Counts:");
            foreach (KeyValuePair<char, int> entry in characterCounts)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }
    }
}
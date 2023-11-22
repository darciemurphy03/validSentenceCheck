using System.Text.RegularExpressions;

namespace validSentenceCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter a sentence: ");
            string input = Console.ReadLine(); // Get user input

            bool isValid = IsValidSentence(input);

            if (isValid)  // Checks if sentence is valid and returns result
            {
                Console.WriteLine("The sentence is valid.");
            }
            else
            {
                Console.WriteLine("The sentence is not valid.");
            }
        }

        static bool IsValidSentence(string sentence)
        {
            // Rule 1: String starts with a capital letter
            if (string.IsNullOrWhiteSpace(sentence) || !char.IsUpper(sentence[0])) // Checks if the first character is blank or lowercase
            {
                return false;
            }

            // Rule 2: String has an even number of quotation marks
            int quotationMarkCount = 0;
            foreach (char c in sentence)    // Iterates through each character in the string 
            {
                if (c == '"')               // Checks if the character is a quotation mark
                {
                    quotationMarkCount++;
                }
            }
            
            if (quotationMarkCount % 2 != 0)  // Checks if the number of quotation marks is odd
            {
                return false;
            }

            // Rule 3: String ends with one of the following sentence termination characters: ".", "?", "!"
            char[] sentenceTerminationCharacters = { '.', '?', '!' };   // Array of the sentence termination characters
            char lastChar = sentence[sentence.Length - 1];              // Last character in the array

            if  (!sentenceTerminationCharacters.Contains(lastChar)) {   // Checks if the last character is equal to any of the termination characters
                return false; 
            }

            // Rule 4: String has no period characters other than the last character
            for (int i = 0; i < sentence.Length - 1; i++)
            {
                if (sentence[i] == '.' && i != sentence.Length - 2)     // Checks if the character at index 'i' is a full stop and not the last character
                {
                    return false;
                }
            }

            // Rule 5: Numbers below 13 are spelled out
            string[] words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries); // Splits the sentence into individual words. RemoveEmptyEntries ensures double spacing won't count as a word
            foreach (string word in words)  // Iterate through each word
            {
                if (int.TryParse(word, out int number) && number < 13)  // TryParse checks if the word can be converted to an integer. Also checking if number is less than 13
                {
                    return false;
                }
            }

            return true; // Returns true if all rules are met
        }

    }
}

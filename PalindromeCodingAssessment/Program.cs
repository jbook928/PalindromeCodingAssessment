using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace PalindromeCodingAssessment

{
    class Program
    {

        private static readonly Regex onlyAlphaNumeric = new Regex("[^a-zA-Z0-9']");

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a paragraph: ");
            Console.SetIn(new StreamReader(Console.OpenStandardInput(),
                               Console.InputEncoding,
                               false,
                               bufferSize: 1024));
            string paragraph = Console.ReadLine();

            // 1, 2
            ListWordAndSentenceCount(paragraph);

            // 3
            var allWords = GetCleanWords(paragraph);
            ListUniqueWordsAndCount(allWords);

            // 4 - let the user also input a letter at some point and list all words containing that letter  ---------------------------------------------------------------------------------
            Console.WriteLine();
            Console.WriteLine("Enter a letter: ");
            var userInput = Console.ReadLine();
            char letterInput;

            while (!Char.TryParse(userInput, out letterInput) || Char.IsNumber(letterInput))
            {
                Console.WriteLine("Please enter only a letter: ");
                userInput = Console.ReadLine();
            }

            ListWordsWithLetterInArray(letterInput, allWords);

        }

        static bool IsPalindrome(string value)
        {
            //remove all non-alphanumeric characters and convert the whole string to lowercase
            value = onlyAlphaNumeric.Replace(value, String.Empty).ToLower();

            //reverse the string
            var reversed = new string(value.Reverse().ToArray());

            //compare the two strings
            return value == reversed;
        }

        static string[] GetCleanWords(string value)
        {
            value = onlyAlphaNumeric.Replace(value, " ").ToLower();

            // Split the text into words.
            var words = value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return words;
        }

        static void ListWordAndSentenceCount(string value)
        {

            //break down paragraph into sentences
            string[] sentences = Regex.Split(value, @"(?<=[\.!\?])\s+");

            int palindromeWordCount = 0;
            int palindromeSentenceCount = 0;

            // 1 - give number of palindrome sentences ------------------------------------------------------------------------------------------------
            foreach (string sentence in sentences)
            {
                if (IsPalindrome(sentence))
                {
                    palindromeSentenceCount++;
                }

                //break sentence down into words
                string[] words = sentence.Split(' ');

                // 2 - give number of palindrome words  ------------------------------------------------------------------------------------------------
                foreach (string word in words)
                {
                    if (IsPalindrome(word))
                    {
                        palindromeWordCount++;
                    }
                }
            }

            Console.WriteLine("Number of palindrome words: {0}", palindromeWordCount);
            Console.WriteLine("Number of palindrome sentences: {0}", palindromeSentenceCount);

        }

        static void ListUniqueWordsAndCount(string[] array)
        {
            // 3 - list the unique words of a paragraph with the count of the word instance  ------------------------------------------------------------------------------------------------
            var uniqueWords = array
                            .GroupBy(grp => grp)
                            .Select(grp => new { Word = grp.Key, Count = grp.Count() })
                            .OrderByDescending(x => x.Count)
                            .ToList();

            Console.WriteLine();
            Console.WriteLine("Unique words with their count:");

            foreach (var item in uniqueWords)
            {
                Console.WriteLine("{0}: {1}", item.Word, item.Count);
            }
        }

        static void ListWordsWithLetterInArray(char letter, string[] array)
        {
            var wordsWithLetter = array.Where(x => x.Contains(letter)).ToArray();
            if (wordsWithLetter.Count() > 0)
            {
                Console.WriteLine("Words in paragraph that contain the letter {0}", letter);
                foreach (var word in wordsWithLetter)
                {
                    Console.WriteLine(word);
                }
            }
            else
            {
                Console.WriteLine("There are no words in the paragraph that contain the letter {0}", letter);
            }

        }

    }
}



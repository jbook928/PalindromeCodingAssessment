# PalindromeCodingAssessment
Humana / Enclara Pharmacia interview coding assessment

This application takes in an input (a paragraph) and:
1. Gives the number of palindrome words
2. Gives the number of palindrome sentences
3. Lists the unique words of a paragraph with the count of the word instance
4. Prompts the user for a letter and lists all words containing that letter

It does this in the following manner:
1. It splits the paragraph into sentences, then strips the sentences of all non-alphanumeric characters (not including apostrophes) to do a reverse string comparison and find out if the sentence is a palindrome.
2. It divides each sentence into words and looks for palindromes within those.
3. It uses LINQ to query the array of all words in the paragraph and find the count of each word occurrence, and orders by highest to lowest count.
4. Finally, after receiving and validating input from the user, uses LINQ and a lambda expression to find all words that contain that letter.

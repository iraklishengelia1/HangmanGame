using System;
using System.Collections.Generic;



List<string> words = new List<string> { "apple", "banana", "cherry", "date", "Blueberry", "pig", "grape", "honeydew", "kiwi", "lemon" };


Random random = new Random();
string wordtoguess = words[random.Next(words.Count)];


char[] wordtoguessarray = wordtoguess.ToCharArray();


char[] guessedLetters = new char[wordtoguess.Length];

for (int i = 0; i < wordtoguess.Length; i++)
{
    guessedLetters[i] = '_';
}


int maxAttempts = 7;
int attempts = 0;
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("----------------------------------------------------");
Console.WriteLine("Welcome to Hangman!");
Console.WriteLine($"The word to guess has {wordtoguess.Length} letters.");
Console.WriteLine("----------------------------------------------------");
Console.ResetColor();
while (attempts < maxAttempts)
{
    Console.WriteLine($"Guessed letters: {string.Join(" ", guessedLetters)}");

    Console.Write("Enter a letter: ");
    string input = Console.ReadLine();

    if (input.Length == 1)
    {
        char guess = input[0];


        bool found = false;
        for (int i = 0; i < wordtoguess.Length; i++)
        {
            if (wordtoguessarray[i] == guess)
            {
                guessedLetters[i] = guess;
                found = true;
            }
        }

        if (!found)
        {
            attempts++;
            Console.WriteLine($"Incorrect! You have {maxAttempts - attempts} attempts left.");
        }
    }
    else
    {
        Console.WriteLine("Invalid input! Please enter a single letter.");
    }


    if (string.Join("", guessedLetters) == wordtoguess)
    {
        Console.WriteLine($"Congratulations! You guessed the word '{wordtoguess}' correctly.");
        break;
    }
}


if (attempts == maxAttempts)
{
    Console.WriteLine($"Sorry, you couldn't guess the word '{wordtoguess}' within {maxAttempts} attempts.");
}
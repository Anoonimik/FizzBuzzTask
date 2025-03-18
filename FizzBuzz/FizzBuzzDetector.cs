using System.Text;

namespace FizzBuzz;

/// <summary>
///     Implementation of a FizzBuzz algorithm that processes strings according to specific rules.
///     The algorithm replaces every third word with "Fizz", every fifth word with "Buzz",
///     and words that are both third and fifth with "FizzBuzz". Only alphanumeric words are
///     counted and processed during the replacement.
/// </summary>
public class FizzBuzzDetector
{
    /// <summary>
    ///     Processes the input string according to FizzBuzz rules.
    /// </summary>
    /// <param name="input">The input string to process.</param>
    /// <returns>A Result object containing the processed string and count of replacements.</returns>
    /// <exception cref="ArgumentNullException">Thrown when input is null.</exception>
    /// <exception cref="ArgumentException">Thrown when input length is invalid.</exception>
    public Result GetOverlappings(string input)
    {
        // Validate input
        ValidateInput(input);

        var result = new StringBuilder();
        var wordCount = 0;
        var replacementCount = 0;

        // Process the input character by character
        var i = 0;
        var inWord = false;
        var currentWord = new StringBuilder();

        while (i < input.Length)
        {
            var currentChar = input[i];
            var isAlphaNumeric = IsAlphaNumeric(currentChar);

            if (isAlphaNumeric)
            {
                // Handle alphanumeric character
                if (!inWord)
                {
                    // Start of a new word
                    inWord = true;
                    currentWord.Clear();
                }

                currentWord.Append(currentChar);
            }
            else
            {
                // Handle non-alphanumeric character
                if (inWord)
                {
                    // End of a word, process it
                    inWord = false;
                    wordCount++;
                    // Apply FizzBuzz logic and append the result
                    if (ProcessWord(wordCount, currentWord, result)) replacementCount++;
                }

                // Preserve non-alphanumeric character
                result.Append(currentChar);
            }

            i++;
        }

        // Handle case where the string ends with a word
        if (inWord)
        {
            wordCount++;
            if (ProcessWord(wordCount, currentWord, result)) replacementCount++;
        }

        return new Result(result.ToString(), replacementCount);
    }

    /// <summary>
    ///     Validates that the input string meets the required constraints.
    /// </summary>
    /// <param name="input">The string to validate.</param>
    /// <exception cref="ArgumentNullException">Thrown when input is null.</exception>
    /// <exception cref="ArgumentException">Thrown when input length is invalid.</exception>
    private void ValidateInput(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) throw new ArgumentNullException(nameof(input), "Input string cannot be null");

        if (input.Length < 7 || input.Length > 100)
        {
            throw new ArgumentException("Input string length must be between 7 and 100 characters", nameof(input));
        }

    }

    /// <summary>
    ///     Processes a word according to FizzBuzz rules.
    /// </summary>
    /// <param name="wordCount">The count of the current word.</param>
    /// <param name="currentWord">The StringBuilder containing the current word.</param>
    /// <param name="result">The StringBuilder to append the processed word to.</param>
    /// <returns>True if a replacement was made, false otherwise.</returns>
    private bool ProcessWord(int wordCount, StringBuilder currentWord, StringBuilder result)
    {
        var isFizz = wordCount % 3 == 0;
        var isBuzz = wordCount % 5 == 0;

        if (isFizz && isBuzz)
        {
            result.Append("FizzBuzz");
            return true;
        }

        if (isFizz)
        {
            result.Append("Fizz");
            return true;
        }

        if (isBuzz)
        {
            result.Append("Buzz");
            return true;
        }

        result.Append(currentWord);
        return false;
    }

    /// <summary>
    ///     Determines if a character is alphanumeric (a letter or digit).
    /// </summary>
    /// <param name="c">The character to check.</param>
    /// <returns>True if the character is a letter or digit, false otherwise.</returns>
    private bool IsAlphaNumeric(char c)
    {
        // Check if digit (0-9)
        if (c >= '0' && c <= '9') return true;

        // Check if uppercase letter (A-Z)
        if (c >= 'A' && c <= 'Z') return true;

        // Check if lowercase letter (a-z)
        if (c >= 'a' && c <= 'z') return true;
        
        //Check if apostrophe letter (')
        if (c == 39) return true;
        return false;
    }

    /// <summary>
    ///     Class to store the result of FizzBuzz processing.
    /// </summary>
    public class Result
    {
        /// <summary>
        ///     The count of replacements made (Fizz, Buzz, or FizzBuzz).
        /// </summary>
        public readonly int Count;

        /// <summary>
        ///     The processed output string with replacements.
        /// </summary>
        public readonly string OutputString;

        /// <summary>
        ///     Initializes a new instance of the Result class.
        /// </summary>
        /// <param name="outputString">The processed output string.</param>
        /// <param name="count">The count of replacements made.</param>
        public Result(string outputString, int count)
        {
            OutputString = outputString;
            Count = count;
        }
    }
}
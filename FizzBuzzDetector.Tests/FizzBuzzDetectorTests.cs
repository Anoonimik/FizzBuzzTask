
namespace FizzBuzzDetector.Tests
{
  /// <summary>
  /// Test class for the FizzBuzzDetector implementation.
  /// </summary>
  public class FizzBuzzDetectorTests
  {
    /// <summary>
    /// Tests the example case provided in the requirements specification.
    /// </summary>
    [Fact]
    public void TestExampleCase()
        {
            // Input from the requirements
            string input = "Mary had a little lamb Little lamb, little lamb Mary had a little lamb It's fleece was white as snow";

            FizzBuzz.FizzBuzzDetector detector = new FizzBuzz.FizzBuzzDetector();
            FizzBuzz.FizzBuzzDetector.Result result = detector.GetOverlappings(input);

            // Expected output as specified in requirements
            string expected = @"Mary had Fizz little Buzz Fizz lamb, little Fizz Buzz had Fizz little lamb FizzBuzz fleece was Fizz as Buzz";

            Assert.Equal(expected, result.OutputString);
            Assert.Equal(9, result.Count);
        }

        /// <summary>
        /// Tests that an ArgumentNullException is thrown when input is null.
        /// </summary>
        [Fact]
        public void TestNullInput()
        {
            FizzBuzz.FizzBuzzDetector detector = new FizzBuzz.FizzBuzzDetector();

            Assert.Throws<ArgumentNullException>(() => detector.GetOverlappings(null));
        }

        /// <summary>
        /// Tests that an ArgumentException is thrown when input is too short.
        /// </summary>
        [Fact]
        public void TestTooShortInput()
        {
            FizzBuzz.FizzBuzzDetector detector = new FizzBuzz.FizzBuzzDetector();

            Assert.Throws<ArgumentException>(() => detector.GetOverlappings("Short")); // 5 characters, minimum is 7
        }

        /// <summary>
        /// Tests that an ArgumentException is thrown when input is too long.
        /// </summary>
        [Fact]
        public void TestTooLongInput()
        {
            FizzBuzz.FizzBuzzDetector detector = new FizzBuzz.FizzBuzzDetector();

            // Create a string of length 101 (exceeding the maximum of 100)
            string longInput = new string('a', 101);

            Assert.Throws<ArgumentException>(() => detector.GetOverlappings(longInput));
        }

        /// <summary>
        /// Tests handling of special characters and punctuation.
        /// </summary>
        [Fact]
        public void TestSpecialCharacters()
        {
            string input = "One! Two@ Three# Four$ Five% Six^ Seven&";

            FizzBuzz.FizzBuzzDetector detector = new FizzBuzz.FizzBuzzDetector();
            FizzBuzz.FizzBuzzDetector.Result result = detector.GetOverlappings(input);

            string expected = "One! Two@ Fizz# Four$ Buzz% Fizz^ Seven&";

            Assert.Equal(expected, result.OutputString);
            Assert.Equal(3, result.Count);
        }

        /// <summary>
        /// Tests a series of consecutive FizzBuzz replacements.
        /// </summary>
        [Fact]
        public void TestConsecutiveReplacements()
        {
            string input = "one two three four five six seven eight nine ten eleven twelve thirteen fourteen fifteen";

            FizzBuzz.FizzBuzzDetector detector = new FizzBuzz.FizzBuzzDetector();
            FizzBuzz.FizzBuzzDetector.Result result = detector.GetOverlappings(input);

            string expected = "one two Fizz four Buzz Fizz seven eight Fizz Buzz eleven Fizz thirteen fourteen FizzBuzz";

            Assert.Equal(expected, result.OutputString);
            Assert.Equal(7, result.Count);
        }

        /// <summary>
        /// Tests handling of multiple spaces between words.
        /// </summary>
        [Fact]
        public void TestMultipleSpaces()
        {
            string input = "one    two  three    four     five";

            FizzBuzz.FizzBuzzDetector detector = new FizzBuzz.FizzBuzzDetector();
            FizzBuzz.FizzBuzzDetector.Result result = detector.GetOverlappings(input);

            string expected = "one    two  Fizz    four     Buzz";

            Assert.Equal(expected, result.OutputString);
            Assert.Equal(2, result.Count);
        }

        /// <summary>
        /// Tests handling of non-alphanumeric words.
        /// </summary>
        [Fact]
        public void TestNonAlphanumericWords()
        {
            string input = "1 2 &*! 3 4 %%% 5 6";

            FizzBuzz.FizzBuzzDetector detector = new FizzBuzz.FizzBuzzDetector();
            FizzBuzz.FizzBuzzDetector.Result result = detector.GetOverlappings(input);

            // Only digits should be counted as words, not the symbols
            string expected = "1 2 &*! Fizz 4 %%% Buzz Fizz";

            Assert.Equal(expected, result.OutputString);
            Assert.Equal(3, result.Count);
        }
    }
}
using Microsoft.VisualStudio.TestPlatform.TestHost;
namespace validSentenceTesting
{
    using validSentenceCheck;
    [TestClass]
    public class ValidSentenceTests
    {

        // Tests for Rule 1: String starts with a capital letter
        [TestMethod]
        public void SentenceStartsWithCapitalLetter()
        {
            // Arrange
            string sentence = "The quick brown fox said “hello Mr lazy dog”.";

            // Act
            bool isValid = Program.IsValidSentence(sentence);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void SentenceStartsWithLowerCaseLetter()
        {
            // Arrange
            string sentence = "the quick brown fox said “hello Mr lazy dog.";

            // Act
            bool isValid = Program.IsValidSentence(sentence);

            // Assert
            Assert.IsFalse(isValid);
        }

        // Tests for Rule 2: String has an even number of quotation marks
        [TestMethod]
        public void SentenceContainsEvenDoubleQuotationMarks()
        {
            // Arrange
            string sentence = "The quick brown fox said “hello Mr lazy dog.\"";

            // Act
            bool isValid = Program.IsValidSentence(sentence);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void SentenceDoesntContainEvenDoubleQuotationMarks()
        {
            // Arrange
            string sentence = "The quick brown fox said “hello Mr lazy dog.";

            // Act
            bool isValid = Program.IsValidSentence(sentence);

            // Assert
            Assert.IsTrue(isValid);
        }

        // Tests for Rule 3: String ends with one of the following sentence termination characters: ".", "?", "!"
        [TestMethod]
        public void SentenceEndsWithValidTerminationCharacter()
        {
            // Arrange
            string sentence = "The quick brown fox said hello Mr lazy dog.";

            // Act
            bool isValid = Program.IsValidSentence(sentence);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void SentenceEndsWithInvalidTerminationCharacter()
        {
            // Arrange
            string sentence = "There is no punctuation in this sentence";

            // Act
            bool isValid = Program.IsValidSentence(sentence);

            // Assert
            Assert.IsFalse(isValid);
        }

        // Tests for Rule 4: String has no period characters other than the last character
        [TestMethod]
        public void NoPeriodCharactersOtherThanLastCharacter()
        {
            // Arrange
            string sentence = "The quick brown fox said hello Mr lazy dog.";

            // Act
            bool isValid = Program.IsValidSentence(sentence);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void PeriodCharactersOtherThanLastCharacter()
        {
            // Arrange
            string sentence = "The quick brown fox said hello Mr. lazy dog.";

            // Act
            bool isValid = Program.IsValidSentence(sentence);

            // Assert
            Assert.IsFalse(isValid);
        }

        // Tests for Rule 5: Numbers below 13 are spelled out
        [TestMethod]
        public void NumbersBelow13AreSpelledOut()
        {
            // Arrange
            string sentence = "One lazy dog is too few, twelve is too many.";

            // Act
            bool isValid = Program.IsValidSentence(sentence);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void NumbersBelow13AreNotSpelledOut()
        {
            // Arrange
            string sentence = "One lazy dog is too few, 12 is too many.";

            // Act
            bool isValid = Program.IsValidSentence(sentence);

            // Assert
            Assert.IsFalse(isValid);
        }

    }
}

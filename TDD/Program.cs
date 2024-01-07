using Xunit;

namespace TDD
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }

    // Testklasse
    public class StringCalculatorTests
    {
        [Fact]
        public void Add_EmptyString_ReturnsZero()
        {
            
            var calculator = new StringCalculator();

            
            var result = calculator.Add("");

            
            Assert.Equal(0, result);
        }
    }

    
    public class StringCalculator
    {
        private int calledCount;

        public int CalledCount => calledCount;

        public int Add(string numbers)
        {
            calledCount++;

            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }

            var delimiter = ',';

            if (numbers.StartsWith("//"))
            {
                delimiter = numbers[2];
                numbers = numbers.Substring(4);
            }

            var splitNumbers = numbers.Split(new[] { delimiter, '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int sum = 0;

            List<int> negativeNumbers = new List<int>();

            foreach (var num in splitNumbers)
            {
                int parsedNum = int.Parse(num);
                if (parsedNum < 0)
                {
                    negativeNumbers.Add(parsedNum);
                }

                if (parsedNum <= 1000)
                {
                    sum += parsedNum;
                }
            }

            if (negativeNumbers.Any())
            {
                throw new InvalidOperationException($"negatives not allowed {string.Join(", ", negativeNumbers)}");
            }

            return sum;
        }

    }

}
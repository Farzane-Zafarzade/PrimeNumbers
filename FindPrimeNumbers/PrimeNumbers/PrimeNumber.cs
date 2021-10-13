namespace FindPrimeNumbers.PrimeNumbers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="PrimeNumber" />.
    /// </summary>
    public class PrimeNumber
    {
        /// <summary>
        /// Gets or sets the number that will be checked.
        /// </summary>
        public long Value { get; set; }

        /// <summary>
        /// Defines the listOfPrimes to store all the Prime numbers.
        /// </summary>
        public List<long> listOfPrimes = new();

        /// <summary>
        /// Checks whether the number is a Prime number.
        /// </summary>
        /// <param name="value">The value<see cref="int"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool IsPrime(long value)
        {
            var possibleFactors = Math.Sqrt(value);

            for (var factor = 2; factor <= possibleFactors; factor++)
            {
                if (value % factor == 0)
                {
                    return false;
                }
            }
            listOfPrimes.Add(value);
            return value > 1;
        }

        /// <summary>
        /// Shows all Prime numbers in the list.
        /// </summary>
        public void PrintList()
        {
            if (listOfPrimes?.Count > 0)
            {
                listOfPrimes.Sort();
                foreach (var number in listOfPrimes)
                {
                    Console.Write(" {0} ,", number);
                }
            }
            else
            {
                Console.WriteLine("\n There is no Prime number");
            }
        }

        /// <summary>
        /// Generates the next Prime number.
        /// Sorts the list and then Generates the next prime number based on the highest in the list.
        /// </summary>
        public void GenerateNextPrimNumber()
        {
            if (listOfPrimes?.Count > 0)
            {
                listOfPrimes.Sort();
                var index = listOfPrimes.Count;
                Value = listOfPrimes[index - 1];
                do
                {
                    Value += 2;

                } while (!IsPrime(Value));
            }
            else
            {
                Value = 2;
                listOfPrimes.Add(Value);
            }
            Console.WriteLine("\n The next Prime number is {0}", Value);
        }
    }
}

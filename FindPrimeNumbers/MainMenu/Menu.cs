namespace FindPrimeNumbers.MainMenu
{
    using FindPrimeNumbers.PrimeNumbers;
    using System;

    /// <summary>
    /// Defines the <see cref="Menu" />.
    /// </summary>
    internal class Menu
    {
        /// <summary>
        /// Creats an object from PrimeNumber class
        /// </summary>
        private PrimeNumber number = new();

        /// <summary>
        /// Shows the options and user can choose one of them.
        /// Checks if user choose a valid option and then show the process of the selected option.
        /// </summary>
        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("\n 1. Check Prime numbers\n");
            Console.WriteLine(" 2. Add the next prime number\n");
            Console.WriteLine(" 3. Show all Prime numbers\n");
            Console.WriteLine(" 4. Exit\n");
            Console.WriteLine(" \n------------------\n");
            Console.Write(" Select an option: ");
            _ = int.TryParse(Console.ReadLine(), out int choice);
            while (choice != 1 && choice != 2 && choice != 3 && choice != 4)
            {
                Console.Write("\n Invalid input, try again: ");
                _ = int.TryParse(Console.ReadLine(), out choice);
            }

            ShowSelectedOption(choice);
        }

        /// <summary>
        /// Gets the option that is chosen by user and show the process of the selected option.
        /// </summary>
        /// <param name="choice">The choice<see cref="int"/>.</param>
        public void ShowSelectedOption(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    CheckNumbers();
                    BackToMenu();
                    break;

                case 2:
                    Console.Clear();
                    number.GenerateNextPrimNumber();
                    BackToMenu();
                    break;

                case 3:
                    Console.Clear();
                    number.PrintList();
                    BackToMenu();
                    break;

                case 4:
                    System.Environment.Exit(1);
                    break;
            }
        }

        /// <summary>
        /// Asks for a number from user to check if that is a Prime number or not and the shows the result to user.
        /// Checks if the input is valid or not. If input is not a digit the program will show an error message.
        /// asks the user whether want to continue checking or return to the menu.
        /// </summary>
        public void CheckNumbers()
        {
            bool repeat = true;

            while (repeat)
            {
                bool valid;

                Console.Write("\n Please enter number you want to check: ");
                string input = Console.ReadLine();
                valid = long.TryParse(input, out long i);
                while (!valid)
                {
                    Console.Write("\n Invalid input, Try again: ");
                    valid = long.TryParse(Console.ReadLine(), out i);
                }
                number.Value = i;
                if (number.IsPrime(number.Value))
                {
                    Console.WriteLine("\n The number is prime");
                }
                else
                {
                    Console.WriteLine("\n The number is not prime");
                }

                Console.Write("\n Continue?: (y/n)  ");
                input = CheckInput((Console.ReadLine()).ToLower().Trim());
                if (input == "n")
                {
                    repeat = false;
                }
            }
        }

        /// <summary>
        /// Asks the user whether want to return to menu.
        /// If the user choose 'y' returns to menu and if user choose 'n' the program will exit.
        /// </summary>
        private void BackToMenu()
        {
            Console.Write("\n Do you want to back to menu: (y/n)  ");
            string input = CheckInput(Console.ReadLine().ToLower().Trim());

            if (input == "y")
            {
                ShowMenu();
            }
            else
            {
                System.Environment.Exit(1);
            }
        }

        /// <summary>
        /// Checks whether the input is 'n' or 'y'. If the input will be invalid, shows an error message.
        /// </summary>
        /// <param name="input">The input<see cref="string"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private string CheckInput(string input)
        {
            while (input != "n" && input != "y")
            {
                Console.Write("\n Invalid input, enter 'y' or 'n': ");
                input = Console.ReadLine().ToLower().Trim();
            }

            return input;
        }
    }
}

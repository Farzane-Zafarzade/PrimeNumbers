namespace FindPrimeNumbers
{
    using FindPrimeNumbers.MainMenu;

    internal static class Program
    {
        internal static void Main(string[] args)
        {
            Menu myMenu = new();
            myMenu.ShowMenu();
        }
    }
}

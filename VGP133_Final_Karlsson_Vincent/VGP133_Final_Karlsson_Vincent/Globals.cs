using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VGP133_Final_Karlsson_Vincent
{
    public static class Globals
    {
        public static void ClearConsoleLines(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', Console.BufferWidth));
                Console.SetCursorPosition(0, Console.CursorTop);
            }
        }

        public static bool ValidateIntInput(ref int input, int minInclusive, int maxRangeExclusive)
        {
            if (input < minInclusive || input >= maxRangeExclusive)
            {
                input = 0;
                return false;
            }

            return true;
        }

        public static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public static void ClearConsoleLinesBasedOnError(ref bool error)
        {
            if (error == false)
            {
                error = true;
                ClearConsoleLines(1);
            }
            else
            {
                ClearConsoleLines(2);
            }
        }

        public static int GetMenuChoice<T>() where T : Enum
        {
            int input = 0;
            int menuCount = Enum.GetValues(typeof(T)).Length;

            while (input == 0)
            {
                while (Int32.TryParse(Console.ReadLine(), out input) == false)
                {
                    ClearConsoleLines(1);
                }

                if (ValidateIntInput(ref input, 1, menuCount) == false)
                {
                    ClearConsoleLines(1);
                }
            }

            return input;
        }
    }
}

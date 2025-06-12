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

        public static bool ValidateIntInput(ref int input, int maxRangeExclusive)
        {
            if (input <= 0 || input >= maxRangeExclusive)
            {
                input = 0;
                return false;
            }

            return true;
        }
    }
}
